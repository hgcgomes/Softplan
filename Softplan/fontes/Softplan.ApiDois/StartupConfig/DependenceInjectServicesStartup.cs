using Microsoft.Extensions.DependencyInjection;
using Softplan.ApiDois.Camadas.Infra.Integracao;

namespace Softplan.ApiDois.StartupConfig
{
    public class DependenceInjectServicesStartup
    {
        public static void Configure(IServiceCollection services) =>
            services.AddSingleton(ApiUmIntegracao.Instancia());
    }
}
