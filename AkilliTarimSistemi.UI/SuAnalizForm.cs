using AkilliTarimSistemi.Core.Enums;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class SuAnalizForm : Form
    {
        public SuAnalizForm()
        {
            InitializeComponent();
            // Form açılırken neon sihrini yükler:
            ThemeHelper.ApplyNeonTheme(this);
            Load += SuAnalizForm_Load;
            // 🚀 TİTREMEYİ ENGELLEYEN SİHİRLİ SATIRLAR
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void SuAnalizForm_Load(object sender, EventArgs e)
        {
            try
            {
                var urunler = Enum.GetValues(typeof(UrunTipi))
                    .Cast<UrunTipi>()
                    .Select(u => new { Value = (int)u, Name = u.ToString() })
                    .ToList();

                cmbUrun.DataSource = null;
                cmbUrun.Items.Clear();
                cmbUrun.DataSource = urunler;
                cmbUrun.DisplayMember = "Name";
                cmbUrun.ValueMember = "Value";

                this.BeginInvoke(new Action(() =>
                {
                    if (cmbUrun.Items.Count > 0)
                        cmbUrun.SelectedIndex = 0;
                }));

                // Su kaynağı listesi
                cmbKaynak.Items.Clear();
                cmbKaynak.Items.AddRange(new string[] { "Kuyu", "Nehir", "Göl", "Şebeke" });
                cmbKaynak.SelectedIndex = 0;

                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata");
            }
        }

        private void Listele()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Ürün", typeof(string));
            dt.Columns.Add("Tarih", typeof(DateTime));
            dt.Columns.Add("pH", typeof(double));
            dt.Columns.Add("EC", typeof(double));
            dt.Rows.Add(1, "Buğday", DateTime.Now, 7.2, 450);
            dgvAnalizler.DataSource = dt;
            dgvAnalizler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçin.");
                return;
            }
            int secilenUrunId = (int)cmbUrun.SelectedValue;
            MessageBox.Show($"Su analizi kaydedildi (Ürün ID: {secilenUrunId})");
            Listele();
            Temizle();
        }

        private void Temizle()
        {
            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
            dtpTarih.Value = DateTime.Now;
            nudpH.Value = 7;
            nudEC.Value = 0;
            nudSertlik.Value = 0;
            nudNitrat.Value = 0;
            nudNitrit.Value = 0;
            nudSodyum.Value = 0;
            nudKlor.Value = 0;
            cmbKaynak.SelectedIndex = 0;
            chkSulamayaUygun.Checked = false;
            txtNotlar.Clear();
        }

        private void btnTemizle_Click(object sender, EventArgs e) => Temizle();
        private void btnYenile_Click(object sender, EventArgs e) => Listele();
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAnalizler.CurrentRow != null)
            {
                if (MessageBox.Show("Silinsin mi?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("Silindi.");
                    Listele();
                }
            }
        }
    }
}