using System.Threading.Tasks;
using Xunit;

namespace Softplan.Api.Teste.Controllers
{
    public class FinanceiroCalculaJurosTeste : ControllerBaseTeste
    {
        #region Calcula Juros

        [Fact]
        public async Task FinanceiroController_CalculaTaxaJurosUmEhTempoMesesUm_UmPontoZeroUm()
        {
            // Preparar (base) 
            var valorEsperado = 1.01M;
            var queries = Parametros(valorInicial: 1, tempoMeses: 1);
            SetQueryString(queries);
            
            // Executar
            var valorObtido = FinanceiroController.CalculaJuros();

            // Validar
            Assert.Equal(valorEsperado, valorObtido);
        }
        

        #endregion Calcula Juros
    }
}
