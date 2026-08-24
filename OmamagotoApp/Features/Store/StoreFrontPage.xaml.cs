namespace OmamagotoApp.Features.Store;

public partial class StoreFrontPage : ContentPage
{
    private readonly StoreFrontViewModel _viewModel;

    /// <summary>
    /// Initializes the store front page with its view model.
    /// </summary>
    /// <param name="viewModel">The view model that provides the page's data and behavior.</param>
    public StoreFrontPage(StoreFrontViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    /// <summary>
    /// Loads the storefront data when the page appears.
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadAsync();
    }
}