using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CropDealWebAPI.Models;


namespace CropDealWebAPI.Repository
{
    public interface IUserRepository<T1> where T1 : class
    {
        #region Function Declaration
        Task<T1> Register(T1 entity);
        Task<T1> GetById(int id);
        Task<T1> Update(T1 entity);
        Task Save();
        #endregion
    }
}
