using Microsoft.EntityFrameworkCore;

namespace ch04_Sportstore.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> opts): base(opts){}

    public DbSet<Product> Products { get; set; }
}