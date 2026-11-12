namespace ElectroDoc.Data;

public class DocumentType
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public List<Document> Documents { get; set; } = [];
}