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
	/// Internal temporary state for deactivating InputText() instances.<br/>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ImGuiInputTextDeactivatedState
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		public uint ID;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImVector<byte> TextA;


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiInputTextDeactivatedState(uint id = default, ImVector<byte> textA = default)
		{
			ID = id;
			TextA = textA;
		}


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			fixed (ImGuiInputTextDeactivatedState* @this = &this)
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
	public unsafe struct ImGuiInputTextDeactivatedStatePtr : IEquatable<ImGuiInputTextDeactivatedStatePtr>
	{
		public ImGuiInputTextDeactivatedStatePtr(ImGuiInputTextDeactivatedState* handle) { Handle = handle; }

		public ImGuiInputTextDeactivatedState* Handle;

		public bool IsNull => Handle == null;

		public static ImGuiInputTextDeactivatedStatePtr Null => new ImGuiInputTextDeactivatedStatePtr(null);

		public ImGuiInputTextDeactivatedState this[int index] { get => Handle[index]; set => Handle[index] = value; }

		public static implicit operator ImGuiInputTextDeactivatedStatePtr(ImGuiInputTextDeactivatedState* handle) => new ImGuiInputTextDeactivatedStatePtr(handle);

		public static implicit operator ImGuiInputTextDeactivatedState*(ImGuiInputTextDeactivatedStatePtr handle) => handle.Handle;

		public static bool operator ==(ImGuiInputTextDeactivatedStatePtr left, ImGuiInputTextDeactivatedStatePtr right) => left.Handle == right.Handle;

		public static bool operator !=(ImGuiInputTextDeactivatedStatePtr left, ImGuiInputTextDeactivatedStatePtr right) => left.Handle != right.Handle;

		public static bool operator ==(ImGuiInputTextDeactivatedStatePtr left, ImGuiInputTextDeactivatedState* right) => left.Handle == right;

		public static bool operator !=(ImGuiInputTextDeactivatedStatePtr left, ImGuiInputTextDeactivatedState* right) => left.Handle != right;

		public bool Equals(ImGuiInputTextDeactivatedStatePtr other) => Handle == other.Handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ImGuiInputTextDeactivatedStatePtr handle && Equals(handle);

		/// <inheritdoc/>
		public override int GetHashCode() => ((nuint)Handle).GetHashCode();

		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("ImGuiInputTextDeactivatedStatePtr [0x{0}]", ((nuint)Handle).ToString("X"));
		#endif
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint ID => ref Unsafe.AsRef<uint>(&Handle->ID);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImVector<byte> TextA => ref Unsafe.AsRef<ImVector<byte>>(&Handle->TextA);
		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			ImGui.DestroyNative(Handle);
		}

	}

}
