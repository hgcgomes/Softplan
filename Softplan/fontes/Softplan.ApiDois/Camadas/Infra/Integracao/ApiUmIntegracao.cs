using Newtonsoft.Json;
using RestSharp;
using System;

namespace Softplan.ApiDois.Camadas.Infra.Integracao
{
    public class ApiUmIntegracao : IApiUmIntegracao
    {
        private readonly string _apiFinanceiroTaxaJuros = "https://localhost:49157/financeiro/taxajuros";
        public decimal ObtemTaxaJuros()
        {
            var uri = new Uri(_apiFinanceiroTaxaJuros);
            var cliente = new RestClient(uri);
            var requisicao = new RestRequest(uri, Method.GET, DataFormat.Json);
            var resposta = cliente.Execute(requisicao);
            var conteudo = resposta.Content;
            var taxaJuros = JsonConvert.DeserializeObject<decimal>(conteudo);
            return taxaJuros;
        }

        public static IApiUmIntegracao Instancia() => new ApiUmIntegracao();
    }
}
