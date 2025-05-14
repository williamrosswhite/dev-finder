using DevFinder.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using DotNetEnv;

namespace DevFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration; // Inject IConfiguration

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration; // Assign IConfiguration
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] AuthDto dto)
        {
            if (dto.ActionType == "login")
            {
                // Login logic
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null)
                    return Unauthorized("Invalid email or password.");

                var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
                if (!result.Succeeded)
                    return Unauthorized("Invalid email or password.");

                // Generate a JWT token
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }
            else if (dto.ActionType == "signup")
            {
                // Sign up logic
                var user = new User
                {
                    UserName = dto.Email, // Use email as the username
                    Email = dto.Email
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);

                return Ok("User registered successfully.");
            }

            return BadRequest("Invalid action type. Use 'login' or 'signup'.");
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Environment.GetEnvironmentVariable("JWT_KEY") 
                ?? throw new InvalidOperationException("JWT signing key is not configured.");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") 
                ?? throw new InvalidOperationException("JWT issuer is not configured.");
            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") 
                ?? throw new InvalidOperationException("JWT audience is not configured.");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}