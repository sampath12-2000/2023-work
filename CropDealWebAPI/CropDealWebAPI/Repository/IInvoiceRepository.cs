using System.Threading.Tasks;
using CropDealWebAPI.Models;

namespace CropDealWebAPI.Repository
{
    public interface IInvoiceRepository<TEntity> where TEntity : class

    {
        #region Funtion Declaration
        Task<TEntity> GetById(int id);
        Task<TEntity> Edit(TEntity entity);
        Task Delete(int id);
        Task Save();
        #endregion

    }
}
