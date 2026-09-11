using Raylib_cs;

namespace SortingVisualizer.Core;

public class Visualizer(Window window, Array array) : IDisposable
{
    private bool _initialized;
    
    public void Initialize()
    {
        window.Initialize();
        _initialized = true;
    }

    public void Run()
    {
        if(!_initialized) throw new InvalidOperationException("Visualizer is not initialized");
        try
        {
            Loop();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e.ToString());
        }
    }
    
    private void Loop()
    {
        while (!window.ShouldClose)
        {
            array.Update(Raylib.GetFrameTime());
            
            window.BeginFrame();
            array.Draw();
            window.EndFrame();
        }
    }

    public void Dispose()
    {
        if(_initialized) window.Close();
    }
}