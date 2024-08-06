using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ch04_Sportstore.Models;

public class DataRepository : IRepository
{
    private readonly DataContext _ctx;

    public DataRepository(DataContext ctx)
    {
        _ctx = ctx;
    }

    public IEnumerable<Product> Products => _ctx.Products.ToArray();

    public Product GetProduct(int key)
    {
        
        var product = _ctx.Products.Find(key);
        
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with key {key} not found.");
        }

        return product;
    }

    public void AddProduct(Product product)
    {
        _ctx.Products.Add(product);

        _ctx.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        Product p = GetProduct(product.Id);

        p.Name = product.Name;
        p.Category = product.Category;
        p.PurchasePrice = product.PurchasePrice;
        p.RetailPrice = product.RetailPrice;
        
        //_ctx.Products.Update(product);
        _ctx.SaveChanges();
    }

    public void UpdateAll(Product[] products)
    {
        //context.Products.UpdateRange(products);
        
        var data = products.ToDictionary(p => p.Id);
        
        IEnumerable<Product> baseline =
            _ctx.Products.Where(p => data.Keys.Contains(p.Id));
        
        foreach(Product databaseProduct in baseline) {
            Product requestProduct = data[databaseProduct.Id];
            databaseProduct.Name = requestProduct.Name;
            databaseProduct.Category = requestProduct.Category;
            databaseProduct.PurchasePrice = requestProduct.PurchasePrice;
            databaseProduct.RetailPrice = requestProduct.RetailPrice;
        }

        _ctx.SaveChanges();
    }

    public void Delete(Product product)
    {
        _ctx.Products.Remove(product);

        _ctx.SaveChanges();
    }
}