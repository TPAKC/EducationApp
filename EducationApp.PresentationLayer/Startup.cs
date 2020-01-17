using EducationApp.BusinessLogicalLayer.Common;
using EducationApp.BusinessLogicalLayer.Helpers;
using EducationApp.PresentationLayer.Configurations;
using EducationApp.PresentationLayer.Data;
using EducationApp.PresentationLayer.Helpers.Interfaces;
using EducationApp.PresentationLayer.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json.Serialization;

namespace EducationApp.PresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddScoped<IJwtHelper, JwtHelper>();

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddControllers();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            BusinessLogicalLayer.Startup.RegisterDependencies(connection, services);

            services.ConfigureSwaggerService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();

            BusinessLogicalLayer.Startup.EnsureUpdate(serviceProvider);//инжектить DBIntitilizator

            app.ConfigureSwagger();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
