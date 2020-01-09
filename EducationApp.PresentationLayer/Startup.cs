using EducationApp.BusinessLogicalLayer.Common;
using EducationApp.BusinessLogicalLayer.Helpers;
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddControllers();

            BusinessLogicalLayer.Startup.RegisterDependencies(connection, services);

            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("EducationApp", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Education App API",
                        Version = $"v1.0",
                        Description = "API Documentation - Education App",
                    });

                    //var security = new Dictionary<string, IEnumerable<string>>
                    //{
                    //    {"Bearer", new string[] { }},
                    //};

                    //options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiInfo
                    //{
                    //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    //    Name = "Authorization",
                    //    In = "header",
                    //    Type = "apiKey"
                    //});
                    //options.AddSecurityRequirement(security);
                });
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

            BusinessLogicalLayer.Startup.EnsureUpdate(serviceProvider);

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint($"/swagger/EducationApp/swagger.json", "Education App");
                });

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
