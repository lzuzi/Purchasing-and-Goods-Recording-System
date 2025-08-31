using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi
{
    public partial class LoginForm : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public LoginForm()
        {
            InitializeComponent();
        }

        // X tuşuna basıldığında formun kapatıldığından emin olalım.
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /*
         * Kullanıcı adı ve şifreyi kullanıcı girdilerinden alarak belirli kontroller yapalım.
         * Kullanıcı adı veya şifre boş mu?
         * Kullanıcı adı ile eşleşen bir kullanıcı var mı?
         * Kullanıcı adı ile eşleşen bir kullancısı var ise şifresi doğru mu?
        */
        private void girisButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string usernameQuery = "SELECT COUNT(1) FROM KULLANICI WHERE KullaniciAdi= @username";
                SqlCommand usernameCommand = new SqlCommand(usernameQuery, connection);
                usernameCommand.Parameters.AddWithValue("@username", username);

                int usernameExists = (int)usernameCommand.ExecuteScalar();

                if (usernameExists == 0)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string passwordQuery = "SELECT COUNT(1) FROM KULLANICI WHERE KullaniciAdi = @username AND KullaniciSifre = @password";
                    SqlCommand passwordCommand = new SqlCommand(passwordQuery, connection);
                    passwordCommand.Parameters.AddWithValue("@username", username);
                    passwordCommand.Parameters.AddWithValue("@password", password);

                    int isPasswordCorrect = (int)passwordCommand.ExecuteScalar();

                    if (isPasswordCorrect == 1)
                    {
                        string roleQuery = "SELECT KullaniciGrubu FROM KULLANICI WHERE KullaniciAdi = @username AND KullaniciSifre = @password";
                        SqlCommand roleCommand = new SqlCommand(roleQuery, connection);
                        roleCommand.Parameters.AddWithValue("@username", username);
                        roleCommand.Parameters.AddWithValue("@password", password);
                        SqlDataReader reader = roleCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            string role = reader["KullaniciGrubu"].ToString();

                            MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            UserSession.KullaniciAdi = username;
                            UserSession.KullaniciGrubu = role;

                            MainForm mainForm = new MainForm(role);
                            this.Hide();
                            mainForm.ShowDialog();

                            this.Close();
                            connection.Close();
                        }
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}