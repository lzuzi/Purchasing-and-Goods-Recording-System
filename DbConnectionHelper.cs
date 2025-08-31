using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SatinalmaMalKayitSistemi
{
    public class DbConnectionHelper
    {
        // Proje kök dizinini alıyoruz.
        private static string GetProjectRoot()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectRoot = baseDirectory;

            // Proje kök dizinine gitmek için tam 3 üst dizine çıkıyoruz.
            for (int i = 0; i < 4; i++)
            {
                projectRoot = Directory.GetParent(projectRoot)?.FullName;
                if (projectRoot == null) break;
            }

            return projectRoot;
        }

        // Bağlantı dizesini alıyoruz.
        public static string GetConnectionString()
        {
            string projectRoot = GetProjectRoot();

            // appsettings.json dosyasını okuyoruz.
            var config = new ConfigurationBuilder()
                .SetBasePath(projectRoot)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            // connectionString alıyoruz.
            string connectionString = config.GetConnectionString("SatinalmaMalKayitDB");

            // Veritabanı dosyasının (SatinalmaMalKayitDB.mdf) tam yolunu alıyoruz.
            string dbFilePath = Path.Combine(projectRoot, "SatinalmaMalKayitDB.mdf");

            // connectionString ile dbFilePath düzenlemesini yapıyoruz.
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbFilePath};Integrated Security=True";

            return connectionString;
        }

        // Bağlantı testi
        [Obsolete]
        public static bool TestConnection()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection con = new(connectionString))
            {
                try
                {
                    con.Open();
                    return true; // Bağlantı başarılı
                }
                catch (Exception)
                {
                    return false; // Bağlantı hatası
                }
            }
        }
    }
}
