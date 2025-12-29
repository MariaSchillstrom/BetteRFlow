public class BrfDto
{
    public int Id { get; set; }
    public string ForeningensNamn { get; set; } = string.Empty;
    public string OrganisationsNummer { get; set; } = string.Empty;
    public string? Kortnamn { get; set; }  // LÄGG TILL DENNA RAD
    public string Gatuadress { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Ort { get; set; } = string.Empty;
    public string KontaktEmail { get; set; } = string.Empty;
    public string? KontaktTelefon { get; set; }
    public string? Hemsida { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}

    // INGEN CreatedAt, UpdatedAt
    // INGA navigation properties
