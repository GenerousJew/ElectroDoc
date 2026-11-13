namespace ElectroDoc.Data;

public class RefreshToken
{
    public Guid  Id { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid SessionId { get; set; }
    public required string Hash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime? RevokedAt { get; set; }

    public Employee Employee { get; set; } = null!;
}