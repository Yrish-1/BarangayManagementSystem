using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ResidentsBrgyStffF4 : Form
    {
        private DataGridView dgvResidents;
        private List<Resident> _residents = new();

        public ResidentsBrgyStffF4()
        {
            InitializeComponent();
            this.Load += ResidentsBrgyStffF4_Load;
        }

        private void ResidentsBrgyStffF4_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadData();
            WireEvents();
        }

        private void SetupGrid()
        {
            dgvResidents = new DataGridView();
            dgvResidents.Dock = DockStyle.Fill;
            dgvResidents.BackgroundColor = System.Drawing.Color.MidnightBlue;
            dgvResidents.BorderStyle = BorderStyle.None;
            dgvResidents.RowHeadersVisible = false;
            dgvResidents.AllowUserToAddRows = false;
            dgvResidents.AllowUserToDeleteRows = false;
            dgvResidents.ReadOnly = true;
            dgvResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResidents.MultiSelect = false;
            dgvResidents.RowTemplate.Height = 35;

            dgvResidents.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvResidents.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvResidents.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvResidents.ColumnHeadersHeight = 35;
            dgvResidents.EnableHeadersVisualStyles = false;
            dgvResidents.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvResidents.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvResidents.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            dgvResidents.Columns.Add("ColId", "ID");
            dgvResidents.Columns.Add("ColLast", "Last Name");
            dgvResidents.Columns.Add("ColFirst", "First Name");
            dgvResidents.Columns.Add("ColMiddle", "Middle Name");
            dgvResidents.Columns.Add("ColDOB", "Date of Birth");
            dgvResidents.Columns.Add("ColAge", "Age");
            dgvResidents.Columns.Add("ColContact", "Contact No.");
            dgvResidents.Columns.Add("ColBarangay", "Barangay");
            dgvResidents.Columns.Add("ColPurok", "Purok");
            dgvResidents.Columns.Add("ColStatus", "Status");

            panel6.Controls.Add(dgvResidents);
        }

        private void WireEvents()
        {
            txtbFineRes.TextChanged += (s, e) => FilterResidents();
            cbFilterBy.SelectedIndexChanged += (s, e) => FilterResidents();
        }

        private void LoadData()
        {
            _residents = DatabaseHelper.GetAllResidents();
            var allReports = DatabaseHelper.GetAllReports("All");

            int total = _residents.Count;
            int approved = allReports.FindAll(r => r.Status == "Approved").Count;
            int deaths = allReports.FindAll(r => r.EventType == "Death").Count;

            lbAll.Text = $"Total Residents ( {total} )";
            lbPending.Text = $"New Registered ( {total} )";
            lbApproved.Text = $"Approved ( {approved} )";
            lbRejected.Text = $"Total Deaths ( {deaths} )";

            PopulateGrid(_residents);
        }

        private void PopulateGrid(List<Resident> list)
        {
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
                bool matchSearch = string.IsNullOrEmpty(keyword) ||
                                   fullName.Contains(keyword) ||
                                   r.ResidentId.ToString().Contains(keyword);
                bool matchFilter = filter == "All Status" ||
                                   r.ResidencyStatus.Equals(filter,
                                   StringComparison.OrdinalIgnoreCase);
                return matchSearch && matchFilter;
            });

            PopulateGrid(filtered);
        }
    }
}