using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class KullaniciYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public KullaniciYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(KullaniciYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void KullaniciYonetim_Load(object sender, EventArgs e)
        {
            KullaniciListele();
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void KullaniciListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT KullaniciID, KullaniciAdi, KullaniciSifre, KullaniciAdSoyad, KullaniciEposta, KullaniciGrubu FROM KULLANICI", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvUsers.DataSource = dataTable;
                    dgvUsers.AutoResizeColumns();
                    dgvUsers.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }

        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvUsers.CurrentRow.Selected = true;
            txtKullaniciID.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciID"].Value?.ToString() ?? "";
            txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciAdi"].Value?.ToString() ?? "";
            txtPassword.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciSifre"].Value?.ToString() ?? "";
            txtFullName.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciAdSoyad"].Value?.ToString() ?? "";
            txtEmail.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciEposta"].Value?.ToString() ?? "";
            cmbRole.Text = dgvUsers.Rows[e.RowIndex].Cells["KullaniciGrubu"].Value?.ToString() ?? "";
        }

        // Kullanıcı adı veritabanında var mı metodu
        private bool IsKullaniciAdiExists(string kullaniciAdi)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM KULLANICI WHERE KullaniciAdi = @kullaniciAdi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        int count = (int)cmd.ExecuteScalar();
                        exists = (count > 0);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }

            return exists;
        }

        // TextBox'ları temizlemek için yeni metod oluşturalım, istediğimizde çağırabiliriz.
        private void TextBoxTemizleme()
        {
            txtKullaniciID.Text = null;
            txtUsername.Text = null;
            txtPassword.Text = null;
            txtFullName.Text = null;
            txtEmail.Text = null;
            cmbRole.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Yeni kullanıcı ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string kullaniciID = txtKullaniciID.Text.Trim();
            string kullaniciAdi = txtUsername.Text.Trim();
            string kullaniciSifre = txtPassword.Text.Trim();
            string kullaniciAdSoyad = txtFullName.Text.Trim();
            string kullaniciEposta = txtEmail.Text.Trim();
            string kullaniciGrubu = cmbRole.Text.Trim();

            if (!string.IsNullOrEmpty(kullaniciID))
            {
                MessageBox.Show("Kullanıcı ID alanı boş olmalıdır. Metin alanlarını temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(kullaniciSifre) || string.IsNullOrEmpty(kullaniciAdSoyad) || string.IsNullOrEmpty(kullaniciEposta) || string.IsNullOrEmpty(kullaniciGrubu))
                {
                    MessageBox.Show("Kullanıcı adı, şifre, ad-soyad, eposta veya kullanıcı grubu alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (IsKullaniciAdiExists(kullaniciAdi) == false)
                {
                    string query = "INSERT INTO KULLANICI (KullaniciAdi, KullaniciSifre, KullaniciAdSoyad, KullaniciEposta, KullaniciGrubu) " +
                        "VALUES (@kullaniciAdi, @kullaniciSifre, @kullaniciAdSoyad, @kullaniciEposta, @kullaniciGrubu)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                                cmd.Parameters.AddWithValue("@kullaniciSifre", kullaniciSifre);
                                cmd.Parameters.AddWithValue("@kullaniciAdSoyad", kullaniciAdSoyad);
                                cmd.Parameters.AddWithValue("@kullaniciEposta", kullaniciEposta);
                                cmd.Parameters.AddWithValue("@kullaniciGrubu", kullaniciGrubu);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connection.Close();
                                TextBoxTemizleme();
                                KullaniciListele();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hata: {ex.Message}");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı. Lütfen başka bir kullanıcı adı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        // Kullanıcıyı güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string kullaniciID = txtKullaniciID.Text.Trim();
            string kullaniciAdi = txtUsername.Text.Trim();
            string kullaniciSifre = txtPassword.Text.Trim();
            string kullaniciAdSoyad = txtFullName.Text.Trim();
            string kullaniciEposta = txtEmail.Text.Trim();
            string kullaniciGrubu = cmbRole.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(kullaniciSifre) || string.IsNullOrEmpty(kullaniciAdSoyad) || string.IsNullOrEmpty(kullaniciEposta) || string.IsNullOrEmpty(kullaniciGrubu))
            {
                MessageBox.Show("Kullanıcı adı, şifre, ad-soyad, email veya rol alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string eskiKullaniciAdi = "";
                string queryGetOldUsername = "SELECT KullaniciAdi FROM KULLANICI WHERE kullaniciID = @kullaniciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(queryGetOldUsername, connection))
                        {
                            cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                            eskiKullaniciAdi = (string)cmd.ExecuteScalar();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                }

                if (!string.Equals(eskiKullaniciAdi, kullaniciAdi, StringComparison.Ordinal))
                {
                    string queryDuplicateName = "SELECT COUNT(1) FROM KULLANICI WHERE KullaniciAdi = @kullaniciAdi AND kullaniciID != @kullaniciID";

                    using (SqlConnection connectionDuplicate = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connectionDuplicate.Open();
                            using (SqlCommand cmdDuplicate = new SqlCommand(queryDuplicateName, connectionDuplicate))
                            {
                                cmdDuplicate.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                                cmdDuplicate.Parameters.AddWithValue("@kullaniciID", kullaniciID); // Kendi ID'sini hariç tutuyoruz

                                int count = (int)cmdDuplicate.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Kullanıcı adı başka bir kullanıcı tarafından alınmış. Lütfen farklı bir kullanıcı adı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            connectionDuplicate.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hata: {ex.Message}");
                            return;
                        }
                    }
                }

                string query = eskiKullaniciAdi != kullaniciAdi
                    ? "UPDATE KULLANICI SET KullaniciAdi = @kullaniciAdi, KullaniciSifre = @kullaniciSifre, " +
                      "KullaniciAdSoyad = @kullaniciAdSoyad, KullaniciEposta = @kullaniciEposta, KullaniciGrubu = @kullaniciGrubu " +
                      "WHERE kullaniciID = @kullaniciID"
                    : "UPDATE KULLANICI SET KullaniciSifre = @kullaniciSifre, " +
                      "KullaniciAdSoyad = @kullaniciAdSoyad, KullaniciEposta = @kullaniciEposta, KullaniciGrubu = @kullaniciGrubu " +
                      "WHERE kullaniciID = @kullaniciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            if (eskiKullaniciAdi != kullaniciAdi)
                                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                            cmd.Parameters.AddWithValue("@kullaniciSifre", kullaniciSifre);
                            cmd.Parameters.AddWithValue("@kullaniciAdSoyad", kullaniciAdSoyad);
                            cmd.Parameters.AddWithValue("@kullaniciEposta", kullaniciEposta);
                            cmd.Parameters.AddWithValue("@kullaniciGrubu", kullaniciGrubu);
                            cmd.Parameters.AddWithValue("@kullaniciID", kullaniciID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            KullaniciListele();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                }
            }
        }

        // Kullanıcıyı silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (IsKullaniciAdiExists(kullaniciAdi) == true)
                {
                    string query = "DELETE FROM KULLANICI WHERE KullaniciAdi = @kullaniciAdi";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connection.Close();
                                KullaniciListele();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hata: {ex.Message}");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("İlgili kullanıcı adına ait kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}