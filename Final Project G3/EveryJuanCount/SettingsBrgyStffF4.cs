using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class SettingsBrgyStffF4 : Form
    {
        public SettingsBrgyStffF4()
        {
            InitializeComponent();
        }


        #region ChangePAsswordButtons

        private void btShowCurrentPass_SettingsF3_Click_1(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '*')
            {
                btHideCurrentPass_SettingsF4.BringToFront();
                CurrentPass.PasswordChar = '\0';
            }
        }

        private void btHideCurrentPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (CurrentPass.PasswordChar == '\0')
            {
                btShowCurrentPass_SettingsF4.BringToFront();
                CurrentPass.PasswordChar = '*';
            }
        }

        private void btShowNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '*')
            {
                btHideNewPass_SettingsF4.BringToFront();
                NewPass.PasswordChar = '\0';
            }
        }

        private void btHideNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (NewPass.PasswordChar == '\0')
            {
                btShowNewPass_SettingsF4.BringToFront();
                NewPass.PasswordChar = '*';
            }
        }

        private void btShowConNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '*')
            {
                btHideConNewPass_SettingsF4.BringToFront();
                ConNewPass.PasswordChar = '\0';
            }
        }

        private void btHideConNewPass_SettingsF3_Click(object sender, EventArgs e)
        {
            if (ConNewPass.PasswordChar == '\0')
            {
                btShowConNewPass_SettingsF4.BringToFront();
                ConNewPass.PasswordChar = '*';
            
            }
        }
        #endregion

    }
}
