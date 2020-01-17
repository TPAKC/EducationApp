using EducationApp.DataAccessLayer.Helpers.Mapper;
using EducationApp.DataAccessLayer.Helpers.Mapper.Interface;
using EducationApp.DataAccessLayer.Initialization;
using EducationApp.DataAccessLayer.Repositories.DapperRepositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.Repositories.UserRepository;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.DataAccessLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddSingleton(connectionString);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IAuthorInPrintingEditionRepository, AuthorInPrintingEditionRepository>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<DataBaseInitializer>();
        }
    }
}
