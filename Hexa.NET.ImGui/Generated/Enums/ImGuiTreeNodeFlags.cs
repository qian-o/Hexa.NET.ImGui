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
	public enum ImGuiTreeNodeFlags : int
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		None = unchecked(0),

		/// <summary>
		/// Draw as selected<br/>
		/// </summary>
		Selected = unchecked(1),

		/// <summary>
		/// Draw frame with background (e.g. for CollapsingHeader)<br/>
		/// </summary>
		Framed = unchecked(2),

		/// <summary>
		/// Hit testing to allow subsequent widgets to overlap this one<br/>
		/// </summary>
		AllowOverlap = unchecked(4),

		/// <summary>
		/// Don't do a TreePush() when open (e.g. for CollapsingHeader) = no extra indent nor pushing on ID stack<br/>
		/// </summary>
		NoTreePushOnOpen = unchecked(8),

		/// <summary>
		/// Don't automatically and temporarily open node when Logging is active (by default logging will automatically open tree nodes)<br/>
		/// </summary>
		NoAutoOpenOnLog = unchecked(16),

		/// <summary>
		/// Default node to be open<br/>
		/// </summary>
		DefaultOpen = unchecked(32),

		/// <summary>
		/// Need double-click to open node<br/>
		/// </summary>
		OpenOnDoubleClick = unchecked(64),

		/// <summary>
		/// Only open when clicking on the arrow part. If ImGuiTreeNodeFlags_OpenOnDoubleClick is also set, single-click arrow or double-click all box to open.<br/>
		/// </summary>
		OpenOnArrow = unchecked(128),

		/// <summary>
		/// No collapsing, no arrow (use as a convenience for leaf nodes).<br/>
		/// </summary>
		Leaf = unchecked(256),

		/// <summary>
		/// Display a bullet instead of arrow. IMPORTANT: node can still be marked openclose if you don't set the _Leaf flag!<br/>
		/// </summary>
		Bullet = unchecked(512),

		/// <summary>
		/// Use FramePadding (even for an unframed text node) to vertically align text baseline to regular widget height. Equivalent to calling AlignTextToFramePadding() before the node.<br/>
		/// </summary>
		FramePadding = unchecked(1024),

		/// <summary>
		/// Extend hit box to the right-most edge, even if not framed. This is not the default in order to allow adding other items on the same line without using AllowOverlap mode.<br/>
		/// </summary>
		SpanAvailWidth = unchecked(2048),

		/// <summary>
		/// Extend hit box to the left-most and right-most edges (cover the indent area).<br/>
		/// </summary>
		SpanFullWidth = unchecked(4096),

		/// <summary>
		/// Narrow hit box + narrow hovering highlight, will only cover the label text.<br/>
		/// </summary>
		SpanTextWidth = unchecked(8192),

		/// <summary>
		/// Frame will span all columns of its container table (text will still fit in current column)<br/>
		/// </summary>
		SpanAllColumns = unchecked(16384),

		/// <summary>
		/// (WIP) Nav: left direction may move to this TreeNode() from any of its child (items submitted between TreeNode and TreePop)<br/>
		/// </summary>
		NavLeftJumpsBackHere = unchecked(32768),

		/// <summary>
		/// To be documented.
		/// </summary>
		CollapsingHeader = unchecked(26),
	}
}
