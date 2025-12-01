using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Konvertera "Maklare" (från UI) → UserRole.Realtor (i kod)
            UserRole userRole = registerDto.Role == "Realtor" ? UserRole.Realtor : UserRole.BRF;

            var user = new User
            {
                Fornamn = registerDto.Fornamn,
                Efternamn = registerDto.Efternamn,
                Email = registerDto.Email,
                PasswordHash = HashPassword(registerDto.Password),
                Role = userRole,
                Firma = registerDto.Firma,
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            user.Id = 1; // Simulera

            var userDto = new UserDto
            {
                Id = user.Id,
                Fornamn = user.Fornamn,
                Efternamn = user.Efternamn,
                Email = user.Email,
                Role = user.Role.ToString(),
                IsActive = user.IsActive
            };

            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Hårdkodat för test
            var user = new User
            {
                Id = 1,
                Fornamn = "Test",
                Efternamn = "Testsson",
                Email = loginDto.Email,
                PasswordHash = HashPassword("test123"),
                Role = UserRole.BRF,
                IsActive = true
            };

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized("Fel email eller lösenord");
            }

            user.LastLogin = DateTime.UtcNow;

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

        private string HashPassword(string password)
        {
            return password; // TILLFÄLLIGT
        }

        private bool VerifyPassword(string password, string hash)
        {
            return password == hash; // TILLFÄLLIGT
        }
    }
}


