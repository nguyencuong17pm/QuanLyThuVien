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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private int flag = 0;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            List<NhanVien_DTO> lstNhanVien = NhanVien_BUS.LayDSNhanVien();
            dgvNhanVien.DataSource = lstNhanVien;
            txttracuu.Enabled = false;
            dgvNhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["MaNV"].Width = 130;
            dgvNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns["TenNV"].Width = 140;
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["NgaySinh"].Width = 130;
            dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns["NgayVaoLam"].Width = 130;
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["GioiTinh"].Width = 110;
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns["DienThoai"].Width = 140;
            hienthi(true);
        }
        
        private void matudong()
        {
            string manhanvien = "NV001";
            int dem = 0;
            while (NhanVien_BUS.TimNhanVien_TheoMa(manhanvien) != null)
            {
                dem += 1;
                if (dem < 10)
                    manhanvien = "NV00" + dem.ToString();
                else if (dem < 100)
                    manhanvien = "NV0" + dem.ToString();
                else if (dem < 1000)
                    manhanvien = "NV" + dem.ToString();
                else
                    XtraMessageBox.Show("Không thể thêm nhân viên. Không đủ bộ nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           txtManv.Text = manhanvien;
        }
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            int t = dgvNhanVien.CurrentCell.RowIndex;
            txtManv.Text = dgvNhanVien.Rows[t].Cells[0].Value.ToString();
            txtTennv.Text = dgvNhanVien.Rows[t].Cells[1].Value.ToString();
            dtpngaysinh.Text = dgvNhanVien.Rows[t].Cells[2].FormattedValue.ToString();
            dtpngayvaolam.Text = dgvNhanVien.Rows[t].Cells[3].FormattedValue.ToString();
            string Gender = "";
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                Gender = dgvNhanVien.SelectedRows[0].Cells["Gioitinh"].Value.ToString();
                if (Gender == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                    rdNu.Checked = true;
            }

            txtDiaChi.Text = dgvNhanVien.Rows[t].Cells[5].Value.ToString();
            txtDienThoai.Text = dgvNhanVien.Rows[t].Cells[6].Value.ToString();
        }

        private void rdNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNam.Checked == true)
            {
                rdNu.Checked = false;
            }
        }

        private void rdNu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNu.Checked == true)
            {
                rdNam.Checked = false;
            }
        }
        public void hienthi(bool giatri)
        {

            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
            txtManv.Clear();
            txtTennv.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            dtpngaysinh.Value = DateTime.Now;
            dtpngayvaolam.Value = DateTime.Now;
            rdNam.Checked = true;
            txttracuu.Clear();
            txtDiaChi.Enabled = !giatri;
            txtDienThoai.Enabled = !giatri;
            txtTennv.Enabled = !giatri;
            dtpngaysinh.Enabled = !giatri;
            dtpngayvaolam.Enabled = !giatri;
            rdNam.Enabled = !giatri;
            rdNu.Enabled = !giatri;
             

        }
        public void hien(bool giatri)
        {

            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
            dtpngaysinh.Value = DateTime.Now;
            dtpngayvaolam.Value = DateTime.Now;
            txttracuu.Clear();
            txtDiaChi.Enabled = !giatri;
            txtDienThoai.Enabled = !giatri;
            txtTennv.Enabled = !giatri;
            dtpngaysinh.Enabled = !giatri;
            dtpngayvaolam.Enabled = !giatri;
            rdNam.Enabled = !giatri;
            rdNu.Enabled = !giatri;


        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 1;
            hienthi(false);
            matudong();
            txtTennv.Focus();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void BtnLUU_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (txtManv.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu   ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTennv.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (txtManv.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu   ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDiaChi.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtDienThoai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi lưu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.MaNV = txtManv.Text;
                    nv.TenNV = txtTennv.Text;
                    nv.NgaySinh = DateTime.Parse(dtpngaysinh.Text);
                    nv.NgayVaoLam = DateTime.Parse(dtpngayvaolam.Text);
                    if (rdNam.Checked == true)
                    {
                        nv.GioiTinh = rdNam.Text;
                    }
                    else if (rdNu.Checked == true)
                    {
                        nv.GioiTinh = rdNu.Text;
                    }
                    nv.DiaChi = txtDiaChi.Text;
                    nv.DienThoai = txtDienThoai.Text;
                    if (NhanVien_BUS.TimNhanVien_TheoMa(txtManv.Text.Trim()) != null)
                    {
                        XtraMessageBox.Show("Mã nhân viên không được trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtManv.Text.Trim().Length > 5)
                    {
                        XtraMessageBox.Show("Mã nhân viên không được lớn hơn 5 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (NhanVien_BUS.ThemNhanVien(nv))
                    {
                        frmNhanVien_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã thêm thành công thông tin nhân viên " + txtTennv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        XtraMessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            if (flag == 2)
            {
                if (txtTennv.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng chọn dòng cần sửa trên Bảng thông tin  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtManv.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Mã nhân viên chưa có dữ liệu  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDienThoai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng chọn dòng cần sửa trên Bảng thông tin  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtDiaChi.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng chọn dòng cần sửa trên Bảng thông tin  ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    NhanVien_DTO nv = new NhanVien_DTO();
                    nv.MaNV = txtManv.Text;
                    nv.TenNV = txtTennv.Text;
                    nv.NgaySinh = DateTime.Parse(dtpngaysinh.Text);
                    nv.NgayVaoLam = DateTime.Parse(dtpngayvaolam.Text);
                    if (rdNam.Checked == true)
                    {
                        nv.GioiTinh = rdNam.Text;
                    }
                    else if (rdNu.Checked == true)
                    {
                        nv.GioiTinh = rdNu.Text;
                    }
                    nv.DiaChi = txtDiaChi.Text;
                    nv.DienThoai = txtDienThoai.Text;
                    if (NhanVien_BUS.SuaNhanVien(nv))
                    {
                        frmNhanVien_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã sửa thành công thông", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNV = txtManv.Text;
                if (NhanVien_BUS.XoaNhanVien(txtManv.Text.Trim()))
                {
                    frmNhanVien_Load(sender, e);
                    XtraMessageBox.Show("Bạn đã xóa thành công nhân viên " + txtTennv.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            
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
            sheet.Name = "DsNhanVien";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dgvNhanVien.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dgvNhanVien.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                {
                    if (dgvNhanVien.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = dgvNhanVien.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.FileName = "NhanVien";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách nhân viên đã được xuất ra Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 2;
            hien(false);
          
        }
        private string dieukien;
        private void cbotimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttracuu.Enabled = true;
            txttracuu.Clear();
            txttracuu.Focus();
            if (cbotimkiem.Text == "Mã nhân viên")
                dieukien = "MaNV";
            if (cbotimkiem.Text == "Tên nhân viên")
                dieukien = "TenNV";
            if (cbotimkiem.Text == "Địa chỉ")
                dieukien = "DiaChiNV";
        }

        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            if (txttracuu.Text.Trim() == "")
            {
                List<NhanVien_DTO> lstNhanVien = NhanVien_BUS.LayDSNhanVien();
                dgvNhanVien.DataSource = lstNhanVien;
            }
            else
            {
                List<NhanVien_DTO> lstTimKiem = NhanVien_BUS.TimNhanVien(dieukien, txttracuu.Text);
                dgvNhanVien.DataSource = lstTimKiem;
            }
        }

        private void txtManv_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtManv.Text))
            //{
            //    e.Cancel = true;
            //    txtManv.Focus();
            //    errorProvider1.SetError(txtManv, "Vui lòng nhập mã nhân viên!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtManv, null);
            //}
        }

        private void txtTennv_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtTennv.Text))
            //{
            //    e.Cancel = true;
            //    txtTennv.Focus();
            //    errorProvider1.SetError(txtTennv, "Vui lòng nhập tên nhân viên!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtTennv, null);
            //}
        }

        private void txtDiaChi_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDiaChi.Text))
            //{
            //    e.Cancel = true;
            //    txtDiaChi.Focus();
            //    errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtDiaChi, null);
            //}
        }

        private void txtDienThoai_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtDienThoai.Text))
            //{
            //    e.Cancel = true;
            //    txtTennv.Focus();
            //    errorProvider1.SetError(txtDienThoai, "Vui lòng nhập điện thoại!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtDienThoai, null);
            //}
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txttracuu.Clear();
            frmNhanVien_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
            txttracuu.Focus();
        }
    }
}
