namespace ElectroDoc.Data;

public class DocumentHistoryAction
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public List<DocumentHistory>  DocumentHistory { get; set; } = [];
}