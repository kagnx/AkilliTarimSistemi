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
        private System.Windows.Forms.DataGridView dgvAnalizler;

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
            btnYenile = new Button();
            dgvAnalizler = new DataGridView();
            grpGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudpH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSertlik).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNitrit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSodyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudKlor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnalizler).BeginInit();
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
            grpGiris.Controls.Add(btnYenile);
            grpGiris.Dock = DockStyle.Top;
            grpGiris.Location = new Point(0, 0);
            grpGiris.Margin = new Padding(3, 4, 3, 4);
            grpGiris.Name = "grpGiris";
            grpGiris.Padding = new Padding(3, 4, 3, 4);
            grpGiris.Size = new Size(1001, 453);
            grpGiris.TabIndex = 0;
            grpGiris.TabStop = false;
            grpGiris.Text = "Su Analizi Girişi";
            // 
            // lblUrun
            // 
            lblUrun.AutoSize = true;
            lblUrun.Location = new Point(20, 30);
            lblUrun.Name = "lblUrun";
            lblUrun.Size = new Size(59, 28);
            lblUrun.TabIndex = 0;
            lblUrun.Text = "Ürün:";
            // 
            // cmbUrun
            // 
            cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrun.Location = new Point(80, 27);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(200, 36);
            cmbUrun.TabIndex = 1;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(286, 40);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(57, 28);
            lblTarih.TabIndex = 2;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(343, 36);
            dtpTarih.Margin = new Padding(3, 4, 3, 4);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(171, 34);
            dtpTarih.TabIndex = 3;
            // 
            // lblpH
            // 
            lblpH.AutoSize = true;
            lblpH.Location = new Point(23, 93);
            lblpH.Name = "lblpH";
            lblpH.Size = new Size(42, 28);
            lblpH.TabIndex = 4;
            lblpH.Text = "pH:";
            // 
            // nudpH
            // 
            nudpH.DecimalPlaces = 2;
            nudpH.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudpH.Location = new Point(114, 87);
            nudpH.Margin = new Padding(3, 4, 3, 4);
            nudpH.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            nudpH.Name = "nudpH";
            nudpH.Size = new Size(91, 34);
            nudpH.TabIndex = 5;
            nudpH.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // lblEC
            // 
            lblEC.AutoSize = true;
            lblEC.Location = new Point(229, 93);
            lblEC.Name = "lblEC";
            lblEC.Size = new Size(38, 28);
            lblEC.TabIndex = 6;
            lblEC.Text = "EC:";
            // 
            // nudEC
            // 
            nudEC.DecimalPlaces = 2;
            nudEC.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudEC.Location = new Point(274, 91);
            nudEC.Margin = new Padding(3, 4, 3, 4);
            nudEC.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudEC.Name = "nudEC";
            nudEC.Size = new Size(91, 34);
            nudEC.TabIndex = 7;
            // 
            // lblSertlik
            // 
            lblSertlik.AutoSize = true;
            lblSertlik.Location = new Point(377, 93);
            lblSertlik.Name = "lblSertlik";
            lblSertlik.Size = new Size(71, 28);
            lblSertlik.TabIndex = 8;
            lblSertlik.Text = "Sertlik:";
            // 
            // nudSertlik
            // 
            nudSertlik.DecimalPlaces = 1;
            nudSertlik.Location = new Point(446, 91);
            nudSertlik.Margin = new Padding(3, 4, 3, 4);
            nudSertlik.Name = "nudSertlik";
            nudSertlik.Size = new Size(91, 34);
            nudSertlik.TabIndex = 9;
            // 
            // lblNitrat
            // 
            lblNitrat.AutoSize = true;
            lblNitrat.Location = new Point(571, 93);
            lblNitrat.Name = "lblNitrat";
            lblNitrat.Size = new Size(67, 28);
            lblNitrat.TabIndex = 10;
            lblNitrat.Text = "Nitrat:";
            // 
            // nudNitrat
            // 
            nudNitrat.DecimalPlaces = 1;
            nudNitrat.Location = new Point(644, 93);
            nudNitrat.Margin = new Padding(3, 4, 3, 4);
            nudNitrat.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudNitrat.Name = "nudNitrat";
            nudNitrat.Size = new Size(91, 34);
            nudNitrat.TabIndex = 11;
            // 
            // lblNitrit
            // 
            lblNitrit.AutoSize = true;
            lblNitrit.Location = new Point(754, 93);
            lblNitrit.Name = "lblNitrit";
            lblNitrit.Size = new Size(62, 28);
            lblNitrit.TabIndex = 12;
            lblNitrit.Text = "Nitrit:";
            // 
            // nudNitrit
            // 
            nudNitrit.DecimalPlaces = 2;
            nudNitrit.Location = new Point(841, 93);
            nudNitrit.Margin = new Padding(3, 4, 3, 4);
            nudNitrit.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudNitrit.Name = "nudNitrit";
            nudNitrit.Size = new Size(91, 34);
            nudNitrit.TabIndex = 13;
            // 
            // lblSodyum
            // 
            lblSodyum.AutoSize = true;
            lblSodyum.Location = new Point(23, 147);
            lblSodyum.Name = "lblSodyum";
            lblSodyum.Size = new Size(89, 28);
            lblSodyum.TabIndex = 14;
            lblSodyum.Text = "Sodyum:";
            // 
            // nudSodyum
            // 
            nudSodyum.DecimalPlaces = 1;
            nudSodyum.Location = new Point(114, 144);
            nudSodyum.Margin = new Padding(3, 4, 3, 4);
            nudSodyum.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudSodyum.Name = "nudSodyum";
            nudSodyum.Size = new Size(91, 34);
            nudSodyum.TabIndex = 15;
            // 
            // lblKlor
            // 
            lblKlor.AutoSize = true;
            lblKlor.Location = new Point(229, 147);
            lblKlor.Name = "lblKlor";
            lblKlor.Size = new Size(52, 28);
            lblKlor.TabIndex = 16;
            lblKlor.Text = "Klor:";
            // 
            // nudKlor
            // 
            nudKlor.DecimalPlaces = 1;
            nudKlor.Location = new Point(274, 144);
            nudKlor.Margin = new Padding(3, 4, 3, 4);
            nudKlor.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudKlor.Name = "nudKlor";
            nudKlor.Size = new Size(91, 34);
            nudKlor.TabIndex = 17;
            // 
            // lblKaynak
            // 
            lblKaynak.AutoSize = true;
            lblKaynak.Location = new Point(406, 147);
            lblKaynak.Name = "lblKaynak";
            lblKaynak.Size = new Size(79, 28);
            lblKaynak.TabIndex = 18;
            lblKaynak.Text = "Kaynak:";
            // 
            // cmbKaynak
            // 
            cmbKaynak.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKaynak.Location = new Point(491, 143);
            cmbKaynak.Margin = new Padding(3, 4, 3, 4);
            cmbKaynak.Name = "cmbKaynak";
            cmbKaynak.Size = new Size(137, 36);
            cmbKaynak.TabIndex = 19;
            // 
            // lblNotlar
            // 
            lblNotlar.AutoSize = true;
            lblNotlar.Location = new Point(23, 200);
            lblNotlar.Name = "lblNotlar";
            lblNotlar.Size = new Size(72, 28);
            lblNotlar.TabIndex = 20;
            lblNotlar.Text = "Notlar:";
            // 
            // txtNotlar
            // 
            txtNotlar.Location = new Point(91, 196);
            txtNotlar.Margin = new Padding(3, 4, 3, 4);
            txtNotlar.Multiline = true;
            txtNotlar.Name = "txtNotlar";
            txtNotlar.Size = new Size(537, 79);
            txtNotlar.TabIndex = 21;
            // 
            // chkSulamayaUygun
            // 
            chkSulamayaUygun.AutoSize = true;
            chkSulamayaUygun.Location = new Point(91, 293);
            chkSulamayaUygun.Margin = new Padding(3, 4, 3, 4);
            chkSulamayaUygun.Name = "chkSulamayaUygun";
            chkSulamayaUygun.Size = new Size(181, 32);
            chkSulamayaUygun.TabIndex = 22;
            chkSulamayaUygun.Text = "Sulamaya Uygun";
            chkSulamayaUygun.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(91, 360);
            btnKaydet.Margin = new Padding(3, 4, 3, 4);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(114, 53);
            btnKaydet.TabIndex = 23;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(240, 360);
            btnTemizle.Margin = new Padding(3, 4, 3, 4);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(114, 53);
            btnTemizle.TabIndex = 24;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(389, 360);
            btnSil.Margin = new Padding(3, 4, 3, 4);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(114, 53);
            btnSil.TabIndex = 25;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(537, 360);
            btnYenile.Margin = new Padding(3, 4, 3, 4);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(114, 53);
            btnYenile.TabIndex = 26;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // dgvAnalizler
            // 
            dgvAnalizler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalizler.Dock = DockStyle.Fill;
            dgvAnalizler.Location = new Point(0, 453);
            dgvAnalizler.Margin = new Padding(3, 4, 3, 4);
            dgvAnalizler.Name = "dgvAnalizler";
            dgvAnalizler.RowHeadersWidth = 51;
            dgvAnalizler.Size = new Size(1001, 347);
            dgvAnalizler.TabIndex = 1;
            // 
            // SuAnalizForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 800);
            Controls.Add(dgvAnalizler);
            Controls.Add(grpGiris);
            Margin = new Padding(3, 4, 3, 4);
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
            ((System.ComponentModel.ISupportInitialize)dgvAnalizler).EndInit();
            ResumeLayout(false);
        }
    }
}