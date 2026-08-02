
using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.ViewModels;
using OmamagotoApp.Services.Navigation;

using CommunityToolkit.Mvvm.Input;
using OmamagotoApp.Features.Products;

namespace OmamagotoApp.Features.Home;

public partial class HomeViewModel : PageViewModel
{
    public HomeViewModel(
        IDialogService dialogService,
        INavigationService navigationService)
        : base(dialogService, navigationService)
    {
    }

    [RelayCommand]
    private Task GoToProductEditPageAsync()
    {
        return NavigateToAsync(ProductRoutes.Edit);
    }
}
