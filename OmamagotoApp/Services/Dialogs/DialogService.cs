using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace OmamagotoApp.Services.Dialogs;

public sealed class DialogService : IDialogService
{
    public Task ShowErrorAsync(
        string message,
        string title = "エラー")
    {
        return ShowAlertAsync(title, message);
    }

    public Task ShowWarningAsync(
        string message,
        string title = "警告")
    {
        return ShowAlertAsync(title, message);
    }

    public Task ShowInformationAsync(
        string message,
        string title = "情報")
    {
        return ShowAlertAsync(title, message);
    }

    public Task<bool> ConfirmAsync(
        string message,
        string title = "確認")
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
        {
            var page = GetCurrentPage();

            return await page.DisplayAlertAsync(
                title,
                message,
                "はい",
                "いいえ");
        });
    }

    private static Task ShowAlertAsync(
        string title,
        string message)
    {
        return MainThread.InvokeOnMainThreadAsync(async () =>
        {
            var page = GetCurrentPage();

            await page.DisplayAlertAsync(
                title,
                message,
                "OK");
        });
    }

    private static Page GetCurrentPage()
    {
        if (Shell.Current is not null)
        {
            return Shell.Current;
        }

        var page = Application.Current?
            .Windows
            .FirstOrDefault()?
            .Page;

        return page
            ?? throw new InvalidOperationException(
                "ダイアログを表示できるPageがありません。");
    }
}