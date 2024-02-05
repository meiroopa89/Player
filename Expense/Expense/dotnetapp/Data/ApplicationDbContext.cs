using Microsoft.EntityFrameworkCore;
using dotnetapp.Model;

namespace dotnetapp.Data
{
    // ApplicationDbContext.cs

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExpenseModel> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseModel>().HasKey(e => e.ExpenseID);
        }
    }

}
