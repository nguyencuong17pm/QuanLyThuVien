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
using DevExpress.XtraEditors;
using DataTable = System.Data.DataTable;
using BUS;
using System.Security.Cryptography;
namespace GUI
{
    public partial class frmTaiKhoan : Form
    {
        public frmTaiKhoan()
        {
            InitializeComponent(); 
        }
        private int flag = 0;
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            label6.Visible = true;
            label2.Visible = true;
            txtTenHT.Visible = true;
            txtTaiKhoan.Visible = true;
            label1.Visible = false;
            nmID.Visible = false;
            groupBox3.Visible = false;
            comboBox1.Visible = false;
            cboTaiKhoan.Visible = false;
        
            List<TaiKhoan_DTO> lstTK = TaiKhoan_BUS.LayDSTK();
            DgvTaiKhoan.DataSource = lstTK;
            cboTaiKhoan.DataSource = NhanVien_BUS.LayDSNhanVien();
            cboTaiKhoan.DisplayMember = "MaNV";
            cboTaiKhoan.ValueMember = "TenNV";
          
               
            DgvTaiKhoan.Columns["ID"].HeaderText = "Số thứ tự";
            DgvTaiKhoan.Columns["ID"].Width = 120;
            DgvTaiKhoan.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            DgvTaiKhoan.Columns["TaiKhoan"].Width = 160;
            DgvTaiKhoan.Columns["TenHienThi"].HeaderText = "Tên hiển thị";
            DgvTaiKhoan.Columns["TenHienThi"].Width = 300;
            DgvTaiKhoan.Columns["MauKhau"].HeaderText = "Mật khẩu";
            DgvTaiKhoan.Columns["MauKhau"].Width = 130;
            
            DgvTaiKhoan.Columns["QuyenHan"].HeaderText = "Quyền hạn";
            DgvTaiKhoan.Columns["QuyenHan"].Width = 130;
            HienThi(true);
        }
        public static string conn = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
       
        private void hien()
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = " select * from BanDoc  ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "MaSV";
        }
        private void hien1()
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = " select * from BanDoc  ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboTenHT.DataSource = dt;
            cboTenHT.DataSource = dt;
            cboTenHT.DisplayMember = "HoVaTen";
        }
        
        public void HienThi(bool giaTri)
        {
            txtTaiKhoan.Enabled = !giaTri;
            txtMatKhau.Enabled = !giaTri;
            txtTenHT.Enabled = !giaTri;
            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
            cboTaiKhoan.ResetText();
            txtMatKhau.Clear();
            txtTenHT.Clear();
            txtTaiKhoan.Clear();
            cboQuyenHan.ResetText();
            nmID.ResetText();
        }
        public void HienThi1(bool giaTri)
        {
            txtTaiKhoan.Enabled = !giaTri;
            txtMatKhau.Enabled = !giaTri;
            txtTenHT.Enabled = !giaTri;
            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
        
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label2.Visible = false;
            flag = 1;
            HienThi(false);
            hien();
            label6.Visible = false;
            groupBox3.Visible = true;
            txtTaiKhoan.Visible = false;
            txtTenHT.Visible = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
       
        private void DgvTaiKhoan_Click(object sender, EventArgs e)
        {
            int t = DgvTaiKhoan.CurrentCell.RowIndex;
            nmID.Text = DgvTaiKhoan.Rows[t].Cells[0].Value.ToString();
            txtTaiKhoan.Text = DgvTaiKhoan.Rows[t].Cells[1].Value.ToString();
            txtTenHT.Text = DgvTaiKhoan.Rows[t].Cells[2].Value.ToString();
            txtMatKhau.Text = DgvTaiKhoan.Rows[t].Cells[3].Value.ToString();
            cboQuyenHan.Text = DgvTaiKhoan.Rows[t].Cells[4].Value.ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TaiKhoan_BUS.TimTk_TheoTen(txtTaiKhoan.Text.Trim()) == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.No)
                {
                    XtraMessageBox.Show("Bạn đã hủy thao tác xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    if (thongbao == DialogResult.Yes)
                    {
                        TaiKhoan_DTO TK = new TaiKhoan_DTO();
                        TK.ID = int.Parse(nmID.Text);
                        if (TaiKhoan_BUS.XoaTaiKhoan(nmID.Text))
                        {
                            frmTaiKhoan_Load(sender, e);
                            XtraMessageBox.Show("Bạn đã xóa thành công tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
            }
        }
       
        private void BtnLUU_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
               
                TaiKhoan_DTO Tk = new TaiKhoan_DTO();


                if (rdNhanVien.Checked == true)
                {
                    Tk.TaiKhoan = cboTaiKhoan.Text;
                }
                else if (rdSinhVien.Checked == true)
                {
                    Tk.TaiKhoan = comboBox1.Text;
                }
                Tk.TenHienThi = cboTenHT.Text;
                Tk.MauKhau = txtMatKhau.Text;

                Tk.QuyenHan = cboQuyenHan.Text;
               
              
                if (TaiKhoan_BUS.TimTk_TheoTen(comboBox1.Text.Trim()) != null)
                {
                    XtraMessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //else if (TaiKhoan_BUS.TimTk_TheoTen(cboTaiKhoan.Text.Trim()) != null)
                //{
                //    XtraMessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

               else if (TaiKhoan_BUS.ThemTaiKhoan(Tk))
                {

                   
                    frmTaiKhoan_Load(sender, e);
                    XtraMessageBox.Show("Bạn đã thêm thành công tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
         else  if (flag == 2)
            {
                TaiKhoan_DTO Tk = new TaiKhoan_DTO();
                Tk.ID = int.Parse(nmID.Text);
                Tk.TaiKhoan = txtTaiKhoan.Text;
                Tk.TenHienThi = txtTenHT.Text;
                Tk.MauKhau = txtMatKhau.Text;
                Tk.QuyenHan = cboQuyenHan.Text;
                
                
                if (txtTaiKhoan.Text.Trim() =="")
                {
                    XtraMessageBox.Show("Bạn chưa chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
              else  if (TaiKhoan_BUS.TimTk_TheoTen(txtTaiKhoan.Text.Trim()) != null)
                {
                    XtraMessageBox.Show("Tên tài khoản trùng rồi !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (TaiKhoan_BUS.TimTk_TheoTenHT(txtTenHT.Text.Trim()) != null) 
                {
                    XtraMessageBox.Show("Tên hiển thị đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
      
              else  if (TaiKhoan_BUS.SuaTaiKhoan(Tk))
                {
                    frmTaiKhoan_Load(sender, e);
                    XtraMessageBox.Show("Bạn đã sửa thành công tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            flag = 2;
            HienThi1(false);
           
        }

        private void hienmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (hienmatkhau.Checked == true)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void DgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if ( DgvTaiKhoan.Columns[e.ColumnIndex].HeaderText == "Mật khẩu")
            {
                e.Value = "******";
            }
        }
        private string dieukien;
        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            if (txttracuu.Text.Trim() == "")
            {

                List<TaiKhoan_DTO> lstTK = TaiKhoan_BUS.LayDSTK();
                DgvTaiKhoan.DataSource = lstTK;
            }
            else
            {
                dieukien = "TaiKhoan";
                List<TaiKhoan_DTO> lstTimKiem = TaiKhoan_BUS.Timtaikhoan(dieukien, txttracuu.Text);
                DgvTaiKhoan.DataSource = lstTimKiem;
            }
        }

        private void rdNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            cboTenHT.DataSource = NhanVien_BUS.LayDSNhanVien();
            cboTenHT.DisplayMember = "TenNV";
            cboTenHT.ValueMember = "MaNV";
            cboTaiKhoan.Visible = true;
            comboBox1.Visible = false;
        }

        private void rdSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            hien1();
            comboBox1.Visible = true;
            cboTaiKhoan.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmTaiKhoan_Load(sender, e);
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            txttracuu.Text = "Nhập tài khoản cần tìm...";
            frmTaiKhoan_Load(sender, e);
        }

        private void txttracuu_Click(object sender, EventArgs e)
        {
            txttracuu.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cboQuyenHan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboQuyenHan_TextChanged(object sender, EventArgs e)
        {
            //MD5 mh = MD5.Create();
            ////Chuyển kiểu chuổi thành kiểu byte
            //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(txtMatKhau.Text);

            ////mã hóa chuỗi đã chuyển
            //byte[] hash = mh.ComputeHash(inputBytes);
            ////tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < hash.Length; i++)
            //{
            //    sb.Append(hash[i].ToString("X"));
            //}

          
            //MD5 mh = MD5.Create();
            ////Chuyển kiểu chuổi thành kiểu byte
            //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(txtMatKhau.Text);

            ////mã hóa chuỗi đã chuyển
            //byte[] hash = mh.ComputeHash(inputBytes);
            ////tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < hash.Length; i++)
            //{
            //    sb.Append(hash[i].ToString("X"));
            //}
        }

      

     
    }
}
