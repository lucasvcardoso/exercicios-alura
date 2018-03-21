using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            //executando a acao
            Avaliador leiloeiro = new Caelum.Leilao.Avaliador();
            leiloeiro.Avalia(leilao);

            //comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorDeTodos, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorDeTodos, 0.00001);
        }

        [Test]
        public void DeveCalcularAMediaDosLances()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria= new Usuario("Maria");
            Usuario jose = new Usuario("Jose");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 200));
            leilao.Propoe(new Lance(maria, 450));
            leilao.Propoe(new Lance(jose, 550));

            //Act
            Avaliador leiloeiro = new Avaliador();
            double media = leiloeiro.CalculaMediaDosLances(leilao);

            //Assert
            double expected = 400;
            Assert.AreEqual(expected, media, 0.00001);
        }
    }
}
