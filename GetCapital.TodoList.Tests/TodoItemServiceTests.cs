using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetCapital.TodoList.Application.Data;
using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Services.TodoItem;
using GetCapital.TodoList.UI;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace GetCapital.TodoList.Tests
{
    public class TodoItemServiceTests
    {
        private readonly TodoItemService _todoItemService;
        private readonly DataContext _dataContext;
        private readonly IMapper _iMapper;
        public TodoItemServiceTests()
        {
            if (_iMapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapperProfile());
                });
                _iMapper = mappingConfig.CreateMapper();
            }

            if (_dataContext == null)
            {
                var options = new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase(databaseName: "TempTodoListDB")
                    .Options;
                _dataContext = new DataContext(options);
            }
            _todoItemService = new TodoItemService(_iMapper, _dataContext);
        }

        [Fact]
        public async Task AddTodoItemAsync_ShouldContainNewItem()
        {
            var newItem = new AddTodoItemDto
            {
                Name = "New Task"
            };

            var result = await _todoItemService.AddTodoItemAsync(newItem);

            Assert.Contains(result.Data, a =>a.Name.Equals(newItem.Name));
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMoreThanOneValue()
        {
            var newItem = new AddTodoItemDto
            {
                Name = "New Task"
            };
            await _todoItemService.AddTodoItemAsync(newItem);
            var result = await _todoItemService.GetAllAsync();

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task GetItemAsync_ShouldReturnTodoItem()
        {
            var newItem = new AddTodoItemDto
            {
                Name = "New Task"
            };
            var newItemResponse = await _todoItemService.AddTodoItemAsync(newItem);
            var todoItemId = newItemResponse.Data.First().Id;

            var result = await _todoItemService.GetItemAsync(todoItemId);

            Assert.Equal(todoItemId, result.Data.Id);
        }

        [Fact]
        public async Task MarkAsCompletedAsync_ShouldMarkIsComplete()
        {
            var newItem = new AddTodoItemDto
            {
                Name = "New Task"
            };
            var newItemResponse = await _todoItemService.AddTodoItemAsync(newItem);
            var todoItemId = newItemResponse.Data.First().Id;

            var result = await _todoItemService.MarkAsCompletedAsync(todoItemId);

            Assert.Contains(result.Data, a =>a.Id.Equals(todoItemId) && a.IsCompleted);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDontContainDeletedItem()
        {
            var newItem1 = new AddTodoItemDto { Name = "New Task 01" };
            await _todoItemService.AddTodoItemAsync(newItem1);

            var newItem2 = new AddTodoItemDto { Name = "New Task 02" };
            await _todoItemService.AddTodoItemAsync(newItem1);

            var deleteItemId = (await _todoItemService.GetAllAsync()).Data.First().Id;

            var result = await _todoItemService.DeleteAsync(deleteItemId);

            Assert.DoesNotContain(result.Data, a =>a.Id.Equals(deleteItemId));
        }
    }
}
