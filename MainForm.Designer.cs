namespace SatinalmaMalKayitSistemi
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelMenu = new Panel();
            btnRaporlama = new Button();
            btnHurda = new Button();
            btnZimmet = new Button();
            btnTedarikciTeklif = new Button();
            btnMalzemeTalep = new Button();
            btnMalzemeKayit = new Button();
            btnMalzemeKullanim = new Button();
            btnTedarikciKayit = new Button();
            btnDepartman = new Button();
            btnUsers = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            panelTitleBar = new Panel();
            btnCloseChildForm = new Button();
            lblTitle = new Label();
            panelDesktopPane = new Panel();
            lblOgrenciBilgisi = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            panelDesktopPane.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(btnRaporlama);
            panelMenu.Controls.Add(btnHurda);
            panelMenu.Controls.Add(btnZimmet);
            panelMenu.Controls.Add(btnTedarikciTeklif);
            panelMenu.Controls.Add(btnMalzemeTalep);
            panelMenu.Controls.Add(btnMalzemeKayit);
            panelMenu.Controls.Add(btnMalzemeKullanim);
            panelMenu.Controls.Add(btnTedarikciKayit);
            panelMenu.Controls.Add(btnDepartman);
            panelMenu.Controls.Add(btnUsers);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 684);
            panelMenu.TabIndex = 0;
            // 
            // btnRaporlama
            // 
            btnRaporlama.Dock = DockStyle.Top;
            btnRaporlama.FlatAppearance.BorderSize = 0;
            btnRaporlama.FlatStyle = FlatStyle.Flat;
            btnRaporlama.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRaporlama.ForeColor = SystemColors.HighlightText;
            btnRaporlama.Image = Properties.Resources.raporlama;
            btnRaporlama.ImageAlign = ContentAlignment.MiddleLeft;
            btnRaporlama.Location = new Point(0, 620);
            btnRaporlama.Name = "btnRaporlama";
            btnRaporlama.Padding = new Padding(12, 0, 0, 0);
            btnRaporlama.Size = new Size(220, 60);
            btnRaporlama.TabIndex = 11;
            btnRaporlama.Text = "  Raporlar";
            btnRaporlama.TextAlign = ContentAlignment.MiddleLeft;
            btnRaporlama.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnRaporlama.UseVisualStyleBackColor = true;
            btnRaporlama.Click += btnRaporlama_Click;
            // 
            // btnHurda
            // 
            btnHurda.Dock = DockStyle.Top;
            btnHurda.FlatAppearance.BorderSize = 0;
            btnHurda.FlatStyle = FlatStyle.Flat;
            btnHurda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHurda.ForeColor = SystemColors.HighlightText;
            btnHurda.Image = Properties.Resources.hurda;
            btnHurda.ImageAlign = ContentAlignment.MiddleLeft;
            btnHurda.Location = new Point(0, 560);
            btnHurda.Name = "btnHurda";
            btnHurda.Padding = new Padding(12, 0, 0, 0);
            btnHurda.Size = new Size(220, 60);
            btnHurda.TabIndex = 10;
            btnHurda.Text = "  Hurda Yönetim";
            btnHurda.TextAlign = ContentAlignment.MiddleLeft;
            btnHurda.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHurda.UseVisualStyleBackColor = true;
            btnHurda.Click += btnHurda_Click;
            // 
            // btnZimmet
            // 
            btnZimmet.Dock = DockStyle.Top;
            btnZimmet.FlatAppearance.BorderSize = 0;
            btnZimmet.FlatStyle = FlatStyle.Flat;
            btnZimmet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnZimmet.ForeColor = SystemColors.HighlightText;
            btnZimmet.Image = Properties.Resources.zimmet_yonetim;
            btnZimmet.ImageAlign = ContentAlignment.MiddleLeft;
            btnZimmet.Location = new Point(0, 500);
            btnZimmet.Name = "btnZimmet";
            btnZimmet.Padding = new Padding(12, 0, 0, 0);
            btnZimmet.Size = new Size(220, 60);
            btnZimmet.TabIndex = 9;
            btnZimmet.Text = "  Zimmet Yönetim";
            btnZimmet.TextAlign = ContentAlignment.MiddleLeft;
            btnZimmet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnZimmet.UseVisualStyleBackColor = true;
            btnZimmet.Click += btnZimmet_Click;
            // 
            // btnTedarikciTeklif
            // 
            btnTedarikciTeklif.Dock = DockStyle.Top;
            btnTedarikciTeklif.FlatAppearance.BorderSize = 0;
            btnTedarikciTeklif.FlatStyle = FlatStyle.Flat;
            btnTedarikciTeklif.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTedarikciTeklif.ForeColor = SystemColors.HighlightText;
            btnTedarikciTeklif.Image = (Image)resources.GetObject("btnTedarikciTeklif.Image");
            btnTedarikciTeklif.ImageAlign = ContentAlignment.MiddleLeft;
            btnTedarikciTeklif.Location = new Point(0, 440);
            btnTedarikciTeklif.Name = "btnTedarikciTeklif";
            btnTedarikciTeklif.Padding = new Padding(12, 0, 0, 0);
            btnTedarikciTeklif.Size = new Size(220, 60);
            btnTedarikciTeklif.TabIndex = 8;
            btnTedarikciTeklif.Text = "  Tedarikçi Teklifleri";
            btnTedarikciTeklif.TextAlign = ContentAlignment.MiddleLeft;
            btnTedarikciTeklif.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTedarikciTeklif.UseVisualStyleBackColor = true;
            btnTedarikciTeklif.Click += btnTedarikciTeklif_Click;
            // 
            // btnMalzemeTalep
            // 
            btnMalzemeTalep.Dock = DockStyle.Top;
            btnMalzemeTalep.FlatAppearance.BorderSize = 0;
            btnMalzemeTalep.FlatStyle = FlatStyle.Flat;
            btnMalzemeTalep.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMalzemeTalep.ForeColor = SystemColors.HighlightText;
            btnMalzemeTalep.Image = Properties.Resources.malzeme_talep;
            btnMalzemeTalep.ImageAlign = ContentAlignment.MiddleLeft;
            btnMalzemeTalep.Location = new Point(0, 380);
            btnMalzemeTalep.Name = "btnMalzemeTalep";
            btnMalzemeTalep.Padding = new Padding(12, 0, 0, 0);
            btnMalzemeTalep.Size = new Size(220, 60);
            btnMalzemeTalep.TabIndex = 7;
            btnMalzemeTalep.Text = "  Malzeme Talepleri";
            btnMalzemeTalep.TextAlign = ContentAlignment.MiddleLeft;
            btnMalzemeTalep.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMalzemeTalep.UseVisualStyleBackColor = true;
            btnMalzemeTalep.Click += btnMalzemeTalep_Click;
            // 
            // btnMalzemeKayit
            // 
            btnMalzemeKayit.Dock = DockStyle.Top;
            btnMalzemeKayit.FlatAppearance.BorderSize = 0;
            btnMalzemeKayit.FlatStyle = FlatStyle.Flat;
            btnMalzemeKayit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMalzemeKayit.ForeColor = SystemColors.HighlightText;
            btnMalzemeKayit.Image = Properties.Resources.malzeme_kayit;
            btnMalzemeKayit.ImageAlign = ContentAlignment.MiddleLeft;
            btnMalzemeKayit.Location = new Point(0, 320);
            btnMalzemeKayit.Name = "btnMalzemeKayit";
            btnMalzemeKayit.Padding = new Padding(12, 0, 0, 0);
            btnMalzemeKayit.Size = new Size(220, 60);
            btnMalzemeKayit.TabIndex = 6;
            btnMalzemeKayit.Text = "  Malzeme Kayıtları";
            btnMalzemeKayit.TextAlign = ContentAlignment.MiddleLeft;
            btnMalzemeKayit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMalzemeKayit.UseVisualStyleBackColor = true;
            btnMalzemeKayit.Click += btnMalzemeKayit_Click;
            // 
            // btnMalzemeKullanim
            // 
            btnMalzemeKullanim.Dock = DockStyle.Top;
            btnMalzemeKullanim.FlatAppearance.BorderSize = 0;
            btnMalzemeKullanim.FlatStyle = FlatStyle.Flat;
            btnMalzemeKullanim.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMalzemeKullanim.ForeColor = SystemColors.HighlightText;
            btnMalzemeKullanim.Image = Properties.Resources.malzeme_takip;
            btnMalzemeKullanim.ImageAlign = ContentAlignment.MiddleLeft;
            btnMalzemeKullanim.Location = new Point(0, 260);
            btnMalzemeKullanim.Name = "btnMalzemeKullanim";
            btnMalzemeKullanim.Padding = new Padding(12, 0, 0, 0);
            btnMalzemeKullanim.Size = new Size(220, 60);
            btnMalzemeKullanim.TabIndex = 5;
            btnMalzemeKullanim.Text = "  Envanter Takip";
            btnMalzemeKullanim.TextAlign = ContentAlignment.MiddleLeft;
            btnMalzemeKullanim.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMalzemeKullanim.UseVisualStyleBackColor = true;
            btnMalzemeKullanim.Click += btnMalzemeKullanim_Click;
            // 
            // btnTedarikciKayit
            // 
            btnTedarikciKayit.Dock = DockStyle.Top;
            btnTedarikciKayit.FlatAppearance.BorderSize = 0;
            btnTedarikciKayit.FlatStyle = FlatStyle.Flat;
            btnTedarikciKayit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTedarikciKayit.ForeColor = SystemColors.HighlightText;
            btnTedarikciKayit.Image = Properties.Resources.tedarikci_kayit;
            btnTedarikciKayit.ImageAlign = ContentAlignment.MiddleLeft;
            btnTedarikciKayit.Location = new Point(0, 200);
            btnTedarikciKayit.Name = "btnTedarikciKayit";
            btnTedarikciKayit.Padding = new Padding(12, 0, 0, 0);
            btnTedarikciKayit.Size = new Size(220, 60);
            btnTedarikciKayit.TabIndex = 3;
            btnTedarikciKayit.Text = "  Tedarikçi Yönetim";
            btnTedarikciKayit.TextAlign = ContentAlignment.MiddleLeft;
            btnTedarikciKayit.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTedarikciKayit.UseVisualStyleBackColor = true;
            btnTedarikciKayit.Click += btnTedarikciKayit_Click;
            // 
            // btnDepartman
            // 
            btnDepartman.Dock = DockStyle.Top;
            btnDepartman.FlatAppearance.BorderSize = 0;
            btnDepartman.FlatStyle = FlatStyle.Flat;
            btnDepartman.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDepartman.ForeColor = SystemColors.HighlightText;
            btnDepartman.Image = Properties.Resources.departman_yonetim;
            btnDepartman.ImageAlign = ContentAlignment.MiddleLeft;
            btnDepartman.Location = new Point(0, 140);
            btnDepartman.Name = "btnDepartman";
            btnDepartman.Padding = new Padding(12, 0, 0, 0);
            btnDepartman.Size = new Size(220, 60);
            btnDepartman.TabIndex = 2;
            btnDepartman.Text = "  Departman Yönetim";
            btnDepartman.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartman.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDepartman.UseVisualStyleBackColor = true;
            btnDepartman.Click += btnDepartman_Click;
            // 
            // btnUsers
            // 
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnUsers.ForeColor = SystemColors.HighlightText;
            btnUsers.Image = Properties.Resources.kullanicilar;
            btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsers.Location = new Point(0, 80);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(12, 0, 0, 0);
            btnUsers.Size = new Size(220, 60);
            btnUsers.TabIndex = 1;
            btnUsers.Text = "  Kullanıcı Yönetim";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 80);
            panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(30, 8);
            label1.Name = "label1";
            label1.Size = new Size(157, 63);
            label1.TabIndex = 0;
            label1.Text = "SATIN ALMA\r\nVE\r\nMAL KAYIT SİSTEMİ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(51, 51, 76);
            panelTitleBar.Controls.Add(btnCloseChildForm);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(220, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(975, 80);
            panelTitleBar.TabIndex = 1;
            // 
            // btnCloseChildForm
            // 
            btnCloseChildForm.Dock = DockStyle.Left;
            btnCloseChildForm.FlatAppearance.BorderSize = 0;
            btnCloseChildForm.FlatStyle = FlatStyle.Flat;
            btnCloseChildForm.Image = Properties.Resources.kapama_tusu;
            btnCloseChildForm.Location = new Point(0, 0);
            btnCloseChildForm.Name = "btnCloseChildForm";
            btnCloseChildForm.Size = new Size(42, 80);
            btnCloseChildForm.TabIndex = 1;
            btnCloseChildForm.UseVisualStyleBackColor = true;
            btnCloseChildForm.Click += btnCloseChildForm_Click;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = SystemColors.HighlightText;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(975, 80);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ANA SAYFA";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelDesktopPane
            // 
            panelDesktopPane.Controls.Add(lblOgrenciBilgisi);
            panelDesktopPane.Dock = DockStyle.Fill;
            panelDesktopPane.Location = new Point(220, 80);
            panelDesktopPane.Name = "panelDesktopPane";
            panelDesktopPane.Size = new Size(975, 604);
            panelDesktopPane.TabIndex = 2;
            // 
            // lblOgrenciBilgisi
            // 
            lblOgrenciBilgisi.Anchor = AnchorStyles.None;
            lblOgrenciBilgisi.AutoSize = true;
            lblOgrenciBilgisi.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblOgrenciBilgisi.Location = new Point(145, 195);
            lblOgrenciBilgisi.Name = "lblOgrenciBilgisi";
            lblOgrenciBilgisi.Size = new Size(672, 80);
            lblOgrenciBilgisi.TabIndex = 0;
            lblOgrenciBilgisi.Text = "\r\nPROJE ADI: SATIN ALMA VE MAL KAYIT SİSTEMİ";
            lblOgrenciBilgisi.TextAlign = ContentAlignment.MiddleCenter;
            lblOgrenciBilgisi.Click += lblOgrenciBilgisi_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 684);
            Controls.Add(panelDesktopPane);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1211, 723);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satın Alma ve Mal Kayıt Sistemi";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelDesktopPane.ResumeLayout(false);
            panelDesktopPane.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private Button btnUsers;
        private Button btnZimmet;
        private Button btnTedarikciTeklif;
        private Button btnMalzemeKayit;
        private Button btnMalzemeKullanim;
        private Button btnTedarikciKayit;
        private Button btnDepartman;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label label1;
        private Panel panelDesktopPane;
        private Button btnCloseChildForm;
        private Button btnMalzemeTalep;
        private Button btnHurda;
        private Label lblOgrenciBilgisi;
        private Button btnRaporlama;
    }
}
