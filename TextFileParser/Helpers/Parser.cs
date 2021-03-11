﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleTableExt;
using TextFileParser.Model;

namespace TextFileParser.Helpers
{
    public class Parser : IParser
    {
        public List<Product> Parse(string filePath)
        {
            List <Product> products = new();
            if (!File.Exists(filePath))
                throw new Exception("File does not exist!");
            
            List<string> lines = File.ReadAllLines(filePath).ToList();
            int id = 0;
            foreach (var line in lines)
            {
                string[] col = line.Split(';');
                var product = new Product
                {
                    Id = id,
                    Brand = col[0],
                    Screen = new Screen(col[1], col[2], col[3], col[4]),
                    Cpu = new Cpu(col[5], col[6], col[7]),
                    Ram = col[8],
                    Disk = new Disk(col[9], col[10]),
                    GraphicCard = new GraphicCard(col[11], col[12]),
                    OperatingSystem = col[13],
                    DriverType = col[14]
                };
                id++;
                products.Add(product);
            }

            return products;
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
    }
}