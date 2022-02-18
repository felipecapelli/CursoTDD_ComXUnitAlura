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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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
        Referencias mencionadas na aula 1:
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

    /*
        Referencias da segunda aula 2

        Classes de Equivalência - técnica para identificação de testes relevantes:
            https://en.wikipedia.org/wiki/Equivalence_partitioning

        Análise de Fronteira - outra técnica:
            https://en.wikipedia.org/wiki/Boundary-value_analysis

        Definição de Product Owner
            https://www.scrum.org/resources/what-is-a-product-owner

        Diferença entre [Fact] e [Theory]
            https://xunit.net/docs/getting-started/netfx/visual-studio#write-first-theory

        Nomenclatura de testes
            https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#best-practices

            https://docs.microsoft.com/pt-br/dotnet/standard/modern-web-apps-azure-architecture/test-asp-net-core-mvc-apps#test-naming

       ****************************************** IMPORTANTE ******************************************

        No vídeo Teorizando com xUnit você deve ter ficado se perguntando o seguinte: e se eu tiver dados de entrada mais complexos do que um simples double? E se quiser parametrizar objetos de entrada? O que fazer?

        Para isso o xUnit possui outras duas anotações, [MemberData] e [ClassData], onde você pode construir os dados de entrada usando membros da própria classe de teste ou então uma classe específica para isso.

        Veja mais detalhes nesse artigo (em inglês): https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
     
     */

    /*
         Referencias da segunda aula 3 
     
        Testes de regressão
        http://softwaretestingfundamentals.com/regression-testing/

    Intro a Métodos Ágeis na Alura
        https://cursos.alura.com.br/course/introducao-aos-metodos-ageis

    Livro TDD By Example, de Kent Beck
        https://www.amazon.com.br/Test-Driven-Development-Kent-Beck/dp/0321146530/

    Livro sobre TDD na Casa do Código
        https://www.casadocodigo.com.br/products/livro-tdd-dotnet

    Testes de métodos privados
        https://docs.microsoft.com/pt-br/dotnet/core/testing/unit-testing-best-practices#validate-private-methods-by-unit-testing-public-methods 

     */

    /*
     Referencias da segunda aula 4

     Diferenças entre os frameworks ao testar exceções

        https://xunit.net/docs/comparisons

     Visual Studio tem uma ferramenta de cobertura de código, mas infelizmente apenas nas suas versões pagas.

        https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested

      Esse artigo do Martin Fowler debate o real propósito da cobertura de código, que em sua opinião (na minha também!) deveria ser para encontrar partes não testadas do seu sistema ao invés de ser uma métrica utilizada em contratos e objetivos do time.

        https://www.martinfowler.com/bliki/TestCoverage.html
     
     */

    /*
    Consulte as referências usadas nessa aula.

    Design OO, Interfaces e Implementação
        https://en.wikipedia.org/wiki/Object-oriented_design

    Princípios de Design: SOLID
        https://en.wikipedia.org/wiki/SOLID

    Talk de Michael Feathers sobre como testes melhoram o design
     
     */


}
