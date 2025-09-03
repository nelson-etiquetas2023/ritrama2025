namespace Ritrama2025
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            panel1 = new Panel();
            OPC_MENU_LABELS = new Button();
            panel_foto = new Panel();
            lbl_user_name = new Label();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            bot_products = new Button();
            bot_recepciones = new Button();
            bot_inventario = new Button();
            bot_despacho = new Button();
            bot_ordencorte = new Button();
            splitContainer1 = new SplitContainer();
            panel1.SuspendLayout();
            panel_foto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(OPC_MENU_LABELS);
            panel1.Controls.Add(panel_foto);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(bot_products);
            panel1.Controls.Add(bot_recepciones);
            panel1.Controls.Add(bot_inventario);
            panel1.Controls.Add(bot_despacho);
            panel1.Controls.Add(bot_ordencorte);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(221, 924);
            panel1.TabIndex = 0;
            // 
            // OPC_MENU_LABELS
            // 
            OPC_MENU_LABELS.Dock = DockStyle.Top;
            OPC_MENU_LABELS.FlatAppearance.BorderSize = 0;
            OPC_MENU_LABELS.FlatStyle = FlatStyle.Flat;
            OPC_MENU_LABELS.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OPC_MENU_LABELS.Image = (Image)resources.GetObject("OPC_MENU_LABELS.Image");
            OPC_MENU_LABELS.Location = new Point(0, 630);
            OPC_MENU_LABELS.Name = "OPC_MENU_LABELS";
            OPC_MENU_LABELS.Size = new Size(221, 70);
            OPC_MENU_LABELS.TabIndex = 12;
            OPC_MENU_LABELS.Text = "Etiquetas";
            OPC_MENU_LABELS.TextImageRelation = TextImageRelation.ImageBeforeText;
            OPC_MENU_LABELS.UseVisualStyleBackColor = true;
            OPC_MENU_LABELS.Click += OPC_MENU_LABELS_Click;
            // 
            // panel_foto
            // 
            panel_foto.BorderStyle = BorderStyle.FixedSingle;
            panel_foto.Controls.Add(lbl_user_name);
            panel_foto.Controls.Add(pictureBox1);
            panel_foto.Dock = DockStyle.Bottom;
            panel_foto.Location = new Point(0, 720);
            panel_foto.Name = "panel_foto";
            panel_foto.Size = new Size(221, 204);
            panel_foto.TabIndex = 10;
            // 
            // lbl_user_name
            // 
            lbl_user_name.Dock = DockStyle.Top;
            lbl_user_name.Font = new Font("Noto Sans", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_user_name.Location = new Point(0, 0);
            lbl_user_name.Name = "lbl_user_name";
            lbl_user_name.Size = new Size(219, 18);
            lbl_user_name.TabIndex = 11;
            lbl_user_name.Text = "Usuario : Nelson Pino";
            lbl_user_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 202);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(0, 560);
            button4.Name = "button4";
            button4.Size = new Size(221, 70);
            button4.TabIndex = 9;
            button4.Text = "Reportes";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(0, 490);
            button3.Name = "button3";
            button3.Size = new Size(221, 70);
            button3.TabIndex = 8;
            button3.Text = "Proveedores";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(0, 420);
            button2.Name = "button2";
            button2.Size = new Size(221, 70);
            button2.TabIndex = 7;
            button2.Text = "Usuarios";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(0, 350);
            button1.Name = "button1";
            button1.Size = new Size(221, 70);
            button1.TabIndex = 6;
            button1.Text = "Clientes";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            // 
            // bot_products
            // 
            bot_products.Dock = DockStyle.Top;
            bot_products.FlatAppearance.BorderSize = 0;
            bot_products.FlatStyle = FlatStyle.Flat;
            bot_products.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bot_products.Image = (Image)resources.GetObject("bot_products.Image");
            bot_products.Location = new Point(0, 280);
            bot_products.Name = "bot_products";
            bot_products.Size = new Size(221, 70);
            bot_products.TabIndex = 5;
            bot_products.Text = "Productos";
            bot_products.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_products.UseVisualStyleBackColor = true;
            bot_products.Click += bot_products_Click;
            // 
            // bot_recepciones
            // 
            bot_recepciones.Dock = DockStyle.Top;
            bot_recepciones.FlatAppearance.BorderSize = 0;
            bot_recepciones.FlatStyle = FlatStyle.Flat;
            bot_recepciones.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bot_recepciones.Image = Properties.Resources.add_to_clipboard_48px;
            bot_recepciones.Location = new Point(0, 210);
            bot_recepciones.Name = "bot_recepciones";
            bot_recepciones.Size = new Size(221, 70);
            bot_recepciones.TabIndex = 4;
            bot_recepciones.Text = "Recepciones";
            bot_recepciones.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_recepciones.UseVisualStyleBackColor = true;
            bot_recepciones.Click += Bot_recepciones_Click;
            // 
            // bot_inventario
            // 
            bot_inventario.Dock = DockStyle.Top;
            bot_inventario.FlatAppearance.BorderSize = 0;
            bot_inventario.FlatStyle = FlatStyle.Flat;
            bot_inventario.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bot_inventario.Image = Properties.Resources.procurement_48px;
            bot_inventario.Location = new Point(0, 140);
            bot_inventario.Name = "bot_inventario";
            bot_inventario.Size = new Size(221, 70);
            bot_inventario.TabIndex = 3;
            bot_inventario.Text = "Inventario";
            bot_inventario.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_inventario.UseVisualStyleBackColor = true;
            bot_inventario.Click += bot_inventario_Click;
            // 
            // bot_despacho
            // 
            bot_despacho.Dock = DockStyle.Top;
            bot_despacho.FlatAppearance.BorderSize = 0;
            bot_despacho.FlatStyle = FlatStyle.Flat;
            bot_despacho.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bot_despacho.Image = Properties.Resources.product_48px;
            bot_despacho.Location = new Point(0, 70);
            bot_despacho.Name = "bot_despacho";
            bot_despacho.Size = new Size(221, 70);
            bot_despacho.TabIndex = 2;
            bot_despacho.Text = "Despacho";
            bot_despacho.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_despacho.UseVisualStyleBackColor = true;
            bot_despacho.Click += Bot_despacho_Click;
            // 
            // bot_ordencorte
            // 
            bot_ordencorte.Dock = DockStyle.Top;
            bot_ordencorte.FlatAppearance.BorderSize = 0;
            bot_ordencorte.FlatStyle = FlatStyle.Flat;
            bot_ordencorte.Font = new Font("Segoe UI", 12.2264156F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bot_ordencorte.Image = (Image)resources.GetObject("bot_ordencorte.Image");
            bot_ordencorte.Location = new Point(0, 0);
            bot_ordencorte.Name = "bot_ordencorte";
            bot_ordencorte.Size = new Size(221, 70);
            bot_ordencorte.TabIndex = 1;
            bot_ordencorte.Text = "Orden Corte";
            bot_ordencorte.TextImageRelation = TextImageRelation.ImageBeforeText;
            bot_ordencorte.UseVisualStyleBackColor = true;
            bot_ordencorte.Click += Bot_ordencorte_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(221, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDark;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ScrollBar;
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1058, 924);
            splitContainer1.SplitterDistance = 854;
            splitContainer1.TabIndex = 2;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1279, 924);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 8.830189F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SISTEMA DE PRODUCCION EMPRESA FEDRIGONI VERSION 2025 [CREADO POR ETIQUETAS.COM.DO - SANTO DOMINGO REPUBLICA DOMINICANA - SOPORTE TECNICO: 829-8805472]";
            WindowState = FormWindowState.Maximized;
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel_foto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bot_ordencorte;
        private Button bot_products;
        private Button bot_recepciones;
        private Button bot_inventario;
        private Button bot_despacho;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private Panel panel_foto;
        private PictureBox pictureBox1;
        private Label lbl_user_name;
        private Button OPC_MENU_LABELS;
        private SplitContainer splitContainer1;
    }
}