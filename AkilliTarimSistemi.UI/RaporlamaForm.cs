using System;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class RaporlamaForm : Form
    {
        public RaporlamaForm()
        {
            InitializeComponent();
            // Form açılırken neon sihrini yükler:
            ThemeHelper.ApplyNeonTheme(this);
            cmbRaporTipi.Items.Add("Toprak Analiz Raporu");
            cmbRaporTipi.Items.Add("Yaprak Analiz Raporu");
            cmbRaporTipi.Items.Add("Su Analiz Raporu");
            cmbRaporTipi.SelectedIndex = 0;
            // 🚀 TİTREMEYİ ENGELLEYEN SİHİRLİ SATIRLAR
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void btnExcelOlustur_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyası|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Excel oluşturma servisi çağrılacak
                MessageBox.Show($"Rapor oluşturuldu: {sfd.FileName}", "Bilgi");
            }
        }

        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Dosyası|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // PDF oluşturma servisi çağrılacak
                MessageBox.Show($"PDF oluşturuldu: {sfd.FileName}", "Bilgi");
            }
        }
    }
}