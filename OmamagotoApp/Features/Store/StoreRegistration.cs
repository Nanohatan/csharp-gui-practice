
using OmamagotoApp.Features.Products.Services;

namespace OmamagotoApp.Features.Store;

public static class StoreRegistration
{
    public static IServiceCollection AddStoreFeature(
        this IServiceCollection services)
    {

        services.AddTransient<StoreFrontPage>();
        services.AddTransient<StoreFrontViewModel>();

        return services;
    }
}