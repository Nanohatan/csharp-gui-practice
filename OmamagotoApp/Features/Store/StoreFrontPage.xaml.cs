
namespace OmamagotoApp.Features.Store;

public partial class StoreFrontPage : ContentPage
{
    private readonly StoreFrontViewModel _viewModel;

    public StoreFrontPage(StoreFrontViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadAsync();
    }
}