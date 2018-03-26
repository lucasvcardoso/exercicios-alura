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
    }
}
