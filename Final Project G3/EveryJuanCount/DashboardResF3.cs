using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class DashboardResF3 : Form
    {
        private System.Windows.Forms.Timer clockTimer;
        private DataGridView dgvRecentReports;

        public DashboardResF3()
        {
            InitializeComponent();
            this.Load += DashboardResF3_Load;
            InitializeClockLabel();
            StartClock();
            ViewAllRecentReports.Click += ViewAllRecentReports_Click;
            btReportBirth.Click += btReportBirth_Click;
            btReportDeath.Click += btReportDeath_Click;
            btMoveIn.Click += btMoveIn_Click;
            btMoveOut.Click += btMoveOut_Click;
            pictureBox3.Click += pictureBox3_Click;
            pictureBox4.Click += pictureBox4_Click;
            pictureBox5.Click += pictureBox5_Click;
            pictureBox6.Click += pictureBox6_Click;
        }

        #region Load
        private void DashboardResF3_Load(object sender, EventArgs e)
        {
            LoadGreeting();
            UpdateStats();
            SetupRecentReportsGrid();
            LoadRecentReports();
        }

        private void LoadGreeting()
        {
            Resident r = SessionData.CurrentResident;
            Greetings.Text = $"GOOD DAY, {r.FirstName.ToUpper()}!";
        }

        private void UpdateStats()
        {
            int total = SessionData.Reports.Count;
            int pending = SessionData.Reports.Count(r => r.Status == "Pending");
            int approved = SessionData.Reports.Count(r => r.Status == "Approved");

            lbReports.Text = total.ToString();
            lbPending.Text = pending.ToString();
            lbApproved.Text = approved.ToString();
        }
        #endregion

        #region Recent Reports Grid
        private void SetupRecentReportsGrid()
        {
            dgvRecentReports = new DataGridView();
            dgvRecentReports.Dock = DockStyle.Fill;
            dgvRecentReports.BackgroundColor = Color.Silver;
            dgvRecentReports.BorderStyle = BorderStyle.None;
            dgvRecentReports.RowHeadersVisible = false;
            dgvRecentReports.AllowUserToAddRows = false;
            dgvRecentReports.AllowUserToDeleteRows = false;
            dgvRecentReports.ReadOnly = true;
            dgvRecentReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Style header
            dgvRecentReports.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvRecentReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvRecentReports.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvRecentReports.ColumnHeadersHeight = 35;
            dgvRecentReports.EnableHeadersVisualStyles = false;

            // Style rows
            dgvRecentReports.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvRecentReports.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRecentReports.RowTemplate.Height = 30;
            dgvRecentReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // Add columns
            dgvRecentReports.Columns.Add("EventType", "Event Type");
            dgvRecentReports.Columns.Add("FullName", "Person Involved");
            dgvRecentReports.Columns.Add("DateSubmitted", "Date Submitted");
            dgvRecentReports.Columns.Add("Status", "Status");

            dgvRecentReports.Columns["EventType"].FillWeight = 20;
            dgvRecentReports.Columns["FullName"].FillWeight = 35;
            dgvRecentReports.Columns["DateSubmitted"].FillWeight = 25;
            dgvRecentReports.Columns["Status"].FillWeight = 20;

            MyRecentReports.Controls.Add(dgvRecentReports);
        }

        private void LoadRecentReports()
        {
            dgvRecentReports.Rows.Clear();

            // Show last 5 reports
            var recentReports = SessionData.Reports
                .OrderByDescending(r => r.DateSubmitted)
                .Take(5)
                .ToList();

            foreach (Report r in recentReports)
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".Trim();
                int rowIndex = dgvRecentReports.Rows.Add(
                    r.EventType,
                    fullName,
                    r.DateSubmitted.ToString("MM/dd/yyyy hh:mm tt"),
                    r.Status
                );

                // Color code status
                Color statusColor = r.Status switch
                {
                    "Pending" => Color.Goldenrod,
                    "Approved" => Color.Green,
                    "Rejected" => Color.Red,
                    _ => Color.Black
                };
                dgvRecentReports.Rows[rowIndex].Cells["Status"].Style.ForeColor = statusColor;
                dgvRecentReports.Rows[rowIndex].Cells["Status"].Style.Font =
                    new Font("Arial Narrow", 10f, FontStyle.Bold);
            }
        }
        #endregion

        #region Timer
        private void InitializeClockLabel()
        {
            labelClock.AutoSize = true;
            labelClock.BackColor = Color.Transparent;
            labelClock.ForeColor = Color.White;
            labelClock.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            labelClock.Text = DateTime.Now.ToString("dddd,  MMMM dd, yyyy   hh:mm:ss tt");
            labelClock.TextAlign = ContentAlignment.MiddleRight;
            labelClock.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelClock.Location = new Point(
                this.ClientSize.Width - labelClock.Width - 20,
                labelClock.Location.Y
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

        #region Navigation
        private void ViewAllRecentReports_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new ReportHistoryResF3());
        }

        private void btReportBirth_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void btReportDeath_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void btMoveIn_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void btMoveOut_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            var parentForm = this.ParentForm as ResidentForm3;
            if (parentForm != null)
                parentForm.OpenChildForm(new SubmitReport());
        }
        #endregion
    }
}