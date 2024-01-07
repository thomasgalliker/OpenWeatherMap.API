using System;
using Microsoft.Extensions.Configuration;
using OpenWeatherMap;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenWeatherMap(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Configuration
            serviceCollection.Configure<OpenWeatherMapOptions>(configuration);

            // Register services
            serviceCollection.AddOpenWeatherMap();

            return serviceCollection;
        }

        public static IServiceCollection AddOpenWeatherMap(
            this IServiceCollection services,
            Action<OpenWeatherMapOptions> options = null)
        {
            // Configuration
            if (options != null)
            {
                services.Configure(options);
            }

            // Register services
            services.AddSingleton<IOpenWeatherMapService, OpenWeatherMapService>();

            return services;
        }
    }
}