using Softplan.Api.Camadas.Dominio;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Softplan.Api.Teste.Controllers
{
    public class FinanceiroTeste : ControllerBaseTeste
    {
        #region TaxaJuros

        [Fact]
        public async Task FinanceiroController_TaxaJuros_ValorZeroPontoZeroUm()
        {
            // Preparar (base)
            const decimal valorEsperado = Juros.TaxaJurosPadrao;

            // Executar
            var valorObtido = await Get("financeiro/taxajuros", decimal.Parse);

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public async Task FinanceiroController_TaxaJuros_StatusOk()
        {
            // Preparar (base)
            const HttpStatusCode valorEsperado = HttpStatusCode.OK;

            // Executar
            var valorObtido = await GetStatusCode("financeiro/taxajuros");

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        #endregion TaxaJuros
    }
}
