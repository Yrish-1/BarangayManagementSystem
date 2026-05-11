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
            LoadData();
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

            if (dgvResidents.Columns.Count == 0)
            {
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
                dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

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

            PopulateGrid(filtered);
        }
    }
}