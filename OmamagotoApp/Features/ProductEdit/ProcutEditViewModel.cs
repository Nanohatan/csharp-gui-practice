using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OmamagotoApp.Features.ProductEdit;

public partial class ProductEditViewModel : ObservableObject
{
    public ProductEditViewModel()
    {
    }
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ProcutPriceText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string ResultMessage { get; set; } = string.Empty;


    [ObservableProperty]
    public partial string ErrorMessage { get; set; } = string.Empty;


    [RelayCommand]
    private void Save()
    {
        ErrorMessage = string.Empty;
        ResultMessage = string.Empty;
        if (string.IsNullOrWhiteSpace(ProductName))
        {
            ErrorMessage = "表品名を入力してください";
            return;
        }
        if (!decimal.TryParse(ProcutPriceText, out var price))
        {
            ErrorMessage = "価格は数値で入力してください。";
            return;
        }
        if (price < 0)
        {
            ErrorMessage = "価格は0以上で入力してください";
            return;
        }
        ResultMessage = $"{ProductName}を{ProcutPriceText:N0}円で登録しました。";
    }
}
