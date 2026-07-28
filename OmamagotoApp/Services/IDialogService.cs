namespace OmamagotoApp.Services.Dialogs;

/// <summary>
/// 各種ダイアログの表示する。
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// エラーダイアログを表示する
    /// </summary>
    /// <param name="message">表示するエラーメッセージ</param>
    /// <param name="title">ダイアログタイトル</param>
    /// <returns>ダイアログ表示完了を表すタスク</returns>
    Task ShowErrorAsync(
        string message,
        string title = "エラー");

    /// <summary>
    /// 警告ダイアログを表示する
    /// </summary>
    /// <param name="message">表示する警告メッセージ</param>
    /// <param name="title">ダイアログタイトル</param>
    /// <returns>ダイアログ表示完了を表すタスク</returns>
    Task ShowWarningAsync(
        string message,
        string title = "警告");

    /// <summary>
    /// 情報ダイアログを表示する
    /// </summary>
    /// <param name="message">表示する情報メッセージ</param>
    /// <param name="title">ダイアログタイトル</param>
    /// <returns>ダイアログ表示完了を表すタスク</returns>
    Task ShowInformationAsync(
        string message,
        string title = "情報");

    /// <summary>
    /// 確認ダイアログを表示する
    /// </summary>
    /// <param name="message">確認メッセージ</param>
    /// <param name="title">ダイアログタイトル</param>
    /// <returns>ダイアログ表示完了を表すタスク</returns>
    Task<bool> ConfirmAsync(
        string message,
        string title = "確認");
}