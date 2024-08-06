using Microsoft.EntityFrameworkCore;

namespace ch01;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<GuestResponse> Responses { get; set; }
}