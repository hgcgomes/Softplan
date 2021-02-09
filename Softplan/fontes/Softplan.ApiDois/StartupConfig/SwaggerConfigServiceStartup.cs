using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace Softplan.Api.StartupConfig
{
    public class SwaggerConfigServiceStartup
    {
        public static void Configure(IServiceCollection services) =>
            services.AddSwaggerGen(AddSwaggerGen);

        private static void AddSwaggerGen(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Softplan Test Asp.Net Core - API 2", Version = "v1" });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
        }
    }
}
