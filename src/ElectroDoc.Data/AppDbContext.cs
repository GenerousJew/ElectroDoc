using Microsoft.EntityFrameworkCore;

namespace ElectroDoc.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Membership> Memberships => Set<Membership>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<MembershipPermission> MembershipPermissions => Set<MembershipPermission>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<DocumentFile> DocumentFiles => Set<DocumentFile>();
    public DbSet<DocumentStatus> DocumentStatuses => Set<DocumentStatus>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<DocumentHistory> DocumentHistories => Set<DocumentHistory>();
    public DbSet<DocumentHistoryAction> DocumentHistoryActions => Set<DocumentHistoryAction>();
    public DbSet<PermissionHistory> PermissionHistories => Set<PermissionHistory>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.HasPostgresExtension("citext").ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}