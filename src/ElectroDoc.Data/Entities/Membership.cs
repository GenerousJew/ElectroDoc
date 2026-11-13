namespace ElectroDoc.Data;

public class Membership
{
    public Guid Id { get; set; }
    public int CompanyId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime? LeftAt { get; set; }

    public Company Company { get; set; } = null!;
    public Employee Employee { get; set; } = null!;
    public List<MembershipPermission> MembershipPermissions { get; set; } = [];
    public List<Document> CreatedDocuments { get; set; } = [];
    public List<Document> SentDocuments { get; set; } = [];
    public List<DocumentHistory> ActedDocumentEvents  { get; set; } = [];
    public List<PermissionHistory> PerformedPermissionChanges { get; set; } = [];
    public List<PermissionHistory> AffectedPermissionChanges { get; set; } = [];
}