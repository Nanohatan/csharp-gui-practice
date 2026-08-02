using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OmamagotoApp.Features.Products.Models;
using OmamagotoApp.Features.Products.Services;

namespace OmamagotoApp.Features.Products;

public partial class ProductListViewModel : ObservableObject
{
    private readonly IProductService _productService;

    public ProductListViewModel(
        IProductService productService)
    {
        _productService = productService;
    }

    public ObservableCollection<Product> Products { get; } = [];

    [ObservableProperty]
    public partial bool IsLoading { get; set; }

    [ObservableProperty]
    public partial string ErrorMessage { get; set; } = string.Empty;

    [RelayCommand]
    private async Task LoadAsync()
    {
        if (IsLoading)
        {
            return;
        }

        try
        {
            IsLoading = true;
            ErrorMessage = string.Empty;

            var products = await _productService.GetAllAsync();

            Products.Clear();

            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        catch (Exception)
        {
            ErrorMessage = "商品の取得に失敗しました。";
        }
        finally
        {
            IsLoading = false;
        }
    }
}