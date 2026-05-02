using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ResidentsForm : Form
    {
        public ResidentsForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnslidebar_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 50;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void btCloseApp_Click(object sender, EventArgs e)
        {
            // Go back to Login Form
            var form1 = Application.OpenForms.OfType<LogInForm1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.WindowState = FormWindowState.Normal; // Restore if minimized
                form1.Show();
                form1.BringToFront();
                form1.Focus();                              // Ensure it gets focus
            }
            else
            {
                new LogInForm1().Show();
            }
            this.Close();
        }

        private void btMaximizeApp_Click(object sender, EventArgs e)
        {
            
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btMaximizeApp.Text = "🗗"; // restore icon
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btMaximizeApp.Text = "🗖"; // maximize icon
            }
        }

        private void btminimizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
