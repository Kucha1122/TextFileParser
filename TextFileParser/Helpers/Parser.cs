using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ConsoleTableExt;
using TextFileParser.Model;

namespace TextFileParser.Helpers
{
    public class Parser : IParser
    {
        private int Id { get; set; }
        public List<Product> Products { get; set; }
        public List<string> DupRows { get; set; }

        public Parser()
        {
            Products = new List<Product>();
            Id = 0;
        }
        public List<Product> Parse(string filePath)
        {
            Id = Products.Count + 1;
            
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] col = line.Split(';');
                int cores, clock;
                Int32.TryParse(col[6], out cores);
                Int32.TryParse(col[7], out clock);
                var product = new Product
                {
                    Id = Id,
                    Brand = col[0],
                    Screen = new Screen(col[1], col[2], col[3], col[4]),
                    Cpu = new Cpu(col[5], cores, clock),
                    Ram = col[8],
                    Disk = new Disk(col[9], col[10]),
                    GraphicCard = new GraphicCard(col[11], col[12]),
                    OperatingSystem = col[13],
                    DriverType = col[14]
                };
                Id++;
                Products.Add(product);
            }

            return Products;
        }

        public List<string> ParseDataToFile(DataTable dataTable)
        {
            List<string> dataFile = new();
            foreach (DataRow row in dataTable.Rows)
            {
                dataFile.Add(row[1]+";"+row[2]+";"
                             +row[3]+";"+row[4]+";"+row[5]+";"+row[6]+";"
                             +row[7]+";"+row[8]+";"+row[9]+";"+row[10]+";"
                             +row[11]+";"+row[12]+";"+row[13]+";"+row[14]+";"+row[15]);
            }

            return dataFile;
        }

        public List<Product> ParseXmlFile(string filePath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(filePath);

            foreach (XmlNode node in document.SelectNodes("laptops/laptop"))
            {
                int cores, clock;
                string diskType;
                var touchMap = new Dictionary<string, string>();
                touchMap.Add("no", "nie");
                touchMap.Add("yes", "tak");
                touchMap.Add("", node.ChildNodes[1].Attributes[0].Value);
                if (node.ChildNodes[4].Attributes.Count == 0)
                {
                    diskType = "";
                }
                else
                {
                    diskType = node.ChildNodes[4].Attributes[0].Value;
                }
                Int32.TryParse(node.ChildNodes[2]?.ChildNodes[1]?.InnerText, out cores);
                Int32.TryParse(node.ChildNodes[2]?.ChildNodes[2]?.InnerText, out clock);

                var product = new Product
                {
                    Id = int.Parse(node.Attributes[0].Value),
                    Brand = node.ChildNodes[0]?.InnerText,
                    Screen = new Screen(node.ChildNodes[1]?.ChildNodes[0]?.InnerText, node.ChildNodes[1]?.ChildNodes[1]?.InnerText, node.ChildNodes[1]?.ChildNodes[2]?.InnerText, touchMap[node.ChildNodes[1].Attributes[0].Value]),
                    Cpu = new Cpu(node.ChildNodes[2]?.ChildNodes[0]?.InnerText, cores, clock),
                    Ram = node.ChildNodes[3]?.InnerText,
                    Disk = new Disk(node.ChildNodes[4].ChildNodes[0]?.InnerText, diskType),
                    GraphicCard = new GraphicCard(node.ChildNodes[5]?.ChildNodes[0]?.InnerText, node.ChildNodes[5]?.ChildNodes[1]?.InnerText),
                    OperatingSystem = node.ChildNodes[6]?.InnerText,
                    DriverType = node.ChildNodes[7]?.InnerText
                };
                Products.Add(product);
            }

            return Products;
        }

        public void WriteXmlFile(string filePath, DataTable dataTable)
        {
            var touchMap = new Dictionary<string, string>();
            touchMap.Add("nie", "no");
            touchMap.Add("tak", "yes");
            using (XmlWriter xmlW = XmlWriter.Create(filePath))
            {
                xmlW.WriteStartElement("laptops");
                foreach (DataRow row in dataTable.Rows)
                {
                    xmlW.WriteStartElement("laptop");
                    xmlW.WriteAttributeString("id", row[0].ToString());
                    xmlW.WriteElementString("manufacturer", row[1].ToString());
                    xmlW.WriteStartElement("screen");
                    xmlW.WriteAttributeString("touch", touchMap[row[5].ToString()]);
                    xmlW.WriteElementString("size", row[2].ToString());
                    xmlW.WriteElementString("resolution", row[3].ToString());
                    xmlW.WriteElementString("type", row[4].ToString());
                    xmlW.WriteEndElement();
                    xmlW.WriteStartElement("processor");
                    xmlW.WriteElementString("name", row[6].ToString());
                    xmlW.WriteElementString("physical_cores", row[7].ToString());
                    xmlW.WriteElementString("clock_speed", row[8].ToString());
                    xmlW.WriteEndElement();
                    xmlW.WriteElementString("ram", row[9].ToString());
                    xmlW.WriteStartElement("disc");
                    xmlW.WriteAttributeString("type", row[11].ToString());
                    xmlW.WriteElementString("storage", row[10].ToString());
                    xmlW.WriteEndElement();
                    xmlW.WriteStartElement("graphic_card");
                    xmlW.WriteElementString("name", row[12].ToString());
                    xmlW.WriteElementString("memory", row[13].ToString());
                    xmlW.WriteEndElement();
                    xmlW.WriteElementString("os", row[14].ToString());
                    xmlW.WriteElementString("disc_reader", row[15].ToString());
                    xmlW.WriteEndElement();
                }
                xmlW.Close();
            }
        }

        public List<string> ParseDataToFile(List<Product> products)
        {
            List<string> dataFile = new();

            foreach (var product in products)
            {
                dataFile.Add(product.Brand+";"+product.Screen.Size+";"+product.Screen.Resolution+";"
                +product.Screen.Type+";"+product.Screen.Touch+";"+product.Cpu.Series+";"+product.Cpu.Cores+";"
                +product.Cpu.Clock+";"+product.Ram+";"+product.Disk.Capacity+";"+product.Disk.Type+";"
                +product.GraphicCard.Type+";"+product.GraphicCard.Vram+";"+product.OperatingSystem+";"+product.DriverType);
            }

            return dataFile;
        }

        public void Display(List<Product> products)
        {
            var tableData = new List<List<object>>();
            foreach (var product in products)
            {
                var row = new List<object>
                {
                    product.Id,
                    product.Brand,
                    product.Screen.Size, product.Screen.Type, product.Screen.Touch,
                    product.Cpu.Series, product.Cpu.Cores, product.Cpu.Clock,
                    product.Ram,
                    product.Disk.Capacity, product.Disk.Type,
                    product.GraphicCard.Type, product.GraphicCard.Vram,
                    product.OperatingSystem,
                    product.DriverType
                };
                
                tableData.Add(row);
            }
            
            ConsoleTableBuilder
                .From(tableData)
                .WithFormat(ConsoleTableBuilderFormat.Alternative)
                .WithColumn("Id", "Producent", "Przekątna ekranu", "Typ matrycy", "Dotykowy ekran",
                    "Nazwa CPU", "Ilość rdzeni", "Prędkość taktowania(MHz)","Pamięć RAM", "Pojemność dysku",
                    "Rodzaj dysku", "GPU", "Ilość VRAM", "Systemu operacyjny", "Napęd")
                .ExportAndWriteLine(TableAligntment.Left);
        }

        public void DisplayBrandAvailability(List<Product> products)
        {
            List<Brand> brands = new();

            foreach (var product in products)
            {
                var brand = brands.SingleOrDefault(x => x.Name == product.Brand);
                if (brand != null)
                {
                    brand.Availablity++;
                }
                else
                {
                    brands.Add(new Brand(product.Brand, 1));
                }
            }

            foreach (var brand in brands)
            {
                Console.WriteLine(brand.Name+": "+brand.Availablity);
            }
        }

        public List<Brand> GetBrandAvailability(List<Product> products)
        {
            List<Brand> brands = new();

            foreach (var product in products)
            {
                var brand = brands.SingleOrDefault(x => x.Name == product.Brand);
                if (brand != null)
                {
                    brand.Availablity++;
                }
                else
                {
                    brands.Add(new Brand(product.Brand, 1));
                }
            }

            return brands;
        }

        public void InsertDataToDb(DataTable dataTable)
        {
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TextFileParserDB;MultipleActiveResultSets=true";
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql = "";
            
            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    sql = @"INSERT INTO Products(Id, BrandName, ScreenSize, ScreenResolution, ScreenType, ScreenTouch,
                    CpuSeries, CpuCores, CpuClock, Ram, DiskCapacity, DiskType, GpuType, GpuVram, OperatingSystem, DriverType)
                    values('" + row[0] + "', '" + row[1] + "', '" + row[2] + "', '" + row[3] + "', '" + row[4] +
                          "', '" + row[5] + "', '" + row[6] + "', '" + row[7] + "', '" + row[8] + "', '" + row[9] +
                          "', '" +
                          row[10] + "', '" + row[11] + "', '" + row[12] + "', '" + row[13] + "', '" + row[14] + "', '" +
                          row[15] + "')";

                    cmd = new SqlCommand(sql, con);
                    adapter.InsertCommand = new SqlCommand(sql, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    Console.WriteLine("Same row");
                }
            }
            con.Close();
        }

        public List<Product> SelectDataFromDb()
        {
            var prod = new List<Product>();
            string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TextFileParserDB;MultipleActiveResultSets=true";
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            SqlCommand cmd;
            SqlDataReader dataReader;
            String sql = @"SELECT Id, BrandName, ScreenSize, ScreenResolution, ScreenType, ScreenTouch,
            CpuSeries, CpuCores, CpuClock, Ram, DiskCapacity, DiskType, GpuType, GpuVram, OperatingSystem, DriverType FROM Products";
            cmd = new SqlCommand(sql, con);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                var product = new Product
                {
                    Id = int.Parse(dataReader.GetValue(0).ToString()),
                    Brand = dataReader.GetValue(1).ToString(),
                    Screen = new Screen(dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString()),
                    Cpu = new Cpu(dataReader.GetValue(6).ToString(), int.Parse(dataReader.GetValue(7).ToString()), int.Parse(dataReader.GetValue(8).ToString())),
                    Ram = dataReader.GetValue(9).ToString(),
                    Disk = new Disk(dataReader.GetValue(10).ToString(), dataReader.GetValue(11).ToString()),
                    GraphicCard = new GraphicCard(dataReader.GetValue(12).ToString(), dataReader.GetValue(13).ToString()),
                    OperatingSystem = dataReader.GetValue(14).ToString(),
                    DriverType = dataReader.GetValue(15).ToString()
                };
                prod.Add(product);
                cmd.Dispose();
            }
            
            con.Close();
            return prod;
        }
    }
}