using System;

namespace Exploring.Net.CSharp {
    public struct Interval {
        public Interval(double start, double end) {
            this.start = start;
            this.end = end;
            MidPoint = (start + end) / 2.0;
        }

        public double MidPoint { get; }

        public double Size => Math.Abs(end - start);
        public bool CrossesZero => Math.Sign(start) == -Math.Sign(end) && Math.Sign(start) != 0;
        public bool Ascending => start < end;

        public Interval LeftHalf => new Interval(start, MidPoint);
        public Interval RightHalf => new Interval(MidPoint, end);
        public Interval Swap => new Interval(end, start);
        public Interval Map(Func<double, double> function) => new Interval(function(start), function(end));

        readonly double start;
        readonly double end;
    }
}
