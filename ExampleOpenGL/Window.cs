using System.Numerics;
using Silk.NET.GLFW;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.SDL;
using Silk.NET.Windowing;
using Monitor = Silk.NET.GLFW.Monitor;

namespace ExampleOpenGL;

internal unsafe class Window : DisposableObject
{
    private static List<IWindow> _windows = [];
    private static Glfw? _glfw;
    private static Sdl? _sdl;

    private readonly IWindow _window;
    private readonly GL _gl;

    public event Action? Load;
    public event Action<double>? Update;
    public event Action<double>? Render;

    public Window()
    {
        WindowOptions options = WindowOptions.Default;

        _window = SilkWindow.Create(options);
        _window.Load += () => Load?.Invoke();
        _window.Update += delta => Update?.Invoke(delta);
        _window.Render += delta => Render?.Invoke(delta);

        _window.Initialize();

        _windows.Add(_window);
        IsGlfwWindow(_window);
        IsSdlWindow(_window);

        _gl = _window.CreateOpenGL();
    }

    public GL GL => _gl;

    public string Title
    {
        get => _window.Title;
        set => _window.Title = value;
    }

    public Vector2 Position
    {
        get => new(_window.Position.X, _window.Position.Y);
        set => _window.Position = new Vector2D<int>((int)value.X, (int)value.Y);
    }

    public Vector2 Size
    {
        get => new(_window.Size.X, _window.Size.Y);
        set => _window.Size = new Vector2D<int>((int)value.X, (int)value.Y);
    }

    public Vector2 FramebufferSize
    {
        get => new(_window.FramebufferSize.X, _window.FramebufferSize.Y);
    }

    public float DpiScale
    {
        get
        {
            float displayDpi = 96.0f;

            if (IsGlfwWindow(_window))
            {
                Monitor** monitors = _glfw!.GetMonitors(out int displayCount);

                _glfw.GetWindowPos((GlfwWindow*)_window.Handle, out int windowX, out int windowY);
                _glfw.GetWindowSize((GlfwWindow*)_window.Handle, out int windowWidth, out int windowHeight);

                int windowCenterX = windowX + windowWidth / 2;
                int windowCenterY = windowY + windowHeight / 2;

                for (int i = 0; i < displayCount; i++)
                {
                    _glfw.GetMonitorWorkarea(monitors[i], out int monitorX, out int monitorY, out int monitorWidth, out int monitorHeight);

                    if (windowCenterX >= monitorX && windowCenterX < monitorX + monitorWidth &&
                        windowCenterY >= monitorY && windowCenterY < monitorY + monitorHeight)
                    {
                        _glfw.GetMonitorContentScale(monitors[i], out float xScale, out float yScale);

                        displayDpi = MathF.Max(xScale, yScale) * 96.0f;

                        break;
                    }
                }
            }
            else if (IsSdlWindow(_window))
            {
                int displayIndex = _sdl!.GetWindowDisplayIndex((SdlWindow*)_window.Handle);

                _sdl.GetDisplayDPI(displayIndex, &displayDpi, null, null);
            }

            return displayDpi / 96.0f;
        }
    }

    public WindowState WindowState
    {
        get => _window.WindowState;
        set => _window.WindowState = value;
    }

    public WindowBorder WindowBorder
    {
        get => _window.WindowBorder;
        set => _window.WindowBorder = value;
    }

    public bool TopMost
    {
        get => _window.TopMost;
        set => _window.TopMost = value;
    }

    public bool IsFocused
    {
        get
        {
            bool isFocused = false;

            if (IsGlfwWindow(_window))
            {
                isFocused = _glfw!.GetWindowAttrib((GlfwWindow*)_window.Handle, WindowAttributeGetter.Focused);
            }
            else if (IsSdlWindow(_window))
            {
                WindowFlags windowFlags = (WindowFlags)_sdl!.GetWindowFlags((SdlWindow*)_window.Handle);

                return windowFlags.HasFlag(WindowFlags.InputFocus);
            }

            return isFocused;
        }
    }

    public float Opacity
    {
        get
        {
            float opacity = 0;

            if (IsGlfwWindow(_window))
            {
                opacity = _glfw!.GetWindowOpacity((GlfwWindow*)_window.Handle);
            }
            else if (IsSdlWindow(_window))
            {
                _sdl!.GetWindowOpacity((SdlWindow*)_window.Handle, &opacity);
            }

            return opacity;
        }
        set
        {
            if (IsGlfwWindow(_window))
            {
                _glfw!.SetWindowOpacity((GlfwWindow*)_window.Handle, value);
            }
            else if (IsSdlWindow(_window))
            {
                _sdl!.SetWindowOpacity((SdlWindow*)_window.Handle, value);
            }
        }
    }

    public void Run()
    {
        _window.Run();
    }

    public void Focus()
    {
        if (IsGlfwWindow(_window))
        {
            _glfw!.FocusWindow((GlfwWindow*)_window.Handle);
        }
        else if (IsSdlWindow(_window))
        {
            _sdl!.RaiseWindow((SdlWindow*)_window.Handle);
        }
    }

    public static bool IsMouseFocusOnWindow()
    {
        if (_glfw != null)
        {
            foreach (IWindow window in _windows)
            {
                _glfw.GetCursorPos((GlfwWindow*)window.Handle, out double mouseX, out double mouseY);

                if (mouseX >= 0 && mouseX < window.Size.X && mouseY >= 0 && mouseY < window.Size.Y)
                {
                    return true;
                }
            }
        }

        if (_sdl != null)
        {
            return _sdl.GetMouseFocus() != null;
        }

        return false;
    }

    public static MouseButton[] GetGlobalMouseState(out Vector2 position)
    {
        position = Vector2.Zero;

        if (_glfw != null)
        {
            Dictionary<MouseButton, int> buttonMasks = new()
            {
                { MouseButton.Left, 0 },
                { MouseButton.Right, 1 },
                { MouseButton.Middle, 2 },
                { MouseButton.Button4, 3 },
                { MouseButton.Button5, 4 }
            };

            foreach (IWindow window in _windows)
            {
                _glfw.GetWindowPos((GlfwWindow*)window.Handle, out int windowX, out int windowY);
                _glfw.GetCursorPos((GlfwWindow*)window.Handle, out double mouseX, out double mouseY);

                position = new Vector2(windowX + (float)mouseX, windowY + (float)mouseY);

                List<MouseButton> buttons = [];
                foreach (KeyValuePair<MouseButton, int> buttonMask in buttonMasks)
                {
                    if ((InputAction)_glfw.GetMouseButton((GlfwWindow*)window.Handle, buttonMask.Value) == InputAction.Press)
                    {
                        buttons.Add(buttonMask.Key);
                    }
                }

                if (buttons.Count > 0)
                {
                    return [.. buttons];
                }
            }
        }

        if (_sdl != null)
        {
            Dictionary<MouseButton, int> buttonMasks = new()
            {
                { MouseButton.Left, 1 },
                { MouseButton.Middle, 2 },
                { MouseButton.Right, 3 },
                { MouseButton.Button4, 4 },
                { MouseButton.Button5, 5 }
            };

            int x, y;
            uint mask = _sdl.GetGlobalMouseState(&x, &y);

            position = new Vector2(x, y);

            List<MouseButton> buttons = [];
            foreach (KeyValuePair<MouseButton, int> buttonMask in buttonMasks)
            {
                if ((mask & (1 << (buttonMask.Value - 1))) != 0)
                {
                    buttons.Add(buttonMask.Key);
                }
            }

            return [.. buttons];
        }

        return [];
    }

    public static int GetDisplayCount()
    {
        if (_glfw != null)
        {
            _ = _glfw.GetMonitors(out int displayCount);

            return displayCount;
        }

        if (_sdl != null)
        {
            return _sdl.GetNumVideoDisplays();
        }

        return 0;
    }

    public static Display GetDisplay(int index)
    {
        if (_glfw != null)
        {
            Monitor** monitors = _glfw.GetMonitors(out int displayCount);

            Monitor* monitor = monitors[index];

            string name = _glfw.GetMonitorName(monitor);

            _glfw.GetMonitorPos(monitor, out int x, out int y);
            _glfw.GetMonitorPhysicalSize(monitor, out int width, out int height);
            _glfw.GetMonitorContentScale(monitor, out float xScale, out float yScale);

            return new Display(index,
                               name,
                               new Vector2(x, y),
                               new Vector2(width, height),
                               new Vector2(),
                               new Vector2(),
                               MathF.Max(xScale, yScale));
        }

        if (_sdl != null)
        {
            string name = _sdl.GetDisplayNameS(index);

            Rectangle<int> main;
            _sdl.GetDisplayBounds(index, &main);

            Rectangle<int> work;
            _sdl.GetDisplayUsableBounds(index, &work);

            float dpi;
            _sdl.GetDisplayDPI(index, &dpi, null, null);

            return new Display(index,
                               name,
                               new Vector2(main.Origin.X, main.Origin.Y),
                               new Vector2(main.Size.X, main.Size.Y),
                               new Vector2(work.Origin.X, work.Origin.Y),
                               new Vector2(work.Size.X, work.Size.Y),
                               dpi / 96.0f);
        }

        return new Display();
    }

    protected override void Destroy()
    {
        _window.Dispose();
    }

    private static bool IsGlfwWindow(IWindow window)
    {
        if (window.GLContext is GlfwContext)
        {
            _glfw ??= Glfw.GetApi();

            return true;
        }

        return false;
    }

    private static bool IsSdlWindow(IWindow window)
    {
        if (window.GLContext is SdlContext)
        {
            _sdl ??= Sdl.GetApi();

            return true;
        }

        return false;
    }
}
