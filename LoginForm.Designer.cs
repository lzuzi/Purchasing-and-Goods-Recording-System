namespace SatinalmaMalKayitSistemi
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            girisButton = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            passwordLabel = new Label();
            usernameLabel = new Label();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // girisButton
            // 
            girisButton.Location = new Point(138, 267);
            girisButton.Name = "girisButton";
            girisButton.Size = new Size(101, 47);
            girisButton.TabIndex = 0;
            girisButton.Text = "Giriş Yap";
            girisButton.UseVisualStyleBackColor = true;
            girisButton.Click += girisButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(passwordLabel);
            panel1.Controls.Add(usernameLabel);
            panel1.Controls.Add(passwordTextBox);
            panel1.Controls.Add(usernameTextBox);
            panel1.Controls.Add(girisButton);
            panel1.Location = new Point(65, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(378, 345);
            panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(83, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 139);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(101, 219);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(30, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Şifre";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(101, 170);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(73, 15);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Kullanıcı Adı";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(104, 237);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "şifrenizi giriniz";
            passwordTextBox.Size = new Size(168, 23);
            passwordTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(104, 188);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "kullanıcı adınızı giriniz";
            usernameTextBox.Size = new Size(168, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // LoginForm
            // 
            AcceptButton = girisButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(239, 243, 246);
            ClientSize = new Size(508, 450);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(524, 489);
            MinimumSize = new Size(524, 489);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satın Alma ve Mal Kayıt Sistemi Giriş Paneli";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button girisButton;
        private Panel panel1;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label passwordLabel;
        private Label usernameLabel;
        private PictureBox pictureBox1;
    }
}