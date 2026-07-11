using System;
using System.Drawing;
using System.Windows.Forms;
using AkilliTarimSistemi.Services.Logging;

namespace AkilliTarimSistemi.UI
{
    public partial class LoginForm : Form
    {
        public bool GirisBasarili { get; private set; }
        public string KullaniciAdi { get; private set; } = string.Empty;

        public LoginForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            this.BackColor = Color.FromArgb(18, 22, 31);
            this.ForeColor = Color.FromArgb(230, 235, 245);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giris - Akilii Tarim Sistemi";
            this.ClientSize = new Size(400, 320);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanici adi ve sifre bos birakilamaz!", "Uyari",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Basit dogrulama (gercek uygulamada veritabanindan kontrol edilmeli)
            if (kullaniciAdi.ToLower() == "admin" && sifre == "admin")
            {
                GirisBasarili = true;
                KullaniciAdi = kullaniciAdi;
                LogManager.BilgiYaz($"Basarili giris: {kullaniciAdi}", "LoginForm");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                LogManager.UyariYaz($"Basarisiz giris denemesi: {kullaniciAdi}", "LoginForm");
                MessageBox.Show("Kullanici adi veya sifre hatali!\n\nVarsayilan: admin/admin",
                    "Hatali Giris", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear();
                txtSifre.Focus();
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiris_Click(sender, e);
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSifre.Focus();
        }
    }
}
