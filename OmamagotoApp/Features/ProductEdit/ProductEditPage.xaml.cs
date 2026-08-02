
namespace OmamagotoApp.Features.ProductEdit;

public partial class ProductEditPage : ContentPage
{
    public ProductEditPage(ProductEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}