using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;
using BetteRFlow.Shared.Data;

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

        [HttpPost]
        public async Task<IActionResult> CreateFormSubmission([FromBody] FormDto formDto)
        {
            try
            {
                var formSubmission = new FormSubmission
                {
                    // Grunduppgifter
                    Fastighet = formDto.Fastighet,
                    Organisationsnummer = formDto.Organisationsnummer,
                    BrfNamn = formDto.BrfNamn,
                    Byggnadsår = formDto.Byggnadsår,
                    AntalLägenheter = formDto.AntalLägenheter,
                    ÄktaBrf = formDto.ÄktaBrf,

                    // Förvaltning
                    EkonomiskFörvaltare = formDto.EkonomiskFörvaltare,
                    FastighetsFörvaltare = formDto.FastighetsFörvaltare,

                    // Medlemskap
                    MedlemskapsRutin = formDto.MedlemskapsRutin,
                    JuridiskPersonFårFörvärva = formDto.JuridiskPersonFårFörvärva,
                    JuridiskPersonKommentar = formDto.JuridiskPersonKommentar,
                    BeslutOmMedlemskap = formDto.BeslutOmMedlemskap,
                    MedlemsansökanSkickasTill = formDto.MedlemsansökanSkickasTill,
                    DelatÄgande = formDto.DelatÄgande,
                    MinstaAndel = formDto.MinstaAndel,
                    Överlåtelseavgift = formDto.Överlåtelseavgift,

                    // Månadsavgift
                    AvgiftInnefattarVärme = formDto.AvgiftInnefattarVärme,
                    AvgiftInnefattarVarmvatten = formDto.AvgiftInnefattarVarmvatten,
                    AvgiftInnefattarKallvatten = formDto.AvgiftInnefattarKallvatten,
                    AvgiftInnefattarKabelTV = formDto.AvgiftInnefattarKabelTV,
                    AvgiftInnefattarBredband = formDto.AvgiftInnefattarBredband,
                    AvgiftInnefattarHemförsäkring = formDto.AvgiftInnefattarHemförsäkring,
                    AvgiftInnefattarKällare = formDto.AvgiftInnefattarKällare,
                    AvgiftInnefattarAnnat = formDto.AvgiftInnefattarAnnat,
                    SenasteAvgiftsförändring = formDto.SenasteAvgiftsförändring,

                    // Bredband och teknik
                    Bredbandsleverantör = formDto.Bredbandsleverantör,
                    Bredbandshastighet = formDto.Bredbandshastighet,
                    BredbandKundservice = formDto.BredbandKundservice,
                    Uppvärmning = formDto.Uppvärmning,
                    Ventilation = formDto.Ventilation,
                    Elavtal = formDto.Elavtal,
                    ElavtalKommentar = formDto.ElavtalKommentar,

                    // Parkering
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

                    // Gemensamma utrymmen
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

                    // Nycklar och överlämning
                    NyckelÖverlämning = formDto.NyckelÖverlämning,
                    VadSkasÖverlämnas = formDto.VadSkasÖverlämnas,
                    AdressNyckelÖverlämning = formDto.AdressNyckelÖverlämning,

                    // Andrahandsuthyrning
                    AndrahandsuthyrningKrävergodkännande = formDto.AndrahandsuthyrningKrävergodkännande,
                    AndrahandsuthyrningAvgift = formDto.AndrahandsuthyrningAvgift,
                    AndrahandsuthyrningAnsökanTill = formDto.AndrahandsuthyrningAnsökanTill,
                    AndrahandsuthyrningVillkorUrl = formDto.AndrahandsuthyrningVillkorUrl,

                    // Reparationer
                    PlanerardeReparationer = formDto.PlanerardeReparationer,
                    Energideklaration = formDto.Energideklaration,
                    EnergideklarationDatum = formDto.EnergideklarationDatum,

                    // Kontakt
                    KontaktEmail = formDto.KontaktEmail,
                    KontaktTelefon = formDto.KontaktTelefon,
                    Hemsida = formDto.Hemsida,

                    // Metadata
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