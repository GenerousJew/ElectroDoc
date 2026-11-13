using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class PermissionHistoryConfiguration : IEntityTypeConfiguration<PermissionHistory>
{
    public void Configure(EntityTypeBuilder<PermissionHistory> b)
    {
        b.ToTable("permission_history");
        b.HasOne(e => e.ActorMembership)
            .WithMany(e => e.PerformedPermissionChanges)
            .HasForeignKey(e => e.ActorMembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.TargetMembership)
            .WithMany(e => e.AffectedPermissionChanges)
            .HasForeignKey(e => e.TargetMembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.Permission)
            .WithMany(e => e.PermissionHistory)
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasIndex(e => new { e.TargetMembershipId, e.HappenedAt });
    }
}