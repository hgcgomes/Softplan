using Microsoft.AspNetCore.Mvc;

namespace Softplan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceiroController : ControllerBase
    {
        [HttpGet, Route("taxaJuros")]
        public decimal TaxaJuros() => 0.01M;
    }
}
