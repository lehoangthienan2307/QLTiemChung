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
using PTTK2.GOITIEMCHUNG;

namespace PTTK2
{
    public partial class DKTC : Form
    {
        private InterfaceKH _interfaceKH;
        private KhachHang _kh;
        private KhachHang _treEm; // người thân cảu khách hàng đang sử dụng hệ thống

        private List<GoiTiemChung> _goiTiemChungList = Bus_GoiTiemChung.getGoiTiemChung();
        public DKTC(InterfaceKH interfaceKH,KhachHang kh)
        {
            _interfaceKH = interfaceKH;
            _kh = kh;
            InitializeComponent();
            FormClosing += DKTC_FormClosing;

            loadInfoToGui();
            loadGoiTiemChungToGui();
        }

        private void DKTC_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _interfaceKH.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Lấy thông tin gói tiêm chủng và hiển thị lên gui
        /// </summary>
        private void loadGoiTiemChungToGui()
        {
            foreach(GoiTiemChung gtc in _goiTiemChungList)
            {
                checkedListBox1.Items.Add(gtc.TenLoai);
            }
        }

        /// <summary>
        /// Lấy thông tin của class Khách hàng để hiển thị lên Gui
        /// </summary>
        private void loadInfoToGui()
        {
            textBox1.Text = _kh.HoTen;
            textBox2.Text = _kh.NgaySinh;
            textBox3.Text = _kh.GioiTinh;
            textBox4.Text = _kh.DiaChi;
            textBox5.Text = _kh.SDTKH;
            textBox9.Text = _kh.QuanHe;

            loadChildrenToGUI();
        }

        /// <summary>
        /// Hiện thêm thông tin nếu người dùng đăng ký tiêm cho trẻ em
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                label6.Hide();
                label7.Hide();
                label8.Hide();

                comboBox2.Hide();
                textBox9.Hide();
                textBox10.Hide();
            }
            else
            {
                label6.Show();
                label7.Show();
                label8.Show();

                comboBox2.Show();   
                textBox9.Show();
                textBox10.Show();
            }
        }

        /// <summary>
        /// Lấy tên trẻ em của người dùng và load vào comboBox
        /// </summary>
        private void loadChildrenToGUI()
        {
            List<string> childrenName = Bus_KhachHang.getChildrenName(_kh.MaKH);

            foreach(string childName in childrenName)
            {
                comboBox2.Items.Add(childName);
            }
        }


        /// <summary>
        /// Lấy thông tin người thân của người dùng để tạo KhachHang object
        /// Load một vài thông tin ấy lên gui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _treEm = Bus_KhachHang.getChildInfo(comboBox2.Text, _kh.MaKH.ToUpper());
            if (_treEm == null) return;
            textBox10.Text = _treEm.SDTKH;
        }
    }
}
