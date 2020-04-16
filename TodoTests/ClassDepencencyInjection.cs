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
    public class ClassDepencencyInjection : IBaseTest
    {
        private readonly Mock<ITodoService> mock = new Mock<ITodoService>();

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped(typeof(ITodoService), factory => mock.Object);
        }

        [TestMethod]
        public async Task Test()
        {
            var factory = new ControllerFactory();

            mock.Setup(x => x.GetAsync<TodoItemListView>())
                .ReturnsAsync(Array.Empty<TodoItemListView>());

            var controller = factory.Create<TodoController>(this);

            var result = await controller.GetAsync();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
