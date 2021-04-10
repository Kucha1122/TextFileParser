namespace TextFileParser.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.productTable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.productTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Location = new System.Drawing.Point(6, 19);
            this.openFileDialog.Name = "openFileDialog";
            this.openFileDialog.Size = new System.Drawing.Size(93, 39);
            this.openFileDialog.TabIndex = 0;
            this.openFileDialog.Text = "Load";
            this.openFileDialog.UseVisualStyleBackColor = true;
            this.openFileDialog.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.openFileDialog);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TXT File";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // productTable
            // 
            this.productTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.productTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.productTable.Location = new System.Drawing.Point(12, 107);
            this.productTable.Name = "productTable";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.productTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.productTable.Size = new System.Drawing.Size(1420, 550);
            this.productTable.TabIndex = 2;
            this.productTable.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.productTable_CellValueChanged);
            this.productTable.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.productTable_DataError);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(1175, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 89);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stan magazynu";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 70);
            this.listBox1.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));
            this.messageLabel.Location = new System.Drawing.Point(11, 83);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(343, 21);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(220, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 68);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "XML File";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 39);
            this.button3.TabIndex = 0;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(428, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 68);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DB Connection";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(105, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 39);
            this.button4.TabIndex = 1;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 39);
            this.button5.TabIndex = 0;
            this.button5.Text = "Load";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1444, 666);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.productTable);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Integracja Systemów - Michał Kuśpit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.productTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.Label messageLabel;

        private System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.DataGridView productTable;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button openFileDialog;

        #endregion
    }
}