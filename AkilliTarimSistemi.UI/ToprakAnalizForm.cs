using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.Services;
using AkilliTarimSistemi.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class ToprakAnalizForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITarlaService _tarlaService;
        private List<ToprakAnalizi> _analizler = new();
        private int? _selectedAnalizId = null;

        public ToprakAnalizForm(IUnitOfWork unitOfWork, ITarlaService tarlaService)
        {
            InitializeComponent();
            ThemeHelper.ApplyNeonTheme(this);
            _unitOfWork = unitOfWork;
            _tarlaService = tarlaService;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.Load += ToprakAnalizForm_Load;
            this.dgvAnalizler.CellClick += dgvAnalizler_CellClick;
        }

        private async void ToprakAnalizForm_Load(object sender, EventArgs e)
        {
            UrunHelper.UrunComboBoxDoldur(cmbUrun);
            await TarlalarıComboBoxDoldurAsync();
            await Listele();
        }

        public async Task TarlalarıComboBoxDoldurAsync()
        {
            try
            {
                var tarlalar = await _tarlaService.GetAllAsync();

                // 🚀 CS1061 ÇÖZÜMÜ: Tarla nesnesinin property adı 'TarlaAdi' veya 'Ad' olabilir. 
                // Eğer entity içinde 'TarlaAdi' kullanıyorsan t.TarlaAdi yap, 'Ad' ise t.Ad olarak bırak.
                var tarlaListesi = tarlalar.Select(t => new KeyValuePair<int, string>(t.Id, t.TarlaAdi)).ToList();

                // 🚀 CS0103 ÇÖZÜMÜ: Eğer tasarım ekranında ComboBox adın 'cmbTarla' ise burayı 'cmbTarla' yap.
                cmbTarlaSec.DataSource = tarlaListesi;
                cmbTarlaSec.DisplayMember = "Value";
                cmbTarlaSec.ValueMember = "Key";

                if (tarlaListesi.Count == 0)
                {
                    // Formunda bir durum label'ı (lblDurum) yoksa bu satırı güvenle silebilirsin.
                    // lblDurum.Text = "Sistemde tarla bulunamadı!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tarlalar listesi yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Listele()
        {
            try
            {
                _analizler = (await _unitOfWork.ToprakAnalizler.GetAllAsync()).ToList();

                var displayList = _analizler.Select(a => new
                {
                    a.Id,
                    // 🚀 CS1061 ÇÖZÜMÜ: İlişkisel tarla ismi alanı için 'TarlaAdi' mülkünü okuyoruz
                    Tarla = a.Tarla?.TarlaAdi ?? "Bilinmeyen Tarla",
                    Urun = a.UrunTipi.ToString(),
                    Tarih = a.Tarih,
                    a.pH,
                    a.Azot,
                    a.Fosfor,
                    a.Potasyum,
                    a.OrganikMadde,
                    a.Tuzluluk,
                    a.Notlar
                }).ToList();

                dgvAnalizler.DataSource = displayList;
                dgvAnalizler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Liste yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Tarla Seçim Kontrolü ve Güvenli Unboxing
                if (cmbTarlaSec.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen analizin ait olduğu tarlayı seçin!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int seciliTarlaId = 0;
                if (cmbTarlaSec.SelectedItem is KeyValuePair<int, string> tarlaKvp)
                {
                    seciliTarlaId = tarlaKvp.Key;
                }

                if (seciliTarlaId <= 0)
                {
                    MessageBox.Show("Geçersiz Tarla seçimi yapıldı. Lütfen tarlayı tekrar seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Ürün Seçim Kontrolü ve Enum'a Güvenli Dönüştürme
                UrunTipi secilenUrunTipi = UrunTipi.Bugday; // Default güvenli bir değer
                if (cmbUrun.SelectedItem != null)
                {
                    if (cmbUrun.SelectedItem is KeyValuePair<int, string> urunKvp)
                    {
                        secilenUrunTipi = (UrunTipi)urunKvp.Key;
                    }
                    else if (cmbUrun.SelectedItem is UrunTipi doğrudanEnum)
                    {
                        secilenUrunTipi = doğrudanEnum;
                    }
                    else
                    {
                        // Eğer string veya başka bir tip olarak dolduysa Enum.Parse ile garantiye alalım
                        string selectedText = cmbUrun.SelectedItem.ToString();
                        if (Enum.TryParse(selectedText, out UrunTipi parsedEnum))
                        {
                            secilenUrunTipi = parsedEnum;
                        }
                    }
                }

                // 3. KAYDETME VEYA GÜNCELLEME İŞLEMİ
                if (_selectedAnalizId == null)
                {
                    // YENİ KAYIT
                    var yeniAnaliz = new ToprakAnalizi
                    {
                        TarlaId = seciliTarlaId,
                        Tarih = dtpTarih.Value,
                        UrunTipi = secilenUrunTipi, // Güvenli enum ataması
                        pH = (double)nudpH.Value,
                        Azot = (double)nudAzot.Value,
                        Fosfor = (double)nudFosfor.Value,
                        Potasyum = (double)nudPotasyum.Value,
                        Kalsiyum = (double)nudKalsiyum.Value,
                        Magnezyum = (double)nudMagnezyum.Value,
                        OrganikMadde = (double)nudOrganikMadde.Value,
                        Tuzluluk = (double)nudTuzluluk.Value,
                        Notlar = txtNotlar.Text,
                        OlusturmaTarihi = DateTime.Now,
                        Aktif = true
                    };

                    await _unitOfWork.ToprakAnalizler.AddAsync(yeniAnaliz);
                    MessageBox.Show("Toprak analizi başarıyla veritabanına kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // GÜNCELLEME
                    var guncellenecek = _analizler.FirstOrDefault(a => a.Id == _selectedAnalizId);
                    if (guncellenecek != null)
                    {
                        guncellenecek.TarlaId = seciliTarlaId;
                        guncellenecek.Tarih = dtpTarih.Value;
                        guncellenecek.UrunTipi = secilenUrunTipi;
                        guncellenecek.pH = (double)nudpH.Value;
                        guncellenecek.Azot = (double)nudAzot.Value;
                        guncellenecek.Fosfor = (double)nudFosfor.Value;
                        guncellenecek.Potasyum = (double)nudPotasyum.Value;
                        guncellenecek.Kalsiyum = (double)nudKalsiyum.Value;       // Eksikti, Eklendi!
                        guncellenecek.Magnezyum = (double)nudMagnezyum.Value;     // Eksikti, Eklendi!
                        guncellenecek.OrganikMadde = (double)nudOrganikMadde.Value;
                        guncellenecek.Tuzluluk = (double)nudTuzluluk.Value;
                        guncellenecek.Notlar = txtNotlar.Text;

                        _unitOfWork.ToprakAnalizler.Update(guncellenecek);
                        MessageBox.Show("Toprak analizi başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // 4. Değişiklikleri Veritabanına Zorla Yaz ve Arayüzü Tazele
                await _unitOfWork.CompleteAsync();
                await Listele();
                Temizle();
            }
            catch (Exception ex)
            {
                // Hatanın iç yüzünü tam görebilmek için InnerException detayını ekrana basıyoruz
                string icHata = ex.InnerException != null ? $"\nDetay: {ex.InnerException.Message}" : "";
                MessageBox.Show($"Kayıt Gerçekleştirilemedi! {icHata}\nGenel Hata: {ex.Message}", "Veritabanı Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvAnalizler.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dynamic selected = dgvAnalizler.CurrentRow.DataBoundItem;
                int id = selected.Id;

                var silinecek = _analizler.FirstOrDefault(a => a.Id == id);
                if (silinecek == null) return;

                if (MessageBox.Show("Seçili analiz silinsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _unitOfWork.ToprakAnalizler.Delete(silinecek);
                    await _unitOfWork.CompleteAsync();

                    await Listele();
                    Temizle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi gerçekleştirilemedi: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAnalizler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dynamic selected = dgvAnalizler.Rows[e.RowIndex].DataBoundItem;
                if (selected == null) return;

                int id = selected.Id;
                var analiz = _analizler.FirstOrDefault(a => a.Id == id);

                if (analiz != null)
                {
                    _selectedAnalizId = analiz.Id;

                    for (int i = 0; i < cmbUrun.Items.Count; i++)
                    {
                        var item = (KeyValuePair<int, string>)cmbUrun.Items[i];
                        if (item.Key == (int)analiz.UrunTipi)
                        {
                            cmbUrun.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < cmbTarlaSec.Items.Count; i++)
                    {
                        var item = (KeyValuePair<int, string>)cmbTarlaSec.Items[i];
                        if (item.Key == analiz.TarlaId)
                        {
                            cmbTarlaSec.SelectedIndex = i;
                            break;
                        }
                    }

                    dtpTarih.Value = analiz.Tarih;
                    nudpH.Value = (decimal)analiz.pH;
                    nudAzot.Value = (decimal)analiz.Azot;
                    nudFosfor.Value = (decimal)analiz.Fosfor;
                    nudPotasyum.Value = (decimal)analiz.Potasyum;
                    nudOrganikMadde.Value = (decimal)analiz.OrganikMadde;
                    nudTuzluluk.Value = (decimal)analiz.Tuzluluk;
                    txtNotlar.Text = analiz.Notlar;

                    btnKaydet.Text = "Güncelle";
                }
            }
        }

        private void Temizle()
        {
            if (cmbUrun.Items.Count > 0) cmbUrun.SelectedIndex = 0;
            if (cmbTarlaSec.Items.Count > 0) cmbTarlaSec.SelectedIndex = 0;
            dtpTarih.Value = DateTime.Now;
            nudpH.Value = 7;
            nudAzot.Value = 0;
            nudFosfor.Value = 0;
            nudPotasyum.Value = 0;
            nudOrganikMadde.Value = 0;
            nudTuzluluk.Value = 0;
            txtNotlar.Clear();
            _selectedAnalizId = null;
            btnKaydet.Text = "Kaydet";
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await TarlalarıComboBoxDoldurAsync();
            await Listele();
        }
        private void btnTemizle_Click(object sender, EventArgs e) => Temizle();
    }
}