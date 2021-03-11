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
            this.openFileDialog = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.productTable = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.productTable)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Location = new System.Drawing.Point(6, 19);
            this.openFileDialog.Name = "openFileDialog";
            this.openFileDialog.Size = new System.Drawing.Size(93, 32);
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
            this.groupBox1.Size = new System.Drawing.Size(202, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TXT File";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // productTable
            // 
            this.productTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productTable.Location = new System.Drawing.Point(12, 76);
            this.productTable.Name = "productTable";
            this.productTable.Size = new System.Drawing.Size(1415, 550);
            this.productTable.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1444, 761);
            this.Controls.Add(this.productTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Integracja Systemów - Michał Kuśpit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.productTable)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView productTable;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button openFileDialog;

        #endregion
    }
}