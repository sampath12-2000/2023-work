using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class InvoiceRepository : IInvoiceRepository<Invoice>
    {
        private readonly CropDealDatabaseContext _dbContext;
        public InvoiceRepository(CropDealDatabaseContext dbContext) => this._dbContext = dbContext;

        #region GetById
        public async Task<Invoice> GetById(int id)
        {
            try
            {
                var invoice = await _dbContext.Invoices.Where(i => i.InvoiceId == id).Select(i => new Invoice()
                {
                    InvoiceId = i.InvoiceId,
                    OrderDate = i.OrderDate,
                    FarmerId = i.FarmerId,
                    DealerId = i.DealerId,
                    CropName = i.CropName,
                    CropQty = i.CropQty,
                    OrderTotal = i.OrderTotal,
                    Review = i.Review
                }).FirstOrDefaultAsync();
                return invoice;
            }
            catch
            {
                throw;
            }
            //  throw new NotImplementedException();
        }
        #endregion

        #region Edit

        public async Task<Invoice> Edit(Invoice entity)
        {
            try
            {
                var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(i => i.InvoiceId == entity.InvoiceId);
                if (invoice != null)
                {
                    invoice.InvoiceId = entity.InvoiceId;
                    invoice.OrderDate = entity.OrderDate;
                    invoice.FarmerId = entity.FarmerId;
                    invoice.DealerId = entity.DealerId;
                    invoice.CropName = entity.CropName;
                    invoice.CropQty = entity.CropQty;
                    invoice.OrderTotal = entity.OrderTotal;
                    invoice.Review = entity.Review;
                    _dbContext.SaveChanges();
                }
                return invoice;
            }
            catch
            {
                return null;
            }
            // throw new NotImplementedException();
        }

        #endregion

        #region Delete

        public async Task Delete(int id)
        {
            try
            {
                var invoice = new Invoice() { InvoiceId = id };
                _dbContext.Invoices.Remove(invoice);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
            //  throw new NotImplementedException();
        }

        #endregion
    }
}
