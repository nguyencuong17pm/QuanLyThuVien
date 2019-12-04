using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;
namespace GUI
{
    public partial class frmCTMuonTra : Form
    {
        public frmCTMuonTra()
        {
            InitializeComponent();
        }

        private void frmCTMuonTra_Load(object sender, EventArgs e)
        {
            List<CTMuonTra_DTO> lstCTMuonTra = CTMuonTra_BUS.LayDSMT(); ;
            dgvCTMuonTra.DataSource = lstCTMuonTra;
            hienthi(true);
            loadMaMT();
            loadMaSach();
            dgvCTMuonTra.Columns["ID"].HeaderText = "STT";
            dgvCTMuonTra.Columns["ID"].Width = 40;
            dgvCTMuonTra.Columns["MaMuonTra"].HeaderText = "Mã mượn";
            dgvCTMuonTra.Columns["MaMuonTra"].Width = 100;
            dgvCTMuonTra.Columns["MaSach"].HeaderText = "Tên sách";
            dgvCTMuonTra.Columns["MaSach"].Width = 180;
            dgvCTMuonTra.Columns["DaTra"].HeaderText = "Đã trả";
            dgvCTMuonTra.Columns["DaTra"].Width = 75;
            dgvCTMuonTra.Columns["NgayTra"].HeaderText = "Ngày trả";
            dgvCTMuonTra.Columns["NgayTra"].Width = 90;
            dgvCTMuonTra.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvCTMuonTra.Columns["GhiChu"].Width = 200;
        }
        private int flag = 0;
        public void hienthi(bool giatri)
        {
            label5.Visible = false;
            ID.Visible = false;
            dtpNgayMuon.Visible = false;
            dtpNgayMuon.Enabled = !giatri;
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLuu.Enabled = !giatri;
            txtGhiChu.Enabled = !giatri;
            txtGhiChu.Clear();
            CK0.Enabled = !giatri;
            CK1.Enabled = !giatri;
            CK0.Checked = false;
            CK1.Checked = false;
        }
        public static string conn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLThuVien;Integrated Security=True";
        public static SqlConnection con;
        public void loadMaMT()
        {
            con = new SqlConnection(conn);
            con.Open();
            string sql = "select * from MuonTra";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboMaMuonTra.DataSource = dt;
            cboMaMuonTra.ValueMember = "MaMuonTra";
        }
        public void loadMaSach()
        {
            List<Sach_DTO> lstSach = Sach_BUS.LayDSSach();
            cboMaSach.DataSource = lstSach;
            cboMaSach.ValueMember = "TenSach";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hienthi(false);
            flag = 1;
        }
        public void hienthi1(bool giatri)
        {
            btnThem.Enabled = giatri;
            btnSua.Enabled = giatri;
            btnXoa.Enabled = giatri;
            BtnLuu.Enabled = !giatri;
            txtGhiChu.Enabled = !giatri;
            CK0.Enabled = !giatri;
            CK1.Enabled = !giatri;
            dtpNgayMuon.Enabled = !giatri;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 2;
            hienthi1(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CTMuonTra_DTO CT = new CTMuonTra_DTO();
            CT.ID = int.Parse(ID.Text);
            if (CTMuonTra_BUS.XoaCTMuonTra(ID.Text))
            {

                frmCTMuonTra_Load(sender, e);
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmCTMuonTra_Load(sender, e);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                CTMuonTra_DTO CT = new CTMuonTra_DTO();
                CT.MaMuonTra = cboMaMuonTra.Text;
                CT.MaSach = cboMaSach.Text;
                if (CK0.Checked == true)
                {

                    CT.DaTra = CK0.Text;
                    CT.NgayTra = textBox1.Text;

                }
                else
                {

                    CT.DaTra = CK1.Text;
                    CT.NgayTra = dtpNgayMuon.Text;

                }
                CT.GhiChu = txtGhiChu.Text;

                if (CTMuonTra_BUS.ThemCTMuonTra(CT))
                {

                    frmCTMuonTra_Load(sender, e);
                    MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (flag == 2)
            {
                CTMuonTra_DTO CT = new CTMuonTra_DTO();
                CT.ID = int.Parse(ID.Text);
                CT.MaMuonTra = cboMaMuonTra.Text;
                CT.MaSach = cboMaSach.Text;
                if (CK0.Checked == true)
                {

                    CT.DaTra = CK0.Text;
                    CT.NgayTra = textBox1.Text;

                }
                else
                {

                    CT.DaTra = CK1.Text;
                    CT.NgayTra = dtpNgayMuon.Text;

                }
                CT.GhiChu = txtGhiChu.Text;
                if (CTMuonTra_BUS.SuaCTMuonTra(CT))
                {

                    frmCTMuonTra_Load(sender, e);
                    MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            frmBCMuonTra BC = new frmBCMuonTra();
            BC.Show();
        }

        private void dgvCTMuonTra_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvCTMuonTra.SelectedRows[0];
                ID.Text = dr.Cells["ID"].Value.ToString();
                cboMaMuonTra.Text = dr.Cells["MaMuonTra"].Value.ToString();
                cboMaSach.Text = dr.Cells["MaSach"].Value.ToString();
                string Gender = "";
                if (dgvCTMuonTra.SelectedRows.Count > 0)
                {
                    Gender = dgvCTMuonTra.SelectedRows[0].Cells["DaTra"].Value.ToString();
                    if (Gender == "0")
                    {
                        CK0.Checked = true;
                    }
                    else
                        CK1.Checked = true;
                }
                dtpNgayMuon.Text = dr.Cells["NgayTra"].Value.ToString();
                txtGhiChu.Text = dr.Cells["GhiChu"].Value.ToString();
            }
            catch
            { }
        }

        private void CK0_CheckedChanged(object sender, EventArgs e)
        {
            if (CK0.Checked == true)
            {
                CK1.Checked = false;
                label5.Visible = false;
                dtpNgayMuon.Visible = false;
            }
        }

        private void CK1_CheckedChanged(object sender, EventArgs e)
        {
            if (CK1.Checked == true)
            {
                CK0.Checked = false;
                label5.Visible = true;
                dtpNgayMuon.Value = DateTime.Now;
                dtpNgayMuon.Visible = true;
            }
        }
    }
}