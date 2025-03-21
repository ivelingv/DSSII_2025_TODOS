using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Domain.Repositories;
using Todo.Infrastructure.Repositories;

namespace Todo.Infrastructure
{
    public static class ApplicationConfigurationExtensions
    {
        public static IServiceCollection ConfigureDatabase(
            this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite("Data Source=main_db");
            });

            services.AddScoped<DatabaseContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();

            return services;
        }
    }
}
