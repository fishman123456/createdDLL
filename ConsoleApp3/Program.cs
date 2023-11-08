using ShambalaEncriptionLibrary_08_11_2023;
namespace ConsoleApp3

{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomEncoder Encoder = new CustomEncoder();
            Console.WriteLine("Hello, World!");
            Console.WriteLine(Encoder.encode("Hello, World!"));
        }
    }
}