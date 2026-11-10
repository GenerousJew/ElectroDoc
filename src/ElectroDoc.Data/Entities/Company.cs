namespace ElectroDoc.Data;

public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime? ClosedAt { get; set; }

    public List<Membership> Memberships { get; set; } = [];
}