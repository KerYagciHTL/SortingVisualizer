using Microsoft.Extensions.DependencyInjection;

namespace SortingVisualizer.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddWindow(this IServiceCollection services, WindowConfig config)
    {
        services.AddSingleton(config);
        services.AddSingleton<Window>();
        services.AddSingleton<Visualizer>();
        services.AddSingleton(new Array(NativeMethods.GetRandomArray(1, 100, 40), config));
        //future services

        return services;
    }
}