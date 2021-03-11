using System.Collections.Generic;
using TextFileParser.Model;

namespace TextFileParser.Helpers
{
    public interface IParser
    {
        public List<Product> Parse(string filePath);
        public List<string> ParseDataToFile(List<Product> products);
        public void Display(List<Product> products);
        public void DisplayBrandAvailability(List<Product> products);
    }
}