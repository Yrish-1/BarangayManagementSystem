using System;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class DashboardBrgyStffF4 : Form
    {
        public DashboardBrgyStffF4()
        {
            InitializeComponent();
            LoadDashboardStats();
            StartClock();
        }

        private void StartClock()
        {
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
        }

        private void LoadDashboardStats()
        {
            try
            {
                Greetings.Text = $"GOOD DAY, {SessionData.CurrentUsername.ToUpper()}!";

                var allReports = DatabaseHelper.GetAllReports("All");
                int pending = allReports.FindAll(r => r.Status == "Pending").Count;

                var reportCounts = DatabaseHelper.GetReportCountsByType();
                int births = reportCounts.ContainsKey("Birth") ? reportCounts["Birth"] : 0;
                int moveIn = reportCounts.ContainsKey("Move In") ? reportCounts["Move In"] : 0;

                var residents = DatabaseHelper.GetAllResidents();

                // Blue card → Total Residents
                lbReports.Text = residents.Count.ToString();

                // Red card → Pending Reports
                label1.Text = pending.ToString();

                // Yellow card → Birth Reports
                label4.Text = births.ToString();

                // Green card → Move-In Reports
                label7.Text = moveIn.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
        }

        private void ViewAllRecentReports_Click(object sender, EventArgs e)
        {
            // Navigate to Reports Queue
            var parentForm = this.ParentForm as BarangayStaffForm4;
            parentForm?.OpenChildForm(new ReportsQueueBrgyStffF4());
        }

        #region Quick Access Buttons
        private void btReportBirth_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            parentForm?.OpenChildForm(new SubmitReportBrgyStffF4());
        }

        private void btReportDeath_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            parentForm?.OpenChildForm(new SubmitReportBrgyStffF4());
        }

        private void btMoveIn_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            parentForm?.OpenChildForm(new SubmitReportBrgyStffF4());
        }

        private void btMoveOut_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as BarangayStaffForm4;
            parentForm?.OpenChildForm(new SubmitReportBrgyStffF4());
        }

        private void pictureBox6_Click(object sender, EventArgs e) => btReportBirth_Click(sender, e);
        private void pictureBox7_Click(object sender, EventArgs e) => btReportDeath_Click(sender, e);
        private void pictureBox8_Click(object sender, EventArgs e) => btMoveIn_Click(sender, e);
        private void pictureBox9_Click(object sender, EventArgs e) => btMoveOut_Click(sender, e);
        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            clockTimer?.Stop();
            clockTimer?.Dispose();
        }
    }
}