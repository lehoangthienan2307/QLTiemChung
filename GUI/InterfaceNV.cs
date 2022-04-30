using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTTK2.NHANVIEN;

namespace PTTK2
{
    public partial class InterfaceNV : Form
    {
        private Login _login;
        private NhanVien _nv;
        public InterfaceNV(Login login,NhanVien nv)
        {
            _login = login;
            _nv = nv;
            InitializeComponent();

            label1.Text = _nv.HoTen;
            FormClosing += InterfaceNV_FormClosing;
        }

        private void InterfaceNV_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _login.Show();
        }


        /// <summary>
        /// Nút xem lịch làm việc cá nhân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            XLCN xlcn = new XLCN(_nv.MaNV);
            xlcn.Show();
        }
    }
}
