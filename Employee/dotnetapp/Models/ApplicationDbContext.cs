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

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<VerificationTask> VerificationTasks { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<VerificationTask>()
        .HasKey(vt => vt.TaskID); // Specify TaskID as the primary key

    // Configure relationships
    modelBuilder.Entity<VerificationTask>()
        .HasOne(vt => vt.Candidate)
        .WithMany(c => c.VerificationTasks)
        .HasForeignKey(vt => vt.CandidateID)
        .OnDelete(DeleteBehavior.Cascade); // Adjust this behavior as needed

    // Additional configurations or constraints can be added here

    base.OnModelCreating(modelBuilder);
}

}
}