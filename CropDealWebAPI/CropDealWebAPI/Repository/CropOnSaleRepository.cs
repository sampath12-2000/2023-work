using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class CropOnSaleRepository : IRepository<CropOnSale>
    {
        private readonly CropDealDatabaseContext _dbContext;
        public CropOnSaleRepository(CropDealDatabaseContext dbContext) => this._dbContext = dbContext;

        #region GetAll
        public async Task<IEnumerable<CropOnSale>> GetAll()
        {
            try
            {
                return await _dbContext.CropOnSales.ToListAsync();
                // throw new NotImplementedException();
            }
            catch
            {
                return Enumerable.Empty<CropOnSale>();
            }
            
        }
#endregion

        #region GetById
        public async Task<CropOnSale> GetById(int id)
        {
            try
            {
                var croponSale = await _dbContext.CropOnSales.Where(c => c.CropSaleId == id).Select(c => new CropOnSale()
                {
                    CropSaleId = c.CropSaleId,
                    CropId = c.CropId,
                    CropName = c.CropName,
                    CropType = c.CropType,
                    CropQty = c.CropQty,
                    CropPrice = c.CropPrice,
                    FarmerId = c.FarmerId


                }).FirstOrDefaultAsync();
                return croponSale;
            }
            catch
            {
                return null;
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region Insert

        public async Task<CropOnSale> Insert(CropOnSale entity)
        {
            try
            {
                var croponSale = new CropOnSale()
                {
                    CropSaleId = entity.CropSaleId,
                    CropId = entity.CropId,
                    CropName = entity.CropName,
                    CropType = entity.CropType,
                    CropQty = entity.CropQty,
                    CropPrice = entity.CropPrice,
                    FarmerId = entity.FarmerId
                };
                _dbContext.CropOnSales.Add(croponSale);
                await _dbContext.SaveChangesAsync();
                return croponSale;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }
        #endregion

        #region Edit
        public async Task<CropOnSale> Edit(CropOnSale entity)
        {
            try
            {
                var croponSale = await _dbContext.CropOnSales.FirstOrDefaultAsync(c => c.CropSaleId == entity.CropSaleId);
                if (croponSale != null)
                {
                    croponSale.CropSaleId = entity.CropSaleId;
                    croponSale.CropId = entity.CropId;
                    croponSale.CropName = entity.CropName;
                    croponSale.CropType = entity.CropType;
                    croponSale.CropQty = entity.CropQty;
                    croponSale.CropPrice = entity.CropPrice;
                    croponSale.FarmerId = entity.FarmerId;

                    _dbContext.SaveChanges();
                    
                }
                return croponSale;
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
                var croponSale = new CropOnSale() { CropSaleId = id };
                _dbContext.CropOnSales.Remove(croponSale);
                await _dbContext.SaveChangesAsync();
                // throw new NotImplementedException();
            }
            catch
            {
                throw;
            }
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
