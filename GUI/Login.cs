using System.Data.SqlClient;
using PTTK2.KHACHHANG;
namespace PTTK2
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            // set default index
            comboBox1.SelectedIndex = 0;

            FormClosing += Login_FormClosing;
        }

        private void Login_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginIdentify();
        }

        private void loginIdentify()
        {
            // user is customer
            if (comboBox1.SelectedIndex == 0)
            {
                int isValid = Bus_KhachHang.login(textBox1.Text, textBox2.Text);
                if (isValid == 1)
                {
                    MessageBox.Show("Welcome", "Notification");
                    // create KhachHang class on successfull login
                    KhachHang kh = Bus_KhachHang.getInfo(textBox1.Text);

                    InterfaceKH itfKH = new InterfaceKH(this,kh);
                    itfKH.Show();

                }
                else
                {
                    MessageBox.Show("Failed to login", "Alert");
                }
            }
            else
            {

            }
        }
    }

}