using OmamagotoApp.Features.Products.Models;

using OmamagotoApp.Services.Database;

namespace OmamagotoApp.Features.Products.Services;

public sealed class ProductService : IProductService
{
    private readonly IDatabaseService _databaseService;

    public ProductService(
        IDatabaseService databaseService
    )
    {
        _databaseService = databaseService;
    }
    public async Task<int> AddAsync(Product product)
    {
        var db = await _databaseService.GetConnectionAsync();

        return await db.InsertAsync(product);
    }
    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        var db = await _databaseService.GetConnectionAsync();

        return await db.Table<Product>()
            .OrderByDescending(product => product.CreatedAt)
            .ToListAsync();
    }
    public async Task<IReadOnlyList<Product>> GetLimitedAsync(int count)
    {
        var db = await _databaseService.GetConnectionAsync();

        return await db.Table<Product>()
            .OrderByDescending(product => product.CreatedAt)
            .Take(count)
            .ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var db = await _databaseService.GetConnectionAsync();
        return await db.Table<Product>()
            .Where(product => product.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> UpdateAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var db = await _databaseService.GetConnectionAsync();

        return await db.UpdateAsync(product);
    }

    public async Task<int> DeleteAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        var db = await _databaseService.GetConnectionAsync();
        return await db.DeleteAsync(product);
    }
}

