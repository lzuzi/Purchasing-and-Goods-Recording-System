namespace SatinalmaMalKayitSistemi.Forms
{
    partial class EnvanterTakipYonetim
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
            btnStokluMalzemeler = new Button();
            dgvEnvanter = new DataGridView();
            btnStokluZimmetsizMalzemeler = new Button();
            btnStoksuzMalzemeler = new Button();
            btnHurdaMalzemeler = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEnvanter).BeginInit();
            SuspendLayout();
            // 
            // btnStokluMalzemeler
            // 
            btnStokluMalzemeler.Anchor = AnchorStyles.Top;
            btnStokluMalzemeler.Location = new Point(74, 54);
            btnStokluMalzemeler.Name = "btnStokluMalzemeler";
            btnStokluMalzemeler.Size = new Size(177, 59);
            btnStokluMalzemeler.TabIndex = 90;
            btnStokluMalzemeler.Text = "Stoklu Malzemeler";
            btnStokluMalzemeler.UseVisualStyleBackColor = true;
            btnStokluMalzemeler.Click += btnStokluMalzemeler_Click;
            // 
            // dgvEnvanter
            // 
            dgvEnvanter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEnvanter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnvanter.Location = new Point(32, 172);
            dgvEnvanter.Name = "dgvEnvanter";
            dgvEnvanter.Size = new Size(793, 310);
            dgvEnvanter.TabIndex = 80;
            // 
            // btnStokluZimmetsizMalzemeler
            // 
            btnStokluZimmetsizMalzemeler.Anchor = AnchorStyles.Top;
            btnStokluZimmetsizMalzemeler.Location = new Point(440, 54);
            btnStokluZimmetsizMalzemeler.Name = "btnStokluZimmetsizMalzemeler";
            btnStokluZimmetsizMalzemeler.Size = new Size(177, 59);
            btnStokluZimmetsizMalzemeler.TabIndex = 82;
            btnStokluZimmetsizMalzemeler.Text = "Stoklu Zimmetsiz Malzemeler";
            btnStokluZimmetsizMalzemeler.UseVisualStyleBackColor = true;
            btnStokluZimmetsizMalzemeler.Click += btnStokluZimmetsizMalzemeler_Click;
            // 
            // btnStoksuzMalzemeler
            // 
            btnStoksuzMalzemeler.Anchor = AnchorStyles.Top;
            btnStoksuzMalzemeler.Location = new Point(257, 54);
            btnStoksuzMalzemeler.Name = "btnStoksuzMalzemeler";
            btnStoksuzMalzemeler.Size = new Size(177, 59);
            btnStoksuzMalzemeler.TabIndex = 81;
            btnStoksuzMalzemeler.Text = "Stoksuz Malzemeler";
            btnStoksuzMalzemeler.UseVisualStyleBackColor = true;
            btnStoksuzMalzemeler.Click += btnStoksuzMalzemeler_Click;
            // 
            // btnHurdaMalzemeler
            // 
            btnHurdaMalzemeler.Anchor = AnchorStyles.Top;
            btnHurdaMalzemeler.Location = new Point(623, 54);
            btnHurdaMalzemeler.Name = "btnHurdaMalzemeler";
            btnHurdaMalzemeler.Size = new Size(177, 59);
            btnHurdaMalzemeler.TabIndex = 91;
            btnHurdaMalzemeler.Text = "Hurda Malzemeler";
            btnHurdaMalzemeler.UseVisualStyleBackColor = true;
            btnHurdaMalzemeler.Click += btnHurdaMalzemeler_Click;
            // 
            // EnvanterTakipYonetim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 501);
            Controls.Add(btnHurdaMalzemeler);
            Controls.Add(btnStokluMalzemeler);
            Controls.Add(dgvEnvanter);
            Controls.Add(btnStokluZimmetsizMalzemeler);
            Controls.Add(btnStoksuzMalzemeler);
            Name = "EnvanterTakipYonetim";
            Text = "Envanter Takip Sistemi";
            ((System.ComponentModel.ISupportInitialize)dgvEnvanter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStokluMalzemeler;
        private DataGridView dgvEnvanter;
        private Button btnStokluZimmetsizMalzemeler;
        private Button btnStoksuzMalzemeler;
        private Button btnHurdaMalzemeler;
    }
}