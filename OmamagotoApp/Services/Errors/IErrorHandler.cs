namespace OmamagotoApp.Services.Errors;

public interface IErrorHandler
{
    Task HandleAsync(
        Exception exception,
        string? userMessage = null,
        string? operationName = null);

    Task ExecuteAsync(
        Func<Task> action,
        string? userMessage = null,
        string? operationName = null);

    Task<T?> ExecuteAsync<T>(
        Func<Task<T>> action,
        string? userMessage = null,
        string? operationName = null);
}