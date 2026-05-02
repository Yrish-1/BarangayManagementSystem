namespace EveryJuanCount
{
    partial class ResidentsForm3
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResidentsForm3));
            panel1 = new Panel();
            lb1ResDash_ResF = new Label();
            btHam_ResF = new PictureBox();
            nightCB1_ResF = new ReaLTaiizor.Controls.NightControlBox();
            sidebar = new FlowLayoutPanel();
            panel3 = new Panel();
            pl2Dashboard_ResF = new Panel();
            bt1Dashboard_ResF = new Button();
            pl3MyPrrofile_ResF = new Panel();
            bt2MyProfile_ResF = new Button();
            pl4SubmitRep_ResF = new Panel();
            bt3SubmitRep_ResF = new Button();
            pl5RepHistory_ResF = new Panel();
            bt4SubmitRep_ResF = new Button();
            panel4 = new Panel();
            pl6ChangePass_ResF = new Panel();
            bt5ChangePass_ResF = new Button();
            panel5 = new Panel();
            bt6LogOut_ResF = new Button();
            panel2 = new Panel();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btHam_ResF).BeginInit();
            sidebar.SuspendLayout();
            pl2Dashboard_ResF.SuspendLayout();
            pl3MyPrrofile_ResF.SuspendLayout();
            pl4SubmitRep_ResF.SuspendLayout();
            pl5RepHistory_ResF.SuspendLayout();
            pl6ChangePass_ResF.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(lb1ResDash_ResF);
            panel1.Controls.Add(btHam_ResF);
            panel1.Controls.Add(nightCB1_ResF);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 56);
            panel1.TabIndex = 0;
            // 
            // lb1ResDash_ResF
            // 
            lb1ResDash_ResF.AutoSize = true;
            lb1ResDash_ResF.BackColor = Color.Transparent;
            lb1ResDash_ResF.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb1ResDash_ResF.ForeColor = SystemColors.Control;
            lb1ResDash_ResF.Location = new Point(66, 17);
            lb1ResDash_ResF.Name = "lb1ResDash_ResF";
            lb1ResDash_ResF.Size = new Size(215, 24);
            lb1ResDash_ResF.TabIndex = 2;
            lb1ResDash_ResF.Text = "RESIDENTS DASHBOARD";
            // 
            // btHam_ResF
            // 
            btHam_ResF.Image = Properties.Resources.Menu;
            btHam_ResF.Location = new Point(9, 10);
            btHam_ResF.Name = "btHam_ResF";
            btHam_ResF.Size = new Size(51, 37);
            btHam_ResF.SizeMode = PictureBoxSizeMode.Zoom;
            btHam_ResF.TabIndex = 1;
            btHam_ResF.TabStop = false;
            btHam_ResF.Click += btHam_ResF_Click;
            // 
            // nightCB1_ResF
            // 
            nightCB1_ResF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nightCB1_ResF.BackColor = Color.Transparent;
            nightCB1_ResF.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightCB1_ResF.CloseHoverForeColor = Color.White;
            nightCB1_ResF.DefaultLocation = true;
            nightCB1_ResF.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightCB1_ResF.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightCB1_ResF.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightCB1_ResF.EnableMaximizeButton = true;
            nightCB1_ResF.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightCB1_ResF.EnableMinimizeButton = true;
            nightCB1_ResF.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightCB1_ResF.Location = new Point(1143, 0);
            nightCB1_ResF.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightCB1_ResF.MaximizeHoverForeColor = Color.White;
            nightCB1_ResF.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightCB1_ResF.MinimizeHoverForeColor = Color.White;
            nightCB1_ResF.Name = "nightCB1_ResF";
            nightCB1_ResF.Size = new Size(139, 31);
            nightCB1_ResF.TabIndex = 0;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.MidnightBlue;
            sidebar.Controls.Add(panel3);
            sidebar.Controls.Add(pl2Dashboard_ResF);
            sidebar.Controls.Add(pl3MyPrrofile_ResF);
            sidebar.Controls.Add(pl4SubmitRep_ResF);
            sidebar.Controls.Add(pl5RepHistory_ResF);
            sidebar.Controls.Add(panel4);
            sidebar.Controls.Add(pl6ChangePass_ResF);
            sidebar.Controls.Add(panel5);
            sidebar.Controls.Add(bt6LogOut_ResF);
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new Point(3, 56);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(66, 620);
            sidebar.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(259, 10);
            panel3.TabIndex = 7;
            // 
            // pl2Dashboard_ResF
            // 
            pl2Dashboard_ResF.Anchor = AnchorStyles.None;
            pl2Dashboard_ResF.Controls.Add(bt1Dashboard_ResF);
            pl2Dashboard_ResF.Location = new Point(7, 19);
            pl2Dashboard_ResF.Name = "pl2Dashboard_ResF";
            pl2Dashboard_ResF.Size = new Size(250, 54);
            pl2Dashboard_ResF.TabIndex = 3;
            // 
            // bt1Dashboard_ResF
            // 
            bt1Dashboard_ResF.AutoSize = true;
            bt1Dashboard_ResF.BackColor = Color.MidnightBlue;
            bt1Dashboard_ResF.FlatAppearance.BorderSize = 0;
            bt1Dashboard_ResF.FlatStyle = FlatStyle.Flat;
            bt1Dashboard_ResF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt1Dashboard_ResF.ForeColor = SystemColors.Control;
            bt1Dashboard_ResF.Image = (Image)resources.GetObject("bt1Dashboard_ResF.Image");
            bt1Dashboard_ResF.ImageAlign = ContentAlignment.MiddleLeft;
            bt1Dashboard_ResF.Location = new Point(11, -12);
            bt1Dashboard_ResF.Name = "bt1Dashboard_ResF";
            bt1Dashboard_ResF.Size = new Size(251, 74);
            bt1Dashboard_ResF.TabIndex = 2;
            bt1Dashboard_ResF.Text = "         Dashboard";
            bt1Dashboard_ResF.TextAlign = ContentAlignment.MiddleLeft;
            bt1Dashboard_ResF.UseVisualStyleBackColor = true;
            // 
            // pl3MyPrrofile_ResF
            // 
            pl3MyPrrofile_ResF.Anchor = AnchorStyles.None;
            pl3MyPrrofile_ResF.Controls.Add(bt2MyProfile_ResF);
            pl3MyPrrofile_ResF.Location = new Point(7, 79);
            pl3MyPrrofile_ResF.Name = "pl3MyPrrofile_ResF";
            pl3MyPrrofile_ResF.Size = new Size(251, 54);
            pl3MyPrrofile_ResF.TabIndex = 4;
            // 
            // bt2MyProfile_ResF
            // 
            bt2MyProfile_ResF.AutoSize = true;
            bt2MyProfile_ResF.BackColor = Color.MidnightBlue;
            bt2MyProfile_ResF.FlatAppearance.BorderSize = 0;
            bt2MyProfile_ResF.FlatStyle = FlatStyle.Flat;
            bt2MyProfile_ResF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt2MyProfile_ResF.ForeColor = SystemColors.Control;
            bt2MyProfile_ResF.Image = (Image)resources.GetObject("bt2MyProfile_ResF.Image");
            bt2MyProfile_ResF.ImageAlign = ContentAlignment.MiddleLeft;
            bt2MyProfile_ResF.Location = new Point(11, -10);
            bt2MyProfile_ResF.Name = "bt2MyProfile_ResF";
            bt2MyProfile_ResF.Size = new Size(251, 74);
            bt2MyProfile_ResF.TabIndex = 2;
            bt2MyProfile_ResF.Text = "         My Profile";
            bt2MyProfile_ResF.TextAlign = ContentAlignment.MiddleLeft;
            bt2MyProfile_ResF.UseVisualStyleBackColor = true;
            // 
            // pl4SubmitRep_ResF
            // 
            pl4SubmitRep_ResF.Anchor = AnchorStyles.None;
            pl4SubmitRep_ResF.Controls.Add(bt3SubmitRep_ResF);
            pl4SubmitRep_ResF.Location = new Point(6, 139);
            pl4SubmitRep_ResF.Name = "pl4SubmitRep_ResF";
            pl4SubmitRep_ResF.Size = new Size(252, 54);
            pl4SubmitRep_ResF.TabIndex = 5;
            // 
            // bt3SubmitRep_ResF
            // 
            bt3SubmitRep_ResF.AutoSize = true;
            bt3SubmitRep_ResF.BackColor = Color.MidnightBlue;
            bt3SubmitRep_ResF.FlatAppearance.BorderSize = 0;
            bt3SubmitRep_ResF.FlatStyle = FlatStyle.Flat;
            bt3SubmitRep_ResF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt3SubmitRep_ResF.ForeColor = SystemColors.Control;
            bt3SubmitRep_ResF.Image = (Image)resources.GetObject("bt3SubmitRep_ResF.Image");
            bt3SubmitRep_ResF.ImageAlign = ContentAlignment.MiddleLeft;
            bt3SubmitRep_ResF.Location = new Point(11, -10);
            bt3SubmitRep_ResF.Name = "bt3SubmitRep_ResF";
            bt3SubmitRep_ResF.Size = new Size(251, 74);
            bt3SubmitRep_ResF.TabIndex = 2;
            bt3SubmitRep_ResF.Text = "         Submit Report";
            bt3SubmitRep_ResF.TextAlign = ContentAlignment.MiddleLeft;
            bt3SubmitRep_ResF.UseVisualStyleBackColor = true;
            // 
            // pl5RepHistory_ResF
            // 
            pl5RepHistory_ResF.Anchor = AnchorStyles.None;
            pl5RepHistory_ResF.Controls.Add(bt4SubmitRep_ResF);
            pl5RepHistory_ResF.Location = new Point(6, 199);
            pl5RepHistory_ResF.Name = "pl5RepHistory_ResF";
            pl5RepHistory_ResF.Size = new Size(252, 54);
            pl5RepHistory_ResF.TabIndex = 6;
            // 
            // bt4SubmitRep_ResF
            // 
            bt4SubmitRep_ResF.AutoSize = true;
            bt4SubmitRep_ResF.BackColor = Color.MidnightBlue;
            bt4SubmitRep_ResF.FlatAppearance.BorderSize = 0;
            bt4SubmitRep_ResF.FlatStyle = FlatStyle.Flat;
            bt4SubmitRep_ResF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt4SubmitRep_ResF.ForeColor = SystemColors.Control;
            bt4SubmitRep_ResF.Image = (Image)resources.GetObject("bt4SubmitRep_ResF.Image");
            bt4SubmitRep_ResF.ImageAlign = ContentAlignment.MiddleLeft;
            bt4SubmitRep_ResF.Location = new Point(11, -9);
            bt4SubmitRep_ResF.Name = "bt4SubmitRep_ResF";
            bt4SubmitRep_ResF.Size = new Size(251, 74);
            bt4SubmitRep_ResF.TabIndex = 2;
            bt4SubmitRep_ResF.Text = "         Report History";
            bt4SubmitRep_ResF.TextAlign = ContentAlignment.MiddleLeft;
            bt4SubmitRep_ResF.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.RoyalBlue;
            panel4.Location = new Point(3, 259);
            panel4.Name = "panel4";
            panel4.Size = new Size(243, 3);
            panel4.TabIndex = 2;
            // 
            // pl6ChangePass_ResF
            // 
            pl6ChangePass_ResF.Anchor = AnchorStyles.None;
            pl6ChangePass_ResF.Controls.Add(bt5ChangePass_ResF);
            pl6ChangePass_ResF.Location = new Point(6, 268);
            pl6ChangePass_ResF.Name = "pl6ChangePass_ResF";
            pl6ChangePass_ResF.Size = new Size(252, 54);
            pl6ChangePass_ResF.TabIndex = 7;
            // 
            // bt5ChangePass_ResF
            // 
            bt5ChangePass_ResF.AutoSize = true;
            bt5ChangePass_ResF.BackColor = Color.MidnightBlue;
            bt5ChangePass_ResF.FlatAppearance.BorderSize = 0;
            bt5ChangePass_ResF.FlatStyle = FlatStyle.Flat;
            bt5ChangePass_ResF.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bt5ChangePass_ResF.ForeColor = SystemColors.Control;
            bt5ChangePass_ResF.Image = (Image)resources.GetObject("bt5ChangePass_ResF.Image");
            bt5ChangePass_ResF.ImageAlign = ContentAlignment.MiddleLeft;
            bt5ChangePass_ResF.Location = new Point(11, -9);
            bt5ChangePass_ResF.Name = "bt5ChangePass_ResF";
            bt5ChangePass_ResF.Size = new Size(251, 74);
            bt5ChangePass_ResF.TabIndex = 2;
            bt5ChangePass_ResF.Text = "         Change Password";
            bt5ChangePass_ResF.TextAlign = ContentAlignment.MiddleLeft;
            bt5ChangePass_ResF.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            panel5.BackColor = Color.MidnightBlue;
            panel5.Location = new Point(3, 328);
            panel5.Name = "panel5";
            panel5.Size = new Size(243, 216);
            panel5.TabIndex = 3;
            // 
            // bt6LogOut_ResF
            // 
            bt6LogOut_ResF.BackColor = Color.Maroon;
            bt6LogOut_ResF.FlatAppearance.BorderSize = 0;
            bt6LogOut_ResF.FlatStyle = FlatStyle.Flat;
            bt6LogOut_ResF.Image = Properties.Resources.LogOut;
            bt6LogOut_ResF.Location = new Point(3, 550);
            bt6LogOut_ResF.Name = "bt6LogOut_ResF";
            bt6LogOut_ResF.Size = new Size(65, 48);
            bt6LogOut_ResF.TabIndex = 2;
            bt6LogOut_ResF.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gold;
            panel2.Location = new Point(1, 59);
            panel2.Name = "panel2";
            panel2.Size = new Size(253, 10);
            panel2.TabIndex = 0;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 10;
            sidebarTransition.Tick += sidebarTransition_Tick;
            // 
            // ResidentsForm3
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Gold;
            ClientSize = new Size(1290, 679);
            Controls.Add(panel2);
            Controls.Add(sidebar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            IsMdiContainer = true;
            Name = "ResidentsForm3";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btHam_ResF).EndInit();
            sidebar.ResumeLayout(false);
            pl2Dashboard_ResF.ResumeLayout(false);
            pl2Dashboard_ResF.PerformLayout();
            pl3MyPrrofile_ResF.ResumeLayout(false);
            pl3MyPrrofile_ResF.PerformLayout();
            pl4SubmitRep_ResF.ResumeLayout(false);
            pl4SubmitRep_ResF.PerformLayout();
            pl5RepHistory_ResF.ResumeLayout(false);
            pl5RepHistory_ResF.PerformLayout();
            pl6ChangePass_ResF.ResumeLayout(false);
            pl6ChangePass_ResF.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox btHam_ResF;
        private ReaLTaiizor.Controls.NightControlBox nightCB1_ResF;
        private Label lb1ResDash_ResF;
        private FlowLayoutPanel sidebar;
        private Button bt1Dashboard_ResF;
        private Panel pl2Dashboard_ResF;
        private Panel pl3MyPrrofile_ResF;
        private Button bt2MyProfile_ResF;
        private Panel pl4SubmitRep_ResF;
        private Button bt3SubmitRep_ResF;
        private Panel pl5RepHistory_ResF;
        private Button bt4SubmitRep_ResF;
        private Panel panel2;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel panel3;
        private Panel panel4;
        private Panel pl6ChangePass_ResF;
        private Button bt5ChangePass_ResF;
        private Panel panel5;
        private Button bt6LogOut_ResF;
    }
}