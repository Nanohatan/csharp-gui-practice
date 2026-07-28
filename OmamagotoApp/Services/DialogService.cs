namespace OmamagotoApp.Services.Dialogs;

/// <summary>
/// .NET MAUIのダイアログ機能を提供します。
/// </summary>
public sealed class DialogService : IDialogService
{
    private static Page CurrentPage =>
        Shell.Current?.CurrentPage
        ?? throw new InvalidOperationException(
            "現在のページを取得できませんでした。");

    public Task ShowErrorAsync(
        string message,
        string title = "エラー")
    {
        return CurrentPage.DisplayAlertAsync(
            title,
            message,
            "OK");
    }

    public Task ShowWarningAsync(
        string message,
        string title = "警告")
    {
        return CurrentPage.DisplayAlertAsync(
            title,
            message,
            "OK");
    }

    public Task ShowInformationAsync(
        string message,
        string title = "情報")
    {
        return CurrentPage.DisplayAlertAsync(
            title,
            message,
            "OK");
    }

    public Task<bool> ConfirmAsync(
        string message,
        string title = "確認")
    {
        return CurrentPage.DisplayAlertAsync(
            title,
            message,
            "はい",
            "いいえ");
    }
}