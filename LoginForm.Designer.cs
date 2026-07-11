namespace AkilliTarimSistemi.UI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBaslik = new Label();
            this.lblKullaniciAdi = new Label();
            this.txtKullaniciAdi = new TextBox();
            this.lblSifre = new Label();
            this.txtSifre = new TextBox();
            this.btnGiris = new Button();
            this.lblBilgi = new Label();
            this.SuspendLayout();
            //
            // lblBaslik
            //
            this.lblBaslik.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblBaslik.ForeColor = Color.FromArgb(0, 255, 200);
            this.lblBaslik.Location = new Point(50, 20);
            this.lblBaslik.Size = new Size(300, 40);
            this.lblBaslik.Text = "AKILLI TARIM SISTEMI";
            this.lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblKullaniciAdi
            //
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new Point(50, 80);
            this.lblKullaniciAdi.Text = "Kullanici Adi:";
            //
            // txtKullaniciAdi
            //
            this.txtKullaniciAdi.BackColor = Color.FromArgb(24, 30, 41);
            this.txtKullaniciAdi.ForeColor = Color.White;
            this.txtKullaniciAdi.Location = new Point(50, 100);
            this.txtKullaniciAdi.Size = new Size(300, 27);
            this.txtKullaniciAdi.KeyDown += new KeyEventHandler(this.txtKullaniciAdi_KeyDown);
            //
            // lblSifre
            //
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new Point(50, 140);
            this.lblSifre.Text = "Sifre:";
            //
            // txtSifre
            //
            this.txtSifre.BackColor = Color.FromArgb(24, 30, 41);
            this.txtSifre.ForeColor = Color.White;
            this.txtSifre.Location = new Point(50, 160);
            this.txtSifre.Size = new Size(300, 27);
            this.txtSifre.UseSystemPasswordChar = true;
            this.txtSifre.KeyDown += new KeyEventHandler(this.txtSifre_KeyDown);
            //
            // btnGiris
            //
            this.btnGiris.BackColor = Color.FromArgb(0, 100, 0);
            this.btnGiris.FlatStyle = FlatStyle.Flat;
            this.btnGiris.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 200);
            this.btnGiris.FlatAppearance.BorderSize = 1;
            this.btnGiris.ForeColor = Color.FromArgb(0, 255, 200);
            this.btnGiris.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.btnGiris.Location = new Point(50, 210);
            this.btnGiris.Size = new Size(300, 45);
            this.btnGiris.Text = "GIRIS YAP";
            this.btnGiris.UseVisualStyleBackColor = false;
            this.btnGiris.Click += new EventHandler(this.btnGiris_Click);
            //
            // lblBilgi
            //
            this.lblBilgi.Font = new Font("Segoe UI", 8F);
            this.lblBilgi.ForeColor = Color.Gray;
            this.lblBilgi.Location = new Point(50, 270);
            this.lblBilgi.Size = new Size(300, 30);
            this.lblBilgi.Text = "Varsayilan: admin / admin";
            this.lblBilgi.TextAlign = ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblBaslik);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.lblBilgi);
            this.Name = "LoginForm";
            this.Text = "Giris";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblBaslik;
        private Label lblKullaniciAdi;
        private TextBox txtKullaniciAdi;
        private Label lblSifre;
        private TextBox txtSifre;
        private Button btnGiris;
        private Label lblBilgi;
    }
}
