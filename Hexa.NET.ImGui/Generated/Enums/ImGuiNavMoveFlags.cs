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
	public enum ImGuiNavMoveFlags : int
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		None = unchecked(0),

		/// <summary>
		/// To be documented.
		/// </summary>
		LoopX = unchecked(1),

		/// <summary>
		/// To be documented.
		/// </summary>
		LoopY = unchecked(2),

		/// <summary>
		/// To be documented.
		/// </summary>
		WrapX = unchecked(4),

		/// <summary>
		/// To be documented.
		/// </summary>
		WrapY = unchecked(8),

		/// <summary>
		/// To be documented.
		/// </summary>
		WrapMask = unchecked(15),

		/// <summary>
		/// To be documented.
		/// </summary>
		AllowCurrentNavId = unchecked(16),

		/// <summary>
		/// To be documented.
		/// </summary>
		AlsoScoreVisibleSet = unchecked(32),

		/// <summary>
		/// To be documented.
		/// </summary>
		ScrollToEdgeY = unchecked(64),

		/// <summary>
		/// To be documented.
		/// </summary>
		Forwarded = unchecked(128),

		/// <summary>
		/// To be documented.
		/// </summary>
		DebugNoResult = unchecked(256),

		/// <summary>
		/// To be documented.
		/// </summary>
		FocusApi = unchecked(512),

		/// <summary>
		/// To be documented.
		/// </summary>
		IsTabbing = unchecked(1024),

		/// <summary>
		/// To be documented.
		/// </summary>
		IsPageMove = unchecked(2048),

		/// <summary>
		/// To be documented.
		/// </summary>
		Activate = unchecked(4096),

		/// <summary>
		/// To be documented.
		/// </summary>
		NoSelect = unchecked(8192),

		/// <summary>
		/// To be documented.
		/// </summary>
		NoSetNavHighlight = unchecked(16384),

		/// <summary>
		/// To be documented.
		/// </summary>
		NoClearActiveId = unchecked(32768),
	}
}
