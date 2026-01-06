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
            // Fake purchase - ingen riktig betalning
            var purchase = new Purchase
            {
                UserId = 9,              // ✅ Mäklaren
                FormSubmissionId = 7,    // ✅ ID som finns i produktion
                Amount = 299,
                PurchaseDate = DateTime.UtcNow,
                PaymentStatus = "Completed",
                TransactionId = Guid.NewGuid().ToString()
            };



            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Köp genomfört!", purchaseId = purchase.Id });
        }
    }
}