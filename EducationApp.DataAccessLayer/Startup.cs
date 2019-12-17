using EducationApp.DataAccessLayer.Initialization;
using EducationApp.DataAccessLayer.Repositories;
using EducationApp.DataAccessLayer.Repositories.DapperRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.DataAccessLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddSingleton(new Connection(connectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemsRepository>();
            services.AddScoped<DataBaseInitializer, DataBaseInitializer>();
        }
    }
}
