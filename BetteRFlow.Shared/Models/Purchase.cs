using System;

namespace BetteRFlow.Shared.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        // FEJK-KÖP → tillåter null
        public int? UserId { get; set; }

        public int? FormSubmissionId { get; set; }


        public decimal Amount { get; set; }


        public DateTime PurchaseDate { get; set; }

        public string PaymentStatus { get; set; } = "";

        public string TransactionId { get; set; } = "";
    }
}
