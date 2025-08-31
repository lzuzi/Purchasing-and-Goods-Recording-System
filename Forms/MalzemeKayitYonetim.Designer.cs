namespace SatinalmaMalKayitSistemi.Forms
{
    partial class MalzemeKayitYonetim
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
            btnTextClear = new Button();
            dgvMalzemeKayit = new DataGridView();
            lblMalzemeSonKullanimTarihi = new Label();
            lblMalzemeAdi = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblMalzemeSatinAlimTarihi = new Label();
            cmbMalzemeAdi = new ComboBox();
            txtMalzemeGirisStokMiktari = new TextBox();
            lblMalzemeGirisStokMiktari = new Label();
            lblMalzemeTedarikciID = new Label();
            cmbMalzemeTedarikciID = new ComboBox();
            txtMalzemeID = new TextBox();
            lblMalzemeID = new Label();
            txtMalzemeKalanStokMiktari = new TextBox();
            lblMalzemeKalanStokMiktari = new Label();
            dtpMalzemeSatinAlimTarihi = new DateTimePicker();
            dtpMalzemeSonKullanimTarihi = new DateTimePicker();
            cmbTedarikciTeklifID = new ComboBox();
            lblTedarikciTeklifID = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMalzemeKayit).BeginInit();
            SuspendLayout();
            // 
            // btnTextClear
            // 
            btnTextClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTextClear.Location = new Point(607, 133);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 53;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvMalzemeKayit
            // 
            dgvMalzemeKayit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMalzemeKayit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMalzemeKayit.Location = new Point(41, 174);
            dgvMalzemeKayit.Name = "dgvMalzemeKayit";
            dgvMalzemeKayit.Size = new Size(793, 310);
            dgvMalzemeKayit.TabIndex = 45;
            dgvMalzemeKayit.CellClick += dgvMalzemeKayit_CellClick;
            // 
            // lblMalzemeSonKullanimTarihi
            // 
            lblMalzemeSonKullanimTarihi.AutoSize = true;
            lblMalzemeSonKullanimTarihi.Location = new Point(224, 125);
            lblMalzemeSonKullanimTarihi.Name = "lblMalzemeSonKullanimTarihi";
            lblMalzemeSonKullanimTarihi.Size = new Size(159, 15);
            lblMalzemeSonKullanimTarihi.TabIndex = 52;
            lblMalzemeSonKullanimTarihi.Text = "Malzeme Son Kullanım Tarihi";
            // 
            // lblMalzemeAdi
            // 
            lblMalzemeAdi.AutoSize = true;
            lblMalzemeAdi.Location = new Point(41, 73);
            lblMalzemeAdi.Name = "lblMalzemeAdi";
            lblMalzemeAdi.Size = new Size(76, 15);
            lblMalzemeAdi.TabIndex = 51;
            lblMalzemeAdi.Text = "Malzeme Adı";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(625, 104);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 50;
            btnDelete.Text = "Malzemeyi Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(625, 73);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 49;
            btnUpdate.Text = "Malzemeyi Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(625, 42);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 48;
            btnAdd.Text = "Yeni Malzeme Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblMalzemeSatinAlimTarihi
            // 
            lblMalzemeSatinAlimTarihi.AutoSize = true;
            lblMalzemeSatinAlimTarihi.Location = new Point(224, 73);
            lblMalzemeSatinAlimTarihi.Name = "lblMalzemeSatinAlimTarihi";
            lblMalzemeSatinAlimTarihi.Size = new Size(143, 15);
            lblMalzemeSatinAlimTarihi.TabIndex = 55;
            lblMalzemeSatinAlimTarihi.Text = "Malzeme Satın Alım Tarihi";
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(42, 91);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(167, 23);
            cmbMalzemeAdi.TabIndex = 56;
            // 
            // txtMalzemeGirisStokMiktari
            // 
            txtMalzemeGirisStokMiktari.Location = new Point(42, 143);
            txtMalzemeGirisStokMiktari.Name = "txtMalzemeGirisStokMiktari";
            txtMalzemeGirisStokMiktari.Size = new Size(167, 23);
            txtMalzemeGirisStokMiktari.TabIndex = 57;
            // 
            // lblMalzemeGirisStokMiktari
            // 
            lblMalzemeGirisStokMiktari.AutoSize = true;
            lblMalzemeGirisStokMiktari.Location = new Point(42, 125);
            lblMalzemeGirisStokMiktari.Name = "lblMalzemeGirisStokMiktari";
            lblMalzemeGirisStokMiktari.Size = new Size(147, 15);
            lblMalzemeGirisStokMiktari.TabIndex = 58;
            lblMalzemeGirisStokMiktari.Text = "Malzeme Giriş Stok Miktarı";
            // 
            // lblMalzemeTedarikciID
            // 
            lblMalzemeTedarikciID.AutoSize = true;
            lblMalzemeTedarikciID.ForeColor = SystemColors.ControlText;
            lblMalzemeTedarikciID.Location = new Point(411, 20);
            lblMalzemeTedarikciID.Name = "lblMalzemeTedarikciID";
            lblMalzemeTedarikciID.Size = new Size(118, 15);
            lblMalzemeTedarikciID.TabIndex = 59;
            lblMalzemeTedarikciID.Text = "Malzeme Tedarikçi ID";
            // 
            // cmbMalzemeTedarikciID
            // 
            cmbMalzemeTedarikciID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMalzemeTedarikciID.FormattingEnabled = true;
            cmbMalzemeTedarikciID.Location = new Point(407, 38);
            cmbMalzemeTedarikciID.Name = "cmbMalzemeTedarikciID";
            cmbMalzemeTedarikciID.Size = new Size(167, 23);
            cmbMalzemeTedarikciID.TabIndex = 60;
            // 
            // txtMalzemeID
            // 
            txtMalzemeID.Location = new Point(41, 38);
            txtMalzemeID.Name = "txtMalzemeID";
            txtMalzemeID.ReadOnly = true;
            txtMalzemeID.Size = new Size(167, 23);
            txtMalzemeID.TabIndex = 61;
            // 
            // lblMalzemeID
            // 
            lblMalzemeID.AutoSize = true;
            lblMalzemeID.Location = new Point(41, 20);
            lblMalzemeID.Name = "lblMalzemeID";
            lblMalzemeID.Size = new Size(69, 15);
            lblMalzemeID.TabIndex = 62;
            lblMalzemeID.Text = "Malzeme ID";
            // 
            // txtMalzemeKalanStokMiktari
            // 
            txtMalzemeKalanStokMiktari.Location = new Point(224, 38);
            txtMalzemeKalanStokMiktari.Name = "txtMalzemeKalanStokMiktari";
            txtMalzemeKalanStokMiktari.Size = new Size(167, 23);
            txtMalzemeKalanStokMiktari.TabIndex = 63;
            // 
            // lblMalzemeKalanStokMiktari
            // 
            lblMalzemeKalanStokMiktari.AutoSize = true;
            lblMalzemeKalanStokMiktari.Location = new Point(224, 20);
            lblMalzemeKalanStokMiktari.Name = "lblMalzemeKalanStokMiktari";
            lblMalzemeKalanStokMiktari.Size = new Size(153, 15);
            lblMalzemeKalanStokMiktari.TabIndex = 64;
            lblMalzemeKalanStokMiktari.Text = "Malzeme Kalan Stok Miktarı";
            // 
            // dtpMalzemeSatinAlimTarihi
            // 
            dtpMalzemeSatinAlimTarihi.CustomFormat = "dd.MM.yyyy";
            dtpMalzemeSatinAlimTarihi.Format = DateTimePickerFormat.Custom;
            dtpMalzemeSatinAlimTarihi.Location = new Point(224, 91);
            dtpMalzemeSatinAlimTarihi.Name = "dtpMalzemeSatinAlimTarihi";
            dtpMalzemeSatinAlimTarihi.Size = new Size(168, 23);
            dtpMalzemeSatinAlimTarihi.TabIndex = 65;
            // 
            // dtpMalzemeSonKullanimTarihi
            // 
            dtpMalzemeSonKullanimTarihi.CustomFormat = "dd.MM.yyyy";
            dtpMalzemeSonKullanimTarihi.Format = DateTimePickerFormat.Custom;
            dtpMalzemeSonKullanimTarihi.Location = new Point(224, 140);
            dtpMalzemeSonKullanimTarihi.Name = "dtpMalzemeSonKullanimTarihi";
            dtpMalzemeSonKullanimTarihi.Size = new Size(168, 23);
            dtpMalzemeSonKullanimTarihi.TabIndex = 66;
            // 
            // cmbTedarikciTeklifID
            // 
            cmbTedarikciTeklifID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarikciTeklifID.FormattingEnabled = true;
            cmbTedarikciTeklifID.Location = new Point(407, 91);
            cmbTedarikciTeklifID.Name = "cmbTedarikciTeklifID";
            cmbTedarikciTeklifID.Size = new Size(167, 23);
            cmbTedarikciTeklifID.TabIndex = 68;
            // 
            // lblTedarikciTeklifID
            // 
            lblTedarikciTeklifID.AutoSize = true;
            lblTedarikciTeklifID.ForeColor = SystemColors.ControlText;
            lblTedarikciTeklifID.Location = new Point(411, 73);
            lblTedarikciTeklifID.Name = "lblTedarikciTeklifID";
            lblTedarikciTeklifID.Size = new Size(97, 15);
            lblTedarikciTeklifID.TabIndex = 67;
            lblTedarikciTeklifID.Text = "Tedarikçi Teklif ID";
            // 
            // MalzemeKayitYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(cmbTedarikciTeklifID);
            Controls.Add(lblTedarikciTeklifID);
            Controls.Add(dtpMalzemeSonKullanimTarihi);
            Controls.Add(dtpMalzemeSatinAlimTarihi);
            Controls.Add(txtMalzemeKalanStokMiktari);
            Controls.Add(lblMalzemeKalanStokMiktari);
            Controls.Add(lblMalzemeID);
            Controls.Add(cmbMalzemeTedarikciID);
            Controls.Add(lblMalzemeTedarikciID);
            Controls.Add(txtMalzemeGirisStokMiktari);
            Controls.Add(lblMalzemeGirisStokMiktari);
            Controls.Add(lblMalzemeSatinAlimTarihi);
            Controls.Add(dgvMalzemeKayit);
            Controls.Add(lblMalzemeSonKullanimTarihi);
            Controls.Add(lblMalzemeAdi);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbMalzemeAdi);
            Controls.Add(txtMalzemeID);
            Controls.Add(btnTextClear);
            Name = "MalzemeKayitYonetim";
            Text = "Malzeme Kayıt Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvMalzemeKayit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTextClear;
        private DataGridView dgvMalzemeKayit;
        private TextBox txtDepartmanAdi;
        private Label lblMalzemeSonKullanimTarihi;
        private Label lblMalzemeAdi;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblMalzemeSatinAlimTarihi;
        private ComboBox cmbMalzemeAdi;
        private TextBox txtMalzemeGirisStokMiktari;
        private Label lblMalzemeGirisStokMiktari;
        private Label lblMalzemeTedarikciID;
        private ComboBox cmbMalzemeTedarikciID;
        private TextBox txtMalzemeID;
        private Label lblMalzemeID;
        private TextBox txtMalzemeKalanStokMiktari;
        private Label lblMalzemeKalanStokMiktari;
        private DateTimePicker dtpMalzemeSatinAlimTarihi;
        private DateTimePicker dtpMalzemeSonKullanimTarihi;
        private ComboBox cmbTedarikciTeklifID;
        private Label lblTedarikciTeklifID;
    }
}