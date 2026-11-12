namespace ElectroDoc.Data;

public class Document
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int StatusId { get; set; }
    public Guid AuthorMembershipId { get; set; }
    public Guid? SenderMembershipId { get; set; }
    public int TypeId { get; set; }
    public int? RecipientCompanyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public DocumentStatus Status { get; set; } = null!;
    public Membership AuthorMembership { get; set; } = null!;
    public Membership? SenderMembership { get; set; }
    public DocumentType Type { get; set; } = null!;
    public Company? RecipientCompany { get; set; }

    public DocumentFile? File { get; set; }
}