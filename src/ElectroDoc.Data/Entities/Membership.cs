namespace ElectroDoc.Data;

public class Membership
{
    public Guid Id { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public DateTime? LeftAt { get; set; }

    public List<MembershipPermission> MembershipPermissions { get; set; } = [];
}