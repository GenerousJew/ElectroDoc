using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> b)
    {
        b.ToTable("document");
        b.Property(e => e.Name).HasMaxLength(500);
        b.HasOne(e => e.Status)
            .WithMany(s => s.Documents)
            .HasForeignKey(e => e.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.AuthorMembership)
            .WithMany(s => s.CreatedDocuments)
            .HasForeignKey(e => e.AuthorMembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.SenderMembership)
            .WithMany(s => s.SentDocuments)
            .HasForeignKey(e => e.SenderMembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.Type)
            .WithMany(s => s.Documents)
            .HasForeignKey(e => e.TypeId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.RecipientCompany)
            .WithMany(s => s.ReceivedDocuments)
            .HasForeignKey(e => e.RecipientCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        b.HasIndex(e => new { e.RecipientCompanyId, e.StatusId });
    }
}