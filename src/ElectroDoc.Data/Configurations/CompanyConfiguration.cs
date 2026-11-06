using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> b)
    {
        b.ToTable("company");
        b.Property(e => e.Name).HasMaxLength(500);
        b.HasOne(e => e.Status)
            .WithMany(c => c.Companies)
            .HasForeignKey(e => e.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}