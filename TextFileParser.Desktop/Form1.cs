using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextFileParser.Helpers;

namespace TextFileParser.Desktop
{
    public partial class Form1 : Form
    {
        private OpenFileDialog _openFileDialog;
        private Parser _parser;
        private DataTable _table;
        public Form1()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog();
            _parser = new Parser();
            _table = new DataTable();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            _openFileDialog.ShowDialog();
            string filename = _openFileDialog.FileName;
            var products = _parser.Parse(filename);

            foreach (var product in products)
            {
                if (_table.Rows.Contains(product.Id))
                {
                    continue;
                }
                _table.Rows.Add(product.Id, product.Brand, product.Screen.Size, product.Screen.Resolution,
                    product.Screen.Type, product.Screen.Touch, product.Cpu.Series, product.Cpu.Cores, product.Cpu.Clock,
                    product.Ram, product.Disk.Capacity, product.Disk.Type, product.GraphicCard.Type,
                    product.GraphicCard.Vram,
                    product.OperatingSystem, product.DriverType);
            }

            productTable.DataSource = _table;
            productTable.Width = 0;
            productTable.Height = 0;
            productTable.AutoSize = true;
            productTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            productTable.BackgroundColor = SystemColors.ControlLightLight;
            productTable.BorderStyle = BorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] tableHeaders = 
            {
                "Id", "Producent", "Przekątna ekranu", "Rozdzielczość", "Typ matrycy", "Dotykowy ekran",
                "Nazwa CPU", "Ilość rdzeni", "Prędkość taktowania(MHz)", "Pamięć RAM", "Pojemność dysku",
                "Rodzaj dysku", "GPU", "Ilość VRAM", "Systemu operacyjny", "Napęd"
            };
            
            _table.Columns.Add(tableHeaders[0], typeof(int));
            _table.PrimaryKey = new DataColumn[] { _table.Columns["Id"] };
            
            for(int i=1; i<tableHeaders.Length; i++)
            {
                _table.Columns.Add(tableHeaders[i], typeof(string));
            }
        }
    }
}