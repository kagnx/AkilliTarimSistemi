using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace AkilliTarimSistemi.UI
{
    public partial class BaseForm : Form
    {
        // Özel neon renkler
        protected Color NeonGreen = Color.FromArgb(0, 255, 100);
        protected Color NeonBlue = Color.FromArgb(0, 200, 255);
        protected Color DarkBg = Color.FromArgb(15, 20, 30);
        protected Color DarkPanel = Color.FromArgb(25, 30, 45);
        protected Color DarkBorder = Color.FromArgb(45, 50, 70);

        private PictureBox picLogo;
        private Label lblTitle;
        private Panel pnlHeader;

        // Tasarımcıdaki nesnelerin arkada kalmasını önlemek için pnlContent'i sanallaştırdık
        protected Panel pnlContent;


        // Formun bir panel içine mi gömüleceğini tutan değişken
        private bool _isEmbedded = false;

        public BaseForm()
        {
            // Eğer form AnaForm içerisindeki sağ panele gömülecekse (MDI/Container mantığı)
            // Devasa üst başlık barını oluşturup nesneleri gizlemesini engelliyoruz.
            _isEmbedded = true;

            SetupFormProperties();
            ApplyNeonTheme();

            // Form ilk yüklendiğinde içerideki tüm buton ve gridleri otomatik neon temaya uyarla
            this.Load += BaseForm_Load;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            // Formun içindeki tüm kontrolleri gez ve otomatik olarak neon stillerini giydir
            ApplyThemeToControls(this.Controls);
        }

        private void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is Button btn) StyleButton(btn);
                else if (ctrl is TextBox txt) StyleTextBox(txt);
                else if (ctrl is ComboBox cmb) StyleComboBox(cmb);
                else if (ctrl is NumericUpDown nud) StyleNumericUpDown(nud);
                else if (ctrl is DataGridView dgv) StyleDataGridView(dgv);

                if (ctrl.HasChildren)
                {
                    ApplyThemeToControls(ctrl.Controls);
                }
            }
        }

        private void SetupFormProperties()
        {
            this.BackColor = DarkBg;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void ApplyNeonTheme()
        {
            try
            {
                string bgPath = Application.StartupPath + "\\arka.jpg";
                if (System.IO.File.Exists(bgPath))
                {
                    this.BackgroundImage = Image.FromFile(bgPath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch { }
        }

        // ============ HARİKA NEON STİL YARDIMCILARI ============

        protected void StyleButton(Button btn, Color? btnColor = null)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = btnColor ?? NeonGreen;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, btnColor ?? NeonGreen);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, btnColor ?? NeonGreen);
            btn.BackColor = DarkPanel;
            btn.ForeColor = btnColor ?? NeonGreen;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        protected void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = DarkPanel;
            txt.ForeColor = Color.White;
            txt.Font = new Font("Segoe UI", 11);
        }

        protected void StyleComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = DarkPanel;
            cmb.ForeColor = Color.White;
            cmb.Font = new Font("Segoe UI", 11);
        }

        protected void StyleNumericUpDown(NumericUpDown nud)
        {
            nud.BackColor = DarkPanel;
            nud.ForeColor = Color.White;
            nud.Font = new Font("Segoe UI", 11);
        }

        protected void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = DarkPanel;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = DarkBorder;
            dgv.ForeColor = Color.White;
            dgv.Font = new Font("Segoe UI", 10);
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = NeonGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = DarkBg;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.BackColor = DarkPanel;
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, NeonGreen);
            dgv.DefaultCellStyle.SelectionForeColor = NeonGreen;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(30, 35, 50);
        }
    }
}