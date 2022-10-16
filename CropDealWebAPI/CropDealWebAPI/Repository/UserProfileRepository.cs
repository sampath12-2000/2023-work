using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class UserProfileRepository : IUserRepository<UserProfile>
    {
        private readonly CropDealDatabaseContext _dbContext;
        public UserProfileRepository(CropDealDatabaseContext dbContext)=>this._dbContext= dbContext;

        #region Register
        public async Task<UserProfile> Register(UserProfile entity)
        {
            try
            {
                var userProfile = new UserProfile()
                {
                    UserId = entity.UserId,
                    UserName = entity.UserName,
                    UserEmail = entity.UserEmail,
                    UserPhoneNo = entity.UserPhoneNo,
                    UserAddress = entity.UserAddress,
                    UserPassword = entity.UserPassword,
                    UserType = entity.UserType,
                    UserAccNo = entity.UserAccNo,
                    UserIfsc = entity.UserIfsc,
                    UserBankName = entity.UserBankName,
                    UserStatus = entity.UserStatus
                };
                _dbContext.UserProfiles.Add(userProfile);
                await _dbContext.SaveChangesAsync();
                return userProfile;
            }
            catch
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        #endregion

        #region GetById
        public async Task<UserProfile> GetById(int id)
        {
            try
            {
                var user = await _dbContext.UserProfiles.Where(u => u.UserId == id).Select(u => new UserProfile()
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    UserEmail = u.UserEmail,
                    UserPhoneNo = u.UserPhoneNo,
                    UserAddress = u.UserAddress,
                    UserPassword = u.UserPassword,
                    UserType = u.UserType,
                    UserAccNo = u.UserAccNo,
                    UserIfsc = u.UserIfsc,
                    UserBankName = u.UserBankName,
                    UserStatus = u.UserStatus
                }).FirstOrDefaultAsync();
                return user;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        #endregion

        #region Update
        public async Task<UserProfile> Update(UserProfile user)
        {
            try
            {
                var user1 = await _dbContext.UserProfiles.FirstOrDefaultAsync(u => u.UserId == user.UserId);
                if (user1 != null)
                {
                    user1.UserName = user.UserName;
                    user1.UserEmail = user.UserEmail;
                    user1.UserPhoneNo = user.UserPhoneNo;
                    user1.UserAddress = user.UserAddress;
                    user1.UserPassword = user.UserPassword;
                    user1.UserType = user.UserType;
                    user1.UserAccNo = user.UserAccNo;
                    user1.UserIfsc = user.UserIfsc;
                    user1.UserBankName = user.UserBankName;
                    user1.UserStatus = user.UserStatus;
                    _dbContext.SaveChanges();

                }

                return user1;
            }
            catch
            {
                throw;
            }
            // throw new NotImplementedException();
        }
        #endregion

        #region Save
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
           // throw new NotImplementedException();
        }
        #endregion
    }
}
