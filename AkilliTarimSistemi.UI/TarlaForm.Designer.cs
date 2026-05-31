namespace AkilliTarimSistemi.UI
{
    partial class TarlaForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form kontrolleri
        private System.Windows.Forms.Panel pnlFormContent;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblTarlaAdi;
        private System.Windows.Forms.TextBox txtTarlaAdi;
        private System.Windows.Forms.Label lblAlan;
        private System.Windows.Forms.NumericUpDown numAlan;
        private System.Windows.Forms.Label lblKonum;
        private System.Windows.Forms.TextBox txtKonum;
        private System.Windows.Forms.Label lblToprakTipi;
        private System.Windows.Forms.ComboBox cmbToprakTipi;
        private System.Windows.Forms.Button btnTarlaKaydet;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.DataGridView dgvTarlalar;
        private System.Windows.Forms.Panel pnlButtons;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlFormContent = new Panel();
            pnlInput = new Panel();
            lblTarlaAdi = new Label();
            btnSil = new Button();
            txtTarlaAdi = new TextBox();
            lblAlan = new Label();
            numAlan = new NumericUpDown();
            lblKonum = new Label();
            txtKonum = new TextBox();
            lblToprakTipi = new Label();
            cmbToprakTipi = new ComboBox();
            pnlButtons = new Panel();
            btnTarlaKaydet = new Button();
            btnYenile = new Button();
            btnTemizle = new Button();
            dgvTarlalar = new DataGridView();
            pnlFormContent.SuspendLayout();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAlan).BeginInit();
            pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTarlalar).BeginInit();
            SuspendLayout();
            // 
            // pnlFormContent
            // 
            pnlFormContent.Controls.Add(pnlInput);
            pnlFormContent.Controls.Add(dgvTarlalar);
            pnlFormContent.Dock = DockStyle.Fill;
            pnlFormContent.Location = new Point(0, 0);
            pnlFormContent.Margin = new Padding(3, 4, 3, 4);
            pnlFormContent.Name = "pnlFormContent";
            pnlFormContent.Padding = new Padding(23, 27, 23, 27);
            pnlFormContent.Size = new Size(1371, 933);
            pnlFormContent.TabIndex = 0;
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.FromArgb(25, 30, 45);
            pnlInput.BorderStyle = BorderStyle.FixedSingle;
            pnlInput.Controls.Add(lblTarlaAdi);
            pnlInput.Controls.Add(txtTarlaAdi);
            pnlInput.Controls.Add(lblAlan);
            pnlInput.Controls.Add(numAlan);
            pnlInput.Controls.Add(lblKonum);
            pnlInput.Controls.Add(txtKonum);
            pnlInput.Controls.Add(lblToprakTipi);
            pnlInput.Controls.Add(cmbToprakTipi);
            pnlInput.Controls.Add(pnlButtons);
            pnlInput.Location = new Point(23, 27);
            pnlInput.Margin = new Padding(3, 4, 3, 4);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(457, 879);
            pnlInput.TabIndex = 0;
            // 
            // lblTarlaAdi
            // 
            lblTarlaAdi.AutoSize = true;
            lblTarlaAdi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTarlaAdi.ForeColor = Color.FromArgb(0, 255, 100);
            lblTarlaAdi.Location = new Point(34, 40);
            lblTarlaAdi.Name = "lblTarlaAdi";
            lblTarlaAdi.Size = new Size(94, 25);
            lblTarlaAdi.TabIndex = 0;
            lblTarlaAdi.Text = "Tarla Adı:";
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.Transparent;
            btnSil.FlatAppearance.BorderColor = Color.FromArgb(255, 50, 50);
            btnSil.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 50, 50);
            btnSil.FlatStyle = FlatStyle.Flat;
            btnSil.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSil.ForeColor = Color.FromArgb(255, 80, 80);
            btnSil.Location = new Point(310, 23);
            btnSil.Margin = new Padding(3, 4, 3, 4);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(91, 53);
            btnSil.TabIndex = 2;
            btnSil.Text = "SİL";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // txtTarlaAdi
            // 
            txtTarlaAdi.BackColor = Color.FromArgb(15, 20, 30);
            txtTarlaAdi.BorderStyle = BorderStyle.FixedSingle;
            txtTarlaAdi.Font = new Font("Segoe UI", 11F);
            txtTarlaAdi.ForeColor = Color.White;
            txtTarlaAdi.Location = new Point(171, 36);
            txtTarlaAdi.Margin = new Padding(3, 4, 3, 4);
            txtTarlaAdi.Name = "txtTarlaAdi";
            txtTarlaAdi.Size = new Size(251, 32);
            txtTarlaAdi.TabIndex = 1;
            // 
            // lblAlan
            // 
            lblAlan.AutoSize = true;
            lblAlan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAlan.ForeColor = Color.FromArgb(0, 255, 100);
            lblAlan.Location = new Point(34, 107);
            lblAlan.Name = "lblAlan";
            lblAlan.Size = new Size(129, 25);
            lblAlan.TabIndex = 2;
            lblAlan.Text = "Alan (Dekar):";
            // 
            // numAlan
            // 
            numAlan.BackColor = Color.FromArgb(15, 20, 30);
            numAlan.DecimalPlaces = 2;
            numAlan.Font = new Font("Segoe UI", 11F);
            numAlan.ForeColor = Color.White;
            numAlan.Location = new Point(171, 104);
            numAlan.Margin = new Padding(3, 4, 3, 4);
            numAlan.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numAlan.Name = "numAlan";
            numAlan.Size = new Size(251, 32);
            numAlan.TabIndex = 3;
            // 
            // lblKonum
            // 
            lblKonum.AutoSize = true;
            lblKonum.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblKonum.ForeColor = Color.FromArgb(0, 255, 100);
            lblKonum.Location = new Point(34, 173);
            lblKonum.Name = "lblKonum";
            lblKonum.Size = new Size(82, 25);
            lblKonum.TabIndex = 4;
            lblKonum.Text = "Konum:";
            // 
            // txtKonum
            // 
            txtKonum.BackColor = Color.FromArgb(15, 20, 30);
            txtKonum.BorderStyle = BorderStyle.FixedSingle;
            txtKonum.Font = new Font("Segoe UI", 11F);
            txtKonum.ForeColor = Color.White;
            txtKonum.Location = new Point(171, 169);
            txtKonum.Margin = new Padding(3, 4, 3, 4);
            txtKonum.Name = "txtKonum";
            txtKonum.Size = new Size(251, 32);
            txtKonum.TabIndex = 5;
            // 
            // lblToprakTipi
            // 
            lblToprakTipi.AutoSize = true;
            lblToprakTipi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblToprakTipi.ForeColor = Color.FromArgb(0, 255, 100);
            lblToprakTipi.Location = new Point(34, 240);
            lblToprakTipi.Name = "lblToprakTipi";
            lblToprakTipi.Size = new Size(117, 25);
            lblToprakTipi.TabIndex = 6;
            lblToprakTipi.Text = "Toprak Tipi:";
            // 
            // cmbToprakTipi
            // 
            cmbToprakTipi.BackColor = Color.FromArgb(15, 20, 30);
            cmbToprakTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbToprakTipi.FlatStyle = FlatStyle.Flat;
            cmbToprakTipi.Font = new Font("Segoe UI", 11F);
            cmbToprakTipi.ForeColor = Color.White;
            cmbToprakTipi.Location = new Point(171, 236);
            cmbToprakTipi.Margin = new Padding(3, 4, 3, 4);
            cmbToprakTipi.Name = "cmbToprakTipi";
            cmbToprakTipi.Size = new Size(251, 33);
            cmbToprakTipi.TabIndex = 7;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnTarlaKaydet);
            pnlButtons.Controls.Add(btnSil);
            pnlButtons.Controls.Add(btnYenile);
            pnlButtons.Controls.Add(btnTemizle);
            pnlButtons.Location = new Point(19, 320);
            pnlButtons.Margin = new Padding(3, 4, 3, 4);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(404, 80);
            pnlButtons.TabIndex = 8;
            // 
            // btnTarlaKaydet
            // 
            btnTarlaKaydet.BackColor = Color.Transparent;
            btnTarlaKaydet.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 100);
            btnTarlaKaydet.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 255, 100);
            btnTarlaKaydet.FlatStyle = FlatStyle.Flat;
            btnTarlaKaydet.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTarlaKaydet.ForeColor = Color.FromArgb(0, 255, 100);
            btnTarlaKaydet.Location = new Point(15, 23);
            btnTarlaKaydet.Margin = new Padding(3, 4, 3, 4);
            btnTarlaKaydet.Name = "btnTarlaKaydet";
            btnTarlaKaydet.Size = new Size(82, 53);
            btnTarlaKaydet.TabIndex = 0;
            btnTarlaKaydet.Text = "KAYDET";
            btnTarlaKaydet.UseVisualStyleBackColor = false;
            btnTarlaKaydet.Click += btnTarlaKaydet_Click;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.Transparent;
            btnYenile.FlatAppearance.BorderColor = Color.FromArgb(255, 200, 0);
            btnYenile.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 200, 0);
            btnYenile.FlatStyle = FlatStyle.Flat;
            btnYenile.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYenile.ForeColor = Color.FromArgb(255, 200, 0);
            btnYenile.Location = new Point(212, 23);
            btnYenile.Margin = new Padding(3, 4, 3, 4);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(76, 53);
            btnYenile.TabIndex = 3;
            btnYenile.Text = "YENİLE";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.Transparent;
            btnTemizle.FlatAppearance.BorderColor = Color.FromArgb(0, 200, 255);
            btnTemizle.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 0, 200, 255);
            btnTemizle.FlatStyle = FlatStyle.Flat;
            btnTemizle.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTemizle.ForeColor = Color.FromArgb(0, 200, 255);
            btnTemizle.Location = new Point(104, 23);
            btnTemizle.Margin = new Padding(3, 4, 3, 4);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(90, 53);
            btnTemizle.TabIndex = 1;
            btnTemizle.Text = "TEMİZLE";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // dgvTarlalar
            // 
            dgvTarlalar.BackgroundColor = Color.FromArgb(25, 30, 45);
            dgvTarlalar.BorderStyle = BorderStyle.None;
            dgvTarlalar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTarlalar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTarlalar.GridColor = Color.FromArgb(45, 50, 70);
            dgvTarlalar.Location = new Point(503, 27);
            dgvTarlalar.Margin = new Padding(3, 4, 3, 4);
            dgvTarlalar.Name = "dgvTarlalar";
            dgvTarlalar.RowHeadersVisible = false;
            dgvTarlalar.RowHeadersWidth = 51;
            dgvTarlalar.Size = new Size(846, 880);
            dgvTarlalar.TabIndex = 1;
            dgvTarlalar.CellClick += dgvTarlalar_CellClick;
            // 
            // TarlaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 933);
            Controls.Add(pnlFormContent);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TarlaForm";
            Text = "Tarla Yönetimi";
            Load += TarlaForm_Load;
            pnlFormContent.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAlan).EndInit();
            pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTarlalar).EndInit();
            ResumeLayout(false);
        }
    }
}