using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Repositories.Interfaces;
using MediatR;

namespace CQRS.MEDIATOR.API.TodoItems.Queries
{
    public class GetAllTodoItemQuery : IRequest<List<TodoItem>>
    {
    }

    public class GetAllTodoItemQueryHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<GetAllTodoItemQuery, List<TodoItem>>
    {
        private readonly ITodoItemRepository todoItemRepository = todoItemRepository;

        public async Task<List<TodoItem>> Handle(GetAllTodoItemQuery request, CancellationToken cancellationToken)
        {
            return await todoItemRepository.GetAllAsync();
        }
    }

    public class GetTodoItemByIdQuery : IRequest<TodoItem>
    {
        public long Id { get; set; }
    }

    public class GetTodoItemByIdQueryHandler(ITodoItemRepository todoItemRepository) : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
    {
        private readonly ITodoItemRepository todoItemRepository = todoItemRepository;

        public async Task<TodoItem> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            return await todoItemRepository.GetAsync(request.Id);
        }
    }
}
