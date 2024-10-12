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
	public readonly partial struct VkSemaphore : IEquatable<VkSemaphore>
	{
		public VkSemaphore(nint handle) { Handle = handle; }
		public nint Handle { get; }
		public bool IsNull => Handle == 0;
		public static VkSemaphore Null => new VkSemaphore(0);
		public static implicit operator VkSemaphore(nint handle) => new VkSemaphore(handle);
		public static bool operator ==(VkSemaphore left, VkSemaphore right) => left.Handle == right.Handle;
		public static bool operator !=(VkSemaphore left, VkSemaphore right) => left.Handle != right.Handle;
		public static bool operator ==(VkSemaphore left, nint right) => left.Handle == right;
		public static bool operator !=(VkSemaphore left, nint right) => left.Handle != right;
		public bool Equals(VkSemaphore other) => Handle == other.Handle;
		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is VkSemaphore handle && Equals(handle);
		/// <inheritdoc/>
		public override int GetHashCode() => Handle.GetHashCode();
		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("VkSemaphore [0x{0}]", Handle.ToString("X"));
		#endif
	}
}
