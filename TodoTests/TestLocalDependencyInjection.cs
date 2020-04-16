﻿using Microsoft.AspNetCore.Mvc;
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
using TodoApi.Controllers;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class TestLocalDependencyInjection
    {
        [TestMethod]
        public async Task Test()
        {
            var factory = new ControllerFactory();
            var mock = new Mock<ITodoService>();

            mock.Setup(x => x.GetAsync<TodoItemListView>())
                .ReturnsAsync(Array.Empty<TodoItemListView>());

            factory.Services.AddScoped(factory => mock.Object);

            var controller = factory.Create<TodoController>(this);

            var result = await controller.GetAsync();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
