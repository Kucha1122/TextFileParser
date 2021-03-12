using System.Collections.Generic;
using System.Data;
using TextFileParser.Model;

namespace TextFileParser.Helpers
{
    public interface IParser
    {
        public List<Product> Parse(string filePath);
        public List<string> ParseDataToFile(DataTable dataTable);
        public void Display(List<Product> products);
        public void DisplayBrandAvailability(List<Product> products);
        public List<Brand> GetBrandAvailability(List<Product> products);
    }
}