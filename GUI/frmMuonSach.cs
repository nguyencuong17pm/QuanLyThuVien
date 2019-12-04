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
using DataTable = System.Data.DataTable;
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmMuonSach : Form
    {
        public frmMuonSach()
        {
            InitializeComponent();
        }
        private int flag = 0;
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            label5.Visible = false;
            thongtinsach();
            txtMaSV.Enabled = false;
            nmID.Visible = false;
            con = new SqlConnection(conn);
            con.Open();
            string sql = " select * from MuonSach ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvMuonSach.DataSource = dt;
            hienthi(true);
            loadsach();
        }
        public void thongtinsach()
        {
            coon = new SqlConnection(connn);
            coon.Open();
            string sql = " select * from SACH ";
            SqlCommand cmd = new SqlCommand(sql, coon);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvSach.DataSource = dt;
                
        }
        
        public void loadsach()
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = "select * from SACH";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            CboTenSach.DataSource = dt;
            CboTenSach.ValueMember = "MaSach";
            CboTenSach.DisplayMember = "TenSach";
        }
        public void hienthi(bool giatri)
        {
            CboTenSach.ResetText();
            cboSoLuong.ResetText();
            CboTenSach.ResetText();
            dtpNgayMuon.Value = DateTime.Now;
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
            CboTenSach.Enabled = !giatri;
        }
        public void hien(bool giatri)
        {
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLUU.Enabled = !giatri;
            CboTenSach.Enabled = !giatri;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            BtnLUU.Text = "Đăng ký";
            flag = 1;
            hienthi(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            hien(false);
            BtnLUU.Text = "Lưu lại";
        }

        private void BtnLUU_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                string sql = "insert into MuonSach values (@tennv, @nsinh, @nvaolam, @gtinh)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tennv", txtMaSV.Text);
                cmd.Parameters.AddWithValue("@nsinh", CboTenSach.Text);
                cmd.Parameters.AddWithValue("@nvaolam", cboSoLuong.Text);
                cmd.Parameters.AddWithValue("@gtinh", dtpNgayMuon.Text);
                cmd.ExecuteNonQuery();

                DialogResult thongbao = (XtraMessageBox.Show("Bạn đã đăng ký thành công", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information));
                if (thongbao == DialogResult.OK)
                    this.Close();
                
                
            }
            if (flag == 2)
            {
                string sql = "update MuonSach set MaSV = @tnv, TenSach = @nsinh, SoLuong = @nvlam, NgayMuon = @gtinh where ID = @e";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@e", nmID.Text);
                cmd.Parameters.AddWithValue("@tnv", txtMaSV.Text);
                cmd.Parameters.AddWithValue("@nsinh", CboTenSach.Text);
                cmd.Parameters.AddWithValue("@nvlam", cboSoLuong.Text);
                cmd.Parameters.AddWithValue("@gtinh", dtpNgayMuon.Text);
                cmd.ExecuteNonQuery();
                frmMuonSach_Load(sender, e);
                XtraMessageBox.Show("Bạn đã sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txttracuu.Enabled = false;
            txtTimkiem.Text = "Nhập mã sv...";
            textBox1.Text = "Nhập tên sách...";
            frmMuonSach_Load(sender, e);
           
        }

        private void dgvMuonSach_Click(object sender, EventArgs e)
        {
            int t = dgvMuonSach.CurrentCell.RowIndex;
            nmID.Text = dgvMuonSach.Rows[t].Cells[0].Value.ToString();
            txtMaSV.Text = dgvMuonSach.Rows[t].Cells[1].Value.ToString();
            CboTenSach.Text = dgvMuonSach.Rows[t].Cells[2].Value.ToString();
            cboSoLuong.Text = dgvMuonSach.Rows[t].Cells[3].Value.ToString();
            dtpNgayMuon.Text = dgvMuonSach.Rows[t].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
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
            sheet.Name = "DsMuon";

            // Thêm dòng tiêu đề
            for (int c = 0; c < dgvMuonSach.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = dgvMuonSach.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            for (int i = 0; i < dgvMuonSach.Rows.Count; i++)
            {
                for (int j = 0; j < dgvMuonSach.Columns.Count; j++)
                {
                    if (dgvMuonSach.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = dgvMuonSach.Rows[i].Cells[j].Value.ToString();
                    } 
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            progressBar1.Visible = false;
            file.FileName = "SinhVienMuon";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách mượn sách đã được xuất ra Excel!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from MuonSach where ID = @manv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@manv", nmID.Text);
            cmd.ExecuteNonQuery();
            frmMuonSach_Load(sender, e);
            XtraMessageBox.Show("Bạn đã xóa thành công", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
        }
        
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            dgvMuonSach.DataSource = HienDL(" select * from MuonSach where MaSV like '%" + txtTimkiem.Text.Trim() + "%' ");
        }
        public static string connn = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection coon;
        public DataTable HienDL(string sql)
        {
            coon = new SqlConnection(connn);
            coon.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, coon);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }﻿
        private void txtTimkiem_Click(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
        }

        private void cbotimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            txttracuu.Enabled = true;
            txttracuu.Clear();
            txttracuu.Focus();
        }

        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            if (cbotimkiem.Text == "Mã sách")
            {
                dgvSach.DataSource = HienDL(" select * from SACH where MaSach like '%" + txttracuu.Text.Trim() + "%' ");
            }
            if (cbotimkiem.Text == "Tên sách")
            {
                dgvSach.DataSource = HienDL(" select * from SACH where TenSach like N'%" + txttracuu.Text.Trim() + "%' ");
            }
            if (cbotimkiem.Text == "Năm xuất bản")
            {
                dgvSach.DataSource = HienDL(" select * from SACH where NamXB like '%" + txttracuu.Text.Trim() + "%' ");
            }
            if (cbotimkiem.Text == "Tác giả")
            {
                dgvSach.DataSource = HienDL(" select * from SACH where TacGia like N'%" + txttracuu.Text.Trim() + "%' ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)

        {
          
            dgvMuonSach.DataSource = HienDL(" select * from MuonSach where TenSach like N'%" + textBox1.Text.Trim() + "%' ");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
            txttracuu.Focus();
        }

       
     

    }
}
