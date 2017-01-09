using Exploring.Net.CSharp;
using NUnit.Framework;

namespace Exploring.UnitTest {
    [TestFixture]
    public class NewtonTest {

        [Test]
        public void InitialGuessIsCorrect() {
            Assert.AreEqual(1.0, Newton.Sqrt(1.0));
        }

        [Test]
        public void ResultGetsCloseEnough() {
            Assert.AreEqual(2.0, Newton.Sqrt(4.0), 0.000001);
        }

        [Test]
        public void ZeroIsHandled() {
            Assert.AreEqual(0.0, Newton.Sqrt(0.0));
        }

        [Test]
        public void LargeResultIsCalculated() {
            Assert.AreEqual(1E50, Newton.Sqrt(1E100), 1E40);
        }
        [Test]
        public void SmallResultIsCalculated() {
            Assert.AreEqual(1E-50, Newton.Sqrt(1E-100), 1E-40);
        }
    }
}
