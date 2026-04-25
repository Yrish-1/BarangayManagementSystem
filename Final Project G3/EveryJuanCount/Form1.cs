namespace EveryJuanCount
{
    public partial class LogInForm1 : Form
    {
        public LogInForm1()
        {
            InitializeComponent();
        }

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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bt5Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
