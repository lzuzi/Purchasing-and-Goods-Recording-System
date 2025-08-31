using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class ZimmetYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Malzeme Adı ComboBox'unu birkaç yerde güncelleyeceğiz dışarı alalım.
        private string malzemeAdiQuery = "SELECT CONCAT(MalzemeID, ' - ', MalzemeAdi) AS MalzemeIDAdi FROM MALZEMELER " +
                "WHERE (MalzemeZimmetID IS NULL OR MalzemeZimmetID < 1) " +
                "AND (MalzemeHurdaID IS NULL OR MalzemeHurdaID < 1) " +
                ";";

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
        public ZimmetYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(ZimmetYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void ZimmetYonetim_Load(object sender, EventArgs e)
        {
            ZimmetListele();

            // ComboBox'lar için SQL sorguları.
            string kullaniciAdiQuery = "SELECT DISTINCT CONCAT(KullaniciID, ' - ', KullaniciAdSoyad) AS ZimmetliAdi FROM KULLANICI";


            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbZimmetliKullaniciID, kullaniciAdiQuery, "ZimmetliAdi");
            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void ZimmetListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.ZimmetID, CONCAT(C.KullaniciID, ' - ', C.KullaniciAdSoyad) AS KullaniciIDAdSoyad, " +
                        "A.ZimmetTarihi, A.ZimmetAciklama, CONCAT(B.MalzemeID, ' - ', B.MalzemeAdi) AS MalzemeIDAdi FROM ZIMMET A " +
                        "INNER JOIN MALZEMELER B ON A.ZimmetID = B.MalzemeZimmetID " +
                        "INNER JOIN KULLANICI C ON A.ZimmetliKullaniciID = C.KullaniciID;", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvZimmet.DataSource = dataTable;
                    dgvZimmet.AutoResizeColumns();
                    dgvZimmet.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }
        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvZimmet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvZimmet.CurrentRow.Selected = true;
            txtZimmetID.Text = dgvZimmet.Rows[e.RowIndex].Cells["ZimmetID"].Value?.ToString() ?? "";
            cmbZimmetliKullaniciID.Text = dgvZimmet.Rows[e.RowIndex].Cells["KullaniciIDAdSoyad"].Value?.ToString() ?? "";
            dtpZimmetTarihi.Text = dgvZimmet.Rows[e.RowIndex].Cells["ZimmetTarihi"].Value?.ToString() ?? "";
            txtZimmetAciklama.Text = dgvZimmet.Rows[e.RowIndex].Cells["ZimmetAciklama"].Value?.ToString() ?? "";
            cmbMalzemeAdi.Text = dgvZimmet.Rows[e.RowIndex].Cells["MalzemeIDAdi"].Value?.ToString() ?? "";
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                    return;
                }
            }
        }

        // TextBox'ları temizlemek için yeni metod oluşturalım, istediğimizde çağırabiliriz.
        private void TextBoxTemizleme()
        {
            txtZimmetID.Text = null;
            cmbZimmetliKullaniciID.Text = null;
            dtpZimmetTarihi.Text = null;
            cmbMalzemeAdi.Text = null;
            txtZimmetAciklama.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında oluşturduğumuz metodu çağıralım.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Zimmet ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string zimmetID = txtZimmetID.Text.Trim();

            string zimmetliKullaniciAdi = cmbZimmetliKullaniciID.Text.Trim();
            string zimmetliKullaniciID = zimmetliKullaniciAdi.Split(" - ")[0];

            DateTime zimmetTarihi = dtpZimmetTarihi.Value;
            string zimmetAciklama = txtZimmetAciklama.Text.Trim();

            string malzemeAdi = cmbMalzemeAdi.Text.Trim();
            string malzemeID = malzemeAdi.Split(" - ")[0];

            if (!string.IsNullOrEmpty(zimmetID))
            {
                MessageBox.Show("Zimmet ID alanı boş olmalıdır. Metin alanlarını temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(malzemeAdi) || string.IsNullOrEmpty(zimmetliKullaniciAdi))
                {
                    MessageBox.Show("Malzeme Adı ve Zimmetli Kişi ve Zimmet Tarihi alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                var updateCommand = new SqlCommand(
                                    "INSERT INTO ZIMMET (ZimmetliKullaniciID, ZimmetTarihi, ZimmetAciklama) " +
                                    "VALUES (@zimmetliKullaniciID, @zimmetTarihi, @zimmetAciklama) " +
                                    ";" +
                                    "SELECT SCOPE_IDENTITY();", connection, transaction);
                                updateCommand.Parameters.AddWithValue("@zimmetliKullaniciID", zimmetliKullaniciID);
                                updateCommand.Parameters.AddWithValue("@zimmetTarihi", zimmetTarihi);
                                updateCommand.Parameters.AddWithValue("@zimmetAciklama", zimmetAciklama);

                                int insertedId = Convert.ToInt32(updateCommand.ExecuteScalar());

                                var updateMalzemeler = new SqlCommand(
                                    "UPDATE MALZEMELER SET MalzemeZimmetID = @insertedId WHERE MalzemeID = @malzemeID", connection, transaction);
                                updateMalzemeler.Parameters.AddWithValue("@insertedId", insertedId);
                                updateMalzemeler.Parameters.AddWithValue("@malzemeID", malzemeID);
                                updateMalzemeler.ExecuteNonQuery();

                                transaction.Commit();
                                MessageBox.Show("Zimmet eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
                                TextBoxTemizleme();
                                ZimmetListele();
                            }
                            catch
                            {
                                MessageBox.Show("Veri tabanı hatası.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
        }

        // Zimmet güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string zimmetID = txtZimmetID.Text.Trim();

            string zimmetliKullaniciAdi = cmbZimmetliKullaniciID.Text.Trim();
            string zimmetliKullaniciID = zimmetliKullaniciAdi.Split(" - ")[0];

            DateTime zimmetTarihi = dtpZimmetTarihi.Value;
            string zimmetAciklama = txtZimmetAciklama.Text.Trim();

            string malzemeAdi = cmbMalzemeAdi.Text.Trim();
            string malzemeID = malzemeAdi.Split(" - ")[0];

            if (string.IsNullOrEmpty(zimmetID) || !string.IsNullOrEmpty(malzemeAdi))
            {
                MessageBox.Show("Zimmet ID alanı boş olamaz veya Malzeme Adı alanı dolu olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMalzemeAdi.Text = null;
                return;
            }
            else
            {
                string query = "UPDATE ZIMMET SET ZimmetliKullaniciID = @zimmetliKullaniciID, ZimmetTarihi = @zimmetTarihi, ZimmetAciklama = @zimmetAciklama " +
                    "WHERE ZimmetID = @zimmetID;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@zimmetliKullaniciID", zimmetliKullaniciID);
                            cmd.Parameters.AddWithValue("@zimmetTarihi", zimmetTarihi);
                            cmd.Parameters.AddWithValue("@zimmetAciklama", zimmetAciklama);
                            cmd.Parameters.AddWithValue("@zimmetID", zimmetID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Zimmet başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxTemizleme();
                            ZimmetListele();
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

        // Zimmet silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string zimmetID = txtZimmetID.Text.Trim();

            if (string.IsNullOrEmpty(zimmetID))
            {
                MessageBox.Show("Zimmet ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var updateCommand = new SqlCommand(
                                "UPDATE MALZEMELER SET MalzemeZimmetID = NULL WHERE MalzemeZimmetID = @zimmetID", connection, transaction);
                            updateCommand.Parameters.AddWithValue("@zimmetID", zimmetID);
                            updateCommand.ExecuteNonQuery();

                            var deleteCommand = new SqlCommand(
                                "DELETE FROM ZIMMET WHERE ZimmetID = @zimmetID", connection, transaction);
                            deleteCommand.Parameters.AddWithValue("@zimmetID", zimmetID);
                            deleteCommand.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Zimmet başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
                            TextBoxTemizleme();
                            ZimmetListele();
                        }
                        catch
                        {
                            MessageBox.Show("Veri tabanı hatası.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}