namespace SatinalmaMalKayitSistemi.Forms
{
    partial class TedarikciKayitYonetim
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
            dgvTedarikci = new DataGridView();
            txtTedarikciAdi = new TextBox();
            txtTedarikciTelefonu = new TextBox();
            lblTedarikciTelefon = new Label();
            lblTedarikciAdi = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtTedarikciAdresi = new TextBox();
            lblTedarikciAdresi = new Label();
            txtTedarikciID = new TextBox();
            lblTedarikciID = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTedarikci).BeginInit();
            SuspendLayout();
            // 
            // btnTextClear
            // 
            btnTextClear.Location = new Point(239, 86);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 53;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvTedarikci
            // 
            dgvTedarikci.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTedarikci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTedarikci.Location = new Point(41, 174);
            dgvTedarikci.Name = "dgvTedarikci";
            dgvTedarikci.Size = new Size(793, 310);
            dgvTedarikci.TabIndex = 45;
            dgvTedarikci.CellClick += dgvTedarikci_CellClick;
            // 
            // txtTedarikciAdi
            // 
            txtTedarikciAdi.Location = new Point(41, 87);
            txtTedarikciAdi.Name = "txtTedarikciAdi";
            txtTedarikciAdi.Size = new Size(168, 23);
            txtTedarikciAdi.TabIndex = 46;
            // 
            // txtTedarikciTelefonu
            // 
            txtTedarikciTelefonu.Location = new Point(41, 134);
            txtTedarikciTelefonu.Name = "txtTedarikciTelefonu";
            txtTedarikciTelefonu.Size = new Size(167, 23);
            txtTedarikciTelefonu.TabIndex = 47;
            // 
            // lblTedarikciTelefon
            // 
            lblTedarikciTelefon.AutoSize = true;
            lblTedarikciTelefon.Location = new Point(41, 116);
            lblTedarikciTelefon.Name = "lblTedarikciTelefon";
            lblTedarikciTelefon.Size = new Size(101, 15);
            lblTedarikciTelefon.TabIndex = 52;
            lblTedarikciTelefon.Text = "Tedarikçi Telefonu";
            // 
            // lblTedarikciAdi
            // 
            lblTedarikciAdi.AutoSize = true;
            lblTedarikciAdi.Location = new Point(41, 69);
            lblTedarikciAdi.Name = "lblTedarikciAdi";
            lblTedarikciAdi.Size = new Size(74, 15);
            lblTedarikciAdi.TabIndex = 51;
            lblTedarikciAdi.Text = "Tedarikçi Adı";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(625, 112);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 50;
            btnDelete.Text = "Tedarikçiyi Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(625, 81);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 49;
            btnUpdate.Text = "Tedarikçiyi Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(625, 50);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 48;
            btnAdd.Text = "Yeni Tedarikçi Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtTedarikciAdresi
            // 
            txtTedarikciAdresi.Location = new Point(239, 35);
            txtTedarikciAdresi.Name = "txtTedarikciAdresi";
            txtTedarikciAdresi.Size = new Size(167, 23);
            txtTedarikciAdresi.TabIndex = 54;
            // 
            // lblTedarikciAdresi
            // 
            lblTedarikciAdresi.AutoSize = true;
            lblTedarikciAdresi.Location = new Point(239, 17);
            lblTedarikciAdresi.Name = "lblTedarikciAdresi";
            lblTedarikciAdresi.Size = new Size(89, 15);
            lblTedarikciAdresi.TabIndex = 55;
            lblTedarikciAdresi.Text = "Tedarikçi Adresi";
            // 
            // txtTedarikciID
            // 
            txtTedarikciID.Location = new Point(41, 35);
            txtTedarikciID.Name = "txtTedarikciID";
            txtTedarikciID.ReadOnly = true;
            txtTedarikciID.Size = new Size(168, 23);
            txtTedarikciID.TabIndex = 56;
            // 
            // lblTedarikciID
            // 
            lblTedarikciID.AutoSize = true;
            lblTedarikciID.Location = new Point(41, 17);
            lblTedarikciID.Name = "lblTedarikciID";
            lblTedarikciID.Size = new Size(67, 15);
            lblTedarikciID.TabIndex = 57;
            lblTedarikciID.Text = "Tedarikçi ID";
            // 
            // TedarikciKayitYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(txtTedarikciID);
            Controls.Add(lblTedarikciID);
            Controls.Add(txtTedarikciAdresi);
            Controls.Add(lblTedarikciAdresi);
            Controls.Add(btnTextClear);
            Controls.Add(dgvTedarikci);
            Controls.Add(txtTedarikciAdi);
            Controls.Add(txtTedarikciTelefonu);
            Controls.Add(lblTedarikciTelefon);
            Controls.Add(lblTedarikciAdi);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "TedarikciKayitYonetim";
            Text = "Tedarikçi Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvTedarikci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTextClear;
        private DataGridView dgvTedarikci;
        private TextBox txtTedarikciAdi;
        private TextBox txtTedarikciTelefonu;
        private Label lblTedarikciTelefon;
        private Label lblTedarikciAdi;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtTedarikciAdresi;
        private Label lblTedarikciAdresi;
        private TextBox txtTedarikciID;
        private Label lblTedarikciID;
    }
}