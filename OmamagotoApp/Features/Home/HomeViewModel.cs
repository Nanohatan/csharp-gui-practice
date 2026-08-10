using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Features.ViewModels;
using OmamagotoApp.Services.Navigation;

using CommunityToolkit.Mvvm.Input;
using OmamagotoApp.Features.Products;
using OmamagotoApp.Features.Store;

namespace OmamagotoApp.Features.Home;

public partial class HomeViewModel : PageViewModel
{
    public HomeViewModel(
        IDialogService dialogService,
        INavigationService navigationService)
        : base(dialogService, navigationService)
    {
    }

    /// <summary>
    /// Navigates to the product edit page.
    /// </summary>
    [RelayCommand]
    private Task GoToProductEditPageAsync()
    {
        return NavigateToAsync(ProductRoutes.Edit);
    }

    /// <summary>
    /// Navigates to the store front page.
    /// </summary>
    [RelayCommand]
    private Task GoToStoreFrontPageAsync()
    {
        return NavigateToAsync(StoreRoutes.Front);
    }
}
