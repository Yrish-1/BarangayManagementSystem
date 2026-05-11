using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ReportsQueueBrgyStffF4 : Form
    {
        private DataGridView dgvReports;
        private List<Report> _reports = new();

        public ReportsQueueBrgyStffF4()
        {
            InitializeComponent();
            this.Load += ReportsQueueBrgyStffF4_Load;
        }

        private void ReportsQueueBrgyStffF4_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadReports();
            WireEvents();
        }

        private void SetupGrid()
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
            dgvReports.MultiSelect = false;
            dgvReports.RowTemplate.Height = 35;

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvReports.ColumnHeadersHeight = 35;
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvReports.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            dgvReports.Columns.Add("ColId", "ID");
            dgvReports.Columns.Add("ColType", "Event Type");
            dgvReports.Columns.Add("ColPerson", "Person Involved");
            dgvReports.Columns.Add("ColReporter", "Reported By");
            dgvReports.Columns.Add("ColDate", "Date of Event");
            dgvReports.Columns.Add("ColSubmitted", "Date Submitted");
            dgvReports.Columns.Add("ColStatus", "Status");

            dgvReports.Columns["ColId"].FillWeight = 5;
            dgvReports.Columns["ColType"].FillWeight = 13;
            dgvReports.Columns["ColPerson"].FillWeight = 20;
            dgvReports.Columns["ColReporter"].FillWeight = 20;
            dgvReports.Columns["ColDate"].FillWeight = 15;
            dgvReports.Columns["ColSubmitted"].FillWeight = 15;
            dgvReports.Columns["ColStatus"].FillWeight = 12;

            // Add approve/reject buttons to panel8
            Button btnApprove = new Button();
            btnApprove.Text = "✔ APPROVE";
            btnApprove.BackColor = Color.FromArgb(0, 100, 0);
            btnApprove.ForeColor = Color.White;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnApprove.Location = new Point(15, 9);
            btnApprove.Size = new Size(140, 30);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.Click += BtnApprove_Click;

            Button btnReject = new Button();
            btnReject.Text = "✖ REJECT";
            btnReject.BackColor = Color.Maroon;
            btnReject.ForeColor = Color.White;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnReject.Location = new Point(165, 9);
            btnReject.Size = new Size(140, 30);
            btnReject.Cursor = Cursors.Hand;
            btnReject.Click += BtnReject_Click;

            panel8.Controls.Add(btnApprove);
            panel8.Controls.Add(btnReject);
            panel7.Controls.Add(dgvReports);
        }

        private void WireEvents()
        {
            txtbSearch_ReportQueue.TextChanged += (s, e) => FilterReports();
            cbAllStatus_ReportsQueue.SelectedIndexChanged += (s, e) => FilterReports();
            cbAllTypes_ReportsQueue.SelectedIndexChanged += (s, e) => FilterReports();
        }

        private void LoadReports()
        {
            _reports = DatabaseHelper.GetAllReports("All");
            PopulateGrid(_reports);
        }

        private void PopulateGrid(List<Report> list)
        {
            dgvReports.Rows.Clear();
            foreach (var r in list)
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".Trim();
                string reporter = $"{r.ReporterFirstName} {r.ReporterLastName}".Trim();

                int rowIndex = dgvReports.Rows.Add(
                    r.ReportId,
                    r.EventType,
                    fullName,
                    reporter,
                    r.DateOfEvent.ToString("MM/dd/yyyy"),
                    r.DateSubmitted.ToString("MM/dd/yyyy hh:mm tt"),
                    r.Status
                );

                Color statusColor = r.Status switch
                {
                    "Pending" => Color.Goldenrod,
                    "Approved" => Color.Green,
                    "Rejected" => Color.Red,
                    _ => Color.Black
                };
                dgvReports.Rows[rowIndex].Cells["ColStatus"].Style.ForeColor = statusColor;
                dgvReports.Rows[rowIndex].Cells["ColStatus"].Style.Font =
                    new Font("Arial Narrow", 10f, FontStyle.Bold);
            }
        }

        private void FilterReports()
        {
            string keyword = txtbSearch_ReportQueue.Text.Trim().ToLower();
            string statusFilter = cbAllStatus_ReportsQueue.SelectedItem?.ToString() ?? "All Status";
            string typeFilter = cbAllTypes_ReportsQueue.SelectedItem?.ToString() ?? "All Types";

            var filtered = _reports.FindAll(r =>
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".ToLower();
                bool matchSearch = string.IsNullOrEmpty(keyword) ||
                                   fullName.Contains(keyword) ||
                                   r.EventType.ToLower().Contains(keyword);
                bool matchStatus = statusFilter == "All Status" ||
                                   r.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase);
                bool matchType = typeFilter == "All Types" ||
                                 r.EventType.Equals(typeFilter, StringComparison.OrdinalIgnoreCase);
                return matchSearch && matchStatus && matchType;
            });

            PopulateGrid(filtered);
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["ColId"].Value);
            DatabaseHelper.UpdateReportStatus(reportId, "Approved", "Approved by staff.");
            MessageBox.Show("Report approved!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReports();
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["ColId"].Value);
            DatabaseHelper.UpdateReportStatus(reportId, "Rejected", "Rejected by staff.");
            MessageBox.Show("Report rejected.", "Rejected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReports();
        }
    }
}