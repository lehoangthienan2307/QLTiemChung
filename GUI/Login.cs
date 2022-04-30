using System.Data.SqlClient;
using PTTK2.KHACHHANG;
using PTTK2.NHANVIEN;
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

        /// <summary>
        /// Button đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            loginIdentify();
        }


        /// <summary>
        /// lấy thông tin trả tra từ layer nghiệp vụ để kiểm tra đăng nhập
        /// </summary>
        private void loginIdentify()
        {
            // người đăng nhập chọn role khách hàng
            if (comboBox1.SelectedIndex == 0)
            {
                int isValid = Bus_KhachHang.login(textBox1.Text, textBox2.Text);
                if (isValid == 1)
                {
                    MessageBox.Show("Chào mừng khách hàng", "Notification");
                    // create KhachHang class on successful login
                    KhachHang kh = Bus_KhachHang.getKhachHang(textBox1.Text);

                    InterfaceKH itfKH = new InterfaceKH(this,kh);
                    Hide();
                    itfKH.Show();

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Alert");
                }
            }
            //người đăng nhập chọn role nhân viên
            else
            {
                int isValid = Bus_NhanVien.login(textBox1.Text, textBox2.Text);
                if (isValid == 1)
                {
                    MessageBox.Show("Chào mừng nhân viên", "Notification");
                    // create NhanVien object on succesful login
                    NhanVien nv = Bus_NhanVien.GetNhanVien(textBox1.Text);

                    InterfaceNV itfNV = new InterfaceNV(this, nv);
                    Hide();
                    itfNV.Show();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Alert");
                }
            }
        }


        /// <summary>
        ///  Nút đăng ký khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DK dK = new DK(this);
            Hide();
            dK.Show();
        }
    }

}