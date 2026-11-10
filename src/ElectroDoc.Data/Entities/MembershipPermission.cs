namespace ElectroDoc.Data;

public class MembershipPermission
{
    public Guid MembershipId { get; set; }
    public int PermissionId { get; set; }

    public Membership Membership { get; set; } = null!;
    public Permission Permission { get; set; } = null!;
}