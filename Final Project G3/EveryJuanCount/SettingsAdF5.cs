using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class SettingsAdF5 : Form
    {
        public SettingsAdF5()
        {
            InitializeComponent();
        }

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
