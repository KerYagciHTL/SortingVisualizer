using Raylib_cs;

namespace SortingVisualizer.Core;

public class Window(WindowConfig config)
{
    private bool _initialized;
    public Color BackgroundColor { get; set; } = Color.Black;
    public bool IsClosed => Raylib.WindowShouldClose();

    public void Initialize()
    {
        Raylib.InitWindow(config.Width, config.Height, config.Title);
        Raylib.SetTargetFPS(config.TargetFps);
        _initialized = true;
    }

    public void BeginFrame()
    {
        if (!_initialized) throw new InvalidOperationException("Window is not initialized");

        Raylib.BeginDrawing();
        Raylib.ClearBackground(BackgroundColor);
    }

    public void EndFrame()
    {
        if (!_initialized) throw new InvalidOperationException("Window is not initialized");
        Raylib.EndDrawing();
    }

    public void Close()
    {
        if (!_initialized) throw new InvalidOperationException("Window is not initialized");
        Raylib.CloseWindow();
    }
}