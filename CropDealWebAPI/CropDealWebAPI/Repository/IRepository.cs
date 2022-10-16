using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Function Declaration
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
       
        Task<TEntity> Insert(TEntity entity);
       // Task Edit(int id, Crop entity);
        Task<TEntity> Edit(TEntity entity);
       // Task Delete(Crop entity);
       Task Delete(int id);
        Task Save();

        #endregion
    }
}
