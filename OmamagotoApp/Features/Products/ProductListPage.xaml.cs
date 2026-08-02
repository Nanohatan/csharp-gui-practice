namespace OmamagotoApp.Features.Products;

public partial class ProductListPage : ContentPage
{
    private readonly ProductListViewModel _viewModel;
    public ProductListPage(ProductListViewModel viewModel)
    {
        InitializeComponent();

        this._viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_viewModel.LoadCommand.CanExecute(null))
        {
            _viewModel.LoadCommand.Execute(null);
        }
    }
}