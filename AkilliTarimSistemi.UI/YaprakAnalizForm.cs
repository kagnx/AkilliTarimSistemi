using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class YaprakAnalizForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private List<YaprakAnalizi> _yaprakAnalizleri = new();
        private int? _selectedAnalizId = null;

        public YaprakAnalizForm(IUnitOfWork unitOfWork, ITarlaService tarlaService)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;

            this.DoubleBuffered = true;
            this.Load += YaprakAnalizForm_Load;
        }

        private async void YaprakAnalizForm_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUrun.DataSource = Enum.GetValues(typeof(UrunTipi));
                cmbEksiklik.DataSource = Enum.GetValues(typeof(BitkiBesinEksikligi));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Enum yükleme hatası: {ex.Message}");
            }

            await ListeleAsync();
        }

        private async Task ListeleAsync()
        {
            try
            {
                _yaprakAnalizleri = (await _unitOfWork.YaprakAnalizler.GetAllAsync()).ToList();

                var displayList = _yaprakAnalizleri.Select(a => new
                {
                    a.Id,
                    Urun = a.UrunTipi.ToString(),
                    Tarih = a.Tarih,
                    Azot = a.AzotYaprak,
                    Fosfor = a.FosforYaprak,
                    Potasyum = a.PotasyumYaprak,
                    a.Demir,
                    a.Cinko,
                    a.Mangan,
                    a.Bakir,
                    Eksiklik = a.GozlenenEksiklik != null ? a.GozlenenEksiklik.ToString() : "Yok"
                }).ToList();

                dgvAnalizler.DataSource = displayList;
                dgvAnalizler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Listeleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🎯 KAYDET / GÜNCELLE BUTONU
        public async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                UrunTipi secilenUrun = cmbUrun.SelectedItem != null ? (UrunTipi)cmbUrun.SelectedItem : UrunTipi.Bugday;
                BitkiBesinEksikligi secilenEksiklik = cmbEksiklik.SelectedItem != null ? (BitkiBesinEksikligi)cmbEksiklik.SelectedItem : BitkiBesinEksikligi.Yok;

                if (_selectedAnalizId == null)
                {
                    var yeniYaprakAnalizi = new YaprakAnalizi
                    {
                        TarlaId = null,
                        Tarih = dtpTarih.Value,
                        UrunTipi = secilenUrun,
                        AzotYaprak = (double)nudAzot.Value,
                        FosforYaprak = (double)nudFosfor.Value,
                        PotasyumYaprak = (double)nudPotasyum.Value,
                        Demir = (double)nudDemir.Value,
                        Cinko = (double)nudCinko.Value,
                        Mangan = (double)nudMangan.Value,
                        Bakir = (double)nudBakir.Value,
                        GozlenenEksiklik = secilenEksiklik,
                        GorselNot = txtNot.Text,
                        OlusturmaTarihi = DateTime.Now,
                        Aktif = true
                    };

                    await _unitOfWork.YaprakAnalizler.AddAsync(yeniYaprakAnalizi);
                    MessageBox.Show($"{secilenUrun} ürünü için yaprak analizi başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var guncellenecek = _yaprakAnalizleri.FirstOrDefault(a => a.Id == _selectedAnalizId);
                    if (guncellenecek != null)
                    {
                        guncellenecek.UrunTipi = secilenUrun;
                        guncellenecek.Tarih = dtpTarih.Value;
                        guncellenecek.AzotYaprak = (double)nudAzot.Value;
                        guncellenecek.FosforYaprak = (double)nudFosfor.Value;
                        guncellenecek.PotasyumYaprak = (double)nudPotasyum.Value;
                        guncellenecek.Demir = (double)nudDemir.Value;
                        guncellenecek.Cinko = (double)nudCinko.Value;
                        guncellenecek.Mangan = (double)nudMangan.Value;
                        guncellenecek.Bakir = (double)nudBakir.Value;
                        guncellenecek.GozlenenEksiklik = secilenEksiklik;
                        guncellenecek.GorselNot = txtNot.Text;

                        _unitOfWork.YaprakAnalizler.Update(guncellenecek);
                        MessageBox.Show("Yaprak analizi başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                await _unitOfWork.CompleteAsync();
                await ListeleAsync();
                Temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt Hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🎯 TEMİZLE BUTONU (Tasarım ekranında görünmesi için public yapıldı)
        public void btnTemizle_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Temizle metodu tetiklendi.");
            Temizle();
        }

        // 🎯 YENİLE BUTONU (Tasarım ekranında görünmesi için public yapıldı)
        public async void btnYenile_Click(object sender, EventArgs e)
        {
            await ListeleAsync();
        }

        // 🎯 SİL BUTONU
        public async void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedAnalizId == null && dgvAnalizler.CurrentRow != null)
                {
                    var currentIdValue = dgvAnalizler.CurrentRow.Cells["Id"].Value;
                    if (currentIdValue != null)
                    {
                        _selectedAnalizId = Convert.ToInt32(currentIdValue);
                    }
                }

                if (_selectedAnalizId == null)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz analizi tablodan seçin!", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialogResult = MessageBox.Show($"{_selectedAnalizId} ID'li yaprak analizini silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var silinecek = _yaprakAnalizleri.FirstOrDefault(a => a.Id == _selectedAnalizId);
                    if (silinecek != null)
                    {
                        _unitOfWork.YaprakAnalizler.Remove(silinecek);
                        await _unitOfWork.CompleteAsync();

                        MessageBox.Show("Yaprak analizi başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await ListeleAsync();
                        Temizle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🎯 GRID SATIR SEÇME OLAYI (Tasarım ekranında görünmesi için public yapıldı)
        public void dgvAnalizler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    var row = dgvAnalizler.Rows[e.RowIndex];
                    if (row.Cells["Id"].Value != null)
                    {
                        _selectedAnalizId = Convert.ToInt32(row.Cells["Id"].Value);
                        var analiz = _yaprakAnalizleri.FirstOrDefault(a => a.Id == _selectedAnalizId);
                        if (analiz != null)
                        {
                            cmbUrun.SelectedItem = analiz.UrunTipi;
                            dtpTarih.Value = analiz.Tarih;
                            nudAzot.Value = (decimal)analiz.AzotYaprak;
                            nudFosfor.Value = (decimal)analiz.FosforYaprak;
                            nudPotasyum.Value = (decimal)analiz.PotasyumYaprak;
                            nudDemir.Value = (decimal)analiz.Demir;
                            nudCinko.Value = (decimal)analiz.Cinko;
                            nudMangan.Value = (decimal)analiz.Mangan;
                            nudBakir.Value = (decimal)analiz.Bakir;
                            cmbEksiklik.SelectedItem = analiz.GozlenenEksiklik;
                            txtNot.Text = analiz.GorselNot ?? "";

                            btnKaydet.Text = "Güncelle";
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Seçim Hatası: {ex.Message}");
                }
            }
        }

        private void Temizle()
        {
            nudAzot.Value = 0; nudFosfor.Value = 0; nudPotasyum.Value = 0;
            nudDemir.Value = 0; nudCinko.Value = 0; nudMangan.Value = 0; nudBakir.Value = 0;
            txtNot.Clear();

            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
            if (cmbEksiklik.Items.Count > 0) cmbEksiklik.SelectedIndex = 0;

            _selectedAnalizId = null;
            btnKaydet.Text = "Kaydet";
        }
    }
}