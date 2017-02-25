using System;
using Exploring.Net.CSharp;
using NUnit.Framework;

namespace Exploring.Net.UnitTest {
    public abstract class HalfIntervalTest {

        [Test]
        public void MidpointIsRoot() {
            Assert.AreEqual(0.0, FindSineRoot(-0.5, 0.5));
        }

        [Test]
        public void RootIsFoundWithPositiveValueAtLeft() {
            Assert.AreEqual(Math.PI, FindSineRoot(Math.PI - 0.1, Math.PI + 0.5), 1E-10);
        }

        [Test]
        public void RootIsFoundWithPositiveValueAtRight() {
            Assert.AreEqual(Math.PI, FindSineRoot(Math.PI + 0.5, Math.PI - 0.1), 1E-10);
        }

        protected abstract double FindSineRoot(double left, double right);
    }

    [TestFixture]
    public class HalfIntervalCSharpTest: HalfIntervalTest {
        protected override double FindSineRoot(double left, double right) {
            return new DoubleFunction(Math.Sin).FindRoot(new Interval(left, right));
        }
    }
}
