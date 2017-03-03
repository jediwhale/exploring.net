using System;

namespace Exploring.Net.CSharp {
    public class HalfIntervalMethod {
        public HalfIntervalMethod(Func<double, double> function) {
            this.function = function;
        }

        public double FindRoot(Interval interval) {
            var values = interval.Map(function);
            if (!values.CrossesZero) {
                throw new ArgumentException("Values are not opposite signs.");
            }
            return FindRootByHalfIntervals(values.Ascending ? interval: interval.Swap);
        }

        double FindRootByHalfIntervals(Interval interval) {
            while (interval.Size >= 1E-10) {
                var value = function(interval.MidPoint);
                if (value == 0.0) break;
                interval = value < 0.0 ? interval.RightHalf : interval.LeftHalf;
            }
            return interval.MidPoint;
        }

        readonly Func<double, double> function;
    }
}
