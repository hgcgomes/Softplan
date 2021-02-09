using Microsoft.AspNetCore.Mvc;
using Softplan.Api.Camadas.Dominio;
using System;

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
        public decimal TaxaJuros() => Juros.TaxaJurosPadrao;
    }
}
