using System.ComponentModel.DataAnnotations;

namespace BetteRFlow.Shared.Models;

public class Form
{
    // Databas-specifika fält
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public int? BrfId { get; set; }
    public Brf? Brf { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    // 🏢 FASTIGHET
    [Required(ErrorMessage = "Fastighetsbeteckning är obligatorisk")]
    public string Fastighetsbeteckning { get; set; } = string.Empty;

    public string Fastighetsadress { get; set; } = string.Empty;
    public string FastighetsPostnummer { get; set; } = string.Empty;
    public string FastighetsOrt { get; set; } = string.Empty;

    // 🏛️ FÖRENING
    [Required(ErrorMessage = "Föreningens juridiska namn är obligatoriskt")]
    public string ForeningensNamn { get; set; } = string.Empty;

    public string? Kortnamn { get; set; }

    [Required(ErrorMessage = "Organisationsnummer är obligatoriskt")]
    public string OrganisationsNummer { get; set; } = string.Empty;  // MED S!

    public string Gatuadress { get; set; } = string.Empty;
    public string Postnummer { get; set; } = string.Empty;
    public string Ort { get; set; } = string.Empty;


    // Kontakt (matchar Brf)
    public string KontaktEmail { get; set; } = string.Empty;
    public string? KontaktTelefon { get; set; }
    public string? Hemsida { get; set; }




    public int? Byggnadsår { get; set; }
    public int? AntalLägenheter { get; set; }
    public bool ÄktaBrf { get; set; }

    // Förvaltning
    public string EkonomiskFörvaltare { get; set; } = string.Empty;
    public string FastighetsFörvaltare { get; set; } = string.Empty;

    // Medlemskap
    public string MedlemskapsRutin { get; set; } = string.Empty;
    public bool JuridiskPersonFårFörvärva { get; set; }
    public string JuridiskPersonKommentar { get; set; } = string.Empty;
    public string BeslutOmMedlemskap { get; set; } = string.Empty;
    public string MedlemsansökanSkickasTill { get; set; } = string.Empty;
    public bool DelatÄgande { get; set; }
    public string MinstaAndel { get; set; } = string.Empty;
    public decimal? Överlåtelseavgift { get; set; }

    // Månadsavgift
    public bool AvgiftInnefattarVärme { get; set; }
    public bool AvgiftInnefattarVarmvatten { get; set; }
    public bool AvgiftInnefattarKallvatten { get; set; }
    public bool AvgiftInnefattarKabelTV { get; set; }
    public bool AvgiftInnefattarBredband { get; set; }
    public bool AvgiftInnefattarHemförsäkring { get; set; }
    public bool AvgiftInnefattarKällare { get; set; }
    public string AvgiftInnefattarAnnat { get; set; } = string.Empty;
    public string SenasteAvgiftsförändring { get; set; } = string.Empty;

    // Bredband och teknik
    public string Bredbandsleverantör { get; set; } = string.Empty;
    public string Bredbandshastighet { get; set; } = string.Empty;
    public string BredbandKundservice { get; set; } = string.Empty;
    public string Uppvärmning { get; set; } = string.Empty;
    public string Ventilation { get; set; } = string.Empty;
    public string Elavtal { get; set; } = string.Empty;
    public string ElavtalKommentar { get; set; } = string.Empty;

    // Parkering
    public int? AntalGarageplatser { get; set; }
    public int? AntalParkeringsplatser { get; set; }
    public int? AntalLaddplatser { get; set; }
    public decimal? FriHöjdGarage { get; set; }
    public bool ElplintarPåMark { get; set; }
    public decimal? KostnadParkeringsplats { get; set; }
    public decimal? KostnadGarageplats { get; set; }
    public decimal? KostnadGarageplatsElektricitet { get; set; }
    public string Laddkostnad { get; set; } = string.Empty;
    public string ParkeringKontakt { get; set; } = string.Empty;

    // Gemensamma utrymmen
    public bool Cykelförråd { get; set; }
    public bool Barnvagnsförråd { get; set; }
    public bool Gästlägenhet { get; set; }
    public bool Tvättstuga { get; set; }
    public bool Bastu { get; set; }
    public bool Gym { get; set; }
    public bool Festlokal { get; set; }
    public string GemensammaUtrymmennAnnat { get; set; } = string.Empty;
    public string ExtraLokaler { get; set; } = string.Empty;
    public string ExtraLokalerKommentar { get; set; } = string.Empty;
    public string StädningGemensamma { get; set; } = string.Empty;

    // Nycklar och överlämning
    public string NyckelÖverlämning { get; set; } = string.Empty;
    public string VadSkasÖverlämnas { get; set; } = string.Empty;
    public string AdressNyckelÖverlämning { get; set; } = string.Empty;

    // Andrahandsuthyrning
    public bool AndrahandsuthyrningKrävergodkännande { get; set; }
    public string AndrahandsuthyrningAvgift { get; set; } = string.Empty;
    public string AndrahandsuthyrningAnsökanTill { get; set; } = string.Empty;
    public string AndrahandsuthyrningVillkorUrl { get; set; } = string.Empty;

    // Reparationer
    public string PlanerardeReparationer { get; set; } = string.Empty;
    public bool Energideklaration { get; set; }
    public string EnergideklarationDatum { get; set; } = string.Empty;
}

    // Kontakt
   