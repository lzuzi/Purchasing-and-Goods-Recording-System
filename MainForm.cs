namespace SatinalmaMalKayitSistemi
{
    public partial class MainForm : Form
    {
        // DbConnectionHelper.cs dosyasýndan connectionString alalým.
        private string connectionString = DbConnectionHelper.GetConnectionString();

        // Genel tanýmlamalar
        private Button currentButton;
        private Form activeForm;
        private string _userRole;
        private List<Button> _buttons;

        // Ana metod, form açýldýðýnda ilk bu metod çalýþýr.
        public MainForm(string userRole)
        {
            InitializeComponent();
            btnCloseChildForm.Visible = false;
            _userRole = userRole;

            _buttons = new List<Button>
            {
                btnUsers,
                btnDepartman,
                btnTedarikciKayit,
                btnMalzemeKullanim,
                btnMalzemeKayit,
                btnMalzemeTalep,
                btnTedarikciTeklif,
                btnZimmet,
                btnHurda,
                btnRaporlama
            };

            MenuVisibility();
        }

        // X tuþuna basýldýðýnda formun kapatýldýðýndan emin olalým.
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Role göre gözükecek formlarý ayarlayalým.
        private void MenuVisibility()
        {
            btnUsers.Visible = false;
            btnDepartman.Visible = false;
            btnTedarikciKayit.Visible = false;
            btnMalzemeKullanim.Visible = false;
            btnMalzemeKayit.Visible = false;
            btnMalzemeTalep.Visible = false;
            btnTedarikciTeklif.Visible = false;
            btnZimmet.Visible = false;
            btnHurda.Visible = false;
            btnRaporlama.Visible = false;

            if (_userRole == "Admin")
            {
                btnUsers.Visible = true;
                btnDepartman.Visible = true;
                btnTedarikciKayit.Visible = true;
                btnMalzemeKullanim.Visible = true;
                btnMalzemeKayit.Visible = true;
                btnMalzemeTalep.Visible = true;
                btnTedarikciTeklif.Visible = true;
                btnZimmet.Visible = true;
                btnHurda.Visible = true;
                btnRaporlama.Visible = true;
            }
            else if (_userRole == "Talep Karsilama")
            {
                btnTedarikciKayit.Visible = true;
                btnMalzemeKullanim.Visible = true;
                btnMalzemeKayit.Visible = true;
                btnMalzemeTalep.Visible = true;
                btnTedarikciTeklif.Visible = true;
                btnZimmet.Visible = true;
                btnHurda.Visible = true;
                btnRaporlama.Visible = true;
            }
            else if (_userRole == "Talep Olusturma")
            {
                btnMalzemeKullanim.Visible = true;
                btnMalzemeTalep.Visible = true;
                btnRaporlama.Visible = true;
            }
        }

        /*
         * ActivateButton ve DisableButton fonksiyonlarý týklanan butonun renginin kýrmýzý olmasý
         * ve týklanmayan butonun varsayýlan haline dönmesi için kullanýlýyor.
         * _Click eventlerinde ActiveButton(sender); ile çaðýrarak kod çalýþtýrýlýyor.
         */
        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = Color.DarkRed;
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 162);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        // Buton stilini eski haline getirelim
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.FromKnownColor(KnownColor.HighlightText);
                    previousBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
                }
            }
        }

        // X butonun metodu.
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "ANA SAYFA";
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        //Sol taraftaki butonlara basýldýðýnda ilgili butona ait form tasarýmýnýn ekrana gelmesini saðlayalým.
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text.ToUpper();
        }

        // Kullanýcý Yönetim Sistemini açalým.
        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.KullaniciYonetim(), sender);
        }

        // Departman Yönetim Sistemini açalým.
        private void btnDepartman_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.DepartmanYonetim(), sender);
        }

        // Tedarikçi Kayýt Yönetim Sistemini açalým.
        private void btnTedarikciKayit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.TedarikciKayitYonetim(), sender);
        }

        // Envanter Takip Yönetim Sistemini açalým.
        private void btnMalzemeKullanim_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.EnvanterTakipYonetim(), sender);
        }

        // Malzeme Kayýt Yönetim Sistemini açalým.
        private void btnMalzemeKayit_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MalzemeKayitYonetim(), sender);
        }

        // Malzeme Talep Yönetim Sistemini açalým.
        private void btnMalzemeTalep_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MalzemeTalepYonetim(), sender);
        }

        // Tedarikçi Teklif Yönetim Sistemini açalým.
        private void btnTedarikciTeklif_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.TedarikciTeklifYonetim(), sender);
        }

        // Zimmet Yönetim Sistemini açalým.
        private void btnZimmet_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ZimmetYonetim(), sender);
        }

        // Hurda Yönetim Sistemini açalým.
        private void btnHurda_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.HurdaYonetim(), sender);
        }

        // Raporlama Yönetim Sistemini açalým.
        private void btnRaporlama_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.RaporlamaYonetim(), sender);
        }

        // Ana Sayfa kýsmýna dönmek için X butonu koyarak iþlevsel hale getirelim.
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        private void lblOgrenciBilgisi_Click(object sender, EventArgs e)
        {

        }
    }
}