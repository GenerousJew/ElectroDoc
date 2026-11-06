namespace ElectroDoc.Data;

public class MembershipStatus
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Membership> Memberships { get; set; } = [];
}