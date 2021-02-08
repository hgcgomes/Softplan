using Microsoft.Extensions.DependencyInjection;

namespace Softplan.Api.StartupConfig
{
    public class DefaultConfigServicesStartup
    {
        public static void Configure(IServiceCollection services) =>
             services.AddControllers();
    }
}
