namespace Ritrama2025.Forms.Otros
{
    partial class Frm_Imports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Imports));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            label1 = new Label();
            txt_buscar = new TextBox();
            btn_search = new Button();
            Grid_Items = new DataGridView();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            rad_rollid = new RadioButton();
            rad_product_name = new RadioButton();
            rad_productid = new RadioButton();
            label3 = new Label();
            label4 = new Label();
            btn_load_data = new Button();
            chk_valid_products = new CheckBox();
            txt_number_rows = new TextBox();
            txt_warning = new TextBox();
            txt_fileName = new TextBox();
            label6 = new Label();
            txt_filePath = new TextBox();
            label7 = new Label();
            btn_saveDatabase = new Button();
            checkBox1 = new CheckBox();
            button1 = new Button();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            chk_product_NoFound = new CheckBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Grid_Items).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label5);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(985, 100);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(146, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 51);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(209, 20);
            label5.Name = "label5";
            label5.Size = new Size(401, 50);
            label5.TabIndex = 0;
            label5.Text = "Importacion de Datos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 1;
            label1.Text = "Buscar Producto Por:";
            // 
            // txt_buscar
            // 
            txt_buscar.Location = new Point(136, 118);
            txt_buscar.Name = "txt_buscar";
            txt_buscar.Size = new Size(566, 23);
            txt_buscar.TabIndex = 2;
            // 
            // btn_search
            // 
            btn_search.Image = (Image)resources.GetObject("btn_search.Image");
            btn_search.Location = new Point(708, 118);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(115, 23);
            btn_search.TabIndex = 3;
            btn_search.Text = "Buscar";
            btn_search.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_search.UseVisualStyleBackColor = true;
            // 
            // Grid_Items
            // 
            Grid_Items.AllowUserToAddRows = false;
            Grid_Items.AllowUserToDeleteRows = false;
            Grid_Items.AllowUserToOrderColumns = true;
            Grid_Items.AllowUserToResizeRows = false;
            Grid_Items.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Grid_Items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Items.Location = new Point(12, 147);
            Grid_Items.MultiSelect = false;
            Grid_Items.Name = "Grid_Items";
            Grid_Items.ReadOnly = true;
            Grid_Items.RowHeadersWidth = 32;
            Grid_Items.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid_Items.Size = new Size(811, 288);
            Grid_Items.TabIndex = 4;
            // 
            // richTextBox1
            // 
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(12, 604);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(811, 96);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 586);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 6;
            label2.Text = "Notificaciones :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rad_rollid);
            groupBox1.Controls.Add(rad_product_name);
            groupBox1.Controls.Add(rad_productid);
            groupBox1.Location = new Point(12, 441);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrar por: ";
            // 
            // rad_rollid
            // 
            rad_rollid.AutoSize = true;
            rad_rollid.Location = new Point(6, 54);
            rad_rollid.Name = "rad_rollid";
            rad_rollid.Size = new Size(60, 19);
            rad_rollid.TabIndex = 10;
            rad_rollid.TabStop = true;
            rad_rollid.Text = "Roll-Id";
            rad_rollid.UseVisualStyleBackColor = true;
            // 
            // rad_product_name
            // 
            rad_product_name.AutoSize = true;
            rad_product_name.Location = new Point(6, 38);
            rad_product_name.Name = "rad_product_name";
            rad_product_name.Size = new Size(121, 19);
            rad_product_name.TabIndex = 9;
            rad_product_name.TabStop = true;
            rad_product_name.Text = "Nombre Producto";
            rad_product_name.UseVisualStyleBackColor = true;
            // 
            // rad_productid
            // 
            rad_productid.AutoSize = true;
            rad_productid.Location = new Point(6, 22);
            rad_productid.Name = "rad_productid";
            rad_productid.Size = new Size(83, 19);
            rad_productid.TabIndex = 8;
            rad_productid.TabStop = true;
            rad_productid.Text = "Product Id.";
            rad_productid.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(218, 454);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 8;
            label3.Text = "Numero de Filas :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(236, 483);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 9;
            label4.Text = "Advertencias :";
            // 
            // btn_load_data
            // 
            btn_load_data.Image = (Image)resources.GetObject("btn_load_data.Image");
            btn_load_data.Location = new Point(829, 147);
            btn_load_data.Name = "btn_load_data";
            btn_load_data.Size = new Size(145, 73);
            btn_load_data.TabIndex = 10;
            btn_load_data.Text = "Cargar Datos";
            btn_load_data.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_load_data.UseVisualStyleBackColor = true;
            btn_load_data.Click += Btn_load_data_Click;
            // 
            // chk_valid_products
            // 
            chk_valid_products.AutoSize = true;
            chk_valid_products.Location = new Point(652, 441);
            chk_valid_products.Name = "chk_valid_products";
            chk_valid_products.Size = new Size(171, 19);
            chk_valid_products.TabIndex = 11;
            chk_valid_products.Text = "Validacion de los Productos";
            chk_valid_products.UseVisualStyleBackColor = true;
            // 
            // txt_number_rows
            // 
            txt_number_rows.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_number_rows.Location = new Point(323, 451);
            txt_number_rows.Name = "txt_number_rows";
            txt_number_rows.ReadOnly = true;
            txt_number_rows.Size = new Size(255, 23);
            txt_number_rows.TabIndex = 12;
            // 
            // txt_warning
            // 
            txt_warning.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_warning.Location = new Point(323, 480);
            txt_warning.Name = "txt_warning";
            txt_warning.ReadOnly = true;
            txt_warning.Size = new Size(255, 23);
            txt_warning.TabIndex = 13;
            // 
            // txt_fileName
            // 
            txt_fileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_fileName.Location = new Point(323, 509);
            txt_fileName.Name = "txt_fileName";
            txt_fileName.ReadOnly = true;
            txt_fileName.Size = new Size(255, 23);
            txt_fileName.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(216, 512);
            label6.Name = "label6";
            label6.Size = new Size(101, 15);
            label6.TabIndex = 14;
            label6.Text = "Nombre Archivo :";
            // 
            // txt_filePath
            // 
            txt_filePath.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_filePath.Location = new Point(323, 538);
            txt_filePath.Name = "txt_filePath";
            txt_filePath.ReadOnly = true;
            txt_filePath.Size = new Size(255, 23);
            txt_filePath.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(280, 541);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 16;
            label7.Text = "Ruta :";
            // 
            // btn_saveDatabase
            // 
            btn_saveDatabase.Image = (Image)resources.GetObject("btn_saveDatabase.Image");
            btn_saveDatabase.Location = new Point(828, 226);
            btn_saveDatabase.Name = "btn_saveDatabase";
            btn_saveDatabase.Size = new Size(145, 73);
            btn_saveDatabase.TabIndex = 18;
            btn_saveDatabase.Text = "Guardar BD";
            btn_saveDatabase.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_saveDatabase.UseVisualStyleBackColor = true;
            btn_saveDatabase.Click += Btn_saveDatabase_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(652, 491);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(123, 19);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "Repeticion Roll-Id ";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(828, 305);
            button1.Name = "button1";
            button1.Size = new Size(145, 73);
            button1.TabIndex = 20;
            button1.Text = "Reporte Data";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(652, 516);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(178, 19);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "Validar Columnas Numericas";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(652, 541);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(152, 19);
            checkBox3.TabIndex = 22;
            checkBox3.Text = "Validar Columnas Fecha";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // chk_product_NoFound
            // 
            chk_product_NoFound.AutoSize = true;
            chk_product_NoFound.Location = new Point(652, 466);
            chk_product_NoFound.Name = "chk_product_NoFound";
            chk_product_NoFound.Size = new Size(213, 19);
            chk_product_NoFound.TabIndex = 23;
            chk_product_NoFound.Text = "Guardar Productos No Encontrados";
            chk_product_NoFound.UseVisualStyleBackColor = true;
            // 
            // Frm_Imports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 712);
            Controls.Add(chk_product_NoFound);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(button1);
            Controls.Add(checkBox1);
            Controls.Add(btn_saveDatabase);
            Controls.Add(txt_filePath);
            Controls.Add(label7);
            Controls.Add(txt_fileName);
            Controls.Add(label6);
            Controls.Add(txt_warning);
            Controls.Add(txt_number_rows);
            Controls.Add(chk_valid_products);
            Controls.Add(btn_load_data);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(Grid_Items);
            Controls.Add(btn_search);
            Controls.Add(txt_buscar);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_Imports";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modulo de Importacion de Datos";
            Load += Frm_Imports_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Grid_Items).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txt_buscar;
        private Button btn_search;
        private DataGridView Grid_Items;
        private RichTextBox richTextBox1;
        private Label label2;
        private Label label5;
        private GroupBox groupBox1;
        private RadioButton rad_rollid;
        private RadioButton rad_product_name;
        private RadioButton rad_productid;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Button btn_load_data;
        private CheckBox chk_valid_products;
        private TextBox txt_number_rows;
        private TextBox txt_warning;
        private TextBox txt_fileName;
        private Label label6;
        private TextBox txt_filePath;
        private Label label7;
        private Button btn_saveDatabase;
        private CheckBox checkBox1;
        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox chk_product_NoFound;
    }
}