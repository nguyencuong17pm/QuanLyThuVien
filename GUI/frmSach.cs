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
using DTO;
using DataTable = System.Data.DataTable;
using BUS;
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmSach : Form
    {
        public frmSach()
        {
            InitializeComponent();
        }
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        private int flag = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
           
         
            List<Sach_DTO> lstSach = Sach_BUS.LayDSSach();
            dgvSach.DataSource = lstSach;
            cbonxb.DataSource = NhaXuatBan_BUS.LayDSTK();
            cbonxb.DisplayMember = "TenNXB";
            cbonxb.ValueMember = "MaNXB";
            cbotheloai.DataSource = TheLoai_BUS.LayDSTL();
            cbotheloai.DisplayMember = "TenLoai";
            cbotheloai.ValueMember = "MaLoai";
            dgvSach.Columns["MaSach"].HeaderText = "Mã sách";
            dgvSach.Columns["MaSach"].Width = 80;
            dgvSach.Columns["TenSach"].HeaderText = "Tên sách";
            dgvSach.Columns["TenSach"].Width = 190;
            dgvSach.Columns["TheLoai"].HeaderText = "Thể loại";
            dgvSach.Columns["TheLoai"].Width = 130;
            dgvSach.Columns["TinhTrang"].HeaderText = "Tình trạng";
            dgvSach.Columns["NamXB"].HeaderText = "Năm xuất bản";
            dgvSach.Columns["NamXB"].Width = 110;
            dgvSach.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvSach.Columns["SoLuong"].Width = 80;
            dgvSach.Columns["TacGia"].HeaderText = "Tác giả";
            dgvSach.Columns["TacGia"].Width = 160;
            dgvSach.Columns["NhaXB"].HeaderText = "Nhà xuất bản";
            dgvSach.Columns["NhaXB"].Width = 170;
            hienthi(true);
            txttracuu.Enabled = false;
        }
        public void hienthi(bool giatri)
        {
            txtmasach.Clear();
            txttensach.Clear();
            txtTacgia.Clear();
            txtNamXB.Clear();
            cbonxb.ResetText();
            cbotheloai.ResetText();
            cboTinhtrang.ResetText();
            cboSoLuong.ResetText();    
            txttensach.Enabled = !giatri;
            txtNamXB.Enabled = !giatri;
            txtTacgia.Enabled = !giatri;
            cbonxb.Enabled = !giatri;
            cboTinhtrang.Enabled = !giatri;
            cboSoLuong.Enabled = !giatri;
            cbotheloai.Enabled = !giatri;
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
        }
        public void hien(bool giatri)
        {
            cboTinhtrang.Enabled = !giatri;
            txttensach.Enabled = !giatri;
            txtNamXB.Enabled = !giatri;
            txtTacgia.Enabled = !giatri;
            cbonxb.Enabled = !giatri;
            cboSoLuong.Enabled = !giatri;
            cbotheloai.Enabled = !giatri;
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
        }
        private void matudong()
        {
            string masach = "S001";
            int dem = 0;
            while (Sach_BUS.TimSach_TheoMa(masach) != null)
            {
                dem += 1;
                if (dem < 10)
                    masach = "S00" + dem.ToString();
                else if (dem < 100)
                    masach = "S0" + dem.ToString();
                else if (dem < 1000)
                    masach = "S" + dem.ToString();
                else
                    MessageBox.Show("Không thể thêm nhân viên. Không đủ bộ nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtmasach.Text = masach;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 1;
            hienthi(false);
            txttensach.Focus();
            matudong();
        }
        //public static string connn = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        //public static SqlConnection coon;
        private string dieukien;
        //public DataTable HienDL(string sql)
        //{
        //    coon = new SqlConnection(connn);
        //    coon.Open();
        //    SqlDataAdapter adap = new SqlDataAdapter(sql, coon);
        //    DataTable dt = new DataTable();
        //    adap.Fill(dt);
        //    return dt;
        //}﻿
        private void cbotimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txttracuu.Enabled = true;
            txttracuu.Clear();
            txttracuu.Focus();
            if (cbotimkiem.Text == "Mã sách")
                dieukien = "MaSach";
            if (cbotimkiem.Text == "Tên sách")
                dieukien = "Tensach";
            if (cbotimkiem.Text == "Năm xuất bản")
                dieukien = "NamXB";
            if (cbotimkiem.Text == "Tác giả")
                dieukien = "TacGia";
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hien(false);
            flag = 2;
           
        }
        
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Sach_BUS.TimSach_TheoMa(txtmasach.Text.Trim()) == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng cần xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.No)
                {
                    XtraMessageBox.Show("Bạn đã hủy tháo tác xóa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               else if( thongbao == DialogResult.Yes)
                {
                //Sach_DTO s = new Sach_DTO();
                //s.MaSach = txtmasach.Text;
                //if (Sach_BUS.XoaSach(txtmasach.Text.Trim()))
                //{
                    con = new SqlConnection(conn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    //Thiết lập các thuộc tính cho đối tượng Command
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandText = "DeleteSach";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaSach", txtmasach.Text);
                    cmd.ExecuteNonQuery();
                    Form1_Load(sender, e);
                    XtraMessageBox.Show("Bạn đã xóa thành công sách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
                }
            }
        }

        private void dgvSach_Click_1(object sender, EventArgs e)
        {
            int t = dgvSach.CurrentCell.RowIndex;
            txtmasach.Text = dgvSach.Rows[t].Cells[0].Value.ToString();
            txttensach.Text = dgvSach.Rows[t].Cells[1].Value.ToString();
            cbotheloai.Text = dgvSach.Rows[t].Cells[2].Value.ToString();
            cboTinhtrang.Text = dgvSach.Rows[t].Cells[3].Value.ToString();
            cboSoLuong.Text = dgvSach.Rows[t].Cells[4].Value.ToString();
            cbonxb.Text = dgvSach.Rows[t].Cells[5].Value.ToString();
            txtNamXB.Text = dgvSach.Rows[t].Cells[6].Value.ToString();
            txtTacgia.Text = dgvSach.Rows[t].Cells[7].Value.ToString();
        }

        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            //if (cbotimkiem.Text == "Mã sách")
            //{
            //    dgvSach.DataSource = HienDL(" select * from SACH where MaSach like '%" + txttracuu.Text.Trim() + "%' ");
            //}
            //if (cbotimkiem.Text == "Tên sách")
            //{
            //    dgvSach.DataSource = HienDL(" select * from SACH where TenSach like N'%" + txttracuu.Text.Trim() + "%' ");
            //}
            //if (cbotimkiem.Text == "Năm xuất bản")
            //{
            //    dgvSach.DataSource = HienDL(" select * from SACH where NamXB like '%" + txttracuu.Text.Trim() + "%' ");
            //}
            //if (cbotimkiem.Text == "Tác giả")
            //{
            //    dgvSach.DataSource = HienDL(" select * from SACH where TacGia like N'%" + txttracuu.Text.Trim() + "%' ");
            //}
            if (txttracuu.Text.Trim() == "")
            {
                List<Sach_DTO> lstSach = Sach_BUS.LayDSSach();
                dgvSach.DataSource = lstSach;

            }
            else
            {
                List<Sach_DTO> lstTimKiem = Sach_BUS.TimSach(dieukien, txttracuu.Text);
                dgvSach.DataSource = lstTimKiem;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
            sheet.Name = "DsSACH";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dgvSach.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dgvSach.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            for (int i = 0; i < dgvSach.Rows.Count; i++)
            {
                for (int j = 0; j < dgvSach.Columns.Count; j++)
                {
                    if (dgvSach.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = dgvSach.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.FileName = "Sach";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách Sách đã được xuất ra Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }
      
        private void BtnLUU_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (txtmasach.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Mã sách không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txttensach.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Tên sách không được trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbotheloai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Thể loại không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboTinhtrang.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Tình trạng không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboSoLuong.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Số lượng không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtNamXB.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Năm xuất bản không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbonxb.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Nhà xuất bản không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTacgia.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Tác giả không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtmasach.Text.Trim().Length > 5)
                {
                    XtraMessageBox.Show("Mã sách không được lớn hơn 5 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    //Sach_DTO s = new Sach_DTO();
                    //s.MaSach = txtmasach.Text;
                    //s.TenSach = txttensach.Text;               
                    //s.TheLoai = cbotheloai.Text;              
                    //s.NhaXB = cbonxb.Text;
                    //s.TinhTrang = cboTinhtrang.Text;
                    //s.SoLuong = cboSoLuong.Text;                   
                    //s.NamXB = txtNamXB.Text;
                    //s.TacGia = txtTacgia.Text;
                    //if (Sach_BUS.TimSach_TheoMa(txtmasach.Text.Trim()) != null)
                    //{
                    //    XtraMessageBox.Show("Mã sách không được trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}

                    //else if (Sach_BUS.ThemSach(s))
                    //{                    
                    //}
                    //    Form1_Load(sender, e);
                    con = new SqlConnection(conn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    //Thiết lập các thuộc tính cho đối tượng Command
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertSach";
                    //Gắn các Parameter và giá trị cho đối tượng Command
                    cmd.Parameters.Add(new SqlParameter("@MaSach", txtmasach.Text));
                    cmd.Parameters.Add(new SqlParameter("@TenSach", txttensach.Text));
                    cmd.Parameters.Add(new SqlParameter("@TheLoai", cbotheloai.Text));
                    cmd.Parameters.Add(new SqlParameter("@SoLuong", cboSoLuong.Text));
                    cmd.Parameters.Add(new SqlParameter("@TinhTrang", cboTinhtrang.Text));
                    cmd.Parameters.Add(new SqlParameter("@NXB", cbonxb.Text));
                    cmd.Parameters.Add(new SqlParameter("@NamXB", txtNamXB.Text));
                    cmd.Parameters.Add(new SqlParameter("@TacGia", txtTacgia.Text));
                    //Thực thi Stored Procedure
                    cmd.ExecuteNonQuery();
                    Form1_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã thêm thành công thông tin sách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
            }
            if (flag == 2)
            {
                if (txttensach.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtmasach.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Mã sách chưa có dữ liệu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtTacgia.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtNamXB.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbonxb.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboTinhtrang.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cboSoLuong.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (cbotheloai.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chọn để sửa trên Bảng thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtmasach.Text.Trim().Length > 5)
                {
                    XtraMessageBox.Show("Mã sách không được lớn hơn 5 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Sach_DTO s = new Sach_DTO();
                    //s.MaSach = txtmasach.Text;
                    //s.TenSach = txttensach.Text;
                    //s.TheLoai = cbotheloai.Text;
                    //s.TinhTrang = cboTinhtrang.Text;
                    //s.SoLuong = cboSoLuong.Text;
                    //s.NhaXB = cbonxb.Text;
                    //s.NamXB = txtNamXB.Text;
                    //s.TacGia = txtTacgia.Text;
                    //if (Sach_BUS.TimSach_TheoMa(txtmasach.Text.Trim()) == null)
                    //{
                    //    XtraMessageBox.Show("Mã sách không được sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    hienthi(true);
                    //}
                    //else if (Sach_BUS.SuaSach(s))
                    //{
                    con = new SqlConnection(conn);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    //Thiết lập các thuộc tính cho đối tượng Command
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.CommandText = "UpdateSach";
                    cmd.Parameters.Add(new SqlParameter("@MaSach", txtmasach.Text));
                    cmd.Parameters.Add(new SqlParameter("@TenSach", txttensach.Text));
                    cmd.Parameters.Add(new SqlParameter("@TheLoai", cbotheloai.Text));
                    cmd.Parameters.Add(new SqlParameter("@SoLuong", cboSoLuong.Text));
                    cmd.Parameters.Add(new SqlParameter("@TinhTrang", cboTinhtrang.Text));
                    cmd.Parameters.Add(new SqlParameter("@NXB", cbonxb.Text));
                    cmd.Parameters.Add(new SqlParameter("@NamXB", txtNamXB.Text));
                    cmd.Parameters.Add(new SqlParameter("@TacGia", txtTacgia.Text));
                    //Thực thi Stored Procedure
                    cmd.ExecuteNonQuery();                              
                    Form1_Load(sender, e);
                     XtraMessageBox.Show("Bạn đã sửa thành công thông tin sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                                        
                    //}
                }
            }
        }

        private void txtmasach_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtmasach.Text))
            //{
            //    e.Cancel = true;
            //    txtmasach.Focus();
            //    errorProvider1.SetError(txtmasach, "Vui lòng nhập mã sách!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtmasach, null);
            //}
        }

        private void txttensach_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txttensach.Text))
            //{
            //    e.Cancel = true;
            //    txttensach.Focus();
            //    errorProvider1.SetError(txttensach, "Vui lòng nhập tên sách!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txttensach, null);
            //}
        }

        private void cbotheloai_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(cbotheloai.Text))
            //{
            //    e.Cancel = true;
            //    cbotheloai.Focus();
            //    errorProvider1.SetError(cbotheloai, "Vui lòng chọn thể loại!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(cbotheloai, null);
            //}
        }

        private void cboTinhtrang_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(cboTinhtrang.Text))
            //{
            //    e.Cancel = true;
            //    cboTinhtrang.Focus();
            //    errorProvider1.SetError(cboTinhtrang, "Vui lòng chọn tình trạng!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(cboTinhtrang, null);
            //}
        }

        private void cboSoLuong_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(cboSoLuong.Text))
            //{
            //    e.Cancel = true;
            //    cboSoLuong.Focus();
            //    errorProvider1.SetError(cboSoLuong, "Vui lòng chọn số lượng!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(cboSoLuong, null);
            //}
        }

        private void cbonxb_Validating(object sender, CancelEventArgs e)
        {
        //    if (string.IsNullOrEmpty(cbonxb.Text))
        //    {
        //        e.Cancel = true;
        //        cbonxb.Focus();
        //        errorProvider1.SetError(cbonxb, "Vui lòng chọn nhà xuất bản!");
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //        errorProvider1.SetError(cbonxb, null);
        //    }
        }

        private void txtNamXB_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtNamXB.Text))
            //{
            //    e.Cancel = true;
            //    txtNamXB.Focus();
            //    errorProvider1.SetError(txtNamXB, "Vui lòng nhập năm xuất bản!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtNamXB, null);
            //}
        }

        private void txtTacgia_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtTacgia.Text))
            //{
            //    e.Cancel = true;
            //    txtTacgia.Focus();
            //    errorProvider1.SetError(txtTacgia, "Vui lòng nhập tên tác giả!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtTacgia, null);
            //}
        }

       

        private void btnhuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txttracuu.Clear();
            //txttracuu.Enabled = false;
            //txttracuu.Text = "Nhập từ khóa cần tìm...";
            Form1_Load(sender, e);
          
        }

        private void txtNamXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
            txttracuu.Focus();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            frmTheLoai TL = new frmTheLoai();
            TL.Show();
        }

        private void btnNhaXuatBan_Click(object sender, EventArgs e)
        {
            frmNhaXuatBan NXB = new frmNhaXuatBan();
            NXB.Show();
        }
        private void cbotheloai_Click(object sender, EventArgs e)
        {
            cbotheloai.DataSource = TheLoai_BUS.LayDSTL();
            cbotheloai.DisplayMember = "TenLoai";
            cbotheloai.ValueMember = "MaLoai";
        }

        private void cbonxb_Click(object sender, EventArgs e)
        {
            cbonxb.DataSource = NhaXuatBan_BUS.LayDSTK();
            cbonxb.DisplayMember = "TenNXB";
            cbonxb.ValueMember = "MaNXB";
        }

       




        
       
    }
}
