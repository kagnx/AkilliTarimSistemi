using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using AkilliTarimSistemi.Services.Validation;
using AkilliTarimSistemi.Services.Logging;

namespace AkilliTarimSistemi.UI
{
    public partial class SuAnalizForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private PredictionEngine<SuAnaliziData, SuOnerisiPrediction>? _suOneriEngine;
        private readonly MLContext _mlContext = new MLContext();
        private int? _duzenlenenId = null;

        public SuAnalizForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);
            _unitOfWork = unitOfWork;

            this.Load += async (s, e) => await FormLoadAsync();

            // KEYBOARD KISAYOLLARI
            this.KeyPreview = true;
            this.KeyDown += SuAnalizForm_KeyDown;
        }

        private void SuAnalizForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { btnKaydet.PerformClick(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.N) { FormuTemizle(); e.Handled = true; }
            else if (e.KeyCode == Keys.F5) { btnYenile.PerformClick(); e.Handled = true; }
            else if (e.KeyCode == Keys.Delete && dgvSu.CurrentRow != null) { btnSil.PerformClick(); e.Handled = true; }
        }

        private async Task FormLoadAsync()
        {
            LoadUrunTipleri();
            LoadSuKaynaklari();
            await GridYenileAsync();
            await Task.Run(() => LoadMlEngine());
        }

        private void LoadUrunTipleri()
        {
            cmbUrun.DataSource = Enum.GetValues(typeof(UrunTipi));
        }

        private void LoadSuKaynaklari()
        {
            // Su kaynaklarinicmbKaynak'a yukle
            cmbKaynak.Items.Clear();
            cmbKaynak.Items.Add("Dere / Akarsu");
            cmbKaynak.Items.Add("Irmak / Nehir");
            cmbKaynak.Items.Add("Gol / Golet");
            cmbKaynak.Items.Add("Sulama Kanali");
            cmbKaynak.Items.Add("Sebeke Suyu");
            cmbKaynak.Items.Add("Deniz Suyu");
            cmbKaynak.Items.Add("Kuyu Suyu (Dogal)");
            cmbKaynak.Items.Add("Kuyu Suyu (Sondaj)");
            cmbKaynak.Items.Add("Yagmur Suyu Toplama");
            if (cmbKaynak.Items.Count > 0) cmbKaynak.SelectedIndex = 0;
        }

        private void LoadMlEngine()
        {
            try
            {
                var model = SuAnalizModelBuilder.LoadModel();
                if (model != null)
                    _suOneriEngine = _mlContext.Model.CreatePredictionEngine<SuAnaliziData, SuOnerisiPrediction>(model);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                    MessageBox.Show($"Su AI Motoru yuklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ));
            }
        }

        private async Task GridYenileAsync()
        {
            try
            {
                var veriler = await _unitOfWork.SuAnalizler.GetAllAsync();
                dgvSu.DataSource = null;
                dgvSu.DataSource = veriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Su analiz verileri listelenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await GridYenileAsync();
        }

        // --- GRID SATIR TIKLAMA ---
        private void dgvSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvSu.Rows[e.RowIndex];
                _duzenlenenId = Convert.ToInt32(row.Cells["Id"].Value);

                nudpH.Value = Convert.ToDecimal(row.Cells["pH"].Value ?? 0);
                nudEC.Value = Convert.ToDecimal(row.Cells["EC"].Value ?? 0);
                nudSertlik.Value = Convert.ToDecimal(row.Cells["Sertlik"].Value ?? 0);
                nudNitrat.Value = Convert.ToDecimal(row.Cells["Nitrat"].Value ?? 0);
                nudNitrit.Value = Convert.ToDecimal(row.Cells["Nitrit"].Value ?? 0);
                nudSodyum.Value = Convert.ToDecimal(row.Cells["Sodyum"].Value ?? 0);
                nudKlor.Value = Convert.ToDecimal(row.Cells["Klor"].Value ?? 0);

                if (row.Cells["Kaynak"].Value != null)
                    cmbKaynak.Text = row.Cells["Kaynak"].Value.ToString();
                if (row.Cells["UrunTipi"].Value != null)
                {
                    var urunStr = row.Cells["UrunTipi"].Value.ToString();
                    if (Enum.TryParse<UrunTipi>(urunStr, true, out var urunTipi))
                        cmbUrun.SelectedItem = urunTipi;
                }
            }
            catch { }
        }

        // --- SIL ---
        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvSu.CurrentRow == null)
            {
                MessageBox.Show("Lutfen tablodan silinecek kaydi secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = MessageBox.Show("Secili su analizi kaydini silmek istediginize emin misiniz?", "Silme Onayi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvSu.CurrentRow.Cells["Id"].Value);
                    var kayit = await _unitOfWork.SuAnalizler.GetByIdAsync(id);

                    if (kayit != null)
                    {
                        _unitOfWork.SuAnalizler.Remove(kayit);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Kayit basariyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _duzenlenenId = null;
                        FormuTemizle();
                        await GridYenileAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme hatasi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- KAYDET / GUNCELLE ---
        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATION
                var dogrulama = ValidationHelper.SuAnalizDogrula(
                    (double)nudpH.Value, (double)nudEC.Value,
                    (double)nudNitrat.Value, (double)nudNitrit.Value,
                    (double)nudSodyum.Value, (double)nudKlor.Value);

                if (!dogrulama.IsValid)
                {
                    MessageBox.Show(dogrulama.HataMesaji, "Dogrulama Hatasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool aiSulamayaUygun = false;
                if (_suOneriEngine != null)
                {
                    var input = new SuAnaliziData
                    {
                        pH = (float)nudpH.Value, EC = (float)nudEC.Value,
                        Sertlik = (float)nudSertlik.Value, Nitrat = (float)nudNitrat.Value,
                        Nitrit = (float)nudNitrit.Value, Sodyum = (float)nudSodyum.Value,
                        Klor = (float)nudKlor.Value
                    };
                    var prediction = _suOneriEngine.Predict(input);
                    aiSulamayaUygun = prediction.SulamayaUygun;
                }

                int suKalitesiSkoru = HesaplaSuKalitesiSkoru(
                    (double)nudpH.Value, (double)nudEC.Value,
                    (double)nudNitrat.Value, (double)nudNitrit.Value,
                    (double)nudSodyum.Value, (double)nudKlor.Value);

                if (_duzenlenenId.HasValue)
                {
                    // GUNCELLEME MODU
                    var mevcut = await _unitOfWork.SuAnalizler.GetByIdAsync(_duzenlenenId.Value);
                    if (mevcut != null)
                    {
                        mevcut.pH = (double)nudpH.Value;
                        mevcut.EC = (double)nudEC.Value;
                        mevcut.Sertlik = (double)nudSertlik.Value;
                        mevcut.Nitrat = (double)nudNitrat.Value;
                        mevcut.Nitrit = (double)nudNitrit.Value;
                        mevcut.Sodyum = (double)nudSodyum.Value;
                        mevcut.Klor = (double)nudKlor.Value;
                        mevcut.Kaynak = cmbKaynak.Text;
                        mevcut.UrunTipi = cmbUrun.Text;
                        mevcut.SulamayaUygun = aiSulamayaUygun;
                        mevcut.SuKalitesiSkoru = suKalitesiSkoru;
                        mevcut.GuncellemeTarihi = DateTime.Now;

                        _unitOfWork.SuAnalizleri.Update(mevcut);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Su analizi basariyla guncellendi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // YENI KAYIT
                    var yeniSuAnaliz = new SuAnaliz
                    {
                        pH = (double)nudpH.Value, EC = (double)nudEC.Value,
                        Sertlik = (double)nudSertlik.Value, Nitrat = (double)nudNitrat.Value,
                        Nitrit = (double)nudNitrit.Value, Sodyum = (double)nudSodyum.Value,
                        Klor = (double)nudKlor.Value, Kaynak = cmbKaynak.Text,
                        UrunTipi = cmbUrun.Text, SulamayaUygun = aiSulamayaUygun,
                        SuKalitesiSkoru = suKalitesiSkoru, AnalizTarihi = DateTime.Now,
                        KayitTarihi = DateTime.Now, AktifMi = true
                    };

                    await _unitOfWork.SuAnalizler.AddAsync(yeniSuAnaliz);
                    await _unitOfWork.CompleteAsync();

                    MessageBox.Show(
                        $"Su analizi veritabanina kaydedildi.\n\n" +
                        $"Su Kalite Skoru: {suKalitesiSkoru}/100\n" +
                        $"YZ Karari: {(aiSulamayaUygun ? "Uygun" : "Riskli")}",
                        "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _duzenlenenId = null;
                FormuTemizle();
                await GridYenileAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaydedilirken hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            _duzenlenenId = null;
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            nudpH.Value = 0;
            nudEC.Value = 0;
            nudSertlik.Value = 0;
            nudNitrat.Value = 0;
            nudNitrit.Value = 0;
            nudSodyum.Value = 0;
            nudKlor.Value = 0;
            if (cmbKaynak.Items.Count > 0) cmbKaynak.SelectedIndex = 0;
            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
        }

        private void btnSuYapayZeka_Click(object sender, EventArgs e)
        {
            if (_suOneriEngine == null)
            {
                MessageBox.Show("YZ motoru yukleniyor, lutfen bekleyin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var input = new SuAnaliziData
            {
                pH = (float)nudpH.Value, EC = (float)nudEC.Value,
                Sertlik = (float)nudSertlik.Value, Nitrat = (float)nudNitrat.Value,
                Nitrit = (float)nudNitrit.Value, Sodyum = (float)nudSodyum.Value,
                Klor = (float)nudKlor.Value
            };

            var prediction = _suOneriEngine.Predict(input);
            MessageBox.Show(prediction.OneriMetni, "YZ Su Analiz Sonucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static int HesaplaSuKalitesiSkoru(double pH, double ec, double nitrat, double nitrit, double sodyum, double klor)
        {
            int skor = 100;

            // pH - once ciddi sapmalari kontrol et
            if (pH < 6.0 || pH > 8.0) skor -= 30;
            else if (pH < 6.5 || pH > 7.5) skor -= 15;

            if (ec > 3.0) skor -= 25;
            else if (ec > 2.0) skor -= 15;
            else if (ec > 1.5) skor -= 8;

            if (nitrat > 50) skor -= 20;
            else if (nitrat > 25) skor -= 10;

            if (nitrit > 0.1) skor -= 15;
            else if (nitrit > 0.03) skor -= 8;

            if (sodyum > 100) skor -= 15;
            else if (sodyum > 50) skor -= 8;

            if (klor > 200) skor -= 15;
            else if (klor > 100) skor -= 8;

            return Math.Max(0, Math.Min(100, skor));
        }
    }
}
