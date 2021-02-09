using System;

namespace Softplan.Api.Camadas.Dominio
{
    public class Juros
    {
        public const decimal TaxaJurosPadrao = 0.01M;
        public static decimal CalculaJurosCompostos(decimal taxaJuros, decimal valorInicial, int tempoMeses, int truncarCasasDecimais = 0)
        {
            var valorFinal =
                valorInicial * Convert.ToDecimal(Math.Pow(1 + Convert.ToDouble(taxaJuros), tempoMeses));

            var sentinela = (decimal)Math.Pow(10, truncarCasasDecimais);
            var temporareo = (int)(sentinela * valorFinal);
            var valorTruncado = temporareo / sentinela;

            return valorTruncado;
        }
    }
}
