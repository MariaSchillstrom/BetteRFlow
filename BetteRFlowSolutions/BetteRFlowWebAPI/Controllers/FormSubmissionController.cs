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
                        (f.BrfNamn != null && f.BrfNamn.Contains(searchTerm)) ||
                        (f.Fastighet != null && f.Fastighet.Contains(searchTerm)) ||
                        (f.Organisationsnummer != null && f.Organisationsnummer.Contains(searchTerm))
                    );
                }

                var results = await query.ToListAsync();

                var formDtos = results.Select(f => new FormDto
                {
                    Id = f.Id,
                    Fastighet = f.Fastighet,
                    Organisationsnummer = f.Organisationsnummer,
                    BrfNamn = f.BrfNamn,
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
                var formSubmission = new FormSubmission
                {
                    Fastighet = formDto.Fastighet,
                    Organisationsnummer = formDto.Organisationsnummer,
                    BrfNamn = formDto.BrfNamn,
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

                return Ok(new { message = "Formulär sparat!", id = formSubmission.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}