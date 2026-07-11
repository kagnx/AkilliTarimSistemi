using AkilliTarimSistemi.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class AnaForm : Form
    {
        private Form? aktifForm = null;
        private readonly IServiceProvider? _serviceProvider;

        // Designer için parametresiz constructor
        public AnaForm()
        {
            InitializeComponent();
            // Form açılırken neon sihrini yükler:
            ThemeHelper.ApplyNeonTheme(this);

            // Ekran ölçeklendirme hatalarını önlemek için sabit boyut ataması
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1250, 850);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None; // Modern kenarlıksız pencere
                                                         // 🚀 TİTREMEYİ ENGELLEYEN SİHİRLİ SATIRLAR
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        // Dependency Injection constructor
        public AnaForm(IServiceProvider serviceProvider) : this()
        {
            _serviceProvider = serviceProvider;
        }

        // Formları sağdaki pnlContainer içerisine gömen metot
        private void FormGoster(Form form)
        {
            if (form == null) return;
            if (aktifForm == form) return;

            if (aktifForm != null)
            {
                aktifForm.Hide();
                pnlContainer.Controls.Remove(aktifForm);
                aktifForm.Dispose();
            }

            aktifForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Form içindeki yazı ve kontrolleri otomatik beyaz yapar
            FormRenkleriniDuzenle(form);

            pnlContainer.Controls.Clear();
            pnlContainer.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        // Koyu temada yazıların (Label, GroupBox vb.) beyaz görünmesini sağlayan fonksiyon
        private void FormRenkleriniDuzenle(Form form)
        {
            form.ForeColor = Color.White;
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is Label || ctrl is GroupBox || ctrl is CheckBox || ctrl is RadioButton)
                {
                    ctrl.ForeColor = Color.White;
                }
                if (ctrl.HasChildren)
                {
                    foreach (Control childCtrl in ctrl.Controls)
                    {
                        if (childCtrl is Label || childCtrl is GroupBox || childCtrl is CheckBox || childCtrl is RadioButton)
                        {
                            childCtrl.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private async void AnaForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1250, 850);
            this.CenterToScreen();

            try
            {
                // Logo Kontrolü
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "a.png");
                if (System.IO.File.Exists(logoPath))
                {
                    if (picLogo != null) picLogo.Image = Image.FromFile(logoPath);
                }

                lblUser.Text = $"Hoş Geldiniz | {DateTime.Now:dd MMMM yyyy}";

                // İlk açılışta Toprak Analizini yükle
                BeginInvoke(new Action(() =>
                {
                    btnToprakAnaliz_Click(null, null);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Başlatma Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============ BUTON TIKLAMA OLAYLARI ============

        private void btnToprakAnaliz_Click(object? sender, EventArgs? e) => FormGetirVeGoster<ToprakAnalizForm>();
        private void btnYaprakAnaliz_Click(object? sender, EventArgs? e) => FormGetirVeGoster<YaprakAnalizForm>();
        private void btnSuAnaliz_Click(object? sender, EventArgs? e) => FormGetirVeGoster<SuAnalizForm>();
        private void btnOtomasyon_Click(object? sender, EventArgs? e) => FormGetirVeGoster<OtomasyonForm>();
        private void btnRaporlar_Click(object? sender, EventArgs? e) => FormGetirVeGoster<RaporlamaForm>();
        private void btnTarlalarim_Click(object? sender, EventArgs? e) => FormGetirVeGoster<TarlaForm>();

        private void FormGetirVeGoster<T>() where T : Form
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<T>();
                FormGoster(form);
            }
            else
            {
                MessageBox.Show("Servis sağlayıcı başlatılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Akıllı Tarım Sisteminden çıkmak istediğinizden emin misiniz?",
                "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHakkinda_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new Hakkinda())
            {
                aboutForm.ShowDialog();
            }
        }
    }
}