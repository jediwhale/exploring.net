namespace Exploring.Net.Console {
    class Program {
        static void Main(string[] args) {
            if (args[0] == "c") {
                while (true) {
                    System.Console.Write("? ");
                    var input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;
                    System.Console.WriteLine(CSharp.Newton.Sqrt(double.Parse(input)));
                }
            }
            else
            if (args[0] == "f") {
                while (true) {
                    System.Console.Write("? ");
                    var input = System.Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;
                    System.Console.WriteLine(FSharp.Newton.Sqrt(double.Parse(input)));
                }
            }
        }
    }
}
