using Microsoft.EntityFrameworkCore;
using StudentEventManagementSystem.Models;

namespace StudentEventManagementSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Registration> Registrations { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Registration>()
            .HasKey(r => new { r.StudentId, r.EventId });

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Student)
            .WithMany(s => s.Registrations)
            .HasForeignKey(r => r.StudentId);

        modelBuilder.Entity<Registration>()
            .HasOne(r => r.Event)
            .WithMany(e => e.Registrations)
            .HasForeignKey(r => r.EventId);
    }
}
