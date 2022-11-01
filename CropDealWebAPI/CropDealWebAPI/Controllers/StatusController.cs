using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CropDealWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        
       
            private readonly CropDealDatabaseContext _dbcontext;
            public StatusController(CropDealDatabaseContext dbcontext)
            {
                _dbcontext = dbcontext;

            }
            [Authorize(Roles = "Admin")]

            [HttpPost]
            public IActionResult ChangeUserStatus(ChangeStatus user)
            {
                try
                {
                    (from u in _dbcontext.UserProfiles
                     where u.UserId == user.userId
                     select u).ToList()
                            .ForEach(x => x.UserStatus = user.userStatus);

                    _dbcontext.SaveChanges();
                    return Ok();
                }
                catch
                {
                    throw;
                }
            }
        }
    }

