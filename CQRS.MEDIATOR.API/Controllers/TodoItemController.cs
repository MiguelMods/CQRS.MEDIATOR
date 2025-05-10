using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Services.Interfaces;
using CQRS.MEDIATOR.API.TodoItems.Commands;
using CQRS.MEDIATOR.API.TodoItems.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MEDIATOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(IMediator mediator, ITodoItemService todoItemService) : ControllerBase
    {
        public IMediator Mediator { get; } = mediator;
        public ITodoItemService TodoItemService { get; } = todoItemService;

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var result = await Mediator.Send(new GetAllTodoItemQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            var result = await Mediator.Send(new GetTodoItemByIdQuery { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItem todoItem)
        {
            var result = await Mediator.Send(new CreateTodoItemCommand()
            {
                Title = todoItem.Title,
                Description = todoItem.Description
            });

            return CreatedAtAction(nameof(GetTodoItem), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, [FromBody] TodoItem todoItem)
        {
            var result = await Mediator.Send(new UpdateTodoItemCommand()
            {
                Id = id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                IsComplete = todoItem.IsComplete,
                CompletedAt = todoItem.CompletedAt
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var result = await TodoItemService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
