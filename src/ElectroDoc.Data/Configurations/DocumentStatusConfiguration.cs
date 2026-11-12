using ElectroDoc.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentStatusConfiguration : IEntityTypeConfiguration<DocumentStatus>
{
    public void Configure(EntityTypeBuilder<DocumentStatus> b)
    {
        b.ToTable("document_status");
        b.Property(e => e.Id).ValueGeneratedNever();
        b.Property(e => e.Name).HasMaxLength(150);
        b.HasIndex(e => e.Name).IsUnique();
        b.HasData(Enum.GetValues<DocumentStatusId>().Select(e => new DocumentStatus() { Id = (int)e, Name = e.ToString() }));
    }    
}