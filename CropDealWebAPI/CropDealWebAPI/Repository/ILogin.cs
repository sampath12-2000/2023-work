namespace CropDealWebAPI.Repository
{
    public interface ILogin<TEntity> where TEntity : class
    {
        Task<TEntity> Login(int id);

        Task Save();
    }
}
