using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtilities.Interfaces;

namespace TestUtilities.Factories
{
    public class ServiceFactory
    {
        public ServiceFactory()
        {
            Services = new ServiceCollection();
        }

        public ServiceCollection Services { get; private set; }

        public TService Create<TService>(object caller)
            where TService : class
        {
            ((IBaseTest)caller).RegisterDependencies(Services);

            Services.AddScoped<TService>();

            var serviceProvider = Services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TService>();

            return controller;
        }
    }
}
