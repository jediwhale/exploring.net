using System;

namespace Exploring.Net.CSharp {
    public class Newton {
        public static double SquareRoot(double input) {
            if (input < 0.0) throw new ArgumentOutOfRangeException();
            if (input == 0.0) return input;
            var guess = 1.0;
            while (true) {
                var newGuess = CalculateNewGuess(input, guess);
                if (CloseEnough(guess, newGuess)) return newGuess;
                guess = newGuess;
            }
        }

        static double CalculateNewGuess(double input, double guess) {
            return (guess + input / guess) / 2.0;
        }

        static bool CloseEnough(double guess, double newGuess) {
            return Math.Abs((guess - newGuess) / guess) < 0.000001;
        }
    }
}
