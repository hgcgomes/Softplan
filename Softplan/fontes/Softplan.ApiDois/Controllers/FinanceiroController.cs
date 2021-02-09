﻿using Microsoft.AspNetCore.Mvc;
using Softplan.Api.Camadas.Dominio;
using Softplan.ApiDois.Camadas.Infra.Integracao;
using System;
using System.Web;

namespace Softplan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceiroController : ControllerBase
    {
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
            var valorInicial = Convert.ToDecimal(Request.Query["valorInicial"]);
            var tempoMeses = Convert.ToInt32(Request.Query["tempoMeses"]);
            var taxaJuros = ApiUmIntegracao.ObtemTaxaJuros();

            var valorFinalTruncado = Juros.CalculaJurosCompostos(taxaJuros, valorInicial, tempoMeses, truncarCasasDecimais: 2);

            return valorFinalTruncado;
        }
    }
}