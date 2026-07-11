using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.ML;
using AkilliTarimSistemi.ML.Models;
using Microsoft.ML;
using Microsoft.Extensions.DependencyInjection;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.Services.Validation;
using AkilliTarimSistemi.Services.Logging;

namespace AkilliTarimSistemi.UI
{
    public partial class ToprakAnalizForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarlaService _tarlaService;

        private PredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>? _azotEngine;
        private PredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>? _fosforEngine;
        private PredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>? _potasyumEngine;
        private PredictionEngine<UrunTavsiyeData, UrunTavsiyePrediction>? _urunTavsiyeEngine;
        private PredictionEngine<VerimTahminiData, VerimTahminiPrediction>? _verimTahminEngine;

        private readonly MLContext _mlContext = new MLContext();
        private int? _duzenlenenId = null; // Duzenleme modu icin

        public ToprakAnalizForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);
            _tarlaService = Program.ServiceProvider.GetRequiredService<ITarlaService>();
            _unitOfWork = unitOfWork;

            this.Load += async (s, e) => await FormLoadAsync();

            // KEYBOARD KISAYOLLARI
            this.KeyPreview = true;
            this.KeyDown += ToprakAnalizForm_KeyDown;
        }

        private void ToprakAnalizForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { btnKaydet.PerformClick(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.N) { FormuTemizle(); e.Handled = true; }
            else if (e.KeyCode == Keys.F5) { btnYenile.PerformClick(); e.Handled = true; }
            else if (e.KeyCode == Keys.Delete && dgvToprak.CurrentRow != null) { btnSil.PerformClick(); e.Handled = true; }
        }

        private async Task FormLoadAsync()
        {
            try
            {
                cmbUrun.DataSource = Enum.GetValues(typeof(UrunTipi));

                // ToprakTipi ComboBox'ini doldur (eger Designer'da tanimliysa)
                if (Controls.Find("cmbToprakTipi", true).FirstOrDefault() is ComboBox cmbToprak)
                {
                    cmbToprak.DataSource = Enum.GetValues(typeof(ToprakTipi));
                }

                var tarlalar = await _tarlaService.GetAllAsync();
                if (tarlalar != null)
                {
                    cmbTarlaSec.DataSource = tarlalar.ToList();
                    cmbTarlaSec.DisplayMember = "TarlaAdi";
                    cmbTarlaSec.ValueMember = "Id";
                }

                await GridYenileAsync();
                await Task.Run(() => LoadAllSoilEngines());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yuklenirken hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllSoilEngines()
        {
            try
            {
                var (azotM, fosforM, potasyumM) = GubreOnerisiModelBuilder.LoadModels();
                _azotEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(azotM);
                _fosforEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(fosforM);
                _potasyumEngine = _mlContext.Model.CreatePredictionEngine<GubreOnerisiData, GubreOnerisiPrediction>(potasyumM);

                var urunM = UrunTavsiyeModelBuilder.LoadModel();
                _urunTavsiyeEngine = _mlContext.Model.CreatePredictionEngine<UrunTavsiyeData, UrunTavsiyePrediction>(urunM);

                var verimM = VerimTahminiModelBuilder.LoadModel();
                _verimTahminEngine = _mlContext.Model.CreatePredictionEngine<VerimTahminiData, VerimTahminiPrediction>(verimM);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                    MessageBox.Show($"YZ motorlari yuklenirken hata: {ex.Message}", "AI Uyarisi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ));
            }
        }

        private async Task GridYenileAsync()
        {
            try
            {
                var veriler = await _unitOfWork.ToprakAnalizler.GetAllAsync();
                dgvToprak.DataSource = null;
                dgvToprak.DataSource = veriler.ToList();

                // Kolon gizleme
                string[] gizlenecekler = { "ToprakTipi", "Kalsiyum", "Magnezyum", "Notlar", "Tarla", "TarlaId" };
                foreach (var kolon in gizlenecekler)
                {
                    if (dgvToprak.Columns[kolon] != null)
                        dgvToprak.Columns[kolon].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler listelenirken hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await GridYenileAsync();
        }

        // --- GRID SATIR TIKLAMA (DUZENLEME ICIN) ---
        private void dgvToprak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvToprak.Rows[e.RowIndex];
                _duzenlenenId = Convert.ToInt32(row.Cells["Id"].Value);

                nudpH.Value = Convert.ToDecimal(row.Cells["pH"].Value ?? 0);
                nudAzot.Value = Convert.ToDecimal(row.Cells["Azot"].Value ?? 0);
                nudFosfor.Value = Convert.ToDecimal(row.Cells["Fosfor"].Value ?? 0);
                nudPotasyum.Value = Convert.ToDecimal(row.Cells["Potasyum"].Value ?? 0);
                nudOrganikMadde.Value = Convert.ToDecimal(row.Cells["OrganikMadde"].Value ?? 0);
                nudEC.Value = Convert.ToDecimal(row.Cells["Tuzluluk"].Value ?? 0);

                if (row.Cells["Kalsiyum"].Value != null && Controls.Find("nudKalsiyum", true).FirstOrDefault() is NumericUpDown nudKal)
                    nudKal.Value = Convert.ToDecimal(row.Cells["Kalsiyum"].Value);
                if (row.Cells["Magnezyum"].Value != null && Controls.Find("nudMagnezyum", true).FirstOrDefault() is NumericUpDown nudMag)
                    nudMag.Value = Convert.ToDecimal(row.Cells["Magnezyum"].Value);
                if (row.Cells["Notlar"].Value != null && Controls.Find("txtNotlar", true).FirstOrDefault() is TextBox txtNot)
                    txtNot.Text = row.Cells["Notlar"].Value.ToString();
            }
            catch { }
        }

        // --- SIL ---
        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvToprak.CurrentRow == null)
            {
                MessageBox.Show("Lutfen silmek istediginiz kaydi tablodan secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = MessageBox.Show("Secili toprak analizi kaydini silmek istediginize emin misiniz?", "Kayit Silme Onayi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvToprak.CurrentRow.Cells["Id"].Value);
                    var kayit = await _unitOfWork.ToprakAnalizler.GetByIdAsync(id);

                    if (kayit != null)
                    {
                        _unitOfWork.ToprakAnalizler.Remove(kayit);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Kayit basariyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _duzenlenenId = null;
                        FormuTemizle();
                        await GridYenileAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme islemi sirasinda hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- KAYDET / GUNCELLE ---
        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATION
                var dogrulama = ValidationHelper.ToprakAnalizDogrula(
                    (double)nudpH.Value, (double)nudAzot.Value, (double)nudFosfor.Value,
                    (double)nudPotasyum.Value, (double)nudOrganikMadde.Value, (double)nudEC.Value);

                if (!dogrulama.IsValid)
                {
                    MessageBox.Show(dogrulama.HataMesaji, "Dogrulama Hatasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? selectedUrunText = cmbUrun.SelectedItem?.ToString();
                if (!Enum.TryParse<UrunTipi>(selectedUrunText, ignoreCase: true, out var urunTipi))
                    urunTipi = UrunTipi.Bugday;

                int? tarlaId = null;
                if (cmbTarlaSec.SelectedItem is Tarla seciliTarla)
                    tarlaId = seciliTarla.Id;

                // ToprakTipi'ni al
                ToprakTipi toprakTipi = ToprakTipi.Belirtilmedi;
                if (Controls.Find("cmbToprakTipi", true).FirstOrDefault() is ComboBox cmbToprak && cmbToprak.SelectedItem != null)
                    Enum.TryParse<ToprakTipi>(cmbToprak.SelectedItem.ToString(), true, out toprakTipi);

                // Kalsiyum ve Magnezyum degerlerini al
                double kalsiyum = 0, magnezyum = 0;
                if (Controls.Find("nudKalsiyum", true).FirstOrDefault() is NumericUpDown nudKal)
                    kalsiyum = (double)nudKal.Value;
                if (Controls.Find("nudMagnezyum", true).FirstOrDefault() is NumericUpDown nudMag)
                    magnezyum = (double)nudMag.Value;

                string? notlar = null;
                if (Controls.Find("txtNotlar", true).FirstOrDefault() is TextBox txtNot && !string.IsNullOrWhiteSpace(txtNot.Text))
                    notlar = txtNot.Text.Trim();

                if (_duzenlenenId.HasValue)
                {
                    // GUNCELLEME MODU
                    var mevcut = await _unitOfWork.ToprakAnalizler.GetByIdAsync(_duzenlenenId.Value);
                    if (mevcut != null)
                    {
                        mevcut.pH = (double)nudpH.Value;
                        mevcut.OrganikMadde = (double)nudOrganikMadde.Value;
                        mevcut.Azot = (double)nudAzot.Value;
                        mevcut.Fosfor = (double)nudFosfor.Value;
                        mevcut.Potasyum = (double)nudPotasyum.Value;
                        mevcut.Tuzluluk = (double)nudEC.Value;
                        mevcut.UrunTipi = urunTipi;
                        mevcut.ToprakTipi = toprakTipi;
                        mevcut.TarlaId = tarlaId;
                        mevcut.Kalsiyum = kalsiyum;
                        mevcut.Magnezyum = magnezyum;
                        mevcut.Notlar = notlar;
                        mevcut.GuncellemeTarihi = DateTime.Now;

                        _unitOfWork.ToprakAnalizler.Update(mevcut);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Toprak analizi basariyla guncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // YENI KAYIT MODU
                    var yeniAnaliz = new ToprakAnalizi
                    {
                        pH = (double)nudpH.Value,
                        OrganikMadde = (double)nudOrganikMadde.Value,
                        Azot = (double)nudAzot.Value,
                        Fosfor = (double)nudFosfor.Value,
                        Potasyum = (double)nudPotasyum.Value,
                        Tuzluluk = (double)nudEC.Value,
                        UrunTipi = urunTipi,
                        ToprakTipi = toprakTipi,
                        TarlaId = tarlaId,
                        Kalsiyum = kalsiyum,
                        Magnezyum = magnezyum,
                        Notlar = notlar,
                        Tarih = DateTime.Now
                    };

                    await _unitOfWork.ToprakAnalizler.AddAsync(yeniAnaliz);
                    await _unitOfWork.CompleteAsync();

                    MessageBox.Show("Toprak analizi basariyla veritabanina kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            nudOrganikMadde.Value = 0;
            nudAzot.Value = 0;
            nudFosfor.Value = 0;
            nudPotasyum.Value = 0;
            nudEC.Value = 0;
            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
            if (cmbTarlaSec.Items.Count > 0) cmbTarlaSec.SelectedIndex = 0;

            if (Controls.Find("nudKalsiyum", true).FirstOrDefault() is NumericUpDown nudKal) nudKal.Value = 0;
            if (Controls.Find("nudMagnezyum", true).FirstOrDefault() is NumericUpDown nudMag) nudMag.Value = 0;
            if (Controls.Find("txtNotlar", true).FirstOrDefault() is TextBox txtNot) txtNot.Clear();
            if (Controls.Find("cmbToprakTipi", true).FirstOrDefault() is ComboBox cmbToprak && cmbToprak.Items.Count > 0) cmbToprak.SelectedIndex = 0;
        }

        private void btnToprakYaykRaporu_Click(object sender, EventArgs e)
        {
            if (_urunTavsiyeEngine == null || _verimTahminEngine == null ||
                _azotEngine == null || _fosforEngine == null || _potasyumEngine == null)
            {
                MessageBox.Show("YZ modelleri arka planda yukleniyor, lutfen bekleyin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            float pHDegeri = (float)nudpH.Value;
            float orgMadde = (float)nudOrganikMadde.Value;
            float azot = (float)nudAzot.Value;
            float fosfor = (float)nudFosfor.Value;
            float potasyum = (float)nudPotasyum.Value;
            float ec = (float)nudEC.Value;
            string secilenUrun = cmbUrun.SelectedItem?.ToString() ?? "Bugday";
            string toprakTuru = "Standart";

            var gubreInput = new GubreOnerisiData
            {
                pH = pHDegeri, OrganikMadde = orgMadde,
                Azot_ppm = azot, Fosfor_ppm = fosfor, Potasyum_ppm = potasyum,
                Tuzluluk = ec, GecmisVerim_kg = 0, ToprakTuru = toprakTuru, UrunTipi = secilenUrun
            };

            float tahminAzot = _azotEngine.Predict(gubreInput).Score;
            float tahminFosfor = _fosforEngine.Predict(gubreInput).Score;
            float tahminPotasyum = _potasyumEngine.Predict(gubreInput).Score;

            var urunInput = new UrunTavsiyeData
            {
                Azot_ppm = azot, Fosfor_ppm = fosfor, Potasyum_ppm = potasyum,
                pH = pHDegeri, OrganikMadde = orgMadde, Tuzluluk = ec,
                ToprakTuru = toprakTuru, UrunTipi = secilenUrun, Kirec = 2.0f
            };
            var urunPrediction = _urunTavsiyeEngine.Predict(urunInput);

            var verimInput = new VerimTahminiData
            {
                Azot = azot, Fosfor = fosfor, Potasyum = potasyum,
                pH = pHDegeri, OrganikMadde = orgMadde, Tuzluluk = ec,
                ToprakTuru = toprakTuru, UrunTipi = secilenUrun,
                Yagis_mm = 0, Sicaklik_Ort = 0, SulamaYapildiMi = false,
                Gubreleme_TamMi = false, GecmisVerim_kg = 0
            };
            var verimPrediction = _verimTahminEngine.Predict(verimInput);

            string raporMetni = $"[YAPAY ZEKA TOPRAK ANALIZ RAPORU]\n\n" +
                                $"En Uygun Urun Tavsiyesi: {urunPrediction.PredictedLabel}\n\n" +
                                $"Mevcut Urun ({secilenUrun}) Icin Tahmini Verim:\n" +
                                $"{verimPrediction.PredictedVerim:F1} Kg / Dekar\n\n" +
                                $"Dekar Basina Ideal Guvre Recetesi:\n" +
                                $"- Azot (N): {Math.Max(0, tahminAzot):F1} kg\n" +
                                $"- Fosfor (P2O5): {Math.Max(0, tahminFosfor):F1} kg\n" +
                                $"- Potasyum (K2O): {Math.Max(0, tahminPotasyum):F1} kg";

            MessageBox.Show(raporMetni, "YZ Analiz Sonuclari", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
