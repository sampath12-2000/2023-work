using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class UserIdRepository : IUserIdRepository<int>
    {
        private readonly CropDealDatabaseContext _dbContext;
        public UserIdRepository(CropDealDatabaseContext dbContext) => this._dbContext = dbContext;

        #region getuserid
        public async Task<int> GetUserId(string item)
        {
            try
            {
                var userfound = await _dbContext.UserProfiles.SingleOrDefaultAsync(e => e.UserEmail == item);
                if (userfound != null)
                {
                    int userid = userfound.UserId;
                    return userid;
                }
                else
                {
                    return 404;
                }
            }
            catch
            {
                return 404;
            }
        }

        #endregion
    }
}
