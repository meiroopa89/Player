using System.Data.Entity;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
