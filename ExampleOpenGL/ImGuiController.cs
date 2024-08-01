using System.Numerics;
using System.Runtime.InteropServices;
using Hexa.NET.ImGui;
using Hexa.NET.ImGuizmo;
using Hexa.NET.ImNodes;
using Hexa.NET.ImPlot;

namespace ExampleOpenGL;

internal unsafe class ImGuiController : DisposableObject
{
    private readonly Window _window;
    private readonly ImGuiContextPtr _imGuiContext;
    private readonly ImPlotContextPtr _imPlotContext;
    private readonly ImNodesContextPtr _imNodesContext;
    private readonly ImGuiFontConfig _imGuiFontConfig;
    private readonly ImGuiSizeConfig _imGuiSizeConfig;
    private readonly Dictionary<float, ImFontPtr> _dpiScaleFonts;
    private readonly Dictionary<float, ImGuiSizeConfig> _dpiScaleSizes;
    private readonly List<ImGuiPlatform> _platforms;
    private readonly Dictionary<nint, ImGuiPlatform> _platformsByHandle;

    private readonly PlatformCreateWindow _createWindow;
    private readonly PlatformDestroyWindow _destroyWindow;
    private readonly PlatformShowWindow _showWindow;
    private readonly PlatformGetWindowPos _getWindowPos;
    private readonly PlatformSetWindowPos _setWindowPos;
    private readonly PlatformGetWindowSize _getWindowSize;
    private readonly PlatformSetWindowSize _setWindowSize;
    private readonly PlatformGetWindowFocus _getWindowFocus;
    private readonly PlatformSetWindowFocus _setWindowFocus;
    private readonly PlatformGetWindowMinimized _getWindowMinimized;
    private readonly PlatformSetWindowTitle _setWindowTitle;
    private readonly PlatformSetWindowAlpha _setWindowAlpha;
    private readonly PlatformUpdateWindow _updateWindow;
    private readonly PlatformRenderWindow _renderWindow;
    private readonly PlatformOnChangedViewport _onChangedViewport;

    private bool _frameBegun;

    #region Constructors
    public ImGuiController(Window window,
                           ImGuiFontConfig imGuiFontConfig,
                           ImGuiSizeConfig imGuiSizeConfig,
                           Action? onConfigureIO)
    {
        _window = window;
        _imGuiContext = ImGui.CreateContext();
        _imPlotContext = ImPlot.CreateContext();
        _imNodesContext = ImNodes.CreateContext();
        _imGuiFontConfig = imGuiFontConfig;
        _imGuiSizeConfig = imGuiSizeConfig;
        _dpiScaleFonts = [];
        _dpiScaleSizes = [];
        _platforms = [];
        _platformsByHandle = [];

        _createWindow = CreateWindow;
        _destroyWindow = DestroyWindow;
        _showWindow = ShowWindow;
        _getWindowPos = GetWindowPos;
        _setWindowPos = SetWindowPos;
        _getWindowSize = GetWindowSize;
        _setWindowSize = SetWindowSize;
        _getWindowFocus = GetWindowFocus;
        _setWindowFocus = SetWindowFocus;
        _getWindowMinimized = GetWindowMinimized;
        _setWindowTitle = SetWindowTitle;
        _setWindowAlpha = SetWindowAlpha;
        _updateWindow = UpdateWindow;
        _renderWindow = RenderWindow;
        _onChangedViewport = OnChangedViewport;

        Initialize(onConfigureIO);
    }

    public ImGuiController(Window window,
                           ImGuiFontConfig imGuiFontConfig,
                           ImGuiSizeConfig imGuiSizeConfig) : this(window,
                                                                   imGuiFontConfig,
                                                                   imGuiSizeConfig,
                                                                   null)
    {
    }

    public ImGuiController(Window window,
                           ImGuiFontConfig imGuiFontConfig) : this(window,
                                                                   imGuiFontConfig,
                                                                   ImGuiSizeConfig.Default,
                                                                   null)
    {
    }
    #endregion

    public void Update(float deltaSeconds)
    {
        if (_frameBegun)
        {
            ImGui.Render();
        }

        ImGui.SetCurrentContext(_imGuiContext);
        ImPlot.SetCurrentContext(_imPlotContext);
        ImNodes.SetCurrentContext(_imNodesContext);

        ImPlot.SetImGuiContext(_imGuiContext);
        ImNodes.SetImGuiContext(_imGuiContext);
        ImGuizmo.SetImGuiContext(_imGuiContext);

        SetPerFrameImGuiData(deltaSeconds);

        UpdateMouseState();

        ImGui.NewFrame();
        ImGuizmo.BeginFrame();

        ImGui.DockSpaceOverViewport();

        _frameBegun = true;
    }

    public void Render()
    {
        if (_frameBegun)
        {
            ImGui.Render();

            _platformsByHandle[(nint)ImGui.GetMainViewport().PlatformHandle].Render();

            ImGui.UpdatePlatformWindows();
            ImGui.RenderPlatformWindowsDefault();

            _frameBegun = false;
        }
    }

    protected override void Destroy()
    {
        foreach (ImGuiPlatform platform in _platforms)
        {
            platform.Dispose();
        }

        ImNodes.DestroyContext(_imNodesContext);
        ImPlot.DestroyContext(_imPlotContext);
        ImGui.DestroyContext(_imGuiContext);
    }

    private void SetPerFrameImGuiData(float deltaSeconds)
    {
        ImGuiIOPtr io = ImGui.GetIO();

        io.DisplaySize = _window.FramebufferSize;
        io.DisplayFramebufferScale = _window.FramebufferSize / _window.Size;

        io.DeltaTime = deltaSeconds;
    }

    private static void UpdateMouseState()
    {
        if (Window.IsMouseFocusOnWindow())
        {
            ImGuiIOPtr io = ImGui.GetIO();

            MouseButton[] mouseButtons = Window.GetGlobalMouseState(out Vector2 position);

            io.AddMouseButtonEvent(0, mouseButtons.Contains(MouseButton.Left));
            io.AddMouseButtonEvent(1, mouseButtons.Contains(MouseButton.Right));
            io.AddMouseButtonEvent(2, mouseButtons.Contains(MouseButton.Middle));
            io.AddMouseButtonEvent(3, mouseButtons.Contains(MouseButton.Button4));
            io.AddMouseButtonEvent(4, mouseButtons.Contains(MouseButton.Button5));

            io.AddMousePosEvent(position.X, position.Y);
        }
    }

    private void Initialize(Action? onConfigureIO)
    {
        ImGui.SetCurrentContext(_imGuiContext);
        ImPlot.SetCurrentContext(_imPlotContext);
        ImNodes.SetCurrentContext(_imNodesContext);

        ImPlot.SetImGuiContext(_imGuiContext);
        ImNodes.SetImGuiContext(_imGuiContext);
        ImGuizmo.SetImGuiContext(_imGuiContext);

        ImGui.StyleColorsDark();

        ImGuiIOPtr io = ImGui.GetIO();

        io.Fonts.Clear();

        io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

        onConfigureIO?.Invoke();

        io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors;
        io.BackendFlags |= ImGuiBackendFlags.HasSetMousePos;
        io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset;
        io.BackendFlags |= ImGuiBackendFlags.PlatformHasViewports;
        io.BackendFlags |= ImGuiBackendFlags.RendererHasViewports;

        InitializePlatform();
    }

    private void InitializePlatform()
    {
        InitializePlatformDpiScale();

        ImGuiViewportPtr mainViewport = ImGui.GetMainViewport();
        ImGuiPlatform mainPlatform = new(mainViewport, _window);

        _platformsByHandle.Add((nint)mainViewport.PlatformHandle, mainPlatform);

        InitializePlatformMonitors();
        InitializePlatformCallbacks();
    }

    private void InitializePlatformDpiScale()
    {
        ImGuiIOPtr io = ImGui.GetIO();

        int displayCount = Window.GetDisplayCount();

        for (int i = 0; i < displayCount; i++)
        {
            Display display = Window.GetDisplay(i);

            nint glyph_ranges = _imGuiFontConfig.GetGlyphRange?.Invoke(io) ?? 0;
            ImFontPtr fontPtr = io.Fonts.AddFontFromFileTTF(_imGuiFontConfig.FontPath, Convert.ToInt32(_imGuiFontConfig.FontSize * display.DpiScale), null, (char*)glyph_ranges);

            _dpiScaleFonts.Add(display.DpiScale, fontPtr);

            ImGuiSizeConfig sizeConfig = _imGuiSizeConfig.Scale(display.DpiScale);

            _dpiScaleSizes.Add(display.DpiScale, sizeConfig);
        }

        byte* pixels;
        int width;
        int height;
        io.Fonts.GetTexDataAsRGBA32(&pixels, &width, &height);
    }

    private void InitializePlatformMonitors()
    {
        ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();

        int displayCount = Window.GetDisplayCount();

        platformIO.Monitors.Size = displayCount;
        platformIO.Monitors.Capacity = displayCount;
        platformIO.Monitors.Data = (ImGuiPlatformMonitor*)Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiPlatformMonitor>() * displayCount);

        for (int i = 0; i < displayCount; i++)
        {
            Display display = Window.GetDisplay(i);

            ImGuiPlatformMonitor monitor = new()
            {
                MainPos = display.MainPosition,
                MainSize = display.MainSize,
                WorkPos = display.WorkPosition,
                WorkSize = display.WorkSize,
                DpiScale = display.DpiScale
            };

            platformIO.Monitors.Data[i] = monitor;
        }
    }

    private void InitializePlatformCallbacks()
    {
        ImGuiPlatformIOPtr platformIO = ImGui.GetPlatformIO();

        platformIO.PlatformCreateWindow = (void*)Marshal.GetFunctionPointerForDelegate(_createWindow);
        platformIO.PlatformDestroyWindow = (void*)Marshal.GetFunctionPointerForDelegate(_destroyWindow);
        platformIO.PlatformShowWindow = (void*)Marshal.GetFunctionPointerForDelegate(_showWindow);
        platformIO.PlatformGetWindowPos = (void*)Marshal.GetFunctionPointerForDelegate(_getWindowPos);
        platformIO.PlatformSetWindowPos = (void*)Marshal.GetFunctionPointerForDelegate(_setWindowPos);
        platformIO.PlatformGetWindowSize = (void*)Marshal.GetFunctionPointerForDelegate(_getWindowSize);
        platformIO.PlatformSetWindowSize = (void*)Marshal.GetFunctionPointerForDelegate(_setWindowSize);
        platformIO.PlatformGetWindowFocus = (void*)Marshal.GetFunctionPointerForDelegate(_getWindowFocus);
        platformIO.PlatformSetWindowFocus = (void*)Marshal.GetFunctionPointerForDelegate(_setWindowFocus);
        platformIO.PlatformGetWindowMinimized = (void*)Marshal.GetFunctionPointerForDelegate(_getWindowMinimized);
        platformIO.PlatformSetWindowTitle = (void*)Marshal.GetFunctionPointerForDelegate(_setWindowTitle);
        platformIO.PlatformSetWindowAlpha = (void*)Marshal.GetFunctionPointerForDelegate(_setWindowAlpha);
        platformIO.PlatformUpdateWindow = (void*)Marshal.GetFunctionPointerForDelegate(_updateWindow);
        platformIO.PlatformRenderWindow = (void*)Marshal.GetFunctionPointerForDelegate(_renderWindow);
        platformIO.PlatformOnChangedViewport = (void*)Marshal.GetFunctionPointerForDelegate(_onChangedViewport);
    }

    private void CreateWindow(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = new(vp);

        _platforms.Add(platform);
        _platformsByHandle.Add((nint)vp->PlatformHandle, platform);
    }

    private void DestroyWindow(ImGuiViewport* vp)
    {
        if (vp->PlatformHandle == null)
        {
            return;
        }

        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        _platforms.Remove(platform);
        _platformsByHandle.Remove((nint)vp->PlatformHandle);

        platform.Dispose();
    }

    private void ShowWindow(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Show();
    }

    private Vector2* GetWindowPos(Vector2* pos, ImGuiViewport* viewport)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)viewport->PlatformHandle];

        *pos = platform.Position;

        return pos;
    }

    private void SetWindowPos(ImGuiViewport* vp, Vector2 pos)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Position = pos;
    }

    private Vector2* GetWindowSize(Vector2* size, ImGuiViewport* viewport)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)viewport->PlatformHandle];

        *size = platform.Size;

        return size;
    }

    private void SetWindowSize(ImGuiViewport* vp, Vector2 size)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Size = size;
    }

    private byte GetWindowFocus(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        return platform.IsFocused;
    }

    private void SetWindowFocus(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Focus();
    }

    private byte GetWindowMinimized(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        return platform.IsMinimized;
    }

    private void SetWindowTitle(ImGuiViewport* vp, byte* str)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Title = Marshal.PtrToStringAnsi((nint)str)!;
    }

    private void SetWindowAlpha(ImGuiViewport* vp, float alpha)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Alpha = alpha;
    }

    private void UpdateWindow(ImGuiViewport* vp)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Update();
    }

    private void RenderWindow(ImGuiViewport* vp, void* renderArgs)
    {
        ImGuiPlatform platform = _platformsByHandle[(nint)vp->PlatformHandle];

        platform.Render();
    }

    private void OnChangedViewport(ImGuiViewport* vp)
    {
        _dpiScaleSizes[vp->DpiScale].Apply(ImGui.GetStyle());

        ImGui.SetCurrentFont(_dpiScaleFonts[vp->DpiScale]);
    }
}
