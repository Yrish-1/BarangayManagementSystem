using EveryJuanCount.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ResidentForm3 : Form
    {
        public ResidentForm3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ControlBox = true;


        }

        #region FormClosing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Show Login Form when this form closes
            var form1 = Application.OpenForms.OfType<LogInForm1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.Show();
                form1.BringToFront();
            }
            else
            {
                new LogInForm1().Show();
            }
        }
        #endregion

        #region Color Title Bar

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_CAPTION_COLOR = 35;  // title bar color
        private const int DWMWA_BORDER_COLOR = 34;   // border color

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetGoldTitleBar();
        }

        private void SetGoldTitleBar()
        {
            int goldBGR = ColorToBGR(Color.Gold);
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref goldBGR, sizeof(int));
            DwmSetWindowAttribute(this.Handle, DWMWA_BORDER_COLOR, ref goldBGR, sizeof(int));
        }

        private int ColorToBGR(Color color)
        {
            return color.B << 16 | color.G << 8 | color.R;
        }
        #endregion

        #region OpenChildForm
        private Form activeForm = null;

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.Location = new Point(0, 0);
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Opacity = 0.80; // Set opacity to 95%

            childForm.AutoScroll = true;
            pnChilForms.Controls.Add(childForm);
            pnChilForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        #endregion

        #region MenuVerticalButtons
        private void btDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardResF3());
        }

        private void btSubmitReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SubmitReport());
        }

        private void btReportHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReportHistoryResF3());
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsResF3());
        }

        #endregion


        private void btLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btMenuVertical_Click(object sender, EventArgs e)
        {

            pnSlideMenu.Width = pnSlideMenu.Width == 330 ? 45 : 330;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Close the active child form and show the default panel background
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
        }

        
    }
}