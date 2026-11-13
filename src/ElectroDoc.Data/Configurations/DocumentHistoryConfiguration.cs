using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentHistoryConfiguration : IEntityTypeConfiguration<DocumentHistory>
{
    public void Configure(EntityTypeBuilder<DocumentHistory> b)
    {
        b.ToTable("document_history");
        b.HasOne(e => e.ActorMembership)
            .WithMany(c => c.ActedDocumentEvents)
            .HasForeignKey(e => e.ActorMembershipId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.Document)
            .WithMany(c => c.DocumentHistory)
            .HasForeignKey(e => e.DocumentId)
            .OnDelete(DeleteBehavior.Restrict);
        b.HasOne(e => e.Action)
            .WithMany(c => c.DocumentHistory)
            .HasForeignKey(e => e.ActionId)
            .OnDelete(DeleteBehavior.Restrict);
        b.Property(e => e.Id).ValueGeneratedNever();
        b.HasIndex(e => new { e.DocumentId, e.HappenedAt });
    }
}