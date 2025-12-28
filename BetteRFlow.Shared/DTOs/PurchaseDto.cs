namespace BetteRFlow.Shared.DTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FormSubmissionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public string? TransactionId { get; set; }
    }
}
