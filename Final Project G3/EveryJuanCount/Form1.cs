using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace EveryJuanCount
{
    public partial class LogInForm1 : Form
    {
        public LogInForm1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EJC_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void UsernameTB1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void bt1ShowPass_Click(object sender, EventArgs e)
        {
            if (txtB2Password.PasswordChar == '*')
            {
                bt2HidePass.BringToFront();
                txtB2Password.PasswordChar = '\0';
            }
        }

        private void bt2HidePass_Click(object sender, EventArgs e)
        {
            if (txtB2Password.PasswordChar == '\0')
            {
                bt1ShowPass.BringToFront();
                txtB2Password.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtB2Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt3LogIn_Click(object sender, EventArgs e)
        {
            //hide Form 1
            this.Hide();
            //create an instance of Form 3
            ResidentsForm3 f2 = new ResidentsForm3();
            //show Form 2
            f2.ShowDialog();
            //dispose Form 2 after it is closed
            f2 = null;
            //show form1 again

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hide Form 1
            this.Hide();
            //create an instance of Form 2
            RegistrationForm2 f2 = new RegistrationForm2();
            //show Form 2
            f2.ShowDialog();
            //dispose Form 2 after it is closed
            f2 = null;
            //show form1 again
            this.Show();
        }

        private void bt5Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignInLb6_Click(object sender, EventArgs e)
        {

        }

        private void btminimizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BarTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
