using CQRS.MEDIATOR.API.DataContext;
using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MEDIATOR.API.Repositories.Impletations
{
    public class TodoItemRepository(ApplicationDataContext context) : ITodoItemRepository
    {
        private readonly ApplicationDataContext Context = context;

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await Context.TodoItems.ToListAsync();
        }
        public async Task<TodoItem> GetAsync(long id)
        {
            return await Context.TodoItems.FindAsync(id);
        }
        public async Task<TodoItem> AddAsync(TodoItem entity)
        {
            await Context.TodoItems.AddAsync(entity);
            return entity;
        }
        public async Task<TodoItem> UpdateAsync(TodoItem entity)
        {
            Context.TodoItems.Update(entity);
            return entity;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var todoItem = await GetAsync(id);
            if (todoItem == null) return false;
            Context.TodoItems.Remove(todoItem);
            return true;
        }
    }
}
