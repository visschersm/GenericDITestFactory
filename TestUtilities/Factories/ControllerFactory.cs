using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtilities.Interfaces;

namespace TestUtilities.Factories
{
    public class ControllerFactory
    {
        public ControllerFactory()
        {
            Services = new ServiceCollection();
        }

        public ServiceCollection Services { get; private set; }

        public TController Create<TController>(object caller)
            where TController : ControllerBase
        {
            ((IBaseTest)caller).RegisterDependencies(Services);

            Services.AddScoped<TController>();

            var serviceProvider = Services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TController>();

            return controller;
        }
    }
}
