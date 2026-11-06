namespace ElectroDoc.Data;

public class Employee
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    
    public List<Membership> Memberships { get; set; } = [];
}