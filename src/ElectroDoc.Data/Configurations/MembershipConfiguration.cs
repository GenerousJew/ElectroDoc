using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> b)
    {
        b.ToTable("membership");
        
        b.HasIndex(e => new {e.CompanyId, e.EmployeeId}).IsUnique();
        
        b.HasOne(e => e.Company)
            .WithMany(c => c.Memberships)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasOne(e => e.Employee)
            .WithMany(c => c.Memberships)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasOne(e => e.Role)
            .WithMany(c => c.Memberships)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasOne(e => e.Status)
            .WithMany(c => c.Memberships)
            .HasForeignKey(e => e.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}