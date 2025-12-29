using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Data;
using BetteRFlow.Shared.Models;
using ClosedXML.Excel;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrfImportController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public BrfImportController(BetteRFlowContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcel([FromForm] IFormFile file)

        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            try
            {
                using var stream = file.OpenReadStream();
                using var workbook = new XLWorkbook(stream);
                var worksheet = workbook.Worksheet(1);

                var brfs = new List<Brf>();

                // Börja från rad 2 (rad 1 är headers)
                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var brf = new Brf
                    {
                        BrfNamn = row.Cell(1).GetString(),
                        OrganisationsNummer = row.Cell(2).GetString(),
                        KontaktEmail = row.Cell(3).GetString(),
                        KontaktTelefon = row.Cell(4).GetString(),
                        Gatuadress = row.Cell(5).GetString(),
                        Postnummer = row.Cell(6).GetString(),
                        Ort = row.Cell(7).GetString(),
                        Hemsida = row.Cell(8).GetString(),
                        IsActive = true
                    };

                    brfs.Add(brf);
                }

                _context.Brfs.AddRange(brfs);
                await _context.SaveChangesAsync();

                return Ok(new { message = $"{brfs.Count} BRF:er importerade!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
