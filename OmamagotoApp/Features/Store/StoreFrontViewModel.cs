using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.ViewModels;
using OmamagotoApp.Services.Navigation;

using System.Collections.ObjectModel;
using OmamagotoApp.Features.Products.Models;
using OmamagotoApp.Features.Products.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLitePCL;
using System.Diagnostics;

namespace OmamagotoApp.Features.Store;

public partial class StoreFrontViewModel : PageViewModel
{
    private readonly IProductService _productService;

    public ObservableCollection<Product> Products { get; } = new();

    /// <summary>
    /// Initializes a store front view model with the services required for product retrieval, navigation, and dialogs.
    /// </summary>
    /// <param name="dialogService">The service used to display dialogs.</param>
    /// <param name="navigationService">The service used for page navigation.</param>
    /// <param name="productService">The service used to retrieve products.</param>
    public StoreFrontViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IProductService productService)
        : base(dialogService, navigationService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Loads up to five products into the product collection.
    /// </summary>
    public async Task LoadAsync()
    {
        var products = await _productService.GetLimitedAsync(5);
        Debug.WriteLine(products);
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }
}