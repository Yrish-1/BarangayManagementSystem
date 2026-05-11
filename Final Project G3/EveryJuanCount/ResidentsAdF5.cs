using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ResidentsAdF5 : Form
    {
        private List<Resident> _residents = new();

        public ResidentsAdF5()
        {
            InitializeComponent();
            LoadStats();
            // Wire up search and filter events
            txtbFineRes.TextChanged += (s, e) => FilterResidents();
            cbFilterBy.SelectedIndexChanged += (s, e) => FilterResidents();
        }

        private void LoadStats()
        {
            _residents = DatabaseHelper.GetAllResidents();
            var allReports = DatabaseHelper.GetAllReports("All");

            int total = _residents.Count;
            int newRegistered = _residents.FindAll(r =>
                DateTime.TryParse(r.DateOfBirth.ToString(), out _)).Count; // placeholder
            int approved = allReports.FindAll(r => r.Status == "Approved").Count;
            int deaths = allReports.FindAll(r => r.EventType == "Death").Count;

            lbAll.Text = $"Total Residents ( {total} )";
            lbPending.Text = $"New Registered ( {total} )";
            lbApproved.Text = $"Approved ( {approved} )";
            lbRejected.Text = $"Total Deaths ( {deaths} )";

            LoadGrid(_residents);
        }

        private void LoadGrid(List<Resident> list)
        {
            // Check if dgvResidents exists — add it in designer first!
            if (!this.Controls.ContainsKey("dgvResidents") &&
                !panel6.Controls.ContainsKey("dgvResidents"))
            {
                var dgv = new DataGridView();
                dgv.Name = "dgvResidents";
                dgv.Dock = DockStyle.Fill;
                dgv.BackgroundColor = System.Drawing.Color.MidnightBlue;
                dgv.ForeColor = System.Drawing.Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 0, 64);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
                dgv.EnableHeadersVisualStyles = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.ReadOnly = true;
                dgv.AllowUserToAddRows = false;
                dgv.Columns.Add("ResidentId", "ID");
                dgv.Columns.Add("LastName", "Last Name");
                dgv.Columns.Add("FirstName", "First Name");
                dgv.Columns.Add("MiddleName", "Middle Name");
                dgv.Columns.Add("DateOfBirth", "Date of Birth");
                dgv.Columns.Add("Age", "Age");
                dgv.Columns.Add("ContactNumber", "Contact No.");
                dgv.Columns.Add("Barangay", "Barangay");
                dgv.Columns.Add("Purok", "Purok");
                dgv.Columns.Add("ResidencyStatus", "Status");
                panel6.Controls.Add(dgv);
                dgv.BringToFront();
            }

            var dgvResidents = panel6.Controls["dgvResidents"] as DataGridView;
            if (dgvResidents == null) return;

            dgvResidents.Rows.Clear();
            foreach (var r in list)
            {
                int age = DateTime.Today.Year - r.DateOfBirth.Year;
                if (DateTime.Today < r.DateOfBirth.AddYears(age)) age--;

                dgvResidents.Rows.Add(
                    r.ResidentId,
                    r.LastName,
                    r.FirstName,
                    r.MiddleName,
                    r.DateOfBirth.ToString("MM/dd/yyyy"),
                    age,
                    r.ContactNumber,
                    r.Barangay,
                    r.Purok,
                    r.ResidencyStatus
                );
            }
        }

        private void FilterResidents()
        {
            string keyword = txtbFineRes.Text.Trim().ToLower();
            string filter = cbFilterBy.SelectedItem?.ToString() ?? "All Status";

            var filtered = _residents.FindAll(r =>
            {
                string fullName = $"{r.FirstName} {r.MiddleName} {r.LastName}".ToLower();
                bool matchesSearch = string.IsNullOrEmpty(keyword) ||
                                     fullName.Contains(keyword) ||
                                     r.ResidentId.ToString().Contains(keyword);
                bool matchesFilter = filter == "All Status" ||
                                     r.ResidencyStatus.Equals(filter,
                                     StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesFilter;
            });

            LoadGrid(filtered);
        }
    }
}