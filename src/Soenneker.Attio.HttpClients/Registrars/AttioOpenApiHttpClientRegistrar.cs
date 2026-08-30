using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Attio.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Attio.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class AttioOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IAttioOpenApiHttpClient"/> as a singleton service backed by the singleton HTTP-client cache.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddAttioOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IAttioOpenApiHttpClient, AttioOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAttioOpenApiHttpClient"/> as a scoped service backed by the singleton HTTP-client cache.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddAttioOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IAttioOpenApiHttpClient, AttioOpenApiHttpClient>();

        return services;
    }
}
