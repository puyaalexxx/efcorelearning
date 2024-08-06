namespace ch04_Sportstore.Models;

public interface IRepository
{
    IEnumerable<Product> Products { get;  }

    Product? GetProduct(int key);

    void AddProduct(Product product);

    void UpdateProduct(Product product);

    void UpdateAll(Product[] products);

    void Delete(Product product);
}