namespace AkilliTarimSistemi.UI
{
    partial class OtomasyonForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpSimulasyon;
        private System.Windows.Forms.GroupBox grpSulama;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Button btnDurdur;
        private System.Windows.Forms.DataGridView dgvSensor;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.CheckBox chkOtomatikSulama;
        private System.Windows.Forms.Button btnManuelAc;
        private System.Windows.Forms.Button btnManuelKapa;
        private System.Windows.Forms.Label lblSicaklik;
        private System.Windows.Forms.Label lblNem;
        private System.Windows.Forms.Label lblToprakNemi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpSimulasyon = new GroupBox();
            btnBaslat = new Button();
            btnDurdur = new Button();
            dgvSensor = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            lblSicaklik = new Label();
            lblNem = new Label();
            lblToprakNemi = new Label();
            grpSulama = new GroupBox();
            chkOtomatikSulama = new CheckBox();
            btnManuelAc = new Button();
            btnManuelKapa = new Button();
            lblDurum = new Label();
            grpSimulasyon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSensor).BeginInit();
            grpSulama.SuspendLayout();
            SuspendLayout();
            // 
            // grpSimulasyon
            // 
            grpSimulasyon.Controls.Add(btnBaslat);
            grpSimulasyon.Controls.Add(btnDurdur);
            grpSimulasyon.Controls.Add(dgvSensor);
            grpSimulasyon.Controls.Add(lblSicaklik);
            grpSimulasyon.Controls.Add(lblNem);
            grpSimulasyon.Controls.Add(lblToprakNemi);
            grpSimulasyon.Location = new Point(18, 63);
            grpSimulasyon.Margin = new Padding(2);
            grpSimulasyon.Name = "grpSimulasyon";
            grpSimulasyon.Padding = new Padding(2);
            grpSimulasyon.Size = new Size(581, 275);
            grpSimulasyon.TabIndex = 0;
            grpSimulasyon.TabStop = false;
            grpSimulasyon.Text = "Sensör Simülasyonu";
            // 
            // btnBaslat
            // 
            btnBaslat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBaslat.Location = new Point(164, 20);
            btnBaslat.Margin = new Padding(2);
            btnBaslat.Name = "btnBaslat";
            btnBaslat.Size = new Size(158, 51);
            btnBaslat.TabIndex = 0;
            btnBaslat.Text = "Simülasyonu Başlat";
            btnBaslat.UseVisualStyleBackColor = true;
            btnBaslat.Click += btnBaslat_Click;
            // 
            // btnDurdur
            // 
            btnDurdur.Enabled = false;
            btnDurdur.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDurdur.Location = new Point(368, 20);
            btnDurdur.Margin = new Padding(2);
            btnDurdur.Name = "btnDurdur";
            btnDurdur.Size = new Size(107, 51);
            btnDurdur.TabIndex = 1;
            btnDurdur.Text = "Durdur";
            btnDurdur.UseVisualStyleBackColor = true;
            btnDurdur.Click += btnDurdur_Click;
            // 
            // dgvSensor
            // 
            dgvSensor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSensor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSensor.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dgvSensor.Location = new Point(55, 111);
            dgvSensor.Margin = new Padding(2);
            dgvSensor.Name = "dgvSensor";
            dgvSensor.RowHeadersWidth = 51;
            dgvSensor.Size = new Size(420, 179);
            dgvSensor.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "Saat";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Sıcaklık ";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Nem";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Toprak Nemi";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // lblSicaklik
            // 
            lblSicaklik.AutoSize = true;
            lblSicaklik.Location = new Point(195, 73);
            lblSicaklik.Margin = new Padding(2, 0, 2, 0);
            lblSicaklik.Name = "lblSicaklik";
            lblSicaklik.Size = new Size(71, 20);
            lblSicaklik.TabIndex = 3;
            lblSicaklik.Text = "Sıcaklık: -";
            // 
            // lblNem
            // 
            lblNem.AutoSize = true;
            lblNem.Location = new Point(268, 73);
            lblNem.Margin = new Padding(2, 0, 2, 0);
            lblNem.Name = "lblNem";
            lblNem.Size = new Size(54, 20);
            lblNem.TabIndex = 4;
            lblNem.Text = "Nem: -";
            // 
            // lblToprakNemi
            // 
            lblToprakNemi.AutoSize = true;
            lblToprakNemi.Location = new Point(326, 73);
            lblToprakNemi.Margin = new Padding(2, 0, 2, 0);
            lblToprakNemi.Name = "lblToprakNemi";
            lblToprakNemi.Size = new Size(107, 20);
            lblToprakNemi.TabIndex = 5;
            lblToprakNemi.Text = "Toprak Nemi: -";
            // 
            // grpSulama
            // 
            grpSulama.Controls.Add(chkOtomatikSulama);
            grpSulama.Controls.Add(btnManuelAc);
            grpSulama.Controls.Add(btnManuelKapa);
            grpSulama.Controls.Add(lblDurum);
            grpSulama.Location = new Point(631, 91);
            grpSulama.Margin = new Padding(2);
            grpSulama.Name = "grpSulama";
            grpSulama.Padding = new Padding(2);
            grpSulama.Size = new Size(294, 168);
            grpSulama.TabIndex = 1;
            grpSulama.TabStop = false;
            grpSulama.Text = "Sulama Kontrolü";
            // 
            // chkOtomatikSulama
            // 
            chkOtomatikSulama.AutoSize = true;
            chkOtomatikSulama.Location = new Point(15, 25);
            chkOtomatikSulama.Margin = new Padding(2);
            chkOtomatikSulama.Name = "chkOtomatikSulama";
            chkOtomatikSulama.Size = new Size(146, 24);
            chkOtomatikSulama.TabIndex = 0;
            chkOtomatikSulama.Text = "Otomatik Sulama";
            chkOtomatikSulama.UseVisualStyleBackColor = true;
            // 
            // btnManuelAc
            // 
            btnManuelAc.Location = new Point(15, 50);
            btnManuelAc.Margin = new Padding(2);
            btnManuelAc.Name = "btnManuelAc";
            btnManuelAc.Size = new Size(73, 25);
            btnManuelAc.TabIndex = 1;
            btnManuelAc.Text = "Manuel AÇ";
            btnManuelAc.UseVisualStyleBackColor = true;
            btnManuelAc.Click += btnManuelSulamaAc_Click;
            // 
            // btnManuelKapa
            // 
            btnManuelKapa.Location = new Point(95, 50);
            btnManuelKapa.Margin = new Padding(2);
            btnManuelKapa.Name = "btnManuelKapa";
            btnManuelKapa.Size = new Size(73, 25);
            btnManuelKapa.TabIndex = 2;
            btnManuelKapa.Text = "Manuel KAPA";
            btnManuelKapa.UseVisualStyleBackColor = true;
            btnManuelKapa.Click += btnManuelSulamaKapa_Click;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(15, 93);
            lblDurum.Margin = new Padding(2, 0, 2, 0);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(138, 20);
            lblDurum.TabIndex = 3;
            lblDurum.Text = "Sulama durumu: ---";
            // 
            // OtomasyonForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 450);
            Controls.Add(grpSulama);
            Controls.Add(grpSimulasyon);
            Margin = new Padding(2);
            Name = "OtomasyonForm";
            Text = "IoT Otomasyon ve Sensör Simülasyonu";
            grpSimulasyon.ResumeLayout(false);
            grpSimulasyon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSensor).EndInit();
            grpSulama.ResumeLayout(false);
            grpSulama.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}