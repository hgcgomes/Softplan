using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Softplan.Api.StartupConfig
{
    public class SwaggerConfigAppStartup
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(UseSwaggerUI);
        }

        private static void UseSwaggerUI(SwaggerUIOptions c)
        {
            c.RoutePrefix = "swaggerapidois";
            c.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
        }
    }
}
