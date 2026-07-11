using AkilliTarimSistemi.Core.DTOs;
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
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class YaprakAnalizForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarlaService _tarlaService;
        private PredictionEngine<YaprakAnaliziData, YaprakOnerisiPrediction>? _yaprakOneriEngine;
        private readonly MLContext _mlContext = new MLContext();
        private int? _duzenlenenId = null;

        public YaprakAnalizForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);
            _unitOfWork = unitOfWork;
            _tarlaService = Program.ServiceProvider.GetRequiredService<ITarlaService>();
        }

        private async void YaprakAnalizForm_Load(object? sender, EventArgs e)
        {
            cmbUrun.DataSource = Enum.GetValues(typeof(UrunTipi));

            // Tarla ComboBox'ini doldur
            try
            {
                var tarlalar = await _tarlaService.GetAllAsync();
                if (Controls.Find("cmbTarlaSec", true).FirstOrDefault() is ComboBox cmbTarla)
                {
                    cmbTarla.DataSource = tarlalar?.ToList();
                    cmbTarla.DisplayMember = "TarlaAdi";
                    cmbTarla.ValueMember = "Id";
                }
            }
            catch { }

            await GridYenileAsync();
            await Task.Run(() => LoadMlEngine());

            // KEYBOARD KISAYOLLARI
            this.KeyPreview = true;
            this.KeyDown += YaprakAnalizForm_KeyDown;
        }

        private void YaprakAnalizForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { btnKaydet.PerformClick(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.N) { FormuTemizle(); e.Handled = true; }
            else if (e.KeyCode == Keys.F5) { btnYenile.PerformClick(); e.Handled = true; }
            else if (e.KeyCode == Keys.Delete && dgvYaprak.CurrentRow != null) { btnSil.PerformClick(); e.Handled = true; }
        }

        private void LoadMlEngine()
        {
            try
            {
                var model = YaprakAnalizModelBuilder.LoadModel();
                if (model != null)
                    _yaprakOneriEngine = _mlContext.Model.CreatePredictionEngine<YaprakAnaliziData, YaprakOnerisiPrediction>(model);
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                    MessageBox.Show($"YZ motoru yuklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ));
            }
        }

        private async Task GridYenileAsync()
        {
            try
            {
                var veriler = await _unitOfWork.YaprakAnalizler.GetAllAsync();
                dgvYaprak.DataSource = null;
                dgvYaprak.DataSource = veriler;

                // Gereksiz kolonlari gizle
                string[] gizlenecekler = { "GozlenenEksiklik", "GorselNot", "Tarla", "TarlaId" };
                foreach (var kolon in gizlenecekler)
                {
                    if (dgvYaprak.Columns[kolon] != null)
                        dgvYaprak.Columns[kolon].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yaprak verileri listelenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await GridYenileAsync();
        }

        // --- GRID SATIR TIKLAMA ---
        private void dgvYaprak_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvYaprak.Rows[e.RowIndex];
                _duzenlenenId = Convert.ToInt32(row.Cells["Id"].Value);

                nudAzot.Value = Convert.ToDecimal(row.Cells["AzotYaprak"].Value ?? 0);
                nudFosfor.Value = Convert.ToDecimal(row.Cells["FosforYaprak"].Value ?? 0);
                nudPotasyum.Value = Convert.ToDecimal(row.Cells["PotasyumYaprak"].Value ?? 0);
                nudDemir.Value = Convert.ToDecimal(row.Cells["Demir"].Value ?? 0);
                nudCinko.Value = Convert.ToDecimal(row.Cells["Cinko"].Value ?? 0);
                nudMangan.Value = Convert.ToDecimal(row.Cells["Mangan"].Value ?? 0);
                nudBakir.Value = Convert.ToDecimal(row.Cells["Bakir"].Value ?? 0);

                if (row.Cells["GozlenenEksiklik"].Value != null)
                    cmbEksiklik.Text = row.Cells["GozlenenEksiklik"].Value.ToString();
                if (row.Cells["GorselNot"].Value != null && txtNot != null)
                    txtNot.Text = row.Cells["GorselNot"].Value.ToString();

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
            if (dgvYaprak.CurrentRow == null)
            {
                MessageBox.Show("Lutfen tablodan silinecek kaydi secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var onay = MessageBox.Show("Secili yaprak analizi kaydini silmek istiyor musunuz?", "Silme Onayi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvYaprak.CurrentRow.Cells["Id"].Value);
                    var kayit = await _unitOfWork.YaprakAnalizler.GetByIdAsync(id);

                    if (kayit != null)
                    {
                        _unitOfWork.YaprakAnalizler.Remove(kayit);
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
                var dogrulama = ValidationHelper.YaprakAnalizDogrula(
                    (double)nudAzot.Value, (double)nudFosfor.Value, (double)nudPotasyum.Value,
                    (double)nudDemir.Value, (double)nudCinko.Value, (double)nudMangan.Value, (double)nudBakir.Value);

                if (!dogrulama.IsValid)
                {
                    MessageBox.Show(dogrulama.HataMesaji, "Dogrulama Hatasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BitkiBesinEksikligi? secilenEksiklik = null;
                if (Enum.TryParse<BitkiBesinEksikligi>(cmbEksiklik.Text, true, out var sonucEnum))
                    secilenEksiklik = sonucEnum;

                int? tarlaId = null;
                if (Controls.Find("cmbTarlaSec", true).FirstOrDefault() is ComboBox cmbTarla && cmbTarla.SelectedItem is Tarla seciliTarla)
                    tarlaId = seciliTarla.Id;

                if (_duzenlenenId.HasValue)
                {
                    // GUNCELLEME MODU
                    var mevcut = await _unitOfWork.YaprakAnalizler.GetByIdAsync(_duzenlenenId.Value);
                    if (mevcut != null)
                    {
                        mevcut.AzotYaprak = (double)nudAzot.Value;
                        mevcut.FosforYaprak = (double)nudFosfor.Value;
                        mevcut.PotasyumYaprak = (double)nudPotasyum.Value;
                        mevcut.Demir = (double)nudDemir.Value;
                        mevcut.Cinko = (double)nudCinko.Value;
                        mevcut.Mangan = (double)nudMangan.Value;
                        mevcut.Bakir = (double)nudBakir.Value;
                        mevcut.GozlenenEksiklik = secilenEksiklik;
                        mevcut.GorselNot = txtNot.Text;
                        mevcut.UrunTipi = (UrunTipi)cmbUrun.SelectedItem;
                        mevcut.TarlaId = tarlaId;

                        _unitOfWork.YaprakAnalizler.Update(mevcut);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Yaprak analizi basariyla guncellendi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // YENI KAYIT
                    var yeniYaprakAnaliz = new YaprakAnalizi
                    {
                        Tarih = DateTime.Now,
                        AzotYaprak = (double)nudAzot.Value,
                        FosforYaprak = (double)nudFosfor.Value,
                        PotasyumYaprak = (double)nudPotasyum.Value,
                        Demir = (double)nudDemir.Value,
                        Cinko = (double)nudCinko.Value,
                        Mangan = (double)nudMangan.Value,
                        Bakir = (double)nudBakir.Value,
                        GozlenenEksiklik = secilenEksiklik,
                        GorselNot = txtNot.Text,
                        UrunTipi = (UrunTipi)cmbUrun.SelectedItem,
                        TarlaId = tarlaId
                    };

                    await _unitOfWork.YaprakAnalizler.AddAsync(yeniYaprakAnaliz);
                    await _unitOfWork.CompleteAsync();

                    MessageBox.Show("Detayli yaprak analizi kaydedildi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _duzenlenenId = null;
                FormuTemizle();
                await GridYenileAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayit hatasi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            _duzenlenenId = null;
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            nudAzot.Value = 0;
            nudFosfor.Value = 0;
            nudPotasyum.Value = 0;
            nudDemir.Value = 0;
            nudCinko.Value = 0;
            nudMangan.Value = 0;
            nudBakir.Value = 0;
            cmbEksiklik.Text = string.Empty;
            txtNot.Text = string.Empty;
            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
            if (Controls.Find("cmbTarlaSec", true).FirstOrDefault() is ComboBox cmbTarla && cmbTarla.Items.Count > 0)
                cmbTarla.SelectedIndex = 0;
        }

        private void btnYapayZekaTephis_Click(object sender, EventArgs e)
        {
            if (_yaprakOneriEngine == null)
            {
                MessageBox.Show("YZ motoru yukleniyor, lutfen bekleyin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var input = new YaprakAnaliziData
            {
                AzotYuzde = (float)nudAzot.Value,
                FosforYuzde = (float)nudFosfor.Value,
                PotasyumYuzde = (float)nudPotasyum.Value,
                DemirPpm = (float)nudDemir.Value,
                CinkoPpm = (float)nudCinko.Value,
                ManganPpm = (float)nudMangan.Value,
                BakirPpm = (float)nudBakir.Value
            };

            var prediction = _yaprakOneriEngine.Predict(input);

            MessageBox.Show($"[YAYK TESHISI]\n\n" +
                            $"Saptanan Durum: {prediction.TespitEdilenEksiklik}\n\n" +
                            $"Recete / Oneri:\n{prediction.MudahaleOnerisi}",
                            "YZ Yaprak Analiz Raporu", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cmbEksiklik.Text = prediction.TespitEdilenEksiklik;
        }
    }
}
