using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EveryJuanCount
{
    public partial class SubmitReportBrgyStffF4 : Form
    {
        public SubmitReportBrgyStffF4()
        {
            InitializeComponent();
        }

        private string selectedFilePath = "";
        private void btUploadFile_Click(object sender, EventArgs e)
        {

            // 1. Open the dialog FIRST and check if user confirmed
            if (openFile.ShowDialog() != DialogResult.OK)
                return; // user cancelled — do nothing

            selectedFilePath = openFile.FileName;

            // 2. Get file info
            FileInfo fileInfo = new FileInfo(selectedFilePath);
            double fileSizeKB = fileInfo.Length / 1024.0;

            // 3. Check file size — max 5MB
            if (fileInfo.Length > 5 * 1024 * 1024)
            {
                MessageBox.Show(
                    "File is too large. Maximum allowed size is 5MB.",
                    "File Too Large",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                selectedFilePath = "";
                return;
            }

            // 4. Show file name and size
            lbFile.Text = fileInfo.Name + " (" + fileSizeKB.ToString("F1") + " KB)";
            lbFile.ForeColor = Color.FromArgb(0, 45, 114);

            // 5. Check extension (optional — use if you need to filter by type)
            string ext = Path.GetExtension(selectedFilePath).ToLower();

            // 6. Update button appearance
            // Update button appearance
            btUploadFile.Text = "✔ File Selected — Click to Replace";
            btUploadFile.Font = new Font(btUploadFile.Font.FontFamily, 8f, FontStyle.Regular);
            btUploadFile.BackColor = Color.FromArgb(220, 240, 230);
            btUploadFile.ForeColor = Color.FromArgb(0, 80, 64);
        }

        private void btSubmit_ReportF4_Click(object sender, EventArgs e)
        {
            // Check if declaration checkbox is checked
            if (!chkb1Confirm_ReportF4.Checked)
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
            if (string.IsNullOrEmpty(selectedFilePath))
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
            "Report submitted successfully!\n\n" +
            "Please wait for the Reply and further instructions.\n" +
            "You will be notified once your concern is addressed.",
            "Registration Submitted",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
            return;
        }

        private void MoveIn_Click(object sender, EventArgs e)
        {

        }
    }
}


