using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class MalzemeKayitYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Tedarikçi Teklif ID ComboBox'unu birkaç yerde güncelleyeceğiz dışarı alalım.
        private string tedarikciTeklifQuery = "SELECT " +
                "CASE WHEN C.MalzemeAdi IS NULL THEN CONCAT(A.TeklifID, ' - ', B.TalepKayitsizMalzemeID) " +
                "ELSE CONCAT(A.TeklifID, ' - ', C.MalzemeAdi) END AS TeklifMalzemeID " +
                "FROM TEDARIKCITEKLIF A " +
                "INNER JOIN TALEPLER B ON A.TeklifTalepID = B.TalepID " +
                "LEFT JOIN MALZEMELER C ON B.TalepKayitliMalzemeID = C.MalzemeID " +
                "WHERE (A.KabulEdilenTeklif > 0) AND (A.TeklifMalzemeKayitID IS NULL OR A.TeklifMalzemeKayitID = 0) " +
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
        public MalzemeKayitYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(MalzemeKayitYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void MalzemeKayitYonetim_Load(object sender, EventArgs e)
        {
            MalzemeListele();

            // ComboBox'lar için SQL sorguları.
            string malzemeAdiQuery = "SELECT MalzemeAdi FROM MALZEMELER GROUP BY MalzemeAdi";
            string malzemeTedarikciAdiQuery = "SELECT CONCAT(TedarikciID, ' - ', TedarikciAdi) AS TedarikciIDAdi FROM TEDARIKCI";

            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "MalzemeAdi");
            ComboBoxDoldur(cmbMalzemeTedarikciID, malzemeTedarikciAdiQuery, "TedarikciIDAdi");
            ComboBoxDoldur(cmbTedarikciTeklifID, tedarikciTeklifQuery, "TeklifMalzemeID");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void MalzemeListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.MalzemeID, A.MalzemeAdi, A.MalzemeGirisStokMiktari, " +
                        "A.MalzemeKalanStokMiktari, A.MalzemeSatinAlimTarihi, A.MalzemeSonKullanmaTarihi, CONCAT(B.TedarikciID, ' - ', + B.TedarikciAdi) AS TedarikciIDAdi, " +
                        "A.MalzemeTeklifID " +
                        "FROM MALZEMELER A " +
                        "INNER JOIN TEDARIKCI B ON A.MalzemeTedarikciID = B.TedarikciID " +
                        "WHERE A.MalzemeKalanStokMiktari > 0" +
                        "AND ISNULL(A.MalzemeHurdaID, 0) = 0;", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvMalzemeKayit.DataSource = dataTable;
                    dgvMalzemeKayit.AutoResizeColumns();
                    dgvMalzemeKayit.Refresh();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }
        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvMalzemeKayit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvMalzemeKayit.CurrentRow.Selected = true;
            txtMalzemeID.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeID"].Value?.ToString() ?? "";
            cmbMalzemeAdi.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeAdi"].Value?.ToString() ?? "";
            txtMalzemeGirisStokMiktari.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeGirisStokMiktari"].Value?.ToString() ?? "";
            txtMalzemeKalanStokMiktari.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeKalanStokMiktari"].Value?.ToString() ?? "";
            dtpMalzemeSatinAlimTarihi.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeSatinAlimTarihi"].Value?.ToString() ?? "";
            dtpMalzemeSonKullanimTarihi.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["MalzemeSonKullanmaTarihi"].Value?.ToString() ?? "";
            cmbMalzemeTedarikciID.Text = dgvMalzemeKayit.Rows[e.RowIndex].Cells["TedarikciIDAdi"].Value?.ToString() ?? "";
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

        // TextBox'ları temizlemek için yeni metod oluşturalım, istediğimizde çağırabiliriz.
        private void TextBoxTemizleme()
        {
            txtMalzemeID.Text = null;
            cmbMalzemeAdi.Text = null;
            txtMalzemeGirisStokMiktari.Text = null;
            txtMalzemeKalanStokMiktari.Text = null;
            dtpMalzemeSatinAlimTarihi.Text = null;
            dtpMalzemeSonKullanimTarihi.Text = null;
            cmbMalzemeTedarikciID.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Yeni malzeme ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string malzemeID = txtMalzemeID.Text.Trim();
            string malzemeAdi = cmbMalzemeAdi.Text.Trim();

            string textMalzemeStokGirisMiktari = txtMalzemeGirisStokMiktari.Text.Trim();
            string textMalzemeKalanStokMiktari = txtMalzemeKalanStokMiktari.Text.Trim();
            int malzemeStokGirisMiktari;
            int malzemeKalanStokMiktari;

            if (string.IsNullOrEmpty(textMalzemeStokGirisMiktari) || string.IsNullOrEmpty(textMalzemeKalanStokMiktari))
            {
                malzemeStokGirisMiktari = 0;
                malzemeKalanStokMiktari = 0;
            }
            else
            {
                malzemeStokGirisMiktari = Convert.ToInt32(textMalzemeStokGirisMiktari);
                malzemeKalanStokMiktari = Convert.ToInt32(textMalzemeKalanStokMiktari);
            }

            DateTime malzemeSatinAlimTarihi = dtpMalzemeSatinAlimTarihi.Value;
            DateTime malzemeSonKullanimTarihi = dtpMalzemeSonKullanimTarihi.Value;
            string malzemeTedarikciAdi = cmbMalzemeTedarikciID.Text.Trim();
            string malzemeTedarikciID = malzemeTedarikciAdi.Split(" - ")[0];

            string malzemeTedarikciTeklifAdi = cmbTedarikciTeklifID.Text.Trim();
            string malzemeTedarikciTeklifID;
            if (string.IsNullOrEmpty(malzemeTedarikciTeklifAdi))
            {
                malzemeTedarikciTeklifID = null;
            }
            else
            {
                malzemeTedarikciTeklifID = malzemeTedarikciTeklifAdi.Split(" - ")[0];
            }

            if (!string.IsNullOrEmpty(malzemeID))
            {
                MessageBox.Show("Malzeme ID alanı boş olmalıdır. Metin Alanlarını Temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (malzemeStokGirisMiktari <= 0 || (malzemeStokGirisMiktari != malzemeKalanStokMiktari))
            {
                MessageBox.Show("Malzeme Stok Giriş Miktarı 0'dan küçük olamaz veya Malzeme Stok Giriş Miktarı ile Malzeme Kalan Stok Miktarı aynı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(malzemeAdi) || string.IsNullOrEmpty(textMalzemeStokGirisMiktari) || string.IsNullOrEmpty(textMalzemeKalanStokMiktari) || string.IsNullOrEmpty(malzemeTedarikciAdi))
                {
                    MessageBox.Show("Malzeme Adı, Malzeme Giriş Stok Miktarı, Malzeme Kalan Stok Miktarı, Malzeme Satın Alım Tarihi, Malzeme Son Kullanım Tarihi, " +
                        " Malzeme Tedarikçi ID alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string query = "INSERT INTO MALZEMELER (MalzemeAdi, MalzemeGirisStokMiktari, MalzemeKalanStokMiktari, MalzemeSatinAlimTarihi, " +
                        "MalzemeSonKullanmaTarihi, MalzemeTedarikciID, MalzemeHurdaID, MalzemeZimmetID, MalzemeTeklifID) " +
                        "VALUES(@malzemeAdi, @malzemeStokGirisMiktari, @malzemeKalanStokMiktari, @malzemeSatinAlimTarihi, " +
                        "@malzemeSonKullanimTarihi, @malzemeTedarikciID, NULL, NULL, @malzemeTedarikciTeklifID);" +
                        " " +
                        "SELECT SCOPE_IDENTITY();";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                                cmd.Parameters.AddWithValue("@malzemeStokGirisMiktari", malzemeStokGirisMiktari);
                                cmd.Parameters.AddWithValue("@malzemeKalanStokMiktari", malzemeKalanStokMiktari);
                                cmd.Parameters.AddWithValue("@malzemeSatinAlimTarihi", malzemeSatinAlimTarihi);
                                cmd.Parameters.AddWithValue("@malzemeSonKullanimTarihi", malzemeSonKullanimTarihi);
                                cmd.Parameters.AddWithValue("@malzemeTedarikciID", malzemeTedarikciID);

                                if (malzemeTedarikciTeklifID == null || malzemeTedarikciTeklifID == "0")
                                {
                                    cmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", DBNull.Value);
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", malzemeTedarikciTeklifID);
                                }

                                int insertedMalzemeID = Convert.ToInt32(cmd.ExecuteScalar());

                                if (malzemeTedarikciTeklifID != null)
                                {
                                    string updateQuery = @"UPDATE TEDARIKCITEKLIF 
                                       SET TeklifMalzemeKayitID = @insertedMalzemeID 
                                       WHERE TeklifID = @malzemeTedarikciTeklifID";

                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                                    {
                                        updateCmd.Parameters.AddWithValue("@insertedMalzemeID", insertedMalzemeID);
                                        updateCmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", malzemeTedarikciTeklifID);

                                        updateCmd.ExecuteNonQuery();
                                    }
                                }

                                MessageBox.Show("Malzeme başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ComboBoxDoldur(cmbTedarikciTeklifID, tedarikciTeklifQuery, "TeklifMalzemeID");
                                TextBoxTemizleme();
                                MalzemeListele();
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
        }

        // Malzemeyi güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string malzemeID = txtMalzemeID.Text.Trim();
            string malzemeAdi = cmbMalzemeAdi.Text.Trim();

            string textMalzemeStokGirisMiktari = txtMalzemeGirisStokMiktari.Text.Trim();
            string textMalzemeKalanStokMiktari = txtMalzemeKalanStokMiktari.Text.Trim();
            int malzemeStokGirisMiktari;
            int malzemeKalanStokMiktari;

            if (string.IsNullOrEmpty(textMalzemeStokGirisMiktari) || string.IsNullOrEmpty(textMalzemeKalanStokMiktari))
            {
                malzemeStokGirisMiktari = 0;
                malzemeKalanStokMiktari = 0;
            }
            else
            {
                malzemeStokGirisMiktari = Convert.ToInt32(textMalzemeStokGirisMiktari);
                malzemeKalanStokMiktari = Convert.ToInt32(textMalzemeKalanStokMiktari);
            }

            DateTime malzemeSatinAlimTarihi = dtpMalzemeSatinAlimTarihi.Value;
            DateTime malzemeSonKullanimTarihi = dtpMalzemeSonKullanimTarihi.Value;
            string malzemeTedarikciAdi = cmbMalzemeTedarikciID.Text.Trim();
            string malzemeTedarikciID = malzemeTedarikciAdi.Split(" - ")[0];

            string malzemeTedarikciTeklifAdi = cmbTedarikciTeklifID.Text.Trim();
            string malzemeTedarikciTeklifID;
            if (string.IsNullOrEmpty(malzemeTedarikciTeklifAdi))
            {
                malzemeTedarikciTeklifID = null;
            }
            else
            {
                malzemeTedarikciTeklifID = malzemeTedarikciTeklifAdi.Split(" - ")[0];
            }

            if (string.IsNullOrEmpty(malzemeID) || string.IsNullOrEmpty(malzemeAdi) || string.IsNullOrEmpty(textMalzemeStokGirisMiktari) || string.IsNullOrEmpty(textMalzemeKalanStokMiktari) || string.IsNullOrEmpty(malzemeTedarikciAdi))
            {
                MessageBox.Show("MalzemeID, Malzeme Adı, Malzeme Giriş Stok Miktarı, Malzeme Kalan Stok Miktarı, Malzeme Satın Alım Tarihi, Malzeme Son Kullanım Tarihi, " +
                    " Malzeme Tedarikçi ID alanları boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (malzemeStokGirisMiktari <= 0 || malzemeKalanStokMiktari < 0 || (malzemeKalanStokMiktari > malzemeStokGirisMiktari))
            {
                MessageBox.Show("Malzeme Stok Giriş Miktarı ve Malzeme Kalan Stok Miktarı 0'dan küçük olamaz veya Malzeme Kalan Stok Miktarı, Malzeme Stok Giriş Miktarından büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string query = "UPDATE MALZEMELER SET MalzemeAdi = @malzemeAdi, MalzemeGirisStokMiktari = @malzemeStokGirisMiktari, " +
                    "MalzemeKalanStokMiktari = @malzemeKalanStokMiktari, MalzemeSatinAlimTarihi = @malzemeSatinAlimTarihi, " +
                    "MalzemeSonKullanmaTarihi = @malzemeSonKullanimTarihi, MalzemeTedarikciID = @malzemeTedarikciID, " +
                    "MalzemeTeklifID = @malzemeTedarikciTeklifID " +
                    "WHERE MalzemeID = @malzemeID;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                            cmd.Parameters.AddWithValue("@malzemeStokGirisMiktari", malzemeStokGirisMiktari);
                            cmd.Parameters.AddWithValue("@malzemeKalanStokMiktari", malzemeKalanStokMiktari);
                            cmd.Parameters.AddWithValue("@malzemeSatinAlimTarihi", malzemeSatinAlimTarihi);
                            cmd.Parameters.AddWithValue("@malzemeSonKullanimTarihi", malzemeSonKullanimTarihi);
                            cmd.Parameters.AddWithValue("@malzemeTedarikciID", malzemeTedarikciID);
                            cmd.Parameters.AddWithValue("@malzemeID", malzemeID);

                            if (malzemeTedarikciTeklifID == null || malzemeTedarikciTeklifID == "0")
                            {
                                cmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", DBNull.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", malzemeTedarikciTeklifID);
                            }

                            cmd.ExecuteNonQuery();
                        }

                        if (malzemeTedarikciTeklifID != null)
                        {
                            string clearQuery = @"UPDATE TEDARIKCITEKLIF SET TeklifMalzemeKayitID = NULL WHERE TeklifMalzemeKayitID = @malzemeID"
                            ;

                            using (SqlCommand clearCmd = new SqlCommand(clearQuery, connection))
                            {
                                clearCmd.Parameters.AddWithValue("@malzemeID", malzemeID);
                                clearCmd.ExecuteNonQuery();
                            }

                            string updateQuery = "UPDATE TEDARIKCITEKLIF SET TeklifMalzemeKayitID = @malzemeID " +
                                "WHERE TeklifID = @malzemeTedarikciTeklifID;";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@malzemeID", malzemeID);
                                updateCmd.Parameters.AddWithValue("@malzemeTedarikciTeklifID", malzemeTedarikciTeklifID);

                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Malzeme başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ComboBoxDoldur(cmbTedarikciTeklifID, tedarikciTeklifQuery, "TeklifMalzemeID");
                        TextBoxTemizleme();
                        MalzemeListele();

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

        // Malzemeyi silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string malzemeID = txtMalzemeID.Text.Trim();

            if (string.IsNullOrEmpty(malzemeID))
            {
                MessageBox.Show("Malzeme ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string queryCheck = "SELECT * FROM MALZEMELER WHERE MalzemeID = @malzemeID " +
                    "AND ISNULL(MalzemeHurdaID, 0) = 0 " +
                    "AND ISNULL(MalzemeZimmetID, 0) = 0;";

                string queryDelete = "DELETE FROM MALZEMELER WHERE MalzemeID = @malzemeID;";

                string queryUpdate = "UPDATE TEDARIKCITEKLIF SET TeklifMalzemeKayitID = NULL WHERE TeklifMalzemeKayitID = @malzemeID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@malzemeID", malzemeID);

                            using (SqlDataReader reader = cmdCheck.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Close();

                                    using (SqlCommand cmdDelete = new SqlCommand(queryDelete, connection))
                                    {
                                        cmdDelete.Parameters.AddWithValue("@malzemeID", malzemeID);
                                        cmdDelete.ExecuteNonQuery();

                                    }

                                    using (SqlCommand updateCmd = new SqlCommand(queryUpdate, connection))
                                    {
                                        updateCmd.Parameters.AddWithValue("@malzemeID", malzemeID);

                                        updateCmd.ExecuteNonQuery();
                                    }

                                    MessageBox.Show("Malzeme başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ComboBoxDoldur(cmbTedarikciTeklifID, tedarikciTeklifQuery, "TeklifMalzemeID");
                                    TextBoxTemizleme();
                                    MalzemeListele();

                                    connection.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Malzemeye ait zimmet ve/veya hurda kaydı var olduğundan malzeme silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Hata: {ex.Message}");
                        return;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}