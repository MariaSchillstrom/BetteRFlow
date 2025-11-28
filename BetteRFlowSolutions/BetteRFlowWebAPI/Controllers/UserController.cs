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
            // ============================================
            // GetUserById - Hämta en användare med ID
            // ============================================

            // STEG 1: Validera id
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            // STEG 2: Hämta från databas (hårdkoda för nu)
            // TODO: Senare via repository/DbContext
            var user = new User
            {
                Id = id,
                Fornamn = "Test",
                Efternamn = "Testsson",
                Email = "test@example.com",
                Role = UserRole.BRF,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // STEG 3: Kolla att user finns
            if (user == null)
            {
                return NotFound($"Användare med ID {id} hittades inte");
            }

            // STEG 4: Konvertera till DTO
            var userDto = new UserDto
            {
                Id = user.Id,
                Fornamn = user.Fornamn,
                Efternamn = user.Efternamn,
                Email = user.Email,
                Role = user.Role.ToString(),
                IsActive = user.IsActive,
                LastLogin = user.LastLogin
            };

            return Ok(userDto);
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