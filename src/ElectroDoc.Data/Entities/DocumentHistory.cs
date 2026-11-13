namespace ElectroDoc.Data;

public class DocumentHistory
{
    public Guid Id { get; set; }
    public Guid ActorMembershipId { get; set; }
    public Guid DocumentId { get; set; }
    public int ActionId { get; set; }
    public required DateTime HappenedAt { get; set; }

    public Membership ActorMembership { get; set; } = null!;
    public Document Document { get; set; } = null!;
    public DocumentHistoryAction Action { get; set; } = null!;
}