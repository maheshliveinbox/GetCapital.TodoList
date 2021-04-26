using System;
using System.Collections.Generic;
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
        public async Task Get_ListOfTodoItems()
        {
            // Arrange
            var mockService = new Mock<ITodoItemService>();
            mockService.Setup(m => m.GetAllAsync())
                .ReturnsAsync(GetTestResponse_GetAll());
            var controller = new TodoItemsController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var serviceResponse = Assert.IsType<ServiceResponse<List<GetTodoItemsDto>>>(result);

            Assert.Equal(3, serviceResponse.Data.Count);
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
