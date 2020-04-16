using Microsoft.Extensions.DependencyInjection;
using Moq;
using Services;

namespace TestUtilities
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITodoService>(factory => new Mock<ITodoService>().Object);

            return services;
        }
    }
}
