public class BrfDto
{
    public int Id { get; set; }
    public string BrfNamn { get; set; } = string.Empty;
    public string OrganisationsNummer { get; set; } = string.Empty;
    public string Gatuadress { get; set; }
    public string Postnummer { get; set; }
    public string Ort { get; set; }
    public string KontaktEmail { get; set; } = string.Empty;
    public string? KontaktTelefon { get; set; }
    public string? Hemsida { get; set; }

    // INGEN CreatedAt, UpdatedAt
    // INGA navigation properties
}