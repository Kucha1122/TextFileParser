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
            messageLabel.Text = $"{_products.Count} rows loaded from a file";
            messageLabel.ForeColor = Color.Green;
            /*productTable.Width = 0;
            productTable.Height = 0;
            productTable.AutoSize = true;*/
            productTable.ScrollBars = ScrollBars.Both;
            productTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            productTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            productTable.BackgroundColor = SystemColors.ControlLightLight;
            productTable.BorderStyle = BorderStyle.None;

            listBox1.Items.Clear();
            foreach (var brand in _parser.GetBrandAvailability(_products))
            {
                listBox1.Items.Add(brand.Name+": "+brand.Availablity);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] tableHeaders = 
            {
                "Id", "Producent", "Przekątna ekranu", "Rozdzielczość", "Typ matrycy", "Dotykowy ekran",
                "Nazwa CPU", "Ilość rdzeni", "Prędkość taktowania(MHz)", "Pamięć RAM", "Pojemność dysku",
                "Rodzaj dysku", "GPU", "Ilość VRAM", "Systemu operacyjny", "Napęd"
            };
            
            _table.Columns.Add(tableHeaders[0], typeof(Int32));
            _table.Columns[0].ReadOnly = true;
            _table.Columns[0].AutoIncrement = true;  
            _table.Columns[0].AutoIncrementSeed = 1;  
            _table.Columns[0].AutoIncrementStep = 1;  
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
            _saveFileDialog.Filter = @"Txt files (*.txt)|*.txt|All files (*.*)|*.*";
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

                messageLabel.Text = @"All rows have been saved in a file";
                messageLabel.ForeColor = Color.Green;
                sw.Close();
            }
        }

        private void productTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            string errorMessage = "Error in a column [" +
                         productTable.Columns[e.ColumnIndex].HeaderText +
                         "]\n\n" + "Please input correct data";
            MessageBox.Show(errorMessage, @"Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openXmlFileDialog = new OpenFileDialog();
            openXmlFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openXmlFileDialog.FilterIndex = 0;
            openXmlFileDialog.DefaultExt = "xml";
            if (openXmlFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(openXmlFileDialog.FileName), ".xml",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Wrong file type, please select XML File.","Invalid File Type",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    _products = _parser.ParseXmlFile(openXmlFileDialog.FileName);
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
                    messageLabel.Text = $"{_products.Count} rows loaded from a file";
                    messageLabel.ForeColor = Color.Green;
                    /*productTable.Width = 0;
                    productTable.Height = 0;
                    productTable.AutoSize = true;*/
                    productTable.ScrollBars = ScrollBars.Both;
                    productTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    productTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    productTable.BackgroundColor = SystemColors.ControlLightLight;
                    productTable.BorderStyle = BorderStyle.None;

                    listBox1.Items.Clear();
                    foreach (var brand in _parser.GetBrandAvailability(_products))
                    {
                        listBox1.Items.Add(brand.Name+": "+brand.Availablity);
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveXmlFileDialog = new SaveFileDialog();
            saveXmlFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveXmlFileDialog.FilterIndex = 0;
            saveXmlFileDialog.DefaultExt = "xml";

            if (saveXmlFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveXmlFileDialog.FileName;
                _parser.WriteXmlFile(filePath, _table);

                messageLabel.Text = @"All rows have been saved in a file";
                messageLabel.ForeColor = Color.Green;
            }
        }
    }
}