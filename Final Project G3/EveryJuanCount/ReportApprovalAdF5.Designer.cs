namespace EveryJuanCount
{
    partial class ReportApprovalAdF5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportApprovalAdF5));
            panel2 = new Panel();
            panel5 = new Panel();
            Welcome = new Label();
            Greetings = new Label();
            panel6 = new Panel();
            panel1 = new Panel();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(Welcome);
            panel2.Controls.Add(Greetings);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1015, 80);
            panel2.TabIndex = 22;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Goldenrod;
            panel5.ForeColor = Color.Goldenrod;
            panel5.Location = new Point(17, 12);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(45, 4);
            panel5.TabIndex = 16;
            // 
            // Welcome
            // 
            Welcome.AutoSize = true;
            Welcome.Font = new Font("Arial Narrow", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Welcome.ForeColor = SystemColors.AppWorkspace;
            Welcome.Location = new Point(17, 58);
            Welcome.Name = "Welcome";
            Welcome.Size = new Size(306, 16);
            Welcome.TabIndex = 15;
            Welcome.Text = "Review and approve or reject resident-submitted reports.";
            // 
            // Greetings
            // 
            Greetings.AutoSize = true;
            Greetings.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Greetings.ForeColor = Color.MidnightBlue;
            Greetings.Location = new Point(12, 16);
            Greetings.Name = "Greetings";
            Greetings.Size = new Size(342, 42);
            Greetings.TabIndex = 14;
            Greetings.Text = "REPORT APPROVAL";
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 80);
            panel6.Name = "panel6";
            panel6.Size = new Size(1015, 10);
            panel6.TabIndex = 23;
            // 
            // panel1
            // 
            panel1.Controls.Add(guna2ShadowPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 90);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1015, 682);
            panel1.TabIndex = 24;
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Dock = DockStyle.Fill;
            guna2ShadowPanel1.FillColor = SystemColors.GradientActiveCaption;
            guna2ShadowPanel1.Location = new Point(10, 10);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 15;
            guna2ShadowPanel1.ShadowColor = Color.Black;
            guna2ShadowPanel1.Size = new Size(995, 662);
            guna2ShadowPanel1.TabIndex = 0;
            // 
            // ReportApprovalAdF5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 773);
            Controls.Add(panel1);
            Controls.Add(panel6);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReportApprovalAdF5";
            Text = "ReportApprovalAdF5";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel5;
        private Label Welcome;
        private Label Greetings;
        private Panel panel6;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
    }
}