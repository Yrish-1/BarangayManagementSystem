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
    public partial class ResidentsForm3 : Form
    {
        public ResidentsForm3()
        {
            InitializeComponent();
            this.Resize += ResidentForm3_Resize;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void BarTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuVertical_Paint_1(object sender, PaintEventArgs e)
        {

        }


        //To open Forms In the Panel
        private void OpenFormInPanel(object childForm)
        {

            if (this.ResForm3Panel.Controls.Count > 0)
                this.ResForm3Panel.Controls.RemoveAt(0);

            Form cf = childForm as Form;
            cf.Dock = DockStyle.Fill;
            cf.TopLevel = false;
            this.ResForm3Panel.Controls.Add(cf);
            this.ResForm3Panel.Tag = cf;
            cf.Show();
        }

        private void btDashboard_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new Dashboard_ResF3());
        }

        private void btMyProfile_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new MyProfile_ResF3());
        }



        private void ResForm3Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ResidentForm3_Load(object sender, EventArgs e)
        {
            AdjustLayout();
            OpenFormInPanel(new Dashboard_ResF3());
        }

        private void ResidentForm3_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int sidebarWidth = MenuVertical.Width;

            // Top bar
            BarTitle.Location = new Point(0, 0);
            BarTitle.Width = this.ClientSize.Width;

            // Sidebar
            MenuVertical.Location = new Point(0, BarTitle.Bottom);
            MenuVertical.Height = this.ClientSize.Height - BarTitle.Bottom;

            // Content panel
            ResForm3Panel.Location = new Point(MenuVertical.Right, BarTitle.Bottom);
            ResForm3Panel.Size = new Size(
                this.ClientSize.Width - MenuVertical.Right,
                this.ClientSize.Height - BarTitle.Bottom
            );

            // Logo panel fixed at top
            pnEJC.Location = new Point(1, 27);

            pnButtons.Location = new Point(2, pnEJC.Bottom + 25);


            // Log Out always at bottom
            btLogOut.Location = new Point(1, MenuVertical.Height - btLogOut.Height - 1);

        }
        private void BarTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnslidebar_Click_1(object sender, EventArgs e)
        {
            MenuVertical.Width = MenuVertical.Width == 233 ? 50 : 233;
            AdjustLayout();

        }

        private void btLogOut_Click(object sender, EventArgs e)
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
    }
}
