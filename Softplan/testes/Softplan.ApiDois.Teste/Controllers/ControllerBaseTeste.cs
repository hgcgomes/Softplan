using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Softplan.Api.Teste.Controllers
{
    public abstract class ControllerBaseTeste : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposable;

        protected ControllerBaseTeste()
        {
            // Preparar
            _httpClient = new WebApplicationFactory<Startup>().CreateClient();
            _disposable = false;
        }

        protected async Task<T> Get<T>(string url, string[] parametros, Func<string, T> parse)
        {
            var parametrosToString = parametros.Any() ? "?" + string.Join("&", parametros) : string.Empty;
            var resultado = await _httpClient.GetAsync(url + parametrosToString);
            var conteudo = await resultado.Content.ReadAsStringAsync();
            var valor = await Task.Run(() => parse(conteudo));
            return valor;
        }

        protected async Task<HttpStatusCode> GetStatusCode(string url, string[] parametros)
        {
            var parametrosToString = parametros.Any() ? "?" + string.Join("&", parametros) : string.Empty;
            var resultado = await _httpClient.GetAsync(url + parametrosToString);
            var httpStatuscode = resultado.StatusCode;
            return httpStatuscode;
        }

        public void Dispose()
        {
            if (_disposable) return;

            _httpClient.Dispose();
            _disposable = true;
        }
    }
}
