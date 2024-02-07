using BigBoars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBoars.EntityFramework.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<HealingEvent> HealingEvents { get; set; }
    public DbSet<HealingEventType> HealingEventTypes { get; set; }
    public DbSet<Hospitalization> Hospitalizations { get; set; }
    public DbSet<HospitalizationCondition> HospitalizationConditions { get; set; }
    public DbSet<MedicalCard> MedicalCards { get; set; }
    public DbSet<RequestVisitation> RequestVisitations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserCredentials> UserCredentials { get; set; }
    public DbSet<UserInfo> UserInfos { get; set; }
    public DbSet<Visitation> Visitations { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(new Role[]
        {
            new Role { Id = 1, Name = "admin" },
            new Role { Id = 2, Name = "moderator" },
            new Role { Id = 3, Name = "medic" },
            new Role { Id = 4, Name = "user" },
        });

        modelBuilder.Entity<Gender>().HasData(new Gender[]
        {
            new Gender { Id = 1, Name = "male" },
            new Gender { Id = 2, Name = "female" }
        });

        modelBuilder.Entity<Status>().HasData(new Status[]
        {
            new Status { Id = 1, Name = "reject" },
            new Status { Id = 2, Name = "accept" },
            new Status { Id = 3, Name = "waiting" },
            new Status { Id = 4, Name = "complete" },
        });
    }
}
