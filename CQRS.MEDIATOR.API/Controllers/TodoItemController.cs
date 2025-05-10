using CQRS.MEDIATOR.API.Models.TodoItem.Entity;
using CQRS.MEDIATOR.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MEDIATOR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController(IUnitOfWork unitOfWork) : ControllerBase
    {
        public IUnitOfWork UnitOfWork { get; } = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        {
            var todoItems = await UnitOfWork.TodoItemRepository.GetAllAsync();
            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoItem(long id)
        {
            var todoItem = await UnitOfWork.TodoItemRepository.GetAsync(id);
            if (todoItem == null) return NotFound();
            return Ok(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoItem([FromBody] TodoItem todoItem)
        {
            if (todoItem == null) return BadRequest();
            var createdTodoItem = await UnitOfWork.TodoItemRepository.AddAsync(todoItem);
            await UnitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = createdTodoItem.Id }, createdTodoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, [FromBody] TodoItem todoItem)
        {
            if (todoItem == null || todoItem.Id != id) return BadRequest();
            var existingTodoItem = await UnitOfWork.TodoItemRepository.GetAsync(id);
            if (existingTodoItem == null) return NotFound();
            await UnitOfWork.TodoItemRepository.UpdateAsync(todoItem);
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var existingTodoItem = await UnitOfWork.TodoItemRepository.GetAsync(id);
            if (existingTodoItem == null) return NotFound();
            await UnitOfWork.TodoItemRepository.DeleteAsync(id);
            await UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
