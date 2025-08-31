using System.Data;
using System.Data.SqlClient;

namespace SatinalmaMalKayitSistemi.Forms
{
    public partial class EnvanterTakipYonetim : Form
    {
        // DbConnectionHelper.cs dosyasından connectionString alalım.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Ana metod, form açıldığında ilk bu metod çalışır.
        public EnvanterTakipYonetim()
        {
            InitializeComponent();
            this.Load += new EventHandler(EnvanterTakipYonetim_Load);
        }

        // Form yüklenirken yapacağımız işlemleri burada çağıralım.
        private void EnvanterTakipYonetim_Load(object sender, EventArgs e)
        {
            StokluMalzemeListele();
        }

        // Stoklu Malzeme Sorgusu
        private void StokluMalzemeListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MALZEMELER " +
                        "WHERE MalzemeKalanStokMiktari > 0 AND (MalzemeHurdaID IS NULL OR MalzemeHurdaID = 0);", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvEnvanter.DataSource = dataTable;
                    dgvEnvanter.AutoResizeColumns();
                    dgvEnvanter.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // Stoksuz Malzeme Sorgusu
        private void StoksuzMalzemeListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MALZEMELER " +
                        "WHERE MalzemeKalanStokMiktari < 1;", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvEnvanter.DataSource = dataTable;
                    dgvEnvanter.AutoResizeColumns();
                    dgvEnvanter.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // Stoklu ve Zimmetsiz Malzeme Sorgusu
        private void StokluZimmetsizMalzemeListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MALZEMELER " +
                        "WHERE MalzemeKalanStokMiktari > 0 AND (MalzemeHurdaID IS NULL OR MalzemeHurdaID = 0) " +
                        "AND (MalzemeZimmetID IS NULL OR MalzemeHurdaID = 0);", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvEnvanter.DataSource = dataTable;
                    dgvEnvanter.AutoResizeColumns();
                    dgvEnvanter.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // Hurda Malzeme Sorgusu
        private void HurdaMalzemeListele()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM MALZEMELER WHERE MalzemeHurdaID > 0;", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvEnvanter.DataSource = dataTable;
                    dgvEnvanter.AutoResizeColumns();
                    dgvEnvanter.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // Stoklu Malzeme Listesini datagrid'de gösterelim.
        private void btnStokluMalzemeler_Click(object sender, EventArgs e)
        {
            StokluMalzemeListele();
        }

        // Stoksuz Malzeme Listesini datagrid'de gösterelim.
        private void btnStoksuzMalzemeler_Click(object sender, EventArgs e)
        {
            StoksuzMalzemeListele();
        }

        // Stoklu ve Zimmetsiz Malzeme Listesini datagrid'de gösterelim.
        private void btnStokluZimmetsizMalzemeler_Click(object sender, EventArgs e)
        {
            StokluZimmetsizMalzemeListele();
        }

        private void btnHurdaMalzemeler_Click(object sender, EventArgs e)
        {
            HurdaMalzemeListele();
        }
    }
}