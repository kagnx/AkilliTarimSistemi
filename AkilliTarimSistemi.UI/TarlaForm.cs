using AkilliTarimSistemi.Core.DTOs;
using AkilliTarimSistemi.Core.Entities;
using AkilliTarimSistemi.Core.Enums;
using AkilliTarimSistemi.DAL.UnitOfWork;
using AkilliTarimSistemi.UI.Helpers;
using AkilliTarimSistemi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class TarlaForm : Form
    {
        private readonly ITarlaService _tarlaService;

        // Visual Studio Tasarımcısı (Designer) için parametresiz boş constructor
        public TarlaForm()
        {
            InitializeComponent();
            // Form açılırken neon sihrini yükler:
            ThemeHelper.ApplyNeonTheme(this);
            // 🚀 TİTREMEYİ ENGELLEYEN SİHİRLİ SATIRLAR
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        // Dependency Injection (DI) için kullanılacak gerçek constructor
        public TarlaForm(ITarlaService tarlaService) : this()
        {
            _tarlaService = tarlaService;

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // ★ EN KRİTİK DÜZENLEME: DataError olayını burada koda bağlıyoruz.
            // Böylece veritabanındaki 0 olan eski veriler bu formu asla kilitleyemeyecek!
            if (dgvTarlalar != null)
            {
                dgvTarlalar.DataError += dgvTarlalar_DataError;
            }
        }

        // Form ekrana ilk yüklendiğinde çalışacak metot
        private async void TarlaForm_Load(object sender, EventArgs e)
        {
            this.BringToFront();

            try
            {
                // ComboBox'a senin yazdığın harika detaylı ToprakTuru enum listesini bağlıyoruz
                if (cmbToprakTipi != null)
                {
                    cmbToprakTipi.DataSource = Enum.GetValues(typeof(ToprakTipi));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Enum yüklenirken hata: {ex.Message}");
            }

            // Form açılır açılmaz tarlaları listeleme fonksiyonunu çağırıyoruz
            await TarlalariListele();
        }

        // Veritabanındaki tarlaları çekip ekrandaki Grid'e basan metot
        private async System.Threading.Tasks.Task TarlalariListele()
        {
            try
            {
                if (_tarlaService != null && dgvTarlalar != null)
                {
                    var tarlalar = await _tarlaService.GetAllAsync();

                    // Grid'i güvenli bir şekilde tazelemek için
                    dgvTarlalar.DataSource = null;
                    dgvTarlalar.DataSource = tarlalar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tarlalar yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        // Tarla ekleme butonuna basıldığında çalışacak metot
        private async void btnTarlaKaydet_Click(object sender, EventArgs e)
        {
            // BOŞ KAYIT ENGELLEME BARİYERLERİ
            if (string.IsNullOrWhiteSpace(txtTarlaAdi.Text))
            {
                MessageBox.Show("Tarla Adı alanı boş bırakılamaz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTarlaAdi.Focus(); // İmleci otomatik oraya odaklar
                return; // Metodu burada keser, veritabanına asla gitmez
            }

            if (numAlan == null || numAlan.Value <= 0)
            {
                MessageBox.Show("Lütfen 0'dan büyük geçerli bir Alan (Dekar) değeri giriniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAlan?.Focus();
                return;
            }

            if (cmbToprakTipi == null || cmbToprakTipi.SelectedItem == null || (ToprakTipi)cmbToprakTipi.SelectedItem == ToprakTipi.Belirtilmedi)
            {
                MessageBox.Show("Lütfen geçerli bir Toprak Tipi seçiniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToprakTipi?.Focus();
                return;
            }

            try
            {
                // Tüm kontrollerden geçildiyse artık kayıt güvenlidir
                var yeniTarla = new AkilliTarimSistemi.Core.Entities.Tarla
                {
                    TarlaAdi = txtTarlaAdi.Text.Trim(), // Kenar boşluklarını temizler
                    ToprakTipi = (ToprakTipi)cmbToprakTipi.SelectedItem,
                    AlanDekar = (double)numAlan.Value,
                    Konum = string.IsNullOrWhiteSpace(txtKonum.Text) ? "Belirtilmedi" : txtKonum.Text.Trim()
                };

                await _tarlaService.AddAsync(yeniTarla);
                MessageBox.Show("Tarla başarıyla sisteme kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TemizleFormu();
                await TarlalariListele(); // Listeyi yenile
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt esnasında sistem hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Form kutularını sıfırlayan yardımcı metot
        private void TemizleFormu()
        {
            if (txtTarlaAdi != null) txtTarlaAdi.Clear();
            if (txtKonum != null) txtKonum.Clear();

            // DÜZELTME: Tasarım adın olan numAlan olarak güncellendi
            if (numAlan != null) numAlan.Value = 0;

            if (cmbToprakTipi != null && cmbToprakTipi.Items.Count > 0) cmbToprakTipi.SelectedIndex = 0;
        }

        // Temizle butonunun tetikleyeceği metot
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TemizleFormu();
        }

        // Sil butonunun tetikleyeceği metot
        private void btnSil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Silme işlemi henüz entegre edilmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Yenile butonunun tetikleyeceği metot
        private async void btnYenile_Click(object sender, EventArgs e)
        {
            await TarlalariListele();
        }

        // Grid üzerinde bir satıra tıklandığında çalışacak metot
        private void dgvTarlalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satır tıklandığında verileri kutulara doldurma kodları buraya gelecek
        }

        // O meşhur hata iletişim kutusunu susturan ve arayüzü kurtaran metot
        private void dgvTarlalar_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Hatayı yutarak kullanıcının karşısına engel çıkmasını engelliyoruz
            e.ThrowException = false;
        }
    }
}