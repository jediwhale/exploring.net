using Exploring.Net.CSharp;
using NUnit.Framework;

namespace Exploring.UnitTest {
    [TestFixture]
    public class NewtonTest {

        [Test]
        public void InitialGuessIsCorrect() {
            Assert.AreEqual(1.0, Newton.Sqrt(1.0));
        }
    }
}
