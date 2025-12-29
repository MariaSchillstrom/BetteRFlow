using BetteRFlow.Shared.Models;

public class Brf
{
    public int Id { get; set; }

    // Ändra endast dessa rader:
    public string ForeningensNamn { get; set; } = string.Empty;
    public string OrganisationsNummer { get; set; } = string.Empty;
    public string? Kortnamn { get; set; }
    public string Gatuadress { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Ort { get; set; } = string.Empty;
    public string KontaktEmail { get; set; } = string.Empty;
    public string? KontaktTelefon { get; set; }
    public string? Hemsida { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;

    public ICollection<FormSubmission>? FormSubmissions { get; set; }

    // Formulärstatus
    public bool FormularInskickat { get; set; } = false;
    public DateTime? FormularDatum { get; set; }
    public int? SenasteFormSubmissionId { get; set; }

    // Navigation property för avvikelser
    public ICollection<BrfAvvikelse>? Avvikelser { get; set; }
}