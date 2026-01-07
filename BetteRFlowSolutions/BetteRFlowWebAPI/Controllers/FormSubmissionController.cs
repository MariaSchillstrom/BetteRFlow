using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;
using BetteRFlow.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormSubmissionController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public FormSubmissionController(BetteRFlowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<FormSubmission> GetAllFormSubmissions()
        {
            return _context.FormSubmissions.ToList();
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<FormDto>>> SearchBrf([FromQuery] string? searchTerm)
        {
            try
            {
                IQueryable<FormSubmission> query = _context.FormSubmissions;

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(f =>
                        (f.ForeningensNamn != null && f.ForeningensNamn.Contains(searchTerm)) ||
                        (f.Fastighetsbeteckning != null && f.Fastighetsbeteckning.Contains(searchTerm)) ||
                        (f.OrganisationsNummer != null && f.OrganisationsNummer.Contains(searchTerm))
                    );
                }

                var results = await query.ToListAsync();

                var formDtos = results.Select(f => new FormDto
                {
                    Id = f.Id,
                    Fastighetsbeteckning = f.Fastighetsbeteckning,
                    Fastighetsadress = f.Fastighetsadress,
                    FastighetsPostnummer = f.FastighetsPostnummer,
                    FastighetsOrt = f.FastighetsOrt,
                    OrganisationsNummer = f.OrganisationsNummer,
                    ForeningensNamn = f.ForeningensNamn,
                    Kortnamn = f.Kortnamn,
                    Gatuadress = f.Gatuadress,
                    Postnummer = f.Postnummer,
                    Ort = f.Ort,
                    Byggnadsår = f.Byggnadsår,
                    AntalLägenheter = f.AntalLägenheter,
                    ÄktaBrf = f.ÄktaBrf,
                    EkonomiskFörvaltare = f.EkonomiskFörvaltare,
                    FastighetsFörvaltare = f.FastighetsFörvaltare,
                    MedlemskapsRutin = f.MedlemskapsRutin,
                    JuridiskPersonFårFörvärva = f.JuridiskPersonFårFörvärva,
                    JuridiskPersonKommentar = f.JuridiskPersonKommentar,
                    BeslutOmMedlemskap = f.BeslutOmMedlemskap,
                    MedlemsansökanSkickasTill = f.MedlemsansökanSkickasTill,
                    DelatÄgande = f.DelatÄgande,
                    MinstaAndel = f.MinstaAndel,
                    Överlåtelseavgift = f.Överlåtelseavgift,
                    AvgiftInnefattarVärme = f.AvgiftInnefattarVärme,
                    AvgiftInnefattarVarmvatten = f.AvgiftInnefattarVarmvatten,
                    AvgiftInnefattarKallvatten = f.AvgiftInnefattarKallvatten,
                    AvgiftInnefattarKabelTV = f.AvgiftInnefattarKabelTV,
                    AvgiftInnefattarBredband = f.AvgiftInnefattarBredband,
                    AvgiftInnefattarHemförsäkring = f.AvgiftInnefattarHemförsäkring,
                    AvgiftInnefattarKällare = f.AvgiftInnefattarKällare,
                    AvgiftInnefattarAnnat = f.AvgiftInnefattarAnnat,
                    SenasteAvgiftsförändring = f.SenasteAvgiftsförändring,
                    Bredbandsleverantör = f.Bredbandsleverantör,
                    Bredbandshastighet = f.Bredbandshastighet,
                    BredbandKundservice = f.BredbandKundservice,
                    Uppvärmning = f.Uppvärmning,
                    Ventilation = f.Ventilation,
                    Elavtal = f.Elavtal,
                    ElavtalKommentar = f.ElavtalKommentar,
                    AntalGarageplatser = f.AntalGarageplatser,
                    AntalParkeringsplatser = f.AntalParkeringsplatser,
                    AntalLaddplatser = f.AntalLaddplatser,
                    FriHöjdGarage = f.FriHöjdGarage,
                    ElplintarPåMark = f.ElplintarPåMark,
                    KostnadParkeringsplats = f.KostnadParkeringsplats,
                    KostnadGarageplats = f.KostnadGarageplats,
                    KostnadGarageplatsElektricitet = f.KostnadGarageplatsElektricitet,
                    Laddkostnad = f.Laddkostnad,
                    ParkeringKontakt = f.ParkeringKontakt,
                    Cykelförråd = f.Cykelförråd,
                    Barnvagnsförråd = f.Barnvagnsförråd,
                    Gästlägenhet = f.Gästlägenhet,
                    Tvättstuga = f.Tvättstuga,
                    Bastu = f.Bastu,
                    Gym = f.Gym,
                    Festlokal = f.Festlokal,
                    GemensammaUtrymmennAnnat = f.GemensammaUtrymmennAnnat,
                    ExtraLokaler = f.ExtraLokaler,
                    ExtraLokalerKommentar = f.ExtraLokalerKommentar,
                    StädningGemensamma = f.StädningGemensamma,
                    NyckelÖverlämning = f.NyckelÖverlämning,
                    VadSkasÖverlämnas = f.VadSkasÖverlämnas,
                    AdressNyckelÖverlämning = f.AdressNyckelÖverlämning,
                    AndrahandsuthyrningKrävergodkännande = f.AndrahandsuthyrningKrävergodkännande,
                    AndrahandsuthyrningAvgift = f.AndrahandsuthyrningAvgift,
                    AndrahandsuthyrningAnsökanTill = f.AndrahandsuthyrningAnsökanTill,
                    AndrahandsuthyrningVillkorUrl = f.AndrahandsuthyrningVillkorUrl,
                    PlanerardeReparationer = f.PlanerardeReparationer,
                    Energideklaration = f.Energideklaration,
                    EnergideklarationDatum = f.EnergideklarationDatum,
                    KontaktEmail = f.KontaktEmail,
                    KontaktTelefon = f.KontaktTelefon,
                    Hemsida = f.Hemsida
                }).ToList();

                return Ok(formDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFormSubmission([FromBody] FormDto formDto)
        {
            try
            {
                // 1. Hitta matchande BRF via OrganisationsNummer
                var matchadBrf = await _context.Brfs
                    .FirstOrDefaultAsync(b => b.OrganisationsNummer == formDto.OrganisationsNummer);

                var formSubmission = new FormSubmission
                {
                    BrfId = matchadBrf?.Id,
                    Fastighetsbeteckning = formDto.Fastighetsbeteckning,
                    Fastighetsadress = formDto.Fastighetsadress,
                    FastighetsPostnummer = formDto.FastighetsPostnummer,
                    FastighetsOrt = formDto.FastighetsOrt,
                    OrganisationsNummer = formDto.OrganisationsNummer,
                    ForeningensNamn = formDto.ForeningensNamn,
                    Kortnamn = formDto.Kortnamn,
                    Gatuadress = formDto.Gatuadress,
                    Postnummer = formDto.Postnummer,
                    Ort = formDto.Ort,
                    Byggnadsår = formDto.Byggnadsår,
                    AntalLägenheter = formDto.AntalLägenheter,
                    ÄktaBrf = formDto.ÄktaBrf,
                    EkonomiskFörvaltare = formDto.EkonomiskFörvaltare,
                    FastighetsFörvaltare = formDto.FastighetsFörvaltare,
                    MedlemskapsRutin = formDto.MedlemskapsRutin,
                    JuridiskPersonFårFörvärva = formDto.JuridiskPersonFårFörvärva,
                    JuridiskPersonKommentar = formDto.JuridiskPersonKommentar,
                    BeslutOmMedlemskap = formDto.BeslutOmMedlemskap,
                    MedlemsansökanSkickasTill = formDto.MedlemsansökanSkickasTill,
                    DelatÄgande = formDto.DelatÄgande,
                    MinstaAndel = formDto.MinstaAndel,
                    Överlåtelseavgift = formDto.Överlåtelseavgift,
                    AvgiftInnefattarVärme = formDto.AvgiftInnefattarVärme,
                    AvgiftInnefattarVarmvatten = formDto.AvgiftInnefattarVarmvatten,
                    AvgiftInnefattarKallvatten = formDto.AvgiftInnefattarKallvatten,
                    AvgiftInnefattarKabelTV = formDto.AvgiftInnefattarKabelTV,
                    AvgiftInnefattarBredband = formDto.AvgiftInnefattarBredband,
                    AvgiftInnefattarHemförsäkring = formDto.AvgiftInnefattarHemförsäkring,
                    AvgiftInnefattarKällare = formDto.AvgiftInnefattarKällare,
                    AvgiftInnefattarAnnat = formDto.AvgiftInnefattarAnnat,
                    SenasteAvgiftsförändring = formDto.SenasteAvgiftsförändring,
                    Bredbandsleverantör = formDto.Bredbandsleverantör,
                    Bredbandshastighet = formDto.Bredbandshastighet,
                    BredbandKundservice = formDto.BredbandKundservice,
                    Uppvärmning = formDto.Uppvärmning,
                    Ventilation = formDto.Ventilation,
                    Elavtal = formDto.Elavtal,
                    ElavtalKommentar = formDto.ElavtalKommentar,
                    AntalGarageplatser = formDto.AntalGarageplatser,
                    AntalParkeringsplatser = formDto.AntalParkeringsplatser,
                    AntalLaddplatser = formDto.AntalLaddplatser,
                    FriHöjdGarage = formDto.FriHöjdGarage,
                    ElplintarPåMark = formDto.ElplintarPåMark,
                    KostnadParkeringsplats = formDto.KostnadParkeringsplats,
                    KostnadGarageplats = formDto.KostnadGarageplats,
                    KostnadGarageplatsElektricitet = formDto.KostnadGarageplatsElektricitet,
                    Laddkostnad = formDto.Laddkostnad,
                    ParkeringKontakt = formDto.ParkeringKontakt,
                    Cykelförråd = formDto.Cykelförråd,
                    Barnvagnsförråd = formDto.Barnvagnsförråd,
                    Gästlägenhet = formDto.Gästlägenhet,
                    Tvättstuga = formDto.Tvättstuga,
                    Bastu = formDto.Bastu,
                    Gym = formDto.Gym,
                    Festlokal = formDto.Festlokal,
                    GemensammaUtrymmennAnnat = formDto.GemensammaUtrymmennAnnat,
                    ExtraLokaler = formDto.ExtraLokaler,
                    ExtraLokalerKommentar = formDto.ExtraLokalerKommentar,
                    StädningGemensamma = formDto.StädningGemensamma,
                    NyckelÖverlämning = formDto.NyckelÖverlämning,
                    VadSkasÖverlämnas = formDto.VadSkasÖverlämnas,
                    AdressNyckelÖverlämning = formDto.AdressNyckelÖverlämning,
                    AndrahandsuthyrningKrävergodkännande = formDto.AndrahandsuthyrningKrävergodkännande,
                    AndrahandsuthyrningAvgift = formDto.AndrahandsuthyrningAvgift,
                    AndrahandsuthyrningAnsökanTill = formDto.AndrahandsuthyrningAnsökanTill,
                    AndrahandsuthyrningVillkorUrl = formDto.AndrahandsuthyrningVillkorUrl,
                    PlanerardeReparationer = formDto.PlanerardeReparationer,
                    Energideklaration = formDto.Energideklaration,
                    EnergideklarationDatum = formDto.EnergideklarationDatum,
                    KontaktEmail = formDto.KontaktEmail,
                    KontaktTelefon = formDto.KontaktTelefon,
                    Hemsida = formDto.Hemsida,
                    SubmittedAt = DateTime.UtcNow
                };

                _context.FormSubmissions.Add(formSubmission);
                await _context.SaveChangesAsync();

                // 2. Om matchande BRF hittades, jämför och skapa avvikelser
                if (matchadBrf != null)
                {
                    // Uppdatera status på BRF
                    matchadBrf.FormularInskickat = true;
                    matchadBrf.FormularDatum = DateTime.UtcNow;
                    matchadBrf.SenasteFormSubmissionId = formSubmission.Id;

                    // Jämför fält och logga avvikelser
                    KollaOchLoggaAvvikelser(matchadBrf, formSubmission);

                    await _context.SaveChangesAsync();
                }

                return Ok(new
                {
                    message = "Formulär sparat!",
                    id = formSubmission.Id,
                    brfMatchad = matchadBrf != null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private void KollaOchLoggaAvvikelser(Brf grunddata, FormSubmission formular)
        {
            // Jämför ForeningensNamn
            if (grunddata.ForeningensNamn != formular.ForeningensNamn)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "ForeningensNamn",
                    VardeGrunddata = grunddata.ForeningensNamn,
                    VardeFormular = formular.ForeningensNamn
                });
            }

            // Jämför Gatuadress
            if (grunddata.Gatuadress != formular.Gatuadress)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "Gatuadress",
                    VardeGrunddata = grunddata.Gatuadress,
                    VardeFormular = formular.Gatuadress
                });
            }

            // Jämför Postnummer
            if (grunddata.Postnummer != formular.Postnummer)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "Postnummer",
                    VardeGrunddata = grunddata.Postnummer,
                    VardeFormular = formular.Postnummer
                });
            }

            // Jämför Ort
            if (grunddata.Ort != formular.Ort)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "Ort",
                    VardeGrunddata = grunddata.Ort,
                    VardeFormular = formular.Ort
                });
            }

            // Jämför KontaktEmail
            if (grunddata.KontaktEmail != formular.KontaktEmail)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "KontaktEmail",
                    VardeGrunddata = grunddata.KontaktEmail,
                    VardeFormular = formular.KontaktEmail
                });
            }

            // Jämför KontaktTelefon - normalisera först (fixa null/tom sträng)
            var grunddataTelefon = string.IsNullOrWhiteSpace(grunddata.KontaktTelefon) ? "" : grunddata.KontaktTelefon;
            var formularTelefon = string.IsNullOrWhiteSpace(formular.KontaktTelefon) ? "" : formular.KontaktTelefon;

            if (grunddataTelefon != formularTelefon)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "KontaktTelefon",
                    VardeGrunddata = grunddataTelefon,
                    VardeFormular = formularTelefon
                });
            }

            // Jämför Hemsida - normalisera först (fixa null/tom sträng)
            var grunddataHemsida = string.IsNullOrWhiteSpace(grunddata.Hemsida) ? "" : grunddata.Hemsida;
            var formularHemsida = string.IsNullOrWhiteSpace(formular.Hemsida) ? "" : formular.Hemsida;

            if (grunddataHemsida != formularHemsida)
            {
                _context.BrfAvvikelser.Add(new BrfAvvikelse
                {
                    BrfId = grunddata.Id,
                    FormSubmissionId = formular.Id,
                    Faltnamn = "Hemsida",
                    VardeGrunddata = grunddataHemsida,
                    VardeFormular = formularHemsida
                });
            }
        }
    }
}


