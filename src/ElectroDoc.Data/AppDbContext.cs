using Microsoft.EntityFrameworkCore;

namespace ElectroDoc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyStatus> CompanyStatuses => Set<CompanyStatus>();
    public DbSet<MembershipRole> MembershipRoles => Set<MembershipRole>();
    public DbSet<MembershipStatus> MembershipStatuses => Set<MembershipStatus>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}