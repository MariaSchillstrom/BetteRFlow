using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            // STEG 1: Validera input
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

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            // TODO: Implementera
            throw new NotImplementedException();
        }
    

        private bool IsValidUser(User updatedUser)
        {
            // Kolla att user inte är null
            if (updatedUser == null) return false;

            // Kolla att email finns
            if (string.IsNullOrEmpty(updatedUser.Email)) return false;

            // Kolla att email är giltig
            if (!IsValidEmail(updatedUser.Email)) return false;  // ← Röd! Finns inte!

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

