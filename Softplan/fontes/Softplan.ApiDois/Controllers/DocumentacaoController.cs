using Microsoft.AspNetCore.Mvc;
using Softplan.ApiDois.Camadas.Dominio;

namespace Softplan.ApiDois.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentacaoController : ControllerBase
    {
        [HttpGet, Route("showmethecode")]
        public string CodigoFonte() => Documentacao.UrlCodigoFonte;
    }
}
