using System;
using System.Windows.Forms;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.Core.Entities;

namespace AkilliTarimSistemi.UI
{
    public partial class OtomasyonForm : Form
    {
        private System.Windows.Forms.Timer simTimer;   // Tam isim
        private Random rnd = new Random();
        private readonly IIoTSensorService _sensorService;
        private bool servisKullanilsin = false;

        public OtomasyonForm(IIoTSensorService sensorService)
        {
            InitializeComponent();
            // Form açılırken neon sihrini yükler:
            ThemeHelper.ApplyNeonTheme(this);
            _sensorService = sensorService;
            _sensorService.NewSensorDataReceived += OnNewSensorDataReceived;
            // 🚀 TİTREMEYİ ENGELLEYEN SİHİRLİ SATIRLAR
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }


        private void btnBaslat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Gerçek sensör servisini kullanmak ister misiniz?\nEvet->Servis, Hayır->Simülasyon",
                                          "Seçim", MessageBoxButtons.YesNo);
            servisKullanilsin = (result == DialogResult.Yes);

            if (servisKullanilsin)
            {
                int tarlaId = 1;
                _sensorService.StartMonitoring(tarlaId);
                btnBaslat.Enabled = false;
                btnDurdur.Enabled = true;
                lblDurum.Text = "Servis başlatıldı, sensör bekleniyor...";
            }
            else
            {
                if (simTimer == null)
                {
                    simTimer = new System.Windows.Forms.Timer();  // Tam isim
                    simTimer.Interval = 2000;
                    simTimer.Tick += SimTimer_Tick;
                }
                simTimer.Start();
                btnBaslat.Enabled = false;
                btnDurdur.Enabled = true;
                lblDurum.Text = "Simülasyon başlatıldı";
            }
        }

        private void SimTimer_Tick(object sender, EventArgs e)
        {
            double sicaklik = rnd.Next(15, 35);
            double nem = rnd.Next(40, 80);
            double toprakNemi = rnd.Next(20, 60);
            dgvSensor.Rows.Add(DateTime.Now.ToString("HH:mm:ss"), sicaklik, nem, toprakNemi);
            if (chkOtomatikSulama.Checked && toprakNemi < 30)
            {
                lblDurum.Text = "Sulama aktif (otomatik - simülasyon)";
            }
        }

        private void OnNewSensorDataReceived(object? sender, SensorVerisi data)
        {
            if (InvokeRequired)
                Invoke(new Action(() => GosterSensorVerisi(data)));
            else
                GosterSensorVerisi(data);
        }

        private void GosterSensorVerisi(SensorVerisi data)
        {
            dgvSensor.Rows.Add(data.OkumaZamani.ToString("HH:mm:ss"), data.Sicaklik, data.Nem, data.ToprakNemi);
            if (chkOtomatikSulama.Checked && data.ToprakNemi < 30)
                lblDurum.Text = "Sulama aktif (otomatik - gerçek sensör)";
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            if (servisKullanilsin)
                _sensorService.StopMonitoring();
            else
                simTimer?.Stop();

            btnBaslat.Enabled = true;
            btnDurdur.Enabled = false;
            lblDurum.Text = "Durdu";
        }

        private void btnManuelSulamaAc_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Sulama manuel açıldı";
        }

        private void btnManuelSulamaKapa_Click(object sender, EventArgs e)
        {
            lblDurum.Text = "Sulama manuel kapatıldı";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _sensorService.StopMonitoring();
            simTimer?.Stop();
            base.OnFormClosing(e);
        }

        private void OtomasyonForm_Load(object sender, EventArgs e)
        {
            // Tema zaten constructor'da uygulandi
        }
    }
}