// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using HexaGen.Runtime;
using System.Numerics;
using Hexa.NET.ImGui;

namespace Hexa.NET.ImPlot
{
	public unsafe partial class ImPlot
	{
		internal static VTable vt;

		public static void InitApi()
		{
			vt = new VTable(GetLibraryName(), 741);
			vt.Load(0, "ImPlotPoint_ImPlotPoint_Nil");			vt.Load(1, "ImPlotPoint_destroy");			vt.Load(2, "ImPlotPoint_ImPlotPoint_double");			vt.Load(3, "ImPlotPoint_ImPlotPoint_Vec2");			vt.Load(4, "ImPlotRange_ImPlotRange_Nil");			vt.Load(5, "ImPlotRange_destroy");			vt.Load(6, "ImPlotRange_ImPlotRange_double");			vt.Load(7, "ImPlotRange_Contains");			vt.Load(8, "ImPlotRange_Size");			vt.Load(9, "ImPlotRange_Clamp");			vt.Load(10, "ImPlotRect_ImPlotRect_Nil");			vt.Load(11, "ImPlotRect_destroy");			vt.Load(12, "ImPlotRect_ImPlotRect_double");			vt.Load(13, "ImPlotRect_Contains_PlotPoInt");			vt.Load(14, "ImPlotRect_Contains_double");			vt.Load(15, "ImPlotRect_Size");			vt.Load(16, "ImPlotRect_Clamp_PlotPoInt");			vt.Load(17, "ImPlotRect_Clamp_double");			vt.Load(18, "ImPlotRect_Min");			vt.Load(19, "ImPlotRect_Max");			vt.Load(20, "ImPlotStyle_ImPlotStyle");			vt.Load(21, "ImPlotStyle_destroy");			vt.Load(22, "ImPlotInputMap_ImPlotInputMap");			vt.Load(23, "ImPlotInputMap_destroy");			vt.Load(24, "ImPlot_CreateContext");			vt.Load(25, "ImPlot_DestroyContext");			vt.Load(26, "ImPlot_GetCurrentContext");			vt.Load(27, "ImPlot_SetCurrentContext");			vt.Load(28, "ImPlot_SetImGuiContext");			vt.Load(29, "ImPlot_BeginPlot");			vt.Load(30, "ImPlot_EndPlot");			vt.Load(31, "ImPlot_BeginSubplots");			vt.Load(32, "ImPlot_EndSubplots");			vt.Load(33, "ImPlot_SetupAxis");			vt.Load(34, "ImPlot_SetupAxisLimits");			vt.Load(35, "ImPlot_SetupAxisLinks");			vt.Load(36, "ImPlot_SetupAxisFormat_Str");			vt.Load(37, "ImPlot_SetupAxisFormat_PlotFormatter");			vt.Load(38, "ImPlot_SetupAxisTicks_doublePtr");			vt.Load(39, "ImPlot_SetupAxisTicks_double");			vt.Load(40, "ImPlot_SetupAxisScale_PlotScale");			vt.Load(41, "ImPlot_SetupAxisScale_PlotTransform");			vt.Load(42, "ImPlot_SetupAxisLimitsConstraints");			vt.Load(43, "ImPlot_SetupAxisZoomConstraints");			vt.Load(44, "ImPlot_SetupAxes");			vt.Load(45, "ImPlot_SetupAxesLimits");			vt.Load(46, "ImPlot_SetupLegend");			vt.Load(47, "ImPlot_SetupMouseText");			vt.Load(48, "ImPlot_SetupFinish");			vt.Load(49, "ImPlot_SetNextAxisLimits");			vt.Load(50, "ImPlot_SetNextAxisLinks");			vt.Load(51, "ImPlot_SetNextAxisToFit");			vt.Load(52, "ImPlot_SetNextAxesLimits");			vt.Load(53, "ImPlot_SetNextAxesToFit");			vt.Load(54, "ImPlot_PlotLine_FloatPtrInt");			vt.Load(55, "ImPlot_PlotLine_doublePtrInt");			vt.Load(56, "ImPlot_PlotLine_S8PtrInt");			vt.Load(57, "ImPlot_PlotLine_U8PtrInt");			vt.Load(58, "ImPlot_PlotLine_S16PtrInt");			vt.Load(59, "ImPlot_PlotLine_U16PtrInt");			vt.Load(60, "ImPlot_PlotLine_S32PtrInt");			vt.Load(61, "ImPlot_PlotLine_U32PtrInt");			vt.Load(62, "ImPlot_PlotLine_S64PtrInt");			vt.Load(63, "ImPlot_PlotLine_U64PtrInt");			vt.Load(64, "ImPlot_PlotLine_FloatPtrFloatPtr");			vt.Load(65, "ImPlot_PlotLine_doublePtrdoublePtr");			vt.Load(66, "ImPlot_PlotLine_S8PtrS8Ptr");			vt.Load(67, "ImPlot_PlotLine_U8PtrU8Ptr");			vt.Load(68, "ImPlot_PlotLine_S16PtrS16Ptr");			vt.Load(69, "ImPlot_PlotLine_U16PtrU16Ptr");			vt.Load(70, "ImPlot_PlotLine_S32PtrS32Ptr");			vt.Load(71, "ImPlot_PlotLine_U32PtrU32Ptr");			vt.Load(72, "ImPlot_PlotLine_S64PtrS64Ptr");			vt.Load(73, "ImPlot_PlotLine_U64PtrU64Ptr");			vt.Load(74, "ImPlot_PlotLineG");			vt.Load(75, "ImPlot_PlotScatter_FloatPtrInt");			vt.Load(76, "ImPlot_PlotScatter_doublePtrInt");			vt.Load(77, "ImPlot_PlotScatter_S8PtrInt");			vt.Load(78, "ImPlot_PlotScatter_U8PtrInt");			vt.Load(79, "ImPlot_PlotScatter_S16PtrInt");			vt.Load(80, "ImPlot_PlotScatter_U16PtrInt");			vt.Load(81, "ImPlot_PlotScatter_S32PtrInt");			vt.Load(82, "ImPlot_PlotScatter_U32PtrInt");			vt.Load(83, "ImPlot_PlotScatter_S64PtrInt");			vt.Load(84, "ImPlot_PlotScatter_U64PtrInt");			vt.Load(85, "ImPlot_PlotScatter_FloatPtrFloatPtr");			vt.Load(86, "ImPlot_PlotScatter_doublePtrdoublePtr");			vt.Load(87, "ImPlot_PlotScatter_S8PtrS8Ptr");			vt.Load(88, "ImPlot_PlotScatter_U8PtrU8Ptr");			vt.Load(89, "ImPlot_PlotScatter_S16PtrS16Ptr");			vt.Load(90, "ImPlot_PlotScatter_U16PtrU16Ptr");			vt.Load(91, "ImPlot_PlotScatter_S32PtrS32Ptr");			vt.Load(92, "ImPlot_PlotScatter_U32PtrU32Ptr");			vt.Load(93, "ImPlot_PlotScatter_S64PtrS64Ptr");			vt.Load(94, "ImPlot_PlotScatter_U64PtrU64Ptr");			vt.Load(95, "ImPlot_PlotScatterG");			vt.Load(96, "ImPlot_PlotStairs_FloatPtrInt");			vt.Load(97, "ImPlot_PlotStairs_doublePtrInt");			vt.Load(98, "ImPlot_PlotStairs_S8PtrInt");			vt.Load(99, "ImPlot_PlotStairs_U8PtrInt");			vt.Load(100, "ImPlot_PlotStairs_S16PtrInt");			vt.Load(101, "ImPlot_PlotStairs_U16PtrInt");			vt.Load(102, "ImPlot_PlotStairs_S32PtrInt");			vt.Load(103, "ImPlot_PlotStairs_U32PtrInt");			vt.Load(104, "ImPlot_PlotStairs_S64PtrInt");			vt.Load(105, "ImPlot_PlotStairs_U64PtrInt");			vt.Load(106, "ImPlot_PlotStairs_FloatPtrFloatPtr");			vt.Load(107, "ImPlot_PlotStairs_doublePtrdoublePtr");			vt.Load(108, "ImPlot_PlotStairs_S8PtrS8Ptr");			vt.Load(109, "ImPlot_PlotStairs_U8PtrU8Ptr");			vt.Load(110, "ImPlot_PlotStairs_S16PtrS16Ptr");			vt.Load(111, "ImPlot_PlotStairs_U16PtrU16Ptr");			vt.Load(112, "ImPlot_PlotStairs_S32PtrS32Ptr");			vt.Load(113, "ImPlot_PlotStairs_U32PtrU32Ptr");			vt.Load(114, "ImPlot_PlotStairs_S64PtrS64Ptr");			vt.Load(115, "ImPlot_PlotStairs_U64PtrU64Ptr");			vt.Load(116, "ImPlot_PlotStairsG");			vt.Load(117, "ImPlot_PlotShaded_FloatPtrInt");			vt.Load(118, "ImPlot_PlotShaded_doublePtrInt");			vt.Load(119, "ImPlot_PlotShaded_S8PtrInt");			vt.Load(120, "ImPlot_PlotShaded_U8PtrInt");			vt.Load(121, "ImPlot_PlotShaded_S16PtrInt");			vt.Load(122, "ImPlot_PlotShaded_U16PtrInt");			vt.Load(123, "ImPlot_PlotShaded_S32PtrInt");			vt.Load(124, "ImPlot_PlotShaded_U32PtrInt");			vt.Load(125, "ImPlot_PlotShaded_S64PtrInt");			vt.Load(126, "ImPlot_PlotShaded_U64PtrInt");			vt.Load(127, "ImPlot_PlotShaded_FloatPtrFloatPtrInt");			vt.Load(128, "ImPlot_PlotShaded_doublePtrdoublePtrInt");			vt.Load(129, "ImPlot_PlotShaded_S8PtrS8PtrInt");			vt.Load(130, "ImPlot_PlotShaded_U8PtrU8PtrInt");			vt.Load(131, "ImPlot_PlotShaded_S16PtrS16PtrInt");			vt.Load(132, "ImPlot_PlotShaded_U16PtrU16PtrInt");			vt.Load(133, "ImPlot_PlotShaded_S32PtrS32PtrInt");			vt.Load(134, "ImPlot_PlotShaded_U32PtrU32PtrInt");			vt.Load(135, "ImPlot_PlotShaded_S64PtrS64PtrInt");			vt.Load(136, "ImPlot_PlotShaded_U64PtrU64PtrInt");			vt.Load(137, "ImPlot_PlotShaded_FloatPtrFloatPtrFloatPtr");			vt.Load(138, "ImPlot_PlotShaded_doublePtrdoublePtrdoublePtr");			vt.Load(139, "ImPlot_PlotShaded_S8PtrS8PtrS8Ptr");			vt.Load(140, "ImPlot_PlotShaded_U8PtrU8PtrU8Ptr");			vt.Load(141, "ImPlot_PlotShaded_S16PtrS16PtrS16Ptr");			vt.Load(142, "ImPlot_PlotShaded_U16PtrU16PtrU16Ptr");			vt.Load(143, "ImPlot_PlotShaded_S32PtrS32PtrS32Ptr");			vt.Load(144, "ImPlot_PlotShaded_U32PtrU32PtrU32Ptr");			vt.Load(145, "ImPlot_PlotShaded_S64PtrS64PtrS64Ptr");			vt.Load(146, "ImPlot_PlotShaded_U64PtrU64PtrU64Ptr");			vt.Load(147, "ImPlot_PlotShadedG");			vt.Load(148, "ImPlot_PlotBars_FloatPtrInt");			vt.Load(149, "ImPlot_PlotBars_doublePtrInt");			vt.Load(150, "ImPlot_PlotBars_S8PtrInt");			vt.Load(151, "ImPlot_PlotBars_U8PtrInt");			vt.Load(152, "ImPlot_PlotBars_S16PtrInt");			vt.Load(153, "ImPlot_PlotBars_U16PtrInt");			vt.Load(154, "ImPlot_PlotBars_S32PtrInt");			vt.Load(155, "ImPlot_PlotBars_U32PtrInt");			vt.Load(156, "ImPlot_PlotBars_S64PtrInt");			vt.Load(157, "ImPlot_PlotBars_U64PtrInt");			vt.Load(158, "ImPlot_PlotBars_FloatPtrFloatPtr");			vt.Load(159, "ImPlot_PlotBars_doublePtrdoublePtr");			vt.Load(160, "ImPlot_PlotBars_S8PtrS8Ptr");			vt.Load(161, "ImPlot_PlotBars_U8PtrU8Ptr");			vt.Load(162, "ImPlot_PlotBars_S16PtrS16Ptr");			vt.Load(163, "ImPlot_PlotBars_U16PtrU16Ptr");			vt.Load(164, "ImPlot_PlotBars_S32PtrS32Ptr");			vt.Load(165, "ImPlot_PlotBars_U32PtrU32Ptr");			vt.Load(166, "ImPlot_PlotBars_S64PtrS64Ptr");			vt.Load(167, "ImPlot_PlotBars_U64PtrU64Ptr");			vt.Load(168, "ImPlot_PlotBarsG");			vt.Load(169, "ImPlot_PlotBarGroups_FloatPtr");			vt.Load(170, "ImPlot_PlotBarGroups_doublePtr");			vt.Load(171, "ImPlot_PlotBarGroups_S8Ptr");			vt.Load(172, "ImPlot_PlotBarGroups_U8Ptr");			vt.Load(173, "ImPlot_PlotBarGroups_S16Ptr");			vt.Load(174, "ImPlot_PlotBarGroups_U16Ptr");			vt.Load(175, "ImPlot_PlotBarGroups_S32Ptr");			vt.Load(176, "ImPlot_PlotBarGroups_U32Ptr");			vt.Load(177, "ImPlot_PlotBarGroups_S64Ptr");			vt.Load(178, "ImPlot_PlotBarGroups_U64Ptr");			vt.Load(179, "ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt");			vt.Load(180, "ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrInt");			vt.Load(181, "ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrInt");			vt.Load(182, "ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrInt");			vt.Load(183, "ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrInt");			vt.Load(184, "ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrInt");			vt.Load(185, "ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrInt");			vt.Load(186, "ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrInt");			vt.Load(187, "ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrInt");			vt.Load(188, "ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrInt");			vt.Load(189, "ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrFloatPtr");			vt.Load(190, "ImPlot_PlotErrorBars_doublePtrdoublePtrdoublePtrdoublePtr");			vt.Load(191, "ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr");			vt.Load(192, "ImPlot_PlotErrorBars_U8PtrU8PtrU8PtrU8Ptr");			vt.Load(193, "ImPlot_PlotErrorBars_S16PtrS16PtrS16PtrS16Ptr");			vt.Load(194, "ImPlot_PlotErrorBars_U16PtrU16PtrU16PtrU16Ptr");			vt.Load(195, "ImPlot_PlotErrorBars_S32PtrS32PtrS32PtrS32Ptr");			vt.Load(196, "ImPlot_PlotErrorBars_U32PtrU32PtrU32PtrU32Ptr");			vt.Load(197, "ImPlot_PlotErrorBars_S64PtrS64PtrS64PtrS64Ptr");			vt.Load(198, "ImPlot_PlotErrorBars_U64PtrU64PtrU64PtrU64Ptr");			vt.Load(199, "ImPlot_PlotStems_FloatPtrInt");			vt.Load(200, "ImPlot_PlotStems_doublePtrInt");			vt.Load(201, "ImPlot_PlotStems_S8PtrInt");			vt.Load(202, "ImPlot_PlotStems_U8PtrInt");			vt.Load(203, "ImPlot_PlotStems_S16PtrInt");			vt.Load(204, "ImPlot_PlotStems_U16PtrInt");			vt.Load(205, "ImPlot_PlotStems_S32PtrInt");			vt.Load(206, "ImPlot_PlotStems_U32PtrInt");			vt.Load(207, "ImPlot_PlotStems_S64PtrInt");			vt.Load(208, "ImPlot_PlotStems_U64PtrInt");			vt.Load(209, "ImPlot_PlotStems_FloatPtrFloatPtr");			vt.Load(210, "ImPlot_PlotStems_doublePtrdoublePtr");			vt.Load(211, "ImPlot_PlotStems_S8PtrS8Ptr");			vt.Load(212, "ImPlot_PlotStems_U8PtrU8Ptr");			vt.Load(213, "ImPlot_PlotStems_S16PtrS16Ptr");			vt.Load(214, "ImPlot_PlotStems_U16PtrU16Ptr");			vt.Load(215, "ImPlot_PlotStems_S32PtrS32Ptr");			vt.Load(216, "ImPlot_PlotStems_U32PtrU32Ptr");			vt.Load(217, "ImPlot_PlotStems_S64PtrS64Ptr");			vt.Load(218, "ImPlot_PlotStems_U64PtrU64Ptr");			vt.Load(219, "ImPlot_PlotInfLines_FloatPtr");			vt.Load(220, "ImPlot_PlotInfLines_doublePtr");			vt.Load(221, "ImPlot_PlotInfLines_S8Ptr");			vt.Load(222, "ImPlot_PlotInfLines_U8Ptr");			vt.Load(223, "ImPlot_PlotInfLines_S16Ptr");			vt.Load(224, "ImPlot_PlotInfLines_U16Ptr");			vt.Load(225, "ImPlot_PlotInfLines_S32Ptr");			vt.Load(226, "ImPlot_PlotInfLines_U32Ptr");			vt.Load(227, "ImPlot_PlotInfLines_S64Ptr");			vt.Load(228, "ImPlot_PlotInfLines_U64Ptr");			vt.Load(229, "ImPlot_PlotPieChart_FloatPtrPlotFormatter");			vt.Load(230, "ImPlot_PlotPieChart_doublePtrPlotFormatter");			vt.Load(231, "ImPlot_PlotPieChart_S8PtrPlotFormatter");			vt.Load(232, "ImPlot_PlotPieChart_U8PtrPlotFormatter");			vt.Load(233, "ImPlot_PlotPieChart_S16PtrPlotFormatter");			vt.Load(234, "ImPlot_PlotPieChart_U16PtrPlotFormatter");			vt.Load(235, "ImPlot_PlotPieChart_S32PtrPlotFormatter");			vt.Load(236, "ImPlot_PlotPieChart_U32PtrPlotFormatter");			vt.Load(237, "ImPlot_PlotPieChart_S64PtrPlotFormatter");			vt.Load(238, "ImPlot_PlotPieChart_U64PtrPlotFormatter");			vt.Load(239, "ImPlot_PlotPieChart_FloatPtrStr");			vt.Load(240, "ImPlot_PlotPieChart_doublePtrStr");			vt.Load(241, "ImPlot_PlotPieChart_S8PtrStr");			vt.Load(242, "ImPlot_PlotPieChart_U8PtrStr");			vt.Load(243, "ImPlot_PlotPieChart_S16PtrStr");			vt.Load(244, "ImPlot_PlotPieChart_U16PtrStr");			vt.Load(245, "ImPlot_PlotPieChart_S32PtrStr");			vt.Load(246, "ImPlot_PlotPieChart_U32PtrStr");			vt.Load(247, "ImPlot_PlotPieChart_S64PtrStr");			vt.Load(248, "ImPlot_PlotPieChart_U64PtrStr");			vt.Load(249, "ImPlot_PlotHeatmap_FloatPtr");			vt.Load(250, "ImPlot_PlotHeatmap_doublePtr");			vt.Load(251, "ImPlot_PlotHeatmap_S8Ptr");			vt.Load(252, "ImPlot_PlotHeatmap_U8Ptr");			vt.Load(253, "ImPlot_PlotHeatmap_S16Ptr");			vt.Load(254, "ImPlot_PlotHeatmap_U16Ptr");			vt.Load(255, "ImPlot_PlotHeatmap_S32Ptr");			vt.Load(256, "ImPlot_PlotHeatmap_U32Ptr");			vt.Load(257, "ImPlot_PlotHeatmap_S64Ptr");			vt.Load(258, "ImPlot_PlotHeatmap_U64Ptr");			vt.Load(259, "ImPlot_PlotHistogram_FloatPtr");			vt.Load(260, "ImPlot_PlotHistogram_doublePtr");			vt.Load(261, "ImPlot_PlotHistogram_S8Ptr");			vt.Load(262, "ImPlot_PlotHistogram_U8Ptr");			vt.Load(263, "ImPlot_PlotHistogram_S16Ptr");			vt.Load(264, "ImPlot_PlotHistogram_U16Ptr");			vt.Load(265, "ImPlot_PlotHistogram_S32Ptr");			vt.Load(266, "ImPlot_PlotHistogram_U32Ptr");			vt.Load(267, "ImPlot_PlotHistogram_S64Ptr");			vt.Load(268, "ImPlot_PlotHistogram_U64Ptr");			vt.Load(269, "ImPlot_PlotHistogram2D_FloatPtr");			vt.Load(270, "ImPlot_PlotHistogram2D_doublePtr");			vt.Load(271, "ImPlot_PlotHistogram2D_S8Ptr");			vt.Load(272, "ImPlot_PlotHistogram2D_U8Ptr");			vt.Load(273, "ImPlot_PlotHistogram2D_S16Ptr");			vt.Load(274, "ImPlot_PlotHistogram2D_U16Ptr");			vt.Load(275, "ImPlot_PlotHistogram2D_S32Ptr");			vt.Load(276, "ImPlot_PlotHistogram2D_U32Ptr");			vt.Load(277, "ImPlot_PlotHistogram2D_S64Ptr");			vt.Load(278, "ImPlot_PlotHistogram2D_U64Ptr");			vt.Load(279, "ImPlot_PlotDigital_FloatPtr");			vt.Load(280, "ImPlot_PlotDigital_doublePtr");			vt.Load(281, "ImPlot_PlotDigital_S8Ptr");			vt.Load(282, "ImPlot_PlotDigital_U8Ptr");			vt.Load(283, "ImPlot_PlotDigital_S16Ptr");			vt.Load(284, "ImPlot_PlotDigital_U16Ptr");			vt.Load(285, "ImPlot_PlotDigital_S32Ptr");			vt.Load(286, "ImPlot_PlotDigital_U32Ptr");			vt.Load(287, "ImPlot_PlotDigital_S64Ptr");			vt.Load(288, "ImPlot_PlotDigital_U64Ptr");			vt.Load(289, "ImPlot_PlotDigitalG");			vt.Load(290, "ImPlot_PlotImage");			vt.Load(291, "ImPlot_PlotText");			vt.Load(292, "ImPlot_PlotDummy");			vt.Load(293, "ImPlot_DragPoint");			vt.Load(294, "ImPlot_DragLineX");			vt.Load(295, "ImPlot_DragLineY");			vt.Load(296, "ImPlot_DragRect");			vt.Load(297, "ImPlot_Annotation_Bool");			vt.Load(298, "ImPlot_Annotation_Str");			vt.Load(299, "ImPlot_AnnotationV");			vt.Load(300, "ImPlot_TagX_Bool");			vt.Load(301, "ImPlot_TagX_Str");			vt.Load(302, "ImPlot_TagXV");			vt.Load(303, "ImPlot_TagY_Bool");			vt.Load(304, "ImPlot_TagY_Str");			vt.Load(305, "ImPlot_TagYV");			vt.Load(306, "ImPlot_SetAxis");			vt.Load(307, "ImPlot_SetAxes");			vt.Load(308, "ImPlot_PixelsToPlot_Vec2");			vt.Load(309, "ImPlot_PixelsToPlot_Float");			vt.Load(310, "ImPlot_PlotToPixels_PlotPoInt");			vt.Load(311, "ImPlot_PlotToPixels_double");			vt.Load(312, "ImPlot_GetPlotPos");			vt.Load(313, "ImPlot_GetPlotSize");			vt.Load(314, "ImPlot_GetPlotMousePos");			vt.Load(315, "ImPlot_GetPlotLimits");			vt.Load(316, "ImPlot_IsPlotHovered");			vt.Load(317, "ImPlot_IsAxisHovered");			vt.Load(318, "ImPlot_IsSubplotsHovered");			vt.Load(319, "ImPlot_IsPlotSelected");			vt.Load(320, "ImPlot_GetPlotSelection");			vt.Load(321, "ImPlot_CancelPlotSelection");			vt.Load(322, "ImPlot_HideNextItem");			vt.Load(323, "ImPlot_BeginAlignedPlots");			vt.Load(324, "ImPlot_EndAlignedPlots");			vt.Load(325, "ImPlot_BeginLegendPopup");			vt.Load(326, "ImPlot_EndLegendPopup");			vt.Load(327, "ImPlot_IsLegendEntryHovered");			vt.Load(328, "ImPlot_BeginDragDropTargetPlot");			vt.Load(329, "ImPlot_BeginDragDropTargetAxis");			vt.Load(330, "ImPlot_BeginDragDropTargetLegend");			vt.Load(331, "ImPlot_EndDragDropTarget");			vt.Load(332, "ImPlot_BeginDragDropSourcePlot");			vt.Load(333, "ImPlot_BeginDragDropSourceAxis");			vt.Load(334, "ImPlot_BeginDragDropSourceItem");			vt.Load(335, "ImPlot_EndDragDropSource");			vt.Load(336, "ImPlot_GetStyle");			vt.Load(337, "ImPlot_StyleColorsAuto");			vt.Load(338, "ImPlot_StyleColorsClassic");			vt.Load(339, "ImPlot_StyleColorsDark");			vt.Load(340, "ImPlot_StyleColorsLight");			vt.Load(341, "ImPlot_PushStyleColor_U32");			vt.Load(342, "ImPlot_PushStyleColor_Vec4");			vt.Load(343, "ImPlot_PopStyleColor");			vt.Load(344, "ImPlot_PushStyleVar_Float");			vt.Load(345, "ImPlot_PushStyleVar_Int");			vt.Load(346, "ImPlot_PushStyleVar_Vec2");			vt.Load(347, "ImPlot_PopStyleVar");			vt.Load(348, "ImPlot_SetNextLineStyle");			vt.Load(349, "ImPlot_SetNextFillStyle");			vt.Load(350, "ImPlot_SetNextMarkerStyle");			vt.Load(351, "ImPlot_SetNextErrorBarStyle");			vt.Load(352, "ImPlot_GetLastItemColor");			vt.Load(353, "ImPlot_GetStyleColorName");			vt.Load(354, "ImPlot_GetMarkerName");			vt.Load(355, "ImPlot_AddColormap_Vec4Ptr");			vt.Load(356, "ImPlot_AddColormap_U32Ptr");			vt.Load(357, "ImPlot_GetColormapCount");			vt.Load(358, "ImPlot_GetColormapName");			vt.Load(359, "ImPlot_GetColormapIndex");			vt.Load(360, "ImPlot_PushColormap_PlotColormap");			vt.Load(361, "ImPlot_PushColormap_Str");			vt.Load(362, "ImPlot_PopColormap");			vt.Load(363, "ImPlot_NextColormapColor");			vt.Load(364, "ImPlot_GetColormapSize");			vt.Load(365, "ImPlot_GetColormapColor");			vt.Load(366, "ImPlot_SampleColormap");			vt.Load(367, "ImPlot_ColormapScale");			vt.Load(368, "ImPlot_ColormapSlider");			vt.Load(369, "ImPlot_ColormapButton");			vt.Load(370, "ImPlot_BustColorCache");			vt.Load(371, "ImPlot_GetInputMap");			vt.Load(372, "ImPlot_MapInputDefault");			vt.Load(373, "ImPlot_MapInputReverse");			vt.Load(374, "ImPlot_ItemIcon_Vec4");			vt.Load(375, "ImPlot_ItemIcon_U32");			vt.Load(376, "ImPlot_ColormapIcon");			vt.Load(377, "ImPlot_GetPlotDrawList");			vt.Load(378, "ImPlot_PushPlotClipRect");			vt.Load(379, "ImPlot_PopPlotClipRect");			vt.Load(380, "ImPlot_ShowStyleSelector");			vt.Load(381, "ImPlot_ShowColormapSelector");			vt.Load(382, "ImPlot_ShowInputMapSelector");			vt.Load(383, "ImPlot_ShowStyleEditor");			vt.Load(384, "ImPlot_ShowUserGuide");			vt.Load(385, "ImPlot_ShowMetricsWindow");			vt.Load(386, "ImPlot_ShowDemoWindow");			vt.Load(387, "ImPlot_ImLog10_Float");			vt.Load(388, "ImPlot_ImLog10_double");			vt.Load(389, "ImPlot_ImSinh_Float");			vt.Load(390, "ImPlot_ImSinh_double");			vt.Load(391, "ImPlot_ImAsinh_Float");			vt.Load(392, "ImPlot_ImAsinh_double");			vt.Load(393, "ImPlot_ImRemap_Float");			vt.Load(394, "ImPlot_ImRemap_double");			vt.Load(395, "ImPlot_ImRemap_S8");			vt.Load(396, "ImPlot_ImRemap_U8");			vt.Load(397, "ImPlot_ImRemap_S16");			vt.Load(398, "ImPlot_ImRemap_U16");			vt.Load(399, "ImPlot_ImRemap_S32");			vt.Load(400, "ImPlot_ImRemap_U32");			vt.Load(401, "ImPlot_ImRemap_S64");			vt.Load(402, "ImPlot_ImRemap_U64");			vt.Load(403, "ImPlot_ImRemap01_Float");			vt.Load(404, "ImPlot_ImRemap01_double");			vt.Load(405, "ImPlot_ImRemap01_S8");			vt.Load(406, "ImPlot_ImRemap01_U8");			vt.Load(407, "ImPlot_ImRemap01_S16");			vt.Load(408, "ImPlot_ImRemap01_U16");			vt.Load(409, "ImPlot_ImRemap01_S32");			vt.Load(410, "ImPlot_ImRemap01_U32");			vt.Load(411, "ImPlot_ImRemap01_S64");			vt.Load(412, "ImPlot_ImRemap01_U64");			vt.Load(413, "ImPlot_ImPosMod");			vt.Load(414, "ImPlot_ImNan");			vt.Load(415, "ImPlot_ImNanOrInf");			vt.Load(416, "ImPlot_ImConstrainNan");			vt.Load(417, "ImPlot_ImConstrainInf");			vt.Load(418, "ImPlot_ImConstrainLog");			vt.Load(419, "ImPlot_ImConstrainTime");			vt.Load(420, "ImPlot_ImAlmostEqual");			vt.Load(421, "ImPlot_ImMinArray_FloatPtr");			vt.Load(422, "ImPlot_ImMinArray_doublePtr");			vt.Load(423, "ImPlot_ImMinArray_S8Ptr");			vt.Load(424, "ImPlot_ImMinArray_U8Ptr");			vt.Load(425, "ImPlot_ImMinArray_S16Ptr");			vt.Load(426, "ImPlot_ImMinArray_U16Ptr");			vt.Load(427, "ImPlot_ImMinArray_S32Ptr");			vt.Load(428, "ImPlot_ImMinArray_U32Ptr");			vt.Load(429, "ImPlot_ImMinArray_S64Ptr");			vt.Load(430, "ImPlot_ImMinArray_U64Ptr");			vt.Load(431, "ImPlot_ImMaxArray_FloatPtr");			vt.Load(432, "ImPlot_ImMaxArray_doublePtr");			vt.Load(433, "ImPlot_ImMaxArray_S8Ptr");			vt.Load(434, "ImPlot_ImMaxArray_U8Ptr");			vt.Load(435, "ImPlot_ImMaxArray_S16Ptr");			vt.Load(436, "ImPlot_ImMaxArray_U16Ptr");			vt.Load(437, "ImPlot_ImMaxArray_S32Ptr");			vt.Load(438, "ImPlot_ImMaxArray_U32Ptr");			vt.Load(439, "ImPlot_ImMaxArray_S64Ptr");			vt.Load(440, "ImPlot_ImMaxArray_U64Ptr");			vt.Load(441, "ImPlot_ImMinMaxArray_FloatPtr");			vt.Load(442, "ImPlot_ImMinMaxArray_doublePtr");			vt.Load(443, "ImPlot_ImMinMaxArray_S8Ptr");			vt.Load(444, "ImPlot_ImMinMaxArray_U8Ptr");			vt.Load(445, "ImPlot_ImMinMaxArray_S16Ptr");			vt.Load(446, "ImPlot_ImMinMaxArray_U16Ptr");			vt.Load(447, "ImPlot_ImMinMaxArray_S32Ptr");			vt.Load(448, "ImPlot_ImMinMaxArray_U32Ptr");			vt.Load(449, "ImPlot_ImMinMaxArray_S64Ptr");			vt.Load(450, "ImPlot_ImMinMaxArray_U64Ptr");			vt.Load(451, "ImPlot_ImSum_FloatPtr");			vt.Load(452, "ImPlot_ImSum_doublePtr");			vt.Load(453, "ImPlot_ImSum_S8Ptr");			vt.Load(454, "ImPlot_ImSum_U8Ptr");			vt.Load(455, "ImPlot_ImSum_S16Ptr");			vt.Load(456, "ImPlot_ImSum_U16Ptr");			vt.Load(457, "ImPlot_ImSum_S32Ptr");			vt.Load(458, "ImPlot_ImSum_U32Ptr");			vt.Load(459, "ImPlot_ImSum_S64Ptr");			vt.Load(460, "ImPlot_ImSum_U64Ptr");			vt.Load(461, "ImPlot_ImMean_FloatPtr");			vt.Load(462, "ImPlot_ImMean_doublePtr");			vt.Load(463, "ImPlot_ImMean_S8Ptr");			vt.Load(464, "ImPlot_ImMean_U8Ptr");			vt.Load(465, "ImPlot_ImMean_S16Ptr");			vt.Load(466, "ImPlot_ImMean_U16Ptr");			vt.Load(467, "ImPlot_ImMean_S32Ptr");			vt.Load(468, "ImPlot_ImMean_U32Ptr");			vt.Load(469, "ImPlot_ImMean_S64Ptr");			vt.Load(470, "ImPlot_ImMean_U64Ptr");			vt.Load(471, "ImPlot_ImStdDev_FloatPtr");			vt.Load(472, "ImPlot_ImStdDev_doublePtr");			vt.Load(473, "ImPlot_ImStdDev_S8Ptr");			vt.Load(474, "ImPlot_ImStdDev_U8Ptr");			vt.Load(475, "ImPlot_ImStdDev_S16Ptr");			vt.Load(476, "ImPlot_ImStdDev_U16Ptr");			vt.Load(477, "ImPlot_ImStdDev_S32Ptr");			vt.Load(478, "ImPlot_ImStdDev_U32Ptr");			vt.Load(479, "ImPlot_ImStdDev_S64Ptr");			vt.Load(480, "ImPlot_ImStdDev_U64Ptr");			vt.Load(481, "ImPlot_ImMixU32");			vt.Load(482, "ImPlot_ImLerpU32");			vt.Load(483, "ImPlot_ImAlphaU32");			vt.Load(484, "ImPlot_ImOverlaps_Float");			vt.Load(485, "ImPlot_ImOverlaps_double");			vt.Load(486, "ImPlot_ImOverlaps_S8");			vt.Load(487, "ImPlot_ImOverlaps_U8");			vt.Load(488, "ImPlot_ImOverlaps_S16");			vt.Load(489, "ImPlot_ImOverlaps_U16");			vt.Load(490, "ImPlot_ImOverlaps_S32");			vt.Load(491, "ImPlot_ImOverlaps_U32");			vt.Load(492, "ImPlot_ImOverlaps_S64");			vt.Load(493, "ImPlot_ImOverlaps_U64");			vt.Load(494, "ImPlotDateTimeSpec_ImPlotDateTimeSpec_Nil");			vt.Load(495, "ImPlotDateTimeSpec_destroy");			vt.Load(496, "ImPlotDateTimeSpec_ImPlotDateTimeSpec_PlotDateFmt");			vt.Load(497, "ImPlotTime_ImPlotTime_Nil");			vt.Load(498, "ImPlotTime_destroy");			vt.Load(499, "ImPlotTime_ImPlotTime_time_t");			vt.Load(500, "ImPlotTime_RollOver");			vt.Load(501, "ImPlotTime_ToDouble");			vt.Load(502, "ImPlotTime_FromDouble");			vt.Load(503, "ImPlotColormapData_ImPlotColormapData");			vt.Load(504, "ImPlotColormapData_destroy");			vt.Load(505, "ImPlotColormapData_Append");			vt.Load(506, "ImPlotColormapData__AppendTable");			vt.Load(507, "ImPlotColormapData_RebuildTables");			vt.Load(508, "ImPlotColormapData_IsQual");			vt.Load(509, "ImPlotColormapData_GetName");			vt.Load(510, "ImPlotColormapData_GetIndex");			vt.Load(511, "ImPlotColormapData_GetKeys");			vt.Load(512, "ImPlotColormapData_GetKeyCount");			vt.Load(513, "ImPlotColormapData_GetKeyColor");			vt.Load(514, "ImPlotColormapData_SetKeyColor");			vt.Load(515, "ImPlotColormapData_GetTable");			vt.Load(516, "ImPlotColormapData_GetTableSize");			vt.Load(517, "ImPlotColormapData_GetTableColor");			vt.Load(518, "ImPlotColormapData_LerpTable");			vt.Load(519, "ImPlotPointError_ImPlotPointError");			vt.Load(520, "ImPlotPointError_destroy");			vt.Load(521, "ImPlotAnnotation_ImPlotAnnotation");			vt.Load(522, "ImPlotAnnotation_destroy");			vt.Load(523, "ImPlotAnnotationCollection_ImPlotAnnotationCollection");			vt.Load(524, "ImPlotAnnotationCollection_destroy");			vt.Load(525, "ImPlotAnnotationCollection_AppendV");			vt.Load(526, "ImPlotAnnotationCollection_Append");			vt.Load(527, "ImPlotAnnotationCollection_GetText");			vt.Load(528, "ImPlotAnnotationCollection_Reset");			vt.Load(529, "ImPlotTagCollection_ImPlotTagCollection");			vt.Load(530, "ImPlotTagCollection_destroy");			vt.Load(531, "ImPlotTagCollection_AppendV");			vt.Load(532, "ImPlotTagCollection_Append");			vt.Load(533, "ImPlotTagCollection_GetText");			vt.Load(534, "ImPlotTagCollection_Reset");			vt.Load(535, "ImPlotTick_ImPlotTick");			vt.Load(536, "ImPlotTick_destroy");			vt.Load(537, "ImPlotTicker_ImPlotTicker");			vt.Load(538, "ImPlotTicker_destroy");			vt.Load(539, "ImPlotTicker_AddTick_doubleStr");			vt.Load(540, "ImPlotTicker_AddTick_doublePlotFormatter");			vt.Load(541, "ImPlotTicker_AddTick_PlotTick");			vt.Load(542, "ImPlotTicker_GetText_Int");			vt.Load(543, "ImPlotTicker_GetText_PlotTick");			vt.Load(544, "ImPlotTicker_OverrideSizeLate");			vt.Load(545, "ImPlotTicker_Reset");			vt.Load(546, "ImPlotTicker_TickCount");			vt.Load(547, "ImPlotAxis_ImPlotAxis");			vt.Load(548, "ImPlotAxis_destroy");			vt.Load(549, "ImPlotAxis_Reset");			vt.Load(550, "ImPlotAxis_SetMin");			vt.Load(551, "ImPlotAxis_SetMax");			vt.Load(552, "ImPlotAxis_SetRange_double");			vt.Load(553, "ImPlotAxis_SetRange_PlotRange");			vt.Load(554, "ImPlotAxis_SetAspect");			vt.Load(555, "ImPlotAxis_PixelSize");			vt.Load(556, "ImPlotAxis_GetAspect");			vt.Load(557, "ImPlotAxis_Constrain");			vt.Load(558, "ImPlotAxis_UpdateTransformCache");			vt.Load(559, "ImPlotAxis_PlotToPixels");			vt.Load(560, "ImPlotAxis_PixelsToPlot");			vt.Load(561, "ImPlotAxis_ExtendFit");			vt.Load(562, "ImPlotAxis_ExtendFitWith");			vt.Load(563, "ImPlotAxis_ApplyFit");			vt.Load(564, "ImPlotAxis_HasLabel");			vt.Load(565, "ImPlotAxis_HasGridLines");			vt.Load(566, "ImPlotAxis_HasTickLabels");			vt.Load(567, "ImPlotAxis_HasTickMarks");			vt.Load(568, "ImPlotAxis_WillRender");			vt.Load(569, "ImPlotAxis_IsOpposite");			vt.Load(570, "ImPlotAxis_IsInverted");			vt.Load(571, "ImPlotAxis_IsForeground");			vt.Load(572, "ImPlotAxis_IsAutoFitting");			vt.Load(573, "ImPlotAxis_CanInitFit");			vt.Load(574, "ImPlotAxis_IsRangeLocked");			vt.Load(575, "ImPlotAxis_IsLockedMin");			vt.Load(576, "ImPlotAxis_IsLockedMax");			vt.Load(577, "ImPlotAxis_IsLocked");			vt.Load(578, "ImPlotAxis_IsInputLockedMin");			vt.Load(579, "ImPlotAxis_IsInputLockedMax");			vt.Load(580, "ImPlotAxis_IsInputLocked");			vt.Load(581, "ImPlotAxis_HasMenus");			vt.Load(582, "ImPlotAxis_IsPanLocked");			vt.Load(583, "ImPlotAxis_PushLinks");			vt.Load(584, "ImPlotAxis_PullLinks");			vt.Load(585, "ImPlotAlignmentData_ImPlotAlignmentData");			vt.Load(586, "ImPlotAlignmentData_destroy");			vt.Load(587, "ImPlotAlignmentData_Begin");			vt.Load(588, "ImPlotAlignmentData_Update");			vt.Load(589, "ImPlotAlignmentData_End");			vt.Load(590, "ImPlotAlignmentData_Reset");			vt.Load(591, "ImPlotItem_ImPlotItem");			vt.Load(592, "ImPlotItem_destroy");			vt.Load(593, "ImPlotLegend_ImPlotLegend");			vt.Load(594, "ImPlotLegend_destroy");			vt.Load(595, "ImPlotLegend_Reset");			vt.Load(596, "ImPlotItemGroup_ImPlotItemGroup");			vt.Load(597, "ImPlotItemGroup_destroy");			vt.Load(598, "ImPlotItemGroup_GetItemCount");			vt.Load(599, "ImPlotItemGroup_GetItemID");			vt.Load(600, "ImPlotItemGroup_GetItem_ID");			vt.Load(601, "ImPlotItemGroup_GetItem_Str");			vt.Load(602, "ImPlotItemGroup_GetOrAddItem");			vt.Load(603, "ImPlotItemGroup_GetItemByIndex");			vt.Load(604, "ImPlotItemGroup_GetItemIndex");			vt.Load(605, "ImPlotItemGroup_GetLegendCount");			vt.Load(606, "ImPlotItemGroup_GetLegendItem");			vt.Load(607, "ImPlotItemGroup_GetLegendLabel");			vt.Load(608, "ImPlotItemGroup_Reset");			vt.Load(609, "ImPlotPlot_ImPlotPlot");			vt.Load(610, "ImPlotPlot_destroy");			vt.Load(611, "ImPlotPlot_IsInputLocked");			vt.Load(612, "ImPlotPlot_ClearTextBuffer");			vt.Load(613, "ImPlotPlot_SetTitle");			vt.Load(614, "ImPlotPlot_HasTitle");			vt.Load(615, "ImPlotPlot_GetTitle");			vt.Load(616, "ImPlotPlot_XAxis_Nil");			vt.Load(617, "ImPlotPlot_XAxis__const");			vt.Load(618, "ImPlotPlot_YAxis_Nil");			vt.Load(619, "ImPlotPlot_YAxis__const");			vt.Load(620, "ImPlotPlot_EnabledAxesX");			vt.Load(621, "ImPlotPlot_EnabledAxesY");			vt.Load(622, "ImPlotPlot_SetAxisLabel");			vt.Load(623, "ImPlotPlot_GetAxisLabel");			vt.Load(624, "ImPlotSubplot_ImPlotSubplot");			vt.Load(625, "ImPlotSubplot_destroy");			vt.Load(626, "ImPlotNextPlotData_ImPlotNextPlotData");			vt.Load(627, "ImPlotNextPlotData_destroy");			vt.Load(628, "ImPlotNextPlotData_Reset");			vt.Load(629, "ImPlotNextItemData_ImPlotNextItemData");			vt.Load(630, "ImPlotNextItemData_destroy");			vt.Load(631, "ImPlotNextItemData_Reset");			vt.Load(632, "ImPlot_Initialize");			vt.Load(633, "ImPlot_ResetCtxForNextPlot");			vt.Load(634, "ImPlot_ResetCtxForNextAlignedPlots");			vt.Load(635, "ImPlot_ResetCtxForNextSubplot");			vt.Load(636, "ImPlot_GetPlot");			vt.Load(637, "ImPlot_GetCurrentPlot");			vt.Load(638, "ImPlot_BustPlotCache");			vt.Load(639, "ImPlot_ShowPlotContextMenu");			vt.Load(640, "ImPlot_SetupLock");			vt.Load(641, "ImPlot_SubplotNextCell");			vt.Load(642, "ImPlot_ShowSubplotsContextMenu");			vt.Load(643, "ImPlot_BeginItem");			vt.Load(644, "ImPlot_EndItem");			vt.Load(645, "ImPlot_RegisterOrGetItem");			vt.Load(646, "ImPlot_GetItem");			vt.Load(647, "ImPlot_GetCurrentItem");			vt.Load(648, "ImPlot_BustItemCache");			vt.Load(649, "ImPlot_AnyAxesInputLocked");			vt.Load(650, "ImPlot_AllAxesInputLocked");			vt.Load(651, "ImPlot_AnyAxesHeld");			vt.Load(652, "ImPlot_AnyAxesHovered");			vt.Load(653, "ImPlot_FitThisFrame");			vt.Load(654, "ImPlot_FitPointX");			vt.Load(655, "ImPlot_FitPointY");			vt.Load(656, "ImPlot_FitPoint");			vt.Load(657, "ImPlot_RangesOverlap");			vt.Load(658, "ImPlot_ShowAxisContextMenu");			vt.Load(659, "ImPlot_GetLocationPos");			vt.Load(660, "ImPlot_CalcLegendSize");			vt.Load(661, "ImPlot_ClampLegendRect");			vt.Load(662, "ImPlot_ShowLegendEntries");			vt.Load(663, "ImPlot_ShowAltLegend");			vt.Load(664, "ImPlot_ShowLegendContextMenu");			vt.Load(665, "ImPlot_LabelAxisValue");			vt.Load(666, "ImPlot_GetItemData");			vt.Load(667, "ImPlot_IsColorAuto_Vec4");			vt.Load(668, "ImPlot_IsColorAuto_PlotCol");			vt.Load(669, "ImPlot_GetAutoColor");			vt.Load(670, "ImPlot_GetStyleColorVec4");			vt.Load(671, "ImPlot_GetStyleColorU32");			vt.Load(672, "ImPlot_AddTextVertical");			vt.Load(673, "ImPlot_AddTextCentered");			vt.Load(674, "ImPlot_CalcTextSizeVertical");			vt.Load(675, "ImPlot_CalcTextColor_Vec4");			vt.Load(676, "ImPlot_CalcTextColor_U32");			vt.Load(677, "ImPlot_CalcHoverColor");			vt.Load(678, "ImPlot_ClampLabelPos");			vt.Load(679, "ImPlot_GetColormapColorU32");			vt.Load(680, "ImPlot_NextColormapColorU32");			vt.Load(681, "ImPlot_SampleColormapU32");			vt.Load(682, "ImPlot_RenderColorBar");			vt.Load(683, "ImPlot_NiceNum");			vt.Load(684, "ImPlot_OrderOfMagnitude");			vt.Load(685, "ImPlot_OrderToPrecision");			vt.Load(686, "ImPlot_Precision");			vt.Load(687, "ImPlot_RoundTo");			vt.Load(688, "ImPlot_Intersection");			vt.Load(689, "ImPlot_FillRange_Vector_Float_Ptr");			vt.Load(690, "ImPlot_FillRange_Vector_double_Ptr");			vt.Load(691, "ImPlot_FillRange_Vector_S8_Ptr");			vt.Load(692, "ImPlot_FillRange_Vector_U8_Ptr");			vt.Load(693, "ImPlot_FillRange_Vector_S16_Ptr");			vt.Load(694, "ImPlot_FillRange_Vector_U16_Ptr");			vt.Load(695, "ImPlot_FillRange_Vector_S32_Ptr");			vt.Load(696, "ImPlot_FillRange_Vector_U32_Ptr");			vt.Load(697, "ImPlot_FillRange_Vector_S64_Ptr");			vt.Load(698, "ImPlot_FillRange_Vector_U64_Ptr");			vt.Load(699, "ImPlot_CalculateBins_FloatPtr");			vt.Load(700, "ImPlot_CalculateBins_doublePtr");			vt.Load(701, "ImPlot_CalculateBins_S8Ptr");			vt.Load(702, "ImPlot_CalculateBins_U8Ptr");			vt.Load(703, "ImPlot_CalculateBins_S16Ptr");			vt.Load(704, "ImPlot_CalculateBins_U16Ptr");			vt.Load(705, "ImPlot_CalculateBins_S32Ptr");			vt.Load(706, "ImPlot_CalculateBins_U32Ptr");			vt.Load(707, "ImPlot_CalculateBins_S64Ptr");			vt.Load(708, "ImPlot_CalculateBins_U64Ptr");			vt.Load(709, "ImPlot_IsLeapYear");			vt.Load(710, "ImPlot_GetDaysInMonth");			vt.Load(711, "ImPlot_MkGmtTime");			vt.Load(712, "ImPlot_GetGmtTime");			vt.Load(713, "ImPlot_MkLocTime");			vt.Load(714, "ImPlot_GetLocTime");			vt.Load(715, "ImPlot_MakeTime");			vt.Load(716, "ImPlot_GetYear");			vt.Load(717, "ImPlot_AddTime");			vt.Load(718, "ImPlot_FloorTime");			vt.Load(719, "ImPlot_CeilTime");			vt.Load(720, "ImPlot_RoundTime");			vt.Load(721, "ImPlot_CombineDateTime");			vt.Load(722, "ImPlot_FormatTime");			vt.Load(723, "ImPlot_FormatDate");			vt.Load(724, "ImPlot_FormatDateTime");			vt.Load(725, "ImPlot_ShowDatePicker");			vt.Load(726, "ImPlot_ShowTimePicker");			vt.Load(727, "ImPlot_TransformForward_Log10");			vt.Load(728, "ImPlot_TransformInverse_Log10");			vt.Load(729, "ImPlot_TransformForward_SymLog");			vt.Load(730, "ImPlot_TransformInverse_SymLog");			vt.Load(731, "ImPlot_TransformForward_Logit");			vt.Load(732, "ImPlot_TransformInverse_Logit");			vt.Load(733, "ImPlot_Formatter_Default");			vt.Load(734, "ImPlot_Formatter_Logit");			vt.Load(735, "ImPlot_Formatter_Time");			vt.Load(736, "ImPlot_Locator_Default");			vt.Load(737, "ImPlot_Locator_Time");			vt.Load(738, "ImPlot_Locator_Log10");			vt.Load(739, "ImPlot_Locator_SymLog");		}

		public static void FreeApi()
		{
			vt.Free();
		}
	}
}
