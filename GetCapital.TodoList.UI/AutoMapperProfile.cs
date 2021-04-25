using AutoMapper;
using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Models;

namespace GetCapital.TodoList.UI
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddTodoItemDto, TodoItem>();
            CreateMap<TodoItem, GetTodoItemsDto>();
        }
    }
}
