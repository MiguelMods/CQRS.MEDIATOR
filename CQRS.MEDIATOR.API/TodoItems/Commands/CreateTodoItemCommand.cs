using System.Windows.Input;
using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Services.Interfaces;
using MediatR;

namespace CQRS.MEDIATOR.API.TodoItems.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class CreateTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<CreateTodoItemCommand, TodoItem>
    {
        public async Task<TodoItem> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Title = request.Title,
                Description = request.Description
            };
            return await todoItemService.AddAsync(todoItem);
        }
    }

    public class UpdateTodoItemCommand : IRequest<TodoItem>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public class UpdateTodoItemCommandHandler(ITodoItemService todoItemService) : IRequestHandler<UpdateTodoItemCommand, TodoItem>
    {
        public async Task<TodoItem> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description
            };
            return await todoItemService.UpdateAsync(todoItem);
        }
    }
}
