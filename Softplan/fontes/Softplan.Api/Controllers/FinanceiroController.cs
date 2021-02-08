using Microsoft.AspNetCore.Mvc;

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
    }
}
