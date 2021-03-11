using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TextFileParser.Helpers;
using TextFileParser.Model;

namespace TextFileParser.Desktop
{
    public partial class Form1 : Form
    {
        private OpenFileDialog _openFileDialog;
        private SaveFileDialog _saveFileDialog;
        private List<Product> _products;
        private Parser _parser;
        private DataTable _table;
        public Form1()
        {
            InitializeComponent();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
            _products = new List<Product>();
            _parser = new Parser();
            _table = new DataTable();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            _openFileDialog.ShowDialog();
            string filename = _openFileDialog.FileName;
            _products = _parser.Parse(filename);

            foreach (var product in _products)
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
            _table.Columns[0].ReadOnly = true;
            _table.PrimaryKey = new DataColumn[] { _table.Columns["Id"] };
            
            for(int i=1; i<tableHeaders.Length; i++)
            {
                if (i == 7 || i == 8)
                {
                    _table.Columns.Add(tableHeaders[i], typeof(int));
                }
                else
                {
                    _table.Columns.Add(tableHeaders[i], typeof(string));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            _saveFileDialog.FilterIndex = 2;
            _saveFileDialog.RestoreDirectory = true;

            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = _saveFileDialog.FileName;
                StreamWriter sw = new StreamWriter(File.Create(filePath));
                foreach (var line in _parser.ParseDataToFile(_table))
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }

        private void productTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            string errorMessage = "Error in a column [" +
                         productTable.Columns[e.ColumnIndex].HeaderText +
                         "]\n\n" + "Please input correct data";
            MessageBox.Show(errorMessage, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = false;
        }
    }
}