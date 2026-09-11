using Microsoft.Extensions.DependencyInjection;

namespace SortingVisualizer.Core;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddWindow(this IServiceCollection services, WindowConfig config)
    {
        services.AddSingleton(config);
        services.AddSingleton<Window>();
        services.AddSingleton<Visualizer>();
        services.AddSingleton(new Array([5, 3, 3, 4, 12, 7, 4, 8 ,3 ,78, 14, 41, 63, 94, 43, 45, 72, 92 , 34], config));
        //future services

        return services;
    }
}