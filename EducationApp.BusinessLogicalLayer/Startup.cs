using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Services;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EducationApp.BusinessLogicalLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddScoped<IPrintingEditionsService, PrintingEditionService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<Mapper, Mapper>();

            EducationApp.DataAccessLayer.Startup.RegisterDependencies(connectionString, services);

            services.AddIdentity<ApplicationUser, IdentityRole>(opts => //todo replace to BLL +
            {
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            });
        }
    }
}
