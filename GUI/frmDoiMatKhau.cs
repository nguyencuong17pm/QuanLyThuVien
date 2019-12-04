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
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = " select * from TAIKHOAN ";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgvtk.DataSource = dt;
            txtmkmoi1.Clear();
            txtmkmoi2.Clear();
            dgvtk.Visible = false;
            TenHT.Visible = false;
            TK.Visible = false;
            ID.Visible = false;
            QuyenHan.Visible = false;
            txtmkmoi1.Focus();
           
        }
        
        private void dgvtk_Click(object sender, EventArgs e)
        {
            int t = dgvtk.CurrentCell.RowIndex;
            ID.Text = dgvtk.Rows[t].Cells[0].Value.ToString();
            TK.Text = dgvtk.Rows[t].Cells[1].Value.ToString();
            TenHT.Text = dgvtk.Rows[t].Cells[2].Value.ToString();
            txtmkcu.Text = dgvtk.Rows[t].Cells[3].Value.ToString();
            QuyenHan.Text  = dgvtk.Rows[t].Cells[4].Value.ToString();
            
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
          
             if (txtmkmoi1.Text.Trim() == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmkmoi2.Text.Trim() == "")
            {
                XtraMessageBox.Show("Bạn chưa xác nhận lại mật khẩu mới" ,"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else if (txtmkmoi1.Text.Trim() != txtmkmoi2.Text.Trim())
            {
                XtraMessageBox.Show("Hai mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             else if (txtmkmoi1.Text.Trim().Length > 8)
             {
                 XtraMessageBox.Show("Mật khẩu chỉ tối đa 8 ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else if (txtmkmoi1.Text.Trim().Length < 4)
             {
                 XtraMessageBox.Show("Mật khẩu không an toàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else if (txtmkmoi2.Text.Trim().Length > 8)
             {
                 XtraMessageBox.Show("Mật khẩu chỉ tối đa 8 ký tự số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else if (txtmkmoi2.Text.Trim().Length < 4)
             {
                 XtraMessageBox.Show("Mật khẩu không an toàn");
             }
             else
             {
                 DialogResult thongbao = (XtraMessageBox.Show("Bạn có chắc muốn đổi mật khẩu không ? ", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));

                 if (thongbao == DialogResult.Yes)
                 {
                     string sql = "update TaiKhoan set TaiKhoan = @tk,TenHienThi = @tht, MatKhau = @mk, QuyenHan = @qh where ID = @Id";
                     SqlCommand cmd = new SqlCommand(sql, con);
                     cmd.Parameters.AddWithValue("@Id", ID.Text);
                     cmd.Parameters.AddWithValue("tk", TK.Text);
                     cmd.Parameters.AddWithValue("@tht", TenHT.Text);
                     cmd.Parameters.AddWithValue("@mk", txtmkmoi1.Text);
                     cmd.Parameters.AddWithValue("@qh", QuyenHan.Text);
                     cmd.ExecuteNonQuery();
                     frmDoiMatKhau_Load(sender, e);
                     XtraMessageBox.Show("Bạn đã đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }
        }

        private void ckbhienthimk_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbhienthimk.Checked == true)
            {
                txtmkcu.PasswordChar = '\0';
                txtmkmoi1.PasswordChar = '\0';
                txtmkmoi2.PasswordChar = '\0'; 
            }
            else
            {
                txtmkcu.PasswordChar = '*';
                txtmkmoi1.PasswordChar = '*';
                txtmkmoi2.PasswordChar = '*';
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau_Load(sender, e);
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmkmoi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtmkmoi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }
    }
}
