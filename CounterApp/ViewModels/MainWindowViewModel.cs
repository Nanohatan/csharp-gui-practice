using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CounterApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject? currentPage;

    public MainWindowViewModel()
    {
        CurrentPage = null;
    }

    [RelayCommand]
    private void ShowProductList()
    {
        CurrentPage = new ProductListViewModel();
    }
}