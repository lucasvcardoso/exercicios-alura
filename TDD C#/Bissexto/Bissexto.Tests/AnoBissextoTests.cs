using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bissexto;

namespace Bissexto
{
    [TestFixture]
    public class AnoBissextoTests
    {
        [Test]
        public void DeveDizerQueEhBissexto()
        {
            //Arrange
            int ano = 2400;
            AnoBissexto bissexto = new AnoBissexto();

            //Act
            bool ehBissexto = bissexto.EhBissexto(ano);

            //Assert
            Assert.IsTrue(ehBissexto);
        }

        [Test]
        public void DeveDizerQueEhBissextoNaoMultiploDe400()
        {
            //Arrange
            int ano = 2016;
            AnoBissexto bissexto = new AnoBissexto();

            //Act
            bool ehBissexto = bissexto.EhBissexto(ano);

            //Assert
            Assert.IsTrue(ehBissexto);
        }

        [Test]
        public void DeveDizerQueNaoEhBissextoSendoMultiploDe4EMultiploDe100MasNaoDe400()
        {
            //Arrange
            int ano = 1900;
            AnoBissexto bissexto = new AnoBissexto();

            //Act
            bool ehBissexto = bissexto.EhBissexto(ano);

            //Assert
            Assert.IsFalse(ehBissexto);
        }

        [Test]
        public void DeveDizerQueNaoEhBissexto()
        {
            //Arrange
            int ano = 2015;
            AnoBissexto bissexto = new AnoBissexto();

            //Act
            bool ehBissexto = bissexto.EhBissexto(ano);

            //Assert
            Assert.IsFalse(ehBissexto);
        }
    }
}
