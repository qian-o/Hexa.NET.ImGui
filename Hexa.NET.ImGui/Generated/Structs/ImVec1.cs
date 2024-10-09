// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;

namespace Hexa.NET.ImGui
{
	/// <summary>
	/// To be documented.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ImVec1
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		public float X;


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImVec1(float x = default)
		{
			X = x;
		}


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			fixed (ImVec1* @this = &this)
			{
				ImGui.DestroyNative(@this);
			}
		}

	}

	/// <summary>
	/// To be documented.
	/// </summary>
	#if NET5_0_OR_GREATER
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	#endif
	public unsafe struct ImVec1Ptr : IEquatable<ImVec1Ptr>
	{
		public ImVec1Ptr(ImVec1* handle) { Handle = handle; }

		public ImVec1* Handle;

		public bool IsNull => Handle == null;

		public static ImVec1Ptr Null => new ImVec1Ptr(null);

		public ImVec1 this[int index] { get => Handle[index]; set => Handle[index] = value; }

		public static implicit operator ImVec1Ptr(ImVec1* handle) => new ImVec1Ptr(handle);

		public static implicit operator ImVec1*(ImVec1Ptr handle) => handle.Handle;

		public static bool operator ==(ImVec1Ptr left, ImVec1Ptr right) => left.Handle == right.Handle;

		public static bool operator !=(ImVec1Ptr left, ImVec1Ptr right) => left.Handle != right.Handle;

		public static bool operator ==(ImVec1Ptr left, ImVec1* right) => left.Handle == right;

		public static bool operator !=(ImVec1Ptr left, ImVec1* right) => left.Handle != right;

		public bool Equals(ImVec1Ptr other) => Handle == other.Handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ImVec1Ptr handle && Equals(handle);

		/// <inheritdoc/>
		public override int GetHashCode() => ((nuint)Handle).GetHashCode();

		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("ImVec1Ptr [0x{0}]", ((nuint)Handle).ToString("X"));
		#endif
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref float X => ref Unsafe.AsRef<float>(&Handle->X);
		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			ImGui.DestroyNative(Handle);
		}

	}

}
