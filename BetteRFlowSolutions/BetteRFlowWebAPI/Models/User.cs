namespace BetterFlowWebApp.Models
{
    public enum UserRole
    {
        BRF,
        Maklare,
        Admin
    }

    public class User
    {
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? BrfId { get; set; }
        public string? Firma { get; set; }
        public string? Kundnummer { get; set; }
    }
}

