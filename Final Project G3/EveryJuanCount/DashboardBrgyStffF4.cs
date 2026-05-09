using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class DashboardBrgyStffF4 : Form
    {
        public DashboardBrgyStffF4()
        {
            InitializeComponent();
            InitializeClockLabel();
            StartClock();
        }

        #region Timer

        private void InitializeClockLabel()
        {
            labelClock.AutoSize = true;
            labelClock.BackColor = Color.Transparent;
            labelClock.ForeColor = Color.White;
            labelClock.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");

            // ── Position to the right side ──────────────────────────────
            labelClock.TextAlign = ContentAlignment.MiddleRight;
            labelClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Adjust X (right margin) and Y (vertical position) as needed
            labelClock.Location = new Point(
                this.ClientSize.Width - labelClock.Width - 20,  // 20px from right edge
                labelClock.Location.Y                            // keep same vertical position
            );
        }

        private void StartClock()
        {
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            // Update label every second
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (clockTimer != null)
            {
                clockTimer.Stop();
                clockTimer.Dispose();
            }
        }
        #endregion


        private void ViewAllRecentReports_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new ReportsQueueBrgyStffF4());
            }
        }

        #region QuickAccessButtons
        private void btReportBirth_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new SubmitReportBrgyStffF4());
            }
        }

        private void btReportDeath_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new SubmitReportBrgyStffF4());
            }
        }

        private void btMoveIn_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new SubmitReportBrgyStffF4());
            }
        }

        private void btMoveOut_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new SubmitReportBrgyStffF4());
            }
        }
        #endregion

        #region QuickAccessPictureBoxes
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new ReportsQueueBrgyStffF4());
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new ReportsQueueBrgyStffF4());
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new ReportsQueueBrgyStffF4());
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            if (parentForm != null)
            {
                parentForm.OpenChildForm(new ReportsQueueBrgyStffF4());
            }
        }
        #endregion


    }
}
