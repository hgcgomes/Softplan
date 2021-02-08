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
            const decimal valorEsperado = 0.01M;

            // Executar
            var valorObtido = await Get("financeiro/taxajuros", new string [] { }, decimal.Parse);

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public async Task FinanceiroController_TaxaJuros_StatusOk()
        {
            // Preparar (base)
            const HttpStatusCode valorEsperado = HttpStatusCode.OK;

            // Executar
            var valorObtido = await GetStatusCode("financeiro/taxajuros", new string[] { });

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        #endregion TaxaJuros

        #region Calcula Juros

        [Fact]
        public async Task FinanceiroController_CalculaTaxaJurosUmEhTempoMesesUm_UmPontoZeroUm()
        {
            // Preparar (base)
            const decimal valorEsperado = 1.01M;
            var parametros = new[] { "taxajuros=1", "tempoMeses=1" };

            // Executar
            var valorObtido = await Get("financeiro/calculajuros", parametros, decimal.Parse);

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public async Task FinanceiroController_CalculaJuros_StatusOk()
        {
            // Preparar (base)
            const HttpStatusCode valorEsperado = HttpStatusCode.OK;
            var parametros = new[] { "taxajuros=1", "tempoMeses=1" };

            // Executar
            var valorObtido = await GetStatusCode("financeiro/calculajuros", parametros);

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }

        #endregion Calcula Juros
    }
}
