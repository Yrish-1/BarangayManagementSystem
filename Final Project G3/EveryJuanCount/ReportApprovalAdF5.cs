using System;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ReportApprovalAdF5 : Form
    {
        private DataGridView dgvReports;
        private TextBox txtRemarks;
        private Button btnApprove;
        private Button btnReject;
        private Label lblSelectedReport;
        private ComboBox cmbFilter;

        public ReportApprovalAdF5()
        {
            InitializeComponent();
            this.Load += ReportApprovalAdF5_Load;
        }

        private void ReportApprovalAdF5_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadReports("All");
        }

        #region Setup UI
        private void SetupUI()
        {
            // Filter bar
            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 45;
            filterPanel.BackColor = Color.MidnightBlue;
            filterPanel.Padding = new Padding(10, 8, 10, 5);

            Label lblFilter = new Label();
            lblFilter.Text = "Filter:";
            lblFilter.ForeColor = Color.Gold;
            lblFilter.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(10, 12);

            cmbFilter = new ComboBox();
            cmbFilter.Items.AddRange(new string[] { "All", "Pending", "Approved", "Rejected" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Font = new Font("Arial Narrow", 10f);
            cmbFilter.Location = new Point(60, 8);
            cmbFilter.Width = 150;
            cmbFilter.SelectedIndexChanged += (s, e) => LoadReports(cmbFilter.SelectedItem.ToString());

            filterPanel.Controls.Add(lblFilter);
            filterPanel.Controls.Add(cmbFilter);

            // DataGridView
            dgvReports = new DataGridView();
            dgvReports.Dock = DockStyle.Top;
            dgvReports.Height = 350;
            dgvReports.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.RowHeadersVisible = false;
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.ReadOnly = true;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.MultiSelect = false;

            dgvReports.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvReports.ColumnHeadersHeight = 35;
            dgvReports.EnableHeadersVisualStyles = false;
            dgvReports.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvReports.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvReports.RowTemplate.Height = 30;
            dgvReports.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            dgvReports.Columns.Add("ReportId", "ID");
            dgvReports.Columns.Add("ResidentId", "Resident ID");
            dgvReports.Columns.Add("EventType", "Event Type");
            dgvReports.Columns.Add("FullName", "Person Involved");
            dgvReports.Columns.Add("Reporter", "Reported By");
            dgvReports.Columns.Add("DateSubmitted", "Date Submitted");
            dgvReports.Columns.Add("Status", "Status");

            dgvReports.Columns["ReportId"].FillWeight = 5;
            dgvReports.Columns["ResidentId"].FillWeight = 8;
            dgvReports.Columns["EventType"].FillWeight = 12;
            dgvReports.Columns["FullName"].FillWeight = 20;
            dgvReports.Columns["Reporter"].FillWeight = 20;
            dgvReports.Columns["DateSubmitted"].FillWeight = 18;
            dgvReports.Columns["Status"].FillWeight = 12;

            dgvReports.SelectionChanged += DgvReports_SelectionChanged;

            // Details panel
            Panel detailsPanel = new Panel();
            detailsPanel.Dock = DockStyle.Top;
            detailsPanel.Height = 200;
            detailsPanel.BackColor = Color.AliceBlue;
            detailsPanel.Padding = new Padding(15);

            lblSelectedReport = new Label();
            lblSelectedReport.Text = "Select a report to review";
            lblSelectedReport.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblSelectedReport.ForeColor = Color.MidnightBlue;
            lblSelectedReport.Dock = DockStyle.Top;
            lblSelectedReport.Height = 60;

            Label lblRemarks = new Label();
            lblRemarks.Text = "Admin Remarks:";
            lblRemarks.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblRemarks.ForeColor = Color.MidnightBlue;
            lblRemarks.AutoSize = true;
            lblRemarks.Location = new Point(15, 70);

            txtRemarks = new TextBox();
            txtRemarks.Multiline = true;
            txtRemarks.Location = new Point(15, 95);
            txtRemarks.Width = 700;
            txtRemarks.Height = 60;
            txtRemarks.Font = new Font("Arial Narrow", 10f);
            txtRemarks.PlaceholderText = "Enter remarks here (optional)...";

            btnApprove = new Button();
            btnApprove.Text = "✔ APPROVE";
            btnApprove.BackColor = Color.Green;
            btnApprove.ForeColor = Color.White;
            btnApprove.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.Location = new Point(15, 165);
            btnApprove.Size = new Size(150, 35);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.Click += BtnApprove_Click;

            btnReject = new Button();
            btnReject.Text = "✖ REJECT";
            btnReject.BackColor = Color.Maroon;
            btnReject.ForeColor = Color.White;
            btnReject.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.Location = new Point(175, 165);
            btnReject.Size = new Size(150, 35);
            btnReject.Cursor = Cursors.Hand;
            btnReject.Click += BtnReject_Click;

            detailsPanel.Controls.Add(lblSelectedReport);
            detailsPanel.Controls.Add(lblRemarks);
            detailsPanel.Controls.Add(txtRemarks);
            detailsPanel.Controls.Add(btnApprove);
            detailsPanel.Controls.Add(btnReject);

            guna2ShadowPanel1.Controls.Add(detailsPanel);
            guna2ShadowPanel1.Controls.Add(dgvReports);
            guna2ShadowPanel1.Controls.Add(filterPanel);
        }
        #endregion

        #region Load Reports
        private void LoadReports(string filter)
        {
            dgvReports.Rows.Clear();

            var reports = DatabaseHelper.GetAllReports(filter);

            foreach (var r in reports)
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".Trim();
                string reporter = $"{r.ReporterFirstName} {r.ReporterLastName}".Trim();

                int rowIndex = dgvReports.Rows.Add(
                    r.ReportId,
                    r.ResidentId,
                    r.EventType,
                    fullName,
                    reporter,
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
                dgvReports.Rows[rowIndex].Cells["Status"].Style.ForeColor = statusColor;
                dgvReports.Rows[rowIndex].Cells["Status"].Style.Font =
                    new Font("Arial Narrow", 10f, FontStyle.Bold);
            }
        }
        #endregion

        #region Selection Changed
        private void DgvReports_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0) return;

            var row = dgvReports.SelectedRows[0];
            string eventType = row.Cells["EventType"].Value?.ToString();
            string fullName = row.Cells["FullName"].Value?.ToString();
            string reporter = row.Cells["Reporter"].Value?.ToString();
            string status = row.Cells["Status"].Value?.ToString();
            string date = row.Cells["DateSubmitted"].Value?.ToString();

            lblSelectedReport.Text =
                $"Event: {eventType}  |  Person: {fullName}  |  " +
                $"Reporter: {reporter}  |  Date: {date}  |  Status: {status}";

            txtRemarks.Text = "";
        }
        #endregion

        #region Approve / Reject
        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["ReportId"].Value);
            string remarks = txtRemarks.Text.Trim();

            DatabaseHelper.UpdateReportStatus(reportId, "Approved", remarks);
            MessageBox.Show("Report approved successfully!", "Approved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadReports(cmbFilter.SelectedItem.ToString());
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a report first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reportId = Convert.ToInt32(dgvReports.SelectedRows[0].Cells["ReportId"].Value);
            string remarks = txtRemarks.Text.Trim();

            if (string.IsNullOrEmpty(remarks))
            {
                MessageBox.Show("Please enter a reason for rejection.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper.UpdateReportStatus(reportId, "Rejected", remarks);
            MessageBox.Show("Report rejected.", "Rejected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadReports(cmbFilter.SelectedItem.ToString());
        }
        #endregion
    }
}