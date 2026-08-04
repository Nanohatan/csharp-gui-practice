using SQLite;

namespace OmamagotoApp.Features.Products.Models;

/// <summary>
/// 商品情報を表すエンティティ。
/// SQLite の Products テーブルと対応する。
/// </summary>
[Table("Products")]
public sealed class Product
{
    /// <summary>
    /// 商品ID（主キー・自動採番）
    /// </summary>
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    /// <summary>
    /// 商品名
    /// </summary>
    [NotNull]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 商品価格
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 商品画像のファイル名またはパス
    /// </summary>
    public string ImageSource { get; set; } = "dummy400x400.png";

    /// <summary>
    /// 商品登録日時
    /// </summary>
    public DateTime CreatedAt { get; set; }
}