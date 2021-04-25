using GetCapital.TodoList.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace GetCapital.TodoList.Application.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
