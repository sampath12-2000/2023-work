using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Services
{
    public class CropService
    {
        IRepository<Crop> _repository;
        public CropService(IRepository<Crop> repo)
        {
            _repository = repo;
        }
        #region Insert
        public async Task<Crop> Insert(Crop entity)
        {
           return await _repository.Insert(entity);
            
          
            //throw new NotImplementedException();
        }
        #endregion


        #region Delete
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            // throw new NotImplementedException();
        }

        #endregion

        #region Edit
        public async Task Edit(Crop entity)
        {
             await _repository.Edit(entity);
            //throw new NotImplementedException();
        }

        #endregion

        #region GetAll
        public async Task<IEnumerable<Crop>> GetAll()
        {
            return await _repository.GetAll();
            //throw new NotImplementedException();
        }

        #endregion

        #region GetById

        public async Task<Crop> GetById(int id)
        {
           return await _repository.GetById(id);
            //   throw new NotImplementedException();
        }
        #endregion

        #region Save

        public async Task Save()
        {
            await _repository.Save();
            //throw new NotImplementedException();
        }
        #endregion
    }
}
