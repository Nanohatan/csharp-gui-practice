using OmamagotoApp.Features.Products;
using OmamagotoApp.Features.Store;

namespace OmamagotoApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        ProductRouteRegistration.RegistrationProductRoutes();
        StoreRoutesRegistration.RegistrationStoreRoutes();
    }
}
