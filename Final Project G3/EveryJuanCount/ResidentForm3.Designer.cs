namespace EveryJuanCount
{
    partial class ResidentForm3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResidentForm3));
            pnSlideMenu = new Panel();
            btLogOut = new Button();
            panel1 = new Panel();
            pnButtons = new Panel();
            panel7 = new Panel();
            btReportHistory = new Button();
            panel6 = new Panel();
            btSubmitReport = new Button();
            panel5 = new Panel();
            btMyProfile = new Button();
            panel10 = new Panel();
            btDashboard = new Button();
            panelLogo = new Panel();
            panel9 = new Panel();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            p1top = new Panel();
            btMenuVertical = new PictureBox();
            panel3 = new Panel();
            Lb32026 = new Label();
            BrgyLb1 = new Label();
            CenSyLb2 = new Label();
            pnChilForms = new Panel();
            pbLogo = new PictureBox();
            pnSlideMenu.SuspendLayout();
            panel1.SuspendLayout();
            pnButtons.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            p1top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btMenuVertical).BeginInit();
            pnChilForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pnSlideMenu
            // 
            pnSlideMenu.AutoScroll = true;
            pnSlideMenu.BackColor = Color.FromArgb(0, 0, 64);
            pnSlideMenu.Controls.Add(btLogOut);
            pnSlideMenu.Controls.Add(panel1);
            pnSlideMenu.Controls.Add(panelLogo);
            pnSlideMenu.Dock = DockStyle.Left;
            pnSlideMenu.Location = new Point(0, 0);
            pnSlideMenu.Name = "pnSlideMenu";
            pnSlideMenu.Size = new Size(330, 794);
            pnSlideMenu.TabIndex = 0;
            // 
            // btLogOut
            // 
            btLogOut.Dock = DockStyle.Bottom;
            btLogOut.FlatAppearance.BorderSize = 0;
            btLogOut.FlatAppearance.MouseDownBackColor = Color.Red;
            btLogOut.FlatAppearance.MouseOverBackColor = Color.Red;
            btLogOut.FlatStyle = FlatStyle.Flat;
            btLogOut.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btLogOut.ForeColor = SystemColors.ControlLightLight;
            btLogOut.Image = (Image)resources.GetObject("btLogOut.Image");
            btLogOut.ImageAlign = ContentAlignment.MiddleLeft;
            btLogOut.Location = new Point(0, 752);
            btLogOut.Name = "btLogOut";
            btLogOut.Padding = new Padding(50, 5, 0, 10);
            btLogOut.Size = new Size(330, 42);
            btLogOut.TabIndex = 12;
            btLogOut.Text = "          LOG OUT";
            btLogOut.TextAlign = ContentAlignment.MiddleLeft;
            btLogOut.UseVisualStyleBackColor = true;
            btLogOut.Click += btLogOut_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(pnButtons);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 389);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 362);
            panel1.TabIndex = 1;
            // 
            // pnButtons
            // 
            pnButtons.Controls.Add(panel7);
            pnButtons.Controls.Add(btReportHistory);
            pnButtons.Controls.Add(panel6);
            pnButtons.Controls.Add(btSubmitReport);
            pnButtons.Controls.Add(panel5);
            pnButtons.Controls.Add(btMyProfile);
            pnButtons.Controls.Add(panel10);
            pnButtons.Controls.Add(btDashboard);
            pnButtons.Dock = DockStyle.Top;
            pnButtons.Location = new Point(0, 0);
            pnButtons.Name = "pnButtons";
            pnButtons.Padding = new Padding(50, 0, 0, 0);
            pnButtons.Size = new Size(330, 329);
            pnButtons.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(50, 268);
            panel7.Name = "panel7";
            panel7.Size = new Size(280, 36);
            panel7.TabIndex = 18;
            // 
            // btReportHistory
            // 
            btReportHistory.Dock = DockStyle.Top;
            btReportHistory.FlatAppearance.BorderSize = 0;
            btReportHistory.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btReportHistory.FlatAppearance.MouseOverBackColor = Color.Gold;
            btReportHistory.FlatStyle = FlatStyle.Flat;
            btReportHistory.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btReportHistory.ForeColor = SystemColors.ControlLightLight;
            btReportHistory.Image = Properties.Resources.Report_History;
            btReportHistory.ImageAlign = ContentAlignment.MiddleLeft;
            btReportHistory.Location = new Point(50, 228);
            btReportHistory.Name = "btReportHistory";
            btReportHistory.Size = new Size(280, 40);
            btReportHistory.TabIndex = 17;
            btReportHistory.Text = "          REPORT HISTORY";
            btReportHistory.TextAlign = ContentAlignment.MiddleLeft;
            btReportHistory.UseVisualStyleBackColor = true;
            btReportHistory.Click += btReportHistory_Click;
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(50, 192);
            panel6.Name = "panel6";
            panel6.Size = new Size(280, 36);
            panel6.TabIndex = 16;
            // 
            // btSubmitReport
            // 
            btSubmitReport.Dock = DockStyle.Top;
            btSubmitReport.FlatAppearance.BorderSize = 0;
            btSubmitReport.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btSubmitReport.FlatAppearance.MouseOverBackColor = Color.Gold;
            btSubmitReport.FlatStyle = FlatStyle.Flat;
            btSubmitReport.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btSubmitReport.ForeColor = SystemColors.ControlLightLight;
            btSubmitReport.Image = Properties.Resources.Submit_Report;
            btSubmitReport.ImageAlign = ContentAlignment.MiddleLeft;
            btSubmitReport.Location = new Point(50, 152);
            btSubmitReport.Name = "btSubmitReport";
            btSubmitReport.Size = new Size(280, 40);
            btSubmitReport.TabIndex = 15;
            btSubmitReport.Text = "          SUBMIT REPORT";
            btSubmitReport.TextAlign = ContentAlignment.MiddleLeft;
            btSubmitReport.UseVisualStyleBackColor = true;
            btSubmitReport.Click += btSubmitReport_Click;
            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(50, 116);
            panel5.Name = "panel5";
            panel5.Size = new Size(280, 36);
            panel5.TabIndex = 14;
            // 
            // btMyProfile
            // 
            btMyProfile.Dock = DockStyle.Top;
            btMyProfile.FlatAppearance.BorderSize = 0;
            btMyProfile.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btMyProfile.FlatAppearance.MouseOverBackColor = Color.Gold;
            btMyProfile.FlatStyle = FlatStyle.Flat;
            btMyProfile.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btMyProfile.ForeColor = SystemColors.ControlLightLight;
            btMyProfile.Image = Properties.Resources.My_Profile;
            btMyProfile.ImageAlign = ContentAlignment.MiddleLeft;
            btMyProfile.Location = new Point(50, 76);
            btMyProfile.Name = "btMyProfile";
            btMyProfile.Size = new Size(280, 40);
            btMyProfile.TabIndex = 13;
            btMyProfile.Text = "          MY PROFILE";
            btMyProfile.TextAlign = ContentAlignment.MiddleLeft;
            btMyProfile.UseVisualStyleBackColor = true;
            btMyProfile.Click += btMyProfile_Click;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(50, 40);
            panel10.Name = "panel10";
            panel10.Size = new Size(280, 36);
            panel10.TabIndex = 12;
            // 
            // btDashboard
            // 
            btDashboard.Dock = DockStyle.Top;
            btDashboard.FlatAppearance.BorderSize = 0;
            btDashboard.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btDashboard.FlatAppearance.MouseOverBackColor = Color.Gold;
            btDashboard.FlatStyle = FlatStyle.Flat;
            btDashboard.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btDashboard.ForeColor = SystemColors.ControlLightLight;
            btDashboard.Image = Properties.Resources.dash;
            btDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btDashboard.Location = new Point(50, 0);
            btDashboard.Name = "btDashboard";
            btDashboard.Size = new Size(280, 40);
            btDashboard.TabIndex = 6;
            btDashboard.Text = "          DASHBOARD";
            btDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btDashboard.UseVisualStyleBackColor = true;
            btDashboard.Click += btDashboard_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(panel9);
            panelLogo.Controls.Add(pictureBox4);
            panelLogo.Controls.Add(pictureBox3);
            panelLogo.Controls.Add(pictureBox2);
            panelLogo.Controls.Add(pictureBox1);
            panelLogo.Controls.Add(p1top);
            panelLogo.Controls.Add(panel3);
            panelLogo.Controls.Add(Lb32026);
            panelLogo.Controls.Add(BrgyLb1);
            panelLogo.Controls.Add(CenSyLb2);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(330, 389);
            panelLogo.TabIndex = 0;
            // 
            // panel9
            // 
            panel9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel9.Location = new Point(0, 372);
            panel9.Name = "panel9";
            panel9.Size = new Size(330, 17);
            panel9.TabIndex = 16;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.None;
            pictureBox4.Image = Properties.Resources.Stars;
            pictureBox4.Location = new Point(105, 200);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(46, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.Stars;
            pictureBox3.Location = new Point(176, 200);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(46, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.Stars;
            pictureBox2.Location = new Point(135, 200);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(59, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.EJC_Logo;
            pictureBox1.Location = new Point(0, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(330, 169);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // p1top
            // 
            p1top.Controls.Add(btMenuVertical);
            p1top.Dock = DockStyle.Top;
            p1top.Location = new Point(0, 0);
            p1top.Name = "p1top";
            p1top.Size = new Size(330, 37);
            p1top.TabIndex = 1;
            // 
            // btMenuVertical
            // 
            btMenuVertical.Dock = DockStyle.Left;
            btMenuVertical.Image = Properties.Resources.Menu;
            btMenuVertical.Location = new Point(0, 0);
            btMenuVertical.Name = "btMenuVertical";
            btMenuVertical.Size = new Size(45, 37);
            btMenuVertical.SizeMode = PictureBoxSizeMode.Zoom;
            btMenuVertical.TabIndex = 1;
            btMenuVertical.TabStop = false;
            btMenuVertical.Click += btMenuVertical_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = Color.Goldenrod;
            panel3.ForeColor = Color.Goldenrod;
            panel3.Location = new Point(133, 352);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(65, 4);
            panel3.TabIndex = 15;
            // 
            // Lb32026
            // 
            Lb32026.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Lb32026.AutoSize = true;
            Lb32026.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lb32026.ForeColor = SystemColors.AppWorkspace;
            Lb32026.Location = new Point(130, 325);
            Lb32026.Name = "Lb32026";
            Lb32026.Size = new Size(71, 22);
            Lb32026.TabIndex = 14;
            Lb32026.Text = "Resident";
            // 
            // BrgyLb1
            // 
            BrgyLb1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BrgyLb1.AutoSize = true;
            BrgyLb1.Font = new Font("Arial Black", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BrgyLb1.ForeColor = Color.Goldenrod;
            BrgyLb1.Location = new Point(120, 274);
            BrgyLb1.Name = "BrgyLb1";
            BrgyLb1.Size = new Size(89, 18);
            BrgyLb1.TabIndex = 13;
            BrgyLb1.Text = "BARANGAY";
            // 
            // CenSyLb2
            // 
            CenSyLb2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CenSyLb2.AutoSize = true;
            CenSyLb2.Font = new Font("Arial Black", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CenSyLb2.ForeColor = Color.Goldenrod;
            CenSyLb2.Location = new Point(99, 298);
            CenSyLb2.Name = "CenSyLb2";
            CenSyLb2.Size = new Size(132, 18);
            CenSyLb2.TabIndex = 12;
            CenSyLb2.Text = "CENSUS SYSTEM ";
            // 
            // pnChilForms
            // 
            pnChilForms.AutoScroll = true;
            pnChilForms.BackColor = Color.MidnightBlue;
            pnChilForms.Controls.Add(pbLogo);
            pnChilForms.Dock = DockStyle.Fill;
            pnChilForms.Location = new Point(330, 0);
            pnChilForms.Name = "pnChilForms";
            pnChilForms.Size = new Size(1015, 794);
            pnChilForms.TabIndex = 2;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = Properties.Resources.EJC_Logo;
            pbLogo.Location = new Point(101, 158);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(812, 478);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // ResidentForm3
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1345, 794);
            Controls.Add(pnChilForms);
            Controls.Add(pnSlideMenu);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ResidentForm3";
            StartPosition = FormStartPosition.CenterScreen;
            pnSlideMenu.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnButtons.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            p1top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btMenuVertical).EndInit();
            pnChilForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnSlideMenu;
        private Panel panelLogo;
        private Panel panel3;
        private Label Lb32026;
        private Label CenSyLb2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Label BrgyLb1;
        private Panel panel1;
        private Panel p1top;
        private Button btDashboard;
        private PictureBox pictureBox1;
        private Panel pnButtons;
        private Button btLogOut;
        private Panel panel10;
        private Panel panel7;
        private Button btReportHistory;
        private Panel panel6;
        private Button btSubmitReport;
        private Panel panel5;
        private Button btMyProfile;
        private Panel panel9;
        private Panel pnChilForms;
        private PictureBox pbLogo;
        private PictureBox btMenuVertical;
    }
}