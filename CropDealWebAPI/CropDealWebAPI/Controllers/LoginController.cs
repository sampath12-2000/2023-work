using CropDealWebAPI.Controllers;
using CropDealWebAPI.Models;
using CropDealWebAPI.Services;
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
        private readonly UserIdService _userIdService;
        public LoginController(IConfiguration configuration, CropDealDatabaseContext dBContext,UserIdService userIdService)
        {
            _configuration = configuration;
            _dbContext = dBContext;
            _userIdService = userIdService;
        }

        #region Login part
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            int result = await _userIdService.GetUserId(login.Email);
                var user = Authenticate(login);
                if (user != null)
                {
                    var token = Generate(user);
                User user1 = new User();
                user1.token = token;
                user1.UserId = result;
                   // var obj = new { Token = token };

                    return Ok(user1);

                }
            
            
            return BadRequest("credentials are wrong! try again");
        }
        #endregion

        #region authenticate part
        private UserProfile Authenticate(Login login)
        {
           
                var CurrentUser = _dbContext.UserProfiles.FirstOrDefault(
                    u => u.UserEmail == login.Email
                    && u.UserPassword == login.Password && u.UserType==login.Role);
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



