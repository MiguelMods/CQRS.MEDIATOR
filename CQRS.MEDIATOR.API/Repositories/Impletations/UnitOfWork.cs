using CQRS.MEDIATOR.API.DataContext;
using CQRS.MEDIATOR.API.Repositories.Interfaces;

namespace CQRS.MEDIATOR.API.Repositories.Impletations
{
    public class UnitOfWork(ApplicationDataContext context, ITodoItemRepository todoItemRepository) : IUnitOfWork
    {
        public ITodoItemRepository TodoItemRepository { get; } = todoItemRepository;

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
        public async Task DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
