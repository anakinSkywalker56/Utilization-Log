namespace C7
{
    partial class LoadingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDots;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Panel pnlConnBanner;
        private System.Windows.Forms.Label lblConnBanner;
        private System.Windows.Forms.Label lblVersion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblPercent = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDots = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlConnBanner = new System.Windows.Forms.Panel();
            this.lblConnBanner = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.pnlConnBanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(411, 104);
            this.pnlHeader.TabIndex = 2;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(353, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(41, 42);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 35);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "CompLab Utilization Log";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblSubtitle.Location = new System.Drawing.Point(15, 54);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(377, 19);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Computer Laboratory System";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.lblPercent);
            this.pnlBody.Controls.Add(this.progressBar);
            this.pnlBody.Controls.Add(this.lblStatus);
            this.pnlBody.Controls.Add(this.lblDots);
            this.pnlBody.Controls.Add(this.lblVersion);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 135);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(26, 21, 26, 17);
            this.pnlBody.Size = new System.Drawing.Size(411, 142);
            this.pnlBody.TabIndex = 0;
            // 
            // lblPercent
            // 
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPercent.ForeColor = System.Drawing.Color.Gray;
            this.lblPercent.Location = new System.Drawing.Point(358, 52);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(31, 19);
            this.lblPercent.TabIndex = 0;
            this.lblPercent.Text = "0%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.progressBar.Location = new System.Drawing.Point(26, 49);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(360, 19);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStatus.Location = new System.Drawing.Point(26, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(300, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Initializing…";
            // 
            // lblDots
            // 
            this.lblDots.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(200)))));
            this.lblDots.Location = new System.Drawing.Point(324, 16);
            this.lblDots.Name = "lblDots";
            this.lblDots.Size = new System.Drawing.Size(34, 21);
            this.lblDots.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblVersion.ForeColor = System.Drawing.Color.LightGray;
            this.lblVersion.Location = new System.Drawing.Point(26, 87);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(360, 14);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "v1.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlConnBanner
            // 
            this.pnlConnBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlConnBanner.Controls.Add(this.lblConnBanner);
            this.pnlConnBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnBanner.Location = new System.Drawing.Point(0, 104);
            this.pnlConnBanner.Name = "pnlConnBanner";
            this.pnlConnBanner.Size = new System.Drawing.Size(411, 31);
            this.pnlConnBanner.TabIndex = 1;
            this.pnlConnBanner.Visible = false;
            // 
            // lblConnBanner
            // 
            this.lblConnBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConnBanner.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblConnBanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(77)))), ((int)(((byte)(14)))));
            this.lblConnBanner.Location = new System.Drawing.Point(0, 0);
            this.lblConnBanner.Name = "lblConnBanner";
            this.lblConnBanner.Size = new System.Drawing.Size(411, 31);
            this.lblConnBanner.TabIndex = 0;
            this.lblConnBanner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 277);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlConnBanner);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompLab Utilization Log";
            this.Load += new System.EventHandler(this.LoadingForm_Load);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlConnBanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}