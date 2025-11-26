// BetteRFlowWebAPI/DTOs/UserDto.cs (BACKEND)
namespace BetteRFlowWebAPI.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Email { get; set; }
        // INGEN PasswordHash här! ← Detta är poängen!
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? BrfId { get; set; }
        public string? Firma { get; set; }
        public string? Kundnummer { get; set; }

        // Bonus: Computed property
        public string FullName => $"{Fornamn} {Efternamn}";
    }
}