
using OmamagotoApp.Features.Products.Services;

namespace OmamagotoApp.Features.Products;

public static class ProductPageRegistration
{
    public static IServiceCollection AddProductFeature(
        this IServiceCollection services)
    {
        services.AddSingleton<IProductService, ProductService>();
        services.AddTransient<ProductEditPage>();
        services.AddTransient<ProductEditViewModel>();
        return services;
    }
}