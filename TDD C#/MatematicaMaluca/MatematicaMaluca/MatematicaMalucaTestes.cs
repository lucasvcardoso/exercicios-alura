using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matematica.Maluca
{
    [TestFixture]
    public class MatematicaMalucaTestes
    {
        [Test]
        public void TestaMaiorQueTrinta()
        {
            //Arrange
            MatematicaMaluca matematica = new MatematicaMaluca();

            //Act
            var resultado = matematica.ContaMaluca(31);

            //Assert
            Assert.AreEqual(124, resultado);
        }
        [Test]
        public void TestaMaiorQueDez()
        {
            //Arrange
            MatematicaMaluca matematica = new MatematicaMaluca();

            //Act
            var resultado = matematica.ContaMaluca(30);

            //Assert
            Assert.AreEqual(90, resultado);
        }
        [Test]
        public void TestaMenorQueDez()
        {
            //Arrange
            MatematicaMaluca matematica = new MatematicaMaluca();

            //Act
            var resultado = matematica.ContaMaluca(9);

            //Assert
            Assert.AreEqual(18, resultado);
        }
    }
}
