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
	public enum ImGuiTabBarFlags : int
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		None = unchecked(0),

		/// <summary>
		/// Allow manually dragging tabs to re-order them + New tabs are appended at the end of list<br/>
		/// </summary>
		Reorderable = unchecked(1),

		/// <summary>
		/// Automatically select new tabs when they appear<br/>
		/// </summary>
		AutoSelectNewTabs = unchecked(2),

		/// <summary>
		/// Disable buttons to open the tab list popup<br/>
		/// </summary>
		ListPopupButton = unchecked(4),

		/// <summary>
		/// Disable behavior of closing tabs (that are submitted with p_open != NULL) with middle mouse button. You may handle this behavior manually on user's side with if (IsItemHovered() &amp;&amp; IsMouseClicked(2)) *p_open = false.<br/>
		/// </summary>
		NoCloseWithMiddleMouseButton = unchecked(8),

		/// <summary>
		/// Disable scrolling buttons (apply when fitting policy is ImGuiTabBarFlags_FittingPolicyScroll)<br/>
		/// </summary>
		NoTabListScrollingButtons = unchecked(16),

		/// <summary>
		/// Disable tooltips when hovering a tab<br/>
		/// </summary>
		NoTooltip = unchecked(32),

		/// <summary>
		/// Draw selected overline markers over selected tab<br/>
		/// </summary>
		DrawSelectedOverline = unchecked(64),

		/// <summary>
		/// Resize tabs when they don't fit<br/>
		/// </summary>
		FittingPolicyResizeDown = unchecked(128),

		/// <summary>
		/// Add scroll buttons when tabs don't fit<br/>
		/// </summary>
		FittingPolicyScroll = unchecked(256),

		/// <summary>
		/// To be documented.
		/// </summary>
		FittingPolicyMask = unchecked(384),

		/// <summary>
		/// To be documented.
		/// </summary>
		FittingPolicyDefault = FittingPolicyResizeDown,
	}
}
