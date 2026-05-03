using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class SubmitReport : Form
    {
        public SubmitReport()
        {
            InitializeComponent();
        }

        #region UploadFile

        // Store the selected file path
        private string selectedIDFilePath = "";
        private void btUploadID_Click(object sender, EventArgs e)
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

                // Change button text to show file is selected
                btUploadID.Text = "✔ File Selected — Click to Replace";
                btUploadID.BackColor = Color.FromArgb(220, 240, 230);
                btUploadID.ForeColor = Color.FromArgb(0, 80, 64);
            }
        }
        #endregion


    }
}

