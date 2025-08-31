using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class HurdaYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Malzeme Adı ComboBox'unu birkaç yerde güncelleyeceğiz dışarı alalım.
        private string malzemeAdiQuery = "SELECT CONCAT(MalzemeID, ' - ', MalzemeAdi) AS MalzemeIDAdi " +
            "FROM MALZEMELER WHERE (MalzemeHurdaID IS NULL OR MalzemeHurdaID < 1)";

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
        public HurdaYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(HurdaYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void HurdaYonetim_Load(object sender, EventArgs e)
        {
            HurdaListele();

            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void HurdaListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.HurdaID, B.MalzemeID, B.MalzemeAdi, A.HurdaTarihi, A.HurdaAciklama FROM HURDA A " +
                        "INNER JOIN MALZEMELER B ON A.HurdaID = B.MalzemeHurdaID;", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvHurda.DataSource = dataTable;
                    dgvHurda.AutoResizeColumns();
                    dgvHurda.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }
        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvHurda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvHurda.CurrentRow.Selected = true;
            txtHurdaID.Text = dgvHurda.Rows[e.RowIndex].Cells["HurdaID"].Value?.ToString() ?? "";
            dtpHurdaTarihi.Text = dgvHurda.Rows[e.RowIndex].Cells["HurdaTarihi"].Value?.ToString() ?? "";
            txtHurdaAciklama.Text = dgvHurda.Rows[e.RowIndex].Cells["HurdaAciklama"].Value?.ToString() ?? "";
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
            txtHurdaID.Text = null;
            dtpHurdaTarihi.Text = null;
            txtHurdaAciklama.Text = null;
            cmbMalzemeAdi.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Hurda ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string hurdaID = txtHurdaID.Text.Trim();
            DateTime hurdaTarihi = dtpHurdaTarihi.Value;
            string hurdaAciklama = txtHurdaAciklama.Text.Trim();
            string malzemeIDAdi = cmbMalzemeAdi.Text.Trim();
            string malzemeAdi = malzemeIDAdi.Split(" - ")[0];

            if (!string.IsNullOrEmpty(hurdaID))
            {
                MessageBox.Show("Hurda ID alanı boş olmalıdır. Metin alanlarını temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(malzemeIDAdi))
                {
                    MessageBox.Show("Malzeme Adı ve Hurda Tarihi alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                    "INSERT INTO HURDA (HurdaTarihi, HurdaAciklama) OUTPUT INSERTED.HurdaID VALUES (@hurdaTarihi, @hurdaAciklama)", connection, transaction);
                                updateCommand.Parameters.AddWithValue("@hurdaTarihi", hurdaTarihi);
                                updateCommand.Parameters.AddWithValue("@hurdaAciklama", hurdaAciklama);

                                // Eklenen HurdaID'yi alıyoruz:
                                int insertedHurdaID = (int)updateCommand.ExecuteScalar();

                                var updateMalzemeler = new SqlCommand(
                                    "UPDATE MALZEMELER SET MalzemeHurdaID = @insertedHurdaID WHERE MalzemeID = @malzemeAdi", connection, transaction);
                                updateMalzemeler.Parameters.AddWithValue("@insertedHurdaID", insertedHurdaID);
                                updateMalzemeler.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                                updateMalzemeler.ExecuteNonQuery();

                                transaction.Commit();
                                MessageBox.Show("Hurda eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
                                TextBoxTemizleme();
                                HurdaListele();
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

        // Hurdayı güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string hurdaID = txtHurdaID.Text.Trim();
            DateTime hurdaTarihi = dtpHurdaTarihi.Value;
            string malzemeIDAdi = cmbMalzemeAdi.Text.Trim();
            string hurdaAciklama = txtHurdaAciklama.Text.Trim();

            if (string.IsNullOrEmpty(hurdaID))
            {
                MessageBox.Show("Hurda ID alanı ve Hurda Tarihi alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(malzemeIDAdi))
            {
                MessageBox.Show("Malzeme Adı alanı dolu olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMalzemeAdi.Text = null;
                return;
            }
            else
            {
                string query = "UPDATE HURDA SET HurdaTarihi = @hurdaTarihi, HurdaAciklama = @hurdaAciklama WHERE HurdaID = @hurdaID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@hurdaTarihi", hurdaTarihi);
                            cmd.Parameters.AddWithValue("@hurdaAciklama", hurdaAciklama);
                            cmd.Parameters.AddWithValue("@hurdaID", hurdaID);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Hurda başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TextBoxTemizleme();
                            HurdaListele();
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

        // Hurdayı silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string hurdaID = txtHurdaID.Text.Trim();
            DateTime hurdaTarihi = dtpHurdaTarihi.Value;
            string hurdaAciklama = txtHurdaAciklama.Text.Trim();

            if (string.IsNullOrEmpty(hurdaID))
            {
                MessageBox.Show("Hurda ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                "UPDATE MALZEMELER SET MalzemeHurdaID = NULL WHERE MalzemeHurdaID = @hurdaID", connection, transaction);
                            updateCommand.Parameters.AddWithValue("@hurdaID", hurdaID);
                            updateCommand.ExecuteNonQuery();

                            var deleteCommand = new SqlCommand(
                                "DELETE FROM HURDA WHERE HurdaID = @hurdaID", connection, transaction);
                            deleteCommand.Parameters.AddWithValue("@hurdaID", hurdaID);
                            deleteCommand.ExecuteNonQuery();

                            transaction.Commit();
                            MessageBox.Show("Hurda başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeIDAdi");
                            TextBoxTemizleme();
                            HurdaListele();
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