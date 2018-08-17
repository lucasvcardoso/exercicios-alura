using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {

        private Avaliador Leiloeiro { get; set; }

        //[OneTimeSetUp]
        //public void SetUp()
        //{
        //    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        //}

        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    Trace.Flush();
        //}

        [SetUp]
        public void CriaAvaliador()
        {
            this.Leiloeiro = new Avaliador();
            TestContext.Out.WriteLine("Criando avaliador");
        }

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
            
            Leiloeiro.Avalia(leilao);
             
            //comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, Leiloeiro.MaiorDeTodos, 0.00001);
            Assert.AreEqual(menorEsperado, Leiloeiro.MenorDeTodos, 0.00001);
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
            
            double media = Leiloeiro.CalculaMediaDosLances(leilao);

            //Assert
            double expected = 400;
            Assert.AreEqual(expected, media, 0.00001);
        }

        [Test]
        public void DeveAvaliarUmLance()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 250));

            //Act
            
            Leiloeiro.Avalia(leilao);

            //Assert
            Assert.AreEqual(250, Leiloeiro.MaiorDeTodos, 0.00001);
            Assert.AreEqual(250, Leiloeiro.MenorDeTodos, 0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemAleatoria()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            double[] lances = { 200, 150, 120, 700, 630, 230 };

            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(joao, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(maria, lance));
                }
                i++;
            }


            //Act
            
            Leiloeiro.Avalia(leilao);

            //Assert
            Assert.AreEqual(120, Leiloeiro.MenorDeTodos, 0.00001);
            Assert.AreEqual(700, Leiloeiro.MaiorDeTodos, 0.00001);
        }

        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            //Arrange

            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            double[] lances = { 600,500,400,300,200,100 };

            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(joao, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(maria, lance));
                }
                i++;
            }


            //Act
            
            Leiloeiro.Avalia(leilao);

            //Assert
            Assert.AreEqual(100, Leiloeiro.MenorDeTodos, 0.00001);
            Assert.AreEqual(600, Leiloeiro.MaiorDeTodos, 0.00001);
        }

        [Test]
        public void DevePegarOsTresMaioresEmQuatroLances()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            double[] lances = { 600, 500, 400, 300, 200, 100 };

            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(joao, lance));
                }else
                {
                    leilao.Propoe(new Lance(maria, lance));
                }
                i++;
            }


            //Act
            
            Leiloeiro.Avalia(leilao);
            Leiloeiro.PegaOsMaioresNo(leilao);

            //Assert
            Assert.AreEqual(3, Leiloeiro.TresMaiores.Count);
            Assert.AreEqual(600, Leiloeiro.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(500, Leiloeiro.TresMaiores[1].Valor, 0.00001);
            Assert.AreEqual(400, Leiloeiro.TresMaiores[2].Valor, 0.00001);
        }

        [Test]
        public void DevePegarOsDoisMaioresEmDoisLances()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            double[] lances = { 600, 500 };

            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(joao, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(maria, lance));
                }
                i++;
            }


            //Act
            
            Leiloeiro.Avalia(leilao);
            Leiloeiro.PegaOsMaioresNo(leilao);

            //Assert
            Assert.AreEqual(2, Leiloeiro.TresMaiores.Count);
            Assert.AreEqual(600, Leiloeiro.TresMaiores[0].Valor, 0.00001);
            Assert.AreEqual(500, Leiloeiro.TresMaiores[1].Valor, 0.00001);           
        }

        [Test]
        public void DeveRetornarListaVazia()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            //Act
            
            Leiloeiro.Avalia(leilao);
            Leiloeiro.PegaOsMaioresNo(leilao);

            //Assert
            Assert.AreEqual(0, Leiloeiro.TresMaiores.Count);
        }


    }
}
