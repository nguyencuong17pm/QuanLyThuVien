using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using DevExpress.XtraEditors;
using DTO;
using BUS;
namespace GUI
{
    public partial class frmTheLoai : Form
    {
        public frmTheLoai()
        {
            InitializeComponent();
        }
        private int stt = 0;
        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            List<Theloai_DTO> lstTL = TheLoai_BUS.LayDSTL();
            DgvTheLoai.DataSource = lstTL;
            DgvTheLoai.Columns["MaLoai"].HeaderText = "Mã loại";
            DgvTheLoai.Columns["MaLoai"].Width = 150;
            DgvTheLoai.Columns["TenLoai"].HeaderText = "Tên loại";
            DgvTheLoai.Columns["TenLoai"].Width = 270;
            txttracuu.Enabled = false;
            HienThi(true);
        }

        private void DgvTheLoai_Click(object sender, EventArgs e)
        {
            int t = DgvTheLoai.CurrentCell.RowIndex;
            txtMaLoai.Text = DgvTheLoai.Rows[t].Cells[0].Value.ToString();
            txtTenTheLoai.Text = DgvTheLoai.Rows[t].Cells[1].Value.ToString();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        public void HienThi(bool giaTri)
        {
            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
            txtTenTheLoai.Enabled = !giaTri;
            txtMaLoai.Clear();
            txtTenTheLoai.Clear();
            txtTenTheLoai.Focus();
        }
        public void HienThi1(bool giaTri)
        {
            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
            txtTenTheLoai.Enabled = !giaTri;
            txtTenTheLoai.Focus();
        }
        private void matudong()
        {
            string MaLoai = "TL001";
            int dem = 0;
            while (TheLoai_BUS.TimTL_TheoMa(MaLoai) != null)
            {
                dem += 1;
                if (dem < 10)
                    MaLoai = "TL00" + dem.ToString();
                else if (dem < 100)
                    MaLoai = "TL0" + dem.ToString();
                else if (dem < 1000)
                    MaLoai = "TL" + dem.ToString();
                else
                    XtraMessageBox.Show("Không thể thêm nữa. Không đủ bộ nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtMaLoai.Text = MaLoai;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stt = 1;
            HienThi(false);
            matudong();
        }

        private void BtnLUU_Click(object sender, EventArgs e)
        {
            
            if(stt == 1 )
            {
                if (txtTenTheLoai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập thể loại sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Theloai_DTO TL = new Theloai_DTO();
                    TL.MaLoai = txtMaLoai.Text;
                    TL.TenLoai = txtTenTheLoai.Text;
                    if (TheLoai_BUS.TimTL_TheoMa(txtMaLoai.Text.Trim()) != null)
                    {
                        XtraMessageBox.Show("Mã loại không được trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (TheLoai_BUS.ThemTL(TL))
                    {
                        frmTheLoai_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã thêm thành công " + txtTenTheLoai.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            else if (stt == 2)
            {
                if (txtMaLoai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa chọn dòng cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              else  if (txtTenTheLoai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Thể loại sách không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Theloai_DTO TL = new Theloai_DTO();
                    TL.MaLoai = txtMaLoai.Text;
                    TL.TenLoai = txtTenTheLoai.Text;
                    if (TheLoai_BUS.TimTL_TheoMa(txtMaLoai.Text.Trim()) == null)
                    {
                        XtraMessageBox.Show("Mã loại không được sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        if (TheLoai_BUS.SuaTL(TL))
                        {
                            frmTheLoai_Load(sender, e);
                            XtraMessageBox.Show("Bạn đã sửa thành công " + txtTenTheLoai.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            XtraMessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TheLoai_BUS.TimTL_TheoMa(txtMaLoai.Text.Trim()) == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng cần xóa! ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc muốn xóa thể loại này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.No)
                {
                    XtraMessageBox.Show("Bạn đã hủy thao tác xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (thongbao == DialogResult.Yes)
                {
                    Theloai_DTO TL = new Theloai_DTO();
                    TL.MaLoai = txtMaLoai.Text;
                    if (TheLoai_BUS.XoaTL(txtMaLoai.Text.Trim()))
                    {
                        frmTheLoai_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stt = 2;
            HienThi1(false);
          
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int m;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 40000;

            for (m = 0; m <= 40000; m++)
            {
                progressBar1.Value = m;
            }
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DsNXB";

            // Thêm dòng tiêu đề
            for (int c = 0; c < DgvTheLoai.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = DgvTheLoai.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            for (int i = 0; i < DgvTheLoai.Rows.Count; i++)
            {
                for (int j = 0; j < DgvTheLoai.Columns.Count; j++)
                {
                    if (DgvTheLoai.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = DgvTheLoai.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.FileName = "Theloai";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách thể loại đã được xuất ra Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string dieukien;
        private void cbotimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttracuu.Enabled = true;
            txttracuu.Clear();
            txttracuu.Focus();
            if (cbotimkiem.Text.Trim() == "Mã loại")
            {
                dieukien = "MaLoai";
            }
            else if (cbotimkiem.Text.Trim() == "Tên thể loại")
            {
                dieukien = "TenLoai";
            }
        }

        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            if (txttracuu.Text.Trim() == "")
            {
                List<Theloai_DTO> lstTL = TheLoai_BUS.LayDSTL();
                DgvTheLoai.DataSource = lstTL;
            }
            else
            {
                List<Theloai_DTO> lstTimKiem = TheLoai_BUS.TimTL(dieukien, txttracuu.Text);
                DgvTheLoai.DataSource = lstTimKiem;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txttracuu.Text = "Nhập từ khóa cần tìm...";
            frmTheLoai_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
            txttracuu.Focus();
        }
    }
}
