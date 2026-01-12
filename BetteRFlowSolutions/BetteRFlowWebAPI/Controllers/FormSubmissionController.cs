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

        [HttpGet("{id}")]
        public async Task<ActionResult<FormSubmission>> GetFormSubmissionById(int id)
        {
            var formSubmission = await _context.FormSubmissions.FindAsync(id);

            if (formSubmission == null)
                return NotFound();

            return Ok(formSubmission);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<FormDto>>> SearchBrf([FromQuery] string? searchTerm)
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

        [HttpPost]
        public async Task<IActionResult> CreateFormSubmission([FromBody] FormDto formDto)
        {
            try
            {
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

                if (matchadBrf != null)
                {
                    matchadBrf.FormularInskickat = true;
                    matchadBrf.FormularDatum = DateTime.UtcNow;
                    matchadBrf.SenasteFormSubmissionId = formSubmission.Id;

                    KollaOchLoggaAvvikelser(matchadBrf, formSubmission);

                    await _context.SaveChangesAsync();

                    var harOgranskadeAvvikelser = await _context.BrfAvvikelser
                        .AnyAsync(a => a.BrfId == matchadBrf.Id && !a.Granskad);

                    matchadBrf.IsActive = !harOgranskadeAvvikelser;

                    await _context.SaveChangesAsync();
                }

                return Ok(new { message = "Formulär sparat" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        private void KollaOchLoggaAvvikelser(Brf grunddata, FormSubmission formular)
        {
            void Check(string fält, string? g, string? f)
            {
                g = (g ?? "").Trim();
                f = (f ?? "").Trim();

                if (g != f)
                {
                    _context.BrfAvvikelser.Add(new BrfAvvikelse
                    {
                        BrfId = grunddata.Id,
                        FormSubmissionId = formular.Id,
                        Faltnamn = fält,
                        VardeGrunddata = g,
                        VardeFormular = f
                    });
                }
            }

            Check("ForeningensNamn", grunddata.ForeningensNamn, formular.ForeningensNamn);
            Check("Gatuadress", grunddata.Gatuadress, formular.Gatuadress);
            Check("Postnummer", grunddata.Postnummer, formular.Postnummer);
            Check("Ort", grunddata.Ort, formular.Ort);
            Check("KontaktEmail", grunddata.KontaktEmail, formular.KontaktEmail);
            Check("KontaktTelefon", grunddata.KontaktTelefon, formular.KontaktTelefon);
            Check("Hemsida", grunddata.Hemsida, formular.Hemsida);
        }
    }
}
