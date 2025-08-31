namespace SatinalmaMalKayitSistemi.Forms
{
    partial class MalzemeTalepYonetim
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
            txtTalepKayitsizMalzemeID = new TextBox();
            lblTalepKayitsizMalzemeID = new Label();
            cmbMalzemeAdi = new ComboBox();
            lblTalepKayitliMalzemeID = new Label();
            btnAdd = new Button();
            cmbTalepKullaniciID = new ComboBox();
            txtTalepID = new TextBox();
            lblTalepID = new Label();
            btnTextClear = new Button();
            dgvTalep = new DataGridView();
            lblTalepTarihi = new Label();
            lblTalepKullaniciID = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            cmbTalepDepartmanID = new ComboBox();
            lblTalepDepartmanID = new Label();
            txtTalepMiktari = new TextBox();
            lblTalepMiktari = new Label();
            txtTalepAciklama = new TextBox();
            lblTalepAciklama = new Label();
            cmbTalepKarsilanmaDurumu = new ComboBox();
            lblTalepKarsilanmaDurumu = new Label();
            dtpTalepTarihi = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvTalep).BeginInit();
            SuspendLayout();
            // 
            // txtTalepKayitsizMalzemeID
            // 
            txtTalepKayitsizMalzemeID.Location = new Point(231, 134);
            txtTalepKayitsizMalzemeID.Name = "txtTalepKayitsizMalzemeID";
            txtTalepKayitsizMalzemeID.Size = new Size(168, 23);
            txtTalepKayitsizMalzemeID.TabIndex = 95;
            // 
            // lblTalepKayitsizMalzemeID
            // 
            lblTalepKayitsizMalzemeID.AutoSize = true;
            lblTalepKayitsizMalzemeID.Location = new Point(231, 116);
            lblTalepKayitsizMalzemeID.Name = "lblTalepKayitsizMalzemeID";
            lblTalepKayitsizMalzemeID.Size = new Size(149, 15);
            lblTalepKayitsizMalzemeID.TabIndex = 94;
            lblTalepKayitsizMalzemeID.Text = "Kayıtsız Malzeme Açıklama";
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(231, 85);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(167, 23);
            cmbMalzemeAdi.TabIndex = 92;
            // 
            // lblTalepKayitliMalzemeID
            // 
            lblTalepKayitliMalzemeID.AutoSize = true;
            lblTalepKayitliMalzemeID.Location = new Point(231, 67);
            lblTalepKayitliMalzemeID.Name = "lblTalepKayitliMalzemeID";
            lblTalepKayitliMalzemeID.Size = new Size(125, 15);
            lblTalepKayitliMalzemeID.TabIndex = 91;
            lblTalepKayitliMalzemeID.Text = "Kayıtlı Malzeme Seçim";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(666, 55);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 90;
            btnAdd.Text = "Talep Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbTalepKullaniciID
            // 
            cmbTalepKullaniciID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalepKullaniciID.FormattingEnabled = true;
            cmbTalepKullaniciID.Location = new Point(32, 86);
            cmbTalepKullaniciID.Name = "cmbTalepKullaniciID";
            cmbTalepKullaniciID.Size = new Size(167, 23);
            cmbTalepKullaniciID.TabIndex = 89;
            // 
            // txtTalepID
            // 
            txtTalepID.Location = new Point(32, 36);
            txtTalepID.Name = "txtTalepID";
            txtTalepID.ReadOnly = true;
            txtTalepID.Size = new Size(167, 23);
            txtTalepID.TabIndex = 86;
            // 
            // lblTalepID
            // 
            lblTalepID.AutoSize = true;
            lblTalepID.Location = new Point(32, 18);
            lblTalepID.Name = "lblTalepID";
            lblTalepID.Size = new Size(48, 15);
            lblTalepID.TabIndex = 87;
            lblTalepID.Text = "Talep ID";
            // 
            // btnTextClear
            // 
            btnTextClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTextClear.Location = new Point(643, 142);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 85;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvTalep
            // 
            dgvTalep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTalep.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTalep.Location = new Point(32, 172);
            dgvTalep.Name = "dgvTalep";
            dgvTalep.Size = new Size(793, 310);
            dgvTalep.TabIndex = 80;
            dgvTalep.CellClick += dgvTalep_CellClick;
            // 
            // lblTalepTarihi
            // 
            lblTalepTarihi.AutoSize = true;
            lblTalepTarihi.Location = new Point(231, 18);
            lblTalepTarihi.Name = "lblTalepTarihi";
            lblTalepTarihi.Size = new Size(65, 15);
            lblTalepTarihi.TabIndex = 84;
            lblTalepTarihi.Text = "Talep Tarihi";
            // 
            // lblTalepKullaniciID
            // 
            lblTalepKullaniciID.AutoSize = true;
            lblTalepKullaniciID.Location = new Point(32, 67);
            lblTalepKullaniciID.Name = "lblTalepKullaniciID";
            lblTalepKullaniciID.Size = new Size(84, 15);
            lblTalepKullaniciID.TabIndex = 83;
            lblTalepKullaniciID.Text = "Talep Eden Kişi";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(666, 113);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 82;
            btnDelete.Text = "Talep Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(666, 84);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 81;
            btnUpdate.Text = "Talep Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbTalepDepartmanID
            // 
            cmbTalepDepartmanID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalepDepartmanID.FormattingEnabled = true;
            cmbTalepDepartmanID.Location = new Point(32, 134);
            cmbTalepDepartmanID.Name = "cmbTalepDepartmanID";
            cmbTalepDepartmanID.Size = new Size(167, 23);
            cmbTalepDepartmanID.TabIndex = 97;
            // 
            // lblTalepDepartmanID
            // 
            lblTalepDepartmanID.AutoSize = true;
            lblTalepDepartmanID.Location = new Point(32, 116);
            lblTalepDepartmanID.Name = "lblTalepDepartmanID";
            lblTalepDepartmanID.Size = new Size(99, 15);
            lblTalepDepartmanID.TabIndex = 96;
            lblTalepDepartmanID.Text = "Talep Departmanı";
            // 
            // txtTalepMiktari
            // 
            txtTalepMiktari.Location = new Point(432, 36);
            txtTalepMiktari.Name = "txtTalepMiktari";
            txtTalepMiktari.Size = new Size(168, 23);
            txtTalepMiktari.TabIndex = 99;
            // 
            // lblTalepMiktari
            // 
            lblTalepMiktari.AutoSize = true;
            lblTalepMiktari.Location = new Point(432, 18);
            lblTalepMiktari.Name = "lblTalepMiktari";
            lblTalepMiktari.Size = new Size(74, 15);
            lblTalepMiktari.TabIndex = 98;
            lblTalepMiktari.Text = "Talep Miktarı";
            // 
            // txtTalepAciklama
            // 
            txtTalepAciklama.Location = new Point(432, 85);
            txtTalepAciklama.Name = "txtTalepAciklama";
            txtTalepAciklama.Size = new Size(168, 23);
            txtTalepAciklama.TabIndex = 101;
            // 
            // lblTalepAciklama
            // 
            lblTalepAciklama.AutoSize = true;
            lblTalepAciklama.Location = new Point(432, 67);
            lblTalepAciklama.Name = "lblTalepAciklama";
            lblTalepAciklama.Size = new Size(86, 15);
            lblTalepAciklama.TabIndex = 100;
            lblTalepAciklama.Text = "Talep Açıklama";
            // 
            // cmbTalepKarsilanmaDurumu
            // 
            cmbTalepKarsilanmaDurumu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTalepKarsilanmaDurumu.FormattingEnabled = true;
            cmbTalepKarsilanmaDurumu.Items.AddRange(new object[] { "0 - Karsilanmadi", "1 - Karsilandi", "2 - Reddedildi" });
            cmbTalepKarsilanmaDurumu.Location = new Point(432, 134);
            cmbTalepKarsilanmaDurumu.Name = "cmbTalepKarsilanmaDurumu";
            cmbTalepKarsilanmaDurumu.Size = new Size(167, 23);
            cmbTalepKarsilanmaDurumu.TabIndex = 103;
            // 
            // lblTalepKarsilanmaDurumu
            // 
            lblTalepKarsilanmaDurumu.AutoSize = true;
            lblTalepKarsilanmaDurumu.Location = new Point(432, 116);
            lblTalepKarsilanmaDurumu.Name = "lblTalepKarsilanmaDurumu";
            lblTalepKarsilanmaDurumu.Size = new Size(142, 15);
            lblTalepKarsilanmaDurumu.TabIndex = 102;
            lblTalepKarsilanmaDurumu.Text = "Talep Karşılanma Durumu";
            // 
            // dtpTalepTarihi
            // 
            dtpTalepTarihi.CustomFormat = "dd.MM.yyyy";
            dtpTalepTarihi.Format = DateTimePickerFormat.Custom;
            dtpTalepTarihi.Location = new Point(231, 36);
            dtpTalepTarihi.Name = "dtpTalepTarihi";
            dtpTalepTarihi.Size = new Size(167, 23);
            dtpTalepTarihi.TabIndex = 104;
            // 
            // MalzemeTalepYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(dtpTalepTarihi);
            Controls.Add(cmbTalepKarsilanmaDurumu);
            Controls.Add(lblTalepKarsilanmaDurumu);
            Controls.Add(txtTalepAciklama);
            Controls.Add(lblTalepAciklama);
            Controls.Add(txtTalepMiktari);
            Controls.Add(lblTalepMiktari);
            Controls.Add(cmbTalepDepartmanID);
            Controls.Add(lblTalepDepartmanID);
            Controls.Add(txtTalepKayitsizMalzemeID);
            Controls.Add(lblTalepKayitsizMalzemeID);
            Controls.Add(cmbMalzemeAdi);
            Controls.Add(lblTalepKayitliMalzemeID);
            Controls.Add(btnAdd);
            Controls.Add(cmbTalepKullaniciID);
            Controls.Add(txtTalepID);
            Controls.Add(lblTalepID);
            Controls.Add(btnTextClear);
            Controls.Add(dgvTalep);
            Controls.Add(lblTalepTarihi);
            Controls.Add(lblTalepKullaniciID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Name = "MalzemeTalepYonetim";
            Text = "Malzeme Talep Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvTalep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTalepKayitsizMalzemeID;
        private Label lblTalepKayitsizMalzemeID;
        private ComboBox cmbMalzemeAdi;
        private Label lblTalepKayitliMalzemeID;
        private Button btnAdd;
        private ComboBox cmbTalepKullaniciID;
        private TextBox txtTalepID;
        private Label lblTalepID;
        private Button btnTextClear;
        private DataGridView dgvTalep;
        private Label lblTalepTarihi;
        private Label lblTalepKullaniciID;
        private Button btnDelete;
        private Button btnUpdate;
        private ComboBox cmbTalepDepartmanID;
        private Label lblTalepDepartmanID;
        private TextBox txtTalepMiktari;
        private Label lblTalepMiktari;
        private TextBox txtTalepAciklama;
        private Label lblTalepAciklama;
        private ComboBox cmbTalepKarsilanmaDurumu;
        private Label lblTalepKarsilanmaDurumu;
        private DateTimePicker dtpTalepTarihi;
    }
}