using SQLite;

namespace OmamagotoApp.Services.Database;

/// <summary>
/// DBの作成、接続を提供するサービス。
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// DBへ接続する。
    /// </summary>
    /// <returns></returns>
    Task<SQLiteAsyncConnection> GetConnectionAsync();
}