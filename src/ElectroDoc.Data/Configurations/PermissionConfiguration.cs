using ElectroDoc.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> b)
    {
        b.ToTable("permission");
        b.Property(e => e.Id).ValueGeneratedNever();
        b.Property(e => e.Name).HasMaxLength(150);
        b.HasIndex(e => e.Name).IsUnique();
        b.HasData(Enum.GetValues<PermissionId>().Select(x => new Permission(){Id = (int)x, Name = x.ToString()}));
    }
}