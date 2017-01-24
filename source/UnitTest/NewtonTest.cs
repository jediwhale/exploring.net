using NUnit.Framework;

namespace Exploring.Net.UnitTest {
    public abstract class NewtonTest {

        [Test]
        public void InitialGuessIsCorrect() {
            Assert.AreEqual(1.0, SquareRoot(1.0));
        }

        [Test]
        public void ResultGetsCloseEnough() {
            Assert.AreEqual(2.0, SquareRoot(4.0), 1E-10);
        }

        [Test]
        public void NegativeInputThrowsException() {
            Assert.Throws<System.ArgumentOutOfRangeException>(() => SquareRoot(-1.0));
        }

        [Test]
        public void ZeroIsHandled() {
            Assert.AreEqual(0.0, SquareRoot(0.0));
        }

        [Test]
        public void LargeResultIsCalculated() {
            Assert.AreEqual(1E50, SquareRoot(1E100), 1E40);
        }

        [Test]
        public void SmallResultIsCalculated() {
            Assert.AreEqual(1E-50, SquareRoot(1E-100), 1E-40);
        }

        protected abstract double SquareRoot(double input);
    }

    [TestFixture]
    public class NewtonCSharpTest: NewtonTest {
        protected override double SquareRoot(double input) {
            return CSharp.Newton.SquareRoot(input);
        }
    }

    [TestFixture]
    public class NewtonFSharpTest: NewtonTest {
        protected override double SquareRoot(double input) {
            return FSharp.Newton.SquareRoot(input);
        }
    }
}
