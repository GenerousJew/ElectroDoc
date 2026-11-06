namespace ElectroDoc.Data;

public class MembershipRole
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Membership> Memberships { get; set; } = [];
}