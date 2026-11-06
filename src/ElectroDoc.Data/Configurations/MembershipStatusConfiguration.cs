using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class MembershipStatusConfiguration : IEntityTypeConfiguration<MembershipStatus>
{
    public void Configure(EntityTypeBuilder<MembershipStatus> b)
    {
        b.ToTable("membership_status");
        b.Property(e => e.Id).ValueGeneratedNever();
        b.Property(e => e.Name).HasMaxLength(250);
        b.HasIndex(e => e.Name).IsUnique();
    }
}