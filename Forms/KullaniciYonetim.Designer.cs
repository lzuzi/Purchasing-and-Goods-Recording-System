namespace SatinalmaMalKayitSistemi.Forms
{
    partial class KullaniciYonetim
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
            lblRole = new Label();
            dgvUsers = new DataGridView();
            lblEmail = new Label();
            txtUsername = new TextBox();
            lblFullName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtFullName = new TextBox();
            lblUsername = new Label();
            txtEmail = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cmbRole = new ComboBox();
            btnTextClear = new Button();
            txtKullaniciID = new TextBox();
            lblKullaniciID = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(238, 119);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(88, 15);
            lblRole.TabIndex = 27;
            lblRole.Text = "Kullanıcı Grubu";
            // 
            // dgvUsers
            // 
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(41, 174);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(793, 310);
            dgvUsers.TabIndex = 14;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(238, 69);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 26;
            lblEmail.Text = "Email";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(41, 87);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(168, 23);
            txtUsername.TabIndex = 15;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(238, 17);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(65, 15);
            lblFullName.TabIndex = 25;
            lblFullName.Text = "Ad - Soyad";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(41, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(167, 23);
            txtPassword.TabIndex = 16;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(41, 119);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(30, 15);
            lblPassword.TabIndex = 24;
            lblPassword.Text = "Şifre";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(238, 35);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(166, 23);
            txtFullName.TabIndex = 17;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(41, 69);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(71, 15);
            lblUsername.TabIndex = 23;
            lblUsername.Text = "Kullanıcı adı";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(238, 87);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(167, 23);
            txtEmail.TabIndex = 18;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(647, 111);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "Kullanıcıyı Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(647, 80);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 21;
            btnUpdate.Text = "Kullanıcıyı Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(647, 49);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 20;
            btnAdd.Text = "Yeni Kullanıcı Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Talep Karsilama", "Talep Olusturma" });
            cmbRole.Location = new Point(238, 137);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(167, 23);
            cmbRole.TabIndex = 28;
            // 
            // btnTextClear
            // 
            btnTextClear.Location = new Point(454, 80);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 29;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // txtKullaniciID
            // 
            txtKullaniciID.Location = new Point(41, 35);
            txtKullaniciID.Name = "txtKullaniciID";
            txtKullaniciID.ReadOnly = true;
            txtKullaniciID.Size = new Size(167, 23);
            txtKullaniciID.TabIndex = 30;
            // 
            // lblKullaniciID
            // 
            lblKullaniciID.AutoSize = true;
            lblKullaniciID.Location = new Point(41, 17);
            lblKullaniciID.Name = "lblKullaniciID";
            lblKullaniciID.Size = new Size(66, 15);
            lblKullaniciID.TabIndex = 31;
            lblKullaniciID.Text = "Kullanıcı ID";
            // 
            // KullaniciYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(874, 501);
            Controls.Add(txtKullaniciID);
            Controls.Add(lblKullaniciID);
            Controls.Add(btnTextClear);
            Controls.Add(lblRole);
            Controls.Add(dgvUsers);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblFullName);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtFullName);
            Controls.Add(lblUsername);
            Controls.Add(txtEmail);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cmbRole);
            Name = "KullaniciYonetim";
            Text = "Kullanıcı Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblRole;
        private DataGridView dgvUsers;
        private Label lblEmail;
        private TextBox txtUsername;
        private Label lblFullName;
        private TextBox txtPassword;
        private Label lblPassword;
        private TextBox txtFullName;
        private Label lblUsername;
        private TextBox txtEmail;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox cmbRole;
        private Button btnTextClear;
        private TextBox txtKullaniciID;
        private Label lblKullaniciID;
    }
}