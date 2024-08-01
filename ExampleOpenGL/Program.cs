using ExampleOpenGL;

SilkWindow.PrioritizeGlfw();
// SilkWindow.PrioritizeSdl();

using Window window = new();

window.Load += Window_Load;
window.Update += Window_Update;
window.Render += Window_Render;

window.Run();

void Window_Load()
{
}

void Window_Update(double obj)
{
}

void Window_Render(double obj)
{
    int displayCount = Window.GetDisplayCount();

    for (int i = 0; i < displayCount; i++)
    {
        Display display = Window.GetDisplay(i);

        Console.WriteLine(display);
    }
}
