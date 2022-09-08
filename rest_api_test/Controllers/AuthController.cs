using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace rest_api_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly rest_api_test_db _context;

        public AuthController(IConfiguration configuration, rest_api_test_db context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var userAdmin = "admin";
            var passwordAdmin = "$2a$11$dnFpLforMNxuFSX299u/v.ecNh.gnWsNUJseItN1LJB9BOLzQB4HW";

            var cekPassword = BCrypt.Net.BCrypt.Verify(password, passwordAdmin);

            if (userAdmin != username && cekPassword != true)
            {
                return BadRequest("User Tidak Ditemukan.");
            }

            string token = CreateToken(userAdmin, passwordAdmin);
            return Ok(token);
        }

        private string CreateToken(string username, string password)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
