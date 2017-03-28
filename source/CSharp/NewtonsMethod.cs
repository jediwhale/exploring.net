using System;

namespace Exploring.Net.CSharp {
    public class NewtonsMethod {

        public static double SquareRoot(double input) {
            return FindRoot(x => x * x - input, 1.0);
        }

        public static double FindRoot(Func<double, double> function, double guess) {
            Func<double, double> newtonsTransform = (x => x - function(x) / Derivative(function)(x));
            return FindFixedPoint(newtonsTransform, guess);
        }

        static Func<double, double> Derivative(Func<double, double> function) {
            return x => (function(x + smallAmount) - function(x)) / smallAmount;
        }

        static double FindFixedPoint(Func<double, double> function, double guess) {
            var oldGuess = guess;
            while (true) {
                var newGuess = function(oldGuess);
                if (double.IsNaN(newGuess) || double.IsInfinity(newGuess)) return newGuess;
                var goodEnough = Math.Abs((oldGuess - newGuess) / oldGuess) < smallAmount;
                if (goodEnough) return newGuess;
                oldGuess = newGuess;
            }
        }

        const double smallAmount = 1E-6;
    }
}
