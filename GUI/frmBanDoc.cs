using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmBanDoc : Form
    {
        public frmBanDoc()
        {
            InitializeComponent();
        }

        private int flag = 0;
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        string imgLoc = "";
       
        //OpenFileDialog op = new OpenFileDialog();
        private void frmBanDoc_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = " select * from BanDoc  ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DgvBanDoc.DataSource = dt;
            hienthi(true);
        }

        public void hienthi(bool giatri)
        {

            pbanhdaidien.Image = Image.FromFile("D:/Disk E/HinhAnh/iconfinder_camera_1646008.png");
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            btnLuu.Enabled = !giatri;
            txtMaSV.Clear();
            txtDiaChi.Clear();
            txtHoDem.Clear();
            txtHoVaTen.Clear();
            txtLop.Clear();
            txtMaThe.Clear();
            txtTen.Clear();
            rdNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayHieuLuc.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now;
            dtpNgayCap.Value = DateTime.Now;
            txtDiaChi.Enabled = !giatri;
            txtHoDem.Enabled = !giatri;
            txtHoVaTen.Enabled = !giatri;
            txtLop.Enabled = !giatri;
           
            txtTen.Enabled = !giatri;
            dtpNgayCap.Enabled = !giatri;
            dtpNgayHetHan.Enabled = !giatri;
            dtpNgayHieuLuc.Enabled = !giatri;
            dtpNgaySinh.Enabled = !giatri;
            rdNam.Enabled = !giatri;
            rdNu.Enabled = !giatri;
            
        }
        private string taomasach()
        {
            string masach;
            Random r = new Random();
            masach = "SV" + r.Next(50, 1000).ToString();
            return masach;
        }
        private string taomathe()
        {
            string masach;
            Random r = new Random();
            masach = "TTV" + r.Next(0, 3000).ToString();
            return masach;
        }
        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            //op.Title = "Chọn ảnh đại diện";
            //op.InitialDirectory = @"E:\";
            //op.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*bmp";
            //if (op.ShowDialog() == DialogResult.OK)
            //    pbanhdaidien.Image = Image.FromFile(op.FileName);
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Chọn ảnh đại diện";
                dlg.FileName = "ChonAnh";
                dlg.Filter = "Image|*.jpg;*.jpeg;*.png;*.gif;*bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    imgLoc = dlg.FileName.ToString();
                    pbanhdaidien.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //private byte[] convertImageToBytes()
        //{
        //    FileStream fs;
        //    fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
        //    byte[] picbyte = new byte[fs.Length];
        //    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
        //    fs.Close();
        //    return picbyte;

        //}
        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtHoDem.Text.Trim() == "")
            {
                XtraMessageBox.Show("Họ đệm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTen.Text.Trim() == "") 
            {
                XtraMessageBox.Show("Tên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           else if (txtHoVaTen.Text.Trim() == "")
            {
                XtraMessageBox.Show("Tên đầy đủ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDiaChi.Text.Trim() == "") 
            {
                XtraMessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtLop.Text.Trim() == "") 
            {
                XtraMessageBox.Show("Lớp không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
            if (flag == 1)
            {
                try
                {
                    byte[] img = null;
                    FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                    //string sql = "INSERT INTO tblImages(ten,  blobdata) values('" + txtTenAnh.Text + "', @img)";
                    string sql = "INSERT INTO BanDoc values(@MaSV, @HoDem, @Ten, @HoVaTen, @Lop, @GioiTinh, @NgaySinh, @dchi,@Anh, @MaThe, @NgayCap, @Ngayhieuluc, @Ngayhh )";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add(new SqlParameter("@MaSV", txtMaSV.Text));
                    cmd.Parameters.Add(new SqlParameter("@HoDem", txtHoDem.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ten", txtTen.Text));
                    cmd.Parameters.Add(new SqlParameter("@HoVaTen", txtHoVaTen.Text));
                    cmd.Parameters.Add(new SqlParameter("@Lop", txtLop.Text));
                    if (rdNam.Checked == true)
                    {
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", rdNam.Text));
                    }
                    else if (rdNu.Checked == true)
                    {
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", rdNu.Text));
                    }
                    cmd.Parameters.Add(new SqlParameter("@NgaySinh", dtpNgaySinh.Text));
                    cmd.Parameters.Add(new SqlParameter("@dchi", txtDiaChi.Text));
                  
                        cmd.Parameters.Add(new SqlParameter("@Anh", img));
                    
                    cmd.Parameters.Add(new SqlParameter("@MaThe", txtMaThe.Text));
                    cmd.Parameters.Add(new SqlParameter("@NgayCap", dtpNgayCap.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ngayhieuluc", dtpNgayHieuLuc.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ngayhh", dtpNgayHetHan.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frmBanDoc_Load(sender, e);
                    XtraMessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch
                {
                    con.Close();
                    XtraMessageBox.Show("Không thêm được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (flag == 2)
            {

                try
                {
                    
                        byte[] img = null;
                        FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                   
                    string sql = "update BanDoc set  HoVadem = @HoDem, Ten = @Ten, HoVaTen = @HoVaTen, Lop = @Lop, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, DiaChiSV = @dchi, Anh = @Anh, MaThe = @MaThe, NgayCap = @NgayCap, NgayHieuLuc = @Ngayhieuluc, NgayHetHan = @Ngayhh  where MaSV = @MaSV";
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoDem", txtHoDem.Text);
                    cmd.Parameters.Add(new SqlParameter("@Ten", txtTen.Text));
                    cmd.Parameters.Add(new SqlParameter("@HoVaTen", txtHoVaTen.Text));
                    cmd.Parameters.Add(new SqlParameter("@Lop", txtLop.Text));
                    if (rdNam.Checked == true)
                    {
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", rdNam.Text));
                    }
                    else if (rdNu.Checked == true)
                    {
                        cmd.Parameters.Add(new SqlParameter("@GioiTinh", rdNu.Text));
                    }
                   
                    cmd.Parameters.Add(new SqlParameter("@NgaySinh", dtpNgaySinh.Text));
                    cmd.Parameters.Add(new SqlParameter("@dchi", txtDiaChi.Text));   
                    cmd.Parameters.Add(new SqlParameter("@Anh", img));
                    cmd.Parameters.Add(new SqlParameter("@MaThe", txtMaThe.Text));
                    cmd.Parameters.Add(new SqlParameter("@NgayCap", dtpNgayCap.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ngayhieuluc", dtpNgayHieuLuc.Text));
                    cmd.Parameters.Add(new SqlParameter("@Ngayhh", dtpNgayHetHan.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frmBanDoc_Load(sender, e);
                    XtraMessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                catch
                {
                    con.Close();
                    XtraMessageBox.Show("Không sửa được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               }
            }
        }

        private void DgvBanDoc_Click(object sender, EventArgs e)
        {


            MemoryStream ms = new MemoryStream((byte[])DgvBanDoc.CurrentRow.Cells[8].Value);
            pbanhdaidien.Image = Image.FromStream(ms);
            int t = DgvBanDoc.CurrentCell.RowIndex;
            txtMaSV.Text = DgvBanDoc.Rows[t].Cells[0].Value.ToString();
            txtHoDem.Text = DgvBanDoc.Rows[t].Cells[1].Value.ToString();
            txtTen.Text = DgvBanDoc.Rows[t].Cells[2].Value.ToString();
            txtHoVaTen.Text = DgvBanDoc.Rows[t].Cells[3].Value.ToString();
            txtLop.Text = DgvBanDoc.Rows[t].Cells[4].Value.ToString();
            string Gender = "";
            if (DgvBanDoc.SelectedRows.Count > 0)
            {
                Gender = DgvBanDoc.SelectedRows[0].Cells["Column6"].Value.ToString();
                if (Gender == "Nam")
                {
                    rdNam.Checked = true;
                }
                else
                    rdNu.Checked = true;
            }  
            dtpNgaySinh.Text = DgvBanDoc.Rows[t].Cells[6].Value.ToString();
            txtDiaChi.Text = DgvBanDoc.Rows[t].Cells[7].Value.ToString();
            txtMaThe.Text = DgvBanDoc.Rows[t].Cells[9].Value.ToString();
            dtpNgayCap.Text = DgvBanDoc.Rows[t].Cells[10].Value.ToString();
            dtpNgayHieuLuc.Text = DgvBanDoc.Rows[t].Cells[11].Value.ToString();
            dtpNgayHetHan.Text = DgvBanDoc.Rows[t].Cells[12].Value.ToString();
        }
        public void hienthi1(bool giatri)
        {
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            btnLuu.Enabled = !giatri;
            txtDiaChi.Enabled = !giatri;
            txtHoDem.Enabled = !giatri;
            txtHoVaTen.Enabled = !giatri;
            txtLop.Enabled = !giatri;      
            txtTen.Enabled = !giatri;
            dtpNgayCap.Enabled = !giatri;
            dtpNgayHetHan.Enabled = !giatri;
            dtpNgayHieuLuc.Enabled = !giatri;
            dtpNgaySinh.Enabled = !giatri;
            rdNam.Enabled = !giatri;
            rdNu.Enabled = !giatri;
            txtMaSV.Focus();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            hienthi1(false);
            txtHoDem.Focus();
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            int m;

            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 40000;

            for (m = 0; m <= 40000; m++)
            {
                toolStripProgressBar1.Value = m;
            }
            _Application excel = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = excel.Workbooks.Add(Type.Missing);
            _Worksheet sheet = null;

            sheet = workbook.ActiveSheet;
            sheet.Name = "DsDocGia";

            // Thêm dòng tiêu đề
            for (int c = 0; c < DgvBanDoc.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = DgvBanDoc.Columns[c].HeaderText;
            }
            
            // Thêm các dòng nội dung 
            for (int i = 0; i < DgvBanDoc.Rows.Count; i++)
            {
                for (int j = 0; j < DgvBanDoc.Columns.Count; j++)
                {
                    if (DgvBanDoc.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = DgvBanDoc.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.FileName = "DocGia";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách độc giả đã được xuất ra Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            TXTtimkiem.Enabled = true;
            TXTtimkiem.Clear();
            TXTtimkiem.Focus();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                XtraMessageBox.Show("Chọn vào dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.No)
                {
                    XtraMessageBox.Show("Xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (thongbao == DialogResult.Yes)
                {
                    string sql = "delete from BanDoc where MaSV = @ten";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ten", txtMaSV.Text);
                    cmd.ExecuteNonQuery();
                    frmBanDoc_Load(sender, e);
                    XtraMessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnHủy_Click(object sender, EventArgs e)
        {
             DialogResult thongbao = XtraMessageBox.Show("Bạn có chắc hủy các thao tác vừa thực hiện", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (thongbao == DialogResult.Yes)
             {
                
                 TXTtimkiem.Text = "Nhập từ khóa cần tìm...";
                 TXTtimkiem.Enabled = false;
                 frmBanDoc_Load(sender, e);
             }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            hienthi(false);
            txtMaSV.Text = taomasach();
            txtMaThe.Text = taomathe();
            txtHoDem.Focus();
            
        }

        private void txtHoVaTen_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtHoVaTen_Click(object sender, EventArgs e)
        {
            txtHoVaTen.Text = txtHoDem.Text  + " "+ txtTen.Text;
        }
        public DataTable HienDL(string sql)
        {
            con = new SqlConnection(conn);
            con.Open();
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }﻿
        private void TXTtimkiem_TextChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.Text == "Mã sinh viên") 
            {
                DgvBanDoc.DataSource = HienDL(" select * from BanDoc where MaSV like '%" + TXTtimkiem.Text.Trim() + "%' ");
            }
            if (cboTimKiem.Text == "Tên đầy đủ")
            {
                DgvBanDoc.DataSource = HienDL(" select * from BanDoc where HoVaTen like N'%" + TXTtimkiem.Text.Trim() + "%' ");
            }
            if (cboTimKiem.Text == "Lớp")
            {
                DgvBanDoc.DataSource = HienDL(" select * from BanDoc where LOP like '%" + TXTtimkiem.Text.Trim() + "%' ");
            }
            if (cboTimKiem.Text == "Mã thẻ")
            {
                DgvBanDoc.DataSource = HienDL(" select * from BanDoc where MaThe like '%" + TXTtimkiem.Text.Trim() + "%' ");
            }
            if (cboTimKiem.Text == "Địa chỉ")
            {
                DgvBanDoc.DataSource = HienDL(" select * from BanDoc where DiaChiSV like N'%" + TXTtimkiem.Text.Trim() + "%' ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TXTtimkiem.Clear();
            TXTtimkiem.Focus();
        }
    }

}