using dotNetAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;//hash password
using System.Security.Cryptography;
using dotNetAPI.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private readonly DotNetApiContext _context;
        private readonly IConfiguration _config;
        public AuthController(DotNetApiContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(UserRegister user)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var u = new Entities.User { Email=user.Email,Name=user.Name,Password=hashed};
            _context.Users.Add(u);    
            _context.SaveChanges();
           
            return Ok(new UserData { Name=user.Name,Email=user.Email,Token=GenerateJWT(u)});
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(UserLogin userLogin)
        {
            var user = _context.Users.Where(user => user.Email == userLogin.Email).First();
            
            if (user == null)
            {
                return Unauthorized();
            }

            bool verified = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
            if (!verified)
            {
                return Unauthorized();
            }
            return Ok(new UserData {Id = user.Id, Name = user.Name, Email = user.Email, Token = GenerateJWT(user) });
        }
        private String GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signatureKey = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                //new Claim (ClaimTypes.Role,"Admin")
                new Claim(ClaimTypes.Role,user.RoleTitle),
                new Claim("IT",user.JobTitle)
            };
            var token = new JwtSecurityToken(
                _config["JWT:Issuer"],//header
                _config["JWT:Audience"],//header
                claims,//payloads
                expires: DateTime.Now.AddHours(2),//them
                signingCredentials:signatureKey// signature
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                var Id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                var user = new UserData
                {
                    Id = Convert.ToInt32(Id),
                    Name = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                };
                return Ok(user);
            }
            return Unauthorized();
        }
    }
}
