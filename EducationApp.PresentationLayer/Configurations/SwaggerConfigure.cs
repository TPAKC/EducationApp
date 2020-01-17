using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Configurations
{
    public static class SwaggerConfigure
    {
        public static void ConfigureSwaggerService(this IServiceCollection services)
        {
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

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint($"/swagger/EducationApp/swagger.json", "Education App");
                });
        }
    }
}
