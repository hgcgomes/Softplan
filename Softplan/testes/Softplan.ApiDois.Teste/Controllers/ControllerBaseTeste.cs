using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Softplan.Api.Camadas.Dominio;
using Softplan.Api.Controllers;
using Softplan.ApiDois.Camadas.Infra.Integracao;
using System;
using System.Linq;

namespace Softplan.Api.Teste.Controllers
{
    public abstract class ControllerBaseTeste : IDisposable
    {
        protected readonly HttpContext HttpContext;
        protected readonly ControllerContext ControllerContext;
        protected readonly FinanceiroController FinanceiroController;


        private bool _disposable;

        protected ControllerBaseTeste()
        {
            // Preparar
            HttpContext = new DefaultHttpContext();
            ControllerContext = new ControllerContext();
            FinanceiroController = FinanceiroControllerInstancia();
             
            _disposable = false;
        }

        protected string[] Parametros(decimal valorInicial, int tempoMeses) =>
            new[] { $"{nameof(valorInicial)}={valorInicial}", $"{nameof(tempoMeses)}={tempoMeses}" };


        protected void SetQueryString(string [] queries)
        {
            if (queries == null || !queries.Any()) return;

            var queryString = "?" + string.Join("&", queries);

            HttpContext.Request.QueryString = new QueryString(queryString);
        }

        private IApiUmIntegracao ApiUmIntegracaoInstancia()
        {
            var apiUmIntegracao = new Mock<IApiUmIntegracao>();
            apiUmIntegracao.Setup(aui => aui.ObtemTaxaJuros()).Returns(Juros.TaxaJurosPadrao);
            return apiUmIntegracao.Object;
        }

        private FinanceiroController FinanceiroControllerInstancia() =>
            new FinanceiroController(ApiUmIntegracaoInstancia())
            {
                ControllerContext = ContextoController()
            };

        private ControllerContext ContextoController()
        {
            ControllerContext.HttpContext = HttpContext;
            return ControllerContext;
        }

        public void Dispose()
        {
            if (_disposable) return;

            _disposable = true;
        }
    }
}
