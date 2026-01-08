// BetteRFlowWebAPI/DTOs/UserDto.cs (BACKEND)
using BetteRFlow.Shared.Models;

namespace BetteRFlow.Shared.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;  // ← String, inte UserRole!
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? BrfId { get; set; }
        public Realtor? Realtor { get; set; }
        public string? Firma { get; set; }
    }
    
}