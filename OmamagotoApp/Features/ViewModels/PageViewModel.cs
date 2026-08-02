using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OmamagotoApp.Services.Dialogs;
using OmamagotoApp.Services.Navigation;

namespace OmamagotoApp.Features.ViewModels;

public partial class PageViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;
    private readonly INavigationService _navigationService;

    public PageViewModel(
        IDialogService dialogService,
        INavigationService navigationService)
    {
        _dialogService = dialogService;
        _navigationService = navigationService;
    }

    protected async Task NavigateToAsync(string route)
    {
        await _navigationService.GoToAsync(route);
    }

    [RelayCommand]
    private async Task ShowTestDialogAsync()
    {
        await _dialogService.ShowInformationAsync(
            "ダイアログのテストです。");
    }

    [RelayCommand]
    private async Task ConfirmTestAsync()
    {
        bool confirmed = await _dialogService.ConfirmAsync(
            "処理を実行しますか？");

        if (!confirmed)
        {
            await _dialogService.ShowWarningAsync(
                "処理はキャンセルされました。");

            return;
        }

        await _dialogService.ShowInformationAsync(
            "処理を実行しました。");
    }
}
