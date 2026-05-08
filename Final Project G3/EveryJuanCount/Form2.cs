using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace EveryJuanCount
{
    public partial class RegistrationForm2 : Form
    {
        public RegistrationForm2()
        {
            InitializeComponent();
        }

        #region FormClosing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Show Login Form when this form closes
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
        }
        #endregion

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

        #region SignInHereButtonRestb 
        private void btSignInHere_Restb_Click(object sender, EventArgs e)
        {
            // Go back to Login Form
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

        #endregion

        #region PasswordRestb
        private void btShowPassword_Restb_Click(object sender, EventArgs e)
        {
            if (txtb14Password_Restb.PasswordChar == '*')
            {
                btHidePassword_Restb.BringToFront();
                txtb14Password_Restb.PasswordChar = '\0';
            }
        }

        private void btHidePassword_Restb_Click(object sender, EventArgs e)
        {
            if (txtb14Password_Restb.PasswordChar == '\0')
            {
                btShowPassword_Restb.BringToFront();
                txtb14Password_Restb.PasswordChar = '*';
            }

        }

        private void btShowPassConfirm_Restb_Click(object sender, EventArgs e)
        {
            if (txtb15ConfirmPass_Restb.PasswordChar == '*')
            {
                btHidePassConfirm_Restb.BringToFront();
                txtb15ConfirmPass_Restb.PasswordChar = '\0';
            }
        }

        private void btHidePassConfirm_Restb_Click(object sender, EventArgs e)
        {
            if (txtb15ConfirmPass_Restb.PasswordChar == '\0')
            {
                btShowPassConfirm_Restb.BringToFront();
                txtb15ConfirmPass_Restb.PasswordChar = '*';
            }
        }
        #endregion

        #region SubmitbuttonRestb
        private void btSubmit_Restb_Click_1(object sender, EventArgs e)
        {
            // Check if declaration checkbox is checked
            if (!chkb1Confirm_Restb.Checked)
            {
                MessageBox.Show(
                    "Please confirm the declaration before submitting.",
                    "Declaration Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Check if ID file was uploaded
            if (string.IsNullOrEmpty(selectedIDFilePath))
            {
                MessageBox.Show(
                    "Please upload a photo or file of your valid ID.",
                    "ID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Show success message
            MessageBox.Show(
                "Registration submitted successfully!\n\n" +
                "Please wait for barangay admin approval.\n" +
                "You will be notified once your account is activated.",
                "Registration Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Go back to Login Form
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
        #endregion

        #region UploadFileRestb
        // Store the selected file path
        private string selectedIDFilePath = "";
        private void btIDUpload_Restb_Click(object sender, EventArgs e)
        {
            // Open the file picker
            ofdID.Filter = "Image and PDF Files|*.jpg;*.jpeg;*.png;*.pdf";
            ofdID.Title = "Select your Valid ID";

            if (ofdID.ShowDialog() == DialogResult.OK)
            {
                selectedIDFilePath = ofdID.FileName;

                // Get file info
                FileInfo fileInfo = new FileInfo(selectedIDFilePath);
                double fileSizeKB = fileInfo.Length / 1024.0;

                // Check file size — max 5MB
                if (fileInfo.Length > 5 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "File is too large. Maximum allowed size is 5MB.",
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    selectedIDFilePath = "";
                    return;
                }
                // Show file name and size
                lblFileName.Text = fileInfo.Name +
                                        " (" + fileSizeKB.ToString("F1") + " KB)";
                lblFileName.ForeColor = Color.FromArgb(0, 45, 114);

                // Check if it's an image or PDF
                string ext = Path.GetExtension(selectedIDFilePath).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                {
                    // Show image preview
                    picb1IDUploaded_Restb.Image = Image.FromFile(selectedIDFilePath);
                    picb1IDUploaded_Restb.Visible = true;
                    lblFileName.Text = "✔ " + lblFileName.Text;
                }
                else if (ext == ".pdf")
                {
                    // PDF — no image preview, show icon text instead
                    picb1IDUploaded_Restb.Visible = false;
                    lblFileName.Text = "📄 " + fileInfo.Name +
                                           " (" + fileSizeKB.ToString("F1") + " KB)";
                }

                // Change button text to show file is selected
                btIDUpload_Restb.Text = "✔ File Selected — Click to Replace";
                btIDUpload_Restb.BackColor = Color.FromArgb(220, 240, 230);
                btIDUpload_Restb.ForeColor = Color.FromArgb(0, 80, 64);
            }
        }

        #endregion

        #region PasswordBrgyStftb
        private void bt1ShowPass_BrgyStftb_Click(object sender, EventArgs e)
        {
            if (txtb12Password_BrgyStftb.PasswordChar == '*')
            {
                bt2HidePass_BrgyStftb.BringToFront();
                txtb12Password_BrgyStftb.PasswordChar = '\0';
            }
        }

        private void bt2HidePass_BrgyStftb_Click(object sender, EventArgs e)
        {
            if (txtb12Password_BrgyStftb.PasswordChar == '\0')
            {
                bt1ShowPass_BrgyStftb.BringToFront();
                txtb12Password_BrgyStftb.PasswordChar = '*';
            }
        }

        private void bt3ConShowPass_BrgyStftb_Click(object sender, EventArgs e)
        {
            if (txtb13ConfimPass_BrgyStftb.PasswordChar == '*')
            {
                bt4ConHidePass_BrgyStftb.BringToFront();
                txtb13ConfimPass_BrgyStftb.PasswordChar = '\0';
            }
        }

        private void bt4ConHidePass_BrgyStftb_Click(object sender, EventArgs e)
        {
            if (txtb13ConfimPass_BrgyStftb.PasswordChar == '\0')
            {
                bt3ConShowPass_BrgyStftb.BringToFront();
                txtb13ConfimPass_BrgyStftb.PasswordChar = '*';
            }
        }
        #endregion

        #region UploadFileBrgyStftb
        private void btUploadID_BrgyStftb_Click(object sender, EventArgs e)
        {
            // Open the file picker
            ofdID.Filter = "Image and PDF Files|*.jpg;*.jpeg;*.png;*.pdf";
            ofdID.Title = "Select your Valid ID";

            if (ofdID.ShowDialog() == DialogResult.OK)
            {
                selectedIDFilePath = ofdID.FileName;

                // Get file info
                FileInfo fileInfo = new FileInfo(selectedIDFilePath);
                double fileSizeKB = fileInfo.Length / 1024.0;

                // Check file size — max 5MB
                if (fileInfo.Length > 5 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "File is too large. Maximum allowed size is 5MB.",
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    selectedIDFilePath = "";
                    return;
                }
                // Show file name and size
                lb1FileName_BrgyStftb.Text = fileInfo.Name +
                                        " (" + fileSizeKB.ToString("F1") + " KB)";
                lb1FileName_BrgyStftb.ForeColor = Color.FromArgb(0, 45, 114);

                // Check if it's an image or PDF
                string ext = Path.GetExtension(selectedIDFilePath).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                {
                    // Show image preview
                    picb1ID_BrgyStftb.Image = Image.FromFile(selectedIDFilePath);
                    picb1ID_BrgyStftb.Visible = true;
                    lb1FileName_BrgyStftb.Text = "✔ " + lb1FileName_BrgyStftb.Text;
                }
                else if (ext == ".pdf")
                {
                    // PDF — no image preview, show icon text instead
                    picb1IDUploaded_Restb.Visible = false;
                    lb1FileName_BrgyStftb.Text = "📄 " + fileInfo.Name +
                                           " (" + fileSizeKB.ToString("F1") + " KB)";
                }

                // Change button text to show file is selected
                btUploadID_BrgyStftb.Text = "✔ File Selected — Click to Replace";
                btUploadID_BrgyStftb.BackColor = Color.FromArgb(220, 240, 230);
                btUploadID_BrgyStftb.ForeColor = Color.FromArgb(0, 80, 64);
            }
        }

        #endregion

        #region SubmitButtonBrgyStftb
        private void btSubmit_BrgyStftb_Click(object sender, EventArgs e)
        {
            // Check if declaration checkbox is checked
            if (!chkb1Confirm_BrgyStftb.Checked)
            {
                MessageBox.Show(
                    "Please confirm the declaration before submitting.",
                    "Declaration Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Check if ID file was uploaded
            if (string.IsNullOrEmpty(selectedIDFilePath))
            {
                MessageBox.Show(
                    "Please upload a photo or file of your valid ID.",
                    "ID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Show success message
            MessageBox.Show(
                "Registration submitted successfully!\n\n" +
                "Please wait for barangay admin approval.\n" +
                "You will be notified once your account is activated.",
                "Registration Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Go back to Login Form
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

        #endregion

        #region SignInHereBrgyStftb
        private void btSignInHere_BrgyStftb_Click(object sender, EventArgs e)
        {
            // Go back to Login Form
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

        #endregion

        #region PasswordAdmintb
        private void bt1ShowPassword_Admintb_Click(object sender, EventArgs e)
        {
            if (txtb15Passwors_Admintb.PasswordChar == '*')
            {
                bt2HidePassword_Admintb.BringToFront();
                txtb15Passwors_Admintb.PasswordChar = '\0';
            }

        }

        private void bt2HidePassword_Admintb_Click(object sender, EventArgs e)
        {
            if (txtb15Passwors_Admintb.PasswordChar == '\0')
            {
                bt1ShowPassword_Admintb.BringToFront();
                txtb15Passwors_Admintb.PasswordChar = '*';
            }

        }

        private void bt3ConShowPass_Admintb_Click(object sender, EventArgs e)
        {
            if (txtb16ConPassword_Admintb.PasswordChar == '*')
            {
                bt4ConHidePass_Admintb.BringToFront();
                txtb16ConPassword_Admintb.PasswordChar = '\0';
            }
        }

        private void bt4ConHidePass_Admintb_Click(object sender, EventArgs e)
        {
            if (txtb16ConPassword_Admintb.PasswordChar == '\0')
            {
                bt3ConShowPass_Admintb.BringToFront();
                txtb16ConPassword_Admintb.PasswordChar = '*';
            }

        }

        #endregion

        #region UploadFileAdmintb
        private void btUploadID_Admintb_Click(object sender, EventArgs e)
        {
            // Open the file picker
            ofdID.Filter = "Image and PDF Files|*.jpg;*.jpeg;*.png;*.pdf";
            ofdID.Title = "Select your Valid ID";

            if (ofdID.ShowDialog() == DialogResult.OK)
            {
                selectedIDFilePath = ofdID.FileName;

                // Get file info
                FileInfo fileInfo = new FileInfo(selectedIDFilePath);
                double fileSizeKB = fileInfo.Length / 1024.0;

                // Check file size — max 5MB
                if (fileInfo.Length > 5 * 1024 * 1024)
                {
                    MessageBox.Show(
                        "File is too large. Maximum allowed size is 5MB.",
                        "File Too Large",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    selectedIDFilePath = "";
                    return;
                }
                // Show file name and size
                lb35FileName_Admintb.Text = fileInfo.Name +
                                        " (" + fileSizeKB.ToString("F1") + " KB)";
                lb35FileName_Admintb.ForeColor = Color.FromArgb(0, 45, 114);

                // Check if it's an image or PDF
                string ext = Path.GetExtension(selectedIDFilePath).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                {
                    // Show image preview
                    picbIDUpload_Admintb.Image = Image.FromFile(selectedIDFilePath);
                    picbIDUpload_Admintb.Visible = true;
                    lb35FileName_Admintb.Text = "✔ " + lb35FileName_Admintb.Text;
                }
                else if (ext == ".pdf")
                {
                    // PDF — no image preview, show icon text instead
                    picbIDUpload_Admintb.Visible = false;
                    lb35FileName_Admintb.Text = "📄 " + fileInfo.Name +
                                           " (" + fileSizeKB.ToString("F1") + " KB)";
                }

                // Change button text to show file is selected
                btUploadID_Admintb.Text = "✔ File Selected — Click to Replace";
                btUploadID_Admintb.BackColor = Color.FromArgb(220, 240, 230);
                btUploadID_Admintb.ForeColor = Color.FromArgb(0, 80, 64);
            }
        }

        #endregion

        #region SubmitButtonAdmintb
        private void btSubmit_Admintb_Click(object sender, EventArgs e)
        {
            // Check if declaration checkbox is checked
            if (!chkbConfirm_Admintb.Checked)
            {
                MessageBox.Show(
                    "Please confirm the declaration before submitting.",
                    "Declaration Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Check if ID file was uploaded
            if (string.IsNullOrEmpty(selectedIDFilePath))
            {
                MessageBox.Show(
                    "Please upload a photo or file of your valid ID.",
                    "ID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Show success message
            MessageBox.Show(
                "Registration submitted successfully!",
                "Registration Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Go back to Login Form
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

        #endregion 

        private void BarTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void chkb1Confirm_Restb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1DOB_Admintb_ValueChanged(object sender, EventArgs e)
        {

            // Auto-compute age
            DateTime birthDate = dateTimePicker1DOB_Admintb.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            // Adjust if birthday hasn't occurred yet this year
            if (birthDate.Date > today.AddYears(-age))
                age--;

            // Display in the Age textbox
            txtb4Age_Admintb.Text = age.ToString();

        }

        private void dateTimePicker1_Restb_ValueChanged(object sender, EventArgs e)
        {
            // Auto-compute age
            DateTime birthDate = dateTimePicker1_Restb.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            // Adjust if birthday hasn't occurred yet this year
            if (birthDate.Date > today.AddYears(-age))
                age--;

            // Display in the Age textbox
            txtb4Age_Residenttb.Text = age.ToString();
        }

        private void dateTimePicker1DOB_BrgyStftb_ValueChanged(object sender, EventArgs e)
        {
            // Auto-compute age
            DateTime birthDate = dateTimePicker1DOB_BrgyStftb.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;

            // Adjust if birthday hasn't occurred yet this year
            if (birthDate.Date > today.AddYears(-age))
                age--;

            // Display in the Age textbox
            txtb4Age_BrgyStftb.Text = age.ToString();
        }
    }
}
