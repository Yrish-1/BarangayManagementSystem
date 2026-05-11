using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ManageStaffAdF5 : Form
    {
        private DataGridView dgvStaff;
        private List<(int UserId, string Username, string Role)> _staff = new();

        public ManageStaffAdF5()
        {
            InitializeComponent();
            this.Load += ManageStaffAdF5_Load;
        }

        private void ManageStaffAdF5_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadStaff();
            WireEvents();
        }

        private void SetupGrid()
        {
            dgvStaff = new DataGridView();
            dgvStaff.Dock = DockStyle.Fill;
            dgvStaff.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvStaff.BorderStyle = BorderStyle.None;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToDeleteRows = false;
            dgvStaff.ReadOnly = true;
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStaff.MultiSelect = false;
            dgvStaff.RowTemplate.Height = 35;

            dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold;
            dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            dgvStaff.ColumnHeadersHeight = 35;
            dgvStaff.EnableHeadersVisualStyles = false;
            dgvStaff.DefaultCellStyle.Font = new Font("Arial Narrow", 10f);
            dgvStaff.DefaultCellStyle.BackColor = Color.AliceBlue;
            dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;

            dgvStaff.Columns.Add("ColUserId", "ID");
            dgvStaff.Columns.Add("ColUsername", "Username");
            dgvStaff.Columns.Add("ColRole", "Role");

            dgvStaff.Columns["ColUserId"].FillWeight = 10;
            dgvStaff.Columns["ColUsername"].FillWeight = 50;
            dgvStaff.Columns["ColRole"].FillWeight = 40;

            // Add buttons to panel8 (bottom bar)
            Button btnAdd = new Button();
            btnAdd.Text = "+ ADD STAFF";
            btnAdd.BackColor = Color.FromArgb(0, 64, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnAdd.Location = new Point(15, 9);
            btnAdd.Size = new Size(150, 30);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Click += BtnAdd_Click;

            Button btnDelete = new Button();
            btnDelete.Text = "✖ DELETE";
            btnDelete.BackColor = Color.Maroon;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnDelete.Location = new Point(175, 9);
            btnDelete.Size = new Size(150, 30);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Click += BtnDelete_Click;

            Button btnResetPass = new Button();
            btnResetPass.Text = "🔑 RESET PASSWORD";
            btnResetPass.BackColor = Color.DarkGoldenrod;
            btnResetPass.ForeColor = Color.White;
            btnResetPass.FlatStyle = FlatStyle.Flat;
            btnResetPass.FlatAppearance.BorderSize = 0;
            btnResetPass.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnResetPass.Location = new Point(335, 9);
            btnResetPass.Size = new Size(180, 30);
            btnResetPass.Cursor = Cursors.Hand;
            btnResetPass.Click += BtnResetPass_Click;

            panel8.Controls.Add(btnAdd);
            panel8.Controls.Add(btnDelete);
            panel8.Controls.Add(btnResetPass);

            panel7.Controls.Add(dgvStaff);
        }

        private void WireEvents()
        {
            txtbSearch_ReportQueue.TextChanged += (s, e) => FilterStaff();
            cbAllStatus_ReportsQueue.SelectedIndexChanged += (s, e) => FilterStaff();
        }

        private void LoadStaff()
        {
            _staff = DatabaseHelper.GetAllStaff();
            PopulateGrid(_staff);
        }

        private void PopulateGrid(List<(int UserId, string Username, string Role)> list)
        {
            dgvStaff.Rows.Clear();
            foreach (var s in list)
                dgvStaff.Rows.Add(s.UserId, s.Username, s.Role);
        }

        private void FilterStaff()
        {
            string keyword = txtbSearch_ReportQueue.Text.Trim().ToLower();
            var filtered = _staff.FindAll(s =>
                string.IsNullOrEmpty(keyword) ||
                s.Username.ToLower().Contains(keyword));
            PopulateGrid(filtered);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form addForm = new Form();
            addForm.Text = "Add Staff Account";
            addForm.Size = new Size(400, 230);
            addForm.StartPosition = FormStartPosition.CenterParent;
            addForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            addForm.BackColor = Color.WhiteSmoke;

            Label lblUser = new Label();
            lblUser.Text = "Username:";
            lblUser.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblUser.Location = new Point(20, 20);
            lblUser.AutoSize = true;

            TextBox txtUser = new TextBox();
            txtUser.Location = new Point(20, 45);
            txtUser.Width = 340;
            txtUser.Font = new Font("Arial Narrow", 10f);

            Label lblPass = new Label();
            lblPass.Text = "Password:";
            lblPass.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            lblPass.Location = new Point(20, 80);
            lblPass.AutoSize = true;

            TextBox txtPass = new TextBox();
            txtPass.Location = new Point(20, 105);
            txtPass.Width = 340;
            txtPass.Font = new Font("Arial Narrow", 10f);
            txtPass.PasswordChar = '*';

            Button btnSave = new Button();
            btnSave.Text = "CREATE";
            btnSave.BackColor = Color.FromArgb(0, 64, 0);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnSave.Location = new Point(20, 145);
            btnSave.Size = new Size(120, 35);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += (s, ev) =>
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password are required.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = DatabaseHelper.AddStaff(username, password);
                if (success)
                {
                    MessageBox.Show("Staff account created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addForm.Close();
                    LoadStaff();
                }
                else
                    MessageBox.Show("Username already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

            Button btnCancel = new Button();
            btnCancel.Text = "CANCEL";
            btnCancel.BackColor = Color.Maroon;
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Arial Narrow", 10f, FontStyle.Bold);
            btnCancel.Location = new Point(150, 145);
            btnCancel.Size = new Size(120, 35);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, ev) => addForm.Close();

            addForm.Controls.AddRange(new Control[] {
                lblUser, txtUser, lblPass, txtPass, btnSave, btnCancel
            });

            addForm.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff account to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["ColUserId"].Value);
            string username = dgvStaff.SelectedRows[0].Cells["ColUsername"].Value.ToString();

            var confirm = MessageBox.Show($"Delete staff account '{username}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                DatabaseHelper.DeleteUser(userId);
                MessageBox.Show("Staff account deleted.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStaff();
            }
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            if (dgvStaff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a staff account first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvStaff.SelectedRows[0].Cells["ColUserId"].Value);
            string username = dgvStaff.SelectedRows[0].Cells["ColUsername"].Value.ToString();

            string newPass = Microsoft.VisualBasic.Interaction.InputBox(
                $"Enter new password for '{username}':", "Reset Password", "");

            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Password cannot be empty.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper.ResetPassword(userId, newPass);
            MessageBox.Show("Password reset successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}