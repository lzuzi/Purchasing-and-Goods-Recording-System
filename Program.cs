namespace SatinalmaMalKayitSistemi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            /*
             * LoginForm sat�r� normal program ba�lang�c�.
             * MainForm(Admin) sat�r� geli�tirici program ba�lang�c�.
             */
            Application.Run(new LoginForm());
            //Application.Run(new MainForm("Admin"));
        }
    }
}