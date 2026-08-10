using OmamagotoApp.Features.Products;
using OmamagotoApp.Features.Store;

namespace OmamagotoApp;

public partial class AppShell : Shell
{
    /// <summary>
    /// Initializes the application shell and registers product and store routes.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();
        ProductRouteRegistration.RegistrationProductRoutes();
        StoreRoutesRegistration.RegistrationStoreRoutes();
    }
}
