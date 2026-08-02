
namespace OmamagotoApp.Features.ProductEdit;

public static class ProductEditPageRegistration
{
    public static IServiceCollection AddProductEditFeature(
        this IServiceCollection services)
    {
        services.AddTransient<ProductEditPage>();
        return services;
    }
}