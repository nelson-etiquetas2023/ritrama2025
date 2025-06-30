namespace Ritrama2025.Forms
{
    partial class FrmMateriaPrima
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriaPrima));
            toolStrip1 = new ToolStrip();
            btn_primero = new ToolStripButton();
            btn_anterior = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            btn_siguiente = new ToolStripButton();
            btn_ultimo = new ToolStripButton();
            btn_create = new ToolStripButton();
            btn_cancel = new ToolStripButton();
            btn_save = new ToolStripButton();
            btn_CloseDoc = new ToolStripButton();
            btn_AnularDoc = new ToolStripButton();
            btn_SearchDoc = new ToolStripButton();
            btn_printDoc = new ToolStripButton();
            btn_ExportDoc = new ToolStripButton();
            label1 = new Label();
            txt_numeroOrden = new TextBox();
            label2 = new Label();
            txt_fecha_recepcion = new DateTimePicker();
            txt_prov_Id = new TextBox();
            label3 = new Label();
            txt_nombre_prov = new TextBox();
            btn_ProvBuscar = new Button();
            txt_transport_name = new TextBox();
            txt_transport_id = new TextBox();
            label4 = new Label();
            btn_TransportBuscar = new Button();
            txt_OrdenCompra = new TextBox();
            label5 = new Label();
            txt_person_name = new TextBox();
            label6 = new Label();
            btn_RecepBuscar = new Button();
            txt_guia = new TextBox();
            label7 = new Label();
            rad_DocumentProcess = new RadioButton();
            rad_OrdenAbierta = new RadioButton();
            txt_notas = new RichTextBox();
            label8 = new Label();
            txt_total_cantidad = new TextBox();
            label9 = new Label();
            btn_addRows = new Button();
            btn_deleteRows = new Button();
            txt_lote = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txt_fecha_produccion = new DateTimePicker();
            label12 = new Label();
            btn_OrdenBuscar = new Button();
            panel1 = new Panel();
            label_counter_rows = new Label();
            pictureBox6 = new PictureBox();
            label13 = new Label();
            chk_anulado = new CheckBox();
            btn_AppMovil = new Button();
            GridItems = new DataGridView();
            txt_person_id = new TextBox();
            txt_embarque = new TextBox();
            label16 = new Label();
            btn_template = new Button();
            btn_LoadRows = new Button();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GridItems).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_primero, btn_anterior, toolStripButton3, btn_siguiente, btn_ultimo, btn_create, btn_cancel, btn_save, btn_CloseDoc, btn_AnularDoc, btn_SearchDoc, btn_printDoc, btn_ExportDoc });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1156, 44);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_primero
            // 
            btn_primero.AutoSize = false;
            btn_primero.Font = new Font("Noto Sans", 9.75F);
            btn_primero.Image = (Image)resources.GetObject("btn_primero.Image");
            btn_primero.ImageTransparentColor = Color.Magenta;
            btn_primero.Name = "btn_primero";
            btn_primero.Size = new Size(75, 40);
            btn_primero.Text = "Primero";
            btn_primero.Click += Btn_primero_Click;
            // 
            // btn_anterior
            // 
            btn_anterior.AutoSize = false;
            btn_anterior.Font = new Font("Noto Sans", 9.75F);
            btn_anterior.Image = (Image)resources.GetObject("btn_anterior.Image");
            btn_anterior.ImageTransparentColor = Color.Magenta;
            btn_anterior.Name = "btn_anterior";
            btn_anterior.Size = new Size(75, 40);
            btn_anterior.Text = "Anterior";
            btn_anterior.Click += Btn_anterior_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.Font = new Font("Noto Sans", 9.75F);
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(84, 41);
            toolStripButton3.Text = "Siguiente";
            // 
            // btn_siguiente
            // 
            btn_siguiente.Font = new Font("Noto Sans", 9.75F);
            btn_siguiente.Image = (Image)resources.GetObject("btn_siguiente.Image");
            btn_siguiente.ImageTransparentColor = Color.Magenta;
            btn_siguiente.Name = "btn_siguiente";
            btn_siguiente.Size = new Size(84, 41);
            btn_siguiente.Text = "Siguiente";
            btn_siguiente.Click += Btn_siguiente_Click;
            // 
            // btn_ultimo
            // 
            btn_ultimo.AutoSize = false;
            btn_ultimo.Font = new Font("Noto Sans", 9.75F);
            btn_ultimo.Image = (Image)resources.GetObject("btn_ultimo.Image");
            btn_ultimo.ImageTransparentColor = Color.Magenta;
            btn_ultimo.Name = "btn_ultimo";
            btn_ultimo.Size = new Size(75, 40);
            btn_ultimo.Text = "Ultimo";
            btn_ultimo.Click += Btn_ultimo_Click;
            // 
            // btn_create
            // 
            btn_create.AutoSize = false;
            btn_create.Font = new Font("Noto Sans", 9.75F);
            btn_create.Image = (Image)resources.GetObject("btn_create.Image");
            btn_create.ImageTransparentColor = Color.Magenta;
            btn_create.Name = "btn_create";
            btn_create.Size = new Size(75, 40);
            btn_create.Text = "Nuevo";
            btn_create.Click += Btn_create_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.AutoSize = false;
            btn_cancel.Enabled = false;
            btn_cancel.Font = new Font("Noto Sans", 9.75F);
            btn_cancel.Image = (Image)resources.GetObject("btn_cancel.Image");
            btn_cancel.ImageTransparentColor = Color.Magenta;
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(75, 40);
            btn_cancel.Text = "Cancelar";
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_save
            // 
            btn_save.AutoSize = false;
            btn_save.Enabled = false;
            btn_save.Font = new Font("Noto Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_save.Image = (Image)resources.GetObject("btn_save.Image");
            btn_save.ImageTransparentColor = Color.Magenta;
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(75, 40);
            btn_save.Text = "Guardar";
            btn_save.Click += Btn_save_Click;
            // 
            // btn_CloseDoc
            // 
            btn_CloseDoc.AutoSize = false;
            btn_CloseDoc.Font = new Font("Noto Sans", 9.75F);
            btn_CloseDoc.Image = (Image)resources.GetObject("btn_CloseDoc.Image");
            btn_CloseDoc.ImageTransparentColor = Color.Magenta;
            btn_CloseDoc.Name = "btn_CloseDoc";
            btn_CloseDoc.Size = new Size(75, 40);
            btn_CloseDoc.Text = "Close";
            // 
            // btn_AnularDoc
            // 
            btn_AnularDoc.Font = new Font("Noto Sans", 9.75F);
            btn_AnularDoc.Image = (Image)resources.GetObject("btn_AnularDoc.Image");
            btn_AnularDoc.ImageTransparentColor = Color.Magenta;
            btn_AnularDoc.Name = "btn_AnularDoc";
            btn_AnularDoc.Size = new Size(67, 41);
            btn_AnularDoc.Text = "Anular";
            // 
            // btn_SearchDoc
            // 
            btn_SearchDoc.Font = new Font("Noto Sans", 9.75F);
            btn_SearchDoc.Image = (Image)resources.GetObject("btn_SearchDoc.Image");
            btn_SearchDoc.ImageTransparentColor = Color.Magenta;
            btn_SearchDoc.Name = "btn_SearchDoc";
            btn_SearchDoc.Size = new Size(68, 41);
            btn_SearchDoc.Text = "Buscar";
            // 
            // btn_printDoc
            // 
            btn_printDoc.Font = new Font("Noto Sans", 9.75F);
            btn_printDoc.Image = (Image)resources.GetObject("btn_printDoc.Image");
            btn_printDoc.ImageTransparentColor = Color.Magenta;
            btn_printDoc.Name = "btn_printDoc";
            btn_printDoc.Size = new Size(80, 41);
            btn_printDoc.Text = "Imprimir";
            // 
            // btn_ExportDoc
            // 
            btn_ExportDoc.Font = new Font("Noto Sans", 9.75F);
            btn_ExportDoc.Image = (Image)resources.GetObject("btn_ExportDoc.Image");
            btn_ExportDoc.ImageTransparentColor = Color.Magenta;
            btn_ExportDoc.Name = "btn_ExportDoc";
            btn_ExportDoc.Size = new Size(80, 41);
            btn_ExportDoc.Text = "Exportar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 126);
            label1.Name = "label1";
            label1.Size = new Size(106, 18);
            label1.TabIndex = 1;
            label1.Text = "Numero Orden :";
            // 
            // txt_numeroOrden
            // 
            txt_numeroOrden.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_numeroOrden.Location = new Point(14, 148);
            txt_numeroOrden.Margin = new Padding(3, 4, 3, 4);
            txt_numeroOrden.Name = "txt_numeroOrden";
            txt_numeroOrden.ReadOnly = true;
            txt_numeroOrden.Size = new Size(182, 25);
            txt_numeroOrden.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 182);
            label2.Name = "label2";
            label2.Size = new Size(114, 18);
            label2.TabIndex = 3;
            label2.Text = "Fecha Recepcion :";
            // 
            // txt_fecha_recepcion
            // 
            txt_fecha_recepcion.Enabled = false;
            txt_fecha_recepcion.Location = new Point(14, 204);
            txt_fecha_recepcion.Margin = new Padding(3, 4, 3, 4);
            txt_fecha_recepcion.Name = "txt_fecha_recepcion";
            txt_fecha_recepcion.Size = new Size(247, 25);
            txt_fecha_recepcion.TabIndex = 2;
            // 
            // txt_prov_Id
            // 
            txt_prov_Id.Location = new Point(525, 148);
            txt_prov_Id.Margin = new Padding(3, 4, 3, 4);
            txt_prov_Id.Name = "txt_prov_Id";
            txt_prov_Id.ReadOnly = true;
            txt_prov_Id.Size = new Size(73, 25);
            txt_prov_Id.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(525, 126);
            label3.Name = "label3";
            label3.Size = new Size(137, 18);
            label3.TabIndex = 5;
            label3.Text = "Datos del Proveedor :";
            // 
            // txt_nombre_prov
            // 
            txt_nombre_prov.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_nombre_prov.Location = new Point(605, 148);
            txt_nombre_prov.Margin = new Padding(3, 4, 3, 4);
            txt_nombre_prov.Name = "txt_nombre_prov";
            txt_nombre_prov.ReadOnly = true;
            txt_nombre_prov.Size = new Size(363, 25);
            txt_nombre_prov.TabIndex = 7;
            // 
            // btn_ProvBuscar
            // 
            btn_ProvBuscar.Enabled = false;
            btn_ProvBuscar.Location = new Point(975, 148);
            btn_ProvBuscar.Margin = new Padding(3, 4, 3, 4);
            btn_ProvBuscar.Name = "btn_ProvBuscar";
            btn_ProvBuscar.Size = new Size(53, 28);
            btn_ProvBuscar.TabIndex = 7;
            btn_ProvBuscar.Text = "...";
            btn_ProvBuscar.UseVisualStyleBackColor = true;
            btn_ProvBuscar.Click += Btn_ProvBuscar_Click;
            // 
            // txt_transport_name
            // 
            txt_transport_name.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_transport_name.Location = new Point(606, 204);
            txt_transport_name.Margin = new Padding(3, 4, 3, 4);
            txt_transport_name.Name = "txt_transport_name";
            txt_transport_name.ReadOnly = true;
            txt_transport_name.Size = new Size(363, 25);
            txt_transport_name.TabIndex = 11;
            // 
            // txt_transport_id
            // 
            txt_transport_id.Location = new Point(527, 204);
            txt_transport_id.Margin = new Padding(3, 4, 3, 4);
            txt_transport_id.Name = "txt_transport_id";
            txt_transport_id.ReadOnly = true;
            txt_transport_id.Size = new Size(73, 25);
            txt_transport_id.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 181);
            label4.Name = "label4";
            label4.Size = new Size(95, 18);
            label4.TabIndex = 9;
            label4.Text = "Transportista :";
            // 
            // btn_TransportBuscar
            // 
            btn_TransportBuscar.Enabled = false;
            btn_TransportBuscar.Location = new Point(975, 203);
            btn_TransportBuscar.Margin = new Padding(3, 4, 3, 4);
            btn_TransportBuscar.Name = "btn_TransportBuscar";
            btn_TransportBuscar.Size = new Size(53, 28);
            btn_TransportBuscar.TabIndex = 8;
            btn_TransportBuscar.Text = "...";
            btn_TransportBuscar.UseVisualStyleBackColor = true;
            btn_TransportBuscar.Click += Btn_TransportBuscar_Click;
            // 
            // txt_OrdenCompra
            // 
            txt_OrdenCompra.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_OrdenCompra.Location = new Point(269, 148);
            txt_OrdenCompra.Margin = new Padding(3, 4, 3, 4);
            txt_OrdenCompra.Name = "txt_OrdenCompra";
            txt_OrdenCompra.ReadOnly = true;
            txt_OrdenCompra.Size = new Size(247, 25);
            txt_OrdenCompra.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(269, 126);
            label5.Name = "label5";
            label5.Size = new Size(122, 18);
            label5.TabIndex = 13;
            label5.Text = "Orden de Compra :";
            // 
            // txt_person_name
            // 
            txt_person_name.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_person_name.Location = new Point(623, 277);
            txt_person_name.Margin = new Padding(3, 4, 3, 4);
            txt_person_name.Name = "txt_person_name";
            txt_person_name.ReadOnly = true;
            txt_person_name.Size = new Size(191, 25);
            txt_person_name.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(536, 257);
            label6.Name = "label6";
            label6.Size = new Size(106, 18);
            label6.TabIndex = 15;
            label6.Text = "Persona Recibe :";
            // 
            // btn_RecepBuscar
            // 
            btn_RecepBuscar.Enabled = false;
            btn_RecepBuscar.Location = new Point(820, 275);
            btn_RecepBuscar.Margin = new Padding(3, 4, 3, 4);
            btn_RecepBuscar.Name = "btn_RecepBuscar";
            btn_RecepBuscar.Size = new Size(53, 28);
            btn_RecepBuscar.TabIndex = 9;
            btn_RecepBuscar.Text = "...";
            btn_RecepBuscar.UseVisualStyleBackColor = true;
            btn_RecepBuscar.Click += Btn_RecepBuscar_Click;
            // 
            // txt_guia
            // 
            txt_guia.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_guia.Location = new Point(14, 278);
            txt_guia.Margin = new Padding(3, 4, 3, 4);
            txt_guia.Name = "txt_guia";
            txt_guia.ReadOnly = true;
            txt_guia.Size = new Size(140, 25);
            txt_guia.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 257);
            label7.Name = "label7";
            label7.Size = new Size(137, 18);
            label7.TabIndex = 18;
            label7.Text = "Guia de Importacion :";
            // 
            // rad_DocumentProcess
            // 
            rad_DocumentProcess.AutoSize = true;
            rad_DocumentProcess.Location = new Point(937, 285);
            rad_DocumentProcess.Margin = new Padding(3, 4, 3, 4);
            rad_DocumentProcess.Name = "rad_DocumentProcess";
            rad_DocumentProcess.Size = new Size(78, 22);
            rad_DocumentProcess.TabIndex = 1;
            rad_DocumentProcess.TabStop = true;
            rad_DocumentProcess.Text = "Cerrrada";
            rad_DocumentProcess.UseVisualStyleBackColor = true;
            // 
            // rad_OrdenAbierta
            // 
            rad_OrdenAbierta.AutoSize = true;
            rad_OrdenAbierta.Location = new Point(937, 268);
            rad_OrdenAbierta.Margin = new Padding(3, 4, 3, 4);
            rad_OrdenAbierta.Name = "rad_OrdenAbierta";
            rad_OrdenAbierta.Size = new Size(69, 22);
            rad_OrdenAbierta.TabIndex = 0;
            rad_OrdenAbierta.TabStop = true;
            rad_OrdenAbierta.Text = "Abierta";
            rad_OrdenAbierta.UseVisualStyleBackColor = true;
            // 
            // txt_notas
            // 
            txt_notas.BackColor = SystemColors.ActiveBorder;
            txt_notas.Location = new Point(14, 626);
            txt_notas.Margin = new Padding(3, 4, 3, 4);
            txt_notas.Name = "txt_notas";
            txt_notas.ReadOnly = true;
            txt_notas.Size = new Size(502, 146);
            txt_notas.TabIndex = 14;
            txt_notas.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 605);
            label8.Name = "label8";
            label8.Size = new Size(151, 18);
            label8.TabIndex = 23;
            label8.Text = "Notas del Documento";
            // 
            // txt_total_cantidad
            // 
            txt_total_cantidad.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_total_cantidad.Location = new Point(862, 597);
            txt_total_cantidad.Margin = new Padding(3, 4, 3, 4);
            txt_total_cantidad.Name = "txt_total_cantidad";
            txt_total_cantidad.ReadOnly = true;
            txt_total_cantidad.Size = new Size(166, 25);
            txt_total_cantidad.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(750, 600);
            label9.Name = "label9";
            label9.Size = new Size(105, 18);
            label9.TabIndex = 24;
            label9.Text = "Total Cantidad : ";
            // 
            // btn_addRows
            // 
            btn_addRows.Enabled = false;
            btn_addRows.Image = (Image)resources.GetObject("btn_addRows.Image");
            btn_addRows.Location = new Point(1034, 310);
            btn_addRows.Margin = new Padding(3, 4, 3, 4);
            btn_addRows.Name = "btn_addRows";
            btn_addRows.Size = new Size(107, 41);
            btn_addRows.TabIndex = 11;
            btn_addRows.Text = "Agregar";
            btn_addRows.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_addRows.UseVisualStyleBackColor = true;
            btn_addRows.Click += Btn_addRows_Click;
            // 
            // btn_deleteRows
            // 
            btn_deleteRows.Enabled = false;
            btn_deleteRows.Image = (Image)resources.GetObject("btn_deleteRows.Image");
            btn_deleteRows.Location = new Point(1034, 359);
            btn_deleteRows.Margin = new Padding(3, 4, 3, 4);
            btn_deleteRows.Name = "btn_deleteRows";
            btn_deleteRows.Size = new Size(107, 41);
            btn_deleteRows.TabIndex = 12;
            btn_deleteRows.Text = "Borrar";
            btn_deleteRows.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_deleteRows.UseVisualStyleBackColor = true;
            // 
            // txt_lote
            // 
            txt_lote.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_lote.Location = new Point(161, 278);
            txt_lote.Margin = new Padding(3, 4, 3, 4);
            txt_lote.Name = "txt_lote";
            txt_lote.ReadOnly = true;
            txt_lote.Size = new Size(140, 25);
            txt_lote.TabIndex = 5;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(161, 257);
            label10.Name = "label10";
            label10.Size = new Size(95, 18);
            label10.TabIndex = 28;
            label10.Text = "Numero Lote :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(306, 257);
            label11.Name = "label11";
            label11.Size = new Size(130, 18);
            label11.TabIndex = 30;
            label11.Text = "Numero Embarque :";
            label11.UseWaitCursor = true;
            // 
            // txt_fecha_produccion
            // 
            txt_fecha_produccion.Enabled = false;
            txt_fecha_produccion.Location = new Point(267, 204);
            txt_fecha_produccion.Margin = new Padding(3, 4, 3, 4);
            txt_fecha_produccion.Name = "txt_fecha_produccion";
            txt_fecha_produccion.Size = new Size(247, 25);
            txt_fecha_produccion.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(267, 182);
            label12.Name = "label12";
            label12.Size = new Size(121, 18);
            label12.TabIndex = 32;
            label12.Text = "Fecha Produccion :";
            // 
            // btn_OrdenBuscar
            // 
            btn_OrdenBuscar.Image = Properties.Resources.search_property32_32;
            btn_OrdenBuscar.Location = new Point(203, 134);
            btn_OrdenBuscar.Margin = new Padding(3, 4, 3, 4);
            btn_OrdenBuscar.Name = "btn_OrdenBuscar";
            btn_OrdenBuscar.Size = new Size(53, 40);
            btn_OrdenBuscar.TabIndex = 34;
            btn_OrdenBuscar.Text = "...";
            btn_OrdenBuscar.UseVisualStyleBackColor = true;
            btn_OrdenBuscar.Click += btn_OrdenBuscar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label_counter_rows);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(label13);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1156, 82);
            panel1.TabIndex = 36;
            // 
            // label_counter_rows
            // 
            label_counter_rows.AutoSize = true;
            label_counter_rows.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_counter_rows.Location = new Point(975, 26);
            label_counter_rows.Name = "label_counter_rows";
            label_counter_rows.Size = new Size(99, 25);
            label_counter_rows.TabIndex = 97;
            label_counter_rows.Text = "Registros:";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(323, 19);
            pictureBox6.Margin = new Padding(3, 4, 3, 4);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(65, 56);
            pictureBox6.TabIndex = 97;
            pictureBox6.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ControlLightLight;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(394, 26);
            label13.Name = "label13";
            label13.Size = new Size(383, 32);
            label13.TabIndex = 0;
            label13.Text = "RECEPCION DE MATERIA PRIMA";
            // 
            // chk_anulado
            // 
            chk_anulado.AutoSize = true;
            chk_anulado.Location = new Point(862, 630);
            chk_anulado.Margin = new Padding(3, 4, 3, 4);
            chk_anulado.Name = "chk_anulado";
            chk_anulado.Size = new Size(151, 22);
            chk_anulado.TabIndex = 37;
            chk_anulado.Text = "Documento Anulado";
            chk_anulado.UseVisualStyleBackColor = true;
            // 
            // btn_AppMovil
            // 
            btn_AppMovil.Enabled = false;
            btn_AppMovil.Location = new Point(1029, 148);
            btn_AppMovil.Margin = new Padding(3, 4, 3, 4);
            btn_AppMovil.Name = "btn_AppMovil";
            btn_AppMovil.Size = new Size(107, 28);
            btn_AppMovil.TabIndex = 40;
            btn_AppMovil.Text = "App Movil";
            btn_AppMovil.UseVisualStyleBackColor = true;
            // 
            // GridItems
            // 
            GridItems.AllowUserToAddRows = false;
            GridItems.AllowUserToDeleteRows = false;
            GridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridItems.Location = new Point(14, 310);
            GridItems.Name = "GridItems";
            GridItems.ReadOnly = true;
            GridItems.Size = new Size(1014, 260);
            GridItems.TabIndex = 10;
            // 
            // txt_person_id
            // 
            txt_person_id.Location = new Point(536, 278);
            txt_person_id.Margin = new Padding(3, 4, 3, 4);
            txt_person_id.Name = "txt_person_id";
            txt_person_id.ReadOnly = true;
            txt_person_id.Size = new Size(80, 25);
            txt_person_id.TabIndex = 42;
            // 
            // txt_embarque
            // 
            txt_embarque.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_embarque.Location = new Point(307, 279);
            txt_embarque.Name = "txt_embarque";
            txt_embarque.ReadOnly = true;
            txt_embarque.Size = new Size(129, 25);
            txt_embarque.TabIndex = 6;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(934, 246);
            label16.Name = "label16";
            label16.Size = new Size(101, 18);
            label16.TabIndex = 43;
            label16.Text = "Status Orden :";
            // 
            // btn_template
            // 
            btn_template.Enabled = false;
            btn_template.Image = (Image)resources.GetObject("btn_template.Image");
            btn_template.Location = new Point(1037, 439);
            btn_template.Margin = new Padding(3, 4, 3, 4);
            btn_template.Name = "btn_template";
            btn_template.Size = new Size(107, 41);
            btn_template.TabIndex = 44;
            btn_template.Text = "Plantilla";
            btn_template.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_template.UseVisualStyleBackColor = true;
            btn_template.Click += btn_template_Click;
            // 
            // btn_LoadRows
            // 
            btn_LoadRows.Enabled = false;
            btn_LoadRows.Image = (Image)resources.GetObject("btn_LoadRows.Image");
            btn_LoadRows.Location = new Point(1037, 488);
            btn_LoadRows.Margin = new Padding(3, 4, 3, 4);
            btn_LoadRows.Name = "btn_LoadRows";
            btn_LoadRows.Size = new Size(107, 41);
            btn_LoadRows.TabIndex = 45;
            btn_LoadRows.Text = "Cargar";
            btn_LoadRows.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_LoadRows.UseVisualStyleBackColor = true;
            btn_LoadRows.Click += btn_LoadRows_Click;
            // 
            // FrmMateriaPrima
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 787);
            Controls.Add(btn_LoadRows);
            Controls.Add(btn_template);
            Controls.Add(label16);
            Controls.Add(rad_DocumentProcess);
            Controls.Add(txt_embarque);
            Controls.Add(rad_OrdenAbierta);
            Controls.Add(txt_person_id);
            Controls.Add(GridItems);
            Controls.Add(btn_AppMovil);
            Controls.Add(chk_anulado);
            Controls.Add(panel1);
            Controls.Add(btn_OrdenBuscar);
            Controls.Add(txt_fecha_produccion);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txt_lote);
            Controls.Add(label10);
            Controls.Add(btn_deleteRows);
            Controls.Add(btn_addRows);
            Controls.Add(txt_total_cantidad);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txt_notas);
            Controls.Add(txt_guia);
            Controls.Add(label7);
            Controls.Add(btn_RecepBuscar);
            Controls.Add(txt_person_name);
            Controls.Add(label6);
            Controls.Add(txt_OrdenCompra);
            Controls.Add(label5);
            Controls.Add(btn_TransportBuscar);
            Controls.Add(txt_transport_name);
            Controls.Add(txt_transport_id);
            Controls.Add(label4);
            Controls.Add(btn_ProvBuscar);
            Controls.Add(txt_nombre_prov);
            Controls.Add(txt_prov_Id);
            Controls.Add(label3);
            Controls.Add(txt_fecha_recepcion);
            Controls.Add(label2);
            Controls.Add(txt_numeroOrden);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Font = new Font("Noto Sans", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMateriaPrima";
            Text = "RECEPCION MATERIA PRIMA";
            Load += FrmMateriaPrima_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)GridItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btn_primero;
        private ToolStripButton btn_anterior;
        private ToolStripButton btn_siguiente;
        private ToolStripButton btn_save;
        private Label label1;
        private TextBox txt_numeroOrden;
        private Label label2;
        private DateTimePicker txt_fecha_recepcion;
        private TextBox txt_prov_Id;
        private Label label3;
        private TextBox txt_nombre_prov;
        private Button btn_ProvBuscar;
        private TextBox txt_transport_name;
        private TextBox txt_transport_id;
        private Label label4;
        private Button btn_TransportBuscar;
        private TextBox txt_OrdenCompra;
        private Label label5;
        private TextBox txt_person_name;
        private Label label6;
        private Button btn_RecepBuscar;
        private TextBox txt_guia;
        private Label label7;
        private RadioButton rad_DocumentProcess;
        private RadioButton rad_OrdenAbierta;
        private RichTextBox txt_notas;
        private Label label8;
        private TextBox txt_total_cantidad;
        private Label label9;
        private Button btn_addRows;
        private Button btn_deleteRows;
        private TextBox txt_lote;
        private Label label10;
        private Label label11;
        private DateTimePicker txt_fecha_produccion;
        private Label label12;
        private Button btn_OrdenBuscar;
        private Panel panel1;
        private PictureBox pictureBox6;
        private Label label13;
        private Label label_counter_rows;
        private CheckBox chk_anulado;
        private Button btn_AppMovil;
        private ToolStripButton btn_ultimo;
        private ToolStripButton btn_create;
        private ToolStripButton btn_cancel;
        private DataGridView GridItems;
        private TextBox txt_person_id;
        private TextBox txt_embarque;
        private Label label16;
        private Button btn_template;
        private Button btn_LoadRows;
        private ToolStripButton btn_CloseDoc;
        private ToolStripButton toolStripButton3;
        private ToolStripButton btn_ExportDoc;
        private ToolStripButton btn_AnularDoc;
        private ToolStripButton btn_SearchDoc;
        private ToolStripButton btn_printDoc;
    }
}