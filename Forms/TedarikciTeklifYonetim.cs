using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class TedarikciTeklifYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Malzeme Talep ID ComboBox'unu birkaç yerde güncelleyeceğiz dışarı alalım.
        private string malzemeTalepIDQuery = "SELECT " +
        "CASE WHEN B.MalzemeAdi IS NULL THEN CONCAT(A.TalepID, ' - ', A.TalepKayitsizMalzemeID) " +
        "ELSE CONCAT(A.TalepID, ' - ', B.MalzemeAdi) END AS TalepMalzemeID " +
        "FROM TALEPLER A " +
        "LEFT JOIN MALZEMELER B ON A.TalepKayitliMalzemeID = B.MalzemeID " +
        "WHERE A.TalepKarsilanmaDurumu = 0 " +
        "AND NOT EXISTS (SELECT 1 FROM TEDARIKCITEKLIF B WHERE B.TeklifTalepID = A.TalepID) " +
        ";";

        // Tedarikçiler için aynı mı kontrolü yapalım, liste oluşturalım.
        private List<string> cmbTedarikci = new List<string>();

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
        public TedarikciTeklifYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(TedarikciTeklifYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void TedarikciTeklifYonetim_Load(object sender, EventArgs e)
        {
            TedarikciTeklifListele();

            // ComboBox'lar için SQL sorguları.
            string tedarikciAdiQuery = "SELECT DISTINCT CONCAT(TedarikciID, ' - ', TedarikciAdi) AS TedarikciIDAdi FROM TEDARIKCI";

            // ComboBox Doldurma metodlarını çağıralım.
            ComboBoxDoldur(cmbMalzemeTalepID, malzemeTalepIDQuery, "TalepMalzemeID");
            ComboBoxDoldur(cmbBirinciTedarikci, tedarikciAdiQuery, "TedarikciIDAdi");
            ComboBoxDoldur(cmbIkinciTedarikci, tedarikciAdiQuery, "TedarikciIDAdi");
            ComboBoxDoldur(cmbUcuncuTedarikci, tedarikciAdiQuery, "TedarikciIDAdi");
        }

        // Veritabanından ilgili tablodan sorguyu yaptık ve datagrid de gösterdik.
        private void TedarikciTeklifListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT A.TeklifID, A.TeklifTalepID, C.MalzemeAdi AS KayitliMalzemeAdi, " +
                        "B.TalepKayitsizMalzemeID AS KayitsizMalzemeAdi, A.TeklifMalzemeKayitID, " +
                        "CASE WHEN A.KabulEdilenTeklif IS NULL OR A.KabulEdilenTeklif = 0 THEN NULL " +
                        "ELSE CONCAT(A.KabulEdilenTeklif, '. Teklif') END AS KabulEdilmisTeklif, " +
                        "CONCAT(A.BirinciTedarikci, ' - ', D1.TedarikciAdi) AS BirinciTedarikciIDAdi, A.BirinciTeklif, " +
                        "CONCAT(A.IkinciTedarikci, ' - ', D2.TedarikciAdi) AS IkinciTedarikciIDAdi, A.IkinciTeklif, " +
                        "CONCAT(A.UcuncuTedarikci, ' - ', D3.TedarikciAdi) AS UcuncuTedarikciIDAdi, A.UcuncuTeklif " +
                        "FROM TEDARIKCITEKLIF A " +
                        "INNER JOIN TALEPLER B ON A.TeklifTalepID = B.TalepID " +
                        "LEFT JOIN MALZEMELER C ON B.TalepKayitliMalzemeID = C.MalzemeID " +
                        "LEFT JOIN TEDARIKCI D1 ON A.BirinciTedarikci = D1.TedarikciID " +
                        "LEFT JOIN TEDARIKCI D2 ON A.IkinciTedarikci = D2.TedarikciID " +
                        "LEFT JOIN TEDARIKCI D3 ON A.UcuncuTedarikci = D3.TedarikciID " +
                        ";", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvTedarikciTeklif.DataSource = dataTable;
                    dgvTedarikciTeklif.AutoResizeColumns();
                    dgvTedarikciTeklif.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                return;
            }

        }

        // DataGrid'de hücreye tıklandığında ilgili satırdaki verileri TextBox'ların içerisine yazalım.
        private void dgvTedarikciTeklif_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            TextBoxTemizleme();

            dgvTedarikciTeklif.CurrentRow.Selected = true;
            txtTedarikciTeklifID.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["TeklifID"].Value?.ToString() ?? "";
            cmbMalzemeTalepID.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["TeklifTalepID"].Value?.ToString() ?? "";
            cmbKabulEdilenTeklif.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["KabulEdilmisTeklif"].Value?.ToString() ?? "";
            cmbBirinciTedarikci.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["BirinciTedarikciIDAdi"].Value?.ToString() ?? "";
            cmbIkinciTedarikci.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["IkinciTedarikciIDAdi"].Value?.ToString() ?? "";
            cmbUcuncuTedarikci.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["UcuncuTedarikciIDAdi"].Value?.ToString() ?? "";
            txtBirinciTedarikciTeklif.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["BirinciTeklif"].Value?.ToString() ?? "";
            txtIkinciTedarikciTeklif.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["IkinciTeklif"].Value?.ToString() ?? "";
            txtUcuncuTedarikciTeklif.Text = dgvTedarikciTeklif.Rows[e.RowIndex].Cells["UcuncuTeklif"].Value?.ToString() ?? "";
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
            txtTedarikciTeklifID.Text = null;
            cmbMalzemeTalepID.Text = null;
            cmbKabulEdilenTeklif.Text = null;
            cmbBirinciTedarikci.Text = null;
            cmbIkinciTedarikci.Text = null;
            cmbUcuncuTedarikci.Text = null;
            txtBirinciTedarikciTeklif.Text = null;
            txtIkinciTedarikciTeklif.Text = null;
            txtUcuncuTedarikciTeklif.Text = null;
        }

        private void btnTextClear_Click(object sender, EventArgs e)
        {
            TextBoxTemizleme();
        }

        // Teklif metninde sadece rakam (0-9) ve geri silme (Backspace) tuşuna izin verelim. 
        private void txtBirinciTedarikciTeklif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Teklif metninde sadece rakam (0-9) ve geri silme (Backspace) tuşuna izin verelim. 
        private void txtIkinciTedarikciTeklif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Teklif metninde sadece rakam (0-9) ve geri silme (Backspace) tuşuna izin verelim. 
        private void txtUcuncuTedarikciTeklif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Yeni Teklif ekleyelim.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmbTedarikci.Clear();

            string tedarikciTeklifID = txtTedarikciTeklifID.Text.Trim();

            string malzemeTalepAdi = cmbMalzemeTalepID.Text.Trim();
            string malzemeTalepID = malzemeTalepAdi.Split(" - ")[0].Trim();

            string kabulEdilenTeklifID = cmbKabulEdilenTeklif.Text.Trim();
            string kabulEdilenTeklif = string.Empty;
            if (!string.IsNullOrEmpty(kabulEdilenTeklifID))
            {
                kabulEdilenTeklif = kabulEdilenTeklifID.Split('.')[0].Trim();
            }

            string birinciTedarikciID = cmbBirinciTedarikci.Text.Trim();
            string birinciTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(birinciTedarikciID))
            {
                birinciTedarikci = birinciTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(birinciTedarikci);
            }

            string ikinciTedarikciID = cmbIkinciTedarikci.Text.Trim();
            string ikinciTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(ikinciTedarikciID))
            {
                ikinciTedarikci = ikinciTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(ikinciTedarikci);
            }

            string ucuncuTedarikciID = cmbUcuncuTedarikci.Text.Trim();
            string ucuncuTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(ucuncuTedarikciID))
            {
                ucuncuTedarikci = ucuncuTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(ucuncuTedarikci);
            }

            string birinciTeklif = txtBirinciTedarikciTeklif.Text.Trim();
            string ikinciTeklif = txtIkinciTedarikciTeklif.Text.Trim();
            string ucuncuTeklif = txtUcuncuTedarikciTeklif.Text.Trim();

            int cmbTedarikciLength = cmbTedarikci.Count;
            int distinctCount = cmbTedarikci.Distinct().Count();

            if (!string.IsNullOrEmpty(tedarikciTeklifID))
            {
                MessageBox.Show("Tedarikçi Teklif ID alanı boş olmalıdır. Metin alanlarını temizle butonuna basın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(malzemeTalepAdi) || string.IsNullOrEmpty(birinciTedarikciID) || string.IsNullOrEmpty(birinciTeklif))
            {
                MessageBox.Show("Malzeme Talep ID, 1. Tedarikçi ve 1. Tedarikçi Teklifi alanları boş olamaz. Diğer alanlar isteğe bağlıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(ikinciTedarikci) && (kabulEdilenTeklif == "2" || kabulEdilenTeklif == "3"))
            {
                MessageBox.Show("2. Teklif girilmeden 3. Teklif girilemez veya 2. Teklif girilmeden 2. Teklif veya 3. Teklif kabul edilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(ucuncuTedarikci) && kabulEdilenTeklif == "3")
            {
                MessageBox.Show("3. Teklif girilmeden 3. Teklif kabul edilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cmbTedarikciLength > distinctCount)
            {
                MessageBox.Show("Aynı tedarikçiyi birden fazla kez listeye dahil edemezsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTedarikci.Clear();
                return;
            }
            else
            {
                string query = "INSERT INTO TEDARIKCITEKLIF (TeklifTalepID, TeklifMalzemeKayitID, KabulEdilenTeklif, BirinciTedarikci, " +
                    "BirinciTeklif, IkinciTedarikci, IkinciTeklif, UcuncuTedarikci, UcuncuTeklif) " +
                    "VALUES (@malzemeTalepID, NULL, @kabulEdilenTeklif, @birinciTedarikci, @birinciTeklif, " +
                    "@ikinciTedarikci, @ikinciTeklif, @ucuncuTedarikci, @ucuncuTeklif) " +
                    ";";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@malzemeTalepID", malzemeTalepID);
                            cmd.Parameters.AddWithValue("@kabulEdilenTeklif", kabulEdilenTeklif);
                            cmd.Parameters.AddWithValue("@birinciTedarikci", birinciTedarikci);
                            cmd.Parameters.AddWithValue("@birinciTeklif", birinciTeklif);
                            cmd.Parameters.AddWithValue("@ikinciTedarikci", ikinciTedarikci);
                            cmd.Parameters.AddWithValue("@ikinciTeklif", ikinciTeklif);
                            cmd.Parameters.AddWithValue("@ucuncuTedarikci", ucuncuTedarikci);
                            cmd.Parameters.AddWithValue("@ucuncuTeklif", ucuncuTeklif);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Tedarikçi Teklifi başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TextBoxTemizleme();

                            cmbMalzemeTalepID.Items.Clear();
                            ComboBoxDoldur(cmbMalzemeTalepID, malzemeTalepIDQuery, "TalepMalzemeID");

                            TedarikciTeklifListele();
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

        // Teklifi güncelleyelim.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cmbTedarikci.Clear();

            string tedarikciTeklifID = txtTedarikciTeklifID.Text.Trim();

            string malzemeTalepAdi = cmbMalzemeTalepID.Text.Trim();
            string malzemeTalepID = malzemeTalepAdi.Split(" - ")[0].Trim();

            string kabulEdilenTeklifID = cmbKabulEdilenTeklif.Text.Trim();
            string kabulEdilenTeklif = string.Empty;
            if (!string.IsNullOrEmpty(kabulEdilenTeklifID))
            {
                kabulEdilenTeklif = kabulEdilenTeklifID.Split('.')[0].Trim();
            }

            string birinciTedarikciID = cmbBirinciTedarikci.Text.Trim();
            string birinciTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(birinciTedarikciID))
            {
                birinciTedarikci = birinciTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(birinciTedarikci);
            }

            string ikinciTedarikciID = cmbIkinciTedarikci.Text.Trim();
            string ikinciTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(ikinciTedarikciID))
            {
                ikinciTedarikci = ikinciTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(ikinciTedarikci);
            }

            string ucuncuTedarikciID = cmbUcuncuTedarikci.Text.Trim();
            string ucuncuTedarikci = string.Empty;
            if (!string.IsNullOrEmpty(ucuncuTedarikciID))
            {
                ucuncuTedarikci = ucuncuTedarikciID.Split(" - ")[0].Trim();
                cmbTedarikci.Add(ucuncuTedarikci);
            }

            string birinciTeklif = txtBirinciTedarikciTeklif.Text.Trim();
            string ikinciTeklif = txtIkinciTedarikciTeklif.Text.Trim();
            string ucuncuTeklif = txtUcuncuTedarikciTeklif.Text.Trim();

            int cmbTedarikciLength = cmbTedarikci.Count;
            int distinctCount = cmbTedarikci.Distinct().Count();

            if (string.IsNullOrEmpty(tedarikciTeklifID))
            {
                MessageBox.Show("Tedarikçi Teklif ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!string.IsNullOrEmpty(malzemeTalepAdi) || string.IsNullOrEmpty(birinciTedarikciID) || string.IsNullOrEmpty(birinciTeklif))
            {
                MessageBox.Show("Malzeme Talep ID alanı dolu olamaz veya 1. Tedarikçi ve 1. Tedarikçi Teklifi alanları boş olamaz. Diğer alanlar isteğe bağlıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMalzemeTalepID.Text = null;
                return;
            }
            else if (string.IsNullOrEmpty(ikinciTedarikci) && (kabulEdilenTeklif == "2" || kabulEdilenTeklif == "3"))
            {
                MessageBox.Show("2. Teklif girilmeden 3. Teklif girilemez veya 2. Teklif girilmeden 2. Teklif veya 3. Teklif kabul edilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(ucuncuTedarikci) && kabulEdilenTeklif == "3")
            {
                MessageBox.Show("3. Teklif girilmeden 3. Teklif kabul edilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (cmbTedarikciLength > distinctCount)
            {
                MessageBox.Show("Aynı tedarikçiyi birden fazla kez listeye dahil edemezsiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTedarikci.Clear();
                return;
            }
            else
            {
                string queryCheck = "SELECT TeklifMalzemeKayitID FROM TEDARIKCITEKLIF WHERE TeklifID = @tedarikciTeklifID;";
                string queryUpdate = "UPDATE TEDARIKCITEKLIF SET KabulEdilenTeklif = @kabulEdilenTeklif, BirinciTedarikci = @birinciTedarikci, " +
                    "BirinciTeklif = @birinciTeklif, IkinciTedarikci = @ikinciTedarikci, IkinciTeklif = @ikinciTeklif, " +
                    "UcuncuTedarikci = @ucuncuTedarikci, UcuncuTeklif = @ucuncuTeklif " +
                    "WHERE TeklifID = @tedarikciTeklifID " +
                    ";";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@tedarikciTeklifID", tedarikciTeklifID);

                            object result = cmdCheck.ExecuteScalar();

                            if (result == DBNull.Value || Convert.ToInt32(result) <= 0)
                            {
                                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@malzemeTalepID", malzemeTalepID);
                                    cmdUpdate.Parameters.AddWithValue("@kabulEdilenTeklif", kabulEdilenTeklif);
                                    cmdUpdate.Parameters.AddWithValue("@birinciTedarikci", birinciTedarikci);
                                    cmdUpdate.Parameters.AddWithValue("@birinciTeklif", birinciTeklif);
                                    cmdUpdate.Parameters.AddWithValue("@ikinciTedarikci", ikinciTedarikci);
                                    cmdUpdate.Parameters.AddWithValue("@ikinciTeklif", ikinciTeklif);
                                    cmdUpdate.Parameters.AddWithValue("@ucuncuTedarikci", ucuncuTedarikci);
                                    cmdUpdate.Parameters.AddWithValue("@ucuncuTeklif", ucuncuTeklif);
                                    cmdUpdate.Parameters.AddWithValue("@tedarikciTeklifID", tedarikciTeklifID);

                                    cmdUpdate.ExecuteNonQuery();

                                    MessageBox.Show("Tedarikçi Teklifi başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TextBoxTemizleme();
                                    TedarikciTeklifListele();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Teklife ait Malzeme Kayıt yapıldığı için güncellenmek için uygun değildir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Teklifi silelim.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string tedarikciTeklifID = txtTedarikciTeklifID.Text.Trim();

            if (string.IsNullOrEmpty(tedarikciTeklifID))
            {
                MessageBox.Show("Tedarikçi Teklif ID alanı boş olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string queryCheck = "SELECT TeklifMalzemeKayitID FROM TEDARIKCITEKLIF WHERE TeklifID = @tedarikciTeklifID;";
                string queryUpdate = "DELETE FROM TEDARIKCITEKLIF WHERE TeklifID = @tedarikciTeklifID" +
                    ";";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@tedarikciTeklifID", tedarikciTeklifID);

                            object result = cmdCheck.ExecuteScalar();

                            if (result == DBNull.Value || Convert.ToInt32(result) <= 0)
                            {
                                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@tedarikciTeklifID", tedarikciTeklifID);


                                    cmdUpdate.ExecuteNonQuery();

                                    MessageBox.Show("Tedarikçi Teklifi başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    TextBoxTemizleme();

                                    cmbMalzemeTalepID.Items.Clear();
                                    ComboBoxDoldur(cmbMalzemeTalepID, malzemeTalepIDQuery, "TalepMalzemeID");

                                    TedarikciTeklifListele();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Teklife ait Malzeme Kayıt yapıldığı için güncellenmek için uygun değildir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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