// BetteRFlowWebAPI/Models/User.cs (BACKEND)


namespace BetteRFlow.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fornamn { get; set; } = string.Empty;
        public string Efternamn { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }

        // För BRF-användare:
        public int? BrfId { get; set; }
        public Brf? Brf { get; set; }

        // För mäklare:
        public string? Firma { get; set; }       // ← LÄGG TILL!
        public int? RealtorId { get; set; }      // ← 
        public Realtor? Realtor { get; set; }    // ← 
    }
}

    
    

    

