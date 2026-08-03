using SQLite;

namespace OmamagotoApp.Features.Products.Models;

[Table("Products")]
public sealed class Product
{
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string ImageSource { get; set; } = "dammy400x400.png";
    public DateTime CreatedAt { get; set; }

}