
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

    public StoreFrontViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        IProductService productService)
        : base(dialogService, navigationService)
    {
        _productService = productService;
    }

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