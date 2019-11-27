using EducationApp.BusinessLogicalLayer.Services;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.BusinessLogicalLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddScoped<IPrintingEditionsService, PrintingEditionService>();

            EducationApp.DataAccessLayer.Startup.RegisterDependencies(connectionString, services);
        }
    }
}
