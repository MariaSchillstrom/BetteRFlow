public class BrfDto
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;
    public string OrganisationsNummer { get; set; } = string.Empty;
    public string OrganisationsAdress { get; set; } = string.Empty;
    public string KontaktEmail { get; set; } = string.Empty;
    public string? KontaktTelefon { get; set; }
    public string? Hemsida { get; set; }

    // INGEN CreatedAt, UpdatedAt
    // INGA navigation properties
}