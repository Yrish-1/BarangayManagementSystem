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

        #region DLL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        #region Color Title Bar

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_CAPTION_COLOR = 35;  // title bar color
        private const int DWMWA_BORDER_COLOR = 34;   // border color

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetGoldTitleBar();
        }

        private void SetGoldTitleBar()
        {
            int goldBGR = ColorToBGR(Color.Gold);
            DwmSetWindowAttribute(this.Handle, DWMWA_CAPTION_COLOR, ref goldBGR, sizeof(int));
            DwmSetWindowAttribute(this.Handle, DWMWA_BORDER_COLOR, ref goldBGR, sizeof(int));
        }

        private int ColorToBGR(Color color)
        {
            return color.B << 16 | color.G << 8 | color.R;
        }
        #endregion

        #region Password
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
        #endregion

        #region LogInButton
        private void bt3LogIn_Click(object sender, EventArgs e)
        {
            //hide Form 1
            this.Hide();
            //create an instance of Form 3
            ResidentForm3 f2 = new ResidentForm3();
            //show Form 2
            f2.ShowDialog();
            //dispose Form 2 after it is closed
            f2 = null;
            //show form1 again

        }

        #endregion

        private void BarTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #region RegistrationButton
        private void bt4Reg_Click(object sender, EventArgs e)
        {
            //hide Form 1
            this.Hide();
            //create an instance of Form 3
            RegistrationForm2 f2 = new RegistrationForm2();
            //show Form 2
            f2.ShowDialog();
            //dispose Form 2 after it is closed
            f2 = null;
            //show form1 again
        }

        #endregion

    }
}
