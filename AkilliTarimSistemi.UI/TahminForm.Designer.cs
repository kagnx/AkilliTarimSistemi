using System.Drawing;
using System.Windows.Forms;

namespace AkilliTarimSistemi.UI
{
    // C# Tasarımcısının (Designer) formu görebilmesi için geçici olarak Form'dan türetiyoruz.
    // Proje derlendiğinde kod tarafındaki BaseForm ezmesi devreye girecek.
    partial class TahminForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form bileşenleriniz (Hepsini buraya eksiksiz geri yazıyoruz)
        private GroupBox grpTavsiye;
        private GroupBox grpGubre;
        private GroupBox grpVerim;
        private Label lblAnaliz;
        private ComboBox cmbAnalizList;
        private Label lblUrunTavsiye;
        private ComboBox cmbUrunTavsiye;
        private Button btnTavsiyeAl;
        private Label lblTavsiyeSonuc;
        private Label lblUrunGubre;
        private ComboBox cmbUrunGubre;
        private Button btnGubreOner;
        private Label lblGubreSonuc;
        private Label lblTarlaVerim;
        private ComboBox cmbTarlaVerim;
        private Label lblUrunVerim;
        private ComboBox cmbUrunVerim;
        private Button btnVerimTahmin;
        private Label lblVerimSonuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpTavsiye = new GroupBox();
            lblUrunTavsiye = new Label();
            cmbUrunTavsiye = new ComboBox();
            btnTavsiyeAl = new Button();
            lblTavsiyeSonuc = new Label();
            grpGubre = new GroupBox();
            lblUrunGubre = new Label();
            cmbUrunGubre = new ComboBox();
            btnGubreOner = new Button();
            lblGubreSonuc = new Label();
            grpVerim = new GroupBox();
            lblTarlaVerim = new Label();
            cmbTarlaVerim = new ComboBox();
            lblUrunVerim = new Label();
            cmbUrunVerim = new ComboBox();
            btnVerimTahmin = new Button();
            lblVerimSonuc = new Label();
            lblAnaliz = new Label();
            cmbAnalizList = new ComboBox();
            grpTavsiye.SuspendLayout();
            grpGubre.SuspendLayout();
            grpVerim.SuspendLayout();
            SuspendLayout();
            // 
            // grpTavsiye
            // 
            grpTavsiye.Controls.Add(lblUrunTavsiye);
            grpTavsiye.Controls.Add(cmbUrunTavsiye);
            grpTavsiye.Controls.Add(btnTavsiyeAl);
            grpTavsiye.Controls.Add(lblTavsiyeSonuc);
            grpTavsiye.Location = new Point(19, 64);
            grpTavsiye.Margin = new Padding(2);
            grpTavsiye.Name = "grpTavsiye";
            grpTavsiye.Padding = new Padding(2);
            grpTavsiye.Size = new Size(327, 113);
            grpTavsiye.TabIndex = 2;
            grpTavsiye.TabStop = false;
            grpTavsiye.Text = "Ürün Tavsiyesi";
            // 
            // lblUrunTavsiye
            // 
            lblUrunTavsiye.AutoSize = true;
            lblUrunTavsiye.Location = new Point(-2, 29);
            lblUrunTavsiye.Margin = new Padding(2, 0, 2, 0);
            lblUrunTavsiye.Name = "lblUrunTavsiye";
            lblUrunTavsiye.Size = new Size(70, 20);
            lblUrunTavsiye.TabIndex = 0;
            lblUrunTavsiye.Text = "Ürün Seç:";
            // 
            // cmbUrunTavsiye
            // 
            cmbUrunTavsiye.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrunTavsiye.FormattingEnabled = true;
            cmbUrunTavsiye.Location = new Point(71, 29);
            cmbUrunTavsiye.Margin = new Padding(2);
            cmbUrunTavsiye.Name = "cmbUrunTavsiye";
            cmbUrunTavsiye.Size = new Size(132, 28);
            cmbUrunTavsiye.TabIndex = 1;
            // 
            // btnTavsiyeAl
            // 
            btnTavsiyeAl.Location = new Point(232, 30);
            btnTavsiyeAl.Margin = new Padding(2);
            btnTavsiyeAl.Name = "btnTavsiyeAl";
            btnTavsiyeAl.Size = new Size(87, 27);
            btnTavsiyeAl.TabIndex = 2;
            btnTavsiyeAl.Text = "Tavsiye Al";
            btnTavsiyeAl.UseVisualStyleBackColor = true;
            //btnTavsiyeAl.Click += btnTavsiyeAl_Click;
            // 
            // lblTavsiyeSonuc
            // 
            lblTavsiyeSonuc.AutoSize = true;
            lblTavsiyeSonuc.Location = new Point(4, 64);
            lblTavsiyeSonuc.Margin = new Padding(2, 0, 2, 0);
            lblTavsiyeSonuc.Name = "lblTavsiyeSonuc";
            lblTavsiyeSonuc.Size = new Size(86, 20);
            lblTavsiyeSonuc.TabIndex = 3;
            lblTavsiyeSonuc.Text = "Sonuç: -----";
            // 
            // grpGubre
            // 
            grpGubre.Controls.Add(lblUrunGubre);
            grpGubre.Controls.Add(cmbUrunGubre);
            grpGubre.Controls.Add(btnGubreOner);
            grpGubre.Controls.Add(lblGubreSonuc);
            grpGubre.Location = new Point(15, 181);
            grpGubre.Margin = new Padding(2);
            grpGubre.Name = "grpGubre";
            grpGubre.Padding = new Padding(2);
            grpGubre.Size = new Size(327, 96);
            grpGubre.TabIndex = 3;
            grpGubre.TabStop = false;
            grpGubre.Text = "Gübre Önerisi";
            // 
            // lblUrunGubre
            // 
            lblUrunGubre.AutoSize = true;
            lblUrunGubre.Location = new Point(4, 29);
            lblUrunGubre.Margin = new Padding(2, 0, 2, 0);
            lblUrunGubre.Name = "lblUrunGubre";
            lblUrunGubre.Size = new Size(70, 20);
            lblUrunGubre.TabIndex = 0;
            lblUrunGubre.Text = "Ürün Seç:";
            // 
            // cmbUrunGubre
            // 
            cmbUrunGubre.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrunGubre.FormattingEnabled = true;
            cmbUrunGubre.Location = new Point(70, 23);
            cmbUrunGubre.Margin = new Padding(2);
            cmbUrunGubre.Name = "cmbUrunGubre";
            cmbUrunGubre.Size = new Size(132, 28);
            cmbUrunGubre.TabIndex = 1;
            // 
            // btnGubreOner
            // 
            btnGubreOner.Location = new Point(236, 29);
            btnGubreOner.Margin = new Padding(2);
            btnGubreOner.Name = "btnGubreOner";
            btnGubreOner.Size = new Size(87, 29);
            btnGubreOner.TabIndex = 2;
            btnGubreOner.Text = "Öneri Al";
            btnGubreOner.UseVisualStyleBackColor = true;
            //btnGubreOner.Click += btnGubreOner_Click;

            // 
            // lblGubreSonuc
            // 
            lblGubreSonuc.AutoSize = true;
            lblGubreSonuc.Location = new Point(9, 58);
            lblGubreSonuc.Margin = new Padding(2, 0, 2, 0);
            lblGubreSonuc.Name = "lblGubreSonuc";
            lblGubreSonuc.Size = new Size(86, 20);
            lblGubreSonuc.TabIndex = 3;
            lblGubreSonuc.Text = "Sonuç: -----";
            // 
            // grpVerim
            // 
            grpVerim.Controls.Add(lblTarlaVerim);
            grpVerim.Controls.Add(cmbTarlaVerim);
            grpVerim.Controls.Add(lblUrunVerim);
            grpVerim.Controls.Add(cmbUrunVerim);
            grpVerim.Controls.Add(btnVerimTahmin);
            grpVerim.Controls.Add(lblVerimSonuc);
            grpVerim.Location = new Point(15, 281);
            grpVerim.Margin = new Padding(2);
            grpVerim.Name = "grpVerim";
            grpVerim.Padding = new Padding(2);
            grpVerim.Size = new Size(327, 156);
            grpVerim.TabIndex = 4;
            grpVerim.TabStop = false;
            grpVerim.Text = "Verim Tahmini";
            // 
            // lblTarlaVerim
            // 
            lblTarlaVerim.AutoSize = true;
            lblTarlaVerim.Location = new Point(4, 25);
            lblTarlaVerim.Margin = new Padding(2, 0, 2, 0);
            lblTarlaVerim.Name = "lblTarlaVerim";
            lblTarlaVerim.Size = new Size(70, 20);
            lblTarlaVerim.TabIndex = 0;
            lblTarlaVerim.Text = "Tarla Seç:";
            // 
            // cmbTarlaVerim
            // 
            cmbTarlaVerim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarlaVerim.FormattingEnabled = true;
            cmbTarlaVerim.Location = new Point(87, 25);
            cmbTarlaVerim.Margin = new Padding(2);
            cmbTarlaVerim.Name = "cmbTarlaVerim";
            cmbTarlaVerim.Size = new Size(132, 28);
            cmbTarlaVerim.TabIndex = 1;
            // 
            // lblUrunVerim
            // 
            lblUrunVerim.AutoSize = true;
            lblUrunVerim.Location = new Point(4, 59);
            lblUrunVerim.Margin = new Padding(2, 0, 2, 0);
            lblUrunVerim.Name = "lblUrunVerim";
            lblUrunVerim.Size = new Size(70, 20);
            lblUrunVerim.TabIndex = 2;
            lblUrunVerim.Text = "Ürün Seç:";
            // 
            // cmbUrunVerim
            // 
            cmbUrunVerim.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrunVerim.FormattingEnabled = true;
            cmbUrunVerim.Location = new Point(87, 55);
            cmbUrunVerim.Margin = new Padding(2);
            cmbUrunVerim.Name = "cmbUrunVerim";
            cmbUrunVerim.Size = new Size(132, 28);
            cmbUrunVerim.TabIndex = 3;
            // 
            // btnVerimTahmin
            // 
            btnVerimTahmin.Location = new Point(236, 35);
            btnVerimTahmin.Margin = new Padding(2);
            btnVerimTahmin.Name = "btnVerimTahmin";
            btnVerimTahmin.Size = new Size(87, 33);
            btnVerimTahmin.TabIndex = 4;
            btnVerimTahmin.Text = "Tahmin Et";
            btnVerimTahmin.UseVisualStyleBackColor = true;
            btnVerimTahmin.Click += btnVerimTahmin_Click;
            // 
            // lblVerimSonuc
            // 
            lblVerimSonuc.AutoSize = true;
            lblVerimSonuc.Location = new Point(4, 100);
            lblVerimSonuc.Margin = new Padding(2, 0, 2, 0);
            lblVerimSonuc.Name = "lblVerimSonuc";
            lblVerimSonuc.Size = new Size(86, 20);
            lblVerimSonuc.TabIndex = 5;
            lblVerimSonuc.Text = "Sonuç: -----";
            // 
            // lblAnaliz
            // 
            lblAnaliz.AutoSize = true;
            lblAnaliz.BackColor = SystemColors.Control;
            lblAnaliz.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            lblAnaliz.ForeColor = SystemColors.Desktop;
            lblAnaliz.Location = new Point(24, 27);
            lblAnaliz.Margin = new Padding(2, 0, 2, 0);
            lblAnaliz.Name = "lblAnaliz";
            lblAnaliz.Size = new Size(178, 23);
            lblAnaliz.TabIndex = 0;
            lblAnaliz.Text = "Toprak Analizi Seçin:";
            // 
            // cmbAnalizList
            // 
            cmbAnalizList.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnalizList.FormattingEnabled = true;
            cmbAnalizList.Location = new Point(206, 22);
            cmbAnalizList.Margin = new Padding(2);
            cmbAnalizList.Name = "cmbAnalizList";
            cmbAnalizList.Size = new Size(183, 28);
            cmbAnalizList.TabIndex = 1;
           // cmbAnalizList.SelectedIndexChanged += cmbAnalizList_SelectedIndexChanged;
            // 
            // TahminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 457);
            Controls.Add(cmbAnalizList);
            Controls.Add(lblAnaliz);
            Controls.Add(grpVerim);
            Controls.Add(grpGubre);
            Controls.Add(grpTavsiye);
            Margin = new Padding(2);
            Name = "TahminForm";
            Text = "Yapay Zeka Tahmin ve Öneriler";
            grpTavsiye.ResumeLayout(false);
            grpTavsiye.PerformLayout();
            grpGubre.ResumeLayout(false);
            grpGubre.PerformLayout();
            grpVerim.ResumeLayout(false);
            grpVerim.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}