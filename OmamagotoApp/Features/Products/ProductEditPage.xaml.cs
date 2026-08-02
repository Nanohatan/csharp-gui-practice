
namespace OmamagotoApp.Features.Products;

public partial class ProductEditPage : ContentPage
{
    public ProductEditPage(ProductEditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}