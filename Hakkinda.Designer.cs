namespace AkilliTarimSistemi.UI
{
    partial class Hakkinda
    {
        private System.ComponentModel.IContainer components = null;

        // Tüm kontrolleri tanımla
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlIcon;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblDeveloperName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlTechStack;
        private System.Windows.Forms.Label lblTechTitle;
        private System.Windows.Forms.FlowLayoutPanel flpTech;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailValue;
        private System.Windows.Forms.Panel pnlSocial;
        private System.Windows.Forms.Label lblSocialTitle;
        private System.Windows.Forms.Label lblFacebook;
        private System.Windows.Forms.Label lblFacebookValue;
        private System.Windows.Forms.Label lblInstagram;
        private System.Windows.Forms.Label lblInstagramValue;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hakkinda));
            pnlMain = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            lblSlogan = new Label();
            pnlBorder = new Panel();
            pnlIcon = new Panel();
            lblIcon = new Label();
            lblVersion = new Label();
            lblDeveloper = new Label();
            lblDeveloperName = new Label();
            lblDescription = new Label();
            txtDescription = new TextBox();
            pnlTechStack = new Panel();
            lblTechTitle = new Label();
            flpTech = new FlowLayoutPanel();
            btnClose = new Button();
            lblCopyright = new Label();
            lblEmail = new Label();
            lblEmailValue = new Label();
            pnlSocial = new Panel();
            lblSocialTitle = new Label();
            lblFacebook = new Label();
            lblFacebookValue = new Label();
            lblInstagram = new Label();
            lblInstagramValue = new Label();
            pnlMain.SuspendLayout();
            pnlIcon.SuspendLayout();
            pnlTechStack.SuspendLayout();
            pnlSocial.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(20, 20, 35);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblSubTitle);
            pnlMain.Controls.Add(lblSlogan);
            pnlMain.Controls.Add(pnlBorder);
            pnlMain.Controls.Add(pnlIcon);
            pnlMain.Controls.Add(lblVersion);
            pnlMain.Controls.Add(lblDeveloper);
            pnlMain.Controls.Add(lblDeveloperName);
            pnlMain.Controls.Add(lblDescription);
            pnlMain.Controls.Add(txtDescription);
            pnlMain.Controls.Add(pnlTechStack);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(lblCopyright);
            pnlMain.Controls.Add(lblEmail);
            pnlMain.Controls.Add(lblEmailValue);
            pnlMain.Controls.Add(pnlSocial);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(728, 737);
            pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 255, 255);
            lblTitle.Location = new Point(120, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(520, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🌾 Akıllı Tarım Sistemi";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            lblSubTitle.ForeColor = Color.FromArgb(150, 150, 200);
            lblSubTitle.Location = new Point(125, 95);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(278, 28);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Smart Agricultural System v1.0";
            // 
            // lblSlogan
            // 
            lblSlogan.AutoSize = true;
            lblSlogan.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSlogan.ForeColor = Color.FromArgb(0, 255, 150);
            lblSlogan.Location = new Point(125, 125);
            lblSlogan.Name = "lblSlogan";
            lblSlogan.Size = new Size(573, 25);
            lblSlogan.TabIndex = 2;
            lblSlogan.Text = "\"Geleceği Toprakla Buluşturan Teknoloji, Akıllı Tarım ile Yeşerir\"";
            // 
            // pnlBorder
            // 
            pnlBorder.BackColor = Color.FromArgb(0, 255, 255);
            pnlBorder.Location = new Point(30, 160);
            pnlBorder.Name = "pnlBorder";
            pnlBorder.Size = new Size(640, 2);
            pnlBorder.TabIndex = 3;
            // 
            // pnlIcon
            // 
            pnlIcon.BackColor = Color.FromArgb(0, 80, 80);
            pnlIcon.Controls.Add(lblIcon);
            pnlIcon.Location = new Point(30, 30);
            pnlIcon.Name = "pnlIcon";
            pnlIcon.Size = new Size(80, 80);
            pnlIcon.TabIndex = 4;
            // 
            // lblIcon
            // 
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI", 48F);
            lblIcon.Location = new Point(10, 5);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(155, 106);
            lblIcon.TabIndex = 5;
            lblIcon.Text = "🚜";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 10F);
            lblVersion.ForeColor = Color.FromArgb(0, 200, 200);
            lblVersion.Location = new Point(580, 95);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(66, 23);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "v1.0.0.0";
            // 
            // lblDeveloper
            // 
            lblDeveloper.AutoSize = true;
            lblDeveloper.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeveloper.ForeColor = Color.White;
            lblDeveloper.Location = new Point(30, 190);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(141, 28);
            lblDeveloper.TabIndex = 7;
            lblDeveloper.Text = "👨‍💻 Geliştirici:";
            // 
            // lblDeveloperName
            // 
            lblDeveloperName.AutoSize = true;
            lblDeveloperName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDeveloperName.ForeColor = Color.FromArgb(0, 255, 200);
            lblDeveloperName.Location = new Point(180, 188);
            lblDeveloperName.Name = "lblDeveloperName";
            lblDeveloperName.Size = new Size(210, 32);
            lblDeveloperName.TabIndex = 8;
            lblDeveloperName.Text = "Oğuz Kaan FIRAT";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDescription.ForeColor = Color.White;
            lblDescription.Location = new Point(30, 240);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(222, 28);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "📋 Sistem Açıklaması:";
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.FromArgb(25, 25, 40);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.ForeColor = Color.FromArgb(200, 200, 220);
            txtDescription.Location = new Point(35, 275);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ReadOnly = true;
            txtDescription.Size = new Size(630, 90);
            txtDescription.TabIndex = 10;
            txtDescription.Text = resources.GetString("txtDescription.Text");
            // 
            // pnlTechStack
            // 
            pnlTechStack.Controls.Add(lblTechTitle);
            pnlTechStack.Controls.Add(flpTech);
            pnlTechStack.Location = new Point(30, 380);
            pnlTechStack.Name = "pnlTechStack";
            pnlTechStack.Size = new Size(635, 95);
            pnlTechStack.TabIndex = 11;
            // 
            // lblTechTitle
            // 
            lblTechTitle.AutoSize = true;
            lblTechTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTechTitle.ForeColor = Color.White;
            lblTechTitle.Location = new Point(5, 5);
            lblTechTitle.Name = "lblTechTitle";
            lblTechTitle.Size = new Size(149, 25);
            lblTechTitle.TabIndex = 12;
            lblTechTitle.Text = "🛠️ Teknolojiler:";
            // 
            // flpTech
            // 
            flpTech.FlowDirection = FlowDirection.TopDown;
            flpTech.Location = new Point(5, 35);
            flpTech.Name = "flpTech";
            flpTech.Size = new Size(625, 147);
            flpTech.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(0, 120, 120);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(253, 652);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 45);
            btnClose.TabIndex = 13;
            btnClose.Text = "Kapat";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Font = new Font("Segoe UI", 9F);
            lblCopyright.ForeColor = Color.FromArgb(100, 100, 150);
            lblCopyright.Location = new Point(168, 702);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(317, 20);
            lblCopyright.TabIndex = 14;
            lblCopyright.Text = "© 2026 Her Hakkı Saklıdır | Akıllı Tarım Sistemi";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(37, 565);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(103, 23);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "📧 İletişim:";
            // 
            // lblEmailValue
            // 
            lblEmailValue.AutoSize = true;
            lblEmailValue.Font = new Font("Segoe UI", 10F);
            lblEmailValue.ForeColor = Color.FromArgb(0, 200, 200);
            lblEmailValue.Location = new Point(146, 564);
            lblEmailValue.Name = "lblEmailValue";
            lblEmailValue.Size = new Size(257, 23);
            lblEmailValue.TabIndex = 16;
            lblEmailValue.Text = "oguzkaanfirat@windowslive.com";
            // 
            // pnlSocial
            // 
            pnlSocial.Controls.Add(lblSocialTitle);
            pnlSocial.Controls.Add(lblFacebook);
            pnlSocial.Controls.Add(lblFacebookValue);
            pnlSocial.Controls.Add(lblInstagram);
            pnlSocial.Controls.Add(lblInstagramValue);
            pnlSocial.Location = new Point(37, 590);
            pnlSocial.Name = "pnlSocial";
            pnlSocial.Size = new Size(635, 65);
            pnlSocial.TabIndex = 17;
            // 
            // lblSocialTitle
            // 
            lblSocialTitle.AutoSize = true;
            lblSocialTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSocialTitle.ForeColor = Color.White;
            lblSocialTitle.Location = new Point(0, 0);
            lblSocialTitle.Name = "lblSocialTitle";
            lblSocialTitle.Size = new Size(165, 25);
            lblSocialTitle.TabIndex = 18;
            lblSocialTitle.Text = "🌐 Sosyal Medya:";
            // 
            // lblFacebook
            // 
            lblFacebook.AutoSize = true;
            lblFacebook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFacebook.ForeColor = Color.White;
            lblFacebook.Location = new Point(0, 30);
            lblFacebook.Name = "lblFacebook";
            lblFacebook.Size = new Size(120, 23);
            lblFacebook.TabIndex = 19;
            lblFacebook.Text = "📘 Facebook:";
            // 
            // lblFacebookValue
            // 
            lblFacebookValue.AutoSize = true;
            lblFacebookValue.Font = new Font("Segoe UI", 10F);
            lblFacebookValue.ForeColor = Color.FromArgb(0, 200, 200);
            lblFacebookValue.Location = new Point(126, 30);
            lblFacebookValue.Name = "lblFacebookValue";
            lblFacebookValue.Size = new Size(71, 23);
            lblFacebookValue.TabIndex = 20;
            lblFacebookValue.Text = "@kagnx";
            // 
            // lblInstagram
            // 
            lblInstagram.AutoSize = true;
            lblInstagram.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInstagram.ForeColor = Color.White;
            lblInstagram.Location = new Point(261, 27);
            lblInstagram.Name = "lblInstagram";
            lblInstagram.Size = new Size(125, 23);
            lblInstagram.TabIndex = 21;
            lblInstagram.Text = "📷 Instagram:";
            // 
            // lblInstagramValue
            // 
            lblInstagramValue.AutoSize = true;
            lblInstagramValue.Font = new Font("Segoe UI", 10F);
            lblInstagramValue.ForeColor = Color.FromArgb(0, 200, 200);
            lblInstagramValue.Location = new Point(392, 27);
            lblInstagramValue.Name = "lblInstagramValue";
            lblInstagramValue.Size = new Size(71, 23);
            lblInstagramValue.TabIndex = 22;
            lblInstagramValue.Text = "@kagnx";
            // 
            // Hakkinda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 25);
            ClientSize = new Size(728, 737);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Hakkinda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hakkında - Akıllı Tarım Sistemi";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlIcon.ResumeLayout(false);
            pnlIcon.PerformLayout();
            pnlTechStack.ResumeLayout(false);
            pnlTechStack.PerformLayout();
            pnlSocial.ResumeLayout(false);
            pnlSocial.PerformLayout();
            ResumeLayout(false);

        }
    }
}