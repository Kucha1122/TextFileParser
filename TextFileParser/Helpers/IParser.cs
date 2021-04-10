using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TextFileParser.Model;

namespace TextFileParser.Helpers
{
    public interface IParser
    {
        public List<Product> Parse(string filePath);
        public List<string> ParseDataToFile(DataTable dataTable);
        public List<Product> ParseXmlFile(string filePath);
        public void WriteXmlFile(string filePath, DataTable dataTable);
        public void Display(List<Product> products);
        public void DisplayBrandAvailability(List<Product> products);
        public List<Brand> GetBrandAvailability(List<Product> products);
        public void InsertDataToDb(DataTable dataTable);
        public List<Product> SelectDataFromDb();
    }
}