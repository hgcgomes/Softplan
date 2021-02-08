using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;

namespace Softplan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceiroController : ControllerBase
    {
        /// <summary>
        /// Obtem taxa de juros
        /// </summary>
        /// <response code="200"></response>
        /// <returns>Taxa de Juros</returns>
        [HttpGet, Route("taxaJuros"), ProducesResponseType(typeof(decimal), 200)]
        public decimal TaxaJuros() => 0.01M;


        /// <summary>
        /// Calcula valor final dos juros compostos
        /// </summary>
        /// <param name="valorInicial">Valor inicial base par ao cálculo</param>
        /// <param name="tempoMeses">Tempo em meses para cálculo</param>
        /// <response code="200"></response>
        /// <returns></returns>
        [HttpGet, Route("calculaJuros"), ProducesResponseType(typeof(decimal), 200)]
        public decimal CalculaJuros()
        {
            var valorInicial = Convert.ToDecimal(Request.Query["taxaJuros"]);
            var tempoMeses = Convert.ToInt32(Request.Query["tempoMeses"]);

            var taxaJuros = TaxaJuros();
            var truncarCasasDecimais = 2;
            var valorFinal =
                valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempoMeses));

            var sentinela = (decimal)Math.Pow(10, truncarCasasDecimais);
            var temporareo = (int)(sentinela * valorFinal);
            var valorTruncado = temporareo / sentinela;

            return valorTruncado;
        }
    }
}
