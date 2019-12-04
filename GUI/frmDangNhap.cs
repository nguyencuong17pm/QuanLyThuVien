using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Conect;
using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmDangNhap : Form
    {
        conect con = new conect();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
            txtTaiKhoan.Clear();
            txtmatkhau.Clear();
            
        }
       
        
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "")
            {
                XtraMessageBox.Show(" Tài khoản không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtmatkhau.Text.Trim() == "")
            {
                XtraMessageBox.Show("Mật khẩu không được bỏ trống ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

          
            string tk = txtTaiKhoan.Text;
            string mk = txtmatkhau.Text;
            DataTable dt = new DataTable();
            dt = con.GetData("select * from TAIKHOAN where TaiKhoan = '" + tk + "' and MatKhau = '" + mk + "'");
            if (dt.Rows.Count > 0)
            {

                frmMain f = new frmMain(dt.Rows[0][1].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                frmMain.HoVaTen = dt.Rows[0]["TaiKhoan"].ToString();
                frmMain.ID = dt.Rows[0]["ID"].ToString();
                frmMain.tenHienThi = dt.Rows[0]["TenHienThi"].ToString();
                frmMain.QHan = dt.Rows[0]["QuyenHan"].ToString();
                frmMain.matKhau = dt.Rows[0]["MatKhau"].ToString();
                XtraMessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f.ShowDialog();
                txtTaiKhoan.Clear();
                txtmatkhau.Clear();
                txtTaiKhoan.Focus();
            }
            else
            {
                XtraMessageBox.Show(" Tài khoản hoặc mật khẩu không chính xác ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Clear();
            txtmatkhau.Clear();
            checkBox1.Checked = false;
            txtTaiKhoan.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtmatkhau.PasswordChar = '\0';

            }
            else
            {
                txtmatkhau.PasswordChar = '*';
            }
        }

        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btndangnhap.PerformClick();
            }
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btndangnhap.PerformClick();
            }
        }

        private void txtmatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

       
    }
}
