using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using PTTK2.KHACHHANG;
using PTTK2.GOITIEMCHUNG;
using PTTK2.CHITIETGOI;
using PTTK2.PHIEUGIAODICH;
using PTTK2.CHITIETPHIEUGIAODICH;
using PTTK2.VACCINE;

namespace PTTK2
{
    public partial class DMVC : Form
    {
        private InterfaceKH _interfaceKH;
        private KhachHang _kh;
        //lấy danh sách gói tiêm chủng từ bus_goitiemchung
        private List<GoiTiemChung> _goiTiemChungList = Bus_GoiTiemChung.getGoiTiemChung();
        //lấy danh sach vaccine cua goi tiem chung
        private List<Vaccine> _vaccineList;
        // gói tiêm chủng + số lượng đặt
        private IDictionary<GoiTiemChung, int> gioHang = new Dictionary<GoiTiemChung, int>();
        public DMVC(InterfaceKH interfaceKH, KhachHang kh)
        {
            _interfaceKH = interfaceKH;
            _kh = kh;
            InitializeComponent();
            label4.Text = "0 VND";
            loadGoiTiemChungToGui();
        }

        private void loadGoiTiemChungToGui()
        {
            foreach (GoiTiemChung gtc in _goiTiemChungList)
            {

                listBox1.Items.Add(gtc.TenLoai);
            }
        }

        private void DMVC_FormClosing(object sender, FormClosingEventArgs e)
        {
            _interfaceKH.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lấy chi tiết gói từ gói tiêm chủng
            List<ChiTietGoi> chiTietGoi = Bus_ChiTietGoi.getChiTietGoi(_goiTiemChungList[listBox1.SelectedIndex]);
            loadVaccineToGui(chiTietGoi);

        }

        private void loadVaccineToGui(List<ChiTietGoi> chiTietGoi)
        {
            listBox2.Items.Clear();
            // lấy vaccine từ chi tiết gói
            _vaccineList = Bus_Vaccine.getVaccine(chiTietGoi);
            foreach (Vaccine vc in _vaccineList)
            {
                listBox2.Items.Add(vc.TenVC);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // thêm vào giỏ hàng
            int tongTien = GioHang.themGioHang(gioHang, _goiTiemChungList[listBox1.SelectedIndex]);
            loadGioHangToGui(gioHang, tongTien);

        }

        private void loadGioHangToGui(IDictionary<GoiTiemChung, int> gioHang, int tongTien)
        {
            listBox3.Items.Clear();
            for (int i = 0; i < gioHang.Count; i++)
            {
                string line = gioHang.ElementAt(i).Key.TenLoai + "   x" + gioHang.ElementAt(i).Value.ToString();
                listBox3.Items.Add(line);
            }
            label4.Text = tongTien.ToString() + " VND";
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            int tongTien = GioHang.xoaGioHang(gioHang, gioHang.ElementAt(listBox3.SelectedIndex).Key);
            loadGioHangToGui(gioHang, tongTien);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Xác nhận đặt mua?",
                                     "Đặt mua",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string result = Bus_PhieuGiaoDich.insertDatMua(gioHang, _kh.MaKH);
                if (result != null)
                {
                    // gọi hàm thêm chi tiết phiếu giao dịch ở tầng nghiệp vụ
                    Bus_ChiTietPhieuGiaoDich.insertDatMua(gioHang, _kh.MaKH, result);
                    listBox3.Items.Clear();
                    label4.Text = "0 VND";
                }
            }
            else
            {
                //do nothing
            }

            
        }
    }

}
