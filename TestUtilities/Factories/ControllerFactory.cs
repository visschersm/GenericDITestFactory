using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TestUtilities.Interfaces;

namespace TestUtilities.Factories
{
    public class ControllerFactory
    {
        public ControllerFactory()
        {
            Services = new ServiceCollection();
        }

        public IServiceCollection Services { get; private set; }

        public TController Create<TController>(object caller)
            where TController : ControllerBase
        {
            // TestClass dependency registration
            ((IBaseTest)caller).RegisterDependencies(Services);

            // Project wide registration
            Services.RegisterDependencies();

            Services.AddScoped<TController>();

            var serviceProvider = Services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}
