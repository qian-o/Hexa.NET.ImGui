using System.Numerics;
using Hexa.NET.ImGui;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace ExampleOpenGL;

internal unsafe class ImGuiPlatform : DisposableObject
{
    private readonly ImGuiViewport* _viewport;
    private readonly Window _window;
    private readonly bool _isExternalPlatform;

    public ImGuiPlatform(ImGuiViewport* viewport, Window window)
    {
        _viewport = viewport;
        _window = window;
        _isExternalPlatform = true;

        Initialize();
    }

    public ImGuiPlatform(ImGuiViewport* viewport)
    {
        _viewport = viewport;
        _window = new Window();
        _isExternalPlatform = false;

        Initialize();
    }

    public ImGuiViewport* Viewport => _viewport;

    public string Title { get => _window.Title; set => _window.Title = value; }

    public Vector2 Position { get => _window.Position; set => _window.Position = value; }

    public Vector2 Size { get => _window.Size; set => _window.Size = value; }

    public byte IsFocused => _window.IsFocused ? (byte)1 : (byte)0;

    public byte IsMinimized => _window.WindowState == WindowState.Minimized ? (byte)1 : (byte)0;

    public float Alpha { get => _window.Opacity; set => _window.Opacity = value; }

    public void Show()
    {
        if (_isExternalPlatform)
        {
            return;
        }

        _window.Show();
    }

    public void Focus()
    {
        _window.Focus();
    }

    public void Update()
    {
        if (_isExternalPlatform)
        {
            return;
        }

        _window.PollEvents();
    }

    public void Render()
    {
        _window.GL.Viewport(0, 0, (uint)_window.Size.X, (uint)_window.Size.Y);
        _window.GL.ClearColor(0.45f, 0.55f, 0.60f, 1.00f);
        _window.GL.Clear((uint)ClearBufferMask.ColorBufferBit);
    }

    protected override void Destroy()
    {
        Unregister();

        if (!_isExternalPlatform)
        {
            _window.Dispose();
        }
    }

    private void Initialize()
    {
        _viewport->PlatformHandle = (void*)_window.Handle;

        if (!_isExternalPlatform)
        {
            if (_viewport->Flags.HasFlag(ImGuiViewportFlags.NoTaskBarIcon))
            {
                _window.ShowInTaskbar = false;
            }

            if (_viewport->Flags.HasFlag(ImGuiViewportFlags.NoDecoration))
            {
                _window.WindowBorder = WindowBorder.Hidden;
            }

            if (_viewport->Flags.HasFlag(ImGuiViewportFlags.TopMost))
            {
                _window.TopMost = true;
            }
        }

        Register();
    }

    private void Register()
    {
        _window.Mouse.Scroll += MouseWheel;
        _window.Keyboard.KeyDown += KeyDown;
        _window.Keyboard.KeyUp += KeyUp;
        _window.Keyboard.KeyChar += KeyChar;
        _window.Move += Move;
        _window.Resize += Resize;
        _window.Closing += Closing;
    }

    private void Unregister()
    {
        _window.Mouse.Scroll -= MouseWheel;
        _window.Keyboard.KeyDown -= KeyDown;
        _window.Keyboard.KeyUp -= KeyUp;
        _window.Keyboard.KeyChar -= KeyChar;
        _window.Move -= Move;
        _window.Resize -= Resize;
        _window.Closing -= Closing;
    }

    private void MouseWheel(IMouse mouse, ScrollWheel wheel)
    {
        ImGui.GetIO().AddMouseWheelEvent(wheel.X, wheel.Y);
    }

    private void KeyDown(IKeyboard keyboard, Key key, int arg3)
    {
        if (TryMapKey(key, out ImGuiKey result))
        {
            ImGui.GetIO().AddKeyEvent(result, true);
        }
    }

    private void KeyUp(IKeyboard keyboard, Key key, int arg3)
    {
        if (TryMapKey(key, out ImGuiKey result))
        {
            ImGui.GetIO().AddKeyEvent(result, false);
        }
    }

    private void KeyChar(IKeyboard keyboard, char arg2)
    {
        ImGui.GetIO().AddInputCharacter(arg2);
    }

    private void Move(Vector2D<int> d)
    {
        _viewport->PlatformRequestMove = 1;
    }

    private void Resize(Vector2D<int> d)
    {
        _viewport->PlatformRequestResize = 1;
    }

    private void Closing()
    {
        _viewport->PlatformRequestClose = 1;
    }

    private static bool TryMapKey(Key key, out ImGuiKey result)
    {
        static ImGuiKey KeyToImGuiKeyShortcut(Key keyToConvert, Key startKey1, ImGuiKey startKey2)
        {
            int changeFromStart1 = (int)keyToConvert - (int)startKey1;
            return startKey2 + changeFromStart1;
        }

        result = key switch
        {
            >= Key.F1 and <= Key.F24 => KeyToImGuiKeyShortcut(key, Key.F1, ImGuiKey.F1),
            >= Key.Keypad0 and <= Key.Keypad9 => KeyToImGuiKeyShortcut(key, Key.Keypad0, ImGuiKey.Keypad0),
            >= Key.A and <= Key.Z => KeyToImGuiKeyShortcut(key, Key.A, ImGuiKey.A),
            >= Key.Number0 and <= Key.Number9 => KeyToImGuiKeyShortcut(key, Key.Number0, ImGuiKey.Key0),
            Key.ShiftLeft or Key.ShiftRight => ImGuiKey.ModShift,
            Key.ControlLeft or Key.ControlRight => ImGuiKey.ModCtrl,
            Key.AltLeft or Key.AltRight => ImGuiKey.ModAlt,
            Key.SuperLeft or Key.SuperRight => ImGuiKey.ModSuper,
            Key.Menu => ImGuiKey.Menu,
            Key.Up => ImGuiKey.UpArrow,
            Key.Down => ImGuiKey.DownArrow,
            Key.Left => ImGuiKey.LeftArrow,
            Key.Right => ImGuiKey.RightArrow,
            Key.Enter => ImGuiKey.Enter,
            Key.Escape => ImGuiKey.Escape,
            Key.Space => ImGuiKey.Space,
            Key.Tab => ImGuiKey.Tab,
            Key.Backspace => ImGuiKey.Backspace,
            Key.Insert => ImGuiKey.Insert,
            Key.Delete => ImGuiKey.Delete,
            Key.PageUp => ImGuiKey.PageUp,
            Key.PageDown => ImGuiKey.PageDown,
            Key.Home => ImGuiKey.Home,
            Key.End => ImGuiKey.End,
            Key.CapsLock => ImGuiKey.CapsLock,
            Key.ScrollLock => ImGuiKey.ScrollLock,
            Key.PrintScreen => ImGuiKey.PrintScreen,
            Key.Pause => ImGuiKey.Pause,
            Key.NumLock => ImGuiKey.NumLock,
            Key.KeypadDivide => ImGuiKey.KeypadDivide,
            Key.KeypadMultiply => ImGuiKey.KeypadMultiply,
            Key.KeypadSubtract => ImGuiKey.KeypadSubtract,
            Key.KeypadAdd => ImGuiKey.KeypadAdd,
            Key.KeypadDecimal => ImGuiKey.KeypadDecimal,
            Key.KeypadEnter => ImGuiKey.KeypadEnter,
            Key.GraveAccent => ImGuiKey.GraveAccent,
            Key.Minus => ImGuiKey.Minus,
            Key.Equal => ImGuiKey.Equal,
            Key.LeftBracket => ImGuiKey.LeftBracket,
            Key.RightBracket => ImGuiKey.RightBracket,
            Key.Semicolon => ImGuiKey.Semicolon,
            Key.Apostrophe => ImGuiKey.Apostrophe,
            Key.Comma => ImGuiKey.Comma,
            Key.Period => ImGuiKey.Period,
            Key.Slash => ImGuiKey.Slash,
            Key.BackSlash => ImGuiKey.Backslash,
            _ => ImGuiKey.None
        };

        return result != ImGuiKey.None;
    }
}
