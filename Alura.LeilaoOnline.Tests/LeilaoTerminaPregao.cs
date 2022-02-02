using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public static void RetornaZeroLeilaoSemLances()
        {
            //Anrranje (Given) - cenário
            var leilao = new Leilao("Van Gogh");

            //Act (When) - método sob teste
            leilao.TerminaPregao();

            //Assert (Then)
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);

        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public static void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double ValorEsperado ,double [] ofertas)
        {
            //Anrranje (Given) - cenário
            //Dado Leilao Com Pelo Menos Um Lance
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act (When) - método sob teste
            //Quando o pregão/leilão termina
            leilao.TerminaPregao();

            //Assert (Then)
            //Então o valor esperado é o maior valor dado
            //E o cliente ganhador é o que deu o maior lance
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(ValorEsperado, valorObtido);

        }
    
        
    }
}
