using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Repositories.Interfaces;
using CQRS.MEDIATOR.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MEDIATOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(ITodoItemService todoItemService) : ControllerBase
    {
        public ITodoItemService TodoItemService { get; } = todoItemService;

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await TodoItemService.GetAllAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            var todoItem = await TodoItemService.GetByIdAsync(id);
            if (todoItem == null) return NotFound();
            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItem todoItem)
        {
            if (todoItem == null) return BadRequest();
            var createdTodoItem = await TodoItemService.AddAsync(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = createdTodoItem.Id }, createdTodoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, [FromBody] TodoItem todoItem)
        {
            var result = await TodoItemService.UpdateAsync(todoItem);
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
