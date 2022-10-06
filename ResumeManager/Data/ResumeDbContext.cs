using Microsoft.EntityFrameworkCore;
using ResumeManager.Models;

namespace ResumeManager.Data;

public class ResumeDbContext : DbContext
{
    public ResumeDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>().ToTable("Applicant");
        modelBuilder.Entity<Experience>().ToTable("Experience");


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Experience> Experiences { get; set; }


}