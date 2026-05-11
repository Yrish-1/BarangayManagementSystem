using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class AnnouncementsBrgyStffF4 : Form
    {
        private DataGridView dgvAnnouncements;
        private List<(int Id, string Title, string Content, string DatePosted, string PostedBy)> _announcements = new();

        public AnnouncementsBrgyStffF4()
        {
            InitializeComponent();
            this.Load += AnnouncementsBrgyStffF4_Load;
        }

        private void AnnouncementsBrgyStffF4_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadAnnouncements();
            WireEvents();

            // Staff can only view — rename Edit button to Refresh
            btEdit.Text = "Refresh";
            btEdit.FillColor = Color.MidnightBlue;
            btEdit.Click += (s, ev) => LoadAnnouncements();
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
        }

        private void WireEvents()
        {
            txtbSearchAnnouncements.TextChanged += (s, e) => FilterAnnouncements();
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
    }
}