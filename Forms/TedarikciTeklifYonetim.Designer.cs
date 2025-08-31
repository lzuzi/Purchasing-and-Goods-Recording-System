namespace SatinalmaMalKayitSistemi.Forms
{
    partial class TedarikciTeklifYonetim
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
            txtTedarikciTeklifID = new TextBox();
            lblTedarikciTeklifID = new Label();
            txtBirinciTedarikciTeklif = new TextBox();
            lblBirinciTedarikciTeklif = new Label();
            btnTextClear = new Button();
            dgvTedarikciTeklif = new DataGridView();
            lblMalzemeTalepID = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblKabulEdilenTeklif = new Label();
            cmbKabulEdilenTeklif = new ComboBox();
            cmbMalzemeTalepID = new ComboBox();
            txtIkinciTedarikciTeklif = new TextBox();
            lblIkinciTedarikciTeklif = new Label();
            txtUcuncuTedarikciTeklif = new TextBox();
            lblUcuncuTedarikciTeklif = new Label();
            cmbBirinciTedarikci = new ComboBox();
            lblBirinciTedarikci = new Label();
            cmbIkinciTedarikci = new ComboBox();
            lblIkinciTedarikci = new Label();
            cmbUcuncuTedarikci = new ComboBox();
            lblUcuncuTedarikci = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTedarikciTeklif).BeginInit();
            SuspendLayout();
            // 
            // txtTedarikciTeklifID
            // 
            txtTedarikciTeklifID.Location = new Point(41, 35);
            txtTedarikciTeklifID.Name = "txtTedarikciTeklifID";
            txtTedarikciTeklifID.ReadOnly = true;
            txtTedarikciTeklifID.Size = new Size(168, 23);
            txtTedarikciTeklifID.TabIndex = 69;
            // 
            // lblTedarikciTeklifID
            // 
            lblTedarikciTeklifID.AutoSize = true;
            lblTedarikciTeklifID.Location = new Point(41, 17);
            lblTedarikciTeklifID.Name = "lblTedarikciTeklifID";
            lblTedarikciTeklifID.Size = new Size(97, 15);
            lblTedarikciTeklifID.TabIndex = 70;
            lblTedarikciTeklifID.Text = "Tedarikçi Teklif ID";
            // 
            // txtBirinciTedarikciTeklif
            // 
            txtBirinciTedarikciTeklif.Location = new Point(422, 35);
            txtBirinciTedarikciTeklif.Name = "txtBirinciTedarikciTeklif";
            txtBirinciTedarikciTeklif.Size = new Size(167, 23);
            txtBirinciTedarikciTeklif.TabIndex = 67;
            txtBirinciTedarikciTeklif.KeyPress += txtBirinciTedarikciTeklif_KeyPress;
            // 
            // lblBirinciTedarikciTeklif
            // 
            lblBirinciTedarikciTeklif.AutoSize = true;
            lblBirinciTedarikciTeklif.Location = new Point(422, 17);
            lblBirinciTedarikciTeklif.Name = "lblBirinciTedarikciTeklif";
            lblBirinciTedarikciTeklif.Size = new Size(98, 15);
            lblBirinciTedarikciTeklif.TabIndex = 68;
            lblBirinciTedarikciTeklif.Text = "1. Tedarikçi Teklifi";
            // 
            // btnTextClear
            // 
            btnTextClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTextClear.Location = new Point(645, 131);
            btnTextClear.Name = "btnTextClear";
            btnTextClear.Size = new Size(167, 23);
            btnTextClear.TabIndex = 66;
            btnTextClear.Text = "Metin Alanlarını Temizle";
            btnTextClear.UseVisualStyleBackColor = true;
            btnTextClear.Click += btnTextClear_Click;
            // 
            // dgvTedarikciTeklif
            // 
            dgvTedarikciTeklif.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTedarikciTeklif.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTedarikciTeklif.Location = new Point(41, 174);
            dgvTedarikciTeklif.Name = "dgvTedarikciTeklif";
            dgvTedarikciTeklif.Size = new Size(793, 310);
            dgvTedarikciTeklif.TabIndex = 58;
            dgvTedarikciTeklif.CellClick += dgvTedarikciTeklif_CellClick;
            // 
            // lblMalzemeTalepID
            // 
            lblMalzemeTalepID.AutoSize = true;
            lblMalzemeTalepID.Location = new Point(41, 69);
            lblMalzemeTalepID.Name = "lblMalzemeTalepID";
            lblMalzemeTalepID.Size = new Size(99, 15);
            lblMalzemeTalepID.TabIndex = 65;
            lblMalzemeTalepID.Text = "Malzeme Talep ID";
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(661, 102);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(127, 23);
            btnDelete.TabIndex = 63;
            btnDelete.Text = "Teklifi Sil";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUpdate.Location = new Point(661, 71);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(127, 23);
            btnUpdate.TabIndex = 62;
            btnUpdate.Text = "Teklifi Güncelle";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(661, 40);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 23);
            btnAdd.TabIndex = 61;
            btnAdd.Text = "Yeni Teklif Ekle";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblKabulEdilenTeklif
            // 
            lblKabulEdilenTeklif.AutoSize = true;
            lblKabulEdilenTeklif.Location = new Point(41, 116);
            lblKabulEdilenTeklif.Name = "lblKabulEdilenTeklif";
            lblKabulEdilenTeklif.Size = new Size(102, 15);
            lblKabulEdilenTeklif.TabIndex = 72;
            lblKabulEdilenTeklif.Text = "Kabul Edilen Teklif";
            // 
            // cmbKabulEdilenTeklif
            // 
            cmbKabulEdilenTeklif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKabulEdilenTeklif.FormattingEnabled = true;
            cmbKabulEdilenTeklif.Items.AddRange(new object[] { "1. Teklif", "2. Teklif", "3. Teklif" });
            cmbKabulEdilenTeklif.Location = new Point(41, 134);
            cmbKabulEdilenTeklif.Name = "cmbKabulEdilenTeklif";
            cmbKabulEdilenTeklif.Size = new Size(168, 23);
            cmbKabulEdilenTeklif.TabIndex = 73;
            // 
            // cmbMalzemeTalepID
            // 
            cmbMalzemeTalepID.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMalzemeTalepID.FormattingEnabled = true;
            cmbMalzemeTalepID.Location = new Point(41, 87);
            cmbMalzemeTalepID.Name = "cmbMalzemeTalepID";
            cmbMalzemeTalepID.Size = new Size(168, 23);
            cmbMalzemeTalepID.TabIndex = 74;
            // 
            // txtIkinciTedarikciTeklif
            // 
            txtIkinciTedarikciTeklif.Location = new Point(422, 87);
            txtIkinciTedarikciTeklif.Name = "txtIkinciTedarikciTeklif";
            txtIkinciTedarikciTeklif.Size = new Size(167, 23);
            txtIkinciTedarikciTeklif.TabIndex = 77;
            txtIkinciTedarikciTeklif.KeyPress += txtIkinciTedarikciTeklif_KeyPress;
            // 
            // lblIkinciTedarikciTeklif
            // 
            lblIkinciTedarikciTeklif.AutoSize = true;
            lblIkinciTedarikciTeklif.Location = new Point(422, 69);
            lblIkinciTedarikciTeklif.Name = "lblIkinciTedarikciTeklif";
            lblIkinciTedarikciTeklif.Size = new Size(98, 15);
            lblIkinciTedarikciTeklif.TabIndex = 78;
            lblIkinciTedarikciTeklif.Text = "2. Tedarikçi Teklifi";
            // 
            // txtUcuncuTedarikciTeklif
            // 
            txtUcuncuTedarikciTeklif.Location = new Point(422, 134);
            txtUcuncuTedarikciTeklif.Name = "txtUcuncuTedarikciTeklif";
            txtUcuncuTedarikciTeklif.Size = new Size(167, 23);
            txtUcuncuTedarikciTeklif.TabIndex = 81;
            txtUcuncuTedarikciTeklif.KeyPress += txtUcuncuTedarikciTeklif_KeyPress;
            // 
            // lblUcuncuTedarikciTeklif
            // 
            lblUcuncuTedarikciTeklif.AutoSize = true;
            lblUcuncuTedarikciTeklif.Location = new Point(422, 116);
            lblUcuncuTedarikciTeklif.Name = "lblUcuncuTedarikciTeklif";
            lblUcuncuTedarikciTeklif.Size = new Size(95, 15);
            lblUcuncuTedarikciTeklif.TabIndex = 82;
            lblUcuncuTedarikciTeklif.Text = "3. Tedarikçi Teklif";
            // 
            // cmbBirinciTedarikci
            // 
            cmbBirinciTedarikci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBirinciTedarikci.FormattingEnabled = true;
            cmbBirinciTedarikci.Location = new Point(233, 35);
            cmbBirinciTedarikci.Name = "cmbBirinciTedarikci";
            cmbBirinciTedarikci.Size = new Size(168, 23);
            cmbBirinciTedarikci.TabIndex = 86;
            // 
            // lblBirinciTedarikci
            // 
            lblBirinciTedarikci.AutoSize = true;
            lblBirinciTedarikci.Location = new Point(232, 17);
            lblBirinciTedarikci.Name = "lblBirinciTedarikci";
            lblBirinciTedarikci.Size = new Size(65, 15);
            lblBirinciTedarikci.TabIndex = 85;
            lblBirinciTedarikci.Text = "1. Tedarikçi";
            // 
            // cmbIkinciTedarikci
            // 
            cmbIkinciTedarikci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIkinciTedarikci.FormattingEnabled = true;
            cmbIkinciTedarikci.Location = new Point(234, 87);
            cmbIkinciTedarikci.Name = "cmbIkinciTedarikci";
            cmbIkinciTedarikci.Size = new Size(168, 23);
            cmbIkinciTedarikci.TabIndex = 88;
            // 
            // lblIkinciTedarikci
            // 
            lblIkinciTedarikci.AutoSize = true;
            lblIkinciTedarikci.Location = new Point(233, 69);
            lblIkinciTedarikci.Name = "lblIkinciTedarikci";
            lblIkinciTedarikci.Size = new Size(65, 15);
            lblIkinciTedarikci.TabIndex = 87;
            lblIkinciTedarikci.Text = "2. Tedarikçi";
            // 
            // cmbUcuncuTedarikci
            // 
            cmbUcuncuTedarikci.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUcuncuTedarikci.FormattingEnabled = true;
            cmbUcuncuTedarikci.Location = new Point(233, 134);
            cmbUcuncuTedarikci.Name = "cmbUcuncuTedarikci";
            cmbUcuncuTedarikci.Size = new Size(168, 23);
            cmbUcuncuTedarikci.TabIndex = 90;
            // 
            // lblUcuncuTedarikci
            // 
            lblUcuncuTedarikci.AutoSize = true;
            lblUcuncuTedarikci.Location = new Point(232, 116);
            lblUcuncuTedarikci.Name = "lblUcuncuTedarikci";
            lblUcuncuTedarikci.Size = new Size(65, 15);
            lblUcuncuTedarikci.TabIndex = 89;
            lblUcuncuTedarikci.Text = "3. Tedarikçi";
            // 
            // TedarikciTeklifYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(cmbUcuncuTedarikci);
            Controls.Add(lblUcuncuTedarikci);
            Controls.Add(cmbIkinciTedarikci);
            Controls.Add(lblIkinciTedarikci);
            Controls.Add(cmbBirinciTedarikci);
            Controls.Add(lblBirinciTedarikci);
            Controls.Add(txtUcuncuTedarikciTeklif);
            Controls.Add(lblUcuncuTedarikciTeklif);
            Controls.Add(txtIkinciTedarikciTeklif);
            Controls.Add(lblIkinciTedarikciTeklif);
            Controls.Add(cmbMalzemeTalepID);
            Controls.Add(cmbKabulEdilenTeklif);
            Controls.Add(lblKabulEdilenTeklif);
            Controls.Add(txtTedarikciTeklifID);
            Controls.Add(lblTedarikciTeklifID);
            Controls.Add(txtBirinciTedarikciTeklif);
            Controls.Add(lblBirinciTedarikciTeklif);
            Controls.Add(btnTextClear);
            Controls.Add(dgvTedarikciTeklif);
            Controls.Add(lblMalzemeTalepID);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Name = "TedarikciTeklifYonetim";
            Text = "Tedarikçi Teklif Yönetim Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvTedarikciTeklif).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTedarikciTeklifID;
        private Label lblTedarikciTeklifID;
        private TextBox txtBirinciTedarikciTeklif;
        private Label lblBirinciTedarikciTeklif;
        private Button btnTextClear;
        private DataGridView dgvTedarikciTeklif;
        private TextBox txtTedarikciTelefonu;
        private Label lblMalzemeTalepID;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblKabulEdilenTeklif;
        private ComboBox cmbKabulEdilenTeklif;
        private ComboBox cmbMalzemeTalepID;
        private TextBox txtIkinciTedarikciTeklif;
        private Label lblIkinciTedarikciTeklif;
        private TextBox txtUcuncuTedarikciTeklif;
        private Label lblUcuncuTedarikciTeklif;
        private ComboBox cmbBirinciTedarikci;
        private Label lblBirinciTedarikci;
        private ComboBox cmbIkinciTedarikci;
        private Label lblIkinciTedarikci;
        private ComboBox cmbUcuncuTedarikci;
        private Label lblUcuncuTedarikci;
    }
}