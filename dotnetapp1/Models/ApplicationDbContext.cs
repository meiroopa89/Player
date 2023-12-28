using dotnetapp1.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp1.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If you want to specify any configurations, relationships, constraints, or validations,
            // you can define them here similar to how it was done for the Classes and Students.

            // Example: If you want to set a unique constraint on the Name property of the Book entity
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Name)
                .IsUnique();
        }
    }
}
