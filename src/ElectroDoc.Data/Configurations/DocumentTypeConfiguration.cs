using ElectroDoc.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
{
    public void Configure(EntityTypeBuilder<DocumentType> b)
    {
        b.ToTable("document_type");
        b.Property(e => e.Id).ValueGeneratedNever();
        b.Property(e => e.Name).HasMaxLength(150);
        b.HasIndex(e => e.Name).IsUnique();
        b.HasData(Enum.GetValues<DocumentTypeId>().Select(e => new DocumentType() { Id = (int)e, Name = e.ToString() }));
    }
}