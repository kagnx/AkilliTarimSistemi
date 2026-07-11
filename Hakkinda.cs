using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    public partial class Hakkinda : Form
    {
        private System.Windows.Forms.Timer glowTimer;
        private System.Windows.Forms.Timer neonTimer;

        public Hakkinda()
        {
            InitializeComponent();
            this.Load += Hakkinda_Load;

            // Buton event'lerini bağla
            if (btnClose != null)
                btnClose.Click += btnClose_Click;

            // Sosyal medya event'leri
            if (lblFacebookValue != null)
            {
                lblFacebookValue.Click += SocialLink_Click;
                lblFacebookValue.MouseEnter += SocialLink_MouseEnter;
                lblFacebookValue.MouseLeave += SocialLink_MouseLeave;
            }

            if (lblInstagramValue != null)
            {
                lblInstagramValue.Click += SocialLink_Click;
                lblInstagramValue.MouseEnter += SocialLink_MouseEnter;
                lblInstagramValue.MouseLeave += SocialLink_MouseLeave;
            }

            // Email event'i
            if (lblEmailValue != null)
            {
                lblEmailValue.Click += Email_Click;
                lblEmailValue.MouseEnter += SocialLink_MouseEnter;
                lblEmailValue.MouseLeave += SocialLink_MouseLeave;
            }
        }

        private void Hakkinda_Load(object sender, EventArgs e)
        {
            ApplyNeonTheme();
            SetupAnimations();
            AddTechTags();
            UpdateVersionInfo();
        }

        private void ApplyNeonTheme()
        {
            this.BackColor = Color.FromArgb(15, 15, 25);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "⚡ Hakkında - Akıllı Tarım Sistemi";

            // Ana panel arkaplanı
            if (pnlMain != null)
            {
                pnlMain.BackColor = Color.FromArgb(20, 20, 35);
            }

            // Border paneli neon renk
            if (pnlBorder != null)
            {
                pnlBorder.BackColor = Color.FromArgb(0, 255, 200);
            }

            // Icon paneli
            if (pnlIcon != null)
            {
                pnlIcon.BackColor = Color.FromArgb(0, 60, 60);
            }
        }

        private void SetupAnimations()
        {
            // Glow efekti - Başlık
            glowTimer = new System.Windows.Forms.Timer();
            glowTimer.Interval = 600;
            int glowState = 0;
            glowTimer.Tick += (s, e) =>
            {
                glowState = (glowState + 1) % 2;
                if (lblTitle != null)
                {
                    lblTitle.ForeColor = glowState == 0
                        ? Color.FromArgb(0, 255, 255)
                        : Color.FromArgb(0, 200, 200);
                }
                if (lblSlogan != null)
                {
                    lblSlogan.ForeColor = glowState == 0
                        ? Color.FromArgb(0, 255, 150)
                        : Color.FromArgb(0, 200, 100);
                }
            };
            glowTimer.Start();

            // Neon renk geçişi - Slogan için
            neonTimer = new System.Windows.Forms.Timer();
            neonTimer.Interval = 100;
            int colorIndex = 0;
            Color[] neonColors = new Color[]
            {
                Color.FromArgb(0, 255, 200),
                Color.FromArgb(100, 255, 150),
                Color.FromArgb(0, 200, 255),
                Color.FromArgb(50, 255, 200),
                Color.FromArgb(0, 255, 150)
            };

            if (lblSubTitle != null)
            {
                neonTimer.Tick += (s, e) =>
                {
                    colorIndex = (colorIndex + 1) % neonColors.Length;
                    lblSubTitle.ForeColor = neonColors[colorIndex];
                };
                neonTimer.Start();
            }
        }

        private void UpdateVersionInfo()
        {
            // Versiyon bilgisini güncelle
            if (lblVersion != null)
            {
                lblVersion.Text = $"v{Application.ProductVersion}";
            }

            // Geliştirici adını düzenle
            if (lblDeveloperName != null)
            {
                lblDeveloperName.Text = "Oğuz Kaan FIRAT";
            }

            // Email değerini düzelt
            if (lblEmailValue != null)
            {
                lblEmailValue.Text = "oguzkaanfirat@windowslive.com";
            }

            // Sosyal medya değerlerini düzelt
            if (lblFacebookValue != null)
            {
                lblFacebookValue.Text = "@kagnx";
            }

            if (lblInstagramValue != null)
            {
                lblInstagramValue.Text = "@kagnx";
            }

            // Telif yılını güncelle
            if (lblCopyright != null)
            {
                lblCopyright.Text = $"© {DateTime.Now.Year} Her Hakkı Saklıdır | Akıllı Tarım Sistemi";
            }
        }

        private void AddTechTags()
        {
            if (flpTech == null) return;

            string[] technologies = new string[]
            {
                "🚀 C#", "⚡ .NET 10.0", "🎨 WinForms", 
                "🗄️ Entity Framework Core", "🤖 ML.NET", 
                "🧠 Yapay Zeka", "📀 SQLite", "💜 Neon UI",
                "🌾 Akıllı Tarım", "📊 Veri Analizi",
                "🔮 Makine Öğrenmesi", "🌱 Sensör Verileri"
            };

            flpTech.Controls.Clear();
            flpTech.AutoSize = true;
            flpTech.FlowDirection = FlowDirection.LeftToRight;
            flpTech.WrapContents = false;
            flpTech.Padding = new Padding(5);

            foreach (string tech in technologies)
            {
                Label tag = new Label
                {
                    Text = tech,
                    BackColor = Color.FromArgb(0, 60, 60),
                    ForeColor = Color.FromArgb(0, 255, 200),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    Padding = new Padding(10, 5, 10, 5),
                    Margin = new Padding(3, 3, 3, 3),
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Help
                };

                tag.MouseEnter += (s, e) =>
                {
                    tag.BackColor = Color.FromArgb(0, 120, 120);
                    tag.ForeColor = Color.White;
                    tag.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline);
                };

                tag.MouseLeave += (s, e) =>
                {
                    tag.BackColor = Color.FromArgb(0, 60, 60);
                    tag.ForeColor = Color.FromArgb(0, 255, 200);
                    tag.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                };

                flpTech.Controls.Add(tag);
            }
        }

        private void SocialLink_Click(object sender, EventArgs e)
        {
            if (sender is Label clickedLabel)
            {
                string socialMedia = clickedLabel.Text.Trim('@');
                string url = "";

                if (clickedLabel == lblFacebookValue)
                    url = $"https://facebook.com/{socialMedia}";
                else if (clickedLabel == lblInstagramValue)
                    url = $"https://instagram.com/{socialMedia}";

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bağlantı açılamadı: {ex.Message}", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Email_Click(object sender, EventArgs e)
        {
            if (lblEmailValue != null && !string.IsNullOrEmpty(lblEmailValue.Text))
            {
                try
                {
                    string email = lblEmailValue.Text;
                    Process.Start(new ProcessStartInfo($"mailto:{email}") { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"E-posta istemcisi açılamadı: {ex.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SocialLink_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.ForeColor = Color.FromArgb(0, 255, 255);
                label.Font = new Font(label.Font, FontStyle.Underline);
                label.Cursor = Cursors.Hand;
            }
        }

        private void SocialLink_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                label.ForeColor = Color.FromArgb(0, 200, 200);
                label.Font = new Font(label.Font, FontStyle.Regular);
                label.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            glowTimer?.Stop();
            glowTimer?.Dispose();
            neonTimer?.Stop();
            neonTimer?.Dispose();
            base.OnFormClosing(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Neon kenarlık efekti
            using (Pen pen = new Pen(Color.FromArgb(0, 255, 200), 2))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }
    }
}