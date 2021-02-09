using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Api.StartupConfig;
using Softplan.ApiDois.StartupConfig;

namespace Softplan.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DefaultConfigServicesStartup.Configure(services);
            SwaggerConfigServiceStartup.Configure(services);
            DependenceInjectServicesStartup.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DefaultConfigAppStartup.Configure(app, env);
            SwaggerConfigAppStartup.Configure(app);
        }
    }
}
