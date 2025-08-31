namespace SatinalmaMalKayitSistemi.Forms
{
    partial class ZimmetYonetim
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
            txtZimmetID = new TextBox();
            lblZimmetID = new Label();
            btnTextClear = new Button();
            dgvZimmet = new DataGridView();
            lblZimmetTarihi = new Label();
            lblZimmetliKullaniciID = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            cmbZimmetliKullaniciID = new ComboBox();
            btnAdd = new Button();
            cmbMalzemeAdi = new ComboBox();
            lblMalzemeID = new Label();
            txtZimmetAciklama = new TextBox();
            lblZimmetAciklama = new Label();
            dtpZimmetTarihi = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvZimmet).BeginInit();
            SuspendLayout();
            // 
            // txtZimmetID
            // 
            txtZimmetID.Location = new Point(41, 36);
            txtZimmetID.Name = "txtZimmetID";
            txtZimmetID.ReadOnly = true;
            txtZimmetID.Size = new Size(167, 23);
            txtZimmetID.TabIndex = 66;
            // 
            // lblZimmetID
            // 
            lblZimmetID.AutoSize = true;
            lblZimmetID.Location = new Point(41, 18);
            lblZimmetID.Name = "lblZimmetID";
            lblZimmetID.Size = new Size(63, 15);
            lblZimmetID.TabIndex = 67;
            lblZimmetID.Text = "Zimmet ID";
            // 
            // btnTextClear
            // 
            btnTextClear.Location = new Point(240, 133);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 65;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvZimmet
            // 
            dgvZimmet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvZimmet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvZimmet.Location = new Point(41, 172);
            dgvZimmet.Name = "dgvZimmet";
            dgvZimmet.Size = new Size(793, 310);
            dgvZimmet.TabIndex = 59;
            dgvZimmet.CellClick += dgvZimmet_CellClick;
            // 
            // lblZimmetTarihi
            // 
            lblZimmetTarihi.AutoSize = true;
            lblZimmetTarihi.Location = new Point(41, 116);
            lblZimmetTarihi.Name = "lblZimmetTarihi";
            lblZimmetTarihi.Size = new Size(80, 15);
            lblZimmetTarihi.TabIndex = 64;
            lblZimmetTarihi.Text = "Zimmet Tarihi";
            // 
            // lblZimmetliKullaniciID
            // 
            lblZimmetliKullaniciID.AutoSize = true;
            lblZimmetliKullaniciID.Location = new Point(41, 67);
            lblZimmetliKullaniciID.Name = "lblZimmetliKullaniciID";
            lblZimmetliKullaniciID.Size = new Size(76, 15);
            lblZimmetliKullaniciID.TabIndex = 63;
            lblZimmetliKullaniciID.Text = "Zimmetli Kişi";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(662, 107);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 62;
            btnDelete.Text = "Zimmet Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(662, 78);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 61;
            btnUpdate.Text = "Zimmet Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // cmbZimmetliKullaniciID
            // 
            cmbZimmetliKullaniciID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbZimmetliKullaniciID.FormattingEnabled = true;
            cmbZimmetliKullaniciID.Location = new Point(41, 86);
            cmbZimmetliKullaniciID.Name = "cmbZimmetliKullaniciID";
            cmbZimmetliKullaniciID.Size = new Size(167, 23);
            cmbZimmetliKullaniciID.TabIndex = 69;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(662, 49);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 70;
            btnAdd.Text = "Zimmet Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(240, 85);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(167, 23);
            cmbMalzemeAdi.TabIndex = 76;
            // 
            // lblMalzemeID
            // 
            lblMalzemeID.AutoSize = true;
            lblMalzemeID.Location = new Point(240, 67);
            lblMalzemeID.Name = "lblMalzemeID";
            lblMalzemeID.Size = new Size(76, 15);
            lblMalzemeID.TabIndex = 75;
            lblMalzemeID.Text = "Malzeme Adı";
            // 
            // txtZimmetAciklama
            // 
            txtZimmetAciklama.Location = new Point(240, 36);
            txtZimmetAciklama.Name = "txtZimmetAciklama";
            txtZimmetAciklama.Size = new Size(168, 23);
            txtZimmetAciklama.TabIndex = 79;
            // 
            // lblZimmetAciklama
            // 
            lblZimmetAciklama.AutoSize = true;
            lblZimmetAciklama.Location = new Point(240, 18);
            lblZimmetAciklama.Name = "lblZimmetAciklama";
            lblZimmetAciklama.Size = new Size(101, 15);
            lblZimmetAciklama.TabIndex = 78;
            lblZimmetAciklama.Text = "Zimmet Açıklama";
            // 
            // dtpZimmetTarihi
            // 
            dtpZimmetTarihi.CustomFormat = "dd.MM.yyyy";
            dtpZimmetTarihi.Format = DateTimePickerFormat.Custom;
            dtpZimmetTarihi.Location = new Point(41, 134);
            dtpZimmetTarihi.Name = "dtpZimmetTarihi";
            dtpZimmetTarihi.Size = new Size(167, 23);
            dtpZimmetTarihi.TabIndex = 80;
            // 
            // ZimmetYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(txtZimmetAciklama);
            Controls.Add(lblZimmetAciklama);
            Controls.Add(cmbMalzemeAdi);
            Controls.Add(lblMalzemeID);
            Controls.Add(btnAdd);
            Controls.Add(cmbZimmetliKullaniciID);
            Controls.Add(txtZimmetID);
            Controls.Add(lblZimmetID);
            Controls.Add(btnTextClear);
            Controls.Add(dgvZimmet);
            Controls.Add(lblZimmetTarihi);
            Controls.Add(lblZimmetliKullaniciID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dtpZimmetTarihi);
            Name = "ZimmetYonetim";
            Text = "Zimmet Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvZimmet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtZimmetID;
        private Label lblZimmetID;
        private Button btnTextClear;
        private DataGridView dgvZimmet;
        private Label lblZimmetTarihi;
        private Label lblZimmetliKullaniciID;
        private Button btnDelete;
        private Button btnUpdate;
        private ComboBox cmbZimmetliKullaniciID;
        private Button btnAdd;
        private ComboBox cmbMalzemeAdi;
        private Label lblMalzemeID;
        private TextBox txtZimmetAciklama;
        private Label lblZimmetAciklama;
        private DateTimePicker dtpZimmetTarihi;
    }
}