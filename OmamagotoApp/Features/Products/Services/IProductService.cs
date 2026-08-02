using OmamagotoApp.Features.Products.Models;

namespace OmamagotoApp.Features.Products.Services;

public interface IProductService
{
    Task<int> AddAsync(Product product);

    Task<IReadOnlyList<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<int> UpdateAsync(Product product);

    Task<int> DeleteAsync(Product product);
}