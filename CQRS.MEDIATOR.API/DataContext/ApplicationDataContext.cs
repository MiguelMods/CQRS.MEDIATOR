using Microsoft.EntityFrameworkCore;
using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Models.TodoItem.ModelBuilder;

namespace CQRS.MEDIATOR.API.DataContext
{
    public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
    {
        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoItemModelBuilder());
        }
    }
}