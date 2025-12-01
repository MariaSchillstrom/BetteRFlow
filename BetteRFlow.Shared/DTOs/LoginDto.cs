using System.ComponentModel.DataAnnotations;

namespace BetteRFlow.Shared.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email är obligatorisk")]
        [EmailAddress(ErrorMessage = "Ogiltig email-adress")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lösenord är obligatoriskt")]
        public string Password { get; set; } = string.Empty;
    }
}