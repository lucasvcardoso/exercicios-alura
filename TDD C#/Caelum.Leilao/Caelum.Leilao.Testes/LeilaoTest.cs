using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Caelum.Leilao.Testes
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void DeveReceberUmLance()
        {
            //Arrange
            Leilao leilao = new Leilao("MacBook Pro 15");
            Assert.AreEqual(0, leilao.Lances.Count);

            //Act
            leilao.Propoe(new Lance(new Usuario("Steve Jobe"), 2000));

            //Assert
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            //Arrange
            Leilao leilao = new Leilao("Macbook Pro 15");
            
            //Act
            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));
            leilao.Propoe(new Lance(new Usuario("Steve Wozniak"), 3000));

            //Assert
            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);
            Assert.AreEqual(3000, leilao.Lances[1].Valor);
        }

        [Test]
        public void NaoDeveAceitarDoisLanceSeguidosDoMesmoUsuario()
        {
            //Arrange
            Leilao leilao = new Leilao("MacBook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");

            //Act
            leilao.Propoe(new Lance(steveJobs, 2000));
            leilao.Propoe(new Lance(steveJobs, 3000));

            //Assert
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor);



        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDoMesmoUsuario()
        {
            //Arrange
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");

            double[] lances = {
                2000,
                3000,
                4000,
                5000,
                6000,
                7000,
                8000,
                9000,
                10000,
                11000

            };

            //Act
            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(steveJobs, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(billGates, lance));
                }
                i++;
            }

            //Deve ser ignorado
            leilao.Propoe(new Lance(steveJobs, 12000));

            //Assert
            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(11000.0, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void DeveGerarLanceDobrado()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("New 2DS XL Azul");

            leilao.Propoe(new Lance(joao, 3500));
            leilao.Propoe(new Lance(maria, 4000));

            //Act
            leilao.DobraLance(joao);

            //Assert
            Assert.AreEqual(3, leilao.Lances.Count);
            int ultimoLance = leilao.Lances.Count - 1;
            Assert.AreEqual(7000.0, leilao.Lances[ultimoLance].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveGerarLanceDobradoDoUltimoUsuario()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("New 2DS XL Azul");

            leilao.Propoe(new Lance(joao, 2000));
            leilao.Propoe(new Lance(maria, 4000));

            //Act
            leilao.DobraLance(maria);

            //Assert
            Assert.AreEqual(2, leilao.Lances.Count);
            int ultimoLance = leilao.Lances.Count - 1;
            Assert.AreEqual(4000.0, leilao.Lances[ultimoLance].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveGerarLanceDobradoDeUsuarioQueDeuMaisQueCincoLances()
        {
            //Arrange
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");

            double[] lances = {
                2000,
                3000,
                4000,
                5000,
                6000,
                7000,
                8000,
                9000,
                10000,
                11000

            };

            //Act
            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(steveJobs, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(billGates, lance));
                }
                i++;
            }

            //Deve ser ignorado
            leilao.DobraLance(steveJobs);

            //Assert
            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(11000.0, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void DeveGerarLanceDobradoDeUsuarioQueDeuMenosQueCincoLances()
        {
            //Arrange
            Leilao leilao = new Leilao("Macbook Pro 15");
            Usuario steveJobs = new Usuario("Steve Jobs");
            Usuario billGates = new Usuario("Bill Gates");

            double[] lances = {
                2000,
                3000,
                4000,
                5000,
                6000,
                7000,
                8000,
                9000,
                10000

            };

            //Act
            int i = 1;
            foreach (double lance in lances)
            {
                if (i % 2 != 0)
                {
                    leilao.Propoe(new Lance(billGates, lance));
                }
                else
                {
                    leilao.Propoe(new Lance(steveJobs, lance));
                }
                i++;
            }

            //Deve ser ignorado
            leilao.DobraLance(steveJobs);

            //Assert
            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];
            Assert.AreEqual(18000.0, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void NaoDeveDobrarLanceInexistente()
        {
            //Arrange
            Leilao leilao = new Leilao("New 2DS XL Azul");
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");

            leilao.Propoe(new Lance(joao, 2000));
            //Act
            leilao.DobraLance(maria);

            //Assert
            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[leilao.Lances.Count - 1].Valor, 0.00001);
        }
    }
}
