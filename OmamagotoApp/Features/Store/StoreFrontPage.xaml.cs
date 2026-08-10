
namespace OmamagotoApp.Features.Store;

public partial class StoreFrontPage : ContentPage
{


    public StoreFrontPage(StoreFrontViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
