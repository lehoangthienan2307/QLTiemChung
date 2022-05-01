using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTTK2.KHACHHANG;
namespace PTTK2
{
    public partial class InterfaceKH : Form
    {
        private KhachHang _kh;
        private Login _login;
        public InterfaceKH(Login login,KhachHang kh)
        {
            _login = login;
            _kh = kh;
            InitializeComponent();

            label1.Text = _kh.HoTen;

            FormClosing += InterfaceKH_FormClosing;
        }

        private void InterfaceKH_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            DKTC dktc = new DKTC(this,_kh);
            dktc.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            DMVC dktc = new DMVC(this, _kh);
            dktc.Show();
        }
    }
}
