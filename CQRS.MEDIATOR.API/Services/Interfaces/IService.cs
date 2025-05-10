namespace CQRS.MEDIATOR.API.Services.Interfaces
{
    public interface IService<Type> : IDisposable
    {
        Task<Type> GetByIdAsync(long id);
        Task<IEnumerable<Type>> GetAllAsync();
        Task<Type> AddAsync(Type entity);
        Task<Type> UpdateAsync(Type entity);
        Task<bool> DeleteAsync(long id);
    }
}
