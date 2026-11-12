using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentFileConfiguration : IEntityTypeConfiguration<DocumentFile>
{
    public void Configure(EntityTypeBuilder<DocumentFile> b)
    {
        b.ToTable("document_file");
        b.HasOne(e => e.Document)
            .WithOne(e => e.File)
            .HasForeignKey<DocumentFile>(e => e.Id)
            .OnDelete(DeleteBehavior.Restrict);
        b.Property(e => e.ContentType).HasMaxLength(150);
        b.Property(e => e.FileName).HasMaxLength(500);
        b.Property(e => e.SHA256)
            .HasMaxLength(64)
            .IsFixedLength();
        
        b.Property(f => f.Id).ValueGeneratedNever();
    }
}