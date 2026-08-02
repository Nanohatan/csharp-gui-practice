using System.ComponentModel;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OmamagotoApp.Features.Products.Models;
using OmamagotoApp.Features.Products.Services;

namespace OmamagotoApp.Features.Products;

public partial class ProductEditViewModel : ObservableObject
{
    private readonly IProductService _productService;
    public ProductEditViewModel(IProductService productService)
    {
        _productService = productService;
    }
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProcutPriceText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ResultMessage { get; set; } = string.Empty;


    [ObservableProperty]
    public partial string ErrorMessage { get; set; } = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    public partial bool IsSaving { set; get; } = false;

    private bool CanSave()
    {
        return !IsSaving;
    }

    [RelayCommand]
    private async Task GoToListAsync()
    {
        await Shell.Current.GoToAsync(nameof(ProductListPage));
    }
    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task Save()
    {
        ErrorMessage = string.Empty;
        ResultMessage = string.Empty;
        var name = ProductName.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            ErrorMessage = "表品名を入力してください";
            return;
        }
        if (name.Length > 20)
        {
            ErrorMessage = "商品名は２０文字以内で入力してください。";
            return;
        }
        if (!decimal.TryParse(ProcutPriceText, out var price))
        {
            ErrorMessage = "価格を正しい数値で入力してください。";
            return;
        }
        if (price < 0)
        {
            ErrorMessage = "価格は0以上で入力してください";
            return;
        }

        try
        {
            IsSaving = true;
            var product = new Product
            {
                Name = name,
                Price = price,
                CreatedAt = DateTime.UtcNow,
            };
            await _productService.AddAsync(product);
            ResultMessage = $"商品：{ProductName}を{ProcutPriceText:N0}円で登録しました。";

            ProductName = string.Empty;
            ProcutPriceText = string.Empty;
        }
        catch (Exception)
        {
            ErrorMessage = "商品の登録に失敗しました。";
        }
        finally
        {
            IsSaving = false;
        }
    }
}
