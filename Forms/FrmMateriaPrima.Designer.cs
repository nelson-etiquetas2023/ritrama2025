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
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
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
            txt_recepcionista = new TextBox();
            label6 = new Label();
            btn_RecepBuscar = new Button();
            txt_guia = new TextBox();
            label7 = new Label();
            groupBox1 = new GroupBox();
            rad_DocumentProcess = new RadioButton();
            rad_OrdenAbierta = new RadioButton();
            GridItems = new DataGridView();
            txt_notas = new RichTextBox();
            label8 = new Label();
            txt_total_cantidad = new TextBox();
            label9 = new Label();
            btn_addRows = new Button();
            btn_deleteRows = new Button();
            txt_lote = new TextBox();
            label10 = new Label();
            txt_embarque = new TextBox();
            label11 = new Label();
            txt_fecha_produccion = new DateTimePicker();
            label12 = new Label();
            btn_OrdenBuscar = new Button();
            panel1 = new Panel();
            label14 = new Label();
            pictureBox6 = new PictureBox();
            label13 = new Label();
            chk_ = new CheckBox();
            txt_data_document = new TextBox();
            label15 = new Label();
            btn_AppMovil = new Button();
            toolStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridItems).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1157, 25);
            toolStrip1.TabIndex = 0;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 1;
            label1.Text = "Numero Orden :";
            // 
            // txt_numeroOrden
            // 
            txt_numeroOrden.Location = new Point(12, 123);
            txt_numeroOrden.Name = "txt_numeroOrden";
            txt_numeroOrden.ReadOnly = true;
            txt_numeroOrden.Size = new Size(160, 23);
            txt_numeroOrden.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 152);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 3;
            label2.Text = "Fecha Recepcion :";
            // 
            // txt_fecha_recepcion
            // 
            txt_fecha_recepcion.Enabled = false;
            txt_fecha_recepcion.Location = new Point(12, 170);
            txt_fecha_recepcion.Name = "txt_fecha_recepcion";
            txt_fecha_recepcion.Size = new Size(217, 23);
            txt_fecha_recepcion.TabIndex = 4;
            // 
            // txt_prov_Id
            // 
            txt_prov_Id.Location = new Point(459, 123);
            txt_prov_Id.Name = "txt_prov_Id";
            txt_prov_Id.ReadOnly = true;
            txt_prov_Id.Size = new Size(64, 23);
            txt_prov_Id.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(459, 105);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 5;
            label3.Text = "Datos del Proveedor :";
            // 
            // txt_nombre_prov
            // 
            txt_nombre_prov.Location = new Point(529, 123);
            txt_nombre_prov.Name = "txt_nombre_prov";
            txt_nombre_prov.ReadOnly = true;
            txt_nombre_prov.Size = new Size(318, 23);
            txt_nombre_prov.TabIndex = 7;
            // 
            // btn_ProvBuscar
            // 
            btn_ProvBuscar.Location = new Point(853, 123);
            btn_ProvBuscar.Name = "btn_ProvBuscar";
            btn_ProvBuscar.Size = new Size(46, 23);
            btn_ProvBuscar.TabIndex = 8;
            btn_ProvBuscar.Text = "...";
            btn_ProvBuscar.UseVisualStyleBackColor = true;
            // 
            // txt_transport_name
            // 
            txt_transport_name.Location = new Point(529, 172);
            txt_transport_name.Name = "txt_transport_name";
            txt_transport_name.ReadOnly = true;
            txt_transport_name.Size = new Size(318, 23);
            txt_transport_name.TabIndex = 11;
            // 
            // txt_transport_id
            // 
            txt_transport_id.Location = new Point(459, 173);
            txt_transport_id.Name = "txt_transport_id";
            txt_transport_id.ReadOnly = true;
            txt_transport_id.Size = new Size(64, 23);
            txt_transport_id.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(459, 154);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 9;
            label4.Text = "Transportista :";
            // 
            // btn_TransportBuscar
            // 
            btn_TransportBuscar.Location = new Point(853, 172);
            btn_TransportBuscar.Name = "btn_TransportBuscar";
            btn_TransportBuscar.Size = new Size(46, 23);
            btn_TransportBuscar.TabIndex = 12;
            btn_TransportBuscar.Text = "...";
            btn_TransportBuscar.UseVisualStyleBackColor = true;
            // 
            // txt_OrdenCompra
            // 
            txt_OrdenCompra.Location = new Point(235, 123);
            txt_OrdenCompra.Name = "txt_OrdenCompra";
            txt_OrdenCompra.ReadOnly = true;
            txt_OrdenCompra.Size = new Size(217, 23);
            txt_OrdenCompra.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(235, 105);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 13;
            label5.Text = "Orden de Compra :";
            // 
            // txt_recepcionista
            // 
            txt_recepcionista.Location = new Point(397, 232);
            txt_recepcionista.Name = "txt_recepcionista";
            txt_recepcionista.ReadOnly = true;
            txt_recepcionista.Size = new Size(168, 23);
            txt_recepcionista.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(397, 214);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 15;
            label6.Text = "Recepcionista :";
            // 
            // btn_RecepBuscar
            // 
            btn_RecepBuscar.Location = new Point(567, 233);
            btn_RecepBuscar.Name = "btn_RecepBuscar";
            btn_RecepBuscar.Size = new Size(46, 23);
            btn_RecepBuscar.TabIndex = 17;
            btn_RecepBuscar.Text = "...";
            btn_RecepBuscar.UseVisualStyleBackColor = true;
            // 
            // txt_guia
            // 
            txt_guia.Location = new Point(12, 232);
            txt_guia.Name = "txt_guia";
            txt_guia.ReadOnly = true;
            txt_guia.Size = new Size(123, 23);
            txt_guia.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 214);
            label7.Name = "label7";
            label7.Size = new Size(121, 15);
            label7.TabIndex = 18;
            label7.Text = "Guia de Importacion :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rad_DocumentProcess);
            groupBox1.Controls.Add(rad_OrdenAbierta);
            groupBox1.Location = new Point(740, 201);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(159, 68);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estado del Documento";
            // 
            // rad_DocumentProcess
            // 
            rad_DocumentProcess.AutoSize = true;
            rad_DocumentProcess.Location = new Point(8, 38);
            rad_DocumentProcess.Name = "rad_DocumentProcess";
            rad_DocumentProcess.Size = new Size(146, 19);
            rad_DocumentProcess.TabIndex = 1;
            rad_DocumentProcess.TabStop = true;
            rad_DocumentProcess.Text = "Documento Procesado";
            rad_DocumentProcess.UseVisualStyleBackColor = true;
            // 
            // rad_OrdenAbierta
            // 
            rad_OrdenAbierta.AutoSize = true;
            rad_OrdenAbierta.Location = new Point(8, 22);
            rad_OrdenAbierta.Name = "rad_OrdenAbierta";
            rad_OrdenAbierta.Size = new Size(99, 19);
            rad_OrdenAbierta.TabIndex = 0;
            rad_OrdenAbierta.TabStop = true;
            rad_OrdenAbierta.Text = "Orden Abierta";
            rad_OrdenAbierta.UseVisualStyleBackColor = true;
            // 
            // GridItems
            // 
            GridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridItems.Location = new Point(12, 275);
            GridItems.Name = "GridItems";
            GridItems.Size = new Size(1033, 216);
            GridItems.TabIndex = 21;
            // 
            // txt_notas
            // 
            txt_notas.Location = new Point(12, 522);
            txt_notas.Name = "txt_notas";
            txt_notas.ReadOnly = true;
            txt_notas.Size = new Size(440, 122);
            txt_notas.TabIndex = 22;
            txt_notas.Text = "";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 504);
            label8.Name = "label8";
            label8.Size = new Size(123, 15);
            label8.TabIndex = 23;
            label8.Text = "Notas del Documento";
            // 
            // txt_total_cantidad
            // 
            txt_total_cantidad.Location = new Point(899, 504);
            txt_total_cantidad.Name = "txt_total_cantidad";
            txt_total_cantidad.ReadOnly = true;
            txt_total_cantidad.Size = new Size(146, 23);
            txt_total_cantidad.TabIndex = 25;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(801, 507);
            label9.Name = "label9";
            label9.Size = new Size(92, 15);
            label9.TabIndex = 24;
            label9.Text = "Total Cantidad : ";
            // 
            // btn_addRows
            // 
            btn_addRows.Location = new Point(1051, 275);
            btn_addRows.Name = "btn_addRows";
            btn_addRows.Size = new Size(94, 23);
            btn_addRows.TabIndex = 26;
            btn_addRows.Text = "Agregar";
            btn_addRows.UseVisualStyleBackColor = true;
            // 
            // btn_deleteRows
            // 
            btn_deleteRows.Location = new Point(1051, 304);
            btn_deleteRows.Name = "btn_deleteRows";
            btn_deleteRows.Size = new Size(94, 23);
            btn_deleteRows.TabIndex = 27;
            btn_deleteRows.Text = "Borrar";
            btn_deleteRows.UseVisualStyleBackColor = true;
            // 
            // txt_lote
            // 
            txt_lote.Location = new Point(141, 232);
            txt_lote.Name = "txt_lote";
            txt_lote.ReadOnly = true;
            txt_lote.Size = new Size(123, 23);
            txt_lote.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(141, 214);
            label10.Name = "label10";
            label10.Size = new Size(83, 15);
            label10.TabIndex = 28;
            label10.Text = "Numero Lote :";
            // 
            // txt_embarque
            // 
            txt_embarque.Location = new Point(268, 232);
            txt_embarque.Name = "txt_embarque";
            txt_embarque.ReadOnly = true;
            txt_embarque.Size = new Size(123, 23);
            txt_embarque.TabIndex = 31;
            txt_embarque.UseWaitCursor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(268, 214);
            label11.Name = "label11";
            label11.Size = new Size(114, 15);
            label11.TabIndex = 30;
            label11.Text = "Numero Embarque :";
            label11.UseWaitCursor = true;
            // 
            // txt_fecha_produccion
            // 
            txt_fecha_produccion.Enabled = false;
            txt_fecha_produccion.Location = new Point(235, 173);
            txt_fecha_produccion.Name = "txt_fecha_produccion";
            txt_fecha_produccion.Size = new Size(217, 23);
            txt_fecha_produccion.TabIndex = 33;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(235, 155);
            label12.Name = "label12";
            label12.Size = new Size(108, 15);
            label12.TabIndex = 32;
            label12.Text = "Fecha Produccion :";
            // 
            // btn_OrdenBuscar
            // 
            btn_OrdenBuscar.Location = new Point(178, 122);
            btn_OrdenBuscar.Name = "btn_OrdenBuscar";
            btn_OrdenBuscar.Size = new Size(46, 23);
            btn_OrdenBuscar.TabIndex = 34;
            btn_OrdenBuscar.Text = "...";
            btn_OrdenBuscar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(label14);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(label13);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(1157, 68);
            panel1.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(984, 23);
            label14.Name = "label14";
            label14.Size = new Size(161, 25);
            label14.TabIndex = 97;
            label14.Text = "Registros : 1/100";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(285, 8);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(57, 57);
            pictureBox6.TabIndex = 97;
            pictureBox6.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ControlLightLight;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(348, 16);
            label13.Name = "label13";
            label13.Size = new Size(383, 32);
            label13.TabIndex = 0;
            label13.Text = "RECEPCION DE MATERIA PRIMA";
            // 
            // chk_
            // 
            chk_.AutoSize = true;
            chk_.Location = new Point(908, 625);
            chk_.Name = "chk_";
            chk_.Size = new Size(137, 19);
            chk_.TabIndex = 37;
            chk_.Text = "Documento Anulado";
            chk_.UseVisualStyleBackColor = true;
            // 
            // txt_data_document
            // 
            txt_data_document.Location = new Point(899, 533);
            txt_data_document.Name = "txt_data_document";
            txt_data_document.ReadOnly = true;
            txt_data_document.Size = new Size(146, 23);
            txt_data_document.TabIndex = 39;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(752, 536);
            label15.Name = "label15";
            label15.Size = new Size(141, 15);
            label15.TabIndex = 38;
            label15.Text = "Datos cierre Documento :";
            // 
            // btn_AppMovil
            // 
            btn_AppMovil.Location = new Point(1051, 105);
            btn_AppMovil.Name = "btn_AppMovil";
            btn_AppMovil.Size = new Size(94, 23);
            btn_AppMovil.TabIndex = 40;
            btn_AppMovil.Text = "App Movil";
            btn_AppMovil.UseVisualStyleBackColor = true;
            // 
            // FrmMateriaPrima
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 656);
            Controls.Add(btn_AppMovil);
            Controls.Add(txt_data_document);
            Controls.Add(label15);
            Controls.Add(chk_);
            Controls.Add(panel1);
            Controls.Add(btn_OrdenBuscar);
            Controls.Add(txt_fecha_produccion);
            Controls.Add(label12);
            Controls.Add(txt_embarque);
            Controls.Add(label11);
            Controls.Add(txt_lote);
            Controls.Add(label10);
            Controls.Add(btn_deleteRows);
            Controls.Add(btn_addRows);
            Controls.Add(txt_total_cantidad);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(txt_notas);
            Controls.Add(GridItems);
            Controls.Add(groupBox1);
            Controls.Add(txt_guia);
            Controls.Add(label7);
            Controls.Add(btn_RecepBuscar);
            Controls.Add(txt_recepcionista);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMateriaPrima";
            Text = "RECEPCION MATERIA PRIMA";
            Load += FrmMateriaPrima_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GridItems).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
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
        private TextBox txt_recepcionista;
        private Label label6;
        private Button btn_RecepBuscar;
        private TextBox txt_guia;
        private Label label7;
        private GroupBox groupBox1;
        private RadioButton rad_DocumentProcess;
        private RadioButton rad_OrdenAbierta;
        private DataGridView GridItems;
        private RichTextBox txt_notas;
        private Label label8;
        private TextBox txt_total_cantidad;
        private Label label9;
        private Button btn_addRows;
        private Button btn_deleteRows;
        private TextBox txt_lote;
        private Label label10;
        private TextBox txt_embarque;
        private Label label11;
        private DateTimePicker txt_fecha_produccion;
        private Label label12;
        private Button btn_OrdenBuscar;
        private Panel panel1;
        private PictureBox pictureBox6;
        private Label label13;
        private Label label14;
        private CheckBox chk_;
        private TextBox txt_data_document;
        private Label label15;
        private Button btn_AppMovil;
    }
}