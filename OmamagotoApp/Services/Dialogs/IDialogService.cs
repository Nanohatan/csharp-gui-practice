namespace OmamagotoApp.Services.Dialogs;

public interface IDialogService
{
    Task ShowInformationAsync(
        string message,
        string title = "情報");

    Task ShowWarningAsync(
        string message,
        string title = "警告");

    Task ShowErrorAsync(
        string message,
        string title = "エラー");

    Task<bool> ConfirmAsync(
        string message,
        string title = "確認");
}