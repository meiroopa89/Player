using GuitarBookingSystem.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace GuitarBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, and validations
            modelBuilder.Entity<Class>()
                .HasMany(r => r.Students)
                .WithOne(c => c.Class)
                .HasForeignKey(c => c.ClassID);

        modelBuilder.Entity<Class>().HasData(
        new Class { ClassID = 1, StartTime = new DateTime(2024, 04, 25, 10, 0, 0), EndTime = new DateTime(2024, 04, 25, 12, 0, 0), Capacity = 10 },
        new Class { ClassID = 2, StartTime = new DateTime(2024, 04, 26, 14, 0, 0), EndTime = new DateTime(2024, 04, 26, 16, 0, 0), Capacity = 8 },
        new Class { ClassID = 3, StartTime = new DateTime(2024, 04, 27, 9, 0, 0), EndTime = new DateTime(2024, 04, 27, 11, 0, 0), Capacity = 12 },
        new Class { ClassID = 4, StartTime = new DateTime(2024, 04, 28, 15, 0, 0), EndTime = new DateTime(2024, 04, 28, 17, 0, 0), Capacity = 6 },
        new Class { ClassID = 5, StartTime = new DateTime(2024, 04, 29, 11, 0, 0), EndTime = new DateTime(2024, 04, 29, 13, 0, 0), Capacity = 15 }
    );

        }
    }
}
