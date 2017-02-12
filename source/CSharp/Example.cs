namespace Exploring.Net.CSharp {
    public class Example {
        public static int Recurse(int count) {
            return count == 0 ? 42 : Recurse(count - 1);
        }
    }
}
