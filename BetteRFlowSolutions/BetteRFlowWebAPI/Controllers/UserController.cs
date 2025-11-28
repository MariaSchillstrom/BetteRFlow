using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // ============================================
        // UpdateUser - Uppdatera användare
        // ============================================

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            // STEG 1: Validera input
            if (!IsValidUser(updatedUser))
            {
                return BadRequest("Ogiltig användardata");
            }

            // STEG 2: Kolla att id matchar
            if (id != updatedUser.Id)
            {
                return BadRequest("ID matchar inte");
            }

            // STEG 3: Uppdatera i databas (hårdkoda för nu)
            updatedUser.UpdatedAt = DateTime.UtcNow;

            // STEG 4: Konvertera till DTO och returnera
            var userDto = new UserDto
            {
                Id = updatedUser.Id,
                Fornamn = updatedUser.Fornamn,
                Efternamn = updatedUser.Efternamn,
                Email = updatedUser.Email,
                Role = updatedUser.Role.ToString(),
                IsActive = updatedUser.IsActive,
                LastLogin = updatedUser.LastLogin
            };

            return Ok(userDto);
        }

        // ============================================
        // GetUserById - Hämta en användare
        // ============================================

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            // TODO: Implementera imorgon
            throw new NotImplementedException();
        }




        // ============================================
        // GetAllUsers - Hämta alla användare hårdkodat 
        // ============================================

        // ============================================
        // GetAllUsers - Hämta alla användare
        // ============================================

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            // STEG 1: Hämta från databas (hårdkoda för nu)
            var users = new List<User>
    {
        new User
        {
            Id = 1,
            Fornamn = "Anna",
            Efternamn = "Andersson",
            Email = "anna@example.com",
            Role = UserRole.Admin,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        },
        new User
        {
            Id = 2,
            Fornamn = "Kalle",
            Efternamn = "Karlsson",
            Email = "kalle@example.com",
            Role = UserRole.BRF,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        }
    };

            // STEG 2: Kolla att det finns användare
            if (users == null || !users.Any())
            {
                return Ok(new List<UserDto>()); // Tom lista
            }

            // STEG 3: Konvertera till DTO
            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                Fornamn = u.Fornamn,
                Efternamn = u.Efternamn,
                Email = u.Email,
                Role = u.Role.ToString(),
                IsActive = u.IsActive,
                LastLogin = u.LastLogin
            }).ToList();

            return Ok(userDtos);
        }



        // ============================================
        // PRIVATE HELPER-METODER
        // ============================================

        private bool IsValidUser(User updatedUser)
        {
            // Kolla att user inte är null
            if (updatedUser == null) return false;

            // Kolla att email finns
            if (string.IsNullOrEmpty(updatedUser.Email)) return false;

            // Kolla att email är giltig
            if (!IsValidEmail(updatedUser.Email)) return false;

            // Kolla att namn finns
            if (string.IsNullOrEmpty(updatedUser.Fornamn)) return false;
            if (string.IsNullOrEmpty(updatedUser.Efternamn)) return false;

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}