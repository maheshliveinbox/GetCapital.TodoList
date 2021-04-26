using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetCapital.TodoList.Application.Dtos.TodoItem;
using GetCapital.TodoList.Application.Services.TodoItem;
using GetCapital.TodoList.Application.Utility;
using GetCapital.TodoList.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GetCapital.TodoList.Tests
{
    public class TodoItemsControllerTests
    {
        [Fact]
        public async Task Get_ListOfTodoItems_Should_Return_OK_Response()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var serviceResponse = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, serviceResponse.StatusCode);
        }

        [Fact]
        public async Task Get_OnlyOneTodoItem_Should_Return_OK_Response()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);
            var listItemid = 1;

            // Act
            var result = await controller.GetItem(listItemid);

            // Assert
            var serviceResponse = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, serviceResponse.StatusCode);
        }

        [Fact]
        public async Task AddNewItem_Should_Return_OK_Response()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);

            var newItem = new AddTodoItemDto
            {
                Name = "New Item"
            };

            // Act
            var result = await controller.AddItem(newItem);

            // Assert
            var serviceResponse = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, serviceResponse.StatusCode);
        }

        [Fact]
        public async Task MarkAsCompleted_Should_Return_OK_Response()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);

            var listItemId = 1;

            // Act
            var result = await controller.MarkAsCompleted(listItemId);

            // Assert
            var serviceResponse = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, serviceResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteItem_Should_Return_OK_Response()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);

            var listItemId = 1;

            // Act
            var result = await controller.DeleteItem(listItemId);
            // Assert
            var serviceResponse = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(200, serviceResponse.StatusCode);
        }

        private ServiceResponse<List<GetTodoItemsDto>> GetTestResponse_GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetTodoItemsDto>>
            {
                Data = new List<GetTodoItemsDto>
                {
                    new GetTodoItemsDto
                    {
                        Name = "Test Item 01",
                        Id = 1,
                        IsCompleted = false
                    },
                    new GetTodoItemsDto
                    {
                        Name = "Test Item 02",
                        Id = 2,
                        IsCompleted = false
                    },
                    new GetTodoItemsDto
                    {
                        Name = "Test Item 03",
                        Id = 3,
                        IsCompleted = false
                    },
                }
            };

            return serviceResponse;
        }
    }
}
