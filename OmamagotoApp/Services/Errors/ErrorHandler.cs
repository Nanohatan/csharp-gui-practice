using System.Net;
using System.Net.Http;

using Microsoft.Extensions.Logging;

using OmamagotoApp.Services.Dialogs;

namespace OmamagotoApp.Services.Errors;

public sealed class ErrorHandler : IErrorHandler
{
    private readonly IDialogService _dialogService;
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(
        IDialogService dialogService,
        ILogger<ErrorHandler> logger)
    {
        _dialogService = dialogService;
        _logger = logger;
    }

    public async Task HandleAsync(
        Exception exception,
        string? userMessage = null,
        string? operationName = null)
    {
        ArgumentNullException.ThrowIfNull(exception);

        var operation = string.IsNullOrWhiteSpace(operationName)
            ? "不明な処理"
            : operationName;

        _logger.LogError(
            exception,
            "{OperationName}でエラーが発生しました。",
            operation);

        var message = userMessage
            ?? ConvertToUserMessage(exception);

        await _dialogService.ShowErrorAsync(message);
    }

    public async Task ExecuteAsync(
        Func<Task> action,
        string? userMessage = null,
        string? operationName = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        try
        {
            await action();
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "{OperationName}がキャンセルされました。",
                operationName ?? "処理");
        }
        catch (Exception ex)
        {
            await HandleAsync(
                ex,
                userMessage,
                operationName);
        }
    }

    public async Task<T?> ExecuteAsync<T>(
        Func<Task<T>> action,
        string? userMessage = null,
        string? operationName = null)
    {
        ArgumentNullException.ThrowIfNull(action);

        try
        {
            return await action();
        }
        catch (OperationCanceledException)
        {
            _logger.LogInformation(
                "{OperationName}がキャンセルされました。",
                operationName ?? "処理");

            return default;
        }
        catch (Exception ex)
        {
            await HandleAsync(
                ex,
                userMessage,
                operationName);

            return default;
        }
    }

    private static string ConvertToUserMessage(
        Exception exception)
    {
        return exception switch
        {
            HttpRequestException httpException
                when httpException.StatusCode
                    == HttpStatusCode.Unauthorized =>
                "認証の有効期限が切れました。もう一度ログインしてください。",

            HttpRequestException =>
                "サーバーとの通信に失敗しました。通信状態を確認してください。",

            TimeoutException =>
                "処理がタイムアウトしました。時間をおいて再度お試しください。",

            UnauthorizedAccessException =>
                "この処理を実行する権限がありません。",

            IOException =>
                "ファイルの読み書きに失敗しました。",

            ArgumentException =>
                "入力内容に問題があります。",

            InvalidOperationException =>
                "現在の状態では、この処理を実行できません。",

            _ =>
                "予期しないエラーが発生しました。"
        };
    }
}