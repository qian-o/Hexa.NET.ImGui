﻿namespace Generator
{
    using CppAst;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    public partial class CsCodeGenerator
    {
        public readonly HashSet<string> DefinedFunctions = [];
        public readonly HashSet<string> LibDefinedFunctions = [];
        public readonly HashSet<string> DefinedVariationsFunctions = [];
        public readonly HashSet<string> OutReturnFunctions = [];

        public int VTableLength { get; private set; }

        private bool FilterFunction(CsCodeGeneratorSettings settings, CppFunction cppFunction)
        {
            if (!cppFunction.IsPublicExport())
            {
                return true;
            }

            if (settings.AllowedFunctions.Count != 0 && !settings.AllowedFunctions.Contains(cppFunction.Name))
            {
                return true;
            }

            if (settings.IgnoredFunctions.Contains(cppFunction.Name))
            {
                return true;
            }

            var cppHeader = $"{cppFunction.ReturnType} {cppFunction.Name}({string.Join(", ", cppFunction.Parameters)})";

            if (LibDefinedFunctions.Contains(cppHeader))
            {
                return true;
            }

            if (DefinedFunctions.Contains(cppHeader))
            {
                return true;
            }

            DefinedFunctions.Add(cppHeader);

            return false;
        }

        private void GenerateFunctions(CppCompilation compilation, string outputPath)
        {
            DefinedVariationsFunctions.Clear();
            string[] usings = { "System", "System.Runtime.CompilerServices", "System.Runtime.InteropServices", "HexaGen.Runtime" };

            string outDir = Path.Combine(outputPath, "Functions");
            string filePath = Path.Combine(outDir, "Functions.cs");

            if (Directory.Exists(outDir))
            {
                Directory.Delete(outDir, true);
            }

            Directory.CreateDirectory(outDir);

            using var writer = new SplitCodeWriter(filePath, settings.Namespace, 2, usings.Concat(settings.Usings).ToArray());

            VTableBuilder vTableBuilder = new(settings.VTableStart);
            using (writer.PushBlock($"public unsafe partial class {settings.ApiName}"))
            {
                if (!settings.UseVTable)
                {
                    writer.WriteLine($"internal const string LibName = \"{settings.LibName}\";\n");
                }

                List<CsFunction> commands = new();
                for (int i = 0; i < compilation.Functions.Count; i++)
                {
                    CppFunction? cppFunction = compilation.Functions[i];
                    if (FilterFunction(settings, cppFunction))
                    {
                        continue;
                    }

                    string? csName = settings.GetPrettyCommandName(cppFunction.Name);
                    string returnCsName = settings.GetCsTypeName(cppFunction.ReturnType, false);
                    CppPrimitiveKind returnKind = cppFunction.ReturnType.GetPrimitiveKind(false);

                    bool boolReturn = returnCsName == "bool";
                    bool canUseOut = OutReturnFunctions.Contains(cppFunction.Name);
                    var argumentsString = settings.GetParameterSignature(cppFunction.Parameters, canUseOut);
                    var header = $"{returnCsName} {csName}Native({argumentsString})";

                    WriteCsSummary(cppFunction.Comment, writer);

                    string? modifierString = null;

                    switch (settings.ImportType)
                    {
                        case ImportType.DllImport:
                            writer.WriteLine($"[LibraryImport(LibName, EntryPoint = \"{cppFunction.Name}\")]");
                            writer.WriteLine($"[UnmanagedCallConv(CallConvs = new Type[] {{typeof({cppFunction.CallingConvention.GetCallingConventionLibrary()})}})]");
                            modifierString = "internal static partial";
                            break;

                        case ImportType.LibraryImport:
                            writer.WriteLine($"[DllImport(LibName, CallingConvention = CallingConvention.{cppFunction.CallingConvention.GetCallingConvention()}, EntryPoint = \"{cppFunction.Name}\")]");
                            modifierString = "internal static extern";
                            break;

                        case ImportType.VTable:
                            if (boolReturn)
                            {
                                writer.BeginBlock($"internal static byte {csName}Native({argumentsString})");
                            }
                            else
                            {
                                writer.BeginBlock($"internal static {header}");
                            }

                            string returnType = settings.GetCsTypeName(cppFunction.ReturnType);
                            if (returnType == "bool")
                            {
                                returnType = settings.GetBoolType();
                            }
                            string delegateType;
                            if (cppFunction.Parameters.Count == 0)
                            {
                                delegateType = $"delegate* unmanaged[{cppFunction.CallingConvention.GetCallingConventionDelegate()}]<{returnType}>";
                            }
                            else
                            {
                                delegateType = $"delegate* unmanaged[{cppFunction.CallingConvention.GetCallingConventionDelegate()}]<{settings.GetNamelessParameterSignature(cppFunction.Parameters, false, true)}, {returnType}>";
                            }

                            writer.WriteLine("#if NET5_0_OR_GREATER");
                            // isolates the argument names
                            string argumentNames = settings.WriteFunctionMarshalling(cppFunction.Parameters);

                            int vTableIndex = vTableBuilder.Add(cppFunction.Name);

                            if (returnCsName == "void")
                            {
                                writer.WriteLine($"(({delegateType})vt[{vTableIndex}])({argumentNames});");
                            }
                            else
                            {
                                writer.WriteLine($"return (({delegateType})vt[{vTableIndex}])({argumentNames});");
                            }

                            writer.WriteLine("#else");

                            string returnTypeOld = settings.GetCsTypeName(cppFunction.ReturnType);
                            if (returnTypeOld == "bool")
                            {
                                returnTypeOld = settings.GetBoolType();
                            }
                            if (returnTypeOld.Contains('*'))
                            {
                                returnTypeOld = "nint";
                            }
                            string delegateTypeOld;
                            if (cppFunction.Parameters.Count == 0)
                            {
                                delegateTypeOld = $"delegate* unmanaged[{cppFunction.CallingConvention.GetCallingConventionDelegate()}]<{returnTypeOld}>";
                            }
                            else
                            {
                                delegateTypeOld = $"delegate* unmanaged[{cppFunction.CallingConvention.GetCallingConventionDelegate()}]<{settings.GetNamelessParameterSignature(cppFunction.Parameters, false, true, compatibility: true)}, {returnTypeOld}>";
                            }

                            string argumentNamesOld = settings.WriteFunctionMarshalling(cppFunction.Parameters, compatibility: true);

                            if (returnCsName == "void")
                            {
                                writer.WriteLine($"(({delegateTypeOld})vt[{vTableIndex}])({argumentNamesOld});");
                            }
                            else
                            {
                                writer.WriteLine($"return ({returnType})(({delegateTypeOld})vt[{vTableIndex}])({argumentNamesOld});");
                            }

                            writer.WriteLine("#endif");

                            writer.EndBlock();
                            break;
                    }

                    if (modifierString != null)
                    {
                        if (boolReturn)
                        {
                            writer.WriteLine($"{modifierString} byte {csName}Native({argumentsString});");
                        }
                        else
                        {
                            writer.WriteLine($"{modifierString} {header};");
                        }
                    }

                    writer.WriteLine();

                    CsFunction? function = null;
                    for (int j = 0; j < commands.Count; j++)
                    {
                        if (commands[j].Name == csName)
                        {
                            function = commands[j];
                            break;
                        }
                    }

                    if (function == null)
                    {
                        WriteCsSummary(cppFunction.Comment, out string? comment);
                        function = new(csName, comment);
                        commands.Add(function);
                    }

                    CsFunctionOverload overload = new(cppFunction.Name, csName, "", false, false, false, new(returnCsName, returnKind));
                    for (int j = 0; j < cppFunction.Parameters.Count; j++)
                    {
                        var cppParameter = cppFunction.Parameters[j];
                        var paramCsTypeName = settings.GetCsTypeName(cppParameter.Type, false);
                        var paramCsName = settings.GetParameterName(cppParameter.Type, cppParameter.Name);
                        var direction = cppParameter.Type.GetDirection();
                        var kind = cppParameter.Type.GetPrimitiveKind(false);

                        CsType csType = new(paramCsTypeName, kind);

                        CsParameterInfo csParameter = new(paramCsName, csType, direction);

                        overload.Parameters.Add(csParameter);
                        if (settings.TryGetDefaultValue(cppFunction.Name, cppParameter, false, out var defaultValue))
                        {
                            overload.DefaultValues.Add(paramCsName, defaultValue);
                        }
                    }

                    function.Overloads.Add(overload);
                    GenerateVariations(cppFunction.Parameters, overload, false);
                    WriteMethods(writer, DefinedVariationsFunctions, function, overload, false, false, "public static");
                }
            }

            if (settings.UseVTable)
            {
                var initString = vTableBuilder.Finish(out var count);
                string filePathVT = Path.Combine(outputPath, "Functions.VT.cs");
                using var writerVt = new CodeWriter(filePathVT, settings.Namespace, usings.Concat(settings.Usings).ToArray());
                using (writerVt.PushBlock($"public unsafe partial class {settings.ApiName}"))
                {
                    writerVt.WriteLine("internal static VTable vt;");
                    writerVt.WriteLine();
                    using (writerVt.PushBlock("public static void InitApi()"))
                    {
                        writerVt.WriteLine($"vt = new VTable(GetLibraryName(), {count});");
                        writerVt.WriteLines(initString);
                    }
                    writerVt.WriteLine();
                    using (writerVt.PushBlock("public static void FreeApi()"))
                    {
                        writerVt.WriteLine("vt.Free();");
                    }
                }

                VTableLength = count;
            }
        }

        public void WriteMethods(ICodeWriter writer, HashSet<string> definedFunctions, CsFunction csFunction, CsFunctionOverload overload, bool useThis, bool useHandle, params string[] modifiers)
        {
            for (int j = 0; j < overload.Variations.Count; j++)
            {
                WriteMethod(writer, definedFunctions, csFunction, overload, overload.Variations[j], useThis, useHandle, modifiers);
            }
        }

        private void WriteMethod(ICodeWriter writer, HashSet<string> definedFunctions, CsFunction function, CsFunctionOverload overload, CsFunctionVariation variation, bool useThis, bool useHandle, params string[] modifiers)
        {
            CsType csReturnType = variation.ReturnType;
            if (WrappedPointers.TryGetValue(csReturnType.Name, out string? value))
            {
                csReturnType.Name = value;
            }

            for (int i = 0; i < variation.Parameters.Count; i++)
            {
                var cppParameter = variation.Parameters[i];
                if (WrappedPointers.TryGetValue(cppParameter.Type.Name, out string? v))
                {
                    cppParameter.Type.Name = v;
                    cppParameter.Type.Classify();
                }
            }

            string modifierString = string.Join(" ", modifiers);
            string signature;

            if (useThis || useHandle)
            {
                signature = string.Join(", ", variation.Parameters.Skip(1).Select(x => $"{x.Type} {x.Name}"));
            }
            else
            {
                signature = string.Join(", ", variation.Parameters.Select(x => $"{x.Type} {x.Name}"));
            }

            string header = $"{csReturnType.Name} {variation.Name}({signature})";

            if (definedFunctions.Contains(header))
            {
                return;
            }
            definedFunctions.Add(header);

            Console.WriteLine(header);

            if (function.Comment != null)
            {
                writer.Write(function.Comment);
            }

            using (writer.PushBlock($"{modifierString} {header}"))
            {
                StringBuilder sb = new();
                bool firstParamReturn = false;
                if (!csReturnType.IsString && csReturnType.Name != overload.ReturnType.Name)
                {
                    firstParamReturn = true;
                }

                int offset = firstParamReturn ? 1 : 0;

                bool hasManaged = false;
                for (int j = 0; j < overload.Parameters.Count - offset; j++)
                {
                    var cppParameter = overload.Parameters[j + offset];
                    if (variation.HasParameter(cppParameter))
                    {
                        continue;
                    }

                    var paramCsDefault = overload.DefaultValues[cppParameter.Name];
                    if (cppParameter.Type.IsString || paramCsDefault.StartsWith("\"") && paramCsDefault.EndsWith("\""))
                    {
                        hasManaged = true;
                    }
                }

                if (!firstParamReturn && (!csReturnType.IsVoid || csReturnType.IsVoid && csReturnType.IsPointer))
                {
                    if (csReturnType.IsBool && !csReturnType.IsPointer && !hasManaged)
                    {
                        sb.Append($"byte ret = ");
                    }
                    else
                    {
                        sb.Append($"{csReturnType.Name} ret = ");
                    }
                }

                if (csReturnType.IsString)
                {
                    WriteStringConvertToManaged(sb, variation.ReturnType);
                }

                if (useThis || useHandle)
                {
                    sb.Append($"{settings.ApiName}.");
                }

                if (hasManaged)
                {
                    sb.Append($"{overload.Name}(");
                }
                else if (firstParamReturn)
                {
                    sb.Append($"{overload.Name}Native(&ret" + (overload.Parameters.Count > 1 ? ", " : ""));
                }
                else
                {
                    sb.Append($"{overload.Name}Native(");
                }

                Stack<(string, CsParameterInfo, string)> stack = new();
                int strings = 0;
                Stack<string> arrays = new();
                int stacks = 0;

                for (int i = 0; i < overload.Parameters.Count - offset; i++)
                {
                    var cppParameter = overload.Parameters[i + offset];
                    var isRef = false;
                    var isSpan = false;
                    var isPointer = false;
                    var isStr = false;
                    var isArray = false;
                    var isBool = false;
                    var isConst = true;

                    for (int j = 0; j < variation.Parameters.Count; j++)
                    {
                        var param = variation.Parameters[j];
                        if (param.Name == cppParameter.Name)
                        {
                            cppParameter = param;
                            isRef = param.Type.IsRef;
                            isSpan = param.Type.IsSpan;
                            isPointer = param.Type.IsPointer;
                            isStr = param.Type.IsString;
                            isArray = param.Type.IsArray;
                            isBool = param.Type.IsBool;
                            isConst = false;
                        }
                    }
                    if (useHandle && i == 0)
                    {
                        sb.Append("Handle");
                    }
                    else if (useThis && i == 0 && overload.Parameters[i].Type.IsPointer)
                    {
                        writer.BeginBlock($"fixed ({overload.Parameters[i].Type.Name} @this = &this)");
                        sb.Append("@this");
                        stacks++;
                    }
                    else if (useThis && i == 0)
                    {
                        sb.Append("this");
                    }
                    else if (isConst)
                    {
                        var rootParam = overload.Parameters[i + offset];
                        var paramCsDefault = overload.DefaultValues[cppParameter.Name];
                        if (cppParameter.Type.IsString || paramCsDefault.StartsWith("\"") && paramCsDefault.EndsWith("\""))
                        {
                            sb.Append($"(string){paramCsDefault}");
                        }
                        else if (cppParameter.Type.IsBool && !cppParameter.Type.IsPointer && !cppParameter.Type.IsArray)
                        {
                            sb.Append($"(byte)({paramCsDefault})");
                        }
                        else if (cppParameter.Type.IsPrimitive || cppParameter.Type.IsPointer || cppParameter.Type.IsArray)
                        {
                            sb.Append($"({rootParam.Type.Name})({paramCsDefault})");
                        }
                        else
                        {
                            sb.Append($"{paramCsDefault}");
                        }
                    }
                    else if (isStr)
                    {
                        if (isArray)
                        {
                            WriteStringArrayConvertToUnmanaged(writer, cppParameter.Type, cppParameter.Name, arrays.Count);
                            sb.Append($"pStrArray{arrays.Count}");
                            arrays.Push(cppParameter.Name);
                        }
                        else
                        {
                            if (isRef)
                            {
                                stack.Push((cppParameter.Name, cppParameter, $"pStr{strings}"));
                            }

                            WriteStringConvertToUnmanaged(writer, cppParameter.Type, cppParameter.Name, strings);
                            sb.Append($"pStr{strings}");
                            strings++;
                        }
                    }
                    else if (isRef)
                    {
                        writer.BeginBlock($"fixed ({cppParameter.Type.CleanName}* p{cppParameter.Name} = &{cppParameter.Name})");
                        sb.Append($"({overload.Parameters[i + offset].Type.Name})p{cppParameter.Name}");
                        stacks++;
                    }
                    else if (isSpan)
                    {
                        writer.BeginBlock($"fixed ({cppParameter.Type.CleanName}* p{cppParameter.Name} = {cppParameter.Name})");
                        sb.Append($"({overload.Parameters[i + offset].Type.Name})p{cppParameter.Name}");
                        stacks++;
                    }
                    else if (isArray)
                    {
                        writer.BeginBlock($"fixed ({cppParameter.Type.CleanName}* p{cppParameter.Name} = {cppParameter.Name})");
                        sb.Append($"({overload.Parameters[i + offset].Type.Name})p{cppParameter.Name}");
                        stacks++;
                    }
                    else if (isBool && !isRef && !isSpan && !isPointer)
                    {
                        sb.Append($"{cppParameter.Name} ? (byte)1 : (byte)0");
                    }
                    else
                    {
                        sb.Append(cppParameter.Name);
                    }

                    if (i != overload.Parameters.Count - 1 - offset)
                    {
                        sb.Append(", ");
                    }
                }

                if (csReturnType.IsString)
                {
                    sb.Append("));");
                }
                else
                {
                    sb.Append(");");
                }

                if (firstParamReturn)
                {
                    writer.WriteLine($"{csReturnType.Name} ret;");
                }
                writer.WriteLine(sb.ToString());

                while (stack.TryPop(out var stackItem))
                {
                    WriteStringConvertToManaged(writer, stackItem.Item2.Type, stackItem.Item1, stackItem.Item3);
                }

                while (arrays.TryPop(out var arrayName))
                {
                    WriteFreeUnmanagedStringArray(writer, arrayName, arrays.Count);
                }

                while (strings > 0)
                {
                    strings--;
                    WriteFreeString(writer, strings);
                }

                if (firstParamReturn || !csReturnType.IsVoid || csReturnType.IsVoid && csReturnType.IsPointer)
                {
                    if (csReturnType.IsBool && !csReturnType.IsPointer && !hasManaged)
                    {
                        writer.WriteLine("return ret != 0;");
                    }
                    else
                    {
                        writer.WriteLine("return ret;");
                    }
                }

                while (stacks > 0)
                {
                    stacks--;
                    writer.EndBlock();
                }
            }

            writer.WriteLine();
        }

        private static void WriteStringConvertToManaged(StringBuilder sb, CppType type)
        {
            CppPrimitiveKind primitiveKind = type.GetPrimitiveKind(false);
            if (primitiveKind == CppPrimitiveKind.Char)
            {
                sb.Append("Utils.DecodeStringUTF8(");
            }
            if (primitiveKind == CppPrimitiveKind.WChar)
            {
                sb.Append("Utils.DecodeStringUTF16(");
            }
        }

        private static void WriteStringConvertToManaged(StringBuilder sb, CsType type)
        {
            if (type.StringType == CsStringType.StringUTF8)
            {
                sb.Append("Utils.DecodeStringUTF8(");
            }
            if (type.StringType == CsStringType.StringUTF16)
            {
                sb.Append("Utils.DecodeStringUTF16(");
            }
        }

        private static void WriteStringConvertToManaged(ICodeWriter writer, CppType type, string variable, string pointer)
        {
            CppPrimitiveKind primitiveKind = type.GetPrimitiveKind(false);
            if (primitiveKind == CppPrimitiveKind.Char)
            {
                writer.WriteLine($"{variable} = Marshal.DecodeStringUTF8({pointer});");
            }
            if (primitiveKind == CppPrimitiveKind.WChar)
            {
                writer.WriteLine($"{variable} = Marshal.DecodeStringUTF16({pointer});");
            }
        }

        private static void WriteStringConvertToManaged(ICodeWriter writer, CsType type, string variable, string pointer)
        {
            if (type.StringType == CsStringType.StringUTF8)
            {
                writer.WriteLine($"{variable} = Utils.DecodeStringUTF8({pointer});");
            }
            if (type.StringType == CsStringType.StringUTF16)
            {
                writer.WriteLine($"{variable} = Utils.DecodeStringUTF16({pointer});");
            }
        }

        private static void WriteStringConvertToUnmanaged(ICodeWriter writer, CppType type, string name, int i)
        {
            CppPrimitiveKind primitiveKind = type.GetPrimitiveKind(false);
            if (primitiveKind == CppPrimitiveKind.Char)
            {
                writer.WriteLine($"byte* pStr{i} = null;");
                writer.WriteLine($"int pStrSize{i} = 0;");
                using (writer.PushBlock($"if ({name} != null)"))
                {
                    writer.WriteLine($"pStrSize{i} = Utils.GetByteCountUTF8({name});");
                    using (writer.PushBlock($"if (pStrSize{i} >= Utils.MaxStackallocSize)"))
                    {
                        writer.WriteLine($"pStr{i} = Utils.Alloc<byte>(pStrSize{i} + 1);");
                    }
                    using (writer.PushBlock("else"))
                    {
                        writer.WriteLine($"byte* pStrStack{i} = stackalloc byte[pStrSize{i} + 1];");
                        writer.WriteLine($"pStr{i} = pStrStack{i};");
                    }
                    writer.WriteLine($"int pStrOffset{i} = Utils.EncodeStringUTF8({name}, pStr{i}, pStrSize{i});");
                    writer.WriteLine($"pStr{i}[pStrOffset{i}] = 0;");
                }
            }
            if (primitiveKind == CppPrimitiveKind.WChar)
            {
                writer.WriteLine($"char* pStr{i} = (char*)Marshal.StringToHGlobalUni({name});");
            }
        }

        private static void WriteStringConvertToUnmanaged(ICodeWriter writer, CsType type, string name, int i)
        {
            if (type.StringType == CsStringType.StringUTF8)
            {
                writer.WriteLine($"byte* pStr{i} = null;");
                writer.WriteLine($"int pStrSize{i} = 0;");
                using (writer.PushBlock($"if ({name} != null)"))
                {
                    writer.WriteLine($"pStrSize{i} = Utils.GetByteCountUTF8({name});");
                    using (writer.PushBlock($"if (pStrSize{i} >= Utils.MaxStackallocSize)"))
                    {
                        writer.WriteLine($"pStr{i} = Utils.Alloc<byte>(pStrSize{i} + 1);");
                    }
                    using (writer.PushBlock("else"))
                    {
                        writer.WriteLine($"byte* pStrStack{i} = stackalloc byte[pStrSize{i} + 1];");
                        writer.WriteLine($"pStr{i} = pStrStack{i};");
                    }
                    writer.WriteLine($"int pStrOffset{i} = Utils.EncodeStringUTF8({name}, pStr{i}, pStrSize{i});");
                    writer.WriteLine($"pStr{i}[pStrOffset{i}] = 0;");
                }
            }
            if (type.StringType == CsStringType.StringUTF16)
            {
                writer.WriteLine($"char* pStr{i} = (char*)Marshal.StringToHGlobalUni({name});");
            }
        }

        private static void WriteFreeString(ICodeWriter writer, int i)
        {
            using (writer.PushBlock($"if (pStrSize{i} >= Utils.MaxStackallocSize)"))
            {
                writer.WriteLine($"Utils.Free(pStr{i});");
            }
        }

        private static void WriteStringArrayConvertToUnmanaged(ICodeWriter writer, CppType type, string name, int i)
        {
            CppPrimitiveKind primitiveKind = type.GetPrimitiveKind(false);
            if (primitiveKind == CppPrimitiveKind.Char)
            {
                writer.WriteLine($"byte** pStrArray{i} = null;");
                writer.WriteLine($"int pStrArraySize{i} = Utils.GetByteCountArray({name});");
                using (writer.PushBlock($"if ({name} != null)"))
                {
                    using (writer.PushBlock($"if (pStrArraySize{i} > Utils.MaxStackallocSize)"))
                    {
                        writer.WriteLine($"pStrArray{i} = (byte**)Utils.Alloc<byte>(pStrArraySize{i});");
                    }
                    using (writer.PushBlock("else"))
                    {
                        writer.WriteLine($"byte* pStrArrayStack{i} = stackalloc byte[pStrArraySize{i}];");
                        writer.WriteLine($"pStrArray{i} = (byte**)pStrArrayStack{i};");
                    }
                }
                using (writer.PushBlock($"for (int i = 0; i < {name}.Length; i++)"))
                {
                    writer.WriteLine($"pStrArray{i}[i] = (byte*)Marshal.StringToHGlobalAnsi({name}[i]);");
                }
            }
            if (primitiveKind == CppPrimitiveKind.WChar)
            {
                writer.WriteLine($"char** pAStr{i} = (char**)Marshal.AllocHGlobal(sizeof(nuint) * {name}.Length);");
                using (writer.PushBlock($"for (int i = 0; i < {name}.Length; i++)"))
                {
                    writer.WriteLine($"pAStr{i}[i] = (char*)Marshal.StringToHGlobalUni({name}[i]);");
                }
            }
        }

        private static void WriteStringArrayConvertToUnmanaged(ICodeWriter writer, CsType type, string name, int i)
        {
            if (type.StringType == CsStringType.StringUTF8)
            {
                writer.WriteLine($"byte** pStrArray{i} = null;");
                writer.WriteLine($"int pStrArraySize{i} = Utils.GetByteCountArray({name});");
                using (writer.PushBlock($"if ({name} != null)"))
                {
                    using (writer.PushBlock($"if (pStrArraySize{i} > Utils.MaxStackallocSize)"))
                    {
                        writer.WriteLine($"pStrArray{i} = (byte**)Utils.Alloc<byte>(pStrArraySize{i});");
                    }
                    using (writer.PushBlock("else"))
                    {
                        writer.WriteLine($"byte* pStrArrayStack{i} = stackalloc byte[pStrArraySize{i}];");
                        writer.WriteLine($"pStrArray{i} = (byte**)pStrArrayStack{i};");
                    }
                }
                using (writer.PushBlock($"for (int i = 0; i < {name}.Length; i++)"))
                {
                    writer.WriteLine($"pStrArray{i}[i] = (byte*)Marshal.StringToHGlobalAnsi({name}[i]);");
                }
            }
            if (type.StringType == CsStringType.StringUTF16)
            {
                writer.WriteLine($"char** pAStr{i} = (char**)Marshal.AllocHGlobal(sizeof(nuint) * {name}.Length);");
                using (writer.PushBlock($"for (int i = 0; i < {name}.Length; i++)"))
                {
                    writer.WriteLine($"pAStr{i}[i] = (char*)Marshal.StringToHGlobalUni({name}[i]);");
                }
            }
        }

        private static void WriteFreeUnmanagedStringArray(ICodeWriter writer, string name, int i)
        {
            using (writer.PushBlock($"for (int i = 0; i < {name}.Length; i++)"))
            {
                writer.WriteLine($"Utils.Free(pStrArray{i}[i]);");
            }
            using (writer.PushBlock($"if (pStrArraySize{i} >= Utils.MaxStackallocSize)"))
            {
                writer.WriteLine($"Utils.Free(pStrArray{i});");
            }
        }

        private void GenerateVariations(IList<CppParameter> parameters, CsFunctionOverload function, bool isMember)
        {
            settings.TryGetFunctionMapping(function.ExportedName, out var mapping);

            for (long ix = 0; ix < Math.Pow(2, parameters.Count); ix++)
            {
                {
                    CsParameterInfo[] refParameterList = new CsParameterInfo[parameters.Count];
                    CsParameterInfo[] spanParameterList = new CsParameterInfo[parameters.Count];
                    CsParameterInfo[] stringParameterList = new CsParameterInfo[parameters.Count];
                    CsParameterInfo[][] customParameterList = new CsParameterInfo[mapping?.CustomVariations.Count ?? 0][];
                    for (int i = 0; i < (mapping?.CustomVariations.Count ?? 0); i++)
                    {
                        customParameterList[i] = new CsParameterInfo[parameters.Count];
                    }
                    for (int j = 0; j < parameters.Count; j++)
                    {
                        var bit = (ix & (1 << j - 64)) != 0;
                        CppParameter cppParameter = parameters[j];
                        CppPrimitiveKind kind = cppParameter.Type.GetPrimitiveKind(false);

                        var paramCsName = settings.GetParameterName(cppParameter.Type, cppParameter.Name);
                        var direction = cppParameter.Type.GetDirection();

                        if (bit)
                        {
                            if (cppParameter.Type is CppArrayType arrayType)
                            {
                                if (arrayType.Size > 0)
                                {
                                    spanParameterList[j] = new(paramCsName, new($"ReadOnlySpan<{settings.GetCsTypeName(arrayType.ElementType, false)}>", kind), direction);
                                    refParameterList[j] = new(paramCsName, new("ref " + settings.GetCsTypeName(arrayType.ElementType, false), kind), direction);
                                }
                                else
                                {
                                    spanParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                    refParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                }

                                if (arrayType.ElementType.IsString())
                                {
                                    stringParameterList[j] = new(paramCsName, new("string[]", kind), direction);
                                }
                                else
                                {
                                    stringParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                }
                            }
                            else
                            {
                                refParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);

                                if (cppParameter.Type.IsString())
                                {
                                    switch (kind)
                                    {
                                        case CppPrimitiveKind.Char:
                                            if (direction == Direction.InOut || direction == Direction.Out) goto default;
                                            spanParameterList[j] = new(paramCsName, new("ReadOnlySpan<byte>", kind), direction);
                                            break;

                                        case CppPrimitiveKind.WChar:
                                            if (direction == Direction.InOut || direction == Direction.Out) goto default;
                                            spanParameterList[j] = new(paramCsName, new("ReadOnlySpan<char>", kind), direction);
                                            break;

                                        default:
                                            spanParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                            break;
                                    }

                                    stringParameterList[j] = new(paramCsName, new(direction == Direction.InOut ? "ref string" : "string", kind), direction);
                                }
                                else
                                {
                                    spanParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                    stringParameterList[j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                }
                            }

                            if (mapping != null)
                            {
                                for (int i = 0; i < mapping.CustomVariations.Count; i++)
                                {
                                    if (mapping.CustomVariations[i].TryGetValue(paramCsName, out var paramType))
                                    {
                                        customParameterList[i][j] = new(paramCsName, new(paramType, kind), direction);
                                    }
                                    else
                                    {
                                        customParameterList[i][j] = new(paramCsName, new(settings.GetCsWrapperTypeName(cppParameter.Type, false), kind), direction);
                                    }
                                }
                            }
                        }
                        else
                        {
                            refParameterList[j] = new(paramCsName, new(settings.GetCsTypeName(cppParameter.Type, false), kind), direction);
                            stringParameterList[j] = new(paramCsName, new(settings.GetCsTypeName(cppParameter.Type, false), kind), direction);
                            spanParameterList[j] = new(paramCsName, new(settings.GetCsTypeName(cppParameter.Type, false), kind), direction);
                            if (mapping != null)
                            {
                                for (int i = 0; i < mapping.CustomVariations.Count; i++)
                                {
                                    customParameterList[i][j] = new(paramCsName, new(settings.GetCsTypeName(cppParameter.Type, false), kind), direction);
                                }
                            }
                        }
                    }

                    CsFunctionVariation refVariation = function.CreateVariationWith();
                    refVariation.Parameters.AddRange(refParameterList);
                    CsFunctionVariation stringVariation = function.CreateVariationWith();
                    stringVariation.Parameters.AddRange(stringParameterList);
                    CsFunctionVariation spanVariation = function.CreateVariationWith();
                    spanVariation.Parameters.AddRange(spanParameterList);

                    if (!function.HasVariation(refVariation))
                    {
                        function.Variations.Add(refVariation);
                        GenerateDefaultValueVariations(parameters, function, refVariation, isMember);
                        GenerateReturnVariations(function, refVariation, isMember);
                    }
                    if (!function.HasVariation(stringVariation))
                    {
                        function.Variations.Add(stringVariation);
                        GenerateDefaultValueVariations(parameters, function, stringVariation, isMember);
                        GenerateReturnVariations(function, stringVariation, isMember);
                    }
                    if (!function.HasVariation(spanVariation))
                    {
                        function.Variations.Add(spanVariation);
                        GenerateDefaultValueVariations(parameters, function, spanVariation, isMember);
                        GenerateReturnVariations(function, spanVariation, isMember);
                    }
                    for (int i = 0; i < (mapping?.CustomVariations.Count ?? 0); i++)
                    {
                        CsFunctionVariation customVariation = function.CreateVariationWith();
                        customVariation.Parameters.AddRange(customParameterList[i]);
                        if (!function.HasVariation(customVariation))
                        {
                            function.Variations.Add(customVariation);
                            GenerateDefaultValueVariations(parameters, function, customVariation, isMember);
                            GenerateReturnVariations(function, customVariation, isMember);
                        }
                    }
                }
            }
        }

        private static unsafe void GenerateDefaultValueVariations(IList<CppParameter> parameters, CsFunctionOverload function, CsFunctionVariation variation, bool isMember)
        {
            if (function.DefaultValues.Count == 0)
            {
                return;
            }

            for (int i = variation.Parameters.Count - 1; i >= 0; i--)
            {
                var param = variation.Parameters[i];

                if (!function.DefaultValues.TryGetValue(param.Name, out _))
                {
                    continue;
                }

                CsFunctionVariation defaultVariation = new(variation.ExportedName, variation.Name, variation.StructName, variation.IsMember, variation.IsConstructor, variation.IsDestructor, variation.ReturnType);
                for (int j = 0; j < variation.Parameters.Count; j++)
                {
                    var iationParameter = variation.Parameters[j];
                    if (param != iationParameter)
                    {
                        defaultVariation.Parameters.Add(iationParameter);
                    }
                }

                if (function.HasVariation(defaultVariation))
                {
                    continue;
                }

                function.Variations.Add(defaultVariation);

                GenerateDefaultValueVariations(parameters, function, defaultVariation, isMember);
                GenerateReturnVariations(function, defaultVariation, isMember);
            }
        }

        private static void GenerateReturnVariations(CsFunctionOverload function, CsFunctionVariation variation, bool isMember)
        {
            if (!isMember && variation.ReturnType.IsVoid && !variation.ReturnType.IsPointer && variation.Parameters.Count > 0)
            {
                if (variation.Parameters[0].Name == "output" && variation.Parameters[0].Type.IsPointer)
                {
                    CsFunctionVariation returnVariation = new(variation.ExportedName, variation.Name, variation.StructName, variation.IsMember, variation.IsConstructor, variation.IsDestructor, variation.ReturnType);
                    returnVariation.Parameters = variation.Parameters.Skip(1).ToList();
                    if (!function.HasVariation(returnVariation))
                    {
                        function.Variations.Add(returnVariation);
                        function.Variations.Remove(variation);
                        returnVariation.ReturnType = new(variation.Parameters[0].Type.Name[..^1], variation.Parameters[0].Type.PrimitiveType);
                    }
                }
            }
            if (variation.ReturnType.IsPointer && variation.ReturnType.PrimitiveType == CsPrimitiveType.Byte || variation.ReturnType.PrimitiveType == CsPrimitiveType.Char)
            {
                CsFunctionVariation returnVariation = new(variation.ExportedName, variation.Name + "S", variation.StructName, variation.IsMember, variation.IsConstructor, variation.IsDestructor, variation.ReturnType);
                returnVariation.Parameters = variation.Parameters.ToList();
                function.Variations.Add(returnVariation);
                returnVariation.ReturnType = new("string", variation.ReturnType.PrimitiveType);
            }
        }
    }
}