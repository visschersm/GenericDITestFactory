using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implementation;
using System.Threading.Tasks;
using TestUtilities.Factories;
using TestUtilities.Interfaces;
using ViewModel;

namespace TodoTests
{
    [TestClass]
    public class TodoServiceTests : IBaseTest
    {
        [TestMethod]
        public async Task TestMethod1Async()
        {
            var factory = new ServiceFactory();
            // Setup dependencies here
            //factory.Services.AddScoped<>

            var service = factory.Create<TodoService>(this);

            var result = await service.GetAsync<TodoItemListView>();

            Assert.IsNotNull(result);
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            // Or setup dependencies here class-globally
        }
    }
}
