using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;
using BetteRFlow.Shared.Data;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrfController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        // ============================================
        // KONSTRUKTOR - Dependency Injection
        // ============================================
        public BrfController(BetteRFlowContext context)
        {
            _context = context;
        }

        // ============================================
        // CreateBrf - Skapa ny BRF
        // ============================================
        [HttpPost]
        public async Task<ActionResult<BrfDto>> CreateBrf([FromBody] Brf newBrf)
        {
            // STEG 1: Validera input
            if (!IsValidBrf(newBrf))
            {
                return BadRequest("Ogiltig BRF-data");
            }

            // STEG 2: Sätt tidsstämplar
            newBrf.CreatedAt = DateTime.UtcNow;
            newBrf.UpdatedAt = DateTime.UtcNow;
            newBrf.IsActive = true;

            // STEG 3: Spara i databas
            _context.Brfs.Add(newBrf);
            await _context.SaveChangesAsync();

            // STEG 4: Konvertera till DTO och returnera
            var brfDto = new BrfDto
            {
                Id = newBrf.Id,
                ForeningensNamn = newBrf.ForeningensNamn,
                OrganisationsNummer = newBrf.OrganisationsNummer,
                Gatuadress = newBrf.Gatuadress,
                KontaktEmail = newBrf.KontaktEmail,
                KontaktTelefon = newBrf.KontaktTelefon,
                Hemsida = newBrf.Hemsida
            };

            return CreatedAtAction(nameof(GetBrfById), new { id = brfDto.Id }, brfDto);
        }

        // ============================================
        // GetBrfById - Hämta en BRF
        // ============================================
        [HttpGet("{id}")]
        public async Task<ActionResult<BrfDto>> GetBrfById(int id)
        {
            // STEG 1: Validera id
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            // STEG 2: Hämta från databas
            var brf = await _context.Brfs.FindAsync(id);

            // STEG 3: Kolla att BRF finns
            if (brf == null)
            {
                return NotFound($"BRF med ID {id} hittades inte");
            }

            // STEG 4: Konvertera till DTO
            var brfDto = new BrfDto
            {
                Id = brf.Id,
                ForeningensNamn = brf.ForeningensNamn,
                OrganisationsNummer = brf.OrganisationsNummer,
                Gatuadress = brf.Gatuadress,
                KontaktEmail = brf.KontaktEmail,
                KontaktTelefon = brf.KontaktTelefon,
                Hemsida = brf.Hemsida
            };

            return Ok(brfDto);
        }

        // ============================================
        // GetAllBrfs - Hämta alla BRF:er
        // ============================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrfDto>>> GetAllBrfs()
        {
            // HÄMTA ALLA BRF:er (både aktiva och inaktiva)
            var brfs = await _context.Brfs.ToListAsync();

            // Konvertera till DTO
            var brfDtos = brfs.Select(b => new BrfDto
            {
                Id = b.Id,
                ForeningensNamn = b.ForeningensNamn,
                OrganisationsNummer = b.OrganisationsNummer,
                Gatuadress = b.Gatuadress,
                KontaktEmail = b.KontaktEmail,
                KontaktTelefon = b.KontaktTelefon,
                Hemsida = b.Hemsida,
                IsActive = b.IsActive  // ✅ VIKTIGT: Lägg till denna rad!
            }).ToList();

            return Ok(brfDtos);
        }

        // ============================================
        // UpdateBrf - Uppdatera BRF
        // ============================================
        [HttpPut("{id}")]
        public async Task<ActionResult<BrfDto>> UpdateBrf(int id, [FromBody] Brf updatedBrf)
        {
            // STEG 1: Validera input
            if (!IsValidBrf(updatedBrf))
            {
                return BadRequest("Ogiltig BRF-data");
            }

            // STEG 2: Kolla att id matchar
            if (id != updatedBrf.Id)
            {
                return BadRequest("ID matchar inte");
            }

            // STEG 3: Hämta befintlig BRF från databas
            var existingBrf = await _context.Brfs.FindAsync(id);

            if (existingBrf == null)
            {
                return NotFound($"BRF med ID {id} hittades inte");
            }

            // STEG 4: Uppdatera fält
            existingBrf.ForeningensNamn = updatedBrf.ForeningensNamn;
            existingBrf.OrganisationsNummer = updatedBrf.OrganisationsNummer;
            existingBrf.Gatuadress = updatedBrf.Gatuadress;
            existingBrf.KontaktEmail = updatedBrf.KontaktEmail;
            existingBrf.KontaktTelefon = updatedBrf.KontaktTelefon;
            existingBrf.Hemsida = updatedBrf.Hemsida;
            existingBrf.UpdatedAt = DateTime.UtcNow;

            // STEG 5: Spara i databas
            await _context.SaveChangesAsync();

            // STEG 6: Konvertera till DTO och returnera
            var brfDto = new BrfDto
            {
                Id = existingBrf.Id,
                ForeningensNamn = existingBrf.ForeningensNamn,
                OrganisationsNummer = existingBrf.OrganisationsNummer,
                Gatuadress = existingBrf.Gatuadress,
                KontaktEmail = existingBrf.KontaktEmail,
                KontaktTelefon = existingBrf.KontaktTelefon,
                Hemsida = existingBrf.Hemsida
            };

            return Ok(brfDto);
        }

        // ============================================
        // DeleteBrfById - Ta bort en BRF
        // ============================================
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrfById(int id)
        {
            // STEG 1: Validera id
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            // STEG 2: Hämta BRF från databas
            var brf = await _context.Brfs.FindAsync(id);

            if (brf == null)
            {
                return NotFound($"BRF med ID {id} hittades inte");
            }

            // STEG 3: Ta bort från databas
            _context.Brfs.Remove(brf);
            await _context.SaveChangesAsync();

            // STEG 4: Returnera 204 No Content (standard för lyckad DELETE)
            return NoContent();
        }

        // ============================================
        // PRIVATE HELPER-METODER
        // ============================================

        private bool IsValidBrf(Brf brf)
        {
            if (brf == null) return false;
            if (string.IsNullOrEmpty(brf.ForeningensNamn)) return false;
            if (string.IsNullOrEmpty(brf.OrganisationsNummer)) return false;
            if (string.IsNullOrEmpty(brf.KontaktEmail)) return false;
            if (!IsValidEmail(brf.KontaktEmail)) return false;
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}