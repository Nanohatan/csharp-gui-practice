

namespace OmamagotoApp.Features.Home;

public static class HomeFeatureRegistration
{
    public static IServiceCollection AddHomeFeature(
        this IServiceCollection services)
    {
        services.AddTransient<HomePage>();
        services.AddTransient<HomeViewModel>();

        return services;
    }
}