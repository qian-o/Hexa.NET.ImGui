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
	public enum ImGuiNavHighlightFlags : int
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		None = unchecked(0),

		/// <summary>
		/// Compact highlight, no padding<br/>
		/// </summary>
		Compact = unchecked(2),

		/// <summary>
		/// Draw rectangular highlight if (g.NavId == id) _even_ when using the mouse.<br/>
		/// </summary>
		AlwaysDraw = unchecked(4),

		/// <summary>
		/// To be documented.
		/// </summary>
		NoRounding = unchecked(8),
	}
}
