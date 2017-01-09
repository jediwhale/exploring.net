using System;

namespace Exploring.Net.CSharp {
    public class Newton {
        public static double Sqrt(double input) {
            if (input == 0.0) return input;
            var guess = 1.0;
            while (true) {
                var newGuess = (guess + input / guess) / 2.0;
                if (Math.Abs((guess - newGuess) / guess) < 0.001) return newGuess;
                guess = newGuess;
            }
        }
    }
}
