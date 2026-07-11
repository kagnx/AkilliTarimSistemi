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
            pnlSidebar = new Panel();
            picLogo = new PictureBox();
            btnToprakAnaliz = new Button();
            btnYaprakAnaliz = new Button();
            btnSuAnaliz = new Button();
            btnHakkinda = new Button();
            btnOtomasyon = new Button();
            btnRaporlar = new Button();
            btnTarlalarim = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblUser = new Label();
            btnClose = new Button();
            btnMinimize = new Button();
            pnlContainer = new Panel();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(20, 25, 40);
            pnlSidebar.Controls.Add(picLogo);
            pnlSidebar.Controls.Add(btnToprakAnaliz);
            pnlSidebar.Controls.Add(btnYaprakAnaliz);
            pnlSidebar.Controls.Add(btnSuAnaliz);
            pnlSidebar.Controls.Add(btnHakkinda);
            pnlSidebar.Controls.Add(btnOtomasyon);
            pnlSidebar.Controls.Add(btnRaporlar);
            pnlSidebar.Controls.Add(btnTarlalarim);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 850);
            pnlSidebar.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.Location = new Point(12, 12);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(236, 120);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // btnToprakAnaliz
            // 
            btnToprakAnaliz.BackColor = Color.FromArgb(20, 25, 40);
            btnToprakAnaliz.FlatAppearance.BorderSize = 0;
            btnToprakAnaliz.FlatStyle = FlatStyle.Flat;
            btnToprakAnaliz.Font = new Font("Segoe UI", 11F);
            btnToprakAnaliz.ForeColor = Color.White;
            btnToprakAnaliz.Location = new Point(0, 150);
            btnToprakAnaliz.Name = "btnToprakAnaliz";
            btnToprakAnaliz.Padding = new Padding(20, 0, 0, 0);
            btnToprakAnaliz.Size = new Size(260, 50);
            btnToprakAnaliz.TabIndex = 1;
            btnToprakAnaliz.Text = "🌱  Toprak Analizi";
            btnToprakAnaliz.TextAlign = ContentAlignment.MiddleLeft;
            btnToprakAnaliz.UseVisualStyleBackColor = false;
            btnToprakAnaliz.Click += btnToprakAnaliz_Click;
            // 
            // btnYaprakAnaliz
            // 
            btnYaprakAnaliz.BackColor = Color.FromArgb(20, 25, 40);
            btnYaprakAnaliz.FlatAppearance.BorderSize = 0;
            btnYaprakAnaliz.FlatStyle = FlatStyle.Flat;
            btnYaprakAnaliz.Font = new Font("Segoe UI", 11F);
            btnYaprakAnaliz.ForeColor = Color.White;
            btnYaprakAnaliz.Location = new Point(0, 205);
            btnYaprakAnaliz.Name = "btnYaprakAnaliz";
            btnYaprakAnaliz.Padding = new Padding(20, 0, 0, 0);
            btnYaprakAnaliz.Size = new Size(260, 50);
            btnYaprakAnaliz.TabIndex = 2;
            btnYaprakAnaliz.Text = "🍃  Yaprak Analizi";
            btnYaprakAnaliz.TextAlign = ContentAlignment.MiddleLeft;
            btnYaprakAnaliz.UseVisualStyleBackColor = false;
            btnYaprakAnaliz.Click += btnYaprakAnaliz_Click;
            // 
            // btnSuAnaliz
            // 
            btnSuAnaliz.BackColor = Color.FromArgb(20, 25, 40);
            btnSuAnaliz.FlatAppearance.BorderSize = 0;
            btnSuAnaliz.FlatStyle = FlatStyle.Flat;
            btnSuAnaliz.Font = new Font("Segoe UI", 11F);
            btnSuAnaliz.ForeColor = Color.White;
            btnSuAnaliz.Location = new Point(0, 260);
            btnSuAnaliz.Name = "btnSuAnaliz";
            btnSuAnaliz.Padding = new Padding(20, 0, 0, 0);
            btnSuAnaliz.Size = new Size(260, 50);
            btnSuAnaliz.TabIndex = 3;
            btnSuAnaliz.Text = "💧  Su Analizi";
            btnSuAnaliz.TextAlign = ContentAlignment.MiddleLeft;
            btnSuAnaliz.UseVisualStyleBackColor = false;
            btnSuAnaliz.Click += btnSuAnaliz_Click;
            // 
            // btnHakkinda
            // 
            btnHakkinda.BackColor = Color.FromArgb(20, 25, 40);
            btnHakkinda.FlatAppearance.BorderSize = 0;
            btnHakkinda.FlatStyle = FlatStyle.Flat;
            btnHakkinda.Font = new Font("Segoe UI", 11F);
            btnHakkinda.ForeColor = Color.White;
            btnHakkinda.Location = new Point(3, 484);
            btnHakkinda.Name = "btnHakkinda";
            btnHakkinda.Padding = new Padding(20, 0, 0, 0);
            btnHakkinda.Size = new Size(260, 50);
            btnHakkinda.TabIndex = 4;
            btnHakkinda.Text = "☪︎ ִ Hakkında";
            btnHakkinda.TextAlign = ContentAlignment.MiddleLeft;
            btnHakkinda.UseVisualStyleBackColor = false;
            btnHakkinda.Click += btnHakkinda_Click;
            // 
            // btnOtomasyon
            // 
            btnOtomasyon.BackColor = Color.FromArgb(20, 25, 40);
            btnOtomasyon.FlatAppearance.BorderSize = 0;
            btnOtomasyon.FlatStyle = FlatStyle.Flat;
            btnOtomasyon.Font = new Font("Segoe UI", 11F);
            btnOtomasyon.ForeColor = Color.White;
            btnOtomasyon.Location = new Point(3, 316);
            btnOtomasyon.Name = "btnOtomasyon";
            btnOtomasyon.Padding = new Padding(20, 0, 0, 0);
            btnOtomasyon.Size = new Size(260, 50);
            btnOtomasyon.TabIndex = 5;
            btnOtomasyon.Text = "⚙️  Otomasyon";
            btnOtomasyon.TextAlign = ContentAlignment.MiddleLeft;
            btnOtomasyon.UseVisualStyleBackColor = false;
            btnOtomasyon.Click += btnOtomasyon_Click;
            // 
            // btnRaporlar
            // 
            btnRaporlar.BackColor = Color.FromArgb(20, 25, 40);
            btnRaporlar.FlatAppearance.BorderSize = 0;
            btnRaporlar.FlatStyle = FlatStyle.Flat;
            btnRaporlar.Font = new Font("Segoe UI", 11F);
            btnRaporlar.ForeColor = Color.White;
            btnRaporlar.Location = new Point(3, 372);
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.Padding = new Padding(20, 0, 0, 0);
            btnRaporlar.Size = new Size(260, 50);
            btnRaporlar.TabIndex = 6;
            btnRaporlar.Text = "📋  Raporlar";
            btnRaporlar.TextAlign = ContentAlignment.MiddleLeft;
            btnRaporlar.UseVisualStyleBackColor = false;
            btnRaporlar.Click += btnRaporlar_Click;
            // 
            // btnTarlalarim
            // 
            btnTarlalarim.BackColor = Color.FromArgb(20, 25, 40);
            btnTarlalarim.FlatAppearance.BorderSize = 0;
            btnTarlalarim.FlatStyle = FlatStyle.Flat;
            btnTarlalarim.Font = new Font("Segoe UI", 11F);
            btnTarlalarim.ForeColor = Color.White;
            btnTarlalarim.Location = new Point(3, 428);
            btnTarlalarim.Name = "btnTarlalarim";
            btnTarlalarim.Padding = new Padding(20, 0, 0, 0);
            btnTarlalarim.Size = new Size(260, 50);
            btnTarlalarim.TabIndex = 7;
            btnTarlalarim.Text = "🗺️  Tarlalarım";
            btnTarlalarim.TextAlign = ContentAlignment.MiddleLeft;
            btnTarlalarim.UseVisualStyleBackColor = false;
            btnTarlalarim.Click += btnTarlalarim_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(26, 32, 48);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(btnMinimize);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(260, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(990, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(46, 204, 113);
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(232, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Akıllı Tarım Sistemi";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Right;
            lblUser.ForeColor = Color.LightGray;
            lblUser.Location = new Point(650, 20);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(230, 20);
            lblUser.TabIndex = 1;
            lblUser.Text = "Hoş Geldiniz";
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(945, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(905, 12);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(35, 35);
            btnMinimize.TabIndex = 3;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(34, 42, 64);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(260, 60);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(990, 790);
            pnlContainer.TabIndex = 2;
            // 
            // AnaForm
            // 
            BackColor = Color.FromArgb(34, 42, 64);
            ClientSize = new Size(1250, 850);
            Controls.Add(pnlContainer);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AnaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Akıllı Tarım Yönetim Sistemi";
            Load += AnaForm_Load;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnToprakAnaliz;
        private System.Windows.Forms.Button btnYaprakAnaliz;
        private System.Windows.Forms.Button btnSuAnaliz;
        private System.Windows.Forms.Button btnOtomasyon;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnTarlalarim;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel pnlContainer;
        private Button btnHakkinda;
    }
}