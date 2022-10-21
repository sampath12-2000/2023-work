using CropDealWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CropDealWebAPI.Repository
{
    public class ViewCropRepository : IViewCropRepository
    {
        private readonly CropDealDatabaseContext _dbContext;
        public ViewCropRepository(CropDealDatabaseContext dbContext) => this._dbContext = dbContext;

        #region ViewCropsAd
        public List<ViewCrop> ViewCrops()
        {
            try
            {

                var query = (from a in _dbContext.CropOnSales
                             join b in _dbContext.Crops on a.CropId equals b.CropId
                             join c in _dbContext.UserProfiles on a.FarmerId equals c.UserId
                             select new ViewCrop()
                             {
                                 CropSaleId = a.CropSaleId,
                                 CropName = a.CropName,
                                 CropType = a.CropType,
                                 CropQty = a.CropQty,
                                 CropPrice = a.CropPrice,
                                 FarmerId = a.FarmerId,
                                 CropImage = b.CropImage,
                                 FarmerAddress = c.UserAddress,
                                 FarmerName = c.UserName,
                                 FarmerPhoneNo = c.UserPhoneNo
                             });

                List<ViewCrop> list1 = query.ToList();


                return list1;
            }
            catch
            {
                return null;
            }



        }
        #endregion
    }
}
