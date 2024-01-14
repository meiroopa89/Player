using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Expense model configuration
            modelBuilder.Entity<Expense>()
                .HasKey(e => e.Id); // Specify Id as the primary key

            // Category model configuration
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id); // Specify Id as the primary key

            // Configure one-to-many relationship from Category to Expense
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Expenses)  // Expenses is a virtual ICollection in Category
                .WithOne(e => e.Category)   // Category is a navigation property in Expense
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
