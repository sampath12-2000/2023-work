using CropDealWebAPI.Models;
using CropDealWebAPI.Repository;

namespace CropDealWebAPI.Services
{
    public class UserIdService
    {
        IUserIdRepository<int> _repo;
        public UserIdService(IUserIdRepository<int> repo)
        {
            _repo = repo;
        }
        public async Task<int> GetUserId(string item)
        {
            return await _repo.GetUserId(item);
        }
    }
}
