using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public static class ThemeHelper
    {
        // Siber-Neon Katı Renk Paletimiz
        public static readonly Color DarkBg = Color.FromArgb(18, 22, 31);          // Derin Gece Mavisi
        public static readonly Color ControlInputBg = Color.FromArgb(24, 30, 41);  // TextBox, ComboBox iç alan rengi
        public static readonly Color NeonGreen = Color.FromArgb(57, 255, 20);      // Siber Neon Yeşil
        public static readonly Color NeonBlue = Color.FromArgb(0, 191, 255);       // Detaylar için Neon Mavi
        public static readonly Color TextWhite = Color.FromArgb(230, 235, 245);     // Okunabilir Açık Gri/Beyaz

        // Cam Efekti İçin Kullanılacak Yarı Saydam Renk (Sadece Özel Çizimlerde Kullanılacak)
        private static readonly Color GlassOverlayColor = Color.FromArgb(160, 18, 22, 31); // %60 opak derin mavi/siyah

        /// <summary>
        /// Gönderilen forma arka plan görselini giydirir, titremeyi engeller ve tüm alt nesneleri o harika siber tasarıma uyarlar.
        /// </summary>
        public static void ApplyNeonTheme(Form form)
        {
            // Çift Arabelleğe Almayı Etkinleştir (Arka plan resmi yüklenirken formun titremesini/kasmasını kesinlikle engeller)
            SetDoubleBuffered(form);

            form.BackColor = DarkBg;
            form.ForeColor = TextWhite;

            // Arka Plan Resmini Güvenli Şekilde Yükleme (arka.jpg klasörde varsa)
            string imagePath = Path.Combine(Application.StartupPath, "arka.jpg");
            if (File.Exists(imagePath))
            {
                form.BackgroundImage = Image.FromFile(imagePath);
                form.BackgroundImageLayout = ImageLayout.Stretch;
            }

            // Formun içindeki tüm bileşenleri tek tek siber taramadan geçirip giydiriyoruz
            foreach (Control control in form.Controls)
            {
                ApplyControlStyle(control);
            }
        }

        private static void ApplyControlStyle(Control control)
        {
            // 1. Yazı Alanları, CheckBox ve RadioButton'ların arkasındaki siyah kütleyi kaldırıp tam transparan yapıyoruz
            if (control is Label || control is CheckBox || control is RadioButton)
            {
                control.BackColor = Color.Transparent;
                control.ForeColor = NeonGreen;
            }
            // 2. SİHİRLİ DOKUNUŞ: Panel ve GroupBox'ları arkasını kapatmayan Yarı Saydam Cam Kartlara dönüştürüyoruz
            else if (control is Panel || control is GroupBox)
            {
                control.BackColor = Color.Transparent; // Standart arka planı kaldır, resmi görsün
                control.ForeColor = TextWhite;

                // Panele kendi özel yarı saydam maskemizi ve neon çizgimizi çizdiriyoruz (Hata vermeyen yöntem)
                control.Paint -= Container_Paint; // Mükerrer aboneliği önle
                control.Paint += Container_Paint;
            }
            // 3. Metin Giriş Alanları (TextBox)
            else if (control is TextBox txt)
            {
                txt.BackColor = ControlInputBg;
                txt.ForeColor = TextWhite;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            // 4. Seçim Alanları (ComboBox)
            else if (control is ComboBox cmb)
            {
                cmb.BackColor = ControlInputBg;
                cmb.ForeColor = TextWhite;
                cmb.FlatStyle = FlatStyle.Flat;
            }
            // 5. Sayı Alanları (NumericUpDown)
            else if (control is NumericUpDown num)
            {
                num.BackColor = ControlInputBg;
                num.ForeColor = TextWhite;
                num.BorderStyle = BorderStyle.FixedSingle;
            }
            // 6. Butonlar (Neon Sınır Çizgili ve Mat Geçişli)
            else if (control is Button btn)
            {
                btn.BackColor = ControlInputBg;
                btn.ForeColor = NeonGreen;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = NeonGreen;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 50, 70); // Üzerine gelince tatlı bir parlama
                btn.Cursor = Cursors.Hand;
            }
            // 7. Veri Tabloları (DataGridView) - Arkası yarı saydam, satırları mat uyumlu
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = ControlInputBg;
                dgv.GridColor = Color.FromArgb(45, 55, 72);

                dgv.DefaultCellStyle.BackColor = ControlInputBg;
                dgv.DefaultCellStyle.ForeColor = TextWhite;
                dgv.DefaultCellStyle.SelectionBackColor = NeonGreen;
                dgv.DefaultCellStyle.SelectionForeColor = DarkBg;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = DarkBg;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = NeonGreen;
                dgv.EnableHeadersVisualStyles = false;
                dgv.BorderStyle = BorderStyle.None;
            }

            // Eğer kontrolün içinde başka alt kontroller varsa (Örn: Panel veya GroupBox içindeki elementler) onları da tara
            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                {
                    ApplyControlStyle(child);
                }
            }
        }

        /// <summary>
        /// Panellerin ve GroupBox'ların arkasına yarı saydam cam efekti ve etrafına neon yeşil ince çerçeve çizen özel çizim metodu.
        /// </summary>
        private static void Container_Paint(object sender, PaintEventArgs e)
        {
            Control container = (Control)sender;
            Graphics g = e.Graphics;

            // Yumuşak çizim kalitesi ayarla
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Panelin kapladığı alanı yarı saydam koyu renk ile doldur (Arkadaki kelebekli resim artık harika şekilde görünecek!)
            using (SolidBrush brush = new SolidBrush(GlassOverlayColor))
            {
                g.FillRectangle(brush, 0, 0, container.Width, container.Height);
            }

            // 2. Panelin etrafına o profesyonel tasarımdaki gibi çok ince, asil bir neon yeşil çerçeve at
            using (Pen pen = new Pen(Color.FromArgb(100, NeonGreen), 1)) // 100 değeri çizginin çok çiğ parlamasını engeller, matlaştırır
            {
                g.DrawRectangle(pen, 0, 0, container.Width - 1, container.Height - 1);
            }
        }

        /// <summary>
        /// WinForms'un resimleri işlerken ekranı kaydırmasını/titretmesini engelleyen optimizasyon.
        /// </summary>
        private static void SetDoubleBuffered(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(control, true, null);
        }
    }
}