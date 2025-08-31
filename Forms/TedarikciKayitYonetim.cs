using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class TedarikciKayitYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public TedarikciKayitYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(TedarikciKayitYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void TedarikciKayitYonetim_Load(object sender, EventArgs e)
        {
            TedarikciListele();
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void TedarikciListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT TedarikciID, TedarikciAdi, TedarikciTelefon, TedarikciAdres FROM TEDARIKCI", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTedarikci.DataSource = dataTable;
                    dgvTedarikci.AutoResizeColumns();
                    dgvTedarikci.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }

        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvTedarikci_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvTedarikci.CurrentRow.Selected = true;
            txtTedarikciID.Text = dgvTedarikci.Rows[e.RowIndex].Cells["TedarikciID"].Value?.ToString() ?? "";
            txtTedarikciAdi.Text = dgvTedarikci.Rows[e.RowIndex].Cells["TedarikciAdi"].Value?.ToString() ?? "";
            txtTedarikciTelefonu.Text = dgvTedarikci.Rows[e.RowIndex].Cells["TedarikciTelefon"].Value?.ToString() ?? "";
            txtTedarikciAdresi.Text = dgvTedarikci.Rows[e.RowIndex].Cells["TedarikciAdres"].Value?.ToString() ?? "";
        }

        // Tedarikçi Kayıtlı mı?
        private bool IsTedarikciExists(string tedarikciAdi)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM TEDARIKCI WHERE TedarikciAdi = @tedarikciAdi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tedarikciAdi", tedarikciAdi);

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
            txtTedarikciID.Text = null;
            txtTedarikciAdi.Text = null;
            txtTedarikciTelefonu.Text = null;
            txtTedarikciAdresi.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Yeni Tedarikçi ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string tedarikciID = txtTedarikciID.Text.Trim();
            string tedarikciAdi = txtTedarikciAdi.Text.Trim();
            string tedarikciTelefonu = txtTedarikciTelefonu.Text.Trim();
            string tedarikciAdresi = txtTedarikciAdresi.Text.Trim();

            if (!string.IsNullOrEmpty(tedarikciID) || string.IsNullOrEmpty(tedarikciAdi) || string.IsNullOrEmpty(tedarikciTelefonu) || string.IsNullOrEmpty(tedarikciAdresi))
            {
                MessageBox.Show("Tedarikçi ID alanı dolu olamaz veya Tedarikçi adı, tedarikçi telefonu veya tedarikçi adresi alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTedarikciID.Text = null;
                return;
            }
            else
            {
                if (IsTedarikciExists(tedarikciAdi) == false)
                {
                    string query = "INSERT INTO TEDARIKCI (TedarikciAdi, TedarikciTelefon, TedarikciAdres) VALUES (@tedarikciAdi, @tedarikciTelefonu, @tedarikciAdresi)";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@tedarikciAdi", tedarikciAdi);
                                cmd.Parameters.AddWithValue("@tedarikciTelefonu", tedarikciTelefonu);
                                cmd.Parameters.AddWithValue("@tedarikciAdresi", tedarikciAdresi);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Tedarikçi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connection.Close();
                                TextBoxTemizleme();
                                TedarikciListele();
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
                    MessageBox.Show("Tedarikçi adı kullanılıyor. Lütfen başka bir tedarikçi adı yazınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Tedarikçiyi güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string tedarikciID = txtTedarikciID.Text.Trim();
            string tedarikciAdi = txtTedarikciAdi.Text.Trim();
            string tedarikciTelefonu = txtTedarikciTelefonu.Text.Trim();
            string tedarikciAdresi = txtTedarikciAdresi.Text.Trim();

            if (string.IsNullOrEmpty(tedarikciID) || string.IsNullOrEmpty(tedarikciAdi) || string.IsNullOrEmpty(tedarikciTelefonu) || string.IsNullOrEmpty(tedarikciAdresi))
            {
                MessageBox.Show("Tedarikçi ID, Tedarikçi adı, tedarikçi telefonu veya tedarikçi adresi alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                // Veritabanından eski tedarikçi adını alalım
                string eskiTedarikciAdi = "";
                string queryGetOldTedarikciName = "SELECT TedarikciAdi FROM TEDARIKCI WHERE TedarikciID = @tedarikciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(queryGetOldTedarikciName, connection))
                        {
                            cmd.Parameters.AddWithValue("@tedarikciID", tedarikciID);
                            eskiTedarikciAdi = (string)cmd.ExecuteScalar();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                }

                if (!string.Equals(eskiTedarikciAdi, tedarikciAdi, StringComparison.Ordinal))
                {
                    string queryDuplicateName = "SELECT COUNT(1) FROM TEDARIKCI WHERE TedarikciAdi = @tedarikciAdi AND TedarikciID != @tedarikciID";

                    using (SqlConnection connectionDuplicate = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connectionDuplicate.Open();
                            using (SqlCommand cmdDuplicate = new SqlCommand(queryDuplicateName, connectionDuplicate))
                            {
                                cmdDuplicate.Parameters.AddWithValue("@tedarikciAdi", tedarikciAdi);
                                cmdDuplicate.Parameters.AddWithValue("@tedarikciID", tedarikciID); // Kendi ID'sini hariç tutuyoruz

                                int count = (int)cmdDuplicate.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Tedarikçi adı başka bir tedarikçi tarafından alınmış. Lütfen farklı bir tedarikçi adı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = eskiTedarikciAdi != tedarikciAdi
                    ? "UPDATE TEDARIKCI SET TedarikciAdi = @tedarikciAdi, TedarikciTelefon = @tedarikciTelefonu, " +
                    "TedarikciAdres = @tedarikciAdresi WHERE TedarikciID = @tedarikciID"
                    : "UPDATE TEDARIKCI SET TedarikciTelefon = @tedarikciTelefonu, " +
                    "TedarikciAdres = @tedarikciAdresi WHERE TedarikciID = @tedarikciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            if (eskiTedarikciAdi != tedarikciAdi)
                                cmd.Parameters.AddWithValue("@tedarikciAdi", tedarikciAdi);

                            cmd.Parameters.AddWithValue("@tedarikciTelefonu", tedarikciTelefonu);
                            cmd.Parameters.AddWithValue("@tedarikciAdresi", tedarikciAdresi);
                            cmd.Parameters.AddWithValue("@tedarikciID", tedarikciID);


                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Tedarikçi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxTemizleme();
                            TedarikciListele();
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

        // Tedarikçiyi silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string tedarikciID = txtTedarikciID.Text.Trim();

            if (string.IsNullOrEmpty(tedarikciID))
            {
                MessageBox.Show("Tedarikçi ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "DELETE FROM TEDARIKCI WHERE TedarikciID = @tedarikciID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@tedarikciID", tedarikciID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Tedarikçi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();
                            TextBoxTemizleme();
                            TedarikciListele();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                }
            }
        }
    }
}