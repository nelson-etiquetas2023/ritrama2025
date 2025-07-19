namespace Ritrama2025.Forms
{
    partial class Frm_Inventarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Inventarios));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            groupBox3 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            label8 = new Label();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            label11 = new Label();
            groupBox4 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            dataGridView2 = new DataGridView();
            button2 = new Button();
            label10 = new Label();
            textBox2 = new TextBox();
            tabPage6 = new TabPage();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            ListColumns = new ListBox();
            chk_checkFileCorrect = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
            rad_rollos = new RadioButton();
            rad_hojas = new RadioButton();
            rad_graphics = new RadioButton();
            rad_master = new RadioButton();
            btn_import_excel = new Button();
            btn_load_sheet = new Button();
            label3 = new Label();
            txt_file_path = new TextBox();
            label2 = new Label();
            txt_file_name = new TextBox();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(12, 367);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(986, 349);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(978, 321);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Master";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Location = new Point(7, 225);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 84);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtrar Por: ";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(13, 22);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(80, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Product Id";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(13, 38);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(140, 19);
            radioButton2.TabIndex = 6;
            radioButton2.TabStop = true;
            radioButton2.Text = "Nombre del Producto";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(965, 150);
            dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(292, 40);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 22);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 1;
            label8.Text = "Buscar por:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(279, 23);
            textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(978, 321);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Graphics";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(978, 321);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Hojas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(978, 321);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Rollos Cortados";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(label11);
            tabPage5.Controls.Add(groupBox4);
            tabPage5.Controls.Add(dataGridView2);
            tabPage5.Controls.Add(button2);
            tabPage5.Controls.Add(label10);
            tabPage5.Controls.Add(textBox2);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(978, 321);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Data Import";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(623, 17);
            label11.Name = "label11";
            label11.Size = new Size(106, 21);
            label11.TabIndex = 14;
            label11.Text = "Data Import:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Controls.Add(radioButton4);
            groupBox4.Location = new Point(7, 220);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 84);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Filtrar Por: ";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(13, 22);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(80, 19);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.Text = "Product Id";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(13, 38);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(140, 19);
            radioButton4.TabIndex = 6;
            radioButton4.TabStop = true;
            radioButton4.Text = "Nombre del Producto";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(7, 64);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(965, 150);
            dataGridView2.TabIndex = 11;
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(292, 35);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Buscar";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 17);
            label10.Name = "label10";
            label10.Size = new Size(66, 15);
            label10.TabIndex = 9;
            label10.Text = "Buscar por:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(7, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(279, 23);
            textBox2.TabIndex = 8;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(978, 321);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Notificaciones";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1010, 100);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(254, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(306, 24);
            label1.Name = "label1";
            label1.Size = new Size(411, 50);
            label1.TabIndex = 0;
            label1.Text = "Control de Inventarios";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(ListColumns);
            groupBox1.Controls.Add(chk_checkFileCorrect);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btn_import_excel);
            groupBox1.Controls.Add(btn_load_sheet);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txt_file_path);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txt_file_name);
            groupBox1.Location = new Point(12, 128);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(982, 233);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Importar Data de Excel";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(675, 116);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 13;
            label9.Text = "Propiedades de la columnas: ";
            // 
            // ListColumns
            // 
            ListColumns.FormattingEnabled = true;
            ListColumns.Items.AddRange(new object[] { "1.- Product Id., Columna1" });
            ListColumns.Location = new Point(529, 133);
            ListColumns.Name = "ListColumns";
            ListColumns.Size = new Size(447, 94);
            ListColumns.TabIndex = 12;
            // 
            // chk_checkFileCorrect
            // 
            chk_checkFileCorrect.AutoSize = true;
            chk_checkFileCorrect.Enabled = false;
            chk_checkFileCorrect.Location = new Point(11, 194);
            chk_checkFileCorrect.Name = "chk_checkFileCorrect";
            chk_checkFileCorrect.Size = new Size(199, 19);
            chk_checkFileCorrect.TabIndex = 11;
            chk_checkFileCorrect.Text = "Localizacion Correcta de Archivo";
            chk_checkFileCorrect.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(675, 19);
            label7.Name = "label7";
            label7.Size = new Size(182, 21);
            label7.TabIndex = 10;
            label7.Text = "Resumen de Procesos :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(529, 90);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 9;
            label6.Text = "Advertencias : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(529, 67);
            label5.Name = "label5";
            label5.Size = new Size(148, 15);
            label5.TabIndex = 8;
            label5.Text = "Productos no registrados : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(529, 44);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 7;
            label4.Text = "Numero de Registros : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rad_rollos);
            groupBox2.Controls.Add(rad_hojas);
            groupBox2.Controls.Add(rad_graphics);
            groupBox2.Controls.Add(rad_master);
            groupBox2.Location = new Point(302, 116);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 111);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo Producto";
            // 
            // rad_rollos
            // 
            rad_rollos.AutoSize = true;
            rad_rollos.Location = new Point(25, 77);
            rad_rollos.Name = "rad_rollos";
            rad_rollos.Size = new Size(98, 19);
            rad_rollos.TabIndex = 3;
            rad_rollos.TabStop = true;
            rad_rollos.Text = "Rollo Cortado";
            rad_rollos.UseVisualStyleBackColor = true;
            // 
            // rad_hojas
            // 
            rad_hojas.AutoSize = true;
            rad_hojas.Location = new Point(25, 59);
            rad_hojas.Name = "rad_hojas";
            rad_hojas.Size = new Size(55, 19);
            rad_hojas.TabIndex = 2;
            rad_hojas.TabStop = true;
            rad_hojas.Text = "Hojas";
            rad_hojas.UseVisualStyleBackColor = true;
            // 
            // rad_graphics
            // 
            rad_graphics.AutoSize = true;
            rad_graphics.Location = new Point(25, 40);
            rad_graphics.Name = "rad_graphics";
            rad_graphics.Size = new Size(71, 19);
            rad_graphics.TabIndex = 1;
            rad_graphics.TabStop = true;
            rad_graphics.Text = "Graphics";
            rad_graphics.UseVisualStyleBackColor = true;
            // 
            // rad_master
            // 
            rad_master.AutoSize = true;
            rad_master.Location = new Point(25, 21);
            rad_master.Name = "rad_master";
            rad_master.Size = new Size(61, 19);
            rad_master.TabIndex = 0;
            rad_master.TabStop = true;
            rad_master.Text = "Master";
            rad_master.UseVisualStyleBackColor = true;
            // 
            // btn_import_excel
            // 
            btn_import_excel.Image = (Image)resources.GetObject("btn_import_excel.Image");
            btn_import_excel.Location = new Point(154, 116);
            btn_import_excel.Name = "btn_import_excel";
            btn_import_excel.Size = new Size(142, 69);
            btn_import_excel.TabIndex = 5;
            btn_import_excel.Text = "Cargar Data";
            btn_import_excel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_import_excel.UseVisualStyleBackColor = true;
            btn_import_excel.Click += btn_import_excel_Click;
            // 
            // btn_load_sheet
            // 
            btn_load_sheet.Image = (Image)resources.GetObject("btn_load_sheet.Image");
            btn_load_sheet.Location = new Point(11, 116);
            btn_load_sheet.Name = "btn_load_sheet";
            btn_load_sheet.Size = new Size(142, 69);
            btn_load_sheet.TabIndex = 4;
            btn_load_sheet.Text = "Buscar Hoja";
            btn_load_sheet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_load_sheet.UseVisualStyleBackColor = true;
            btn_load_sheet.Click += btn_load_sheet_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 67);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 3;
            label3.Text = "Ruta de Localizacion";
            // 
            // txt_file_path
            // 
            txt_file_path.Location = new Point(6, 87);
            txt_file_path.Name = "txt_file_path";
            txt_file_path.ReadOnly = true;
            txt_file_path.Size = new Size(496, 23);
            txt_file_path.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 21);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Archivo";
            // 
            // txt_file_name
            // 
            txt_file_name.Location = new Point(6, 41);
            txt_file_name.Name = "txt_file_name";
            txt_file_name.ReadOnly = true;
            txt_file_name.Size = new Size(496, 23);
            txt_file_name.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 });
            toolStrip1.Location = new Point(0, 100);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(1010, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(23, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(23, 22);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(23, 22);
            toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(23, 22);
            toolStripButton5.Text = "toolStripButton5";
            // 
            // Frm_Inventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 728);
            Controls.Add(toolStrip1);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_Inventarios";
            Text = "Control de Inventarios:";
            Load += Frm_Inventarios_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Button btn_load_sheet;
        private Label label3;
        private TextBox txt_file_path;
        private Label label2;
        private TextBox txt_file_name;
        private PictureBox pictureBox1;
        private Button btn_import_excel;
        private TabPage tabPage5;
        private GroupBox groupBox2;
        private RadioButton rad_rollos;
        private RadioButton rad_hojas;
        private RadioButton rad_graphics;
        private RadioButton rad_master;
        private Label label5;
        private Label label4;
        private TabPage tabPage6;
        private ToolStrip toolStrip1;
        private Label label6;
        private Label label7;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private GroupBox groupBox3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private DataGridView dataGridView1;
        private Button button1;
        private Label label8;
        private TextBox textBox1;
        private CheckBox chk_checkFileCorrect;
        private ListBox ListColumns;
        private Label label9;
        private Label label11;
        private GroupBox groupBox4;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private DataGridView dataGridView2;
        private Button button2;
        private Label label10;
        private TextBox textBox2;
    }
}