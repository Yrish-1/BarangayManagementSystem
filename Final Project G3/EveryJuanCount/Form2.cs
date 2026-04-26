using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace EveryJuanCount
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void bt1ExitForm2_Click(object sender, EventArgs e)
        {
            var form1 = Application.OpenForms.OfType<LogInForm1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.Show();
                form1.BringToFront();
            }
            else
            {
                new LogInForm1().Show();
            }
            this.Close();
        }

        private void Lb4WeCount_Fr2_Click(object sender, EventArgs e)
        {

        }

        private void SignInLb6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb2ResLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
