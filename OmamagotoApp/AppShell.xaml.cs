using OmamagotoApp.Features.ProductEdit;

namespace OmamagotoApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ProductEditPage), typeof(ProductEditPage));
    }
}
