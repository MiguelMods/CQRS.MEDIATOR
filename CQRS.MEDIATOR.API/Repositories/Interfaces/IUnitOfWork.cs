namespace CQRS.MEDIATOR.API.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ITodoItemRepository TodoItemRepository { get; }
        Task<int> SaveChangesAsync();
        Task DisposeAsync();
    }
}
