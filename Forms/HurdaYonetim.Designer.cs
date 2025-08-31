namespace SatinalmaMalKayitSistemi.Forms
{
    partial class HurdaYonetim
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
            txtHurdaID = new TextBox();
            lblHurdaID = new Label();
            btnTextClear = new Button();
            dgvHurda = new DataGridView();
            lblHurdaAciklama = new Label();
            lblHurdaTarihi = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            txtHurdaAciklama = new TextBox();
            btnAdd = new Button();
            lblMalzemeID = new Label();
            cmbMalzemeAdi = new ComboBox();
            dtpHurdaTarihi = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvHurda).BeginInit();
            SuspendLayout();
            // 
            // txtHurdaID
            // 
            txtHurdaID.Location = new Point(41, 36);
            txtHurdaID.Name = "txtHurdaID";
            txtHurdaID.ReadOnly = true;
            txtHurdaID.Size = new Size(167, 23);
            txtHurdaID.TabIndex = 56;
            // 
            // lblHurdaID
            // 
            lblHurdaID.AutoSize = true;
            lblHurdaID.Location = new Point(41, 18);
            lblHurdaID.Name = "lblHurdaID";
            lblHurdaID.Size = new Size(54, 15);
            lblHurdaID.TabIndex = 57;
            lblHurdaID.Text = "Hurda ID";
            // 
            // btnTextClear
            // 
            btnTextClear.Location = new Point(240, 85);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 55;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvHurda
            // 
            dgvHurda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHurda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHurda.Location = new Point(41, 172);
            dgvHurda.Name = "dgvHurda";
            dgvHurda.Size = new Size(793, 310);
            dgvHurda.TabIndex = 48;
            dgvHurda.CellClick += dgvHurda_CellClick;
            // 
            // lblHurdaAciklama
            // 
            lblHurdaAciklama.AutoSize = true;
            lblHurdaAciklama.Location = new Point(240, 18);
            lblHurdaAciklama.Name = "lblHurdaAciklama";
            lblHurdaAciklama.Size = new Size(92, 15);
            lblHurdaAciklama.TabIndex = 54;
            lblHurdaAciklama.Text = "Hurda Açıklama";
            // 
            // lblHurdaTarihi
            // 
            lblHurdaTarihi.AutoSize = true;
            lblHurdaTarihi.Location = new Point(41, 116);
            lblHurdaTarihi.Name = "lblHurdaTarihi";
            lblHurdaTarihi.Size = new Size(115, 15);
            lblHurdaTarihi.TabIndex = 53;
            lblHurdaTarihi.Text = "Hurda Ayrılma Tarihi";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(680, 107);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 52;
            btnDelete.Text = "Hurda Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(680, 78);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 51;
            btnUpdate.Text = "Hurda Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtHurdaAciklama
            // 
            txtHurdaAciklama.Location = new Point(240, 36);
            txtHurdaAciklama.Name = "txtHurdaAciklama";
            txtHurdaAciklama.Size = new Size(168, 23);
            txtHurdaAciklama.TabIndex = 58;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(680, 49);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 71;
            btnAdd.Text = "Hurda Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblMalzemeID
            // 
            lblMalzemeID.AutoSize = true;
            lblMalzemeID.Location = new Point(41, 67);
            lblMalzemeID.Name = "lblMalzemeID";
            lblMalzemeID.Size = new Size(76, 15);
            lblMalzemeID.TabIndex = 73;
            lblMalzemeID.Text = "Malzeme Adı";
            // 
            // cmbMalzemeAdi
            // 
            cmbMalzemeAdi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMalzemeAdi.FormattingEnabled = true;
            cmbMalzemeAdi.Location = new Point(41, 85);
            cmbMalzemeAdi.Name = "cmbMalzemeAdi";
            cmbMalzemeAdi.Size = new Size(167, 23);
            cmbMalzemeAdi.TabIndex = 74;
            // 
            // dtpHurdaTarihi
            // 
            dtpHurdaTarihi.CustomFormat = "dd.MM.yyyy";
            dtpHurdaTarihi.Format = DateTimePickerFormat.Custom;
            dtpHurdaTarihi.Location = new Point(41, 134);
            dtpHurdaTarihi.Name = "dtpHurdaTarihi";
            dtpHurdaTarihi.Size = new Size(167, 23);
            dtpHurdaTarihi.TabIndex = 76;
            // 
            // HurdaYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(cmbMalzemeAdi);
            Controls.Add(lblMalzemeID);
            Controls.Add(btnAdd);
            Controls.Add(txtHurdaAciklama);
            Controls.Add(txtHurdaID);
            Controls.Add(lblHurdaID);
            Controls.Add(btnTextClear);
            Controls.Add(dgvHurda);
            Controls.Add(lblHurdaAciklama);
            Controls.Add(lblHurdaTarihi);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dtpHurdaTarihi);
            Name = "HurdaYonetim";
            Text = "Hurda Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvHurda).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtHurdaID;
        private Label lblHurdaID;
        private Button btnTextClear;
        private DataGridView dgvHurda;
        private Label lblHurdaAciklama;
        private Label lblHurdaTarihi;
        private Button btnDelete;
        private Button btnUpdate;
        private TextBox txtHurdaAciklama;
        private Button btnAdd;
        private Label lblMalzemeID;
        private ComboBox cmbMalzemeAdi;
        private DateTimePicker dtpHurdaTarihi;
    }
}