using System;

namespace Exploring.Net.CSharp {
    public struct Interval {
        public Interval(double start, double finish) {
            this.start = start;
            this.finish = finish;
        }

        public double MidPoint => (start + finish) / 2.0;
        public double Size => Math.Abs(finish - start);

        public bool CrossesZero => Math.Sign(start) == -Math.Sign(finish) && Math.Sign(start) != 0;
        public bool Ascending => start < finish;

        public Interval LeftHalf => new Interval(start, MidPoint);
        public Interval RightHalf => new Interval(MidPoint, finish);
        public Interval Swap => new Interval(finish, start);
        public Interval Map(Func<double, double> function) => new Interval(function(start), function(finish));

        readonly double start;
        readonly double finish;
    }
}
