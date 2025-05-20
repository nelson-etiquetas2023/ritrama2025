﻿using System.ComponentModel;


namespace Ritrama2025.Forms.Otros
{
    public partial class Frm_descriptionPalet : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ContentTextDescription { get; set; } = string.Empty;
        public Frm_descriptionPalet()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_ContentText.Text))
            {
                this.ContentTextDescription = txt_ContentText.Text;
            }

            this.Close();
        }

        private void Frm_descriptionPalet_Load(object sender, EventArgs e)
        {
            txt_ContentText.Text = ContentTextDescription;
        }
    }
}
