using System;
using System.Collections.Generic;
using System.Text;

namespace GetCapital.TodoList.Application.Dtos.TodoItem
{
    public class GetTodoItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
