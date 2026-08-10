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
    /// <summary>
    /// Retrieves all products ordered by creation time, from newest to oldest.
    /// </summary>
    /// <returns>The products ordered by descending creation time.</returns>
    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        var db = await _databaseService.GetConnectionAsync();

        return await db.Table<Product>()
            .OrderByDescending(product => product.CreatedAt)
            .ToListAsync();
    }
    /// <summary>
    /// Retrieves the most recently created products up to the specified count.
    /// </summary>
    /// <param name="count">The maximum number of products to retrieve.</param>
    /// <returns>The products ordered by descending creation time.</returns>
    public async Task<IReadOnlyList<Product>> GetLimitedAsync(int count)
    {
        var db = await _databaseService.GetConnectionAsync();

        return await db.Table<Product>()
            .OrderByDescending(product => product.CreatedAt)
            .Take(count)
            .ToListAsync();
    }

    /// <summary>
    /// Retrieves a product by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the product to retrieve.</param>
    /// <returns>The matching product, or <c>null</c> if no product has the specified identifier.</returns>
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

