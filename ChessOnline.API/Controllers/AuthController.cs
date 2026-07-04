using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChessOnline.API.Data; 
using ChessOnline.API.DTOs;
using ChessOnline.API.Models;

namespace ChessOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto newUserData)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == newUserData.Email.ToLower()))
            {
                return BadRequest("Email is already register");
            }
            if (await _context.Users.AnyAsync(u => u.UserName.ToLower() == newUserData.UserName.ToLower()))
            {
                return BadRequest("This Username is already taken");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newUserData.Password);

            var newUser = new User
            {
                FirstName = newUserData.FirstName,
                LastName = newUserData.LastName,
                UserName = newUserData.UserName,
                Email = newUserData.Email,
                Password = passwordHash,
                Country = newUserData.Country,
                Birthday = newUserData.Birthday.ToUniversalTime(),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok("Success");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == userLoginData.Email.ToLower());
            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userLoginData.Password, user.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(new { message = "Login successful" });
        }
    }
}
