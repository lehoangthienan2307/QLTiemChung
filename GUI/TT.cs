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
using PTTK2.PHIEUGIAODICH;
using PTTK2.CHITIETPHIEUGIAODICH;
using PTTK2.HOADON;

namespace PTTK2
{
    public partial class TT : Form
    {
        private InterfaceKH _interfaceKH;
        private KhachHang _kh;
        private List<PhieuGiaoDich> _phieuGiaoDich = new List<PhieuGiaoDich>();
        private string tongTien = "";
        DataTable dt = new DataTable();
        public TT(InterfaceKH interfaceKH, KhachHang kh)
        {
            _interfaceKH = interfaceKH;
            _kh = kh;
            InitializeComponent();
            loadGui();
            
        }

        private void loadGui()
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Phiếu giao dịch";
            dt.Clear();
            label8.Text = "0 VND";
            label10.Hide();
            label9.Hide();
            loadPhieuGiaoDichToGui(_kh.MaKH);
        }
        private void loadPhieuGiaoDichToGui(string maKH)
        {
            _phieuGiaoDich = Bus_PhieuGiaoDich.getPhieuGiaoDich(maKH);
            foreach (PhieuGiaoDich pgd in _phieuGiaoDich)
            {

                comboBox1.Items.Add(pgd.MaPhieu);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label9.Show();
            label10.Text = _phieuGiaoDich[comboBox1.SelectedIndex].LoaiPhieu;
            label10.Show();
            loadChiTietPhieuGiaoDichToGui(_phieuGiaoDich[comboBox1.SelectedIndex].MaPhieu);

        }

        private void loadChiTietPhieuGiaoDichToGui(string maPhieu)
        {
            dt = Bus_ChiTietPhieuGiaoDich.getChiTietPhieuGiaoDichTT(maPhieu);
            label8.Text= Bus_ChiTietPhieuGiaoDich.tinhTongTien(dt).ToString() + " VND";
            tongTien = Bus_ChiTietPhieuGiaoDich.tinhTongTien(dt).ToString();
            dataGridView1.DataSource = dt;
        }

        private void TT_FormClosing(object sender, FormClosingEventArgs e)
        {
            _interfaceKH.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Xác nhận thanh toán?",
                                     "Thanh toán",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Bus_PhieuGiaoDich.updateTrangThai(_phieuGiaoDich[comboBox1.SelectedIndex].MaPhieu);
                Bus_HoaDon.insert(tongTien, _phieuGiaoDich[comboBox1.SelectedIndex]);
                loadGui();
            }
            else
            {
                //do nothing
            }
            
        }
    }
}
