using EducationApp.DataAccessLayer.Repositories;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.DataAccessLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddSingleton(new Connection(connectionString));
            services.AddScoped<IPrintingEditionRepository, PrintingEditionsRepository>();
        }
    }
}
