namespace AkilliTarimSistemi.UI
{
    partial class SuAnalizForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpGiris;
        private System.Windows.Forms.Label lblUrun;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblpH;
        private System.Windows.Forms.NumericUpDown nudpH;
        private System.Windows.Forms.Label lblEC;
        private System.Windows.Forms.NumericUpDown nudEC;
        private System.Windows.Forms.Label lblSertlik;
        private System.Windows.Forms.NumericUpDown nudSertlik;
        private System.Windows.Forms.Label lblNitrat;
        private System.Windows.Forms.NumericUpDown nudNitrat;
        private System.Windows.Forms.Label lblNitrit;
        private System.Windows.Forms.NumericUpDown nudNitrit;
        private System.Windows.Forms.Label lblSodyum;
        private System.Windows.Forms.NumericUpDown nudSodyum;
        private System.Windows.Forms.Label lblKlor;
        private System.Windows.Forms.NumericUpDown nudKlor;
        private System.Windows.Forms.Label lblKaynak;
        private System.Windows.Forms.ComboBox cmbKaynak;
        private System.Windows.Forms.Label lblNotlar;
        private System.Windows.Forms.TextBox txtNotlar;
        private System.Windows.Forms.CheckBox chkSulamayaUygun;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.DataGridView dgvSu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpGiris = new GroupBox();
            lblUrun = new Label();
            cmbUrun = new ComboBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblpH = new Label();
            nudpH = new NumericUpDown();
            lblEC = new Label();
            nudEC = new NumericUpDown();
            lblSertlik = new Label();
            nudSertlik = new NumericUpDown();
            lblNitrat = new Label();
            nudNitrat = new NumericUpDown();
            lblNitrit = new Label();
            nudNitrit = new NumericUpDown();
            lblSodyum = new Label();
            nudSodyum = new NumericUpDown();
            lblKlor = new Label();
            nudKlor = new NumericUpDown();
            lblKaynak = new Label();
            cmbKaynak = new ComboBox();
            lblNotlar = new Label();
            txtNotlar = new TextBox();
            chkSulamayaUygun = new CheckBox();
            btnKaydet = new Button();
            btnTemizle = new Button();
            btnSil = new Button();
            btnSuYapayZeka = new Button();
            btnYenile = new Button();
            dgvSu = new DataGridView();
            grpGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudpH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSertlik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSodyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudKlor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSu).BeginInit();
            SuspendLayout();
            // 
            // grpGiris
            // 
            grpGiris.Controls.Add(lblUrun);
            grpGiris.Controls.Add(cmbUrun);
            grpGiris.Controls.Add(lblTarih);
            grpGiris.Controls.Add(dtpTarih);
            grpGiris.Controls.Add(lblpH);
            grpGiris.Controls.Add(nudpH);
            grpGiris.Controls.Add(lblEC);
            grpGiris.Controls.Add(nudEC);
            grpGiris.Controls.Add(lblSertlik);
            grpGiris.Controls.Add(nudSertlik);
            grpGiris.Controls.Add(lblNitrat);
            grpGiris.Controls.Add(nudNitrat);
            grpGiris.Controls.Add(lblNitrit);
            grpGiris.Controls.Add(nudNitrit);
            grpGiris.Controls.Add(lblSodyum);
            grpGiris.Controls.Add(nudSodyum);
            grpGiris.Controls.Add(lblKlor);
            grpGiris.Controls.Add(nudKlor);
            grpGiris.Controls.Add(lblKaynak);
            grpGiris.Controls.Add(cmbKaynak);
            grpGiris.Controls.Add(lblNotlar);
            grpGiris.Controls.Add(txtNotlar);
            grpGiris.Controls.Add(chkSulamayaUygun);
            grpGiris.Controls.Add(btnKaydet);
            grpGiris.Controls.Add(btnTemizle);
            grpGiris.Controls.Add(btnSil);
            grpGiris.Controls.Add(btnSuYapayZeka);
            grpGiris.Controls.Add(btnYenile);
            grpGiris.Dock = DockStyle.Top;
            grpGiris.Location = new Point(0, 0);
            grpGiris.Margin = new Padding(2, 3, 2, 3);
            grpGiris.Name = "grpGiris";
            grpGiris.Padding = new Padding(2, 3, 2, 3);
            grpGiris.Size = new Size(728, 324);
            grpGiris.TabIndex = 0;
            grpGiris.TabStop = false;
            grpGiris.Text = "Su Analizi Girişi";
            // 
            // lblUrun
            // 
            lblUrun.AutoSize = true;
            lblUrun.Location = new Point(15, 21);
            lblUrun.Margin = new Padding(2, 0, 2, 0);
            lblUrun.Name = "lblUrun";
            lblUrun.Size = new Size(43, 20);
            lblUrun.TabIndex = 0;
            lblUrun.Text = "Ürün:";
            // 
            // cmbUrun
            // 
            cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrun.Location = new Point(58, 19);
            cmbUrun.Margin = new Padding(2);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(147, 28);
            cmbUrun.TabIndex = 1;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(208, 29);
            lblTarih.Margin = new Padding(2, 0, 2, 0);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(43, 20);
            lblTarih.TabIndex = 2;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(249, 26);
            dtpTarih.Margin = new Padding(2, 3, 2, 3);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(125, 27);
            dtpTarih.TabIndex = 3;
            // 
            // lblpH
            // 
            lblpH.AutoSize = true;
            lblpH.Location = new Point(17, 66);
            lblpH.Margin = new Padding(2, 0, 2, 0);
            lblpH.Name = "lblpH";
            lblpH.Size = new Size(32, 20);
            lblpH.TabIndex = 4;
            lblpH.Text = "pH:";
            // 
            // nudpH
            // 
            nudpH.DecimalPlaces = 2;
            nudpH.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudpH.Location = new Point(83, 62);
            nudpH.Margin = new Padding(2, 3, 2, 3);
            nudpH.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            nudpH.Name = "nudpH";
            nudpH.Size = new Size(66, 27);
            nudpH.TabIndex = 5;
            nudpH.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // lblEC
            // 
            lblEC.AutoSize = true;
            lblEC.Location = new Point(167, 66);
            lblEC.Margin = new Padding(2, 0, 2, 0);
            lblEC.Name = "lblEC";
            lblEC.Size = new Size(29, 20);
            lblEC.TabIndex = 6;
            lblEC.Text = "EC:";
            // 
            // nudEC
            // 
            nudEC.DecimalPlaces = 2;
            nudEC.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudEC.Location = new Point(199, 65);
            nudEC.Margin = new Padding(2, 3, 2, 3);
            nudEC.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudEC.Name = "nudEC";
            nudEC.Size = new Size(66, 27);
            nudEC.TabIndex = 7;
            // 
            // lblSertlik
            // 
            lblSertlik.AutoSize = true;
            lblSertlik.Location = new Point(274, 66);
            lblSertlik.Margin = new Padding(2, 0, 2, 0);
            lblSertlik.Name = "lblSertlik";
            lblSertlik.Size = new Size(53, 20);
            lblSertlik.TabIndex = 8;
            lblSertlik.Text = "Sertlik:";
            // 
            // nudSertlik
            // 
            nudSertlik.DecimalPlaces = 1;
            nudSertlik.Location = new Point(324, 65);
            nudSertlik.Margin = new Padding(2, 3, 2, 3);
            nudSertlik.Name = "nudSertlik";
            nudSertlik.Size = new Size(66, 27);
            nudSertlik.TabIndex = 9;
            // 
            // lblNitrat
            // 
            lblNitrat.AutoSize = true;
            lblNitrat.Location = new Point(415, 66);
            lblNitrat.Margin = new Padding(2, 0, 2, 0);
            lblNitrat.Name = "lblNitrat";
            lblNitrat.Size = new Size(50, 20);
            lblNitrat.TabIndex = 10;
            lblNitrat.Text = "Nitrat:";
            // 
            // nudNitrat
            // 
            nudNitrat.DecimalPlaces = 1;
            nudNitrat.Location = new Point(468, 66);
            nudNitrat.Margin = new Padding(2, 3, 2, 3);
            nudNitrat.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudNitrat.Name = "nudNitrat";
            nudNitrat.Size = new Size(66, 27);
            nudNitrat.TabIndex = 11;
            // 
            // lblNitrit
            // 
            lblNitrit.AutoSize = true;
            lblNitrit.Location = new Point(548, 66);
            lblNitrit.Margin = new Padding(2, 0, 2, 0);
            lblNitrit.Name = "lblNitrit";
            lblNitrit.Size = new Size(46, 20);
            lblNitrit.TabIndex = 12;
            lblNitrit.Text = "Nitrit:";
            // 
            // nudNitrit
            // 
            nudNitrit.DecimalPlaces = 2;
            nudNitrit.Location = new Point(612, 66);
            nudNitrit.Margin = new Padding(2, 3, 2, 3);
            nudNitrit.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudNitrit.Name = "nudNitrit";
            nudNitrit.Size = new Size(66, 27);
            nudNitrit.TabIndex = 13;
            // 
            // lblSodyum
            // 
            lblSodyum.AutoSize = true;
            lblSodyum.Location = new Point(17, 105);
            lblSodyum.Margin = new Padding(2, 0, 2, 0);
            lblSodyum.Name = "lblSodyum";
            lblSodyum.Size = new Size(66, 20);
            lblSodyum.TabIndex = 14;
            lblSodyum.Text = "Sodyum:";
            // 
            // nudSodyum
            // 
            nudSodyum.DecimalPlaces = 1;
            nudSodyum.Location = new Point(83, 103);
            nudSodyum.Margin = new Padding(2, 3, 2, 3);
            nudSodyum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudSodyum.Name = "nudSodyum";
            nudSodyum.Size = new Size(66, 27);
            nudSodyum.TabIndex = 15;
            // 
            // lblKlor
            // 
            lblKlor.AutoSize = true;
            lblKlor.Location = new Point(167, 105);
            lblKlor.Margin = new Padding(2, 0, 2, 0);
            lblKlor.Name = "lblKlor";
            lblKlor.Size = new Size(39, 20);
            lblKlor.TabIndex = 16;
            lblKlor.Text = "Klor:";
            // 
            // nudKlor
            // 
            nudKlor.DecimalPlaces = 1;
            nudKlor.Location = new Point(199, 103);
            nudKlor.Margin = new Padding(2, 3, 2, 3);
            nudKlor.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudKlor.Name = "nudKlor";
            nudKlor.Size = new Size(66, 27);
            nudKlor.TabIndex = 17;
            // 
            // lblKaynak
            // 
            lblKaynak.AutoSize = true;
            lblKaynak.Location = new Point(295, 105);
            lblKaynak.Margin = new Padding(2, 0, 2, 0);
            lblKaynak.Name = "lblKaynak";
            lblKaynak.Size = new Size(59, 20);
            lblKaynak.TabIndex = 18;
            lblKaynak.Text = "Kaynak:";
            // 
            // cmbKaynak
            // 
            cmbKaynak.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKaynak.Location = new Point(357, 102);
            cmbKaynak.Margin = new Padding(2, 3, 2, 3);
            cmbKaynak.Name = "cmbKaynak";
            cmbKaynak.Size = new Size(101, 28);
            cmbKaynak.TabIndex = 19;
            // 
            // lblNotlar
            // 
            lblNotlar.AutoSize = true;
            lblNotlar.Location = new Point(17, 143);
            lblNotlar.Margin = new Padding(2, 0, 2, 0);
            lblNotlar.Name = "lblNotlar";
            lblNotlar.Size = new Size(54, 20);
            lblNotlar.TabIndex = 20;
            lblNotlar.Text = "Notlar:";
            // 
            // txtNotlar
            // 
            txtNotlar.Location = new Point(66, 140);
            txtNotlar.Margin = new Padding(2, 3, 2, 3);
            txtNotlar.Multiline = true;
            txtNotlar.Name = "txtNotlar";
            txtNotlar.Size = new Size(392, 58);
            txtNotlar.TabIndex = 21;
            // 
            // chkSulamayaUygun
            // 
            chkSulamayaUygun.AutoSize = true;
            chkSulamayaUygun.Location = new Point(66, 209);
            chkSulamayaUygun.Margin = new Padding(2, 3, 2, 3);
            chkSulamayaUygun.Name = "chkSulamayaUygun";
            chkSulamayaUygun.Size = new Size(141, 24);
            chkSulamayaUygun.TabIndex = 22;
            chkSulamayaUygun.Text = "Sulamaya Uygun";
            chkSulamayaUygun.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(66, 257);
            btnKaydet.Margin = new Padding(2, 3, 2, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(83, 38);
            btnKaydet.TabIndex = 23;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(175, 257);
            btnTemizle.Margin = new Padding(2, 3, 2, 3);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(83, 38);
            btnTemizle.TabIndex = 24;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(283, 257);
            btnSil.Margin = new Padding(2, 3, 2, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(83, 38);
            btnSil.TabIndex = 25;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnSuYapayZeka
            // 
            btnSuYapayZeka.Location = new Point(532, 257);
            btnSuYapayZeka.Margin = new Padding(2, 3, 2, 3);
            btnSuYapayZeka.Name = "btnSuYapayZeka";
            btnSuYapayZeka.Size = new Size(83, 38);
            btnSuYapayZeka.TabIndex = 26;
            btnSuYapayZeka.Text = "Öneri";
            btnSuYapayZeka.UseVisualStyleBackColor = true;
            btnSuYapayZeka.Click += btnSuYapayZeka_Click;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(415, 257);
            btnYenile.Margin = new Padding(2, 3, 2, 3);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(83, 38);
            btnYenile.TabIndex = 26;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // dgvSu
            // 
            dgvSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSu.Dock = DockStyle.Fill;
            dgvSu.Location = new Point(0, 324);
            dgvSu.Margin = new Padding(2, 3, 2, 3);
            dgvSu.Name = "dgvSu";
            dgvSu.RowHeadersWidth = 51;
            dgvSu.Size = new Size(728, 247);
            dgvSu.TabIndex = 1;
            dgvSu.CellClick += dgvSu_CellClick;
            // 
            // SuAnalizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 571);
            Controls.Add(dgvSu);
            Controls.Add(grpGiris);
            Margin = new Padding(2, 3, 2, 3);
            Name = "SuAnalizForm";
            Text = "Su Analizleri";
            grpGiris.ResumeLayout(false);
            grpGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudpH).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEC).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSertlik).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrat).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSodyum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudKlor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSu).EndInit();
            ResumeLayout(false);
        }

        private Button btnSuYapayZeka;
    }
}