using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using ClosedXML.Excel;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class RaporlamaYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public RaporlamaYonetim()
        {
            InitializeComponent();
        }

        // Veri tabanından istediğimiz raporu çekelim.
        public DataTable VeritabanindanGetir(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // Excel çıktısını oluşturalım.
        public void ExportToExcel(DataTable dataTable, string raporAdi)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Excel Dosyası Kaydet";
                saveFileDialog.FileName = $"{raporAdi}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CultureInfo culture = new CultureInfo("tr-TR");
                    System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                    System.Threading.Thread.CurrentThread.CurrentUICulture = culture;

                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(dataTable, $"{raporAdi}");

                        var headerRow = worksheet.Row(1);
                        headerRow.Style.Font.Bold = true;

                        worksheet.Columns().AdjustToContents();

                        worksheet.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                        foreach (IXLCell cell in worksheet.CellsUsed())
                        {
                            if (DateTime.TryParse(cell.Value.ToString(), out _))
                            {
                                cell.Style.DateFormat.Format = "dd/MM/yyyy";
                            }
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Excel çıktısı başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Kaydet butonuna bastığımızda Excel olarak çıktı verelim.
        private void btnSave_Click(object sender, EventArgs e)
        {
            //string query = "SELECT * FROM MALZEMELER;";
            //DataTable data = VeritabanindanGetir(connectionString, query);
            //ExportToExcel(data);

            string raporAdi = cmbRaporAdi.Text.Trim();

            switch (raporAdi)
            {
                case "Tedarikçi Listesi":
                    string tedarikciListesi = "SELECT * FROM TEDARIKCI" +
                        ";";
                    DataTable tedarikciListesiData = VeritabanindanGetir(connectionString, tedarikciListesi);
                    ExportToExcel(tedarikciListesiData, raporAdi);
                    break;
                case "Stok Malzeme Listesi":
                    string stokMalzemeListesi = "SELECT * FROM MALZEMELER WHERE MalzemeKalanStokMiktari > 0 AND " +
                        "(MalzemeHurdaID IS NULL OR MalzemeHurdaID = 0)" +
                        ";";
                    DataTable stokMalzemeListesiData = VeritabanindanGetir(connectionString, stokMalzemeListesi);
                    ExportToExcel(stokMalzemeListesiData, raporAdi);
                    break;
                case "Stoksuz Malzeme Listesi":
                    string stoksuzMalzemeListesi = "SELECT * FROM MALZEMELER WHERE MalzemeKalanStokMiktari < 1" +
                        ";";
                    DataTable stoksuzMalzemeListesiData = VeritabanindanGetir(connectionString, stoksuzMalzemeListesi);
                    ExportToExcel(stoksuzMalzemeListesiData, raporAdi);
                    break;
                case "Malzeme Talepleri":
                    string malzemeTalepListesi = "SELECT A.TalepID, CONCAT(C.KullaniciID, ' - ', C.KullaniciAdSoyad) AS KullaniciIDAdSoyad, " +
                        "CONCAT(D.DepartmanID, ' - ', D.DepartmanAdi) AS DepartmanIDAdi, A.TalepTarihi, " +
                        "CASE WHEN A.TalepKayitliMalzemeID = 0 OR A.TalepKayitliMalzemeID IS NULL THEN '' ELSE B.MalzemeAdi END AS KayitMalzemeAdi, " +
                        "A.TalepKayitsizMalzemeID, A.TalepMiktari, A.TalepAciklama, " +
                        "CASE WHEN A.TalepKarsilanmaDurumu = 0 THEN 'Karsilanmadi' WHEN A.TalepKarsilanmaDurumu = 1 THEN 'Karsilandi' " +
                        "WHEN A.TalepKarsilanmaDurumu = 2 THEN 'Reddedildi' END AS TalepKarsilamaDurum " +
                        "FROM TALEPLER A " +
                        "LEFT JOIN MALZEMELER B ON A.TalepKayitliMalzemeID = B.MalzemeID " +
                        "INNER JOIN KULLANICI C ON A.TalepKullaniciID = C.KullaniciID " +
                        "INNER JOIN DEPARTMAN D ON A.TalepDepartmanID = D.DepartmanID" +
                        ";";
                    DataTable malzemeTalepListesiData = VeritabanindanGetir(connectionString, malzemeTalepListesi);
                    ExportToExcel(malzemeTalepListesiData, raporAdi);
                    break;
                case "Tedarikçi Teklifleri":
                    string tedarikciTeklifListesi = "SELECT A.TeklifID, A.TeklifTalepID, C.MalzemeAdi AS KayitliMalzemeAdi, " +
                        "B.TalepKayitsizMalzemeID AS KayitsizMalzemeAdi, A.TeklifMalzemeKayitID, " +
                        "CASE WHEN A.KabulEdilenTeklif IS NULL OR A.KabulEdilenTeklif = 0 THEN NULL ELSE CONCAT(A.KabulEdilenTeklif, '. Teklif') END AS KabulEdilmisTeklif, " +
                        "CONCAT(A.BirinciTedarikci, ' - ', D1.TedarikciAdi) AS BirinciTedarikciIDAdi, A.BirinciTeklif, " +
                        "CONCAT(A.IkinciTedarikci, ' - ', D2.TedarikciAdi) AS IkinciTedarikciIDAdi, A.IkinciTeklif, " +
                        "CONCAT(A.UcuncuTedarikci, ' - ', D3.TedarikciAdi) AS UcuncuTedarikciIDAdi, A.UcuncuTeklif " +
                        "FROM TEDARIKCITEKLIF A " +
                        "INNER JOIN TALEPLER B ON A.TeklifTalepID = B.TalepID " +
                        "LEFT JOIN MALZEMELER C ON B.TalepKayitliMalzemeID = C.MalzemeID " +
                        "LEFT JOIN TEDARIKCI D1 ON A.BirinciTedarikci = D1.TedarikciID " +
                        "LEFT JOIN TEDARIKCI D2 ON A.IkinciTedarikci = D2.TedarikciID " +
                        "LEFT JOIN TEDARIKCI D3 ON A.UcuncuTedarikci = D3.TedarikciID" +
                        ";";
                    DataTable tedarikciTeklifListesiData = VeritabanindanGetir(connectionString, tedarikciTeklifListesi);
                    ExportToExcel(tedarikciTeklifListesiData, raporAdi);
                    break;
                case "Zimmet Listesi":
                    string zimmetMalzemeListesi = "SELECT A.ZimmetID, CONCAT(B.KullaniciID, ' - ', B.KullaniciAdSoyad) AS KullaniciIDAdSoyad, " +
                        "CONCAT(C.MalzemeID, ' - ', C.MalzemeAdi) AS MalzemeIDAdi, A.ZimmetTarihi, A.ZimmetAciklama " +
                        "FROM ZIMMET A " +
                        "INNER JOIN KULLANICI B ON A.ZimmetliKullaniciID = B.KullaniciID " +
                        "INNER JOIN MALZEMELER C ON A.ZimmetID = C.MalzemeZimmetID" +
                        ";";
                    DataTable zimmetMalzemeListesiData = VeritabanindanGetir(connectionString, zimmetMalzemeListesi);
                    ExportToExcel(zimmetMalzemeListesiData, raporAdi);
                    break;
                case "Hurda Listesi":
                    string hurdaMalzemeListesi = "SELECT A.HurdaID, CONCAT(B.MalzemeID, ' - ', B.MalzemeAdi) AS MalzemeIDAdi, " +
                        "A.HurdaTarihi, A.HurdaAciklama " +
                        "FROM HURDA A " +
                        "INNER JOIN MALZEMELER B ON A.HurdaID = B.MalzemeHurdaID" +
                        ";";
                    DataTable hurdaMalzemeListesiData = VeritabanindanGetir(connectionString, hurdaMalzemeListesi);
                    ExportToExcel(hurdaMalzemeListesiData, raporAdi);
                    break;
                default:
                    MessageBox.Show("Listeden geçerli bir seçim yapmalısınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}