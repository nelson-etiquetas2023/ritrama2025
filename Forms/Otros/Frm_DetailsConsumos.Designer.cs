namespace Ritrama2025.Forms.Otros
{
    partial class Frm_DetailsConsumos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DetailsConsumos));
            Grid_Items = new DataGridView();
            panel1 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            RowCounter = new Label();
            label1 = new Label();
            txt_rollid = new TextBox();
            txt_productid = new TextBox();
            label2 = new Label();
            txt_productName = new TextBox();
            label4 = new Label();
            txt_total = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)Grid_Items).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Grid_Items
            // 
            Grid_Items.AllowUserToAddRows = false;
            Grid_Items.AllowUserToDeleteRows = false;
            Grid_Items.AllowUserToResizeRows = false;
            Grid_Items.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Grid_Items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Items.Location = new Point(12, 205);
            Grid_Items.MultiSelect = false;
            Grid_Items.Name = "Grid_Items";
            Grid_Items.ReadOnly = true;
            Grid_Items.RowHeadersWidth = 33;
            Grid_Items.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_Items.Size = new Size(577, 294);
            Grid_Items.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(577, 100);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(197, 28);
            label3.Name = "label3";
            label3.Size = new Size(251, 32);
            label3.TabIndex = 4;
            label3.Text = "Detalle Movimientos";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(125, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // RowCounter
            // 
            RowCounter.AutoSize = true;
            RowCounter.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RowCounter.Location = new Point(12, 508);
            RowCounter.Name = "RowCounter";
            RowCounter.Size = new Size(185, 21);
            RowCounter.TabIndex = 2;
            RowCounter.Text = "0 Regitros Encontrados";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Roll-Id:";
            // 
            // txt_rollid
            // 
            txt_rollid.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_rollid.Location = new Point(105, 118);
            txt_rollid.Name = "txt_rollid";
            txt_rollid.ReadOnly = true;
            txt_rollid.Size = new Size(484, 23);
            txt_rollid.TabIndex = 4;
            // 
            // txt_productid
            // 
            txt_productid.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_productid.Location = new Point(105, 147);
            txt_productid.Name = "txt_productid";
            txt_productid.ReadOnly = true;
            txt_productid.Size = new Size(484, 23);
            txt_productid.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 150);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 5;
            label2.Text = "Product Id:";
            // 
            // txt_productName
            // 
            txt_productName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_productName.Location = new Point(105, 176);
            txt_productName.Name = "txt_productName";
            txt_productName.ReadOnly = true;
            txt_productName.Size = new Size(484, 23);
            txt_productName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 179);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 7;
            label4.Text = "Product Name:";
            // 
            // txt_total
            // 
            txt_total.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_total.Location = new Point(400, 505);
            txt_total.Name = "txt_total";
            txt_total.ReadOnly = true;
            txt_total.Size = new Size(189, 23);
            txt_total.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(261, 508);
            label5.Name = "label5";
            label5.Size = new Size(133, 15);
            label5.TabIndex = 10;
            label5.Text = "Total Consumo Length:";
            // 
            // Frm_DetailsConsumos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 677);
            Controls.Add(label5);
            Controls.Add(txt_total);
            Controls.Add(txt_productName);
            Controls.Add(label4);
            Controls.Add(txt_productid);
            Controls.Add(label2);
            Controls.Add(txt_rollid);
            Controls.Add(label1);
            Controls.Add(RowCounter);
            Controls.Add(panel1);
            Controls.Add(Grid_Items);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_DetailsConsumos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Movimientos";
            Load += Frm_DetailsConsumos_Load;
            ((System.ComponentModel.ISupportInitialize)Grid_Items).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Grid_Items;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label RowCounter;
        private Label label3;
        private Label label1;
        private TextBox txt_rollid;
        private TextBox txt_productid;
        private Label label2;
        private TextBox txt_productName;
        private Label label4;
        private TextBox txt_total;
        private Label label5;
    }
}