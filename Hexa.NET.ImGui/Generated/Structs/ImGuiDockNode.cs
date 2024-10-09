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

namespace Hexa.NET.ImGui
{
	/// <summary>
	/// sizeof() 156~192<br/>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ImGuiDockNode
	{
		/// <summary>
		/// To be documented.
		/// </summary>
		public uint ID;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDockNodeFlags SharedFlags;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDockNodeFlags LocalFlags;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDockNodeFlags LocalFlagsInWindows;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDockNodeFlags MergedFlags;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDockNodeState State;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode* ParentNode;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode* ChildNodes_0;
		public unsafe ImGuiDockNode* ChildNodes_1;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImVector<ImGuiWindowPtr> Windows;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiTabBar* TabBar;

		/// <summary>
		/// To be documented.
		/// </summary>
		public Vector2 Pos;

		/// <summary>
		/// To be documented.
		/// </summary>
		public Vector2 Size;

		/// <summary>
		/// To be documented.
		/// </summary>
		public Vector2 SizeRef;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiAxis SplitAxis;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiWindowClass WindowClass;

		/// <summary>
		/// To be documented.
		/// </summary>
		public uint LastBgColor;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiWindow* HostWindow;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiWindow* VisibleWindow;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode* CentralNode;

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode* OnlyNodeWithWindows;

		/// <summary>
		/// To be documented.
		/// </summary>
		public int CountNodeWithWindows;

		/// <summary>
		/// To be documented.
		/// </summary>
		public int LastFrameAlive;

		/// <summary>
		/// To be documented.
		/// </summary>
		public int LastFrameActive;

		/// <summary>
		/// To be documented.
		/// </summary>
		public int LastFrameFocused;

		/// <summary>
		/// To be documented.
		/// </summary>
		public uint LastFocusedNodeId;

		/// <summary>
		/// To be documented.
		/// </summary>
		public uint SelectedTabId;

		/// <summary>
		/// To be documented.
		/// </summary>
		public uint WantCloseTabId;

		/// <summary>
		/// To be documented.
		/// </summary>
		public uint RefViewportId;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDataAuthority AuthorityForPos;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDataAuthority AuthorityForSize;

		/// <summary>
		/// To be documented.
		/// </summary>
		public ImGuiDataAuthority AuthorityForViewport;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte IsVisible;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte IsFocused;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte IsBgDrawnThisFrame;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte HasCloseButton;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte HasWindowMenuButton;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte HasCentralNodeChild;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte WantCloseAll;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte WantLockSizeOnce;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte WantMouseMove;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte WantHiddenTabBarUpdate;

		/// <summary>
		/// To be documented.
		/// </summary>
		public byte WantHiddenTabBarToggle;


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode(uint id = default, ImGuiDockNodeFlags sharedFlags = default, ImGuiDockNodeFlags localFlags = default, ImGuiDockNodeFlags localFlagsInWindows = default, ImGuiDockNodeFlags mergedFlags = default, ImGuiDockNodeState state = default, ImGuiDockNode* parentNode = default, ImGuiDockNode** childNodes = default, ImVector<ImGuiWindowPtr> windows = default, ImGuiTabBar* tabBar = default, Vector2 pos = default, Vector2 size = default, Vector2 sizeRef = default, ImGuiAxis splitAxis = default, ImGuiWindowClass windowClass = default, uint lastBgColor = default, ImGuiWindowPtr hostWindow = default, ImGuiWindowPtr visibleWindow = default, ImGuiDockNode* centralNode = default, ImGuiDockNode* onlyNodeWithWindows = default, int countNodeWithWindows = default, int lastFrameAlive = default, int lastFrameActive = default, int lastFrameFocused = default, uint lastFocusedNodeId = default, uint selectedTabId = default, uint wantCloseTabId = default, uint refViewportId = default, ImGuiDataAuthority authorityForPos = default, ImGuiDataAuthority authorityForSize = default, ImGuiDataAuthority authorityForViewport = default, bool isVisible = default, bool isFocused = default, bool isBgDrawnThisFrame = default, bool hasCloseButton = default, bool hasWindowMenuButton = default, bool hasCentralNodeChild = default, bool wantCloseAll = default, bool wantLockSizeOnce = default, bool wantMouseMove = default, bool wantHiddenTabBarUpdate = default, bool wantHiddenTabBarToggle = default)
		{
			ID = id;
			SharedFlags = sharedFlags;
			LocalFlags = localFlags;
			LocalFlagsInWindows = localFlagsInWindows;
			MergedFlags = mergedFlags;
			State = state;
			ParentNode = parentNode;
			if (childNodes != default(ImGuiDockNode**))
			{
				ChildNodes_0 = childNodes[0];
				ChildNodes_1 = childNodes[1];
			}
			Windows = windows;
			TabBar = tabBar;
			Pos = pos;
			Size = size;
			SizeRef = sizeRef;
			SplitAxis = splitAxis;
			WindowClass = windowClass;
			LastBgColor = lastBgColor;
			HostWindow = hostWindow;
			VisibleWindow = visibleWindow;
			CentralNode = centralNode;
			OnlyNodeWithWindows = onlyNodeWithWindows;
			CountNodeWithWindows = countNodeWithWindows;
			LastFrameAlive = lastFrameAlive;
			LastFrameActive = lastFrameActive;
			LastFrameFocused = lastFrameFocused;
			LastFocusedNodeId = lastFocusedNodeId;
			SelectedTabId = selectedTabId;
			WantCloseTabId = wantCloseTabId;
			RefViewportId = refViewportId;
			AuthorityForPos = authorityForPos;
			AuthorityForSize = authorityForSize;
			AuthorityForViewport = authorityForViewport;
			IsVisible = isVisible ? (byte)1 : (byte)0;
			IsFocused = isFocused ? (byte)1 : (byte)0;
			IsBgDrawnThisFrame = isBgDrawnThisFrame ? (byte)1 : (byte)0;
			HasCloseButton = hasCloseButton ? (byte)1 : (byte)0;
			HasWindowMenuButton = hasWindowMenuButton ? (byte)1 : (byte)0;
			HasCentralNodeChild = hasCentralNodeChild ? (byte)1 : (byte)0;
			WantCloseAll = wantCloseAll ? (byte)1 : (byte)0;
			WantLockSizeOnce = wantLockSizeOnce ? (byte)1 : (byte)0;
			WantMouseMove = wantMouseMove ? (byte)1 : (byte)0;
			WantHiddenTabBarUpdate = wantHiddenTabBarUpdate ? (byte)1 : (byte)0;
			WantHiddenTabBarToggle = wantHiddenTabBarToggle ? (byte)1 : (byte)0;
		}

		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe ImGuiDockNode(uint id = default, ImGuiDockNodeFlags sharedFlags = default, ImGuiDockNodeFlags localFlags = default, ImGuiDockNodeFlags localFlagsInWindows = default, ImGuiDockNodeFlags mergedFlags = default, ImGuiDockNodeState state = default, ImGuiDockNode* parentNode = default, Span<Pointer<ImGuiDockNode>> childNodes = default, ImVector<ImGuiWindowPtr> windows = default, ImGuiTabBar* tabBar = default, Vector2 pos = default, Vector2 size = default, Vector2 sizeRef = default, ImGuiAxis splitAxis = default, ImGuiWindowClass windowClass = default, uint lastBgColor = default, ImGuiWindowPtr hostWindow = default, ImGuiWindowPtr visibleWindow = default, ImGuiDockNode* centralNode = default, ImGuiDockNode* onlyNodeWithWindows = default, int countNodeWithWindows = default, int lastFrameAlive = default, int lastFrameActive = default, int lastFrameFocused = default, uint lastFocusedNodeId = default, uint selectedTabId = default, uint wantCloseTabId = default, uint refViewportId = default, ImGuiDataAuthority authorityForPos = default, ImGuiDataAuthority authorityForSize = default, ImGuiDataAuthority authorityForViewport = default, bool isVisible = default, bool isFocused = default, bool isBgDrawnThisFrame = default, bool hasCloseButton = default, bool hasWindowMenuButton = default, bool hasCentralNodeChild = default, bool wantCloseAll = default, bool wantLockSizeOnce = default, bool wantMouseMove = default, bool wantHiddenTabBarUpdate = default, bool wantHiddenTabBarToggle = default)
		{
			ID = id;
			SharedFlags = sharedFlags;
			LocalFlags = localFlags;
			LocalFlagsInWindows = localFlagsInWindows;
			MergedFlags = mergedFlags;
			State = state;
			ParentNode = parentNode;
			if (childNodes != default(Span<Pointer<ImGuiDockNode>>))
			{
				ChildNodes_0 = childNodes[0];
				ChildNodes_1 = childNodes[1];
			}
			Windows = windows;
			TabBar = tabBar;
			Pos = pos;
			Size = size;
			SizeRef = sizeRef;
			SplitAxis = splitAxis;
			WindowClass = windowClass;
			LastBgColor = lastBgColor;
			HostWindow = hostWindow;
			VisibleWindow = visibleWindow;
			CentralNode = centralNode;
			OnlyNodeWithWindows = onlyNodeWithWindows;
			CountNodeWithWindows = countNodeWithWindows;
			LastFrameAlive = lastFrameAlive;
			LastFrameActive = lastFrameActive;
			LastFrameFocused = lastFrameFocused;
			LastFocusedNodeId = lastFocusedNodeId;
			SelectedTabId = selectedTabId;
			WantCloseTabId = wantCloseTabId;
			RefViewportId = refViewportId;
			AuthorityForPos = authorityForPos;
			AuthorityForSize = authorityForSize;
			AuthorityForViewport = authorityForViewport;
			IsVisible = isVisible ? (byte)1 : (byte)0;
			IsFocused = isFocused ? (byte)1 : (byte)0;
			IsBgDrawnThisFrame = isBgDrawnThisFrame ? (byte)1 : (byte)0;
			HasCloseButton = hasCloseButton ? (byte)1 : (byte)0;
			HasWindowMenuButton = hasWindowMenuButton ? (byte)1 : (byte)0;
			HasCentralNodeChild = hasCentralNodeChild ? (byte)1 : (byte)0;
			WantCloseAll = wantCloseAll ? (byte)1 : (byte)0;
			WantLockSizeOnce = wantLockSizeOnce ? (byte)1 : (byte)0;
			WantMouseMove = wantMouseMove ? (byte)1 : (byte)0;
			WantHiddenTabBarUpdate = wantHiddenTabBarUpdate ? (byte)1 : (byte)0;
			WantHiddenTabBarToggle = wantHiddenTabBarToggle ? (byte)1 : (byte)0;
		}


		/// <summary>
		/// To be documented.
		/// </summary>
		public unsafe Span<Pointer<ImGuiDockNode>> ChildNodes
		
		{
			get
			{
				fixed (ImGuiDockNode** p = &this.ChildNodes_0)
				{
					return new Span<Pointer<ImGuiDockNode>>(p, 2);
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
	public unsafe struct ImGuiDockNodePtr : IEquatable<ImGuiDockNodePtr>
	{
		public ImGuiDockNodePtr(ImGuiDockNode* handle) { Handle = handle; }

		public ImGuiDockNode* Handle;

		public bool IsNull => Handle == null;

		public static ImGuiDockNodePtr Null => new ImGuiDockNodePtr(null);

		public ImGuiDockNode this[int index] { get => Handle[index]; set => Handle[index] = value; }

		public static implicit operator ImGuiDockNodePtr(ImGuiDockNode* handle) => new ImGuiDockNodePtr(handle);

		public static implicit operator ImGuiDockNode*(ImGuiDockNodePtr handle) => handle.Handle;

		public static bool operator ==(ImGuiDockNodePtr left, ImGuiDockNodePtr right) => left.Handle == right.Handle;

		public static bool operator !=(ImGuiDockNodePtr left, ImGuiDockNodePtr right) => left.Handle != right.Handle;

		public static bool operator ==(ImGuiDockNodePtr left, ImGuiDockNode* right) => left.Handle == right;

		public static bool operator !=(ImGuiDockNodePtr left, ImGuiDockNode* right) => left.Handle != right;

		public bool Equals(ImGuiDockNodePtr other) => Handle == other.Handle;

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ImGuiDockNodePtr handle && Equals(handle);

		/// <inheritdoc/>
		public override int GetHashCode() => ((nuint)Handle).GetHashCode();

		#if NET5_0_OR_GREATER
		private string DebuggerDisplay => string.Format("ImGuiDockNodePtr [0x{0}]", ((nuint)Handle).ToString("X"));
		#endif
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint ID => ref Unsafe.AsRef<uint>(&Handle->ID);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodeFlags SharedFlags => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&Handle->SharedFlags);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodeFlags LocalFlags => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&Handle->LocalFlags);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodeFlags LocalFlagsInWindows => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&Handle->LocalFlagsInWindows);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodeFlags MergedFlags => ref Unsafe.AsRef<ImGuiDockNodeFlags>(&Handle->MergedFlags);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodeState State => ref Unsafe.AsRef<ImGuiDockNodeState>(&Handle->State);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodePtr ParentNode => ref Unsafe.AsRef<ImGuiDockNodePtr>(&Handle->ParentNode);
		/// <summary>
		/// To be documented.
		/// </summary>
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImVector<ImGuiWindowPtr> Windows => ref Unsafe.AsRef<ImVector<ImGuiWindowPtr>>(&Handle->Windows);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiTabBarPtr TabBar => ref Unsafe.AsRef<ImGuiTabBarPtr>(&Handle->TabBar);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref Vector2 Pos => ref Unsafe.AsRef<Vector2>(&Handle->Pos);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref Vector2 Size => ref Unsafe.AsRef<Vector2>(&Handle->Size);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref Vector2 SizeRef => ref Unsafe.AsRef<Vector2>(&Handle->SizeRef);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiAxis SplitAxis => ref Unsafe.AsRef<ImGuiAxis>(&Handle->SplitAxis);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiWindowClass WindowClass => ref Unsafe.AsRef<ImGuiWindowClass>(&Handle->WindowClass);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint LastBgColor => ref Unsafe.AsRef<uint>(&Handle->LastBgColor);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiWindowPtr HostWindow => ref Unsafe.AsRef<ImGuiWindowPtr>(&Handle->HostWindow);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiWindowPtr VisibleWindow => ref Unsafe.AsRef<ImGuiWindowPtr>(&Handle->VisibleWindow);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodePtr CentralNode => ref Unsafe.AsRef<ImGuiDockNodePtr>(&Handle->CentralNode);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDockNodePtr OnlyNodeWithWindows => ref Unsafe.AsRef<ImGuiDockNodePtr>(&Handle->OnlyNodeWithWindows);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref int CountNodeWithWindows => ref Unsafe.AsRef<int>(&Handle->CountNodeWithWindows);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref int LastFrameAlive => ref Unsafe.AsRef<int>(&Handle->LastFrameAlive);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref int LastFrameActive => ref Unsafe.AsRef<int>(&Handle->LastFrameActive);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref int LastFrameFocused => ref Unsafe.AsRef<int>(&Handle->LastFrameFocused);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint LastFocusedNodeId => ref Unsafe.AsRef<uint>(&Handle->LastFocusedNodeId);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint SelectedTabId => ref Unsafe.AsRef<uint>(&Handle->SelectedTabId);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint WantCloseTabId => ref Unsafe.AsRef<uint>(&Handle->WantCloseTabId);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref uint RefViewportId => ref Unsafe.AsRef<uint>(&Handle->RefViewportId);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDataAuthority AuthorityForPos => ref Unsafe.AsRef<ImGuiDataAuthority>(&Handle->AuthorityForPos);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDataAuthority AuthorityForSize => ref Unsafe.AsRef<ImGuiDataAuthority>(&Handle->AuthorityForSize);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref ImGuiDataAuthority AuthorityForViewport => ref Unsafe.AsRef<ImGuiDataAuthority>(&Handle->AuthorityForViewport);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool IsVisible => ref Unsafe.AsRef<bool>(&Handle->IsVisible);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool IsFocused => ref Unsafe.AsRef<bool>(&Handle->IsFocused);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool IsBgDrawnThisFrame => ref Unsafe.AsRef<bool>(&Handle->IsBgDrawnThisFrame);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool HasCloseButton => ref Unsafe.AsRef<bool>(&Handle->HasCloseButton);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool HasWindowMenuButton => ref Unsafe.AsRef<bool>(&Handle->HasWindowMenuButton);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool HasCentralNodeChild => ref Unsafe.AsRef<bool>(&Handle->HasCentralNodeChild);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool WantCloseAll => ref Unsafe.AsRef<bool>(&Handle->WantCloseAll);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool WantLockSizeOnce => ref Unsafe.AsRef<bool>(&Handle->WantLockSizeOnce);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool WantMouseMove => ref Unsafe.AsRef<bool>(&Handle->WantMouseMove);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool WantHiddenTabBarUpdate => ref Unsafe.AsRef<bool>(&Handle->WantHiddenTabBarUpdate);
		/// <summary>
		/// To be documented.
		/// </summary>
		public ref bool WantHiddenTabBarToggle => ref Unsafe.AsRef<bool>(&Handle->WantHiddenTabBarToggle);
	}

}
