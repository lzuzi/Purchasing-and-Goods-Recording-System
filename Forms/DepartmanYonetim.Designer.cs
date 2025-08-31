namespace SatinalmaMalKayitSistemi.Forms
{
    partial class DepartmanYonetim
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
            dgvDepartman = new DataGridView();
            txtDepartmanAdi = new TextBox();
            lblSorumluKisi = new Label();
            lblDepartmanAdi = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtDepartmanId = new TextBox();
            lblDepartmanId = new Label();
            cmbDepartmanSorumluID = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvDepartman).BeginInit();
            SuspendLayout();
            // 
            // btnTextClear
            // 
            btnTextClear.Location = new Point(240, 87);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 44;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvDepartman
            // 
            dgvDepartman.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDepartman.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDepartman.Location = new Point(41, 174);
            dgvDepartman.Name = "dgvDepartman";
            dgvDepartman.Size = new Size(793, 310);
            dgvDepartman.TabIndex = 30;
            dgvDepartman.CellClick += dgvDepartman_CellClick;
            // 
            // txtDepartmanAdi
            // 
            txtDepartmanAdi.Location = new Point(41, 87);
            txtDepartmanAdi.Name = "txtDepartmanAdi";
            txtDepartmanAdi.Size = new Size(168, 23);
            txtDepartmanAdi.TabIndex = 31;
            // 
            // lblSorumluKisi
            // 
            lblSorumluKisi.AutoSize = true;
            lblSorumluKisi.Location = new Point(41, 118);
            lblSorumluKisi.Name = "lblSorumluKisi";
            lblSorumluKisi.Size = new Size(126, 15);
            lblSorumluKisi.TabIndex = 39;
            lblSorumluKisi.Text = "Departman Sorumlusu";
            // 
            // lblDepartmanAdi
            // 
            lblDepartmanAdi.AutoSize = true;
            lblDepartmanAdi.Location = new Point(41, 69);
            lblDepartmanAdi.Name = "lblDepartmanAdi";
            lblDepartmanAdi.Size = new Size(87, 15);
            lblDepartmanAdi.TabIndex = 38;
            lblDepartmanAdi.Text = "Departman Adı";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(492, 110);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 37;
            btnDelete.Text = "Departmanı Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(492, 79);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 36;
            btnUpdate.Text = "Departmanı Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(492, 48);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 35;
            btnAdd.Text = "Yeni Departman Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDepartmanId
            // 
            txtDepartmanId.Location = new Point(41, 38);
            txtDepartmanId.Name = "txtDepartmanId";
            txtDepartmanId.ReadOnly = true;
            txtDepartmanId.Size = new Size(167, 23);
            txtDepartmanId.TabIndex = 45;
            // 
            // lblDepartmanId
            // 
            lblDepartmanId.AutoSize = true;
            lblDepartmanId.Location = new Point(41, 20);
            lblDepartmanId.Name = "lblDepartmanId";
            lblDepartmanId.Size = new Size(80, 15);
            lblDepartmanId.TabIndex = 46;
            lblDepartmanId.Text = "Departman ID";
            // 
            // cmbDepartmanSorumluID
            // 
            cmbDepartmanSorumluID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartmanSorumluID.FormattingEnabled = true;
            cmbDepartmanSorumluID.Location = new Point(42, 136);
            cmbDepartmanSorumluID.Name = "cmbDepartmanSorumluID";
            cmbDepartmanSorumluID.Size = new Size(167, 23);
            cmbDepartmanSorumluID.TabIndex = 47;
            // 
            // DepartmanYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(cmbDepartmanSorumluID);
            Controls.Add(txtDepartmanId);
            Controls.Add(lblDepartmanId);
            Controls.Add(btnTextClear);
            Controls.Add(dgvDepartman);
            Controls.Add(txtDepartmanAdi);
            Controls.Add(lblSorumluKisi);
            Controls.Add(lblDepartmanAdi);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "DepartmanYonetim";
            Text = "Departman Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvDepartman).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTextClear;
        private Label lblRole;
        private DataGridView dgvDepartman;
        private Label lblEmail;
        private TextBox txtDepartmanAdi;
        private Label lblFullName;
        private Label lblSorumluKisi;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblDepartmanAdi;
        private TextBox txtEmail;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox cmbRole;
        private TextBox txtDepartmanId;
        private Label lblDepartmanId;
        private ComboBox cmbDepartmanSorumluID;
    }
}