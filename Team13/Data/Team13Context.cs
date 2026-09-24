using Microsoft.EntityFrameworkCore;
using TaskEntity = Team13.Models.Task;

namespace Team13.Data;

public class Team13Context(DbContextOptions<Team13Context> options) : DbContext(options)
{
    public DbSet<Team13.Models.Project> Projects => Set<Team13.Models.Project>();

    public DbSet<Team13.Models.User> Users => Set<Team13.Models.User>();

    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskEntity>(task =>
        {
            task.HasOne(item => item.Project)
                .WithMany(project => project.Tasks)
                .HasForeignKey(item => item.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            task.HasOne(item => item.AssignedUser)
                .WithMany(user => user.AssignedTasks)
                .HasForeignKey(item => item.AssignedTo)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}