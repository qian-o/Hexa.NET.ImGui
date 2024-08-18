// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using HexaGen.Runtime;
using System.Numerics;

namespace Hexa.NET.ImGui
{
	/// <summary>
	/// To be documented.
	/// </summary>
	[Flags]
	public enum ImGuiViewportFlags : int
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		None = unchecked(0),

		/// <summary>
		/// Represent a Platform Window<br/>
		/// </summary>
		IsPlatformWindow = unchecked(1),

		/// <summary>
		/// Represent a Platform Monitor (unused yet)<br/>
		/// </summary>
		IsPlatformMonitor = unchecked(2),

		/// <summary>
		/// Platform Window: Was createdmanaged by the user application? (rather than our backend)<br/>
		/// </summary>
		OwnedByApp = unchecked(4),

		/// <summary>
		/// Platform Window: Disable platform decorations: title bar, borders, etc. (generally set all windows, but if ImGuiConfigFlags_ViewportsDecoration is set we only set this on popupstooltips)<br/>
		/// </summary>
		NoDecoration = unchecked(8),

		/// <summary>
		/// Platform Window: Disable platform task bar icon (generally set on popupstooltips, or all windows if ImGuiConfigFlags_ViewportsNoTaskBarIcon is set)<br/>
		/// </summary>
		NoTaskBarIcon = unchecked(16),

		/// <summary>
		/// Platform Window: Don't take focus when created.<br/>
		/// </summary>
		NoFocusOnAppearing = unchecked(32),

		/// <summary>
		/// Platform Window: Don't take focus when clicked on.<br/>
		/// </summary>
		NoFocusOnClick = unchecked(64),

		/// <summary>
		/// Platform Window: Make mouse pass through so we can drag this window while peaking behind it.<br/>
		/// </summary>
		NoInputs = unchecked(128),

		/// <summary>
		/// Platform Window: Renderer doesn't need to clear the framebuffer ahead (because we will fill it entirely).<br/>
		/// </summary>
		NoRendererClear = unchecked(256),

		/// <summary>
		/// Platform Window: Avoid merging this window into another host window. This can only be set via ImGuiWindowClass viewport flags override (because we need to now ahead if we are going to create a viewport in the first place!).<br/>
		/// </summary>
		NoAutoMerge = unchecked(512),

		/// <summary>
		/// Platform Window: Display on top (for tooltips only).<br/>
		/// </summary>
		TopMost = unchecked(1024),

		/// <summary>
		/// Viewport can host multiple imgui windows (secondary viewports are associated to a single window).  FIXME: In practice there's still probably code making the assumption that this is always and only on the MainViewport. Will fix once we add support for "no main viewport".<br/>
		/// </summary>
		CanHostOtherWindows = unchecked(2048),

		/// <summary>
		/// Platform Window: Window is minimized, can skip render. When minimized we tend to avoid using the viewport possize for clipping window or testing if they are contained in the viewport.<br/>
		/// </summary>
		IsMinimized = unchecked(4096),

		/// <summary>
		/// Platform Window: Window is focused (last call to Platform_GetWindowFocus() returned true)<br/>
		/// </summary>
		IsFocused = unchecked(8192),
	}
}
