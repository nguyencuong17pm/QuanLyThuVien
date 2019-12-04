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
namespace GUI
{
    public partial class frmMuonTra : Form
    {
        public frmMuonTra()
        {
            InitializeComponent();
        }
        private int flag = 0;
        //public static  SqlConnection con = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLTV1;Integrated Security=True");
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            dgvMuonTra.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            con = new SqlConnection(conn);
            con.Open();
            string sql = "Select * from MuonTra";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvMuonTra.DataSource = dt;
            hienthi(true);
            loadmathe();
            loadnv();
            loadsach();
        }
        public void loadmathe()
        {
            string sql = "select * from BanDoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboMaThe.DataSource = dt;
            cboMaThe.DisplayMember = "MaThe";
        }
        public void loadnv()
        {

            string sql = "select * from nhanvien";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboMaNV.DataSource = dt;
            cboMaNV.DisplayMember = "TenNV";

        }
        public void loadsach()
        {

            string sql = "select * from sach";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboMaSach.DataSource = dt;
            cboMaSach.DisplayMember = "MaSach";
        }
        public void hienthi(bool giatri)
        {
            btnThem.Enabled = giatri;
            btnXoa.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnLuu.Enabled = !giatri;
            txtMaMuonTra.Clear();
            dtpNgayMuon.Value = DateTime.Now;
            dtpNgayMuon.Enabled = !giatri;
            dateTimePicker1.Enabled = !giatri;
            dateTimePicker1.Value = DateTime.Now;
            txtSoTien.Enabled = !giatri;
            txtSoTien.Clear();

        }
        public void hienthi1(bool giatri)
        {
            btnThem.Enabled = giatri;
            btnXoa.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnLuu.Enabled = !giatri;
            dtpNgayMuon.Enabled = !giatri;
            txtSoTien.Enabled = !giatri;
            dateTimePicker1.Enabled = !giatri;
        }
        private string taomamuon()
        {
            string mamuon;
            Random r = new Random();
            mamuon = "M" + r.Next(10, 999).ToString();
            return mamuon;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 1;
            hienthi(false);
            txtMaMuonTra.Text = taomamuon();
            txtMaMuonTra.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            hienthi1(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongbao == DialogResult.Yes)
            {
                string sql = "delete from MuonTra where MaMuonTra = @ma";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ma", txtMaMuonTra.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                frmMuonTra_Load(sender, e);
                MessageBox.Show("Xóa thành công!!!");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            hienthi(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                try
                {
                    string sql = "insert into MuonTra values (@maMT, @mathe,@masach, @manv, @ngaymuon,@kyhan, @soluong, @sotien )";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@maMT", txtMaMuonTra.Text);
                    cmd.Parameters.AddWithValue("@mathe", cboMaThe.Text);
                    cmd.Parameters.AddWithValue("@masach", cboMaSach.Text);
                    cmd.Parameters.AddWithValue("@manv", cboMaNV.Text);
                    cmd.Parameters.AddWithValue("@ngaymuon", dtpNgayMuon.Text);
                    cmd.Parameters.AddWithValue("@kyhan", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@soluong", cboSoLuong.Text);
                    cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frmMuonTra_Load(sender, e);

                    MessageBox.Show("Thêm thành công!!!");
                }
                catch
                {
                    MessageBox.Show("Không thêm được. Vui lòng kiểm tra lại!!!");
                }
            }
            else
            {
                try
                {
                    if (txtMaMuonTra.Text.Trim().Length > 5)
                    {
                        MessageBox.Show("Không sửa được. Mã mượn trả là khóa chính tối đa 5 ký tự !!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string sql = "update MuonTra set MaThe = @mathe, MaSach = @masach, TenNV = @manv, NgayMuon = @ngaymuon, KyHanTra = @kyhan, SoLuongMuon = @soluong, SoTien = @sotien where MaMuonTra = @maMT ";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.AddWithValue("@maMT", txtMaMuonTra.Text);
                        cmd.Parameters.AddWithValue("@mathe", cboMaThe.Text);
                        cmd.Parameters.AddWithValue("@masach", cboMaSach.Text);
                        cmd.Parameters.AddWithValue("@manv", cboMaNV.Text);
                        cmd.Parameters.AddWithValue("@ngaymuon", dtpNgayMuon.Text);
                        cmd.Parameters.AddWithValue("@kyhan", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@soluong", cboSoLuong.Text);
                        cmd.Parameters.AddWithValue("@sotien", txtSoTien.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        frmMuonTra_Load(sender, e);
                        MessageBox.Show("Sửa thành công!!!");
                    }
                }
                catch
                {
                    MessageBox.Show("Không sửa được. Vui lòng kiểm tra lại!!!");
                }
            }
        }

        private void dgvMuonTra_Click(object sender, EventArgs e)
        {
            int t = dgvMuonTra.CurrentCell.RowIndex;
            txtMaMuonTra.Text = dgvMuonTra.Rows[t].Cells[0].Value.ToString();
            cboMaThe.Text = dgvMuonTra.Rows[t].Cells[1].Value.ToString();
            cboMaSach.Text = dgvMuonTra.Rows[t].Cells[2].Value.ToString();
            cboMaNV.Text = dgvMuonTra.Rows[t].Cells[3].Value.ToString();
            dtpNgayMuon.Text = dgvMuonTra.Rows[t].Cells[4].Value.ToString();
            dateTimePicker1.Text = dgvMuonTra.Rows[t].Cells[5].Value.ToString();
            cboSoLuong.Text = dgvMuonTra.Rows[t].Cells[6].Value.ToString();
            txtSoTien.Text = dgvMuonTra.Rows[t].Cells[7].Value.ToString();
        }

        private void txtSoTien_Click(object sender, EventArgs e)
        {
            txtSoTien.Text = "VNĐ";
        }
    }
}
