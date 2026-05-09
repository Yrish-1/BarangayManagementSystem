using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ReportHistoryResF3 : Form
    {
        private DataGridView dgvReports;
        private string currentFilter = "All";

        public ReportHistoryResF3()
        {
            InitializeComponent();
            this.Load += ReportHistoryResF3_Load;
            this.VisibleChanged += (s, e) =>
            {
                if (this.Visible)
                {
                    UpdateCounts();
                    LoadReports(currentFilter);
                }
            };

            // Wire up filter buttons
            All.Click += (s, e) => FilterReports("All");
            Pending.Click += (s, e) => FilterReports("Pending");
            Approved.Click += (s, e) => FilterReports("Approved");
            Rejected.Click += (s, e) => FilterReports("Rejected");
        }

        #region Load
        private void ReportHistoryResF3_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadReports("All");
            UpdateCounts();
        }
        #endregion

        #region Setup DataGridView
        private void SetupDataGridView()
        {
            dgvReports = new DataGridView();
            dgvReports.Dock = DockStyle.Fill;
            dgvReports.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.RowHeadersVisible = false;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.ReadOnly = true;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Style header
            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvReports.ColumnHeadersHeight = 35;
            dgvReports.EnableHeadersVisualStyles = false;

            // Style rows
            dgvReports.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvReports.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvReports.RowTemplate.Height = 30;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            // Add columns
            dgvReports.Columns.Add("ReportId", "ID");
            dgvReports.Columns.Add("EventType", "Event Type");
            dgvReports.Columns.Add("FullName", "Person Involved");
            dgvReports.Columns.Add("DateOfEvent", "Date of Event");
            dgvReports.Columns.Add("DateSubmitted", "Date Submitted");
            dgvReports.Columns.Add("Status", "Status");

            // Set column widths
            dgvReports.Columns["ReportId"].FillWeight = 5;
            dgvReports.Columns["EventType"].FillWeight = 15;
            dgvReports.Columns["FullName"].FillWeight = 25;
            dgvReports.Columns["DateOfEvent"].FillWeight = 15;
            dgvReports.Columns["DateSubmitted"].FillWeight = 20;
            dgvReports.Columns["Status"].FillWeight = 15;

            panel6.Controls.Add(dgvReports);
        }
        #endregion

        #region Load and Filter Reports
        private void LoadReports(string filter)
        {
            currentFilter = filter;
            dgvReports.Rows.Clear();

            List<Report> reports = SessionData.Reports;

            // Filter
            if (filter != "All")
                reports = reports.Where(r => r.Status == filter).ToList();

            if (reports.Count == 0)
            {
                // Show no reports message
                dgvReports.Rows.Clear();
                return;
            }

            foreach (Report r in reports)
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".Trim();
                int rowIndex = dgvReports.Rows.Add(
                    r.ReportId,
                    r.EventType,
                    fullName,
                    r.DateOfEvent.ToString("MM/dd/yyyy"),
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
                dgvReports.Rows[rowIndex].Cells["Status"].Style.ForeColor = statusColor;
                dgvReports.Rows[rowIndex].Cells["Status"].Style.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            }
        }

        private void FilterReports(string filter)
        {
            LoadReports(filter);
        }

        private void UpdateCounts()
        {
            int total = SessionData.Reports.Count;
            int pending = SessionData.Reports.Count(r => r.Status == "Pending");
            int approved = SessionData.Reports.Count(r => r.Status == "Approved");
            int rejected = SessionData.Reports.Count(r => r.Status == "Rejected");

            lbAll.Text = $"All ( {total} )";
            lbPending.Text = $"Pending ( {pending} )";
            lbApproved.Text = $"Approved ( {approved} )";
            lbRejected.Text = $"Rejected ( {rejected} )";
        }
        #endregion
    }
}