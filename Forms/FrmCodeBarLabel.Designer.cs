namespace Ritrama2025.Forms
{
    partial class FrmCodeBarLabel
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
            richTextBox1 = new RichTextBox();
            btn_buscar_printer = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btn_send_printer_usb = new Button();
            label1 = new Label();
            numero_copias = new NumericUpDown();
            rad_label1 = new RadioButton();
            rad_label2 = new RadioButton();
            rad_label3 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)numero_copias).BeginInit();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(302, 96);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // btn_buscar_printer
            // 
            btn_buscar_printer.Location = new Point(12, 172);
            btn_buscar_printer.Name = "btn_buscar_printer";
            btn_buscar_printer.Size = new Size(302, 23);
            btn_buscar_printer.TabIndex = 1;
            btn_buscar_printer.Text = "Buscar Printer Instaladas local";
            btn_buscar_printer.UseVisualStyleBackColor = true;
            btn_buscar_printer.Click += Btn_buscar_printer_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 114);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(302, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 143);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(302, 23);
            textBox2.TabIndex = 3;
            // 
            // btn_send_printer_usb
            // 
            btn_send_printer_usb.Location = new Point(12, 201);
            btn_send_printer_usb.Name = "btn_send_printer_usb";
            btn_send_printer_usb.Size = new Size(302, 23);
            btn_send_printer_usb.TabIndex = 4;
            btn_send_printer_usb.Text = "Enviar ZPL impresora USB local";
            btn_send_printer_usb.UseVisualStyleBackColor = true;
            btn_send_printer_usb.Click += Button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 243);
            label1.Name = "label1";
            label1.Size = new Size(112, 15);
            label1.TabIndex = 5;
            label1.Text = "Numero de Copias :";
            // 
            // numero_copias
            // 
            numero_copias.Location = new Point(130, 241);
            numero_copias.Name = "numero_copias";
            numero_copias.Size = new Size(120, 23);
            numero_copias.TabIndex = 6;
            numero_copias.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // rad_label1
            // 
            rad_label1.AutoSize = true;
            rad_label1.Location = new Point(12, 320);
            rad_label1.Name = "rad_label1";
            rad_label1.Size = new Size(79, 19);
            rad_label1.TabIndex = 7;
            rad_label1.TabStop = true;
            rad_label1.Text = "Formato 1";
            rad_label1.UseVisualStyleBackColor = true;
            // 
            // rad_label2
            // 
            rad_label2.AutoSize = true;
            rad_label2.Location = new Point(12, 345);
            rad_label2.Name = "rad_label2";
            rad_label2.Size = new Size(79, 19);
            rad_label2.TabIndex = 8;
            rad_label2.TabStop = true;
            rad_label2.Text = "Formato 2";
            rad_label2.UseVisualStyleBackColor = true;
            // 
            // rad_label3
            // 
            rad_label3.AutoSize = true;
            rad_label3.Location = new Point(12, 370);
            rad_label3.Name = "rad_label3";
            rad_label3.Size = new Size(79, 19);
            rad_label3.TabIndex = 9;
            rad_label3.TabStop = true;
            rad_label3.Text = "Formato 3";
            rad_label3.UseVisualStyleBackColor = true;
            // 
            // FrmCodeBarLabel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rad_label3);
            Controls.Add(rad_label2);
            Controls.Add(rad_label1);
            Controls.Add(numero_copias);
            Controls.Add(label1);
            Controls.Add(btn_send_printer_usb);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btn_buscar_printer);
            Controls.Add(richTextBox1);
            Name = "FrmCodeBarLabel";
            Text = "Configuracion de Etiquetas de Codigo de Barras";
            Load += FrmCodeBarLabel_Load;
            ((System.ComponentModel.ISupportInitialize)numero_copias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btn_buscar_printer;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_send_printer_usb;
        private Label label1;
        private NumericUpDown numero_copias;
        private RadioButton rad_label1;
        private RadioButton rad_label2;
        private RadioButton rad_label3;
    }
}