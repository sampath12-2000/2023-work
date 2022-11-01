namespace CropDealWebAPI.Repository
{
    public interface IUserIdRepository<TKey>
    {
        Task<int> GetUserId(string item);
    }
}
