using JobFinder.Domain.Entities.Common;
using JobFinder.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Persistence.DbContexts;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
        
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure relationships
        builder.Entity<Vacancy>()
            .HasOne(v => v.Employer)
            .WithMany(u => u.Vacancies)
            .HasForeignKey(v => v.EmployerId);

        builder.Entity<JobApplication>()
            .HasOne(j => j.Employee)
            .WithMany(u => u.JobApplications)
            .HasForeignKey(j => j.EmployeeId);

        builder.Entity<JobApplication>()
            .HasOne(j => j.Vacancy)
            .WithMany(v => v.JobApplications)
            .HasForeignKey(j => j.VacancyId);

        // Set default values and constraints
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                builder.Entity(entityType.ClrType)
                    .Property<DateTime>("CreatedDate")
                    .HasDefaultValueSql("GETDATE()");

                builder.Entity(entityType.ClrType)
                    .Property<DateTime>("UpdatedDate")
                    .HasDefaultValueSql("GETDATE()");
            }
        }
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.EnableSensitiveDataLogging();
        
        base.OnConfiguring(optionsBuilder);
    }
    
    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }
    
    public DbSet<Vacancy> Vacancies { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
}