using InDBMemory;
using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
    public DbSet<TaskType> Task { get; set; }
    public TaskContext(DbContextOptions options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskType>().HasKey(p => p.ID);
    }
}