using System;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class EncodeResidentBrgyStffF4 : Form
    {
        public EncodeResidentBrgyStffF4()
        {
            InitializeComponent();
            this.Load += EncodeResidentBrgyStffF4_Load;
        }

        private void EncodeResidentBrgyStffF4_Load(object sender, EventArgs e)
        {
            // Auto-calculate age when date of birth changes
            dateTimePicker1_Restb.ValueChanged += (s, ev) => CalculateAge();
            CalculateAge();

            // Wire upload button
            button2.Click += Button2_Click;
        }

        private void CalculateAge()
        {
            var dob = dateTimePicker1_Restb.Value;
            int age = DateTime.Today.Year - dob.Year;
            if (DateTime.Today < dob.AddYears(age)) age--;
            txtb4Age_Residenttb.Text = age.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtb1FN_Residenttb.Text))
            {
                MessageBox.Show("First Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtb3LN_Residenttb.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtb5CN_Restb.Text))
            {
                MessageBox.Show("Contact Number is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtb7House_Restb.Text))
            {
                MessageBox.Show("House/Street Address is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtb9Brgy_Restb.Text))
            {
                MessageBox.Show("Barangay is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtb10city_Restb.Text))
            {
                MessageBox.Show("Municipality/City is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for username and password for the new resident
            string username = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a username for this resident:", "Create Account", "");
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a password for this resident:", "Create Account", "");
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save to database
            bool success = DatabaseHelper.RegisterResident(
                username, password,
                txtb1FN_Residenttb.Text.Trim(),
                txtb2MN_Residenttb.Text.Trim(),
                txtb3LN_Residenttb.Text.Trim(),
                dateTimePicker1_Restb.Value,
                txtb5CN_Restb.Text.Trim(),
                txtb6EA_Restb.Text.Trim(),
                txtb7House_Restb.Text.Trim(),
                txtb8Purok_Restb.Text.Trim(),
                txtb9Brgy_Restb.Text.Trim(),
                txtb10city_Restb.Text.Trim(),
                txtb11Province_Restb.Text.Trim(),
                txtb12Postal_Restb.Text.Trim(),
                cb4HouseRole_Restb.SelectedItem?.ToString() ?? "Not Applicable",
                cb3ResStat_Restb.SelectedItem?.ToString() ?? "Not Applicable",
                (int)numericUpDownHM_Restb.Value
            );

            if (success)
            {
                MessageBox.Show("Resident encoded successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearForm()
        {
            txtb1FN_Residenttb.Clear();
            txtb2MN_Residenttb.Clear();
            txtb3LN_Residenttb.Clear();
            txtb5CN_Restb.Clear();
            txtb6EA_Restb.Clear();
            txtb7House_Restb.Clear();
            txtb8Purok_Restb.Clear();
            txtb9Brgy_Restb.Clear();
            txtb10city_Restb.Clear();
            txtb11Province_Restb.Clear();
            txtb12Postal_Restb.Clear();
            dateTimePicker1_Restb.Value = DateTime.Today;
            cb1CivilSt_Restb.SelectedIndex = -1;
            cb2Sex_Restb.SelectedIndex = -1;
            cb3ResStat_Restb.SelectedIndex = -1;
            cb4HouseRole_Restb.SelectedIndex = -1;
            numericUpDownHM_Restb.Value = 0;
        }
    }
}