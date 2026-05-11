using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EveryJuanCount
{
    public partial class SettingsAdF5 : Form
    {
        public SettingsAdF5()
        {
            InitializeComponent();
        }

        #region Change Password
        private void btChangePAssword_Click(object sender, EventArgs e)
        {
            string current = CurrentPass.Text.Trim();
            string newPass = NewPass.Text.Trim();
            string confirm = ConNewPass.Text.Trim();

            if (string.IsNullOrEmpty(current) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("All password fields are required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass != confirm)
            {
                MessageBox.Show("New password and confirm password do not match.", "Mismatch",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(newPass, @"[0-9]"))
            {
                MessageBox.Show("Password must contain at least one number.", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(newPass, @"[!@#$%^&*]"))
            {
                MessageBox.Show("Password must contain at least one special character (!@#$%).", "Weak Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass == current)
            {
                MessageBox.Show("New password must be different from current password.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = DatabaseHelper.ChangePassword(SessionData.CurrentUsername, current, newPass);
            if (success)
            {
                MessageBox.Show("Password changed successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CurrentPass.Clear();
                NewPass.Clear();
                ConNewPass.Clear();
            }
            else
            {
                MessageBox.Show("Current password is incorrect.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Password Show/Hide
        private void btShowCurrentPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '*')
            {
                btHideCurrentPass_SettingsF5.BringToFront();
                CurrentPass.PasswordChar = '\0';
            }
        }

        private void btHideCurrentPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '\0')
            {
                btShowCurrentPass_SettingsF5.BringToFront();
                CurrentPass.PasswordChar = '*';
            }
        }

        private void btShowNewPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '*')
            {
                btHideNewPass_SettingsF5.BringToFront();
                NewPass.PasswordChar = '\0';
            }
        }

        private void btHideNewPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '\0')
            {
                btShowNewPass_SettingsF5.BringToFront();
                NewPass.PasswordChar = '*';
            }
        }

        private void btShowConNewPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '*')
            {
                btHideConNewPass_SettingsF5.BringToFront();
                ConNewPass.PasswordChar = '\0';
            }
        }

        private void btHideConNewPass_SettingsF5_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '\0')
            {
                btShowConNewPass_SettingsF5.BringToFront();
                ConNewPass.PasswordChar = '*';
            }
        }
        #endregion
    }
}