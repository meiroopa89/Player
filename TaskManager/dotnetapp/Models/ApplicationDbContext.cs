using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasOne(ti => ti.TaskList)
                .WithMany(tl => tl.Tasks)
                .HasForeignKey(ti => ti.TaskListId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
