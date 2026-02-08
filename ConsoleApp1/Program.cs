using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("enter number of small carpets");

            int smallrooms = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter number of big carpets");
            int bigrooms = Convert.ToInt32(Console.ReadLine());
            int bigcarpetprice = 35;
            int smallcarpetprice = 25;
            double tax = 0.06;

            Console.WriteLine($"number of small carpets : {smallrooms}");
            Console.WriteLine($"number of big carpets : {bigrooms}");

            Console.WriteLine($"price per small carpets : 25$ ");

            Console.WriteLine($"number per big carpets : 35$ ");


            int cost = bigrooms * bigcarpetprice + smallrooms * smallcarpetprice;
            double taxx = tax * cost;
            Console.WriteLine($"cost = {cost}");
            Console.WriteLine($"tax = {tax * cost} ");
            Console.WriteLine($"total estimate = {cost + taxx}");




        }

    }
    
}
