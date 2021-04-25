using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GetCapital.TodoList.Application.Data;
using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Utility;
using Microsoft.EntityFrameworkCore;

namespace GetCapital.TodoList.Application.Services.TodoItem
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TodoItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetTodoItemsDto>>> AddTodoItemAsync(AddTodoItemDto item)
        {
            var newItem = _mapper.Map<Models.TodoItem>(item);
            await _context.TodoItems.AddAsync(newItem);
            await _context.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<List<GetTodoItemsDto>>
            {
                Data = _context.TodoItems.Select(t => _mapper.Map<GetTodoItemsDto>(t)).ToList()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoItemsDto>>> GetAllAsync()
        {
            var todoItems = await _context.TodoItems.ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetTodoItemsDto>>
            {
                Data = todoItems.Select(t => _mapper.Map<GetTodoItemsDto>(t)).ToList()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoItemsDto>> GetItemAsync(int id)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id.Equals(id));
            var serviceResponse = new ServiceResponse<GetTodoItemsDto>
            {
                Data = _mapper.Map<GetTodoItemsDto>(todoItem)
            };
            return serviceResponse;
        }

        public Task<ServiceResponse<List<Models.TodoItem>>> MarkAsCompleted(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<Models.TodoItem>>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
