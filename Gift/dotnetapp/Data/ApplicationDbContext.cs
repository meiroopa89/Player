using System.Collections.Generic;
using dotnetapp.Models; 
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Data
{
public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Cart> Carts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and other model-specific settings here
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Customer>(c => c.UserId);

        modelBuilder.Entity<Gift>()
            .HasOne(g => g.Cart)
            .WithMany(c => c.Gifts)
            .HasForeignKey(g => g.CartId);

        modelBuilder.Entity<Gift>()
            .HasOne(g => g.Orders)
            .WithMany(o => o.Gifts)
            .HasForeignKey(g => g.OrdersId);

        modelBuilder.Entity<Orders>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Cart>()
            .HasOne(c => c.Customer)
            .WithOne()
            .HasForeignKey<Cart>(c => c.CustomerId);
    }
}
}
