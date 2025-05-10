using System.Threading.Tasks;
using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Repositories.Interfaces;
using CQRS.MEDIATOR.API.Services.Interfaces;

namespace CQRS.MEDIATOR.API.Services.Implementations
{
    public class TodoItemService(IUnitOfWork unitOfWork) : ITodoItemService
    {
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;

        public async Task<TodoItem> AddAsync(TodoItem entity)
        {
            var add = await UnitOfWork.TodoItemRepository.AddAsync(entity);
            var result = await UnitOfWork.SaveChangesAsync();
            if (result > 0)
            {
                return add;
            }
            else
            {
                throw new Exception("Error while adding TodoItem");
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entityExist = await UnitOfWork.TodoItemRepository.GetAsync(id) ?? throw new Exception("TodoItem not found");
            return await UnitOfWork.TodoItemRepository.DeleteAsync(entityExist.Id);
        }

        public void Dispose()
        {
            UnitOfWork.DisposeAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await UnitOfWork.TodoItemRepository.GetAllAsync();
        }

        public async Task<TodoItem> GetByIdAsync(long id)
        {
            return await UnitOfWork.TodoItemRepository.GetAsync(id);
        }

        public async Task<TodoItem> UpdateAsync(TodoItem entity)
        {
            var entityExist = await UnitOfWork.TodoItemRepository.GetAsync(entity.Id);

            if (entityExist != null)
            {
                var update = await UnitOfWork.TodoItemRepository.UpdateAsync(entity);
                var result = await UnitOfWork.SaveChangesAsync();
                if (result > 0)
                {
                    return update;
                }
                else
                {
                    throw new Exception("Error while updating TodoItem");
                }
            }
            else
            {
                throw new Exception("TodoItem not found");
            }
        }
    }
}
