using OmamagotoApp.Features.Products.Models;

namespace OmamagotoApp.Features.Products.Services;

/// <summary>
/// 商品情報の登録、取得、更新、削除を提供するサービス。
/// </summary>
public interface IProductService
{
    /// <summary>
    /// 商品を新規登録する。
    /// </summary>
    /// <param name="product">登録する商品情報。</param>
    /// <returns>データベースで更新された行数。</returns>
    Task<int> AddAsync(Product product);

    /// <summary>
    /// 登録されているすべての商品を取得する。
    /// </summary>
    /// <summary>
/// Retrieves all products.
/// </summary>
/// <returns>A read-only list of products.</returns>
    Task<IReadOnlyList<Product>> GetAllAsync();

    /// <summary>
/// Retrieves a limited list of products.
/// </summary>
/// <param name="count">The maximum number of products to retrieve.</param>
/// <returns>The products retrieved, up to the specified count.</returns>
Task<IReadOnlyList<Product>> GetLimitedAsync(int count);

    /// <summary>
    /// 指定されたIDの商品を取得する。
    /// </summary>
    /// <param name="id">取得する商品のID。</param>
    /// <returns>
    /// 該当する商品。商品が存在しない場合は <see langword="null"/>。
    /// </returns>
    Task<Product?> GetByIdAsync(int id);

    /// <summary>
    /// 商品情報を更新する。
    /// </summary>
    /// <param name="product">更新する商品情報。</param>
    /// <returns>データベースで更新された行数。</returns>
    Task<int> UpdateAsync(Product product);

    /// <summary>
    /// 商品を削除する。
    /// </summary>
    /// <param name="product">削除する商品情報。</param>
    /// <returns>データベースで削除された行数。</returns>
    Task<int> DeleteAsync(Product product);
}