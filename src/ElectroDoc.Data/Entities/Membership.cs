namespace ElectroDoc.Data;

public class Membership
{
    public Guid Id { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    
    public int RoleId { get; set; }
    public MembershipRole Role { get; set; } = null!;
    
    public int StatusId { get; set; }
    public MembershipStatus Status { get; set; } = null!;
}