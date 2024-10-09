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

namespace Hexa.NET.ImPlot
{
	/// <summary>
	/// To be documented.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ImPlotAlignmentData
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		public byte Vertical;

		/// <summary>
		/// To be documented.
		/// </summary>
		public float PadA;

		/// <summary>
		/// To be documented.
		/// </summary>
		public float PadB;

		/// <summary>
		/// To be documented.
		/// </summary>
		public float PadAMax;

		/// <summary>
		/// To be documented.
		/// </summary>
		public float PadBMax;


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImPlotAlignmentData(bool vertical = default, float padA = default, float padB = default, float padAMax = default, float padBMax = default)
		{
			Vertical = vertical ? (byte)1 : (byte)0;
			PadA = padA;
			PadB = padB;
			PadAMax = padAMax;
			PadBMax = padBMax;
		}


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Begin()
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				ImPlot.BeginNative(@this);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				ImPlot.DestroyNative(@this);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void End()
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				ImPlot.EndNative(@this);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Reset()
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				ImPlot.ResetNative(@this);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, float* deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				ImPlot.UpdateNative(@this, padA, padB, deltaA, deltaB);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, float* deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					ImPlot.UpdateNative(@this, (float*)ppadA, padB, deltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, float* deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadB = &padB)
				{
					ImPlot.UpdateNative(@this, padA, (float*)ppadB, deltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, float* deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* ppadB = &padB)
					{
						ImPlot.UpdateNative(@this, (float*)ppadA, (float*)ppadB, deltaA, deltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, ref float deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					ImPlot.UpdateNative(@this, padA, padB, (float*)pdeltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, ref float deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						ImPlot.UpdateNative(@this, (float*)ppadA, padB, (float*)pdeltaA, deltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, ref float deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						ImPlot.UpdateNative(@this, padA, (float*)ppadB, (float*)pdeltaA, deltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, ref float deltaA, float* deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* ppadB = &padB)
					{
						fixed (float* pdeltaA = &deltaA)
						{
							ImPlot.UpdateNative(@this, (float*)ppadA, (float*)ppadB, (float*)pdeltaA, deltaB);
						}
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, float* deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* pdeltaB = &deltaB)
				{
					ImPlot.UpdateNative(@this, padA, padB, deltaA, (float*)pdeltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, float* deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(@this, (float*)ppadA, padB, deltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, float* deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(@this, padA, (float*)ppadB, deltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, float* deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* ppadB = &padB)
					{
						fixed (float* pdeltaB = &deltaB)
						{
							ImPlot.UpdateNative(@this, (float*)ppadA, (float*)ppadB, deltaA, (float*)pdeltaB);
						}
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, ref float deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(@this, padA, padB, (float*)pdeltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, ref float deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						fixed (float* pdeltaB = &deltaB)
						{
							ImPlot.UpdateNative(@this, (float*)ppadA, padB, (float*)pdeltaA, (float*)pdeltaB);
						}
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, ref float deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						fixed (float* pdeltaB = &deltaB)
						{
							ImPlot.UpdateNative(@this, padA, (float*)ppadB, (float*)pdeltaA, (float*)pdeltaB);
						}
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, ref float deltaA, ref float deltaB)
		{
			fixed (ImPlotAlignmentData* @this = &this)
			{
				fixed (float* ppadA = &padA)
				{
					fixed (float* ppadB = &padB)
					{
						fixed (float* pdeltaA = &deltaA)
						{
							fixed (float* pdeltaB = &deltaB)
							{
								ImPlot.UpdateNative(@this, (float*)ppadA, (float*)ppadB, (float*)pdeltaA, (float*)pdeltaB);
							}
						}
					}
				}
			}
		}

	}

	/// <summary>
	/// To be documented.
	/// </summary>
	#if NET5_0_OR_GREATER
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	#endif
	public unsafe struct ImPlotAlignmentDataPtr : IEquatable<ImPlotAlignmentDataPtr>
	{
		public ImPlotAlignmentDataPtr(ImPlotAlignmentData* handle) { Handle = handle; }

		public ImPlotAlignmentData* Handle;

		public bool IsNull => Handle == null;

		public static ImPlotAlignmentDataPtr Null => new ImPlotAlignmentDataPtr(null);

		public ImPlotAlignmentData this[int index] { get => Handle[index]; set => Handle[index] = value; }

		public static implicit operator ImPlotAlignmentDataPtr(ImPlotAlignmentData* handle) => new ImPlotAlignmentDataPtr(handle);

		public static implicit operator ImPlotAlignmentData*(ImPlotAlignmentDataPtr handle) => handle.Handle;

		public static bool operator ==(ImPlotAlignmentDataPtr left, ImPlotAlignmentDataPtr right) => left.Handle == right.Handle;

		public static bool operator !=(ImPlotAlignmentDataPtr left, ImPlotAlignmentDataPtr right) => left.Handle != right.Handle;

		public static bool operator ==(ImPlotAlignmentDataPtr left, ImPlotAlignmentData* right) => left.Handle == right;

		public static bool operator !=(ImPlotAlignmentDataPtr left, ImPlotAlignmentData* right) => left.Handle != right;

		public bool Equals(ImPlotAlignmentDataPtr other) => Handle == other.Handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ImPlotAlignmentDataPtr handle && Equals(handle);

		/// <inheritdoc/>
		public override int GetHashCode() => ((nuint)Handle).GetHashCode();

		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("ImPlotAlignmentDataPtr [0x{0}]", ((nuint)Handle).ToString("X"));
		#endif
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool Vertical => ref Unsafe.AsRef<bool>(&Handle->Vertical);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref float PadA => ref Unsafe.AsRef<float>(&Handle->PadA);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref float PadB => ref Unsafe.AsRef<float>(&Handle->PadB);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref float PadAMax => ref Unsafe.AsRef<float>(&Handle->PadAMax);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref float PadBMax => ref Unsafe.AsRef<float>(&Handle->PadBMax);
		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Begin()
		{
			ImPlot.BeginNative(Handle);
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Destroy()
		{
			ImPlot.DestroyNative(Handle);
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void End()
		{
			ImPlot.EndNative(Handle);
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Reset()
		{
			ImPlot.ResetNative(Handle);
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, float* deltaA, float* deltaB)
		{
			ImPlot.UpdateNative(Handle, padA, padB, deltaA, deltaB);
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, float* deltaA, float* deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				ImPlot.UpdateNative(Handle, (float*)ppadA, padB, deltaA, deltaB);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, float* deltaA, float* deltaB)
		{
			fixed (float* ppadB = &padB)
			{
				ImPlot.UpdateNative(Handle, padA, (float*)ppadB, deltaA, deltaB);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, float* deltaA, float* deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* ppadB = &padB)
				{
					ImPlot.UpdateNative(Handle, (float*)ppadA, (float*)ppadB, deltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, ref float deltaA, float* deltaB)
		{
			fixed (float* pdeltaA = &deltaA)
			{
				ImPlot.UpdateNative(Handle, padA, padB, (float*)pdeltaA, deltaB);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, ref float deltaA, float* deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					ImPlot.UpdateNative(Handle, (float*)ppadA, padB, (float*)pdeltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, ref float deltaA, float* deltaB)
		{
			fixed (float* ppadB = &padB)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					ImPlot.UpdateNative(Handle, padA, (float*)ppadB, (float*)pdeltaA, deltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, ref float deltaA, float* deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						ImPlot.UpdateNative(Handle, (float*)ppadA, (float*)ppadB, (float*)pdeltaA, deltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, float* deltaA, ref float deltaB)
		{
			fixed (float* pdeltaB = &deltaB)
			{
				ImPlot.UpdateNative(Handle, padA, padB, deltaA, (float*)pdeltaB);
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, float* deltaA, ref float deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* pdeltaB = &deltaB)
				{
					ImPlot.UpdateNative(Handle, (float*)ppadA, padB, deltaA, (float*)pdeltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, float* deltaA, ref float deltaB)
		{
			fixed (float* ppadB = &padB)
			{
				fixed (float* pdeltaB = &deltaB)
				{
					ImPlot.UpdateNative(Handle, padA, (float*)ppadB, deltaA, (float*)pdeltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, float* deltaA, ref float deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(Handle, (float*)ppadA, (float*)ppadB, deltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, float* padB, ref float deltaA, ref float deltaB)
		{
			fixed (float* pdeltaA = &deltaA)
			{
				fixed (float* pdeltaB = &deltaB)
				{
					ImPlot.UpdateNative(Handle, padA, padB, (float*)pdeltaA, (float*)pdeltaB);
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, float* padB, ref float deltaA, ref float deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(Handle, (float*)ppadA, padB, (float*)pdeltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(float* padA, ref float padB, ref float deltaA, ref float deltaB)
		{
			fixed (float* ppadB = &padB)
			{
				fixed (float* pdeltaA = &deltaA)
				{
					fixed (float* pdeltaB = &deltaB)
					{
						ImPlot.UpdateNative(Handle, padA, (float*)ppadB, (float*)pdeltaA, (float*)pdeltaB);
					}
				}
			}
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe void Update(ref float padA, ref float padB, ref float deltaA, ref float deltaB)
		{
			fixed (float* ppadA = &padA)
			{
				fixed (float* ppadB = &padB)
				{
					fixed (float* pdeltaA = &deltaA)
					{
						fixed (float* pdeltaB = &deltaB)
						{
							ImPlot.UpdateNative(Handle, (float*)ppadA, (float*)ppadB, (float*)pdeltaA, (float*)pdeltaB);
						}
					}
				}
			}
		}

	}

}
