using System.Security.Cryptography.X509Certificates;

namespace CounterApp.Models;

public sealed class Product
{
    public int Id { get; }
    public string Name { get; }

    public decimal Price { get; }

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}