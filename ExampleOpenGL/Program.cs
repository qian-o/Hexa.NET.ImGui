using ExampleOpenGL;
using Hexa.NET.ImGui;

internal unsafe class Program
{
    private static Window _window = null!;
    private static ImGuiController _controller = null!;

    private static void Main(string[] _)
    {
        SilkWindow.PrioritizeGlfw();

        _window = new Window();

        _window.Load += Window_Load;
        _window.Update += Window_Update;
        _window.Render += Window_Render;

        _window.Run();

        _window.Dispose();
    }

    private static void Window_Load()
    {
        _controller = new ImGuiController(_window,
                                          new ImGuiFontConfig("Assets/Fonts/MSYH.TTC", 14, (a) => (nint)a.Fonts.GetGlyphRangesDefault()));
    }

    private static void Window_Update(double obj)
    {
        _controller.Update((float)obj);
    }

    private static void Window_Render(double obj)
    {
        ImGui.ShowDemoWindow();

        _controller.Render();
    }
}