using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrfController : ControllerBase
    {
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

            // STEG 3: Uppdatera i databas (hårdkoda för nu)
            updatedBrf.UpdatedAt = DateTime.UtcNow;

            // STEG 4: Konvertera till DTO och returnera
            var brfDto = new BrfDto
            {
                Id = updatedBrf.Id,
                Namn = updatedBrf.Namn,
                OrganisationsNummer = updatedBrf.OrganisationsNummer,
                OrganisationsAdress = updatedBrf.OrganisationsAdress,
                KontaktEmail = updatedBrf.KontaktEmail,
                KontaktTelefon = updatedBrf.KontaktTelefon,
                Hemsida = updatedBrf.Hemsida
            };

            return Ok(brfDto);
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

            // STEG 2: Hämta från databas (hårdkoda för nu)
            var brf = new Brf
            {
                Id = id,
                Namn = "BRF Testgatan",
                OrganisationsNummer = "123456-7890",
                OrganisationsAdress = "Testgatan 1, Stockholm",
                KontaktEmail = "test@brftest.se",
                KontaktTelefon = "070-1234567",
                Hemsida = "https://brftest.se",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // STEG 3: Kolla att BRF finns
            if (brf == null)
            {
                return NotFound($"BRF med ID {id} hittades inte");
            }

            // STEG 4: Konvertera till DTO
            var brfDto = new BrfDto
            {
                Id = brf.Id,
                Namn = brf.Namn,
                OrganisationsNummer = brf.OrganisationsNummer,
                OrganisationsAdress = brf.OrganisationsAdress,
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
            // STEG 1: Hämta från databas (hårdkoda för nu)
            var brfs = new List<Brf>
            {
                new Brf
                {
                    Id = 1,
                    Namn = "BRF Rosendal",
                    OrganisationsNummer = "769630-6856",
                    OrganisationsAdress = "Rosvägen 1, Uppsala",
                    KontaktEmail = "styrelsen@brfrosendal.se",
                    KontaktTelefon = "018-123456",
                    Hemsida = "https://brfrosendal.se",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Brf
                {
                    Id = 2,
                    Namn = "BRF Solbacken",
                    OrganisationsNummer = "556789-1234",
                    OrganisationsAdress = "Solvägen 10, Stockholm",
                    KontaktEmail = "info@brfsolbacken.se",
                    KontaktTelefon = "08-987654",
                    Hemsida = "https://brfsolbacken.se",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            // STEG 2: Kolla att det finns BRF:er
            if (brfs == null || !brfs.Any())
            {
                return Ok(new List<BrfDto>());
            }

            // STEG 3: Konvertera till DTO
            var brfDtos = brfs.Select(b => new BrfDto
            {
                Id = b.Id,
                Namn = b.Namn,
                OrganisationsNummer = b.OrganisationsNummer,
                OrganisationsAdress = b.OrganisationsAdress,
                KontaktEmail = b.KontaktEmail,
                KontaktTelefon = b.KontaktTelefon,
                Hemsida = b.Hemsida
            }).ToList();

            return Ok(brfDtos);
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

            // STEG 2: Kolla att BRF:en finns (hårdkoda för nu)
            // TODO: Senare via repository/DbContext
            var brfExists = true; // Simulerar att BRF:en finns

            if (!brfExists)
            {
                return NotFound($"BRF med ID {id} hittades inte");
            }

            // STEG 3: Ta bort från databas (simulerat för nu)
            // TODO: Senare: await _context.Brfs.Remove(brf); await _context.SaveChangesAsync();

            // STEG 4: Returnera 204 No Content (standard för lyckad DELETE)
            return NoContent();
        }

        // ============================================
        // PRIVATE HELPER-METODER
        // ============================================

        private bool IsValidBrf(Brf updatedBrf)
        {
            if (updatedBrf == null) return false;
            if (string.IsNullOrEmpty(updatedBrf.Namn)) return false;
            if (string.IsNullOrEmpty(updatedBrf.OrganisationsNummer)) return false;
            if (string.IsNullOrEmpty(updatedBrf.KontaktEmail)) return false;
            if (!IsValidEmail(updatedBrf.KontaktEmail)) return false;
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