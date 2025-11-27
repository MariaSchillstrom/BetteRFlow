// BetteRFlowWebAPI/DTOs/UserDto.cs (BACKEND)
using BetteRFlow.Shared.Models;

namespace BetteRFlow.Shared.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? BrfId { get; set; }
        public Realtor? Realtor { get; set; }
    }
    
}