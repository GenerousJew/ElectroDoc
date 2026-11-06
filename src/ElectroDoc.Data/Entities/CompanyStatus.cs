namespace ElectroDoc.Data;

public class CompanyStatus
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<Company> Companies { get; set; } = [];
}