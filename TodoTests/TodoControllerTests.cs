using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtilities.Factories;
using TestUtilities.Interfaces;
using TodoApi.Controllers;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class TodoControllerTests : IBaseTest
    {
        private readonly Mock<ITodoService> _globalTodo = new Mock<ITodoService>();

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped(factory => _globalTodo.Object);
        }

        [TestMethod]
        public async Task GetAsync_ValidRequest_OkObjectResultAsync()
        {
            var factory = new ControllerFactory();
            var mock = new Mock<ITodoService>();

            // local dependency
            mock.Setup(x => x.GetAsync<TodoItemListView>())
                .ReturnsAsync(Array.Empty<TodoItemListView>());

            // local dependency injection
            factory.Services.AddScoped(factory => mock.Object);

            // global dependency => injection is done in RegisterDependencies
            _globalTodo.Setup(x => x.GetAsync<TodoItemListView>())
                .ReturnsAsync(Array.Empty<TodoItemListView>());

            var controller = factory.Create<TodoController>(this);

            var result = await controller.GetAsync();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
