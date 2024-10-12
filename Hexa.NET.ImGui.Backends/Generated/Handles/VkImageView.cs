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
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;
using Hexa.NET.ImGui;

namespace Hexa.NET.ImGui.Backends
{
	/// <summary>
	/// To be documented.
	/// </summary>
	#if NET5_0_OR_GREATER
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	#endif
	public readonly partial struct VkImageView : IEquatable<VkImageView>
	{
		public VkImageView(nint handle) { Handle = handle; }
		public nint Handle { get; }
		public bool IsNull => Handle == 0;
		public static VkImageView Null => new VkImageView(0);
		public static implicit operator VkImageView(nint handle) => new VkImageView(handle);
		public static bool operator ==(VkImageView left, VkImageView right) => left.Handle == right.Handle;
		public static bool operator !=(VkImageView left, VkImageView right) => left.Handle != right.Handle;
		public static bool operator ==(VkImageView left, nint right) => left.Handle == right;
		public static bool operator !=(VkImageView left, nint right) => left.Handle != right;
		public bool Equals(VkImageView other) => Handle == other.Handle;
		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is VkImageView handle && Equals(handle);
		/// <inheritdoc/>
		public override int GetHashCode() => Handle.GetHashCode();
		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("VkImageView [0x{0}]", Handle.ToString("X"));
		#endif
	}
}
