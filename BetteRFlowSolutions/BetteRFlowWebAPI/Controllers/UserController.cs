using Microsoft.AspNetCore.Mvc;
using BetteRFlow.Shared.Models;
using BetteRFlow.Shared.DTOs;
using BetteRFlow.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace BetteRFlowWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly BetteRFlowContext _context;

        public UserController(BetteRFlowContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                return Ok(new List<UserDto>());
            }

            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Fornamn = user.Fornamn,
                Efternamn = user.Efternamn,
                Email = user.Email,
                Role = user.Role.ToString(),
                IsActive = user.IsActive,
                LastLogin = user.LastLogin
            });

            return Ok(userDtos);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Användare med ID {id} hittades inte");
            }

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

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!IsValidUser(updatedUser))
            {
                return BadRequest("Ogiltig användardata");
            }

            if (id != updatedUser.Id)
            {
                return BadRequest("ID matchar inte");
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Användare med ID {id} hittades inte");
            }

            user.Fornamn = updatedUser.Fornamn;
            user.Efternamn = updatedUser.Efternamn;
            user.Email = updatedUser.Email;
            user.UpdatedAt = DateTime.UtcNow;

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

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Ogiltigt ID");
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"Användare med ID {id} hittades inte");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Helper methods
        private bool IsValidUser(User updatedUser)
        {
            if (updatedUser == null) return false;
            if (string.IsNullOrEmpty(updatedUser.Email)) return false;
            if (!IsValidEmail(updatedUser.Email)) return false;
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