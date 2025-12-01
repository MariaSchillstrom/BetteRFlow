using System.ComponentModel.DataAnnotations;
using BetteRFlow.Shared.Models;

namespace BetteRFlow.Shared.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        public string Fornamn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Efternamn är obligatoriskt")]
        public string Efternamn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email är obligatorisk")]
        [EmailAddress(ErrorMessage = "Ogiltig email-adress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lösenord är obligatoriskt")]
        [MinLength(6, ErrorMessage = "Lösenord måste vara minst 6 tecken")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Välj din roll")]
        public string Role { get; set; } = string.Empty;  // ← INGEN default!

        // Valfritt - endast för mäklare
        public string? Firma { get; set; }
    }
}