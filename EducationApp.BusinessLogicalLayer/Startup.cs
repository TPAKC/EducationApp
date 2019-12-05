using EducationApp.BusinessLogicalLayer.Services;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.PresentationLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper.Configuration;

namespace EducationApp.BusinessLogicalLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => //todo replace to BLL
options.UseSqlServer(
Configuration.GetConnectionString("DefaultConnection")));

            EducationApp.Run(async (context) =>
            {
                // пишем на консоль информацию
                logger.LogInformation("Processing request {0}", context.Request.Path);
                //или так
                //logger.LogInformation($"Processing request {context.Request.Path}");

                await context.Response.WriteAsync("Hello World!");
            });

        }

        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddScoped<IPrintingEditionsService, PrintingEditionService>();

            EducationApp.DataAccessLayer.Startup.RegisterDependencies(connectionString, services);

            services.AddIdentity<ApplicationUser, IdentityRole>(opts => //todo replace to BLL
            {
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            });
        }
    }
}
