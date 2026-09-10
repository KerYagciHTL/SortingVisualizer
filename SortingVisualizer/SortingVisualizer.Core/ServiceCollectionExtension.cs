using Microsoft.Extensions.DependencyInjection;

namespace SortingVisualizer.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddWindow(this IServiceCollection services, WindowConfig config)
    {
        services.AddSingleton(config);
        services.AddSingleton<Window>();
        services.AddSingleton<Visualizer>();
        //future services

        return services;
    }
}