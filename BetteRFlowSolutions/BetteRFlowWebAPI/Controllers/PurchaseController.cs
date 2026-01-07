using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Data;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public PurchaseController(BetteRFlowContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchase([FromBody] PurchaseDto purchaseDto)
        {
            try
            {
                var purchase = new Purchase
                {
                    UserId = purchaseDto.UserId,
                    FormSubmissionId = purchaseDto.FormSubmissionId,
                    Amount = purchaseDto.Amount,
                    PurchaseDate = DateTime.UtcNow,
                    PaymentStatus = "Completed",
                    TransactionId = Guid.NewGuid().ToString()
                };

                _context.Purchases.Add(purchase);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Köp genomfört!", purchaseId = purchase.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}