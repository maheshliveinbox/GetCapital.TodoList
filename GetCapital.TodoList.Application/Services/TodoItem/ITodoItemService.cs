using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetCapital.TodoList.Application.Services.TodoItem
{
    public interface ITodoItemService
    {
        Task<ServiceResponse<List<GetTodoItemsDto>>> AddTodoItemAsync(AddTodoItemDto item);
        Task<ServiceResponse<List<GetTodoItemsDto>>> GetAllAsync();
        Task<ServiceResponse<GetTodoItemsDto>> GetItemAsync(int id);
        Task<ServiceResponse<List<Models.TodoItem>>> MarkAsCompleted(int id);
        Task<ServiceResponse<List<Models.TodoItem>>> Delete(int id);
    }
}
