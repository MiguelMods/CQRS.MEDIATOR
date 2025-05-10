using System.Linq.Expressions;
using CQRS.MEDIATOR.API.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.API.Repositories.Interfaces
{
    public interface IGenericRepository<Type> where Type : class
    {
        Task<IEnumerable<Type>> GetAllAsync();
        Task<Type?> GetByAsync(Expression<Func<Type, bool>> predicate);
        Task AddAsync(Type entity);
        Task UpdateAsync(Type entity);
        Task DeleteAsync(int id);
    }

    public class GenericRepository<Type>(ApplicationDataContext applicationDataContext) : IGenericRepository<Type> where Type : class
    {
        public ApplicationDataContext ApplicationDataContext { get; } = applicationDataContext;

        public Task AddAsync(Type entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Type>> GetAllAsync()
        {
            return await ApplicationDataContext.Set<Type>().ToListAsync();
        }

        public async Task<Type?> GetByAsync(Expression<Func<Type, bool>> predicate)
        {
            return await ApplicationDataContext.Set<Type>().FirstOrDefaultAsync(predicate);
        }

        public Task UpdateAsync(Type entity)
        {
            throw new NotImplementedException();
        }
    }
}