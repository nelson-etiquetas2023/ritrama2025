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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            RollosCortados = new TabControl();
            tabPage1 = new TabPage();
            btn_limpiar_filtros = new Button();
            COUNT_ROWS = new Label();
            btn_DetailsConsumos = new Button();
            groupBox3 = new GroupBox();
            rad_rollid = new RadioButton();
            rad_ubication = new RadioButton();
            rad_productid = new RadioButton();
            rad_product_name = new RadioButton();
            GridMaster = new DataGridView();
            btn_buscar = new Button();
            label8 = new Label();
            txt_buscar = new TextBox();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            Rollos = new TabPage();
            COUNTER_ROLLOS = new Label();
            groupBox4 = new GroupBox();
            rad_ordencorte_cor = new RadioButton();
            rad_codeperson_cor = new RadioButton();
            rad_codeunique_cor = new RadioButton();
            rad_rollid_cor = new RadioButton();
            rad_ubic_cor = new RadioButton();
            rad_productid_cor = new RadioButton();
            rad_productname_cor = new RadioButton();
            GridRollosCortados = new DataGridView();
            bto_limpiar_cor = new Button();
            bot_buscar_cor = new Button();
            label10 = new Label();
            txt_buscar_cor = new TextBox();
            tabPage5 = new TabPage();
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
            tabPage6 = new TabPage();
            panel_loading = new Panel();
            text_loadingindicator = new Label();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            Btn_reload = new ToolStripButton();
            Bot_Reports = new ToolStripButton();
            Bot_Excel = new ToolStripButton();
            Bot_Txt = new ToolStripButton();
            RollosCortados.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridMaster).BeginInit();
            Rollos.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridRollosCortados).BeginInit();
            tabPage5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel_loading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RollosCortados
            // 
            RollosCortados.Controls.Add(tabPage1);
            RollosCortados.Controls.Add(tabPage2);
            RollosCortados.Controls.Add(tabPage3);
            RollosCortados.Controls.Add(Rollos);
            RollosCortados.Controls.Add(tabPage5);
            RollosCortados.Controls.Add(tabPage6);
            RollosCortados.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RollosCortados.Location = new Point(12, 129);
            RollosCortados.Name = "RollosCortados";
            RollosCortados.SelectedIndex = 0;
            RollosCortados.Size = new Size(1247, 693);
            RollosCortados.TabIndex = 0;
            RollosCortados.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn_limpiar_filtros);
            tabPage1.Controls.Add(COUNT_ROWS);
            tabPage1.Controls.Add(btn_DetailsConsumos);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(GridMaster);
            tabPage1.Controls.Add(btn_buscar);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(txt_buscar);
            tabPage1.Location = new Point(4, 23);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1239, 666);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Master";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += TabPage1_Click;
            // 
            // btn_limpiar_filtros
            // 
            btn_limpiar_filtros.Image = (Image)resources.GetObject("btn_limpiar_filtros.Image");
            btn_limpiar_filtros.Location = new Point(722, 21);
            btn_limpiar_filtros.Name = "btn_limpiar_filtros";
            btn_limpiar_filtros.Size = new Size(95, 40);
            btn_limpiar_filtros.TabIndex = 13;
            btn_limpiar_filtros.Text = "Limpiar";
            btn_limpiar_filtros.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_limpiar_filtros.UseVisualStyleBackColor = true;
            btn_limpiar_filtros.Click += Btn_limpiar_filtros_Click;
            // 
            // COUNT_ROWS
            // 
            COUNT_ROWS.AutoSize = true;
            COUNT_ROWS.Font = new Font("Roboto Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            COUNT_ROWS.Location = new Point(1016, 496);
            COUNT_ROWS.Name = "COUNT_ROWS";
            COUNT_ROWS.Size = new Size(184, 19);
            COUNT_ROWS.TabIndex = 12;
            COUNT_ROWS.Text = "0 Registros Encontrados";
            // 
            // btn_DetailsConsumos
            // 
            btn_DetailsConsumos.Image = (Image)resources.GetObject("btn_DetailsConsumos.Image");
            btn_DetailsConsumos.Location = new Point(1067, 8);
            btn_DetailsConsumos.Name = "btn_DetailsConsumos";
            btn_DetailsConsumos.Size = new Size(166, 56);
            btn_DetailsConsumos.TabIndex = 11;
            btn_DetailsConsumos.Text = "Detalle Cosumos";
            btn_DetailsConsumos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_DetailsConsumos.UseVisualStyleBackColor = true;
            btn_DetailsConsumos.Click += Btn_DetailsConsumos_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rad_rollid);
            groupBox3.Controls.Add(rad_ubication);
            groupBox3.Controls.Add(rad_productid);
            groupBox3.Controls.Add(rad_product_name);
            groupBox3.Location = new Point(7, 486);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(245, 169);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Filtrar Por: ";
            // 
            // rad_rollid
            // 
            rad_rollid.AutoSize = true;
            rad_rollid.Checked = true;
            rad_rollid.Location = new Point(6, 28);
            rad_rollid.Name = "rad_rollid";
            rad_rollid.Size = new Size(58, 18);
            rad_rollid.TabIndex = 7;
            rad_rollid.TabStop = true;
            rad_rollid.Text = "Roll-Id";
            rad_rollid.UseVisualStyleBackColor = true;
            // 
            // rad_ubication
            // 
            rad_ubication.AutoSize = true;
            rad_ubication.Location = new Point(6, 84);
            rad_ubication.Name = "rad_ubication";
            rad_ubication.Size = new Size(101, 18);
            rad_ubication.TabIndex = 7;
            rad_ubication.Text = "Por Ubicación";
            rad_ubication.UseVisualStyleBackColor = true;
            // 
            // rad_productid
            // 
            rad_productid.AutoSize = true;
            rad_productid.Location = new Point(6, 47);
            rad_productid.Name = "rad_productid";
            rad_productid.Size = new Size(81, 18);
            rad_productid.TabIndex = 5;
            rad_productid.Text = "Product Id";
            rad_productid.UseVisualStyleBackColor = true;
            // 
            // rad_product_name
            // 
            rad_product_name.AutoSize = true;
            rad_product_name.Location = new Point(6, 65);
            rad_product_name.Name = "rad_product_name";
            rad_product_name.Size = new Size(141, 18);
            rad_product_name.TabIndex = 6;
            rad_product_name.Text = "Nombre del Producto";
            rad_product_name.UseVisualStyleBackColor = true;
            // 
            // GridMaster
            // 
            GridMaster.AllowUserToAddRows = false;
            GridMaster.AllowUserToDeleteRows = false;
            GridMaster.AllowUserToResizeRows = false;
            GridMaster.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridMaster.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            GridMaster.DefaultCellStyle = dataGridViewCellStyle1;
            GridMaster.Location = new Point(7, 70);
            GridMaster.MultiSelect = false;
            GridMaster.Name = "GridMaster";
            GridMaster.ReadOnly = true;
            GridMaster.RowHeadersWidth = 33;
            GridMaster.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridMaster.Size = new Size(1226, 410);
            GridMaster.TabIndex = 3;
            GridMaster.CellFormatting += GridMaster_CellFormatting;
            // 
            // btn_buscar
            // 
            btn_buscar.Image = (Image)resources.GetObject("btn_buscar.Image");
            btn_buscar.Location = new Point(621, 21);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(95, 40);
            btn_buscar.TabIndex = 2;
            btn_buscar.Text = "Buscar";
            btn_buscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_buscar.UseVisualStyleBackColor = true;
            btn_buscar.Click += Btn_buscar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 21);
            label8.Name = "label8";
            label8.Size = new Size(68, 14);
            label8.TabIndex = 1;
            label8.Text = "Buscar por:";
            // 
            // txt_buscar
            // 
            txt_buscar.Location = new Point(7, 37);
            txt_buscar.Name = "txt_buscar";
            txt_buscar.Size = new Size(608, 22);
            txt_buscar.TabIndex = 0;
            txt_buscar.TextChanged += txt_buscar_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 23);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1239, 666);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Graphics";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 23);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1239, 666);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Hojas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Rollos
            // 
            Rollos.Controls.Add(COUNTER_ROLLOS);
            Rollos.Controls.Add(groupBox4);
            Rollos.Controls.Add(GridRollosCortados);
            Rollos.Controls.Add(bto_limpiar_cor);
            Rollos.Controls.Add(bot_buscar_cor);
            Rollos.Controls.Add(label10);
            Rollos.Controls.Add(txt_buscar_cor);
            Rollos.Location = new Point(4, 23);
            Rollos.Name = "Rollos";
            Rollos.Padding = new Padding(3);
            Rollos.Size = new Size(1239, 666);
            Rollos.TabIndex = 3;
            Rollos.Text = "Rollos Cortados";
            Rollos.UseVisualStyleBackColor = true;
            Rollos.Click += Rollos_Click;
            // 
            // COUNTER_ROLLOS
            // 
            COUNTER_ROLLOS.AutoSize = true;
            COUNTER_ROLLOS.Font = new Font("Roboto Medium", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            COUNTER_ROLLOS.Location = new Point(973, 481);
            COUNTER_ROLLOS.Name = "COUNTER_ROLLOS";
            COUNTER_ROLLOS.Size = new Size(184, 19);
            COUNTER_ROLLOS.TabIndex = 22;
            COUNTER_ROLLOS.Text = "0 Registros Encontrados";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rad_ordencorte_cor);
            groupBox4.Controls.Add(rad_codeperson_cor);
            groupBox4.Controls.Add(rad_codeunique_cor);
            groupBox4.Controls.Add(rad_rollid_cor);
            groupBox4.Controls.Add(rad_ubic_cor);
            groupBox4.Controls.Add(rad_productid_cor);
            groupBox4.Controls.Add(rad_productname_cor);
            groupBox4.Location = new Point(6, 466);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(245, 174);
            groupBox4.TabIndex = 21;
            groupBox4.TabStop = false;
            groupBox4.Text = "Filtrar Por: ";
            // 
            // rad_ordencorte_cor
            // 
            rad_ordencorte_cor.AutoSize = true;
            rad_ordencorte_cor.Location = new Point(6, 138);
            rad_ordencorte_cor.Name = "rad_ordencorte_cor";
            rad_ordencorte_cor.Size = new Size(89, 18);
            rad_ordencorte_cor.TabIndex = 10;
            rad_ordencorte_cor.Text = "Orden Corte";
            rad_ordencorte_cor.UseVisualStyleBackColor = true;
            // 
            // rad_codeperson_cor
            // 
            rad_codeperson_cor.AutoSize = true;
            rad_codeperson_cor.Location = new Point(6, 121);
            rad_codeperson_cor.Name = "rad_codeperson_cor";
            rad_codeperson_cor.Size = new Size(167, 18);
            rad_codeperson_cor.TabIndex = 9;
            rad_codeperson_cor.Text = "Por Codigo Personalizado";
            rad_codeperson_cor.UseVisualStyleBackColor = true;
            // 
            // rad_codeunique_cor
            // 
            rad_codeunique_cor.AutoSize = true;
            rad_codeunique_cor.Location = new Point(6, 103);
            rad_codeunique_cor.Name = "rad_codeunique_cor";
            rad_codeunique_cor.Size = new Size(120, 18);
            rad_codeunique_cor.TabIndex = 8;
            rad_codeunique_cor.Text = "Por Codigo Unico";
            rad_codeunique_cor.UseVisualStyleBackColor = true;
            // 
            // rad_rollid_cor
            // 
            rad_rollid_cor.AutoSize = true;
            rad_rollid_cor.Checked = true;
            rad_rollid_cor.Location = new Point(6, 28);
            rad_rollid_cor.Name = "rad_rollid_cor";
            rad_rollid_cor.Size = new Size(58, 18);
            rad_rollid_cor.TabIndex = 7;
            rad_rollid_cor.TabStop = true;
            rad_rollid_cor.Text = "Roll-Id";
            rad_rollid_cor.UseVisualStyleBackColor = true;
            // 
            // rad_ubic_cor
            // 
            rad_ubic_cor.AutoSize = true;
            rad_ubic_cor.Location = new Point(6, 84);
            rad_ubic_cor.Name = "rad_ubic_cor";
            rad_ubic_cor.Size = new Size(101, 18);
            rad_ubic_cor.TabIndex = 7;
            rad_ubic_cor.Text = "Por Ubicación";
            rad_ubic_cor.UseVisualStyleBackColor = true;
            // 
            // rad_productid_cor
            // 
            rad_productid_cor.AutoSize = true;
            rad_productid_cor.Location = new Point(6, 47);
            rad_productid_cor.Name = "rad_productid_cor";
            rad_productid_cor.Size = new Size(81, 18);
            rad_productid_cor.TabIndex = 5;
            rad_productid_cor.Text = "Product Id";
            rad_productid_cor.UseVisualStyleBackColor = true;
            // 
            // rad_productname_cor
            // 
            rad_productname_cor.AutoSize = true;
            rad_productname_cor.Location = new Point(6, 65);
            rad_productname_cor.Name = "rad_productname_cor";
            rad_productname_cor.Size = new Size(141, 18);
            rad_productname_cor.TabIndex = 6;
            rad_productname_cor.Text = "Nombre del Producto";
            rad_productname_cor.UseVisualStyleBackColor = true;
            // 
            // GridRollosCortados
            // 
            GridRollosCortados.AllowUserToAddRows = false;
            GridRollosCortados.AllowUserToDeleteRows = false;
            GridRollosCortados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridRollosCortados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridRollosCortados.Location = new Point(6, 67);
            GridRollosCortados.MultiSelect = false;
            GridRollosCortados.Name = "GridRollosCortados";
            GridRollosCortados.ReadOnly = true;
            GridRollosCortados.RowHeadersWidth = 34;
            GridRollosCortados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridRollosCortados.Size = new Size(1227, 393);
            GridRollosCortados.TabIndex = 18;
            // 
            // bto_limpiar_cor
            // 
            bto_limpiar_cor.Image = (Image)resources.GetObject("bto_limpiar_cor.Image");
            bto_limpiar_cor.Location = new Point(1062, 21);
            bto_limpiar_cor.Name = "bto_limpiar_cor";
            bto_limpiar_cor.Size = new Size(95, 40);
            bto_limpiar_cor.TabIndex = 17;
            bto_limpiar_cor.Text = "Limpiar";
            bto_limpiar_cor.TextImageRelation = TextImageRelation.ImageBeforeText;
            bto_limpiar_cor.UseVisualStyleBackColor = true;
            bto_limpiar_cor.Click += bto_limpiar_cor_Click;
            // 
            // bot_buscar_cor
            // 
            bot_buscar_cor.Image = (Image)resources.GetObject("bot_buscar_cor.Image");
            bot_buscar_cor.Location = new Point(961, 21);
            bot_buscar_cor.Name = "bot_buscar_cor";
            bot_buscar_cor.Size = new Size(95, 40);
            bot_buscar_cor.TabIndex = 16;
            bot_buscar_cor.Text = "Buscar";
            bot_buscar_cor.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_buscar_cor.UseVisualStyleBackColor = true;
            bot_buscar_cor.Click += bot_buscar_cor_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 23);
            label10.Name = "label10";
            label10.Size = new Size(68, 14);
            label10.TabIndex = 15;
            label10.Text = "Buscar por:";
            // 
            // txt_buscar_cor
            // 
            txt_buscar_cor.Location = new Point(6, 39);
            txt_buscar_cor.Name = "txt_buscar_cor";
            txt_buscar_cor.Size = new Size(949, 22);
            txt_buscar_cor.TabIndex = 14;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(groupBox1);
            tabPage5.Location = new Point(4, 23);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1239, 666);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Export Excel";
            tabPage5.UseVisualStyleBackColor = true;
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
            groupBox1.Location = new Point(12, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(960, 269);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Importar Data de Excel";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(675, 108);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 13;
            label9.Text = "Propiedades de la columnas: ";
            // 
            // ListColumns
            // 
            ListColumns.FormattingEnabled = true;
            ListColumns.Items.AddRange(new object[] { "1.- Product Id., Columna1" });
            ListColumns.Location = new Point(529, 124);
            ListColumns.Name = "ListColumns";
            ListColumns.Size = new Size(368, 74);
            ListColumns.TabIndex = 12;
            // 
            // chk_checkFileCorrect
            // 
            chk_checkFileCorrect.AutoSize = true;
            chk_checkFileCorrect.Enabled = false;
            chk_checkFileCorrect.Location = new Point(11, 181);
            chk_checkFileCorrect.Name = "chk_checkFileCorrect";
            chk_checkFileCorrect.Size = new Size(203, 18);
            chk_checkFileCorrect.TabIndex = 11;
            chk_checkFileCorrect.Text = "Localizacion Correcta de Archivo";
            chk_checkFileCorrect.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(675, 18);
            label7.Name = "label7";
            label7.Size = new Size(182, 21);
            label7.TabIndex = 10;
            label7.Text = "Resumen de Procesos :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(529, 84);
            label6.Name = "label6";
            label6.Size = new Size(86, 14);
            label6.TabIndex = 9;
            label6.Text = "Advertencias : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(529, 63);
            label5.Name = "label5";
            label5.Size = new Size(153, 14);
            label5.TabIndex = 8;
            label5.Text = "Productos no registrados : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(529, 41);
            label4.Name = "label4";
            label4.Size = new Size(129, 14);
            label4.TabIndex = 7;
            label4.Text = "Numero de Registros : ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rad_rollos);
            groupBox2.Controls.Add(rad_hojas);
            groupBox2.Controls.Add(rad_graphics);
            groupBox2.Controls.Add(rad_master);
            groupBox2.Location = new Point(302, 108);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 104);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tipo Producto";
            // 
            // rad_rollos
            // 
            rad_rollos.AutoSize = true;
            rad_rollos.Location = new Point(25, 72);
            rad_rollos.Name = "rad_rollos";
            rad_rollos.Size = new Size(99, 18);
            rad_rollos.TabIndex = 3;
            rad_rollos.TabStop = true;
            rad_rollos.Text = "Rollo Cortado";
            rad_rollos.UseVisualStyleBackColor = true;
            // 
            // rad_hojas
            // 
            rad_hojas.AutoSize = true;
            rad_hojas.Location = new Point(25, 55);
            rad_hojas.Name = "rad_hojas";
            rad_hojas.Size = new Size(57, 18);
            rad_hojas.TabIndex = 2;
            rad_hojas.TabStop = true;
            rad_hojas.Text = "Hojas";
            rad_hojas.UseVisualStyleBackColor = true;
            // 
            // rad_graphics
            // 
            rad_graphics.AutoSize = true;
            rad_graphics.Location = new Point(25, 37);
            rad_graphics.Name = "rad_graphics";
            rad_graphics.Size = new Size(73, 18);
            rad_graphics.TabIndex = 1;
            rad_graphics.TabStop = true;
            rad_graphics.Text = "Graphics";
            rad_graphics.UseVisualStyleBackColor = true;
            // 
            // rad_master
            // 
            rad_master.AutoSize = true;
            rad_master.Location = new Point(25, 20);
            rad_master.Name = "rad_master";
            rad_master.Size = new Size(62, 18);
            rad_master.TabIndex = 0;
            rad_master.TabStop = true;
            rad_master.Text = "Master";
            rad_master.UseVisualStyleBackColor = true;
            // 
            // btn_import_excel
            // 
            btn_import_excel.Image = (Image)resources.GetObject("btn_import_excel.Image");
            btn_import_excel.Location = new Point(154, 108);
            btn_import_excel.Name = "btn_import_excel";
            btn_import_excel.Size = new Size(142, 64);
            btn_import_excel.TabIndex = 5;
            btn_import_excel.Text = "Cargar Data";
            btn_import_excel.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_import_excel.UseVisualStyleBackColor = true;
            btn_import_excel.Click += Btn_import_excel_Click;
            // 
            // btn_load_sheet
            // 
            btn_load_sheet.Image = (Image)resources.GetObject("btn_load_sheet.Image");
            btn_load_sheet.Location = new Point(11, 108);
            btn_load_sheet.Name = "btn_load_sheet";
            btn_load_sheet.Size = new Size(142, 64);
            btn_load_sheet.TabIndex = 4;
            btn_load_sheet.Text = "Buscar Hoja";
            btn_load_sheet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_load_sheet.UseVisualStyleBackColor = true;
            btn_load_sheet.Click += Btn_load_sheet_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 63);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 3;
            label3.Text = "Ruta de Localizacion";
            // 
            // txt_file_path
            // 
            txt_file_path.Location = new Point(6, 81);
            txt_file_path.Name = "txt_file_path";
            txt_file_path.ReadOnly = true;
            txt_file_path.Size = new Size(496, 22);
            txt_file_path.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(11, 20);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Archivo";
            // 
            // txt_file_name
            // 
            txt_file_name.Location = new Point(6, 38);
            txt_file_name.Name = "txt_file_name";
            txt_file_name.ReadOnly = true;
            txt_file_name.Size = new Size(496, 22);
            txt_file_name.TabIndex = 0;
            // 
            // tabPage6
            // 
            tabPage6.Location = new Point(4, 23);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(1239, 666);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Notificaciones";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel_loading
            // 
            panel_loading.BackColor = SystemColors.Window;
            panel_loading.Controls.Add(text_loadingindicator);
            panel_loading.Controls.Add(pictureBox2);
            panel_loading.Location = new Point(532, 363);
            panel_loading.Name = "panel_loading";
            panel_loading.Size = new Size(200, 87);
            panel_loading.TabIndex = 23;
            panel_loading.Visible = false;
            // 
            // text_loadingindicator
            // 
            text_loadingindicator.AutoSize = true;
            text_loadingindicator.Font = new Font("Russo One", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            text_loadingindicator.Location = new Point(90, 37);
            text_loadingindicator.Name = "text_loadingindicator";
            text_loadingindicator.Size = new Size(96, 19);
            text_loadingindicator.TabIndex = 1;
            text_loadingindicator.Text = "Loading...";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Control;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(13, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(64, 64);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 93);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(381, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 47);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(437, 24);
            label1.Name = "label1";
            label1.Size = new Size(411, 50);
            label1.TabIndex = 0;
            label1.Text = "Control de Inventarios";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.Items.AddRange(new ToolStripItem[] { Btn_reload, Bot_Reports, Bot_Excel, Bot_Txt });
            toolStrip1.Location = new Point(0, 93);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Size = new Size(1271, 33);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // Btn_reload
            // 
            Btn_reload.AutoSize = false;
            Btn_reload.Image = (Image)resources.GetObject("Btn_reload.Image");
            Btn_reload.ImageTransparentColor = Color.Magenta;
            Btn_reload.Name = "Btn_reload";
            Btn_reload.Size = new Size(73, 30);
            Btn_reload.Text = "Cargar";
            Btn_reload.Click += Btn_reload_Click;
            // 
            // Bot_Reports
            // 
            Bot_Reports.AutoSize = false;
            Bot_Reports.Image = (Image)resources.GetObject("Bot_Reports.Image");
            Bot_Reports.ImageTransparentColor = Color.Magenta;
            Bot_Reports.Name = "Bot_Reports";
            Bot_Reports.Size = new Size(73, 30);
            Bot_Reports.Text = "Reportes";
            Bot_Reports.Click += ToolStripButton1_Click;
            // 
            // Bot_Excel
            // 
            Bot_Excel.AutoSize = false;
            Bot_Excel.Image = (Image)resources.GetObject("Bot_Excel.Image");
            Bot_Excel.ImageTransparentColor = Color.Magenta;
            Bot_Excel.Name = "Bot_Excel";
            Bot_Excel.Size = new Size(73, 30);
            Bot_Excel.Text = "Excel";
            Bot_Excel.Click += Bot_Excel_Click;
            // 
            // Bot_Txt
            // 
            Bot_Txt.AutoSize = false;
            Bot_Txt.Image = (Image)resources.GetObject("Bot_Txt.Image");
            Bot_Txt.ImageTransparentColor = Color.Magenta;
            Bot_Txt.Name = "Bot_Txt";
            Bot_Txt.Size = new Size(73, 30);
            Bot_Txt.Text = "Texto";
            Bot_Txt.Click += Bot_Txt_Click;
            // 
            // Frm_Inventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 834);
            Controls.Add(panel_loading);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Controls.Add(RollosCortados);
            Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_Inventarios";
            Text = "Control de Inventarios:";
            Load += Frm_Inventarios_Load;
            RollosCortados.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridMaster).EndInit();
            Rollos.ResumeLayout(false);
            Rollos.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridRollosCortados).EndInit();
            tabPage5.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel_loading.ResumeLayout(false);
            panel_loading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl RollosCortados;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage Rollos;
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
        private ToolStripButton Btn_reload;
        private GroupBox groupBox3;
        private RadioButton rad_product_name;
        private RadioButton rad_productid;
        private DataGridView GridMaster;
        private Button btn_buscar;
        private Label label8;
        private TextBox txt_buscar;
        private CheckBox chk_checkFileCorrect;
        private ListBox ListColumns;
        private Label label9;
        private RadioButton rad_rollid;
        private Button btn_DetailsConsumos;
        private RadioButton rad_ubication;
        private Label COUNT_ROWS;
        private ToolStripButton Bot_Reports;
        private ToolStripButton Bot_Txt;
        private Button btn_limpiar_filtros;
        private ToolStripButton Bot_Excel;
        private Button bto_limpiar_cor;
        private Label label10;
        private TextBox txt_buscar_cor;
        private GroupBox groupBox4;
        private RadioButton rad_rollid_cor;
        private RadioButton rad_ubic_cor;
        private RadioButton rad_productid_cor;
        private RadioButton rad_productname_cor;
        private DataGridView GridRollosCortados;
        private Label COUNTER_ROLLOS;
        private RadioButton rad_codeperson_cor;
        private RadioButton rad_codeunique_cor;
        private Button bot_buscar_cor;
        private RadioButton rad_ordencorte_cor;
        private Panel panel_loading;
        private PictureBox pictureBox2;
        private Label text_loadingindicator;
    }
}