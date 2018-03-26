using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Testes
{
    [TestFixture]
    public class FiltroDeLancesTest
    {
        [Test]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 2000),
                    new Lance(joao, 1000),
                    new Lance(joao, 3000),
                    new Lance(joao, 800),
                });

            //Assert
            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesEntre500E700()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 600),
                    new Lance(joao, 500),
                    new Lance(joao, 700),
                    new Lance(joao, 800),
                });

            //Assert
            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesMaioresQue5000()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 4850),
                    new Lance(joao, 5000),
                    new Lance(joao, 5002),
                    new Lance(joao, 6352),
                });

            //Assert
            Assert.AreEqual(2, resultado.Count);
            Assert.AreEqual(5002, resultado[0].Valor, 0.00001);
            Assert.AreEqual(6352, resultado[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveSelecionarLancesMenoresQue500()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 250),
                    new Lance(joao, 350),
                    new Lance(joao, 350),
                    new Lance(joao, 500),
                });

            //Assert
            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void NaoDeveSelecionarLancesEntre700E1000()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 750),
                    new Lance(joao, 800),
                    new Lance(joao, 900),
                    new Lance(joao, 1000),
                });

            //Assert
            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void NaoDeveSelecionarLancesEntre3000E5000()
        {
            //Arrange
            Usuario joao = new Usuario("Joao");
            FiltroDeLances filtro = new FiltroDeLances();

            //Act
            IList<Lance> resultado = filtro.Filtra(
                new List<Lance>() {
                    new Lance(joao, 3500),
                    new Lance(joao, 4000),
                    new Lance(joao, 4500),
                    new Lance(joao, 5000),
                });

            //Assert
            Assert.AreEqual(0, resultado.Count);
        }
    }
}
