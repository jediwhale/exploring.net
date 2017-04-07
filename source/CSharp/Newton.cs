using System;

namespace Exploring.Net.CSharp {
    public static class Newton {
        public static double SquareRoot(this double input) {
            if (input < 0.0) throw new ArgumentOutOfRangeException();
            if (input == 0.0) return input;
            return FindFixedPoint(guess => (guess + input / guess) / 2.0, 1.0);
        }

        public static double SquareRoot2(double input) {
            return FindRoot(x => x * x - input, 1.0);
        }

        public static double FindRoot(Func<double, double> function, double guess) {
            Func<double, double> newtonsTransform = x => x - function(x) / Derivative(function)(x);
            return FindFixedPoint(newtonsTransform, guess);
        }

        static Func<double, double> Derivative(Func<double, double> function) {
            return x => (function(x + smallAmount) - function(x)) / smallAmount;
        }

        static double FindFixedPoint(Func<double, double> improveGuess, double initialGuess) {
            var guess = initialGuess;
            while (true) {
                var newGuess = improveGuess(guess);
                if (double.IsNaN(newGuess) || double.IsInfinity(newGuess)) return newGuess;
                if (CloseEnough(guess, newGuess)) return newGuess;
                guess = newGuess;
            }
        }

        static bool CloseEnough(double guess, double newGuess) {
            return Math.Abs((guess - newGuess) / guess) < smallAmount;
        }

        const double smallAmount = 0.000001;
    }
}
