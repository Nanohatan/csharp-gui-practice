using SQLite;

using OmamagotoApp.Features.Products.Models;

namespace OmamagotoApp.Services.Database;

public sealed class DatabaseService : IDatabaseService
{
    private const string DatabaseFileName = "omamagotoApp.db3";
    private readonly SemaphoreSlim _initializationLock = new(1, 1);

    private SQLiteAsyncConnection? _database;

    private static string DatabasePath =>
        Path.Combine(
            FileSystem.AppDataDirectory,
            DatabaseFileName);
    public async Task<SQLiteAsyncConnection> GetConnectionAsync()
    {
        if (_database is not null)
        {
            return _database;
        }

        await _initializationLock.WaitAsync();

        try
        {
            if (_database is not null)
            {
                return _database;
            }
            var connection = new SQLiteAsyncConnection(
                DatabasePath,
                SQLiteOpenFlags.ReadWrite
                | SQLiteOpenFlags.Create
                | SQLiteOpenFlags.SharedCache);

            await connection.CreateTableAsync<Product>();
            _database = connection;
            return _database;
        }
        finally
        {
            _initializationLock.Release();
        }
    }

}