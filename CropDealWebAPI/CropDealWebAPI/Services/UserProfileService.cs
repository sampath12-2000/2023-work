using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Services
{
    public class UserProfileService 
    {
        IUserRepository<UserProfile> _repository;
        public UserProfileService(IUserRepository<UserProfile> repo)
        {
            _repository=repo;
        }

        #region Register
        public async Task<UserProfile> Register(UserProfile entity)
        {
            return await _repository.Register(entity);


            //throw new NotImplementedException();
        }
        #endregion

        #region GetById
        public async Task<UserProfile> GetById(int id)
        {
            return await _repository.GetById(id);
            //throw new NotImplementedException();
        }

        #endregion

        #region Update
        public async Task Update(UserProfile entity)
        {
             await _repository.Update(entity);
            //throw new NotImplementedException();
        }
        #endregion

        #region Save
        public async Task Save()
        {
             await _repository.Save();
           // throw new NotImplementedException();
        }
        #endregion
    }
}
