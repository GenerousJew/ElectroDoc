namespace ElectroDoc.Data;

public class DocumentFile
{
    public Guid Id { get; set; }
    public required string ContentType { get; set; }
    public required string FileName { get; set; }
    public long Size { get; set; }
    public required string SHA256 { get; set; }
    public DateTime UploadedAt { get; set; }

    public Document Document { get; set; } = null!;
}