using OmamagotoApp.Features.Products.Models;

using SQLite;

namespace OmamagotoApp.Features.Products.Services;

public sealed class ProductService : IProductService
{
    private const string DatabaseFileName = "omamagotoApp.db3";
    private readonly SemaphoreSlim _initializationLock = new(1, 1);

    private SQLiteAsyncConnection? _database;

    private static string DatabasePath =>
        Path.Combine(
            FileSystem.AppDataDirectory,
            DatabaseFileName);
    private async Task<SQLiteAsyncConnection> GetDatabaseAsync()
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

    public async Task<int> AddAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);
        var db = await GetDatabaseAsync();
        return await db.InsertAsync(product);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        var db = await GetDatabaseAsync();

        return await db.Table<Product>()
            .OrderByDescending(product => product.CreatedAt)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var db = await GetDatabaseAsync();
        return await db.Table<Product>()
            .Where(product => product.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> UpdateAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var db = await GetDatabaseAsync();

        return await db.UpdateAsync(product);
    }

    public async Task<int> DeleteAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var db = await GetDatabaseAsync();
        return await db.DeleteAsync(product);
    }
}

