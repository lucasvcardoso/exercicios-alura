using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromo
{
    [TestFixture]
    public class PalindromoTestes
    {
        [Test]
        public void DeveIdentificarSeEhPalindromo()
        {
            //Arrange
            Palindromo palindromo = new Palindromo();

            //Act
            var ehPalindromo = palindromo.EhPalindromo("Socorram-me subi no onibus em marrocos");

            //Assert
            Assert.IsTrue(ehPalindromo);
        }

        [Test]
        public void DeveIdentificarSeNaoEhPalindromo()
        {
            //Arrange
            Palindromo palindromo = new Palindromo();

            //Act
            var ehPalindromo = palindromo.EhPalindromo("E preciso amar as pessoas como se nao houvesse amanha");

            //Assert
            Assert.IsFalse(ehPalindromo);
        }
    }
}
