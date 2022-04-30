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
    public partial class XLCN : Form
    {
        private string _maNV;
        DataTable dt = new DataTable();
        public XLCN(string maNV)
        {
            _maNV = maNV;
            InitializeComponent();
            loadLichLamViecToGui();
        }



        /// <summary>
        /// Lấy dữ liệu ở tầng nghiệp vụ của nhân viên để hiển thị lên gui
        /// </summary>
        private void loadLichLamViecToGui()
        {
            dt = Bus_NhanVien.getWorkDate(_maNV);
            dataGridView1.DataSource = dt;
        }
    }
}
