using System;

namespace BetteRFlow.Shared.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        // Vilken mäklare köpte?
        public int UserId { get; set; }
        public User? User { get; set; }

        // Vilket formulär köptes?
        public int FormSubmissionId { get; set; }
        public FormSubmission? FormSubmission { get; set; }

        // Betalning
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        public string PaymentStatus { get; set; } = "Pending";
        public string? TransactionId { get; set; }
    }
}