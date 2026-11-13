namespace ElectroDoc.Data;

public class PermissionHistory
{
    public Guid Id { get; set; }
    public Guid ActorMembershipId { get; set; }
    public Guid TargetMembershipId { get; set; }
    public int PermissionId { get; set; }
    public bool IsGranted { get; set; }
    public DateTime HappenedAt { get; set; }

    public Membership ActorMembership { get; set; } = null!;
    public Membership TargetMembership { get; set; } = null!;
    public Permission Permission { get; set; } = null!;
}