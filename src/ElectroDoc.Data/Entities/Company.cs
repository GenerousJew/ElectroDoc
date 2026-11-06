namespace ElectroDoc.Data;

public class Company
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int StatusId { get; set; }
    public CompanyStatus Status { get; set; } = null!;
    
    public List<Membership> Memberships { get; set; } = [];
}