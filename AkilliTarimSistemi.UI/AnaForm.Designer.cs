namespace AkilliTarimSistemi.UI
{
    partial class AnaForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnToprakAnaliz = new System.Windows.Forms.Button();
            this.btnYaprakAnaliz = new System.Windows.Forms.Button();
            this.btnSuAnaliz = new System.Windows.Forms.Button();
            this.btnTahminOneri = new System.Windows.Forms.Button();
            this.btnOtomasyon = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.btnTarlalarim = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.btnToprakAnaliz);
            this.pnlSidebar.Controls.Add(this.btnYaprakAnaliz);
            this.pnlSidebar.Controls.Add(this.btnSuAnaliz);
            this.pnlSidebar.Controls.Add(this.btnTahminOneri);
            this.pnlSidebar.Controls.Add(this.btnOtomasyon);
            this.pnlSidebar.Controls.Add(this.btnRaporlar);
            this.pnlSidebar.Controls.Add(this.btnTarlalarim);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 850);
            this.pnlSidebar.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(236, 120);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnToprakAnaliz
            // 
            this.btnToprakAnaliz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnToprakAnaliz.FlatAppearance.BorderSize = 0;
            this.btnToprakAnaliz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToprakAnaliz.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToprakAnaliz.ForeColor = System.Drawing.Color.White;
            this.btnToprakAnaliz.Location = new System.Drawing.Point(0, 150);
            this.btnToprakAnaliz.Name = "btnToprakAnaliz";
            this.btnToprakAnaliz.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnToprakAnaliz.Size = new System.Drawing.Size(260, 50);
            this.btnToprakAnaliz.Text = "🌱  Toprak Analizi";
            this.btnToprakAnaliz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToprakAnaliz.UseVisualStyleBackColor = false;
            this.btnToprakAnaliz.Click += new System.EventHandler(this.btnToprakAnaliz_Click);
            // 
            // btnYaprakAnaliz
            // 
            this.btnYaprakAnaliz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnYaprakAnaliz.FlatAppearance.BorderSize = 0;
            this.btnYaprakAnaliz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYaprakAnaliz.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnYaprakAnaliz.ForeColor = System.Drawing.Color.White;
            this.btnYaprakAnaliz.Location = new System.Drawing.Point(0, 205);
            this.btnYaprakAnaliz.Name = "btnYaprakAnaliz";
            this.btnYaprakAnaliz.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnYaprakAnaliz.Size = new System.Drawing.Size(260, 50);
            this.btnYaprakAnaliz.Text = "🍃  Yaprak Analizi";
            this.btnYaprakAnaliz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnYaprakAnaliz.UseVisualStyleBackColor = false;
            this.btnYaprakAnaliz.Click += new System.EventHandler(this.btnYaprakAnaliz_Click);
            // 
            // btnSuAnaliz
            // 
            this.btnSuAnaliz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnSuAnaliz.FlatAppearance.BorderSize = 0;
            this.btnSuAnaliz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuAnaliz.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSuAnaliz.ForeColor = System.Drawing.Color.White;
            this.btnSuAnaliz.Location = new System.Drawing.Point(0, 260);
            this.btnSuAnaliz.Name = "btnSuAnaliz";
            this.btnSuAnaliz.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSuAnaliz.Size = new System.Drawing.Size(260, 50);
            this.btnSuAnaliz.Text = "💧  Su Analizi";
            this.btnSuAnaliz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuAnaliz.UseVisualStyleBackColor = false;
            this.btnSuAnaliz.Click += new System.EventHandler(this.btnSuAnaliz_Click);
            // 
            // btnTahminOneri
            // 
            this.btnTahminOneri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnTahminOneri.FlatAppearance.BorderSize = 0;
            this.btnTahminOneri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTahminOneri.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTahminOneri.ForeColor = System.Drawing.Color.White;
            this.btnTahminOneri.Location = new System.Drawing.Point(0, 315);
            this.btnTahminOneri.Name = "btnTahminOneri";
            this.btnTahminOneri.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTahminOneri.Size = new System.Drawing.Size(260, 50);
            this.btnTahminOneri.Text = "📊  Tahmin ve Öneri";
            this.btnTahminOneri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTahminOneri.UseVisualStyleBackColor = false;
            this.btnTahminOneri.Click += new System.EventHandler(this.btnTahminOneri_Click);
            // 
            // btnOtomasyon
            // 
            this.btnOtomasyon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnOtomasyon.FlatAppearance.BorderSize = 0;
            this.btnOtomasyon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtomasyon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOtomasyon.ForeColor = System.Drawing.Color.White;
            this.btnOtomasyon.Location = new System.Drawing.Point(0, 370);
            this.btnOtomasyon.Name = "btnOtomasyon";
            this.btnOtomasyon.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnOtomasyon.Size = new System.Drawing.Size(260, 50);
            this.btnOtomasyon.Text = "⚙️  Otomasyon";
            this.btnOtomasyon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOtomasyon.UseVisualStyleBackColor = false;
            this.btnOtomasyon.Click += new System.EventHandler(this.btnOtomasyon_Click);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporlar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnRaporlar.Location = new System.Drawing.Point(0, 425);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRaporlar.Size = new System.Drawing.Size(260, 50);
            this.btnRaporlar.Text = "📋  Raporlar";
            this.btnRaporlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporlar.UseVisualStyleBackColor = false;
            this.btnRaporlar.Click += new System.EventHandler(this.btnRaporlar_Click);
            // 
            // btnTarlalarim
            // 
            this.btnTarlalarim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnTarlalarim.FlatAppearance.BorderSize = 0;
            this.btnTarlalarim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTarlalarim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTarlalarim.ForeColor = System.Drawing.Color.White;
            this.btnTarlalarim.Location = new System.Drawing.Point(0, 480);
            this.btnTarlalarim.Name = "btnTarlalarim";
            this.btnTarlalarim.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnTarlalarim.Size = new System.Drawing.Size(260, 50);
            this.btnTarlalarim.Text = "🗺️  Tarlalarım";
            this.btnTarlalarim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTarlalarim.UseVisualStyleBackColor = false;
            this.btnTarlalarim.Click += new System.EventHandler(this.btnTarlalarim_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(48)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(260, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(990, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Size = new System.Drawing.Size(182, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Akıllı Tarım Sistemi";
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUser.ForeColor = System.Drawing.Color.LightGray;
            this.lblUser.Location = new System.Drawing.Point(650, 20);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(230, 20);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Hoş Geldiniz";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(945, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(905, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 35);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(260, 60);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(990, 790);
            this.pnlContainer.TabIndex = 2;
            // 
            // AnaForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1250, 850);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akıllı Tarım Yönetim Sistemi";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnToprakAnaliz;
        private System.Windows.Forms.Button btnYaprakAnaliz;
        private System.Windows.Forms.Button btnSuAnaliz;
        private System.Windows.Forms.Button btnTahminOneri;
        private System.Windows.Forms.Button btnOtomasyon;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnTarlalarim;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlContainer;
    }
}