using CommunityToolkit.Mvvm.ComponentModel;

namespace CounterApp.ViewModels;

public partial class ProductListViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "商品";
}