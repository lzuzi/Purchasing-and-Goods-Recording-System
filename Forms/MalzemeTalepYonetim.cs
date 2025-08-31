using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class MalzemeTalepYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // UserSession.cs dosyasından KullaniciGrubu için değişken oluşturalım.
        private string KullaniciGrubu;

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
        public MalzemeTalepYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(MalzemeTalepYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void MalzemeTalepYonetim_Load(object sender, EventArgs e)
        {
            MalzemeTalepListele();

            // KullaniciGrubu'nu baz alarak Talep Karşılama Durumunu güncelleme işlevini açıp/kapatacağız.
            KullaniciGrubu = UserSession.KullaniciGrubu;

            if (KullaniciGrubu == "Admin" || KullaniciGrubu == "Talep Karsilama")
            {
                cmbTalepKarsilanmaDurumu.Enabled = true;
            }
            else
            {
                cmbTalepKarsilanmaDurumu.Enabled = false;
            }

            // ComboBox'lar için SQL sorguları.
            string kullaniciAdiQuery = "SELECT DISTINCT CONCAT(KullaniciAdi, ' - ', KullaniciAdSoyad) AS TalepEdenKullanici FROM KULLANICI";
            string departmanAdi = "SELECT DepartmanAdi FROM DEPARTMAN GROUP BY DepartmanAdi";
            string malzemeAdiQuery = "SELECT DISTINCT CONCAT(MalzemeID, ' - ', MalzemeAdi) AS TalepMalzemeAdi FROM MALZEMELER";

            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbTalepKullaniciID, kullaniciAdiQuery, "TalepEdenKullanici");
            ComboBoxDoldur(cmbTalepDepartmanID, departmanAdi, "DepartmanAdi");
            ComboBoxDoldur(cmbMalzemeAdi, malzemeAdiQuery, "TalepMalzemeAdi");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void MalzemeTalepListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.TalepID, CONCAT(B.KullaniciAdi, ' - ', B.KullaniciAdSoyad) AS TalepEdenKullanici, C.DepartmanAdi, A.TalepTarihi, " +
                        "A.TalepKayitliMalzemeID AS MalzemeID, CONCAT(D.MalzemeID, ' - ', D.MalzemeAdi) AS MalzemeIDAdi, A.TalepKayitsizMalzemeID AS KayitsizMalzeme, " +
                        "A.TalepMiktari, A.TalepAciklama, " +
                        "CASE WHEN A.TalepKarsilanmaDurumu = 0 Then 'Karsilanmadi' " +
                        "WHEN A.TalepKarsilanmaDurumu = 1 Then 'Karsilandi' " +
                        "WHEN A.TalepKarsilanmaDurumu = 2 Then 'Reddedildi' END AS KarsilanmaDurumu, " +
                        "CASE WHEN E.KabulEdilenTeklif = 0 OR E.KabulEdilenTeklif IS NULL Then NULL " +
                        "WHEN E.KabulEdilenTeklif = 1 Then CONCAT(F1.TedarikciAdi + ' - ', 'Tedarikcisi Tarafindan Karsilandi') " +
                        "WHEN E.KabulEdilenTeklif = 2 Then CONCAT(F2.TedarikciAdi + ' - ', 'Tedarikcisi Tarafindan Karsilandi') " +
                        "WHEN E.KabulEdilenTeklif = 3 Then CONCAT(F3.TedarikciAdi + ' - ', 'Tedarikcisi Tarafindan Karsilandi') END AS KarsilayanTedarikci " +
                        "FROM TALEPLER A " +
                        "INNER JOIN KULLANICI B ON A.TalepKullaniciID = B.KullaniciID " +
                        "INNER JOIN DEPARTMAN C ON A.TalepDepartmanID = C.DepartmanID " +
                        "LEFT JOIN MALZEMELER D ON A.TalepKayitliMalzemeID = D.MalzemeID " +
                        "LEFT JOIN TEDARIKCITEKLIF E ON A.TalepID = E.TeklifTalepID " +
                        "LEFT JOIN TEDARIKCI F1 ON E.BirinciTedarikci = F1.TedarikciID " +
                        "LEFT JOIN TEDARIKCI F2 ON E.IkinciTedarikci = F2.TedarikciID " +
                        "LEFT JOIN TEDARIKCI F3 ON E.UcuncuTedarikci = F3.TedarikciID " +
                        ";", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTalep.DataSource = dataTable;
                    dgvTalep.AutoResizeColumns();
                    dgvTalep.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }
        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvTalep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvTalep.CurrentRow.Selected = true;
            txtTalepID.Text = dgvTalep.Rows[e.RowIndex].Cells["TalepID"].Value?.ToString() ?? "";
            cmbTalepKullaniciID.Text = dgvTalep.Rows[e.RowIndex].Cells["TalepEdenKullanici"].Value?.ToString() ?? "";
            cmbTalepDepartmanID.Text = dgvTalep.Rows[e.RowIndex].Cells["DepartmanAdi"].Value?.ToString() ?? "";
            dtpTalepTarihi.Text = dgvTalep.Rows[e.RowIndex].Cells["TalepTarihi"].Value?.ToString() ?? "";
            cmbMalzemeAdi.Text = dgvTalep.Rows[e.RowIndex].Cells["MalzemeIDAdi"].Value?.ToString() ?? "";
            txtTalepKayitsizMalzemeID.Text = dgvTalep.Rows[e.RowIndex].Cells["KayitsizMalzeme"].Value?.ToString() ?? "";
            txtTalepMiktari.Text = dgvTalep.Rows[e.RowIndex].Cells["TalepMiktari"].Value?.ToString() ?? "";
            txtTalepAciklama.Text = dgvTalep.Rows[e.RowIndex].Cells["TalepAciklama"].Value?.ToString() ?? "";
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
            txtTalepID.Text = null;
            cmbTalepKullaniciID.Text = null;
            cmbTalepDepartmanID.Text = null;
            dtpTalepTarihi.Text = null;
            cmbMalzemeAdi.Text = null;
            txtTalepKayitsizMalzemeID.Text = null;
            txtTalepMiktari.Text = null;
            txtTalepAciklama.Text = null;
        }

        // Metin Alanlarını Temizle butonuna basıldığında alanları temizleyelim.
        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Malzeme Talebi ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string talepID = txtTalepID.Text.Trim();
            string talepKullaniciID = cmbTalepKullaniciID.Text.Trim();
            string kullaniciAdi = talepKullaniciID.Split(" - ")[0];
            string talepDepartmanAdi = cmbTalepDepartmanID.Text.Trim();
            DateTime talepTarihi = dtpTalepTarihi.Value;
            string talepMalzemeID = cmbMalzemeAdi.Text.Trim();
            string malzemeAdi = talepMalzemeID.Split(" - ")[0];
            string talepKayitsizMalzemeID = txtTalepKayitsizMalzemeID.Text.Trim();
            string talepMiktari = txtTalepMiktari.Text.Trim();
            string talepAciklama = txtTalepAciklama.Text.Trim();

            if (!string.IsNullOrEmpty(talepID))
            {
                MessageBox.Show("Talep ID alanı boş olmalıdır. Metin alanlarını temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(talepKullaniciID) || string.IsNullOrEmpty(talepDepartmanAdi) || string.IsNullOrEmpty(talepMiktari))
                {
                    MessageBox.Show("Talep ID, Talep Eden Kişi, Talep Departmanı, Talep Tarihi, Talep Miktarı alanları boş olamaz. Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca bir tanesi dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(talepMalzemeID) && string.IsNullOrEmpty(talepKayitsizMalzemeID))
                    {
                        MessageBox.Show("Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca teki dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (!string.IsNullOrEmpty(talepMalzemeID) && !string.IsNullOrEmpty(talepKayitsizMalzemeID))
                    {
                        MessageBox.Show("Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca teki dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        string query = "INSERT INTO TALEPLER (TalepKullaniciID, TalepDepartmanID, TalepTarihi, TalepKayitliMalzemeID, " +
                        "TalepKayitsizMalzemeID, TalepMiktari, TalepAciklama, TalepKarsilanmaDurumu) " +
                        "SELECT A.KullaniciID, (SELECT DepartmanID FROM DEPARTMAN Where DepartmanAdi = @talepDepartmanAdi), @talepTarihi, @malzemeAdi, @talepKayitsizMalzemeID, @talepMiktari, @talepAciklama, 0 FROM KULLANICI A " +
                        "WHERE KullaniciAdi = @kullaniciAdi " +
                        ";";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();

                                using (SqlCommand cmd = new SqlCommand(query, connection))
                                {
                                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                                    cmd.Parameters.AddWithValue("@talepDepartmanAdi", talepDepartmanAdi);
                                    cmd.Parameters.AddWithValue("@talepTarihi", talepTarihi);
                                    cmd.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                                    cmd.Parameters.AddWithValue("@talepKayitsizMalzemeID", talepKayitsizMalzemeID);
                                    cmd.Parameters.AddWithValue("@talepMiktari", talepMiktari);
                                    cmd.Parameters.AddWithValue("@talepAciklama", talepAciklama);

                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Talep başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TextBoxTemizleme();
                                    MalzemeTalepListele();
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
        }

        // Malzeme Talebini güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string talepID = txtTalepID.Text.Trim();
            string talepKullaniciID = cmbTalepKullaniciID.Text.Trim(); ;
            string kullaniciAdi = talepKullaniciID.Split(" - ")[0];
            string talepDepartmanAdi = cmbTalepDepartmanID.Text.Trim();
            DateTime talepTarihi = dtpTalepTarihi.Value;
            string talepMalzemeID = cmbMalzemeAdi.Text.Trim();
            string malzemeAdi = talepMalzemeID.Split(" - ")[0];
            string talepKayitsizMalzemeID = txtTalepKayitsizMalzemeID.Text.Trim();
            string talepMiktari = txtTalepMiktari.Text.Trim();
            string talepAciklama = txtTalepAciklama.Text.Trim();
            string talepKarsilanmaDurumuID = cmbTalepKarsilanmaDurumu.Text.Trim();
            string talepKarsilanmaDurumu = talepKarsilanmaDurumuID.Split(" - ")[0];

            if (string.IsNullOrEmpty(talepID) || string.IsNullOrEmpty(talepKullaniciID) || string.IsNullOrEmpty(talepDepartmanAdi) || string.IsNullOrEmpty(talepMiktari))
            {
                MessageBox.Show("Talep ID, Talep Eden Kişi, Talep Departmanı, Talep Tarihi, Talep Miktarı alanları boş olamaz. Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca bir tanesi dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(talepMalzemeID) && string.IsNullOrEmpty(talepKayitsizMalzemeID))
                {
                    MessageBox.Show("Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca teki dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!string.IsNullOrEmpty(talepMalzemeID) && !string.IsNullOrEmpty(talepKayitsizMalzemeID))
                {
                    MessageBox.Show("Kayıtlı Malzeme Seçim veya Kayıtsız Malzeme Açıklama alanlarından yalnızca teki dolu olabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string queryCheck = "SELECT TalepKarsilanmaDurumu FROM TALEPLER WHERE TalepID = @talepID";
                    string queryUpdate = "UPDATE TALEPLER SET TalepKullaniciID = (SELECT KullaniciID FROM KULLANICI Where KullaniciAdi = @kullaniciAdi), " +
                                         "TalepDepartmanID = (SELECT DepartmanID FROM DEPARTMAN WHERE DepartmanAdi = @talepDepartmanAdi), " +
                                        "TalepTarihi = @talepTarihi, TalepKayitliMalzemeID = @malzemeAdi, TalepKayitsizMalzemeID = @talepKayitsizMalzemeID, " +
                                        "TalepMiktari = @talepMiktari, TalepAciklama = @talepAciklama, TalepKarsilanmaDurumu = ISNULL(@talepKarsilanmaDurumu, 0) " +
                                        "WHERE TalepID = @talepID;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                            {
                                cmdCheck.Parameters.AddWithValue("@talepID", talepID);

                                object result = cmdCheck.ExecuteScalar();

                                if ((result != null && Convert.ToInt32(result) == 0) || KullaniciGrubu == "Admin")
                                {
                                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection))
                                    {
                                        cmdUpdate.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                                        cmdUpdate.Parameters.AddWithValue("@talepDepartmanAdi", talepDepartmanAdi);
                                        cmdUpdate.Parameters.AddWithValue("@talepTarihi", talepTarihi);
                                        cmdUpdate.Parameters.AddWithValue("@malzemeAdi", malzemeAdi);
                                        cmdUpdate.Parameters.AddWithValue("@talepKayitsizMalzemeID", talepKayitsizMalzemeID);
                                        cmdUpdate.Parameters.AddWithValue("@talepMiktari", talepMiktari);
                                        cmdUpdate.Parameters.AddWithValue("@talepAciklama", talepAciklama);
                                        cmdUpdate.Parameters.AddWithValue("@talepID", talepID);
                                        cmdUpdate.Parameters.AddWithValue("@talepKarsilanmaDurumu", talepKarsilanmaDurumu);

                                        cmdUpdate.ExecuteNonQuery();

                                        MessageBox.Show("Talep başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        TextBoxTemizleme();
                                        MalzemeTalepListele();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Talep Karşılanma Durumu güncellenmek için uygun değildir. Karşılandı veya Reddedildi durumunu yalnızca Admin güncelleyebilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
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

        // Malzeme Talebini silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string talepID = txtTalepID.Text.Trim();
            string talepKarsilanmaDurumuID = cmbTalepKarsilanmaDurumu.Text.Trim();
            string talepKarsilanmaDurumu = talepKarsilanmaDurumuID.Split(" - ")[0];

            if (string.IsNullOrEmpty(talepID))
            {
                MessageBox.Show("Talep ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string queryCheck = "SELECT TalepKarsilanmaDurumu FROM TALEPLER WHERE TalepID = @talepID";
                string queryUpdate = "DELETE FROM TALEPLER WHERE TalepID = @talepID;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@talepID", talepID);

                            object result = cmdCheck.ExecuteScalar();

                            if ((result != null && Convert.ToInt32(result) == 0) || KullaniciGrubu == "Admin")
                            {
                                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@talepID", talepID);

                                    cmdUpdate.ExecuteNonQuery();

                                    MessageBox.Show("Talep başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TextBoxTemizleme();
                                    MalzemeTalepListele();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Talep Karşılanma Durumu silmek için uygun değildir. Karşılandı veya Reddedildi durumunu yalnızca Admin güncelleyebilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
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