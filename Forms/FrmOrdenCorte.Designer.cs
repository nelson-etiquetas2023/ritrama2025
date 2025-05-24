namespace Ritrama2025.Forms
{
    partial class FrmOrdenCorte
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrdenCorte));
            panel1 = new Panel();
            registros = new Label();
            label1 = new Label();
            toolStrip1 = new ToolStrip();
            bot_primero = new ToolStripButton();
            bot_anterior = new ToolStripButton();
            bot_siguiente = new ToolStripButton();
            bot_ultimo = new ToolStripButton();
            bot_accion = new ToolStripDropDownButton();
            opt_create_document = new ToolStripMenuItem();
            opt_send_production = new ToolStripMenuItem();
            opt_etiquetar_orden = new ToolStripMenuItem();
            opt_aprobar_orden = new ToolStripMenuItem();
            opt_cerrar_orden = new ToolStripMenuItem();
            opt_modif_orden = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            bot_guardar = new ToolStripButton();
            bot_cancelar = new ToolStripButton();
            bot_imprimir = new ToolStripButton();
            bot_exportar = new ToolStripButton();
            bot_etiquetar = new ToolStripButton();
            label2 = new Label();
            txt_numeroOC = new TextBox();
            txt_fecha_emision = new DateTimePicker();
            label3 = new Label();
            txt_fecha_produccion = new DateTimePicker();
            label4 = new Label();
            txt_rollid_1 = new TextBox();
            label5 = new Label();
            btn_buscar_rollid1 = new Button();
            txt_width1 = new TextBox();
            label6 = new Label();
            txt_length1 = new TextBox();
            label7 = new Label();
            txt_plus1 = new TextBox();
            label8 = new Label();
            txt_menos1 = new TextBox();
            label9 = new Label();
            textBox7 = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txt_real1_width = new TextBox();
            txt_real1_length = new TextBox();
            txt_matrest1_lenght = new TextBox();
            txt_matrest1_width = new TextBox();
            label12 = new Label();
            txt_rollid_2 = new TextBox();
            txt_length2 = new TextBox();
            txt_width2 = new TextBox();
            btn_buscar_rollid2 = new Button();
            label13 = new Label();
            textBox15 = new TextBox();
            label14 = new Label();
            txt_menos2 = new TextBox();
            label15 = new Label();
            txt_plus2 = new TextBox();
            label16 = new Label();
            label17 = new Label();
            txt_matrest2_lenght = new TextBox();
            txt_matrest2_width = new TextBox();
            txt_real2_length = new TextBox();
            txt_real2_width = new TextBox();
            label18 = new Label();
            label19 = new Label();
            txt_product_id = new TextBox();
            txt_product_name = new TextBox();
            label20 = new Label();
            label21 = new Label();
            txt_operador_id = new TextBox();
            label22 = new Label();
            txt_operador_name = new TextBox();
            label23 = new Label();
            txt_cust_name = new TextBox();
            label24 = new Label();
            txt_cust_id = new TextBox();
            label25 = new Label();
            txt_ancho_corte = new TextBox();
            label26 = new Label();
            txt_largo_corte = new TextBox();
            label27 = new Label();
            txt_resta_corte = new TextBox();
            label28 = new Label();
            btn_buscar_customer = new Button();
            btn_buscar_operador = new Button();
            grid_cortes = new DataGridView();
            btn_generar_rollos = new Button();
            btn_add_row_corte = new Button();
            txt_delete_row_corte = new Button();
            txt_long_cortar = new TextBox();
            label29 = new Label();
            txt_vueltas1 = new TextBox();
            label30 = new Label();
            txt_vueltas2 = new TextBox();
            txt_cortes_ancho = new TextBox();
            label31 = new Label();
            txt_rollos_cortar2 = new TextBox();
            txt_rollos_cortar1 = new TextBox();
            label32 = new Label();
            label33 = new Label();
            tabPage1 = new TabPage();
            grid_items = new DataGridView();
            tabControl1 = new TabControl();
            chk_document_anul = new CheckBox();
            chk_orden_rebobinado = new CheckBox();
            label34 = new Label();
            label_status = new Label();
            btn_vueltas = new Button();
            txt_code_person = new TextBox();
            label36 = new Label();
            btn_code_person = new Button();
            chk_unificar_rollos = new CheckBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            button1 = new Button();
            imageList1 = new ImageList(components);
            pictureBox6 = new PictureBox();
            panel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid_cortes).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid_items).BeginInit();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(registros);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 52);
            panel1.TabIndex = 0;
            // 
            // registros
            // 
            registros.AutoSize = true;
            registros.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            registros.Location = new Point(920, 15);
            registros.Name = "registros";
            registros.Size = new Size(161, 25);
            registros.TabIndex = 96;
            registros.Text = "Registros : 1/100";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(393, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 32);
            label1.TabIndex = 0;
            label1.Text = "ORDENES DE CORTES";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { bot_primero, bot_anterior, bot_siguiente, bot_ultimo, bot_accion, toolStripButton1, bot_guardar, bot_cancelar, bot_imprimir, bot_exportar, bot_etiquetar });
            toolStrip1.Location = new Point(0, 52);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1105, 33);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // bot_primero
            // 
            bot_primero.AutoSize = false;
            bot_primero.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_primero.Image = Properties.Resources.double_left_48px;
            bot_primero.ImageTransparentColor = Color.Magenta;
            bot_primero.Name = "bot_primero";
            bot_primero.Size = new Size(80, 30);
            bot_primero.Text = "Primero";
            bot_primero.Click += Bot_primero_Click;
            // 
            // bot_anterior
            // 
            bot_anterior.AutoSize = false;
            bot_anterior.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_anterior.Image = (Image)resources.GetObject("bot_anterior.Image");
            bot_anterior.ImageTransparentColor = Color.Magenta;
            bot_anterior.Name = "bot_anterior";
            bot_anterior.Size = new Size(80, 30);
            bot_anterior.Text = "Anterior";
            bot_anterior.Click += Bot_anterior_Click;
            // 
            // bot_siguiente
            // 
            bot_siguiente.AutoSize = false;
            bot_siguiente.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_siguiente.Image = (Image)resources.GetObject("bot_siguiente.Image");
            bot_siguiente.ImageTransparentColor = Color.Magenta;
            bot_siguiente.Name = "bot_siguiente";
            bot_siguiente.Size = new Size(80, 30);
            bot_siguiente.Text = "Siguiente";
            bot_siguiente.TextImageRelation = TextImageRelation.TextBeforeImage;
            bot_siguiente.Click += Bot_siguiente_Click;
            // 
            // bot_ultimo
            // 
            bot_ultimo.AutoSize = false;
            bot_ultimo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_ultimo.Image = (Image)resources.GetObject("bot_ultimo.Image");
            bot_ultimo.ImageTransparentColor = Color.Magenta;
            bot_ultimo.Name = "bot_ultimo";
            bot_ultimo.Size = new Size(80, 30);
            bot_ultimo.Text = "Ultimo";
            bot_ultimo.TextImageRelation = TextImageRelation.TextBeforeImage;
            bot_ultimo.Click += Bot_ultimo_Click;
            // 
            // bot_accion
            // 
            bot_accion.DropDownItems.AddRange(new ToolStripItem[] { opt_create_document, opt_send_production, opt_etiquetar_orden, opt_aprobar_orden, opt_cerrar_orden, opt_modif_orden });
            bot_accion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_accion.Image = (Image)resources.GetObject("bot_accion.Image");
            bot_accion.ImageTransparentColor = Color.Magenta;
            bot_accion.Name = "bot_accion";
            bot_accion.Size = new Size(85, 30);
            bot_accion.Text = "Acciones";
            // 
            // opt_create_document
            // 
            opt_create_document.Image = Properties.Resources.create_24px;
            opt_create_document.Name = "opt_create_document";
            opt_create_document.Size = new Size(182, 22);
            opt_create_document.Text = "Crear Orden";
            opt_create_document.Click += Opt_create_document_Click;
            // 
            // opt_send_production
            // 
            opt_send_production.Image = Properties.Resources.automation_24px;
            opt_send_production.Name = "opt_send_production";
            opt_send_production.Size = new Size(182, 22);
            opt_send_production.Text = "Enviar a Produccion";
            // 
            // opt_etiquetar_orden
            // 
            opt_etiquetar_orden.Image = Properties.Resources.price_tag_24px;
            opt_etiquetar_orden.Name = "opt_etiquetar_orden";
            opt_etiquetar_orden.Size = new Size(182, 22);
            opt_etiquetar_orden.Text = "Etiquetar Orden";
            // 
            // opt_aprobar_orden
            // 
            opt_aprobar_orden.Image = (Image)resources.GetObject("opt_aprobar_orden.Image");
            opt_aprobar_orden.Name = "opt_aprobar_orden";
            opt_aprobar_orden.Size = new Size(182, 22);
            opt_aprobar_orden.Text = "Aprobar Orden";
            // 
            // opt_cerrar_orden
            // 
            opt_cerrar_orden.Image = Properties.Resources.security_document_24px;
            opt_cerrar_orden.Name = "opt_cerrar_orden";
            opt_cerrar_orden.Size = new Size(182, 22);
            opt_cerrar_orden.Text = "Cerrar Orden";
            // 
            // opt_modif_orden
            // 
            opt_modif_orden.Image = Properties.Resources.edit_24px;
            opt_modif_orden.Name = "opt_modif_orden";
            opt_modif_orden.Size = new Size(182, 22);
            opt_modif_orden.Text = "Modificar Orden";
            // 
            // toolStripButton1
            // 
            toolStripButton1.AutoSize = false;
            toolStripButton1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(80, 30);
            toolStripButton1.Text = "Guardar";
            // 
            // bot_guardar
            // 
            bot_guardar.AutoSize = false;
            bot_guardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_guardar.Image = (Image)resources.GetObject("bot_guardar.Image");
            bot_guardar.ImageTransparentColor = Color.Magenta;
            bot_guardar.Name = "bot_guardar";
            bot_guardar.Size = new Size(80, 30);
            bot_guardar.Text = "Buscar";
            // 
            // bot_cancelar
            // 
            bot_cancelar.AutoSize = false;
            bot_cancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_cancelar.Image = (Image)resources.GetObject("bot_cancelar.Image");
            bot_cancelar.ImageTransparentColor = Color.Magenta;
            bot_cancelar.Name = "bot_cancelar";
            bot_cancelar.Size = new Size(80, 30);
            bot_cancelar.Text = "Cancelar";
            // 
            // bot_imprimir
            // 
            bot_imprimir.AutoSize = false;
            bot_imprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_imprimir.Image = (Image)resources.GetObject("bot_imprimir.Image");
            bot_imprimir.ImageTransparentColor = Color.Magenta;
            bot_imprimir.Name = "bot_imprimir";
            bot_imprimir.Size = new Size(80, 30);
            bot_imprimir.Text = "Imprimir";
            // 
            // bot_exportar
            // 
            bot_exportar.AutoSize = false;
            bot_exportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_exportar.Image = (Image)resources.GetObject("bot_exportar.Image");
            bot_exportar.ImageTransparentColor = Color.Magenta;
            bot_exportar.Name = "bot_exportar";
            bot_exportar.Size = new Size(80, 30);
            bot_exportar.Text = "Exportar";
            // 
            // bot_etiquetar
            // 
            bot_etiquetar.AutoSize = false;
            bot_etiquetar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bot_etiquetar.Image = (Image)resources.GetObject("bot_etiquetar.Image");
            bot_etiquetar.ImageTransparentColor = Color.Magenta;
            bot_etiquetar.Name = "bot_etiquetar";
            bot_etiquetar.Size = new Size(80, 30);
            bot_etiquetar.Text = "Etiquetar";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Numero OC:";
            // 
            // txt_numeroOC
            // 
            txt_numeroOC.Location = new Point(12, 101);
            txt_numeroOC.Name = "txt_numeroOC";
            txt_numeroOC.ReadOnly = true;
            txt_numeroOC.Size = new Size(100, 23);
            txt_numeroOC.TabIndex = 3;
            // 
            // txt_fecha_emision
            // 
            txt_fecha_emision.Enabled = false;
            txt_fecha_emision.Location = new Point(118, 101);
            txt_fecha_emision.Name = "txt_fecha_emision";
            txt_fecha_emision.Size = new Size(216, 23);
            txt_fecha_emision.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(118, 83);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Fecha OC:";
            // 
            // txt_fecha_produccion
            // 
            txt_fecha_produccion.Enabled = false;
            txt_fecha_produccion.Location = new Point(340, 101);
            txt_fecha_produccion.Name = "txt_fecha_produccion";
            txt_fecha_produccion.Size = new Size(216, 23);
            txt_fecha_produccion.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(340, 83);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 7;
            label4.Text = "Fecha Produccion:";
            // 
            // txt_rollid_1
            // 
            txt_rollid_1.Location = new Point(12, 143);
            txt_rollid_1.Name = "txt_rollid_1";
            txt_rollid_1.ReadOnly = true;
            txt_rollid_1.Size = new Size(100, 23);
            txt_rollid_1.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 125);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 8;
            label5.Text = "ID#1";
            // 
            // btn_buscar_rollid1
            // 
            btn_buscar_rollid1.Enabled = false;
            btn_buscar_rollid1.Location = new Point(118, 143);
            btn_buscar_rollid1.Name = "btn_buscar_rollid1";
            btn_buscar_rollid1.Size = new Size(38, 23);
            btn_buscar_rollid1.TabIndex = 10;
            btn_buscar_rollid1.Text = "...";
            btn_buscar_rollid1.UseVisualStyleBackColor = true;
            btn_buscar_rollid1.Click += btn_buscar_rollid1_Click;
            // 
            // txt_width1
            // 
            txt_width1.Location = new Point(162, 143);
            txt_width1.Name = "txt_width1";
            txt_width1.ReadOnly = true;
            txt_width1.Size = new Size(100, 23);
            txt_width1.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(162, 125);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 11;
            label6.Text = "Width [INCH]:";
            // 
            // txt_length1
            // 
            txt_length1.Location = new Point(268, 143);
            txt_length1.Name = "txt_length1";
            txt_length1.ReadOnly = true;
            txt_length1.Size = new Size(100, 23);
            txt_length1.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(268, 125);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 13;
            label7.Text = "Lenght [PIES]:";
            // 
            // txt_plus1
            // 
            txt_plus1.Location = new Point(374, 144);
            txt_plus1.Name = "txt_plus1";
            txt_plus1.ReadOnly = true;
            txt_plus1.Size = new Size(38, 23);
            txt_plus1.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(374, 126);
            label8.Name = "label8";
            label8.Size = new Size(15, 15);
            label8.TabIndex = 15;
            label8.Text = "+";
            // 
            // txt_menos1
            // 
            txt_menos1.Location = new Point(418, 144);
            txt_menos1.Name = "txt_menos1";
            txt_menos1.ReadOnly = true;
            txt_menos1.Size = new Size(38, 23);
            txt_menos1.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(418, 126);
            label9.Name = "label9";
            label9.Size = new Size(12, 15);
            label9.TabIndex = 17;
            label9.Text = "-";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(462, 144);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(462, 126);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 19;
            label10.Text = "Real [PIES]:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(75, 170);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 21;
            label11.Text = "Real Utilizado:";
            // 
            // txt_real1_width
            // 
            txt_real1_width.Location = new Point(162, 167);
            txt_real1_width.Name = "txt_real1_width";
            txt_real1_width.ReadOnly = true;
            txt_real1_width.Size = new Size(100, 23);
            txt_real1_width.TabIndex = 22;
            // 
            // txt_real1_length
            // 
            txt_real1_length.Location = new Point(267, 167);
            txt_real1_length.Name = "txt_real1_length";
            txt_real1_length.ReadOnly = true;
            txt_real1_length.Size = new Size(100, 23);
            txt_real1_length.TabIndex = 23;
            // 
            // txt_matrest1_lenght
            // 
            txt_matrest1_lenght.Location = new Point(267, 191);
            txt_matrest1_lenght.Name = "txt_matrest1_lenght";
            txt_matrest1_lenght.ReadOnly = true;
            txt_matrest1_lenght.Size = new Size(100, 23);
            txt_matrest1_lenght.TabIndex = 25;
            // 
            // txt_matrest1_width
            // 
            txt_matrest1_width.Location = new Point(162, 191);
            txt_matrest1_width.Name = "txt_matrest1_width";
            txt_matrest1_width.ReadOnly = true;
            txt_matrest1_width.Size = new Size(100, 23);
            txt_matrest1_width.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(55, 194);
            label12.Name = "label12";
            label12.Size = new Size(101, 15);
            label12.TabIndex = 26;
            label12.Text = "Material Restante:";
            // 
            // txt_rollid_2
            // 
            txt_rollid_2.Location = new Point(12, 214);
            txt_rollid_2.Name = "txt_rollid_2";
            txt_rollid_2.ReadOnly = true;
            txt_rollid_2.Size = new Size(100, 23);
            txt_rollid_2.TabIndex = 28;
            // 
            // txt_length2
            // 
            txt_length2.Location = new Point(267, 215);
            txt_length2.Name = "txt_length2";
            txt_length2.ReadOnly = true;
            txt_length2.Size = new Size(100, 23);
            txt_length2.TabIndex = 30;
            // 
            // txt_width2
            // 
            txt_width2.Location = new Point(162, 215);
            txt_width2.Name = "txt_width2";
            txt_width2.ReadOnly = true;
            txt_width2.Size = new Size(100, 23);
            txt_width2.TabIndex = 29;
            // 
            // btn_buscar_rollid2
            // 
            btn_buscar_rollid2.Enabled = false;
            btn_buscar_rollid2.Location = new Point(118, 214);
            btn_buscar_rollid2.Name = "btn_buscar_rollid2";
            btn_buscar_rollid2.Size = new Size(38, 23);
            btn_buscar_rollid2.TabIndex = 31;
            btn_buscar_rollid2.Text = "...";
            btn_buscar_rollid2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 196);
            label13.Name = "label13";
            label13.Size = new Size(31, 15);
            label13.TabIndex = 32;
            label13.Text = "ID#2";
            // 
            // textBox15
            // 
            textBox15.Location = new Point(462, 215);
            textBox15.Name = "textBox15";
            textBox15.ReadOnly = true;
            textBox15.Size = new Size(100, 23);
            textBox15.TabIndex = 38;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(462, 197);
            label14.Name = "label14";
            label14.Size = new Size(65, 15);
            label14.TabIndex = 37;
            label14.Text = "Real [PIES]:";
            // 
            // txt_menos2
            // 
            txt_menos2.Location = new Point(418, 215);
            txt_menos2.Name = "txt_menos2";
            txt_menos2.ReadOnly = true;
            txt_menos2.Size = new Size(38, 23);
            txt_menos2.TabIndex = 36;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(418, 197);
            label15.Name = "label15";
            label15.Size = new Size(12, 15);
            label15.TabIndex = 35;
            label15.Text = "-";
            // 
            // txt_plus2
            // 
            txt_plus2.Location = new Point(374, 215);
            txt_plus2.Name = "txt_plus2";
            txt_plus2.ReadOnly = true;
            txt_plus2.Size = new Size(38, 23);
            txt_plus2.TabIndex = 34;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(374, 197);
            label16.Name = "label16";
            label16.Size = new Size(15, 15);
            label16.TabIndex = 33;
            label16.Text = "+";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(55, 266);
            label17.Name = "label17";
            label17.Size = new Size(101, 15);
            label17.TabIndex = 44;
            label17.Text = "Material Restante:";
            // 
            // txt_matrest2_lenght
            // 
            txt_matrest2_lenght.Location = new Point(267, 263);
            txt_matrest2_lenght.Name = "txt_matrest2_lenght";
            txt_matrest2_lenght.ReadOnly = true;
            txt_matrest2_lenght.Size = new Size(100, 23);
            txt_matrest2_lenght.TabIndex = 43;
            // 
            // txt_matrest2_width
            // 
            txt_matrest2_width.Location = new Point(162, 263);
            txt_matrest2_width.Name = "txt_matrest2_width";
            txt_matrest2_width.ReadOnly = true;
            txt_matrest2_width.Size = new Size(100, 23);
            txt_matrest2_width.TabIndex = 42;
            // 
            // txt_real2_length
            // 
            txt_real2_length.Location = new Point(267, 239);
            txt_real2_length.Name = "txt_real2_length";
            txt_real2_length.ReadOnly = true;
            txt_real2_length.Size = new Size(100, 23);
            txt_real2_length.TabIndex = 41;
            // 
            // txt_real2_width
            // 
            txt_real2_width.Location = new Point(161, 239);
            txt_real2_width.Name = "txt_real2_width";
            txt_real2_width.ReadOnly = true;
            txt_real2_width.Size = new Size(100, 23);
            txt_real2_width.TabIndex = 40;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(74, 242);
            label18.Name = "label18";
            label18.Size = new Size(81, 15);
            label18.TabIndex = 39;
            label18.Text = "Real Utilizado:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(12, 285);
            label19.Name = "label19";
            label19.Size = new Size(65, 15);
            label19.TabIndex = 46;
            label19.Text = "Product Id.";
            // 
            // txt_product_id
            // 
            txt_product_id.Location = new Point(12, 303);
            txt_product_id.Name = "txt_product_id";
            txt_product_id.ReadOnly = true;
            txt_product_id.Size = new Size(100, 23);
            txt_product_id.TabIndex = 45;
            // 
            // txt_product_name
            // 
            txt_product_name.Location = new Point(161, 303);
            txt_product_name.Name = "txt_product_name";
            txt_product_name.ReadOnly = true;
            txt_product_name.Size = new Size(401, 23);
            txt_product_name.TabIndex = 47;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(161, 289);
            label20.Name = "label20";
            label20.Size = new Size(84, 15);
            label20.TabIndex = 48;
            label20.Text = "Product Name";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 329);
            label21.Name = "label21";
            label21.Size = new Size(39, 15);
            label21.TabIndex = 50;
            label21.Text = "Op. Id";
            // 
            // txt_operador_id
            // 
            txt_operador_id.Location = new Point(12, 347);
            txt_operador_id.Name = "txt_operador_id";
            txt_operador_id.ReadOnly = true;
            txt_operador_id.Size = new Size(100, 23);
            txt_operador_id.TabIndex = 49;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(162, 333);
            label22.Name = "label22";
            label22.Size = new Size(92, 15);
            label22.TabIndex = 52;
            label22.Text = "Operador Name";
            // 
            // txt_operador_name
            // 
            txt_operador_name.Location = new Point(162, 347);
            txt_operador_name.Name = "txt_operador_name";
            txt_operador_name.ReadOnly = true;
            txt_operador_name.Size = new Size(354, 23);
            txt_operador_name.TabIndex = 51;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(162, 377);
            label23.Name = "label23";
            label23.Size = new Size(94, 15);
            label23.TabIndex = 56;
            label23.Text = "Customer Name";
            // 
            // txt_cust_name
            // 
            txt_cust_name.Location = new Point(162, 391);
            txt_cust_name.Name = "txt_cust_name";
            txt_cust_name.ReadOnly = true;
            txt_cust_name.Size = new Size(354, 23);
            txt_cust_name.TabIndex = 55;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(12, 373);
            label24.Name = "label24";
            label24.Size = new Size(50, 15);
            label24.TabIndex = 54;
            label24.Text = "Cust. Id.";
            // 
            // txt_cust_id
            // 
            txt_cust_id.Location = new Point(12, 391);
            txt_cust_id.Name = "txt_cust_id";
            txt_cust_id.ReadOnly = true;
            txt_cust_id.Size = new Size(100, 23);
            txt_cust_id.TabIndex = 53;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(659, 77);
            label25.Name = "label25";
            label25.Size = new Size(159, 15);
            label25.TabIndex = 57;
            label25.Text = "DIMENSION DE LOS CORTES ";
            // 
            // txt_ancho_corte
            // 
            txt_ancho_corte.Location = new Point(638, 110);
            txt_ancho_corte.Name = "txt_ancho_corte";
            txt_ancho_corte.ReadOnly = true;
            txt_ancho_corte.Size = new Size(53, 23);
            txt_ancho_corte.TabIndex = 59;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.Location = new Point(638, 92);
            label26.Name = "label26";
            label26.Size = new Size(52, 15);
            label26.TabIndex = 58;
            label26.Text = "ANCHO:";
            // 
            // txt_largo_corte
            // 
            txt_largo_corte.Location = new Point(697, 110);
            txt_largo_corte.Name = "txt_largo_corte";
            txt_largo_corte.ReadOnly = true;
            txt_largo_corte.Size = new Size(53, 23);
            txt_largo_corte.TabIndex = 61;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label27.Location = new Point(697, 92);
            label27.Name = "label27";
            label27.Size = new Size(50, 15);
            label27.TabIndex = 60;
            label27.Text = "LARGO:";
            // 
            // txt_resta_corte
            // 
            txt_resta_corte.Location = new Point(756, 110);
            txt_resta_corte.Name = "txt_resta_corte";
            txt_resta_corte.ReadOnly = true;
            txt_resta_corte.Size = new Size(53, 23);
            txt_resta_corte.TabIndex = 63;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.Location = new Point(756, 92);
            label28.Name = "label28";
            label28.Size = new Size(45, 15);
            label28.TabIndex = 62;
            label28.Text = "RESTA:";
            // 
            // btn_buscar_customer
            // 
            btn_buscar_customer.Enabled = false;
            btn_buscar_customer.Location = new Point(522, 391);
            btn_buscar_customer.Name = "btn_buscar_customer";
            btn_buscar_customer.Size = new Size(38, 23);
            btn_buscar_customer.TabIndex = 64;
            btn_buscar_customer.Text = "...";
            btn_buscar_customer.UseVisualStyleBackColor = true;
            // 
            // btn_buscar_operador
            // 
            btn_buscar_operador.Enabled = false;
            btn_buscar_operador.Location = new Point(522, 347);
            btn_buscar_operador.Name = "btn_buscar_operador";
            btn_buscar_operador.Size = new Size(38, 23);
            btn_buscar_operador.TabIndex = 65;
            btn_buscar_operador.Text = "...";
            btn_buscar_operador.UseVisualStyleBackColor = true;
            // 
            // grid_cortes
            // 
            grid_cortes.AllowUserToAddRows = false;
            grid_cortes.AllowUserToDeleteRows = false;
            grid_cortes.AllowUserToResizeRows = false;
            grid_cortes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid_cortes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid_cortes.Location = new Point(569, 136);
            grid_cortes.MultiSelect = false;
            grid_cortes.Name = "grid_cortes";
            grid_cortes.ReadOnly = true;
            grid_cortes.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid_cortes.RowHeadersWidth = 32;
            grid_cortes.ScrollBars = ScrollBars.Vertical;
            grid_cortes.Size = new Size(353, 150);
            grid_cortes.TabIndex = 66;
            // 
            // btn_generar_rollos
            // 
            btn_generar_rollos.Image = (Image)resources.GetObject("btn_generar_rollos.Image");
            btn_generar_rollos.Location = new Point(569, 292);
            btn_generar_rollos.Name = "btn_generar_rollos";
            btn_generar_rollos.Size = new Size(353, 52);
            btn_generar_rollos.TabIndex = 67;
            btn_generar_rollos.Text = "Generar Rollos";
            btn_generar_rollos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_generar_rollos.UseVisualStyleBackColor = true;
            // 
            // btn_add_row_corte
            // 
            btn_add_row_corte.Enabled = false;
            btn_add_row_corte.Image = (Image)resources.GetObject("btn_add_row_corte.Image");
            btn_add_row_corte.Location = new Point(929, 135);
            btn_add_row_corte.Name = "btn_add_row_corte";
            btn_add_row_corte.Size = new Size(99, 38);
            btn_add_row_corte.TabIndex = 68;
            btn_add_row_corte.Text = "Agregar";
            btn_add_row_corte.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_add_row_corte.UseVisualStyleBackColor = true;
            // 
            // txt_delete_row_corte
            // 
            txt_delete_row_corte.Enabled = false;
            txt_delete_row_corte.Image = (Image)resources.GetObject("txt_delete_row_corte.Image");
            txt_delete_row_corte.Location = new Point(929, 173);
            txt_delete_row_corte.Name = "txt_delete_row_corte";
            txt_delete_row_corte.Size = new Size(99, 38);
            txt_delete_row_corte.TabIndex = 69;
            txt_delete_row_corte.Text = "Borrar";
            txt_delete_row_corte.TextImageRelation = TextImageRelation.ImageBeforeText;
            txt_delete_row_corte.UseVisualStyleBackColor = true;
            // 
            // txt_long_cortar
            // 
            txt_long_cortar.Location = new Point(929, 234);
            txt_long_cortar.Name = "txt_long_cortar";
            txt_long_cortar.ReadOnly = true;
            txt_long_cortar.Size = new Size(86, 23);
            txt_long_cortar.TabIndex = 71;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(929, 216);
            label29.Name = "label29";
            label29.Size = new Size(106, 15);
            label29.TabIndex = 70;
            label29.Text = "Longitud a Cortar :";
            // 
            // txt_vueltas1
            // 
            txt_vueltas1.Location = new Point(929, 278);
            txt_vueltas1.Name = "txt_vueltas1";
            txt_vueltas1.ReadOnly = true;
            txt_vueltas1.Size = new Size(80, 23);
            txt_vueltas1.TabIndex = 73;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(929, 260);
            label30.Name = "label30";
            label30.Size = new Size(86, 15);
            label30.TabIndex = 72;
            label30.Text = "Vueltas : [ID#1]";
            // 
            // txt_vueltas2
            // 
            txt_vueltas2.Location = new Point(1016, 279);
            txt_vueltas2.Name = "txt_vueltas2";
            txt_vueltas2.ReadOnly = true;
            txt_vueltas2.Size = new Size(77, 23);
            txt_vueltas2.TabIndex = 74;
            // 
            // txt_cortes_ancho
            // 
            txt_cortes_ancho.Location = new Point(929, 323);
            txt_cortes_ancho.Name = "txt_cortes_ancho";
            txt_cortes_ancho.ReadOnly = true;
            txt_cortes_ancho.Size = new Size(86, 23);
            txt_cortes_ancho.TabIndex = 76;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(929, 305);
            label31.Name = "label31";
            label31.Size = new Size(107, 15);
            label31.TabIndex = 75;
            label31.Text = "Cortes a lo Ancho :";
            // 
            // txt_rollos_cortar2
            // 
            txt_rollos_cortar2.Location = new Point(1021, 367);
            txt_rollos_cortar2.Name = "txt_rollos_cortar2";
            txt_rollos_cortar2.ReadOnly = true;
            txt_rollos_cortar2.Size = new Size(72, 23);
            txt_rollos_cortar2.TabIndex = 79;
            // 
            // txt_rollos_cortar1
            // 
            txt_rollos_cortar1.Location = new Point(929, 367);
            txt_rollos_cortar1.Name = "txt_rollos_cortar1";
            txt_rollos_cortar1.ReadOnly = true;
            txt_rollos_cortar1.Size = new Size(86, 23);
            txt_rollos_cortar1.TabIndex = 78;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(929, 349);
            label32.Name = "label32";
            label32.Size = new Size(118, 15);
            label32.TabIndex = 77;
            label32.Text = "Total Rollos a Cortar :";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(995, 259);
            label33.Name = "label33";
            label33.Size = new Size(86, 15);
            label33.TabIndex = 80;
            label33.Text = "Vueltas : [ID#2]";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(grid_items);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(912, 188);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Rollos Cortados";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // grid_items
            // 
            grid_items.AllowUserToAddRows = false;
            grid_items.AllowUserToDeleteRows = false;
            grid_items.AllowUserToResizeRows = false;
            grid_items.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid_items.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid_items.Location = new Point(3, 6);
            grid_items.MultiSelect = false;
            grid_items.Name = "grid_items";
            grid_items.ReadOnly = true;
            grid_items.RowHeadersWidth = 34;
            grid_items.ScrollBars = ScrollBars.Vertical;
            grid_items.Size = new Size(903, 176);
            grid_items.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 417);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(920, 216);
            tabControl1.TabIndex = 81;
            // 
            // chk_document_anul
            // 
            chk_document_anul.AutoSize = true;
            chk_document_anul.Location = new Point(12, 639);
            chk_document_anul.Name = "chk_document_anul";
            chk_document_anul.Size = new Size(137, 19);
            chk_document_anul.TabIndex = 82;
            chk_document_anul.Text = "Documento Anulado";
            chk_document_anul.UseVisualStyleBackColor = true;
            // 
            // chk_orden_rebobinado
            // 
            chk_orden_rebobinado.AutoSize = true;
            chk_orden_rebobinado.Location = new Point(12, 664);
            chk_orden_rebobinado.Name = "chk_orden_rebobinado";
            chk_orden_rebobinado.Size = new Size(126, 19);
            chk_orden_rebobinado.TabIndex = 83;
            chk_orden_rebobinado.Text = "Orden Rebobinado";
            chk_orden_rebobinado.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(934, 450);
            label34.Name = "label34";
            label34.Size = new Size(111, 15);
            label34.TabIndex = 89;
            label34.Text = "Status Documento :";
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_status.Location = new Point(934, 467);
            label_status.Name = "label_status";
            label_status.Size = new Size(62, 15);
            label_status.TabIndex = 90;
            label_status.Text = "CERRADO";
            // 
            // btn_vueltas
            // 
            btn_vueltas.Image = (Image)resources.GetObject("btn_vueltas.Image");
            btn_vueltas.Location = new Point(650, 637);
            btn_vueltas.Name = "btn_vueltas";
            btn_vueltas.Size = new Size(100, 48);
            btn_vueltas.TabIndex = 91;
            btn_vueltas.Text = "Vueltas";
            btn_vueltas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_vueltas.UseVisualStyleBackColor = true;
            // 
            // txt_code_person
            // 
            txt_code_person.Location = new Point(755, 660);
            txt_code_person.Name = "txt_code_person";
            txt_code_person.Size = new Size(127, 23);
            txt_code_person.TabIndex = 93;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(755, 642);
            label36.Name = "label36";
            label36.Size = new Size(128, 15);
            label36.TabIndex = 92;
            label36.Text = "Codigo Personalizado :";
            // 
            // btn_code_person
            // 
            btn_code_person.Location = new Point(884, 660);
            btn_code_person.Name = "btn_code_person";
            btn_code_person.Size = new Size(38, 25);
            btn_code_person.TabIndex = 94;
            btn_code_person.Text = "...";
            btn_code_person.UseVisualStyleBackColor = true;
            // 
            // chk_unificar_rollos
            // 
            chk_unificar_rollos.AutoSize = true;
            chk_unificar_rollos.Location = new Point(929, 397);
            chk_unificar_rollos.Name = "chk_unificar_rollos";
            chk_unificar_rollos.Size = new Size(97, 19);
            chk_unificar_rollos.TabIndex = 95;
            chk_unificar_rollos.Text = "Unificar Rollo";
            chk_unificar_rollos.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(161, 637);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 96;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Enabled = false;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(237, 637);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(319, 637);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(40, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 98;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(400, 637);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 40);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 99;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(479, 637);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 100;
            pictureBox5.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(527, 642);
            button1.Name = "button1";
            button1.Size = new Size(29, 23);
            button1.TabIndex = 101;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "step1.png");
            imageList1.Images.SetKeyName(1, "step2_active.png");
            imageList1.Images.SetKeyName(2, "step3_active.png");
            imageList1.Images.SetKeyName(3, "step4_active.png");
            imageList1.Images.SetKeyName(4, "step5_active.png");
            imageList1.Images.SetKeyName(5, "step1_deactivate.png");
            imageList1.Images.SetKeyName(6, "step2_deactivate.png");
            imageList1.Images.SetKeyName(7, "step3_deactive.png");
            imageList1.Images.SetKeyName(8, "step4_deactive.png");
            imageList1.Images.SetKeyName(9, "step5_deactive.png");
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.product_management_48px;
            pictureBox6.Location = new Point(333, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(50, 48);
            pictureBox6.TabIndex = 97;
            pictureBox6.TabStop = false;
            // 
            // FrmOrdenCorte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 692);
            Controls.Add(button1);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(chk_unificar_rollos);
            Controls.Add(btn_code_person);
            Controls.Add(txt_code_person);
            Controls.Add(label36);
            Controls.Add(btn_vueltas);
            Controls.Add(label_status);
            Controls.Add(label34);
            Controls.Add(chk_orden_rebobinado);
            Controls.Add(chk_document_anul);
            Controls.Add(tabControl1);
            Controls.Add(label33);
            Controls.Add(txt_rollos_cortar2);
            Controls.Add(txt_rollos_cortar1);
            Controls.Add(label32);
            Controls.Add(txt_cortes_ancho);
            Controls.Add(label31);
            Controls.Add(txt_vueltas2);
            Controls.Add(txt_vueltas1);
            Controls.Add(label30);
            Controls.Add(txt_long_cortar);
            Controls.Add(label29);
            Controls.Add(txt_delete_row_corte);
            Controls.Add(btn_add_row_corte);
            Controls.Add(btn_generar_rollos);
            Controls.Add(grid_cortes);
            Controls.Add(btn_buscar_operador);
            Controls.Add(btn_buscar_customer);
            Controls.Add(txt_resta_corte);
            Controls.Add(label28);
            Controls.Add(txt_largo_corte);
            Controls.Add(label27);
            Controls.Add(txt_ancho_corte);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(label23);
            Controls.Add(txt_cust_name);
            Controls.Add(label24);
            Controls.Add(txt_cust_id);
            Controls.Add(label22);
            Controls.Add(txt_operador_name);
            Controls.Add(label21);
            Controls.Add(txt_operador_id);
            Controls.Add(label20);
            Controls.Add(txt_product_name);
            Controls.Add(label19);
            Controls.Add(txt_product_id);
            Controls.Add(label17);
            Controls.Add(txt_matrest2_lenght);
            Controls.Add(txt_matrest2_width);
            Controls.Add(txt_real2_length);
            Controls.Add(txt_real2_width);
            Controls.Add(label18);
            Controls.Add(textBox15);
            Controls.Add(label14);
            Controls.Add(txt_menos2);
            Controls.Add(label15);
            Controls.Add(txt_plus2);
            Controls.Add(label16);
            Controls.Add(label13);
            Controls.Add(btn_buscar_rollid2);
            Controls.Add(txt_length2);
            Controls.Add(txt_width2);
            Controls.Add(txt_rollid_2);
            Controls.Add(label12);
            Controls.Add(txt_matrest1_lenght);
            Controls.Add(txt_matrest1_width);
            Controls.Add(txt_real1_length);
            Controls.Add(txt_real1_width);
            Controls.Add(label11);
            Controls.Add(textBox7);
            Controls.Add(label10);
            Controls.Add(txt_menos1);
            Controls.Add(label9);
            Controls.Add(txt_plus1);
            Controls.Add(label8);
            Controls.Add(txt_length1);
            Controls.Add(label7);
            Controls.Add(txt_width1);
            Controls.Add(label6);
            Controls.Add(btn_buscar_rollid1);
            Controls.Add(txt_rollid_1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txt_fecha_produccion);
            Controls.Add(label3);
            Controls.Add(txt_fecha_emision);
            Controls.Add(txt_numeroOC);
            Controls.Add(label2);
            Controls.Add(toolStrip1);
            Controls.Add(panel1);
            Name = "FrmOrdenCorte";
            Text = " ";
            Load += FrmOrdenCorte_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid_cortes).EndInit();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)grid_items).EndInit();
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ToolStrip toolStrip1;
        private Label label2;
        private TextBox txt_numeroOC;
        private DateTimePicker txt_fecha_emision;
        private Label label3;
        private DateTimePicker txt_fecha_produccion;
        private Label label4;
        private TextBox txt_rollid_1;
        private Label label5;
        private Button btn_buscar_rollid1;
        private TextBox txt_width1;
        private Label label6;
        private TextBox txt_length1;
        private Label label7;
        private TextBox txt_plus1;
        private Label label8;
        private TextBox txt_menos1;
        private Label label9;
        private TextBox textBox7;
        private Label label10;
        private Label label11;
        private TextBox txt_real1_width;
        private TextBox txt_real1_length;
        private TextBox txt_matrest1_lenght;
        private TextBox txt_matrest1_width;
        private Label label12;
        private TextBox txt_rollid_2;
        private TextBox txt_length2;
        private TextBox txt_width2;
        private Button btn_buscar_rollid2;
        private Label label13;
        private TextBox textBox15;
        private Label label14;
        private TextBox txt_menos2;
        private Label label15;
        private TextBox txt_plus2;
        private Label label16;
        private Label label17;
        private TextBox txt_matrest2_lenght;
        private TextBox txt_matrest2_width;
        private TextBox txt_real2_length;
        private TextBox txt_real2_width;
        private Label label18;
        private Label label19;
        private TextBox txt_product_id;
        private TextBox txt_product_name;
        private Label label20;
        private Label label21;
        private TextBox txt_operador_id;
        private Label label22;
        private TextBox txt_operador_name;
        private Label label23;
        private TextBox txt_cust_name;
        private Label label24;
        private TextBox txt_cust_id;
        private Label label25;
        private TextBox txt_ancho_corte;
        private Label label26;
        private TextBox txt_largo_corte;
        private Label label27;
        private TextBox txt_resta_corte;
        private Label label28;
        private Button btn_buscar_customer;
        private Button btn_buscar_operador;
        private DataGridView grid_cortes;
        private Button btn_generar_rollos;
        private Button btn_add_row_corte;
        private Button txt_delete_row_corte;
        private TextBox txt_long_cortar;
        private Label label29;
        private TextBox txt_vueltas1;
        private Label label30;
        private TextBox txt_vueltas2;
        private TextBox txt_cortes_ancho;
        private Label label31;
        private TextBox txt_rollos_cortar2;
        private TextBox txt_rollos_cortar1;
        private Label label32;
        private Label label33;
        private TabPage tabPage1;
        private TabControl tabControl1;
        private DataGridView grid_items;
        private CheckBox chk_document_anul;
        private CheckBox chk_orden_rebobinado;
        private Label label34;
        private Label label_status;
        private Button btn_vueltas;
        private TextBox txt_code_person;
        private Label label36;
        private Button btn_code_person;
        private ToolStripButton bot_etiquetar;
        private CheckBox chk_unificar_rollos;
        private ToolStripButton bot_primero;
        private ToolStripButton bot_anterior;
        private ToolStripButton bot_siguiente;
        private ToolStripButton bot_ultimo;
        private ToolStripButton bot_guardar;
        private ToolStripButton bot_cancelar;
        private ToolStripButton bot_imprimir;
        private ToolStripButton bot_exportar;
        private ToolStripDropDownButton bot_accion;
        private ToolStripMenuItem opt_create_document;
        private ToolStripMenuItem opt_send_production;
        private ToolStripMenuItem opt_etiquetar_orden;
        private ToolStripMenuItem opt_aprobar_orden;
        private ToolStripMenuItem opt_cerrar_orden;
        private ToolStripMenuItem opt_modif_orden;
        private Label registros;
        private ToolStripButton toolStripButton1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Button button1;
        private ImageList imageList1;
        private PictureBox pictureBox6;
    }
}