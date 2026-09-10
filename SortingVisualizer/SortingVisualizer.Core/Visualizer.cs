namespace SortingVisualizer.Core;

public class Visualizer(Window window) : IDisposable
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
            window.BeginFrame();
            window.EndFrame();
        }
    }

    public void Dispose()
    {
        if(_initialized) window.Close();
    }
}