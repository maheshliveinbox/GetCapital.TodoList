using System.Threading.Tasks;
using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Services.TodoItem;
using Microsoft.AspNetCore.Mvc;

namespace GetCapital.TodoList.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemsController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public async Task<IActionResult> Get()
        {
            return Ok(await _todoItemService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            return Ok(await _todoItemService.GetItemAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddTodoItemDto item)
        {
            return Ok(await _todoItemService.AddTodoItemAsync(item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var response = await _todoItemService.MarkAsCompleted(id);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(await _todoItemService.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var response = await _todoItemService.Delete(id);
            if (response.Data == null)
                return BadRequest(response);
            return Ok(await _todoItemService.GetAllAsync());
        }
    }
}
