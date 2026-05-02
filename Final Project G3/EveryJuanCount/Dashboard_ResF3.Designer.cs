namespace EveryJuanCount
{
    partial class Dashboard_ResF3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard_ResF3));
            lbGreetings = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            lbVerification = new Label();
            lb1RegDes = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lbGreetings
            // 
            lbGreetings.AutoSize = true;
            lbGreetings.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbGreetings.ForeColor = Color.Gold;
            lbGreetings.Location = new Point(102, 9);
            lbGreetings.Name = "lbGreetings";
            lbGreetings.Size = new Size(196, 28);
            lbGreetings.TabIndex = 0;
            lbGreetings.Text = "GOOD DAY, JUAN!";
            lbGreetings.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(lb1RegDes);
            panel2.Controls.Add(lbGreetings);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1453, 67);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.BackColor = Color.Maroon;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(lbVerification);
            panel3.Location = new Point(1284, 15);
            panel3.Name = "panel3";
            panel3.Size = new Size(128, 25);
            panel3.TabIndex = 55;
            // 
            // lbVerification
            // 
            lbVerification.Anchor = AnchorStyles.None;
            lbVerification.AutoSize = true;
            lbVerification.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbVerification.ForeColor = SystemColors.Control;
            lbVerification.Location = new Point(3, 3);
            lbVerification.Name = "lbVerification";
            lbVerification.Size = new Size(118, 15);
            lbVerification.TabIndex = 55;
            lbVerification.Text = "Verified Resident";
            // 
            // lb1RegDes
            // 
            lb1RegDes.AutoSize = true;
            lb1RegDes.Font = new Font("Arial Narrow", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb1RegDes.ForeColor = SystemColors.ControlDark;
            lb1RegDes.Location = new Point(102, 37);
            lb1RegDes.Name = "lb1RegDes";
            lb1RegDes.Size = new Size(224, 16);
            lb1RegDes.TabIndex = 54;
            lb1RegDes.Text = "Welcome back to your barangay census portal";
            // 
            // Dashboard_ResF3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 597);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Dashboard_ResF3";
            Text = "Dashboard_F3";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbGreetings;
        private Panel panel2;
        private Panel panel3;
        private Label lb1RegDes;
        private Label lbVerification;
    }
}