using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OmamagotoApp.Features.Products.Models;
using OmamagotoApp.Features.Products.Services;
using OmamagotoApp.Features.ViewModels;
using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Services.Navigation;

namespace OmamagotoApp.Features.Products;

public partial class ProductEditViewModel : PageViewModel
{
    private readonly IProductService _productService;

    public ProductEditViewModel(
        IProductService productService,
        IDialogService dialogService,
        INavigationService navigationService)
        : base(dialogService, navigationService)
    {
        _productService = productService;
    }

    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProductPriceText { get; set; } = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasResult))]
    public partial string ResultMessage { get; set; } = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HasError))]
    public partial string ErrorMessage { get; set; } = string.Empty;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    public partial bool IsSaving { get; set; }

    public bool HasError =>
        !string.IsNullOrWhiteSpace(ErrorMessage);

    public bool HasResult =>
        !string.IsNullOrWhiteSpace(ResultMessage);

    private bool CanSave()
    {
        return !IsSaving;
    }

    [RelayCommand]
    private Task GoToListAsync()
    {
        return NavigateToAsync(ProductRoutes.List);
    }

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        ErrorMessage = string.Empty;
        ResultMessage = string.Empty;

        var name = ProductName.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            ErrorMessage = "商品名を入力してください。";
            return;
        }

        if (name.Length > 20)
        {
            ErrorMessage = "商品名は20文字以内で入力してください。";
            return;
        }

        if (!decimal.TryParse(ProductPriceText, out var price))
        {
            ErrorMessage = "価格を正しい数値で入力してください。";
            return;
        }

        if (price < 0)
        {
            ErrorMessage = "価格は0以上で入力してください。";
            return;
        }

        try
        {
            IsSaving = true;

            var product = new Product
            {
                Name = name,
                Price = price,
                CreatedAt = DateTime.UtcNow
            };

            await _productService.AddAsync(product);

            ResultMessage =
                $"商品：{name}を{price:N0}円で登録しました。";

            ProductName = string.Empty;
            ProductPriceText = string.Empty;
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