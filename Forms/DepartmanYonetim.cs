using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class DepartmanYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // ComboBox'ta gösterilecek öğelerin metin bilgisini tutalım ve doğrudan görüntülenmesini sağlayalım.
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public DepartmanYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(DepartmanYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void DepartmanYonetim_Load(object sender, EventArgs e)
        {
            DepartmanListele();

            // ComboBox'lar için SQL sorguları.
            string departmanSorumlusuAdiQuery = "SELECT CONCAT(KullaniciID, ' - ', KullaniciAdSoyad) AS KullaniciIDAdSoyad FROM KULLANICI";

            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbDepartmanSorumluID, departmanSorumlusuAdiQuery, "KullaniciIDAdSoyad");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void DepartmanListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.DepartmanID, A.DepartmanAdi, " +
                        "CONCAT(B.KullaniciID, ' - ', B.KullaniciAdSoyad) AS DepartmanSorumlusu " +
                        "FROM DEPARTMAN A INNER JOIN KULLANICI B ON A.DepartmanSorumlusuID = B.KullaniciID", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvDepartman.DataSource = dataTable;
                    dgvDepartman.AutoResizeColumns();
                    dgvDepartman.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }
        }

        // Burada datagrid kısmında tıklanan hücreye ait bilgileri yukardaki textboxlara yüklüyoruz.
        private void dgvDepartman_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvDepartman.CurrentRow.Selected = true;
            txtDepartmanId.Text = dgvDepartman.Rows[e.RowIndex].Cells["DepartmanID"].Value?.ToString() ?? "";
            txtDepartmanAdi.Text = dgvDepartman.Rows[e.RowIndex].Cells["DepartmanAdi"].Value?.ToString() ?? "";
            cmbDepartmanSorumluID.Text = dgvDepartman.Rows[e.RowIndex].Cells["DepartmanSorumlusu"].Value?.ToString() ?? "";
        }

        // ComboBox'ların içerisine veri tabanından dönen sonuçları yükleyelim.
        private void ComboBoxDoldur(ComboBox comboBox, string query, string displayColumn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader[displayColumn].ToString());
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                    return;
                }
            }
        }

        // Departman kayıtlı mı?
        private bool IsDepartmanExists(string departmanAdi)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM DEPARTMAN WHERE DepartmanAdi = @departmanAdi";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@departmanAdi", departmanAdi);

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
            txtDepartmanId.Text = null;
            txtDepartmanAdi.Text = null;
            cmbDepartmanSorumluID.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        //Yeni departman ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string departmanID = txtDepartmanId.Text.Trim();
            string departmanAdi = txtDepartmanAdi.Text.Trim();

            string departmanSorumluAdi = cmbDepartmanSorumluID.Text.Trim();
            string departmanSorumluID = departmanSorumluAdi.Split(" - ")[0];

            if (!string.IsNullOrEmpty(departmanID) || string.IsNullOrEmpty(departmanAdi) || string.IsNullOrEmpty(departmanSorumluAdi))
            {
                MessageBox.Show("Departman ID alanı dolu olamaz veya Departman Adı veya Departman Sorumlusu alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmanId.Text = null;
                return;
            }
            else
            {
                if (IsDepartmanExists(departmanAdi) == false)
                {
                    string query = "INSERT INTO DEPARTMAN (DepartmanAdi, DepartmanSorumlusuID) " +
                        "SELECT @departmanAdi, A.KullaniciID FROM KULLANICI A WHERE A.KullaniciID = @departmanSorumluID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@departmanAdi", departmanAdi);
                                cmd.Parameters.AddWithValue("@departmanSorumluID", departmanSorumluID);


                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Departman başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                connection.Close();
                                TextBoxTemizleme();
                                DepartmanListele();
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
                    MessageBox.Show("Bu departman adı zaten kayıtlı. Lütfen başka bir departman adı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Departmanı güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string departmanID = txtDepartmanId.Text.Trim();
            string departmanAdi = txtDepartmanAdi.Text.Trim();

            string departmanSorumluAdi = cmbDepartmanSorumluID.Text.Trim();
            string departmanSorumluID = departmanSorumluAdi.Split(" - ")[0];

            if (string.IsNullOrEmpty(departmanID) || string.IsNullOrEmpty(departmanAdi) || string.IsNullOrEmpty(departmanSorumluAdi))
            {
                MessageBox.Show("Departman ID, Departman Adı veya Departman Sorumlusu alanlarından hiçbiri boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string eskiDepartmanAdi = "";
                string queryGetOldDepartmanName = "SELECT DepartmanAdi FROM DEPARTMAN WHERE DepartmanID = @departmanID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(queryGetOldDepartmanName, connection))
                        {
                            cmd.Parameters.AddWithValue("@departmanID", departmanID);
                            eskiDepartmanAdi = (string)cmd.ExecuteScalar();
                        }
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                }

                if (!string.Equals(eskiDepartmanAdi, departmanAdi, StringComparison.Ordinal))
                {
                    string queryDuplicateName = "SELECT COUNT(1) FROM DEPARTMAN WHERE DepartmanAdi = @departmanAdi AND departmanID != @departmanID";

                    using (SqlConnection connectionDuplicate = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connectionDuplicate.Open();
                            using (SqlCommand cmdDuplicate = new SqlCommand(queryDuplicateName, connectionDuplicate))
                            {
                                cmdDuplicate.Parameters.AddWithValue("@departmanAdi", departmanAdi);
                                cmdDuplicate.Parameters.AddWithValue("@departmanID", departmanID); // Kendi ID'sini hariç tutuyoruz

                                int count = (int)cmdDuplicate.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Departman adı başka bir departman tarafından kullanılmaktadır. Lütfen farklı bir departman adı deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string query = eskiDepartmanAdi != departmanAdi
                    ? "UPDATE DEPARTMAN SET DepartmanAdi = @departmanAdi, DepartmanSorumlusuID = @departmanSorumluID " +
                      "WHERE DepartmanID = @departmanID"
                    : "UPDATE DEPARTMAN SET DepartmanSorumlusuID = @departmanSorumluID " +
                      "WHERE DepartmanID = @departmanID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            if (eskiDepartmanAdi != departmanAdi)
                                cmd.Parameters.AddWithValue("@departmanAdi", departmanAdi);

                            cmd.Parameters.AddWithValue("@departmanSorumluID", departmanSorumluID);
                            cmd.Parameters.AddWithValue("@departmanID", departmanID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Departman başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxTemizleme();
                            DepartmanListele();
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

        // Departmanı silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string departmanID = txtDepartmanId.Text.Trim();

            if (string.IsNullOrEmpty(departmanID))
            {
                MessageBox.Show("Departman ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "DELETE FROM DEPARTMAN WHERE DepartmanID = @departmanID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@departmanID", departmanID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Departman başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();
                            TextBoxTemizleme();
                            DepartmanListele();
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