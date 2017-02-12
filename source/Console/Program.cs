﻿using System;
using System.Collections.Generic;

namespace Exploring.Net.Console {
    public class Program {
        static void Main(string[] args) {
            while (true) {
                System.Console.Write("? ");
                input = System.Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                System.Console.WriteLine(functions[args[0]]());
            }
        }

        static string input;

        static readonly Dictionary<string, Func<string>> functions =
            new Dictionary<string, Func<string>> {
                {"c", () => DoubleFunction(CSharp.Newton.SquareRoot)},
                {"f", () => DoubleFunction(FSharp.Newton.SquareRoot)},
                {"cr", () => IntFunction(CSharp.Example.Recurse)},
                {"fr", () => IntFunction(FSharp.Example.Recurse)}
            };

        static string DoubleFunction(Func<double, double> calculate) {
            return calculate(double.Parse(input)).ToString();
        }

        static string IntFunction(Func<int, int> calculate) {
            return calculate(int.Parse(input)).ToString();
        }
    }
}
