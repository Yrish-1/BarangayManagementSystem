using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class SubmitReport : Form
    {
        public SubmitReport()
        {
            InitializeComponent();
            this.Load += SubmitReport_Load;
            btSubmit_ReportF3.Click += btSubmit_ReportF3_Click;
            btUploadFile.Click += btUploadFile_Click;
        }

        #region Load Reporter Info
        private void SubmitReport_Load(object sender, EventArgs e)
        {
            LoadReporterInfo();
        }

        private void LoadReporterInfo()
        {
            Resident r = SessionData.CurrentResident;

            // Auto-fill reporter information from logged-in resident
            textBox15.Text = r.FirstName;
            textBox14.Text = r.MiddleName;
            textBox13.Text = r.LastName;
            txtb5ContactN_BrgyStftb.Text = r.ContactNumber;
        }
        #endregion

        #region Upload File
        private string selectedFilePath = "";

        private void btUploadFile_Click(object sender, EventArgs e)
        {
            openFile.Filter = "Image and PDF Files|*.jpg;*.jpeg;*.png;*.pdf";
            openFile.Title = "Select your Valid ID or Document";

            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            selectedFilePath = openFile.FileName;

            FileInfo fileInfo = new FileInfo(selectedFilePath);
            double fileSizeKB = fileInfo.Length / 1024.0;

            if (fileInfo.Length > 5 * 1024 * 1024)
            {
                MessageBox.Show(
                    "File is too large. Maximum allowed size is 5MB.",
                    "File Too Large",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                selectedFilePath = "";
                return;
            }

            lbFile.Text = fileInfo.Name + " (" + fileSizeKB.ToString("F1") + " KB)";
            lbFile.ForeColor = Color.FromArgb(0, 45, 114);

            btUploadFile.Text = "✔ File Selected — Click to Replace";
            btUploadFile.Font = new Font(btUploadFile.Font.FontFamily, 8f, FontStyle.Regular);
            btUploadFile.BackColor = Color.FromArgb(220, 240, 230);
            btUploadFile.ForeColor = Color.FromArgb(0, 80, 64);
        }
        #endregion

        #region Submit Report
        private void btSubmit_ReportF3_Click(object sender, EventArgs e)
        {
            // Check declaration checkbox
            if (!chkb1Confirm_ReportF3.Checked)
            {
                MessageBox.Show(
                    "Please confirm the declaration before submitting.",
                    "Declaration Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Check if ID file was uploaded
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show(
                    "Please upload a photo or file of your valid ID.",
                    "ID Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get active tab (event type)
            string eventType = TabCSubmitReport.SelectedTab.Text;

            // Get fields based on active tab
            string firstName = "";
            string middleName = "";
            string lastName = "";
            DateTime dateOfEvent = DateTime.Now;
            string additionalDetails = "";

            if (eventType == "Birth")
            {
                firstName = txtb1FN_BrgyStftb.Text.Trim();
                middleName = txtb2MN_BrgyStftb.Text.Trim();
                lastName = txtb3LN_BrgyStftb.Text.Trim();
                dateOfEvent = dateTimePicker1DOB_BrgyStftb.Value;
                additionalDetails = txtbAdditionalDits.Text.Trim();
            }
            else if (eventType == "Death")
            {
                firstName = textBox4.Text.Trim();
                middleName = textBox3.Text.Trim();
                lastName = textBox2.Text.Trim();
                dateOfEvent = dateTimePicker1.Value;
                additionalDetails = textBox1.Text.Trim();
            }
            else if (eventType == "Move In")
            {
                firstName = textBox8.Text.Trim();
                middleName = textBox7.Text.Trim();
                lastName = textBox6.Text.Trim();
                dateOfEvent = dateTimePicker2.Value;
                additionalDetails = textBox5.Text.Trim();
            }
            else if (eventType == "Move Out")
            {
                firstName = textBox12.Text.Trim();
                middleName = textBox11.Text.Trim();
                lastName = textBox10.Text.Trim();
                dateOfEvent = dateTimePicker3.Value;
                additionalDetails = textBox9.Text.Trim();
            }

            // Validate required fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show(
                    "Please fill in the First Name and Last Name of the person involved.",
                    "Required Fields",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create report object
            Report report = new Report
            {
                ReportId = SessionData.Reports.Count + 1,
                EventType = eventType,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DateOfEvent = dateOfEvent,
                AdditionalDetails = additionalDetails,
                ReporterFirstName = textBox15.Text.Trim(),
                ReporterMiddleName = textBox14.Text.Trim(),
                ReporterLastName = textBox13.Text.Trim(),
                ReporterContact = txtb5ContactN_BrgyStftb.Text.Trim(),
                RelationshipToPerson = textBox16.Text.Trim(),
                UploadedIDPath = selectedFilePath,
                Status = "Pending",
                DateSubmitted = DateTime.Now
            };

            // Save to SessionData
            SessionData.Reports.Add(report);

            // Show success message
            MessageBox.Show(
                "Report submitted successfully!\n\n" +
                "Your report is now pending review by the barangay admin.\n" +
                "You can track the status in Report History.",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Clear form
            ClearForm();
        }

        private void ClearForm()
        {
            // Clear Birth tab
            txtb1FN_BrgyStftb.Text = "";
            txtb2MN_BrgyStftb.Text = "";
            txtb3LN_BrgyStftb.Text = "";
            txtbAdditionalDits.Text = "";

            // Clear Death tab
            textBox4.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";

            // Clear Move In tab
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";

            // Clear Move Out tab
            textBox12.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";

            // Clear reporter extra fields
            textBox16.Text = "";

            // Clear file upload
            selectedFilePath = "";
            lbFile.Text = "";
            btUploadFile.Text = "Click to Upload";
            btUploadFile.BackColor = Color.AliceBlue;
            btUploadFile.ForeColor = Color.Navy;

            // Uncheck declaration
            chkb1Confirm_ReportF3.Checked = false;
        }
        #endregion
    }
}