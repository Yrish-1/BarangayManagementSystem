using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class SettingsResF3 : Form
    {
        public SettingsResF3()
        {
            InitializeComponent();
            this.Load += SettingsResF3_Load;
            button3.Click += button3_Click;

            // Eye buttons
            btShowCurrentPass_SettingsF3.Click += btShowCurrentPass_SettingsF3_Click;
            btHideCurrentPass_SettingsF3.Click += btHideCurrentPass_SettingsF3_Click;
            btShowNewPass_SettingsF3.Click += btShowNewPass_SettingsF3_Click;
            btHideNewPass_SettingsF3.Click += btHideNewPass_SettingsF3_Click;
            btShowConNewPass_SettingsF3.Click += btShowConNewPass_SettingsF3_Click;
            btHideConNewPass_SettingsF3.Click += btHideConNewPass_SettingsF3_Click;
        }

        #region Load Personal Information
        private void SettingsResF3_Load(object sender, EventArgs e)
        {
            LoadResidentInfo();
        }

        private void LoadResidentInfo()
        {
            Resident r = SessionData.CurrentResident;

            // Personal Information
            textBox14.Text = r.FirstName;
            textBox13.Text = r.MiddleName;
            textBox12.Text = r.LastName;
            textBox11.Text = r.DateOfBirth.ToString("MM/dd/yyyy");
            textBox10.Text = r.Age.ToString();
            textBox9.Text = r.ContactNumber;
            textBox8.Text = r.Email;

            // Address / Household
            textBox7.Text = r.HouseStreet;
            textBox6.Text = r.Purok;
            textBox5.Text = r.Barangay;
            textBox4.Text = r.Municipality;
            textBox3.Text = r.Province;
            textBox2.Text = r.PostalCode;
            textBox1.Text = r.HouseholdRole;
            textBox15.Text = r.ResidencyStatus;
            textBox16.Text = r.HouseholdMembers.ToString();
        }
        #endregion

        #region Show/Hide Password Buttons
        private void btShowCurrentPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '*')
            {
                btHideCurrentPass_SettingsF3.BringToFront();
                CurrentPass.PasswordChar = '\0';
            }
        }

        private void btHideCurrentPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '\0')
            {
                btShowCurrentPass_SettingsF3.BringToFront();
                CurrentPass.PasswordChar = '*';
            }
        }

        private void btShowNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '*')
            {
                btHideNewPass_SettingsF3.BringToFront();
                NewPass.PasswordChar = '\0';
            }
        }

        private void btHideNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '\0')
            {
                btShowNewPass_SettingsF3.BringToFront();
                NewPass.PasswordChar = '*';
            }
        }

        private void btShowConNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '*')
            {
                btHideConNewPass_SettingsF3.BringToFront();
                ConNewPass.PasswordChar = '\0';
            }
        }

        private void btHideConNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '\0')
            {
                btShowConNewPass_SettingsF3.BringToFront();
                ConNewPass.PasswordChar = '*';
            }
        }
<<<<<<< HEAD
        #endregion

        #region Change Password
        private void button3_Click(object sender, EventArgs e)
        {
            string current = CurrentPass.Text.Trim();
            string newPass = NewPass.Text.Trim();
            string confirm = ConNewPass.Text.Trim();

            if (string.IsNullOrEmpty(current) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Please fill in all password fields.", "Missing Fields",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (current != SessionData.Password)
            {
                MessageBox.Show("Current password is incorrect.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass == current)
            {
                MessageBox.Show("New password must be different from your current password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(newPass))
            {
                MessageBox.Show(
                    "New password must:\n" +
                    "● At least 8 characters long\n" +
                    "● Contains at least one number (0–9)\n" +
                    "● Contains at least one special character (!@#$%)\n" +
                    "● Must be different from your current password",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("New password and confirm password do not match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SessionData.Password = newPass;
            MessageBox.Show("Password changed successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            CurrentPass.Text = "";
            NewPass.Text = "";
            ConNewPass.Text = "";
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;

            bool hasNumber = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsDigit(c)) hasNumber = true;
                if ("!@#$%^&*".Contains(c)) hasSpecial = true;
            }

            return hasNumber && hasSpecial;
        }
        #endregion
    }
}
=======
        #endregion 
    }

}
>>>>>>> e47a04e4267162358d9e8433f8843c6dec143062
