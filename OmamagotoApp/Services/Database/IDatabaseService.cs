using SQLite;

namespace OmamagotoApp.Services.Database;

public interface IDatabaseService
{
    Task<SQLiteAsyncConnection> GetConnectionAsync();
}