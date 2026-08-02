using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using OmamagotoApp.Services.Dialogs;

namespace OmamagotoApp.Features.ViewModels;

public partial class PageViewModel : ObservableObject
{
    private readonly IDialogService _dialogService;

    public PageViewModel(IDialogService dialogService)
    {
        _dialogService = dialogService;
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
