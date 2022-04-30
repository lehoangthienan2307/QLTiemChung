using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTTK2.KHACHHANG;

namespace PTTK2
{
    public partial class DK : Form
    {
        private Login _login;
        private KhachHang _newKH;
        public DK(Login login)
        {
            _login = login;
            InitializeComponent();

            FormClosing += DK_FormClosing;
        }

        private void DK_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        /// <summary>
        /// nút đăng ký khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Bus_KhachHang.insert(textBox1.Text, checkBox1.Checked ? "Nữ" : "Nam", dateTimePicker1.Value.Date, textBox2.Text, textBox3.Text))
            {
                Close();
                DK_FormClosing(null,null);
            }
        }
    }
}
