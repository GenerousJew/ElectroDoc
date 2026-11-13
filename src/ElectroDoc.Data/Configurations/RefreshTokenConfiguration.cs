using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> b)
    {
        b.ToTable("refresh_token");
        b.HasOne(e => e.Employee)
            .WithMany(c => c.RefreshTokens)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasIndex(e => e.Hash).IsUnique();
        b.HasIndex(e => e.SessionId);
        b.Property(e => e.Hash)
            .HasMaxLength(64)
            .IsFixedLength();
    }
}