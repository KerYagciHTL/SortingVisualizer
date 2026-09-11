using Microsoft.Extensions.DependencyInjection;

namespace SortingVisualizer.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddWindow(this IServiceCollection services, WindowConfig config)
    {
        services.AddSingleton(config);
        services.AddSingleton<Window>();
        services.AddSingleton<Visualizer>();
        services.AddSingleton(new Array([5, 3, 1, 4], config));
        //future services

        return services;
    }
}