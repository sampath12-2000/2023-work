using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Services
{
    public class InvoiceService
    {
        IInvoiceRepository<Invoice> _repository;
        public InvoiceService(IInvoiceRepository<Invoice> repo)
        {
            _repository = repo;
        }

        #region GetById
        public async Task<Invoice> GetById(int id)
        {
            return await _repository.GetById(id);
            //   throw new NotImplementedException();
        }
        #endregion

        #region Edit
        public async Task Edit(Invoice entity)
        {
            await _repository.Edit(entity);
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

        #region Save
        public async Task Save()
        {
            await _repository.Save();
            //throw new NotImplementedException();
        }
        #endregion
    }
}
