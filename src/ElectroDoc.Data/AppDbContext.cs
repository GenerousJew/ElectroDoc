using Microsoft.EntityFrameworkCore;

namespace ElectroDoc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<MembershipPermission> MembershipPermissions => Set<MembershipPermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.HasPostgresExtension("citext").ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}