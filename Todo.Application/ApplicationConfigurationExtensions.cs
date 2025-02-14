using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Services;
using Todo.Domain.Services;

namespace Todo.Application
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
