using System;
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

        protected async Task<T> Get<T>(string url, Func<string, T> parse)
        {
            var resultado = await _httpClient.GetAsync(url);
            var conteudo = await resultado.Content.ReadAsStringAsync();
            var valor = await Task.Run(() => parse(conteudo));
            return valor;
        }

        protected async Task<HttpStatusCode> GetStatusCode(string url)
        {
            var resultado = await _httpClient.GetAsync(url);
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
