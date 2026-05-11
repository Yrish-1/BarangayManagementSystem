using System;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class PopulationReportAdF5 : Form
    {
        public PopulationReportAdF5()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                var reportCounts = DatabaseHelper.GetReportCountsByType();

                int births = reportCounts.ContainsKey("Birth") ? reportCounts["Birth"] : 0;
                int deaths = reportCounts.ContainsKey("Death") ? reportCounts["Death"] : 0;
                int moveIn = reportCounts.ContainsKey("Move In") ? reportCounts["Move In"] : 0;
                int moveOut = reportCounts.ContainsKey("Move Out") ? reportCounts["Move Out"] : 0;

                // Blue card → Birth Reports
                label4.Text = births.ToString();

                // Red card → Death Reports
                label7.Text = deaths.ToString();

                // Yellow card → Move-In
                lbReports.Text = moveIn.ToString();

                // Green card → Move-Out
                label1.Text = moveOut.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading population stats: " + ex.Message);
            }
        }
    }
}