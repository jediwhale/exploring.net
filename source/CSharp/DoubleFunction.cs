using System;

namespace Exploring.Net.CSharp {
    public class DoubleFunction {
        public DoubleFunction(Func<double, double> function) {
            this.function = function;
        }

        public double FindRoot(Interval interval) {
            var values = interval.Map(function);
            if (!values.CrossesZero) {
                throw new ArgumentException("Values are not opposite signs.");
            }
            return FindRootByHalfIntervals(values.Ascending ? interval.Swap : interval);
        }

        double FindRootByHalfIntervals(Interval interval) {
            while (!interval.SmallEnough) {
                var value = function(interval.MidPoint);
                if (value == 0.0) return interval.MidPoint;
                interval = value > 0.0 ? interval.RightHalf : interval.LeftHalf;
            }
            return interval.MidPoint;
        }

        readonly Func<double, double> function;
    }
}
