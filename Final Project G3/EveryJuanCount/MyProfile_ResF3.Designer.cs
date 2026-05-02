namespace EveryJuanCount
{
    partial class MyProfile_ResF3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProfile_ResF3));
            panel1 = new Panel();
            label1 = new Label();
            lb1RegDes = new Label();
            lbGreetings = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.BackColor = Color.Maroon;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1284, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(128, 25);
            panel1.TabIndex = 57;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 56;
            label1.Text = "Verified Resident";
            // 
            // lb1RegDes
            // 
            lb1RegDes.AutoSize = true;
            lb1RegDes.Font = new Font("Arial Narrow", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb1RegDes.ForeColor = SystemColors.ControlDark;
            lb1RegDes.Location = new Point(102, 37);
            lb1RegDes.Name = "lb1RegDes";
            lb1RegDes.Size = new Size(129, 16);
            lb1RegDes.TabIndex = 54;
            lb1RegDes.Text = "Your Personal Information";
            // 
            // lbGreetings
            // 
            lbGreetings.AutoSize = true;
            lbGreetings.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbGreetings.ForeColor = Color.Gold;
            lbGreetings.Location = new Point(102, 9);
            lbGreetings.Name = "lbGreetings";
            lbGreetings.Size = new Size(133, 28);
            lbGreetings.TabIndex = 0;
            lbGreetings.Text = "MY PROFILE";
            lbGreetings.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MidnightBlue;
            panel2.Controls.Add(lbGreetings);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(lb1RegDes);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1453, 67);
            panel2.TabIndex = 58;
            // 
            // MyProfile_ResF3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1453, 597);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MyProfile_ResF3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyProfile_ResF3";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lb1RegDes;
        private Label lbGreetings;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
    }
}