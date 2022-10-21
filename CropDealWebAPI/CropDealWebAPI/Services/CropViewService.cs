using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Services
{
    public class CropViewService
    {
        private IViewCropRepository _repository;
        public CropViewService(IViewCropRepository repository)
        {
            _repository = repository;
        }
        #region viewcrops
        public List<ViewCrop> CropsView()
        {
            return _repository.ViewCrops();
        }
        #endregion
    }
}
