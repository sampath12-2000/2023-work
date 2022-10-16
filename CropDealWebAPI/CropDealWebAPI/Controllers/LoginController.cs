using CropDealWebAPI.Controllers;
using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _configuration;
        private readonly CropDealDatabaseContext _dbContext;
        public LoginController(IConfiguration configuration, CropDealDatabaseContext dBContext)
        {
            _configuration = configuration;
            _dbContext = dBContext;
        }

        #region Login part
        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            
                var user = Authenticate(login);
                if (user != null)
                {
                    var token = Generate(user);
                    var obj = new { Token = token };
                    return Ok(obj);

                }
            
            
            return BadRequest();
        }
        #endregion

        #region authenticate part
        private UserProfile Authenticate(Login login)
        {
           
                var CurrentUser = _dbContext.UserProfiles.FirstOrDefault(
                    u => u.UserName == login.Username
                    && u.UserPassword == login.Password);
                if (CurrentUser != null)
                {
                    return CurrentUser;
                }
                return null;
            
            
        }

        #endregion

        #region Generate token
        private string Generate(UserProfile user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,user.UserEmail),
                new Claim(ClaimTypes.NameIdentifier,user.UserPassword),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role,user.UserType)
            };
            var token = new JwtSecurityToken(_configuration["JWT:Issuer"],
                                             _configuration["JWT:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        #endregion
    }
}



