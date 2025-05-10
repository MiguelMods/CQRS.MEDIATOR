namespace CQRS.MEDIATOR.API.Repositories.Interfaces
{
    public interface IRepositories<Type> where Type : class
    {
        Task<List<Type>> GetAllAsync();
        Task<Type> GetAsync(long id);
        Task<Type> AddAsync(Type entity);
        Task<Type> UpdateAsync(Type entity);
        Task<bool> DeleteAsync(long id);
    }
}
