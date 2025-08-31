namespace SatinalmaMalKayitSistemi.Forms
{
    partial class RaporlamaYonetim
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
            cmbRaporAdi = new ComboBox();
            btnSave = new Button();
            pnlBackground = new Panel();
            pnlBackground.SuspendLayout();
            SuspendLayout();
            // 
            // cmbRaporAdi
            // 
            cmbRaporAdi.Anchor = AnchorStyles.None;
            cmbRaporAdi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporAdi.FormattingEnabled = true;
            cmbRaporAdi.IntegralHeight = false;
            cmbRaporAdi.Items.AddRange(new object[] { "Tedarikçi Listesi", "Stok Malzeme Listesi", "Stoksuz Malzeme Listesi", "Malzeme Talepleri", "Tedarikçi Teklifleri", "Zimmet Listesi", "Hurda Listesi" });
            cmbRaporAdi.Location = new Point(6, 38);
            cmbRaporAdi.Name = "cmbRaporAdi";
            cmbRaporAdi.Size = new Size(177, 23);
            cmbRaporAdi.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(189, 38);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(183, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "KAYDET";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // pnlBackground
            // 
            pnlBackground.Anchor = AnchorStyles.None;
            pnlBackground.BackColor = Color.White;
            pnlBackground.BorderStyle = BorderStyle.Fixed3D;
            pnlBackground.Controls.Add(btnSave);
            pnlBackground.Controls.Add(cmbRaporAdi);
            pnlBackground.Location = new Point(246, 12);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(382, 100);
            pnlBackground.TabIndex = 2;
            // 
            // RaporlamaYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(pnlBackground);
            Name = "RaporlamaYonetim";
            Text = "Raporlama Yönetim Sistemi";
            pnlBackground.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbRaporAdi;
        private Button btnSave;
        private Panel pnlBackground;
    }
}