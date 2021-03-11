using System;
using TextFileParser.Helpers;

namespace TextFileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"katalog.txt";
            Parser parser = new Parser();

            var products = parser.Parse(filePath);
            parser.Display(products);
            parser.DisplayBrandAvailability(products);
            Console.ReadKey();
        }
    }
}