using OmamagotoApp.Features.Products.Services;

namespace OmamagotoApp.Features.Store;

public static class StoreRegistration
{
    /// <summary>
    /// Registers the Store feature services with transient lifetimes.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddStoreFeature(
        this IServiceCollection services)
    {

        services.AddTransient<StoreFrontPage>();
        services.AddTransient<StoreFrontViewModel>();

        return services;
    }
}