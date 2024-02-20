using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Add this using directive
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using Microsoft.AspNetCore.Identity;
namespace dotnetapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> // Inherit from IdentityDbContext<IdentityUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Order> Orders { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserId);


            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithOne()
                .HasForeignKey<Cart>(c => c.CustomerId);

            modelBuilder.Entity<Order>()
            .HasMany(o => o.Gifts)  // An order can have many gifts
            .WithOne(g => g.Order)  // A gift belongs to one order
            .HasForeignKey(g => g.OrderId)  // Foreign key in the Gift table
            .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete if an order is deleted

            modelBuilder.Entity<Gift>()
            .Property(g => g.GiftId)
            .ValueGeneratedOnAdd();

        }
    }
}
