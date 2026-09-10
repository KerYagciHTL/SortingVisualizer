using SortingVisualizer.Core;
using Microsoft.Extensions.DependencyInjection;

namespace SortingVisualizer;

public static class Program
{
    private static void Main()
    {
        var services = new ServiceCollection();
        services.AddWindow(new WindowConfig(1260, 920, "Sorting Visualizer", IsDebugMode: true));
    }
}