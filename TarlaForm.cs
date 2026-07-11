using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.Services.Validation;
using AkilliTarimSistemi.Services.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class TarlaForm : Form
    {
        private readonly ITarlaService _tarlaService;
        private int? _duzenlenenId = null;

        public TarlaForm()
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        public TarlaForm(ITarlaService tarlaService) : this()
        {
            _tarlaService = tarlaService;

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            if (dgvTarlalar != null)
            {
                dgvTarlalar.DataError += dgvTarlalar_DataError;
                dgvTarlalar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvTarlalar.MultiSelect = false;
            }
        }

        private async void TarlaForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();

            try
            {
                if (cmbToprakTipi != null)
                    cmbToprakTipi.DataSource = Enum.GetValues(typeof(ToprakTipi));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Enum yuklenirken hata: {ex.Message}");
            }

            await TarlalariListele();

            // KEYBOARD KISAYOLLARI
            this.KeyPreview = true;
            this.KeyDown += TarlaForm_KeyDown;
        }

        private void TarlaForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { btnTarlaKaydet.PerformClick(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.N) { TemizleFormu(); e.Handled = true; }
            else if (e.KeyCode == Keys.F5) { btnYenile.PerformClick(); e.Handled = true; }
            else if (e.KeyCode == Keys.Delete && dgvTarlalar.CurrentRow != null) { btnSil.PerformClick(); e.Handled = true; }
        }

        private async Task TarlalariListele()
        {
            try
            {
                if (_tarlaService != null && dgvTarlalar != null)
                {
                    var tarlalar = await _tarlaService.GetAllAsync();
                    dgvTarlalar.DataSource = null;
                    dgvTarlalar.DataSource = tarlalar.ToList();

                    // Kolon basliklarini duzelt ve gizle
                    if (dgvTarlalar.Columns["Id"] != null) dgvTarlalar.Columns["Id"].HeaderText = "ID";
                    if (dgvTarlalar.Columns["TarlaAdi"] != null) dgvTarlalar.Columns["TarlaAdi"].HeaderText = "Tarla Adi";
                    if (dgvTarlalar.Columns["AlanDekar"] != null) dgvTarlalar.Columns["AlanDekar"].HeaderText = "Alan (da)";
                    if (dgvTarlalar.Columns["Konum"] != null) dgvTarlalar.Columns["Konum"].HeaderText = "Konum";
                    if (dgvTarlalar.Columns["ToprakTipi"] != null) dgvTarlalar.Columns["ToprakTipi"].HeaderText = "Toprak Tipi";

                    string[] gizlenecekler = { "KullaniciId", "Kullanici", "ToprakAnalizleri", "YaprakAnalizleri",
                        "SuAnalizleri", "SensorVerileri", "OrtalamaYagis", "OrtalamaSicaklik",
                        "Aktif", "OlusturmaTarihi", "GuncellemeTarihi" };
                    foreach (var kolon in gizlenecekler)
                    {
                        if (dgvTarlalar.Columns[kolon] != null)
                            dgvTarlalar.Columns[kolon].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tarlalar yuklenirken hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- GRID SATIR TIKLAMA (DUZENLEME MODU) ---
        private void dgvTarlalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvTarlalar.Rows[e.RowIndex];
                _duzenlenenId = Convert.ToInt32(row.Cells["Id"].Value);

                txtTarlaAdi.Text = row.Cells["TarlaAdi"].Value?.ToString() ?? "";
                txtKonum.Text = row.Cells["Konum"].Value?.ToString() ?? "";

                if (row.Cells["AlanDekar"].Value != null && numAlan != null)
                    numAlan.Value = Convert.ToDecimal(row.Cells["AlanDekar"].Value);

                if (cmbToprakTipi != null && row.Cells["ToprakTipi"].Value != null)
                {
                    var toprakTipiStr = row.Cells["ToprakTipi"].Value.ToString();
                    if (Enum.TryParse<ToprakTipi>(toprakTipiStr, true, out var toprakTipi))
                        cmbToprakTipi.SelectedItem = toprakTipi;
                }

                // Duzenleme modunda oldugumuzu kullaniciya bildir
                btnTarlaKaydet.Text = "Guncelle";
            }
            catch { }
        }

        // --- EKLE / GUNCELLE ---
        private async void btnTarlaKaydet_Click(object sender, EventArgs e)
        {
            // VALIDATION
            var dogrulama = ValidationHelper.TarlaDogrula(txtTarlaAdi.Text, (double)numAlan.Value);
            if (!dogrulama.IsValid)
            {
                MessageBox.Show(dogrulama.HataMesaji, "Dogrulama Hatasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbToprakTipi == null || cmbToprakTipi.SelectedItem == null || (ToprakTipi)cmbToprakTipi.SelectedItem == ToprakTipi.Belirtilmedi)
            {
                MessageBox.Show("Lutfen gecerli bir Toprak Tipi seciniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToprakTipi?.Focus();
                return;
            }

            try
            {
                if (_duzenlenenId.HasValue)
                {
                    // GUNCELLEME MODU
                    var mevcut = await _tarlaService.GetByIdAsync(_duzenlenenId.Value);
                    if (mevcut != null)
                    {
                        mevcut.TarlaAdi = txtTarlaAdi.Text.Trim();
                        mevcut.ToprakTipi = (ToprakTipi)cmbToprakTipi.SelectedItem;
                        mevcut.AlanDekar = (double)numAlan.Value;
                        mevcut.Konum = string.IsNullOrWhiteSpace(txtKonum.Text) ? "Belirtilmedi" : txtKonum.Text.Trim();
                        mevcut.GuncellemeTarihi = DateTime.Now;

                        await _tarlaService.UpdateAsync(mevcut);
                        MessageBox.Show("Tarla basariyla guncellendi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // YENI KAYIT MODU
                    var yeniTarla = new Tarla
                    {
                        TarlaAdi = txtTarlaAdi.Text.Trim(),
                        ToprakTipi = (ToprakTipi)cmbToprakTipi.SelectedItem,
                        AlanDekar = (double)numAlan.Value,
                        Konum = string.IsNullOrWhiteSpace(txtKonum.Text) ? "Belirtilmedi" : txtKonum.Text.Trim()
                    };

                    await _tarlaService.AddAsync(yeniTarla);
                    MessageBox.Show("Tarla basariyla sisteme kaydedildi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _duzenlenenId = null;
                btnTarlaKaydet.Text = "Kaydet";
                TemizleFormu();
                await TarlalariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Islem sirasinda hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TemizleFormu()
        {
            if (txtTarlaAdi != null) txtTarlaAdi.Clear();
            if (txtKonum != null) txtKonum.Clear();
            if (numAlan != null) numAlan.Value = 0;
            if (cmbToprakTipi != null && cmbToprakTipi.Items.Count > 0) cmbToprakTipi.SelectedIndex = 0;
            _duzenlenenId = null;
            btnTarlaKaydet.Text = "Kaydet";
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TemizleFormu();
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvTarlalar == null || dgvTarlalar.CurrentRow == null)
            {
                MessageBox.Show("Lutfen silmek istediginiz tarlayi tablodan secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tarlaId = Convert.ToInt32(dgvTarlalar.CurrentRow.Cells["Id"].Value);
            string tarlaAdi = dgvTarlalar.CurrentRow.Cells["TarlaAdi"].Value?.ToString() ?? "Bu tarla";

            var onay = MessageBox.Show(
                $"'{tarlaAdi}' adli tarlayi silmek istediginize emin misiniz?\n\nBu islem geri alinamaz!",
                "Silme Onayi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    await _tarlaService.DeleteAsync(tarlaId);
                    MessageBox.Show($"'{tarlaAdi}' basariyla silindi.", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _duzenlenenId = null;
                    btnTarlaKaydet.Text = "Kaydet";
                    TemizleFormu();
                    await TarlalariListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme islemi sirasinda hata olustu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            _duzenlenenId = null;
            btnTarlaKaydet.Text = "Kaydet";
            TemizleFormu();
            await TarlalariListele();
        }

        private void dgvTarlalar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
    }
}
