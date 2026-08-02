
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
        services.AddTransient<ProductListPage>();
        services.AddTransient<ProductListViewModel>();
        return services;
    }
}