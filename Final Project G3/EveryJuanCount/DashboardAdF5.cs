using System;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class DashboardAdF5 : Form
    {
        public DashboardAdF5()
        {
            InitializeComponent();
            LoadDashboardStats();
            StartClock();
        }

        private void StartClock()
        {
            clockTimer.Interval = 1000;
            clockTimer.Tick += (s, e) =>
                labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
            clockTimer.Start();
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
        }

        private void LoadDashboardStats()
        {
            try
            {
                // Update greeting
                Greetings.Text = $"WELCOME, {SessionData.CurrentUsername.ToUpper()}!";

                // Load stats
                var allReports = DatabaseHelper.GetAllReports("All");
                int pending = allReports.FindAll(r => r.Status == "Pending").Count;

                var reportCounts = DatabaseHelper.GetReportCountsByType();
                int births = reportCounts.ContainsKey("Birth") ? reportCounts["Birth"] : 0;
                int deaths = reportCounts.ContainsKey("Death") ? reportCounts["Death"] : 0;

                var residents = DatabaseHelper.GetAllResidents();

                // Total Residents card → lbReports
                lbReports.Text = residents.Count.ToString();

                // Pending Reports card → label1
                label1.Text = pending.ToString();

                // Birth Reports card → label4
                label4.Text = births.ToString();

                // Death Reports card → label7
                label7.Text = deaths.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            clockTimer?.Stop();
            clockTimer?.Dispose();
        }
    }
}