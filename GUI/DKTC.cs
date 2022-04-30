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
using PTTK2.TRUNGTAMTIEM;
using PTTK2.PHIEUGIAODICH;
using PTTK2.CHITIETPHIEUGIAODICH;

namespace PTTK2
{
    public partial class DKTC : Form
    {
        private InterfaceKH _interfaceKH;
        private KhachHang _kh;
        private KhachHang _treEm; // người thân cảu khách hàng đang sử dụng hệ thống

        private List<GoiTiemChung> _goiTiemChungList = Bus_GoiTiemChung.getGoiTiemChung();
        private List<TrungTamTiem> _trungTamTiemList = Bus_TrungTamTiem.GetTrungTamTiem();
        public DKTC(InterfaceKH interfaceKH,KhachHang kh)
        {
            _interfaceKH = interfaceKH;
            _kh = kh;
            InitializeComponent();
            FormClosing += DKTC_FormClosing;

            loadInfoToGui();
            loadGoiTiemChungToGui();
            loadTrungTamTiemToGui();

            dateTimePicker1.Value.AddDays(2);
        }

        private void DKTC_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _interfaceKH.Show();
        }

        /// <summary>
        /// Kiểm tra ngày tháng người dùng chọn có phải hợp lệ (ngày hẹn phải nằm trong tương lai)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value.Date;
            if(!Bus_KhachHang.isValidPickedDate(dateTime))
            {
                MessageBox.Show("Cannot select today or past date", "Alert");
            }
        }


        /// <summary>
        /// Lấy thông tin của trung tâm tiêm chủng và hiển thị lên gui
        /// </summary>
        private void loadTrungTamTiemToGui()
        {
            foreach (TrungTamTiem ttt in _trungTamTiemList)
            {
                comboBox1.Items.Add(ttt.TenTT);
            }
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
            textBox9.Text = _treEm.QuanHe;
            textBox10.Text = _treEm.SDTKH;

        }


        /// <summary>
        /// Gọi tầng nghiệp vụ để xử lí insert thêm đơn đăng ký tiêm chủng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // nếu người dùng không chọn trung tâm nào thì không đăng ký phiếu
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Xin hãy lựa chọn trung tâm", "Thông báo");
                return;
            }            

            // nếu người dùng chưa chọn gói vaccine nào thì không đăng ký phiếu
            if (!isSelectedVaccine())
            {
                MessageBox.Show("Xin hãy lựa chọn gói vaccine", "Thông báo");
                return;
            }

            // người dùng muốn đăng ký tiêm cho người thân
            if (checkBox1.Checked)
            {
                // gọi hàm thêm phiếu giao dịch ở tầng nghiệp vụ
                string result = Bus_PhieuGiaoDich.insert(_trungTamTiemList[comboBox1.SelectedIndex], dateTimePicker1.Value.Date, _treEm.MaKH);
                // nếu tạo phiếu giao dịch thành công thì sẽ trả mã phiếu giao dịch để thêm vào chi tiết phiếu giao dịch
                if (result != null)
                {
                    // gọi hàm thêm chi tiết phiếu giao dịch ở tầng nghiệp vụ
                    Bus_ChiTietPhieuGiaoDich.insert(checkedListBox1, _goiTiemChungList, _treEm.MaKH,result);
                }
            }
            // đăng ký tiêm chủng cho người dùng
            else
            {
                // gọi hàm thêm phiếu giao dịch ở tầng nghiệp vụ
                string result = Bus_PhieuGiaoDich.insert(_trungTamTiemList[comboBox1.SelectedIndex], dateTimePicker1.Value.Date, _kh.MaKH);
                if (result != null)
                {
                    // gọi hàm thêm chi tiết phiếu giao dịch ở tầng nghiệp vụ
                    Bus_ChiTietPhieuGiaoDich.insert(checkedListBox1, _goiTiemChungList, _kh.MaKH,result);
                }
            }
        }

        /// <summary>
        /// Kiểm tra xem người dùng đã chọn gói vaccine nào chưa
        /// </summary>
        /// <returns></returns>
        private bool isSelectedVaccine()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
