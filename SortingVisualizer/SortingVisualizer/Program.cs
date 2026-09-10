using Microsoft.Extensions.DependencyInjection;
using SortingVisualizer.Core;

namespace SortingVisualizer;

public static class Program
{
    private static void Main()
    {
        var services = new ServiceCollection();
        services.AddWindow(new WindowConfig(1260, 920, "Sorting Visualizer", IsDebugMode: true));

        var serviceProvider = services.BuildServiceProvider();
        var visualizer = serviceProvider.GetRequiredService<Visualizer>();
        
        visualizer.Initialize();
        visualizer.Run();
        visualizer.Dispose();
    }
}