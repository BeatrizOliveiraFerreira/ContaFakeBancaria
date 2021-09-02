using AgendaBancaria.Dominio;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(18)]
        [TestCase(38)]
        [TestCase(28)]
        public static void VerificarIdade(int idade)
        {
            bool resultado = MaiordeIdade.VerificarIdade(idade);
            Assert.IsTrue(resultado);
        }
    }
}