using Microsoft.EntityFrameworkCore;


namespace dotnetapp.Models
{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Batch> Batches { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the relationships between entities
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Batch)
            .WithMany(b => b.Students)
            .HasForeignKey(s => s.BatchID);

        // Seed data for Batches
         DateTime startDate = DateTime.Now.Date; // Start date for the first batch
        modelBuilder.Entity<Batch>().HasData(
                new Batch { BatchID = 1, StartTime = startDate, EndTime = startDate.AddDays(60).AddHours(2), Capacity = 5, Price = 100, Duration = 40 },
                new Batch { BatchID = 2, StartTime = startDate.AddDays(10), EndTime = startDate.AddDays(100).AddHours(1), Capacity = 5, Price = 120, Duration = 45 },
                new Batch { BatchID = 3, StartTime = startDate.AddDays(20), EndTime = startDate.AddDays(200).AddHours(1), Capacity = 5, Price = 150, Duration = 50 },
                new Batch { BatchID = 4, StartTime = startDate.AddDays(30), EndTime = startDate.AddDays(300).AddHours(1), Capacity = 5, Price = 130, Duration = 45 },
                new Batch { BatchID = 5, StartTime = startDate.AddDays(40), EndTime = startDate.AddDays(400).AddHours(1), Capacity = 5, Price = 140, Duration = 40 }
        );

        base.OnModelCreating(modelBuilder);
    }

}
}