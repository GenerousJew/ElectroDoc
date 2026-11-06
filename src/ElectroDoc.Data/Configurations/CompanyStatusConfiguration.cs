using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class CompanyStatusConfiguration : IEntityTypeConfiguration<CompanyStatus>
{
    public void Configure(EntityTypeBuilder<CompanyStatus> b)
    {
        b.ToTable("company_status");
        b.Property(e => e.Id).ValueGeneratedNever();
        b.Property(e => e.Name).HasMaxLength(250);
        b.HasIndex(e => e.Name).IsUnique();
    }
}

