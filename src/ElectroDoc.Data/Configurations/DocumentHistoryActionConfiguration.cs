using ElectroDoc.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectroDoc.Data.Configurations;

public class DocumentHistoryActionConfiguration : IEntityTypeConfiguration<DocumentHistoryAction>
{
    public void Configure(EntityTypeBuilder<DocumentHistoryAction> b)
    {
        b.ToTable("document_history_action");
        b.HasIndex(e => e.Name).IsUnique();
        b.Property(e => e.Name).HasMaxLength(150);
        b.Property(e => e.Id).ValueGeneratedNever();
        b.HasData(Enum.GetValues<DocumentHistoryActionId>()
            .Select(x => new DocumentHistoryAction() { Id = (int)x, Name = x.ToString() }));
    }
}