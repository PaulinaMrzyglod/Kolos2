using Kolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<SeedllingBatch> SeedllingBatches { get; set; }
    public DbSet<TreeSpecies> Trees { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Responsible>()
            .HasKey(r => new {r.EmployeeId, r.BatchId});
        
        modelBuilder.Entity<Responsible>()
            .HasOne(r => r.Employee)
            .WithMany(r => r.Responsibles)
            .HasForeignKey(r => r.EmployeeId);
        
        modelBuilder.Entity<Responsible>()
            .HasOne(r => r.Batch)
            .WithMany(r => r.Responsibles)
            .HasForeignKey(r => r.BatchId);

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Anna",
                LastName = "Kowalska",
                HireDate = new DateTime(2025, 7, 14)
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Nowak",
                HireDate = new DateTime(2025, 5, 25)
            });

        modelBuilder.Entity<Nursery>().HasData(
            new Nursery
            {
                NurseryID = 1,
                Name = "Green Forest Nursery",
                EstablishedDate = new DateTime(2025, 7, 14),
            });

        modelBuilder.Entity<TreeSpecies>().HasData(
            new TreeSpecies
            {
                SpeciesId = 1,
                LatinName = "Latin",
                GrowthTimeInYears = 10
            });

        modelBuilder.Entity<SeedllingBatch>().HasData(
            new SeedllingBatch
            {
                BatchId = 1,
                NurseryId = 1,
                SpeciesId = 1,
                Quantity = 10,
                SownDate = new DateTime(2025, 7, 14),
                ReadyDate = new DateTime(2026, 10, 14),
            });

        modelBuilder.Entity<Responsible>().HasData(
            new Responsible
            {
                BatchId = 1,
                EmployeeId = 1,
                Role = "Supervisor"
            });
    }
}