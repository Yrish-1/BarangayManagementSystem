using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class AnnouncementsAdF5 : Form
    {
        private DataGridView dgvAnnouncements;
        private List<(int Id, string Title, string Content, string DatePosted, string PostedBy)> _announcements = new();

        public AnnouncementsAdF5()
        {
            InitializeComponent();
            this.Load += AnnouncementsAdF5_Load;
        }

        private void AnnouncementsAdF5_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadAnnouncements();
            WireEvents();
        }

        private void SetupGrid()
        {
            dgvAnnouncements = new DataGridView();
            dgvAnnouncements.Dock = DockStyle.Fill;
            dgvAnnouncements.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvAnnouncements.BorderStyle = BorderStyle.None;
            dgvAnnouncements.RowHeadersVisible = false;
            dgvAnnouncements.AllowUserToAddRows = false;
            dgvAnnouncements.AllowUserToDeleteRows = false;
            dgvAnnouncements.ReadOnly = true;
            dgvAnnouncements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnnouncements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnnouncements.MultiSelect = false;
            dgvAnnouncements.RowTemplate.Height = 35;

            dgvAnnouncements.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvAnnouncements.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvAnnouncements.ColumnHeadersHeight = 35;
            dgvAnnouncements.EnableHeadersVisualStyles = false;
            dgvAnnouncements.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvAnnouncements.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvAnnouncements.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            dgvAnnouncements.Columns.Add("ColId", "ID");
            dgvAnnouncements.Columns.Add("ColTitle", "Title");
            dgvAnnouncements.Columns.Add("ColContent", "Content");
            dgvAnnouncements.Columns.Add("ColDate", "Date Posted");
            dgvAnnouncements.Columns.Add("ColPostedBy", "Posted By");

            dgvAnnouncements.Columns["ColId"].FillWeight = 5;
            dgvAnnouncements.Columns["ColTitle"].FillWeight = 20;
            dgvAnnouncements.Columns["ColContent"].FillWeight = 40;
            dgvAnnouncements.Columns["ColDate"].FillWeight = 18;
            dgvAnnouncements.Columns["ColPostedBy"].FillWeight = 17;

            panel11.Controls.Add(dgvAnnouncements);

            // Wire Add button
            btAdd.Click += BtAdd_Click;
            // Wire Edit button as Delete
            btEdit.Text = "Delete";
            btEdit.FillColor = Color.Maroon;
            btEdit.Click += BtDelete_Click;

            // Wire search
            txtbSearchAnnouncements.TextChanged += (s, e) => FilterAnnouncements();
        }

        private void WireEvents()
        {
            cbAllStatus_Announcements.SelectedIndexChanged += (s, e) => FilterAnnouncements();
            cbAllCategories_Announcements.SelectedIndexChanged += (s, e) => FilterAnnouncements();
        }

        private void LoadAnnouncements()
        {
            _announcements = DatabaseHelper.GetAnnouncements();
            PopulateGrid(_announcements);
        }

        private void PopulateGrid(List<(int Id, string Title, string Content, string DatePosted, string PostedBy)> list)
        {
            dgvAnnouncements.Rows.Clear();
            foreach (var a in list)
                dgvAnnouncements.Rows.Add(a.Id, a.Title, a.Content, a.DatePosted, a.PostedBy);
        }

        private void FilterAnnouncements()
        {
            string keyword = txtbSearchAnnouncements.Text.Trim().ToLower();
            var filtered = _announcements.FindAll(a =>
                string.IsNullOrEmpty(keyword) ||
                a.Title.ToLower().Contains(keyword) ||
                a.Content.ToLower().Contains(keyword) ||
                a.PostedBy.ToLower().Contains(keyword));
            PopulateGrid(filtered);
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            // Add announcement dialog
            Form addForm = new Form();
            addForm.Text = "New Announcement";
            addForm.Size = new Size(500, 300);
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            addForm.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label();
            lblTitle.Text = "Title:";
            lblTitle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            TextBox txtTitle = new TextBox();
            txtTitle.Location = new Point(20, 45);
            txtTitle.Width = 440;
            txtTitle.Font = new Font("Arial Narrow", 10f);

            Label lblContent = new Label();
            lblContent.Text = "Content:";
            lblContent.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblContent.Location = new Point(20, 80);
            lblContent.AutoSize = true;

            TextBox txtContent = new TextBox();
            txtContent.Location = new Point(20, 105);
            txtContent.Width = 440;
            txtContent.Height = 80;
            txtContent.Multiline = true;
            txtContent.Font = new Font("Arial Narrow", 10f);

            Button btnPost = new Button();
            btnPost.Text = "POST";
            btnPost.BackColor = Color.FromArgb(0, 64, 0);
            btnPost.ForeColor = Color.White;
            btnPost.FlatStyle = FlatStyle.Flat;
            btnPost.FlatAppearance.BorderSize = 0;
            btnPost.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnPost.Location = new Point(20, 210);
            btnPost.Size = new Size(120, 35);
            btnPost.Cursor = Cursors.Hand;
            btnPost.Click += (s, ev) =>
            {
                string title = txtTitle.Text.Trim();
                string content = txtContent.Text.Trim();

                if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("Title and content are required.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatabaseHelper.AddAnnouncement(title, content, SessionData.CurrentUsername);
                MessageBox.Show("Announcement posted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                addForm.Close();
                LoadAnnouncements();
            };

            Button btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.BackColor = Color.Maroon;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnCancel.Location = new Point(155, 210);
            btnCancel.Size = new Size(120, 35);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, ev) => addForm.Close();

            addForm.Controls.AddRange(new Control[] {
                lblTitle, txtTitle, lblContent, txtContent, btnPost, btnCancel
            });

            addForm.ShowDialog();
        }

        private void BtDelete_Click(object sender, EventArgs e)
        {
            if (dgvAnnouncements.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an announcement to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvAnnouncements.SelectedRows[0].Cells["ColId"].Value);
            string title = dgvAnnouncements.SelectedRows[0].Cells["ColTitle"].Value.ToString();

            var confirm = MessageBox.Show($"Delete announcement '{title}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteAnnouncement(id);
                MessageBox.Show("Announcement deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAnnouncements();
            }
        }
    }
}