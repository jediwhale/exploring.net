using System;
using Exploring.Net.CSharp;

namespace Exploring.Net.Console {
    class Program {
        static void Main(string[] args) {
                while (true) {
                    System.Console.Write("? ");
                    var input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;
                    System.Console.WriteLine(SquareRoot(args[0], double.Parse(input)));
                }
            }

        static double SquareRoot(string version, double input) {
            if (version == "c") return input.SquareRoot();
            if (version == "f") return FSharp.Newton.SquareRoot(input);
            throw new ApplicationException("unknown version");
        }
    }
}
