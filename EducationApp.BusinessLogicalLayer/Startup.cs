using EducationApp.BusinessLogicalLayer.Services;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.BusinessLogicalLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddScoped<IPrintingEditionsService, PrintingEditionsService>();

            EducationApp.DataAccessLayer.Startup.RegisterDependencies(connectionString, services);
        }
    }
}
