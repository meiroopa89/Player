using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
