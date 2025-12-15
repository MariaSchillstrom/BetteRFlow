using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using BetteRFlow.Shared.Data;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public AuthController(BetteRFlowContext context)
        {
            _context = context;
        }

       [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            // Kolla om det finns några användare i databasen
            bool isFirstUser = !await _context.Users.AnyAsync();
        
            // Första användaren blir ALLTID Admin
            UserRole userRole;
            if (isFirstUser)
            {
                userRole = UserRole.Admin;
            }
            else if (registerDto.Role == "Admin")
            {
                userRole = UserRole.Admin;
            }
            else if (registerDto.Role == "Maklare" || registerDto.Role == "Realtor")
            {
                userRole = UserRole.Realtor;
            }
            else
            {
                userRole = UserRole.BRF;
            }
        
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
        
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        
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

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null)
            {
                return Unauthorized("Fel email eller lösenord");
            }

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized("Fel email eller lösenord");
            }

            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();

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
            return password;
        }

        private bool VerifyPassword(string password, string hash)
        {
            return password == hash;
        }
    }
}