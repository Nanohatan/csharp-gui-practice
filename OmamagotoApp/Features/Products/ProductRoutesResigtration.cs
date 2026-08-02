
using OmamagotoApp.Features.Products.Models;

namespace OmamagotoApp.Features.Products;

public static class ProductRouteRegistration
{
    public static void RegistrationProductRoutes()
    {
        Routing.RegisterRoute(
            ProductRoutes.Edit,
            typeof(ProductEditPage)
        );

        Routing.RegisterRoute(
            ProductRoutes.List,
            typeof(ProductListPage)
        );
    }
}