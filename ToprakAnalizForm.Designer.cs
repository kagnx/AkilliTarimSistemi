namespace AkilliTarimSistemi.UI
{
    partial class ToprakAnalizForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpGiris;
        private System.Windows.Forms.Label lblUrun;
        private System.Windows.Forms.ComboBox cmbUrun;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.Label lblpH;
        private System.Windows.Forms.NumericUpDown nudpH;
        private System.Windows.Forms.Label lblAzot;
        private System.Windows.Forms.NumericUpDown nudAzot;
        private System.Windows.Forms.Label lblFosfor;
        private System.Windows.Forms.NumericUpDown nudFosfor;
        private System.Windows.Forms.Label lblPotasyum;
        private System.Windows.Forms.NumericUpDown nudPotasyum;
        private System.Windows.Forms.Label lblKalsiyum;
        private System.Windows.Forms.NumericUpDown nudKalsiyum;
        private System.Windows.Forms.Label lblMagnezyum;
        private System.Windows.Forms.NumericUpDown nudMagnezyum;
        private System.Windows.Forms.Label lblOrganikMadde;
        private System.Windows.Forms.NumericUpDown nudOrganikMadde;
        private System.Windows.Forms.Label lblTuzluluk;
        private System.Windows.Forms.NumericUpDown nudEC;
        private System.Windows.Forms.Label lblNotlar;
        private System.Windows.Forms.TextBox txtNotlar;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.DataGridView dgvToprak;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpGiris = new GroupBox();
            lblTarih = new Label();
            dtpTarih = new DateTimePicker();
            lblpH = new Label();
            nudpH = new NumericUpDown();
            lblAzot = new Label();
            nudAzot = new NumericUpDown();
            lblFosfor = new Label();
            nudFosfor = new NumericUpDown();
            lblPotasyum = new Label();
            nudPotasyum = new NumericUpDown();
            lblKalsiyum = new Label();
            nudKalsiyum = new NumericUpDown();
            lblMagnezyum = new Label();
            nudMagnezyum = new NumericUpDown();
            lblOrganikMadde = new Label();
            nudOrganikMadde = new NumericUpDown();
            lblTuzluluk = new Label();
            nudEC = new NumericUpDown();
            lblNotlar = new Label();
            txtNotlar = new TextBox();
            btnKaydet = new Button();
            btnTemizle = new Button();
            btnSil = new Button();
            btnToprakYaykRaporu = new Button();
            btnYenile = new Button();
            cmbTarlaSec = new ComboBox();
            cmbUrun = new ComboBox();
            lblTarlaSec = new Label();
            lblUrun = new Label();
            dgvToprak = new DataGridView();
            grpGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudpH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAzot).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFosfor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPotasyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudKalsiyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMagnezyum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOrganikMadde).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvToprak).BeginInit();
            SuspendLayout();
            // 
            // grpGiris
            // 
            grpGiris.Controls.Add(lblTarih);
            grpGiris.Controls.Add(dtpTarih);
            grpGiris.Controls.Add(lblpH);
            grpGiris.Controls.Add(nudpH);
            grpGiris.Controls.Add(lblAzot);
            grpGiris.Controls.Add(nudAzot);
            grpGiris.Controls.Add(lblFosfor);
            grpGiris.Controls.Add(nudFosfor);
            grpGiris.Controls.Add(lblPotasyum);
            grpGiris.Controls.Add(nudPotasyum);
            grpGiris.Controls.Add(lblKalsiyum);
            grpGiris.Controls.Add(nudKalsiyum);
            grpGiris.Controls.Add(lblMagnezyum);
            grpGiris.Controls.Add(nudMagnezyum);
            grpGiris.Controls.Add(lblOrganikMadde);
            grpGiris.Controls.Add(nudOrganikMadde);
            grpGiris.Controls.Add(lblTuzluluk);
            grpGiris.Controls.Add(nudEC);
            grpGiris.Controls.Add(lblNotlar);
            grpGiris.Controls.Add(txtNotlar);
            grpGiris.Controls.Add(btnKaydet);
            grpGiris.Controls.Add(btnTemizle);
            grpGiris.Controls.Add(btnSil);
            grpGiris.Controls.Add(btnToprakYaykRaporu);
            grpGiris.Controls.Add(btnYenile);
            grpGiris.Controls.Add(cmbTarlaSec);
            grpGiris.Controls.Add(cmbUrun);
            grpGiris.Controls.Add(lblTarlaSec);
            grpGiris.Controls.Add(lblUrun);
            grpGiris.Dock = DockStyle.Top;
            grpGiris.Location = new Point(0, 0);
            grpGiris.Margin = new Padding(2);
            grpGiris.Name = "grpGiris";
            grpGiris.Padding = new Padding(2);
            grpGiris.Size = new Size(941, 250);
            grpGiris.TabIndex = 0;
            grpGiris.TabStop = false;
            grpGiris.Text = "Toprak Analizi Girişi";
            // 
            // lblTarih
            // 
            lblTarih.AutoSize = true;
            lblTarih.Location = new Point(435, 26);
            lblTarih.Margin = new Padding(2, 0, 2, 0);
            lblTarih.Name = "lblTarih";
            lblTarih.Size = new Size(43, 20);
            lblTarih.TabIndex = 2;
            lblTarih.Text = "Tarih:";
            // 
            // dtpTarih
            // 
            dtpTarih.Location = new Point(486, 25);
            dtpTarih.Margin = new Padding(2);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(92, 27);
            dtpTarih.TabIndex = 3;
            // 
            // lblpH
            // 
            lblpH.AutoSize = true;
            lblpH.Location = new Point(34, 78);
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
            nudpH.Location = new Point(110, 70);
            nudpH.Margin = new Padding(2);
            nudpH.Maximum = new decimal(new int[] { 14, 0, 0, 0 });
            nudpH.Name = "nudpH";
            nudpH.Size = new Size(48, 27);
            nudpH.TabIndex = 5;
            // 
            // lblAzot
            // 
            lblAzot.AutoSize = true;
            lblAzot.Location = new Point(208, 83);
            lblAzot.Margin = new Padding(2, 0, 2, 0);
            lblAzot.Name = "lblAzot";
            lblAzot.Size = new Size(43, 20);
            lblAzot.TabIndex = 6;
            lblAzot.Text = "Azot:";
            // 
            // nudAzot
            // 
            nudAzot.DecimalPlaces = 1;
            nudAzot.Location = new Point(279, 74);
            nudAzot.Margin = new Padding(2);
            nudAzot.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudAzot.Name = "nudAzot";
            nudAzot.Size = new Size(48, 27);
            nudAzot.TabIndex = 7;
            // 
            // lblFosfor
            // 
            lblFosfor.AutoSize = true;
            lblFosfor.Location = new Point(341, 77);
            lblFosfor.Margin = new Padding(2, 0, 2, 0);
            lblFosfor.Name = "lblFosfor";
            lblFosfor.Size = new Size(53, 20);
            lblFosfor.TabIndex = 8;
            lblFosfor.Text = "Fosfor:";
            // 
            // nudFosfor
            // 
            nudFosfor.DecimalPlaces = 1;
            nudFosfor.Location = new Point(427, 71);
            nudFosfor.Margin = new Padding(2);
            nudFosfor.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            nudFosfor.Name = "nudFosfor";
            nudFosfor.Size = new Size(48, 27);
            nudFosfor.TabIndex = 9;
            // 
            // lblPotasyum
            // 
            lblPotasyum.AutoSize = true;
            lblPotasyum.Location = new Point(486, 71);
            lblPotasyum.Margin = new Padding(2, 0, 2, 0);
            lblPotasyum.Name = "lblPotasyum";
            lblPotasyum.Size = new Size(75, 20);
            lblPotasyum.TabIndex = 10;
            lblPotasyum.Text = "Potasyum:";
            // 
            // nudPotasyum
            // 
            nudPotasyum.DecimalPlaces = 1;
            nudPotasyum.Location = new Point(565, 72);
            nudPotasyum.Margin = new Padding(2);
            nudPotasyum.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPotasyum.Name = "nudPotasyum";
            nudPotasyum.Size = new Size(48, 27);
            nudPotasyum.TabIndex = 11;
            // 
            // lblKalsiyum
            // 
            lblKalsiyum.AutoSize = true;
            lblKalsiyum.Location = new Point(34, 99);
            lblKalsiyum.Margin = new Padding(2, 0, 2, 0);
            lblKalsiyum.Name = "lblKalsiyum";
            lblKalsiyum.Size = new Size(71, 20);
            lblKalsiyum.TabIndex = 12;
            lblKalsiyum.Text = "Kalsiyum:";
            // 
            // nudKalsiyum
            // 
            nudKalsiyum.DecimalPlaces = 1;
            nudKalsiyum.Location = new Point(110, 98);
            nudKalsiyum.Margin = new Padding(2);
            nudKalsiyum.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudKalsiyum.Name = "nudKalsiyum";
            nudKalsiyum.Size = new Size(48, 27);
            nudKalsiyum.TabIndex = 13;
            // 
            // lblMagnezyum
            // 
            lblMagnezyum.AutoSize = true;
            lblMagnezyum.Location = new Point(175, 105);
            lblMagnezyum.Margin = new Padding(2, 0, 2, 0);
            lblMagnezyum.Name = "lblMagnezyum";
            lblMagnezyum.Size = new Size(93, 20);
            lblMagnezyum.TabIndex = 14;
            lblMagnezyum.Text = "Magnezyum:";
            // 
            // nudMagnezyum
            // 
            nudMagnezyum.DecimalPlaces = 1;
            nudMagnezyum.Location = new Point(279, 101);
            nudMagnezyum.Margin = new Padding(2);
            nudMagnezyum.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudMagnezyum.Name = "nudMagnezyum";
            nudMagnezyum.Size = new Size(48, 27);
            nudMagnezyum.TabIndex = 15;
            // 
            // lblOrganikMadde
            // 
            lblOrganikMadde.AutoSize = true;
            lblOrganikMadde.Location = new Point(341, 103);
            lblOrganikMadde.Margin = new Padding(2, 0, 2, 0);
            lblOrganikMadde.Name = "lblOrganikMadde";
            lblOrganikMadde.Size = new Size(77, 20);
            lblOrganikMadde.TabIndex = 16;
            lblOrganikMadde.Text = "Org. Mad.:";
            // 
            // nudOrganikMadde
            // 
            nudOrganikMadde.DecimalPlaces = 1;
            nudOrganikMadde.Location = new Point(427, 98);
            nudOrganikMadde.Margin = new Padding(2);
            nudOrganikMadde.Name = "nudOrganikMadde";
            nudOrganikMadde.Size = new Size(48, 27);
            nudOrganikMadde.TabIndex = 17;
            // 
            // lblTuzluluk
            // 
            lblTuzluluk.AutoSize = true;
            lblTuzluluk.Location = new Point(498, 95);
            lblTuzluluk.Margin = new Padding(2, 0, 2, 0);
            lblTuzluluk.Name = "lblTuzluluk";
            lblTuzluluk.Size = new Size(66, 20);
            lblTuzluluk.TabIndex = 18;
            lblTuzluluk.Text = "Tuzluluk:";
            // 
            // nudEC
            // 
            nudEC.DecimalPlaces = 2;
            nudEC.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            nudEC.Location = new Point(565, 97);
            nudEC.Margin = new Padding(2);
            nudEC.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nudEC.Name = "nudEC";
            nudEC.Size = new Size(48, 27);
            nudEC.TabIndex = 19;
            // 
            // lblNotlar
            // 
            lblNotlar.AutoSize = true;
            lblNotlar.Location = new Point(68, 158);
            lblNotlar.Margin = new Padding(2, 0, 2, 0);
            lblNotlar.Name = "lblNotlar";
            lblNotlar.Size = new Size(54, 20);
            lblNotlar.TabIndex = 20;
            lblNotlar.Text = "Notlar:";
            // 
            // txtNotlar
            // 
            txtNotlar.Location = new Point(156, 148);
            txtNotlar.Margin = new Padding(2);
            txtNotlar.Multiline = true;
            txtNotlar.Name = "txtNotlar";
            txtNotlar.Size = new Size(352, 42);
            txtNotlar.TabIndex = 21;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(80, 208);
            btnKaydet.Margin = new Padding(2);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(69, 27);
            btnKaydet.TabIndex = 22;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Location = new Point(153, 208);
            btnTemizle.Margin = new Padding(2);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(69, 27);
            btnTemizle.TabIndex = 23;
            btnTemizle.Text = "Temizle";
            btnTemizle.UseVisualStyleBackColor = true;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(225, 208);
            btnSil.Margin = new Padding(2);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(60, 27);
            btnSil.TabIndex = 24;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnToprakYaykRaporu
            // 
            btnToprakYaykRaporu.Location = new Point(382, 208);
            btnToprakYaykRaporu.Margin = new Padding(2);
            btnToprakYaykRaporu.Name = "btnToprakYaykRaporu";
            btnToprakYaykRaporu.Size = new Size(68, 27);
            btnToprakYaykRaporu.TabIndex = 25;
            btnToprakYaykRaporu.Text = "Tavsiye";
            btnToprakYaykRaporu.UseVisualStyleBackColor = true;
            btnToprakYaykRaporu.Click += btnToprakYaykRaporu_Click;
            // 
            // btnYenile
            // 
            btnYenile.Location = new Point(298, 208);
            btnYenile.Margin = new Padding(2);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(60, 27);
            btnYenile.TabIndex = 25;
            btnYenile.Text = "Yenile";
            btnYenile.UseVisualStyleBackColor = true;
            btnYenile.Click += btnYenile_Click;
            // 
            // cmbTarlaSec
            // 
            cmbTarlaSec.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTarlaSec.Location = new Point(713, 155);
            cmbTarlaSec.Margin = new Padding(2);
            cmbTarlaSec.Name = "cmbTarlaSec";
            cmbTarlaSec.Size = new Size(108, 28);
            cmbTarlaSec.TabIndex = 1;
            // 
            // cmbUrun
            // 
            cmbUrun.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUrun.Location = new Point(281, 26);
            cmbUrun.Margin = new Padding(2);
            cmbUrun.Name = "cmbUrun";
            cmbUrun.Size = new Size(108, 28);
            cmbUrun.TabIndex = 1;
            // 
            // lblTarlaSec
            // 
            lblTarlaSec.Location = new Point(654, 161);
            lblTarlaSec.Margin = new Padding(2, 0, 2, 0);
            lblTarlaSec.Name = "lblTarlaSec";
            lblTarlaSec.Size = new Size(53, 17);
            lblTarlaSec.TabIndex = 0;
            lblTarlaSec.Text = "Tarla:";
            // 
            // lblUrun
            // 
            lblUrun.Location = new Point(222, 32);
            lblUrun.Margin = new Padding(2, 0, 2, 0);
            lblUrun.Name = "lblUrun";
            lblUrun.Size = new Size(53, 17);
            lblUrun.TabIndex = 0;
            lblUrun.Text = "Ürün:";
            // 
            // dgvToprak
            // 
            dgvToprak.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvToprak.Dock = DockStyle.Fill;
            dgvToprak.Location = new Point(0, 250);
            dgvToprak.Margin = new Padding(2);
            dgvToprak.Name = "dgvToprak";
            dgvToprak.RowHeadersWidth = 51;
            dgvToprak.Size = new Size(941, 259);
            dgvToprak.TabIndex = 1;
            dgvToprak.CellClick += dgvToprak_CellClick;
            // 
            // ToprakAnalizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 509);
            Controls.Add(dgvToprak);
            Controls.Add(grpGiris);
            Margin = new Padding(2);
            Name = "ToprakAnalizForm";
            Text = "Toprak Analizleri";
            grpGiris.ResumeLayout(false);
            grpGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudpH).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAzot).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFosfor).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPotasyum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudKalsiyum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMagnezyum).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOrganikMadde).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEC).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvToprak).EndInit();
            ResumeLayout(false);
        }

        private ComboBox cmbTarlaSec;
        private Label lblTarlaSec;
        private Button btnToprakYaykRaporu;
    }
}