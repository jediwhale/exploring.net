using System;

namespace Exploring.Net.CSharp {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Console.Write("? ");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                Console.WriteLine(Newton.Sqrt(double.Parse(input)));
            }
        }
    }
}
