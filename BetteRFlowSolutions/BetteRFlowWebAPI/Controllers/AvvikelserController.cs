using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Data;
using BetteRFlow.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvvikelserController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public AvvikelserController(BetteRFlowContext context)
        {
            _context = context;
        }

        [HttpGet("ogranskade")]
        public async Task<ActionResult<List<object>>> GetOgranskaде()
        {
            try
            {
                var avvikelser = await _context.BrfAvvikelser
                    .Include(a => a.Brf)
                    .Where(a => !a.Granskad)
                    .OrderByDescending(a => a.SkapadDatum)
                    .Select(a => new
                    {
                        a.Id,
                        BrfNamn = a.Brf!.ForeningensNamn,
                        a.Faltnamn,
                        a.VardeGrunddata,
                        a.VardeFormular,
                        a.SkapadDatum
                    })
                    .ToListAsync();

                return Ok(avvikelser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/godkann")]
        public async Task<IActionResult> Godkann(int id)
        {
            try
            {
                var avvikelse = await _context.BrfAvvikelser
                    .Include(a => a.Brf)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (avvikelse == null)
                    return NotFound();

                // Uppdatera grunddata med formulärets värde
                var brf = avvikelse.Brf;
                if (brf != null)
                {
                    switch (avvikelse.Faltnamn)
                    {
                        case "ForeningensNamn":
                            brf.ForeningensNamn = avvikelse.VardeFormular;
                            break;
                        case "Gatuadress":
                            brf.Gatuadress = avvikelse.VardeFormular;
                            break;
                        case "Postnummer":
                            brf.Postnummer = avvikelse.VardeFormular;
                            break;
                        case "Ort":
                            brf.Ort = avvikelse.VardeFormular;
                            break;
                        case "KontaktEmail":
                            brf.KontaktEmail = avvikelse.VardeFormular;
                            break;
                        case "KontaktTelefon":
                            brf.KontaktTelefon = avvikelse.VardeFormular;
                            break;
                        case "Hemsida":
                            brf.Hemsida = avvikelse.VardeFormular;
                            break;
                    }

                    brf.UpdatedAt = DateTime.UtcNow;
                }

                // Markera som granskad
                avvikelse.Granskad = true;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Avvikelse godkänd och grunddata uppdaterad" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("{id}/avvisa")]
        public async Task<IActionResult> Avvisa(int id)
        {
            try
            {
                var avvikelse = await _context.BrfAvvikelser.FindAsync(id);

                if (avvikelse == null)
                    return NotFound();

                // Markera som granskad (men uppdatera INTE grunddata)
                avvikelse.Granskad = true;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Avvikelse avvisad, grunddata behålls" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}