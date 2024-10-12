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
using Hexa.NET.ImGui;

namespace Hexa.NET.ImGui.Backends
{
	/// <summary>
	/// To be documented.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ImGuiImplVulkanHFrameSemaphores
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		public VkSemaphore ImageAcquiredSemaphore;

		/// <summary>
		/// To be documented.
		/// </summary>
		public VkSemaphore RenderCompleteSemaphore;


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiImplVulkanHFrameSemaphores(VkSemaphore imageAcquiredSemaphore = default, VkSemaphore renderCompleteSemaphore = default)
		{
			ImageAcquiredSemaphore = imageAcquiredSemaphore;
			RenderCompleteSemaphore = renderCompleteSemaphore;
		}


	}

	/// <summary>
	/// To be documented.
	/// </summary>
	#if NET5_0_OR_GREATER
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	#endif
	public unsafe struct ImGuiImplVulkanHFrameSemaphoresPtr : IEquatable<ImGuiImplVulkanHFrameSemaphoresPtr>
	{
		public ImGuiImplVulkanHFrameSemaphoresPtr(ImGuiImplVulkanHFrameSemaphores* handle) { Handle = handle; }

		public ImGuiImplVulkanHFrameSemaphores* Handle;

		public bool IsNull => Handle == null;

		public static ImGuiImplVulkanHFrameSemaphoresPtr Null => new ImGuiImplVulkanHFrameSemaphoresPtr(null);

		public ImGuiImplVulkanHFrameSemaphores this[int index] { get => Handle[index]; set => Handle[index] = value; }

		public static implicit operator ImGuiImplVulkanHFrameSemaphoresPtr(ImGuiImplVulkanHFrameSemaphores* handle) => new ImGuiImplVulkanHFrameSemaphoresPtr(handle);

		public static implicit operator ImGuiImplVulkanHFrameSemaphores*(ImGuiImplVulkanHFrameSemaphoresPtr handle) => handle.Handle;

		public static bool operator ==(ImGuiImplVulkanHFrameSemaphoresPtr left, ImGuiImplVulkanHFrameSemaphoresPtr right) => left.Handle == right.Handle;

		public static bool operator !=(ImGuiImplVulkanHFrameSemaphoresPtr left, ImGuiImplVulkanHFrameSemaphoresPtr right) => left.Handle != right.Handle;

		public static bool operator ==(ImGuiImplVulkanHFrameSemaphoresPtr left, ImGuiImplVulkanHFrameSemaphores* right) => left.Handle == right;

		public static bool operator !=(ImGuiImplVulkanHFrameSemaphoresPtr left, ImGuiImplVulkanHFrameSemaphores* right) => left.Handle != right;

		public bool Equals(ImGuiImplVulkanHFrameSemaphoresPtr other) => Handle == other.Handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ImGuiImplVulkanHFrameSemaphoresPtr handle && Equals(handle);

		/// <inheritdoc/>
		public override int GetHashCode() => ((nuint)Handle).GetHashCode();

		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("ImGuiImplVulkanHFrameSemaphoresPtr [0x{0}]", ((nuint)Handle).ToString("X"));
		#endif
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref VkSemaphore ImageAcquiredSemaphore => ref Unsafe.AsRef<VkSemaphore>(&Handle->ImageAcquiredSemaphore);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref VkSemaphore RenderCompleteSemaphore => ref Unsafe.AsRef<VkSemaphore>(&Handle->RenderCompleteSemaphore);
	}

}
