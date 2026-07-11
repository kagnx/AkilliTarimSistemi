namespace AkilliTarimSistemi.UI
{
    partial class YaprakAnalizForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpGiris;
        private System.Windows.Forms.Label lblUurun;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblAzot;
        private System.Windows.Forms.NumericUpDown nudAzot;
        private System.Windows.Forms.Label lblFosfor;
        private System.Windows.Forms.NumericUpDown nudFosfor;
        private System.Windows.Forms.Label lblPotasyum;
        private System.Windows.Forms.NumericUpDown nudPotasyum;
        private System.Windows.Forms.Label lblDemir;
        private System.Windows.Forms.NumericUpDown nudDemir;
        private System.Windows.Forms.Label lblCinko;
        private System.Windows.Forms.NumericUpDown nudCinko;
        private System.Windows.Forms.Label lblMangan;
        private System.Windows.Forms.NumericUpDown nudMangan;
        private System.Windows.Forms.Label lblBakir;
        private System.Windows.Forms.NumericUpDown nudBakir;
        private System.Windows.Forms.Label lblEksiklik;
        private System.Windows.Forms.ComboBox cmbEksiklik;
        private System.Windows.Forms.Label lblNot;
        private System.Windows.Forms.TextBox txtNot;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.DataGridView dgvYaprak;
        private System.Windows.Forms.Label lblUrun;
        //private System.Windows.Forms.ComboBox cmbUrun;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpGiris = new GroupBox();
            cmbUrun = new ComboBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblAzot = new Label();
            nudAzot = new NumericUpDown();
            lblFosfor = new Label();
            nudFosfor = new NumericUpDown();
            lblPotasyum = new Label();
            nudPotasyum = new NumericUpDown();
            lblDemir = new Label();
            nudDemir = new NumericUpDown();
            lblCinko = new Label();
            nudCinko = new NumericUpDown();
            lblMangan = new Label();
            nudMangan = new NumericUpDown();
            lblBakir = new Label();
            nudBakir = new NumericUpDown();
            lblEksiklik = new Label();
            cmbEksiklik = new ComboBox();
            lblNot = new Label();
            txtNot = new TextBox();
            btnKaydet = new Button();
            btnTemizle = new Button();
            btnSil = new Button();
            btnYapayZekaTephis = new Button();
            btnYenile = new Button();
            lblUrun = new Label();
            lblUurun = new Label();
            dgvYaprak = new DataGridView();
            grpGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAzot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFosfor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPotasyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDemir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCinko).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMangan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudBakir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvYaprak).BeginInit();
            SuspendLayout();
            // 
            // grpGiris
            // 
            grpGiris.Controls.Add(cmbUrun);
            grpGiris.Controls.Add(lblTarih);
            grpGiris.Controls.Add(dtpTarih);
            grpGiris.Controls.Add(lblAzot);
            grpGiris.Controls.Add(nudAzot);
            grpGiris.Controls.Add(lblFosfor);
            grpGiris.Controls.Add(nudFosfor);
            grpGiris.Controls.Add(lblPotasyum);
            grpGiris.Controls.Add(nudPotasyum);
            grpGiris.Controls.Add(lblDemir);
            grpGiris.Controls.Add(nudDemir);
            grpGiris.Controls.Add(lblCinko);
            grpGiris.Controls.Add(nudCinko);
            grpGiris.Controls.Add(lblMangan);
            grpGiris.Controls.Add(nudMangan);
            grpGiris.Controls.Add(lblBakir);
            grpGiris.Controls.Add(nudBakir);
            grpGiris.Controls.Add(lblEksiklik);
            grpGiris.Controls.Add(cmbEksiklik);
            grpGiris.Controls.Add(lblNot);
            grpGiris.Controls.Add(txtNot);
            grpGiris.Controls.Add(btnKaydet);
            grpGiris.Controls.Add(btnTemizle);
            grpGiris.Controls.Add(btnSil);
            grpGiris.Controls.Add(btnYapayZekaTephis);
            grpGiris.Controls.Add(btnYenile);
            grpGiris.Controls.Add(lblUrun);
            grpGiris.Dock = DockStyle.Top;
            grpGiris.Location = new Point(0, 0);
            grpGiris.Margin = new Padding(2, 3, 2, 3);
            grpGiris.Name = "grpGiris";
            grpGiris.Padding = new Padding(2, 3, 2, 3);
            grpGiris.Size = new Size(665, 364);
            grpGiris.TabIndex = 0;
            grpGiris.TabStop = false;
            grpGiris.Text = "Yaprak Analizi Girişi";
            // 
            // cmbUrun
            // 
            cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrun.Location = new Point(159, 48);
            cmbUrun.Margin = new Padding(2);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(147, 28);
            cmbUrun.TabIndex = 1;
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.BackColor = SystemColors.ControlDark;
            lblTarih.Location = new Point(424, 49);
            lblTarih.Margin = new Padding(2, 0, 2, 0);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(43, 20);
            lblTarih.TabIndex = 4;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(466, 46);
            dtpTarih.Margin = new Padding(2, 3, 2, 3);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(125, 27);
            dtpTarih.TabIndex = 5;
            // 
            // lblAzot
            // 
            lblAzot.AutoSize = true;
            lblAzot.BackColor = SystemColors.ControlDarkDark;
            lblAzot.Location = new Point(17, 86);
            lblAzot.Margin = new Padding(2, 0, 2, 0);
            lblAzot.Name = "lblAzot";
            lblAzot.Size = new Size(69, 20);
            lblAzot.TabIndex = 6;
            lblAzot.Text = "Azot (%):";
            // 
            // nudAzot
            // 
            nudAzot.DecimalPlaces = 2;
            nudAzot.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudAzot.Location = new Point(92, 82);
            nudAzot.Margin = new Padding(2, 3, 2, 3);
            nudAzot.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudAzot.Name = "nudAzot";
            nudAzot.Size = new Size(66, 27);
            nudAzot.TabIndex = 7;
            // 
            // lblFosfor
            // 
            lblFosfor.AutoSize = true;
            lblFosfor.BackColor = SystemColors.ControlDarkDark;
            lblFosfor.Location = new Point(175, 86);
            lblFosfor.Margin = new Padding(2, 0, 2, 0);
            lblFosfor.Name = "lblFosfor";
            lblFosfor.Size = new Size(79, 20);
            lblFosfor.TabIndex = 8;
            lblFosfor.Text = "Fosfor (%):";
            // 
            // nudFosfor
            // 
            nudFosfor.DecimalPlaces = 2;
            nudFosfor.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudFosfor.Location = new Point(255, 85);
            nudFosfor.Margin = new Padding(2, 3, 2, 3);
            nudFosfor.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFosfor.Name = "nudFosfor";
            nudFosfor.Size = new Size(66, 27);
            nudFosfor.TabIndex = 9;
            // 
            // lblPotasyum
            // 
            lblPotasyum.AutoSize = true;
            lblPotasyum.BackColor = SystemColors.ControlDarkDark;
            lblPotasyum.Location = new Point(333, 84);
            lblPotasyum.Margin = new Padding(2, 0, 2, 0);
            lblPotasyum.Name = "lblPotasyum";
            lblPotasyum.Size = new Size(101, 20);
            lblPotasyum.TabIndex = 10;
            lblPotasyum.Text = "Potasyum (%):";
            // 
            // nudPotasyum
            // 
            nudPotasyum.DecimalPlaces = 2;
            nudPotasyum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudPotasyum.Location = new Point(428, 84);
            nudPotasyum.Margin = new Padding(2, 3, 2, 3);
            nudPotasyum.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudPotasyum.Name = "nudPotasyum";
            nudPotasyum.Size = new Size(66, 27);
            nudPotasyum.TabIndex = 11;
            // 
            // lblDemir
            // 
            lblDemir.AutoSize = true;
            lblDemir.BackColor = SystemColors.ControlDarkDark;
            lblDemir.Location = new Point(509, 98);
            lblDemir.Margin = new Padding(2, 0, 2, 0);
            lblDemir.Name = "lblDemir";
            lblDemir.Size = new Size(53, 20);
            lblDemir.TabIndex = 12;
            lblDemir.Text = "Demir:";
            // 
            // nudDemir
            // 
            nudDemir.DecimalPlaces = 1;
            nudDemir.Location = new Point(559, 96);
            nudDemir.Margin = new Padding(2, 3, 2, 3);
            nudDemir.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudDemir.Name = "nudDemir";
            nudDemir.Size = new Size(66, 27);
            nudDemir.TabIndex = 13;
            // 
            // lblCinko
            // 
            lblCinko.AutoSize = true;
            lblCinko.BackColor = SystemColors.ControlDarkDark;
            lblCinko.Location = new Point(17, 119);
            lblCinko.Margin = new Padding(2, 0, 2, 0);
            lblCinko.Name = "lblCinko";
            lblCinko.Size = new Size(49, 20);
            lblCinko.TabIndex = 14;
            lblCinko.Text = "Çinko:";
            // 
            // nudCinko
            // 
            nudCinko.DecimalPlaces = 1;
            nudCinko.Location = new Point(92, 116);
            nudCinko.Margin = new Padding(2, 3, 2, 3);
            nudCinko.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudCinko.Name = "nudCinko";
            nudCinko.Size = new Size(66, 27);
            nudCinko.TabIndex = 15;
            // 
            // lblMangan
            // 
            lblMangan.AutoSize = true;
            lblMangan.BackColor = SystemColors.ControlDarkDark;
            lblMangan.Location = new Point(175, 119);
            lblMangan.Margin = new Padding(2, 0, 2, 0);
            lblMangan.Name = "lblMangan";
            lblMangan.Size = new Size(66, 20);
            lblMangan.TabIndex = 16;
            lblMangan.Text = "Mangan:";
            // 
            // nudMangan
            // 
            nudMangan.DecimalPlaces = 1;
            nudMangan.Location = new Point(255, 119);
            nudMangan.Margin = new Padding(2, 3, 2, 3);
            nudMangan.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudMangan.Name = "nudMangan";
            nudMangan.Size = new Size(66, 27);
            nudMangan.TabIndex = 17;
            // 
            // lblBakir
            // 
            lblBakir.AutoSize = true;
            lblBakir.BackColor = SystemColors.ControlDarkDark;
            lblBakir.Location = new Point(333, 117);
            lblBakir.Margin = new Padding(2, 0, 2, 0);
            lblBakir.Name = "lblBakir";
            lblBakir.Size = new Size(45, 20);
            lblBakir.TabIndex = 18;
            lblBakir.Text = "Bakır:";
            // 
            // nudBakir
            // 
            nudBakir.DecimalPlaces = 1;
            nudBakir.Location = new Point(428, 118);
            nudBakir.Margin = new Padding(2, 3, 2, 3);
            nudBakir.Name = "nudBakir";
            nudBakir.Size = new Size(66, 27);
            nudBakir.TabIndex = 19;
            // 
            // lblEksiklik
            // 
            lblEksiklik.AutoSize = true;
            lblEksiklik.BackColor = SystemColors.ControlDarkDark;
            lblEksiklik.Location = new Point(52, 173);
            lblEksiklik.Margin = new Padding(2, 0, 2, 0);
            lblEksiklik.Name = "lblEksiklik";
            lblEksiklik.Size = new Size(125, 20);
            lblEksiklik.TabIndex = 20;
            lblEksiklik.Text = "Gözlenen Eksiklik:";
            // 
            // cmbEksiklik
            // 
            cmbEksiklik.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEksiklik.Location = new Point(193, 167);
            cmbEksiklik.Margin = new Padding(2, 3, 2, 3);
            cmbEksiklik.Name = "cmbEksiklik";
            cmbEksiklik.Size = new Size(167, 28);
            cmbEksiklik.TabIndex = 21;
            // 
            // lblNot
            // 
            lblNot.AutoSize = true;
            lblNot.BackColor = SystemColors.ControlDark;
            lblNot.Location = new Point(110, 208);
            lblNot.Margin = new Padding(2, 0, 2, 0);
            lblNot.Name = "lblNot";
            lblNot.Size = new Size(37, 20);
            lblNot.TabIndex = 22;
            lblNot.Text = "Not:";
            // 
            // txtNot
            // 
            txtNot.Location = new Point(168, 205);
            txtNot.Margin = new Padding(2, 3, 2, 3);
            txtNot.Multiline = true;
            txtNot.Name = "txtNot";
            txtNot.Size = new Size(375, 58);
            txtNot.TabIndex = 23;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = SystemColors.ControlDark;
            btnKaydet.Location = new Point(75, 286);
            btnKaydet.Margin = new Padding(2, 3, 2, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(83, 38);
            btnKaydet.TabIndex = 24;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = SystemColors.ControlDark;
            btnTemizle.Location = new Point(162, 286);
            btnTemizle.Margin = new Padding(2, 3, 2, 3);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(83, 38);
            btnTemizle.TabIndex = 25;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = SystemColors.ControlDark;
            btnSil.Location = new Point(255, 286);
            btnSil.Margin = new Padding(2, 3, 2, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(83, 38);
            btnSil.TabIndex = 26;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYapayZekaTephis
            // 
            btnYapayZekaTephis.BackColor = SystemColors.ControlDark;
            btnYapayZekaTephis.Location = new Point(449, 286);
            btnYapayZekaTephis.Margin = new Padding(2, 3, 2, 3);
            btnYapayZekaTephis.Name = "btnYapayZekaTephis";
            btnYapayZekaTephis.Size = new Size(83, 38);
            btnYapayZekaTephis.TabIndex = 27;
            btnYapayZekaTephis.Text = "Öneri";
            btnYapayZekaTephis.UseVisualStyleBackColor = false;
            btnYapayZekaTephis.Click += btnYapayZekaTephis_Click;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = SystemColors.ControlDark;
            btnYenile.Location = new Point(351, 286);
            btnYenile.Margin = new Padding(2, 3, 2, 3);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(83, 38);
            btnYenile.TabIndex = 27;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // lblUrun
            // 
            lblUrun.AutoSize = true;
            lblUrun.BackColor = SystemColors.ControlDark;
            lblUrun.Location = new Point(109, 50);
            lblUrun.Margin = new Padding(2, 0, 2, 0);
            lblUrun.Name = "lblUrun";
            lblUrun.Size = new Size(43, 20);
            lblUrun.TabIndex = 0;
            lblUrun.Text = "Ürün:";
            // 
            // lblUurun
            // 
            lblUurun.Location = new Point(0, 0);
            lblUurun.Name = "lblUurun";
            lblUurun.Size = new Size(100, 23);
            lblUurun.TabIndex = 0;
            // 
            // dgvYaprak
            // 
            dgvYaprak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvYaprak.Dock = DockStyle.Fill;
            dgvYaprak.Location = new Point(0, 364);
            dgvYaprak.Margin = new Padding(2, 3, 2, 3);
            dgvYaprak.Name = "dgvYaprak";
            dgvYaprak.RowHeadersWidth = 51;
            dgvYaprak.Size = new Size(665, 207);
            dgvYaprak.TabIndex = 1;
            dgvYaprak.CellClick += dgvYaprak_CellClick;
            // 
            // YaprakAnalizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 571);
            Controls.Add(dgvYaprak);
            Controls.Add(grpGiris);
            Margin = new Padding(2, 3, 2, 3);
            Name = "YaprakAnalizForm";
            Text = "Yaprak Analizleri";
            Load += YaprakAnalizForm_Load;
            grpGiris.ResumeLayout(false);
            grpGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAzot).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFosfor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPotasyum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDemir).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCinko).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMangan).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudBakir).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvYaprak).EndInit();
            ResumeLayout(false);
        }

        private Button btnYapayZekaTephis;
    }
}