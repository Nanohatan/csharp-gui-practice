namespace OmamagotoApp.Services.Dialogs;

/// <summary>
/// ダイアログの表示を提供するサービス。
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// 情報ダイアログを表示する。
    /// </summary>
    /// <param name="message">メッセージ。</param>
    /// <param name="title">ダイアログのタイトル。</param>
    /// <returns></returns>
    Task ShowInformationAsync(
        string message,
        string title = "情報");

    /// <summary>
    /// 警告ダイアログを表示する。
    /// </summary>
    /// <param name="message">メッセージ本文。</param>
    /// <param name="title">ダイアログのタイトル。</param>
    /// <returns></returns>
    Task ShowWarningAsync(
        string message,
        string title = "警告");

    /// <summary>
    /// エラーダイアログを表示する。
    /// </summary>
    /// <param name="message">メッセージ本文。</param>
    /// <param name="title">ダイアログのタイトル。</param>
    /// <returns></returns>
    Task ShowErrorAsync(
        string message,
        string title = "エラー");

    /// <summary>
    /// 確認ダイアログを表示する。
    /// </summary>
    /// <param name="message">メッセージ本文。</param>
    /// <param name="title">ダイアログのタイトル。</param>
    /// <returns></returns>
    Task<bool> ConfirmAsync(
        string message,
        string title = "確認");
}