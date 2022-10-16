using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CropDealWebAPI.Repository
{
    public class CropRepository : IRepository<Crop>
    {
        private readonly CropDealDatabaseContext _dbContext;
        public CropRepository(CropDealDatabaseContext dbContext) => this._dbContext = dbContext;

        #region Insert
        public async Task<Crop> Insert(Crop entity)
        {
            try
            {
                var crop = new Crop()
                {
                    CropId = entity.CropId,
                    CropName = entity.CropName,
                    CropImage = entity.CropImage
                };
                _dbContext.Crops.Add(crop);
                await _dbContext.SaveChangesAsync();
                return crop;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        #endregion

        #region Delete
        public async Task Delete(int id)
        {
            try
            {
                var crop = new Crop() { CropId = id };
                _dbContext.Crops.Remove(crop);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Edit
        public async Task<Crop> Edit(Crop entity)
        {
            try
            {
                var crop = await _dbContext.Crops.FirstOrDefaultAsync(c => c.CropId == entity.CropId);
                if (crop != null)
                {
                    crop.CropId = entity.CropId;
                    crop.CropName = entity.CropName;
                    crop.CropImage = entity.CropImage;
                    _dbContext.SaveChanges();
                }
                return crop;
            }
            catch
            {
                throw;
            }
          //  throw new NotImplementedException();
            
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<Crop>> GetAll()
        {
            try
            {
                return await _dbContext.Crops.ToListAsync();
                //throw new NotImplementedException();
            }
            catch
            {
                return Enumerable.Empty<Crop>();
            }
        }

        #endregion

        #region GetById
        public async Task<Crop> GetById(int id)
        {
            try
            {
                var crop = await _dbContext.Crops.Where(c => c.CropId == id).Select(c => new Crop()
                {
                    CropId = c.CropId,
                    CropName = c.CropName,
                    CropImage = c.CropImage
                }).FirstOrDefaultAsync();
                return crop;
            }
            catch
            {
                throw;
            }
         //   throw new NotImplementedException();
        }

        #endregion

        #region Save
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        #endregion
    }
}
