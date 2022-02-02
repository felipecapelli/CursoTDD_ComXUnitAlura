using System;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;
            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    $"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComVariosLances()
        {
            //Anrranje (Given) - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act (When) - método sob teste
            leilao.TerminaPregao();

            //Assert (Then)
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Verifica(valorEsperado, valorObtido);

        }

        private static void LeilaoComApenasUmLance()
        {
            //Anrranje (Given) - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 8001);

            //Act (When) - método sob teste
            leilao.TerminaPregao();

            //Assert (Then)
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();
        }

    }

    /* 
        Referencias mencionadas na aula:
        Definição de Teste
            http://softwaretestingfundamentals.com/definition-of-test/

        Padrão AAA (Arrange, Act, Assert)
            http://wiki.c2.com/?ArrangeActAssert

        Padrão Given/When/Then
            https://martinfowler.com/bliki/GivenWhenThen.html

        xUnit
            https://xunit.github.io/

        MSTests
            https://github.com/Microsoft/testfx-docs

        NUnit
            https://nunit.org/

        Comparativo entre os frameworks de Teste
            https://xunit.net/docs/comparisons

        Porque xUnit?
            https://www.martin-brennan.com/why-xunit/

        Microsoft está usando o xUnit
            https://dev.to/hatsrumandcode/net-core-2-why-xunit-and-not-nunit-or-mstest--aei

     */


}
