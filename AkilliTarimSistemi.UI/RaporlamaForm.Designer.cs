namespace AkilliTarimSistemi.UI
{
    partial class RaporlamaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpRapor;
        private System.Windows.Forms.Label lblRaporTipi;
        private System.Windows.Forms.ComboBox cmbRaporTipi;
        private System.Windows.Forms.Label lblBaslangic;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Label lblBitis;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.Button btnExcelOlustur;
        private System.Windows.Forms.Button btnPdfOlustur;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpRapor = new GroupBox();
            lblRaporTipi = new Label();
            cmbRaporTipi = new ComboBox();
            lblBaslangic = new Label();
            dtpBaslangic = new DateTimePicker();
            lblBitis = new Label();
            dtpBitis = new DateTimePicker();
            btnExcelOlustur = new Button();
            btnPdfOlustur = new Button();
            grpRapor.SuspendLayout();
            SuspendLayout();
            // 
            // grpRapor
            // 
            grpRapor.Controls.Add(lblRaporTipi);
            grpRapor.Controls.Add(cmbRaporTipi);
            grpRapor.Controls.Add(lblBaslangic);
            grpRapor.Controls.Add(dtpBaslangic);
            grpRapor.Controls.Add(lblBitis);
            grpRapor.Controls.Add(dtpBitis);
            grpRapor.Controls.Add(btnExcelOlustur);
            grpRapor.Controls.Add(btnPdfOlustur);
            grpRapor.Dock = DockStyle.Fill;
            grpRapor.Location = new Point(0, 0);
            grpRapor.Margin = new Padding(2, 2, 2, 2);
            grpRapor.Name = "grpRapor";
            grpRapor.Padding = new Padding(2, 2, 2, 2);
            grpRapor.Size = new Size(791, 444);
            grpRapor.TabIndex = 0;
            grpRapor.TabStop = false;
            grpRapor.Text = "Rapor Oluşturma";
            // 
            // lblRaporTipi
            // 
            lblRaporTipi.AutoSize = true;
            lblRaporTipi.Location = new Point(56, 35);
            lblRaporTipi.Margin = new Padding(2, 0, 2, 0);
            lblRaporTipi.Name = "lblRaporTipi";
            lblRaporTipi.Size = new Size(81, 20);
            lblRaporTipi.TabIndex = 0;
            lblRaporTipi.Text = "Rapor Tipi:";
            // 
            // cmbRaporTipi
            // 
            cmbRaporTipi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporTipi.Location = new Point(152, 35);
            cmbRaporTipi.Margin = new Padding(2, 2, 2, 2);
            cmbRaporTipi.Name = "cmbRaporTipi";
            cmbRaporTipi.Size = new Size(147, 28);
            cmbRaporTipi.TabIndex = 1;
            // 
            // lblBaslangic
            // 
            lblBaslangic.AutoSize = true;
            lblBaslangic.Location = new Point(67, 92);
            lblBaslangic.Margin = new Padding(2, 0, 2, 0);
            lblBaslangic.Name = "lblBaslangic";
            lblBaslangic.Size = new Size(75, 20);
            lblBaslangic.TabIndex = 2;
            lblBaslangic.Text = "Başlangıç:";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.Location = new Point(152, 92);
            dtpBaslangic.Margin = new Padding(2, 2, 2, 2);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(147, 27);
            dtpBaslangic.TabIndex = 3;
            // 
            // lblBitis
            // 
            lblBitis.AutoSize = true;
            lblBitis.Location = new Point(67, 121);
            lblBitis.Margin = new Padding(2, 0, 2, 0);
            lblBitis.Name = "lblBitis";
            lblBitis.Size = new Size(40, 20);
            lblBitis.TabIndex = 4;
            lblBitis.Text = "Bitiş:";
            // 
            // dtpBitis
            // 
            dtpBitis.Location = new Point(152, 121);
            dtpBitis.Margin = new Padding(2, 2, 2, 2);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(147, 27);
            dtpBitis.TabIndex = 5;
            // 
            // btnExcelOlustur
            // 
            btnExcelOlustur.Location = new Point(125, 153);
            btnExcelOlustur.Margin = new Padding(2, 2, 2, 2);
            btnExcelOlustur.Name = "btnExcelOlustur";
            btnExcelOlustur.Size = new Size(87, 29);
            btnExcelOlustur.TabIndex = 6;
            btnExcelOlustur.Text = "Excel Oluştur";
            btnExcelOlustur.UseVisualStyleBackColor = true;
            btnExcelOlustur.Click += btnExcelOlustur_Click;
            // 
            // btnPdfOlustur
            // 
            btnPdfOlustur.Location = new Point(227, 153);
            btnPdfOlustur.Margin = new Padding(2, 2, 2, 2);
            btnPdfOlustur.Name = "btnPdfOlustur";
            btnPdfOlustur.Size = new Size(87, 29);
            btnPdfOlustur.TabIndex = 7;
            btnPdfOlustur.Text = "PDF Oluştur";
            btnPdfOlustur.UseVisualStyleBackColor = true;
            btnPdfOlustur.Click += btnPdfOlustur_Click;
            // 
            // RaporlamaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 444);
            Controls.Add(grpRapor);
            Margin = new Padding(2, 2, 2, 2);
            Name = "RaporlamaForm";
            Text = "Raporlama";
            Controls.SetChildIndex(grpRapor, 0);
            grpRapor.ResumeLayout(false);
            grpRapor.PerformLayout();
            ResumeLayout(false);
        }
    }
}