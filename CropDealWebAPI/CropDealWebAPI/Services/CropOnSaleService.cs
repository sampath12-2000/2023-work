using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Services
{
    public class CropOnSaleService
    {
        IRepository<CropOnSale> _repository;
        public CropOnSaleService(IRepository<CropOnSale> repo)
        {
            _repository = repo;
        }

        #region Insert in Service
        public async Task<CropOnSale> Insert(CropOnSale entity)
        {
            return await _repository.Insert(entity);


            //throw new NotImplementedException();
        }
        #endregion

        #region Delete in Service
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            // throw new NotImplementedException();
        }

        #endregion

        #region Edit in service
        public async Task Edit(CropOnSale entity)
        {
            await _repository.Edit(entity);
            //throw new NotImplementedException();
        }

        #endregion

        #region GetAll
        public async Task<IEnumerable<CropOnSale>> GetAll()
        {
            return await _repository.GetAll();
            //throw new NotImplementedException();
        }

        #endregion

        #region GetById
        public async Task<CropOnSale> GetById(int id)
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
