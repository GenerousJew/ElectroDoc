using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> b)
    {
        b.ToTable("employee");
        b.Property(e => e.Name).HasMaxLength(200);
        b.Property(e => e.Email).HasMaxLength(254);
        b.Property(e => e.PasswordHash).HasMaxLength(120);
        b.Property(e => e.PhoneNumber).HasMaxLength(32);
        
        b.HasIndex(e => e.Email).IsUnique();
    }
}