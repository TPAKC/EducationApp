using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.BusinessLogicalLayer.Helpers.Interfaces;
using EducationApp.BusinessLogicalLayer.Helpers.Mapper;
using EducationApp.BusinessLogicalLayer.Helpers.Mapper.Interface;
using EducationApp.BusinessLogicalLayer.Services;
using EducationApp.BusinessLogicalLayer.Services.Interfaces;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Initialization;
using EducationApp.PresentationLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace EducationApp.BusinessLogicalLayer
{
    public class Startup
    {
        public static void RegisterDependencies(string connectionString, IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString,
               sqlServerOptionsAction: sqlOptions =>
               {
                   sqlOptions.EnableRetryOnFailure(
                       maxRetryCount: 5,
                       maxRetryDelay: TimeSpan.FromSeconds(2),
                       errorNumbersToAdd: null);
               }));

            services.AddIdentity<ApplicationUser, IdentityRole<long>>(opts => //todo replace to BLL +
            {
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders(); ;

            services.AddScoped<IPrintingEditionsService, PrintingEditionService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailHelper, EmailHelper>();
            services.AddScoped<IMapper, Mapper>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            EducationApp.DataAccessLayer.Startup.RegisterDependencies(connectionString, services);
        }

        public static void EnsureUpdate(IServiceProvider serviceProvider)
        {
            serviceProvider.GetService<DataBaseInitializer>().InitializeAsync().Wait();
        }
    }
}
