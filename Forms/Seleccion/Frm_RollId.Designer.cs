namespace Ritrama2025.Forms.Seleccion
{
    partial class Frm_RollId
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RollId));
            txt_buscar = new TextBox();
            btn_buscar = new Button();
            GridItems = new DataGridView();
            label_registros = new Label();
            chk_rebobinado = new CheckBox();
            btn_actualizar = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            groupBox1 = new GroupBox();
            rad_uniquecode = new RadioButton();
            rad_productname = new RadioButton();
            rad_productid = new RadioButton();
            rad_rolldid = new RadioButton();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)GridItems).BeginInit();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txt_buscar
            // 
            txt_buscar.Location = new Point(12, 114);
            txt_buscar.Name = "txt_buscar";
            txt_buscar.Size = new Size(473, 23);
            txt_buscar.TabIndex = 0;
            // 
            // btn_buscar
            // 
            btn_buscar.Image = Properties.Resources.search_16px;
            btn_buscar.Location = new Point(490, 114);
            btn_buscar.Name = "btn_buscar";
            btn_buscar.Size = new Size(92, 23);
            btn_buscar.TabIndex = 1;
            btn_buscar.Text = "Buscar";
            btn_buscar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_buscar.UseVisualStyleBackColor = true;
            // 
            // GridItems
            // 
            GridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridItems.Location = new Point(12, 143);
            GridItems.Name = "GridItems";
            GridItems.Size = new Size(570, 217);
            GridItems.TabIndex = 2;
            // 
            // label_registros
            // 
            label_registros.AutoSize = true;
            label_registros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_registros.Location = new Point(12, 363);
            label_registros.Name = "label_registros";
            label_registros.Size = new Size(147, 15);
            label_registros.TabIndex = 3;
            label_registros.Text = "30 Registros Encontrados";
            // 
            // chk_rebobinado
            // 
            chk_rebobinado.AutoSize = true;
            chk_rebobinado.Location = new Point(12, 431);
            chk_rebobinado.Name = "chk_rebobinado";
            chk_rebobinado.Size = new Size(142, 19);
            chk_rebobinado.TabIndex = 4;
            chk_rebobinado.Text = "Orden de Rebobinado";
            chk_rebobinado.UseVisualStyleBackColor = true;
            // 
            // btn_actualizar
            // 
            btn_actualizar.Image = Properties.Resources.update_doc;
            btn_actualizar.Location = new Point(12, 456);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(142, 39);
            btn_actualizar.TabIndex = 5;
            btn_actualizar.Text = "Actualizar";
            btn_actualizar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_actualizar.UseVisualStyleBackColor = true;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rad_uniquecode);
            groupBox1.Controls.Add(rad_productname);
            groupBox1.Controls.Add(rad_productid);
            groupBox1.Controls.Add(rad_rolldid);
            groupBox1.Location = new Point(382, 366);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 129);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros de Busqueda";
            // 
            // rad_uniquecode
            // 
            rad_uniquecode.AutoSize = true;
            rad_uniquecode.Location = new Point(42, 81);
            rad_uniquecode.Name = "rad_uniquecode";
            rad_uniquecode.Size = new Size(94, 19);
            rad_uniquecode.TabIndex = 3;
            rad_uniquecode.TabStop = true;
            rad_uniquecode.Text = "Unique Code";
            rad_uniquecode.UseVisualStyleBackColor = true;
            // 
            // rad_productname
            // 
            rad_productname.AutoSize = true;
            rad_productname.Location = new Point(42, 65);
            rad_productname.Name = "rad_productname";
            rad_productname.Size = new Size(105, 19);
            rad_productname.TabIndex = 2;
            rad_productname.TabStop = true;
            rad_productname.Text = "Product Name.";
            rad_productname.UseVisualStyleBackColor = true;
            // 
            // rad_productid
            // 
            rad_productid.AutoSize = true;
            rad_productid.Location = new Point(42, 49);
            rad_productid.Name = "rad_productid";
            rad_productid.Size = new Size(83, 19);
            rad_productid.TabIndex = 1;
            rad_productid.TabStop = true;
            rad_productid.Text = "Product Id.";
            rad_productid.UseVisualStyleBackColor = true;
            // 
            // rad_rolldid
            // 
            rad_rolldid.AutoSize = true;
            rad_rolldid.Location = new Point(42, 33);
            rad_rolldid.Name = "rad_rolldid";
            rad_rolldid.Size = new Size(61, 19);
            rad_rolldid.TabIndex = 0;
            rad_rolldid.TabStop = true;
            rad_rolldid.Text = "Roll Id.";
            rad_rolldid.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(570, 100);
            panel1.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.roll_id;
            pictureBox1.Location = new Point(125, 19);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(182, 34);
            label2.Name = "label2";
            label2.Size = new Size(187, 25);
            label2.TabIndex = 0;
            label2.Text = "Selección de Roll-Id";
            // 
            // Frm_RollId
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 514);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(btn_actualizar);
            Controls.Add(chk_rebobinado);
            Controls.Add(label_registros);
            Controls.Add(GridItems);
            Controls.Add(btn_buscar);
            Controls.Add(txt_buscar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Frm_RollId";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccion de Roll-Id";
            ((System.ComponentModel.ISupportInitialize)GridItems).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt_buscar;
        private Button btn_buscar;
        private DataGridView GridItems;
        private Label label_registros;
        private CheckBox chk_rebobinado;
        private Button btn_actualizar;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private GroupBox groupBox1;
        private RadioButton rad_rolldid;
        private RadioButton rad_uniquecode;
        private RadioButton rad_productname;
        private RadioButton rad_productid;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
    }
}