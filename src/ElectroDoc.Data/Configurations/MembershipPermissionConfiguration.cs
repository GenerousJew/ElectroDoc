using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class MembershipPermissionConfiguration : IEntityTypeConfiguration<MembershipPermission>
{
    public void Configure(EntityTypeBuilder<MembershipPermission> b)
    {
        b.ToTable("membership_permission");
        b.HasKey(e => new { e.MembershipId, e.PermissionId });
        b.HasOne(e => e.Membership)
            .WithMany(c => c.MembershipPermissions)
            .HasForeignKey(e => e.MembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.Permission)
            .WithMany(c => c.MembershipPermissions)
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}