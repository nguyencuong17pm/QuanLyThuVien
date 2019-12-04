using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GUI.Conect;
namespace GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        conect con = new conect();
        public string taikhoan = "", matkhau = "", quyenhan = "";
        frmDangNhap DN = null;
        frmNhanVien NV = null;
        frmSach Sach = null;
        frmTaiKhoan TK = null;
        frmNhaXuatBan NXB = null;
        frmTheLoai TL = null;
        frmBCSach BCSach = null;
        frmMuonTra MT = null;
        frmCTMuonTra CT = null;    
        frmMuonSach MS = null;
        frmDoiMatKhau DMK = null;
        frmBanDoc BD = null;
        frmBCMuonTra BCMT = null;
        public static string HoVaTen = "";
        public static string ID = "";
        public static string QHan = "";
        public static string matKhau = "";

        public static string tenHienThi = "";
        private FontDialog fd = new FontDialog();
        public frmMain(string taikhoan, string matkhau, string quyenhan)
        {
            InitializeComponent();
            this.taikhoan = taikhoan;
            this.matkhau = matkhau;
            this.quyenhan = quyenhan;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
           
            if (quyenhan == "Nhân viên")
            {
                nhanvien();
            }
            else if (quyenhan == "Quản lý")
            {
                quanly();

            }
            else if (quyenhan == "Sinh Viên")
            {
                sinhvien();
            }
            else
            {
                hienthi();
            }
        }
        public void hienthi()
        {
           
            btnDoiMatKhau.Enabled = false;
            mnuBaoCaoThongKe.Enabled = false;
            mnuQuanLy.Enabled = false;
      
            mnuDangXuat.Enabled = false;
            mnuDoiMK.Enabled = false;
            btnNXB.Enabled = false;
            btnDocGia.Enabled = false;
            btnSach.Enabled = false;
            btnNhanVien.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnSVMuon.Enabled = false;
            btnPhieuMuon.Enabled = false;
            BtnPhieuTra.Enabled = false;
         
            btnTheLoai.Enabled = false;
            btnDangXuat.Enabled = false;
            thoidiem.Text = "Phần mềm quản lý thư viện_Version 1.0.0.0";
            loichao.Text = "Bạn cần đăng nhập để sử dụng";

        }
        private void btnSach_Click(object sender, EventArgs e)
        {
          
             
               
            
           
            //if (quyenhan == "Sinh Viên")
            //{
            //    sinhvien2();
            //}
            //else if (quyenhan == "Nhân viên")
            //{
            //    nhanvien1();
            //}
            //if (quyenhan == "Quản lý")
            //{
            //    nhanvien1();
            //}
            //else
            if (Sach == null || Sach.IsDisposed)
            {
                Sach = new frmSach();
                Sach.MdiParent = this;
                Sach.Show();

            }

            else
                Sach.Activate();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
           
            if (NV == null || NV.IsDisposed)
            {
                NV = new frmNhanVien();
                NV.MdiParent = this;
                NV.Show();
            }
            else
                NV.Activate();
        }



        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {

            if (TK == null || TK.IsDisposed)
            {
                TK = new frmTaiKhoan();
                TK.MdiParent = this;
                TK.Show();
            }
            else
                TK.Activate();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {

            this.Close();
            //DialogResult thongbao = (MessageBox.Show("Bạn có chắc muốn đăng xuất không ? ", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            //if (thongbao == DialogResult.Yes)
            //{
            //    this.Close();
            //    LS = new frmGhiLichSu();
            //    LS.Show();
            //    LS.txtNguoiDung.Text = HoVaTen;
            //    LS.txtTD.Text = thoidiem.Text;
            //    LS.dgvLichSu.Visible = false;
            //    LS.txtTĐX.Visible = false;
            //    LS.txtTD.Visible = false;
            //    LS.txtNguoiDung.Visible = false;
            //    LS.label1.Visible = false;
            //    LS.label2.Visible = false;
            //    LS.label3.Visible = false;
            //    LS.btnDangNhap.Visible = true;
            //    LS.btnThoat.Visible = true;
            //    LS.btnXoa.Visible = false;
            //    LS.lbltieude.Visible = false;
            //    LS.label5.Visible = true;
            //}
            //else
            //{
            //    this.Close();
            //    DN = new frmDangNhap();
            //    DN.Show();
            //}
        }
        public void quanly()
        {
          
            btnDangNhap.Enabled = false;
            MnuDangNhap.Enabled = false;
            loichao.Text = "Quản lý: " + tenHienThi;
            thoidiem.Text = "Thời điểm đăng nhập: " + DateTime.Now;

        }

        public void nhanvien()
        {
           
            btnDangNhap.Enabled = false;
            MnuDangNhap.Enabled = false;
            mnuQuanLy.Visible = true;
            mnuTaikhoan.Visible = false;
          
            btnNhanVien.Visible = false;
            btnTaiKhoan.Visible = false;

            loichao.Text = "Nhân viên: " + HoVaTen;
            thoidiem.Text = "Thời điểm đăng nhập: " + DateTime.Now;
        }

        public void sinhvien()
        {
           
            toolStripSeparator6.Visible = false;
            btnDangNhap.Enabled = false;
            MnuDangNhap.Enabled = false;
         
            mnuQuanLy.Visible = false;
            mnuBaoCaoThongKe.Visible = false;
            btnDocGia.Visible = false;
            btnSach.Visible = false;
            btnNhanVien.Visible = false;
            btnPhieuMuon.Visible = false;
            btnTaiKhoan.Visible = false;
            btnTheLoai.Visible = false;
            btnSVMuon.Text = "Mượn sách online";
            btnPhieuMuon.Visible = false;
            btnNXB.Visible = false;
            BtnPhieuTra.Visible = false;
            loichao.Text = "Sinh viên: " + tenHienThi;
            thoidiem.Text = "Thời điểm đăng nhập: " + DateTime.Now;

        }

        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, System.IO.Path.Combine(Application.StartupPath, "FileHelp.chm"));
        }

        private void btnNXB_Click(object sender, EventArgs e)
        {
        
            if (NXB == null || NXB.IsDisposed)
            {
                NXB = new frmNhaXuatBan();
                NXB.MdiParent = this;
                NXB.Show();
            }
            else
                NXB.Activate();
        }

        private void btnTheLoai_Click(object sender, EventArgs e)
        {
            if (TL == null || TL.IsDisposed)
            {
                TL = new frmTheLoai();
                TL.MdiParent = this;
                TL.Show();
            }
            else
                TL.Activate();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao = (XtraMessageBox.Show("Bạn có muốn thoát không ? ", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information));
            if (thongbao == DialogResult.Yes)
                Application.Exit();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            btnDangXuat_Click(sender, e);
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            btnThoat_Click(sender, e);
        }

        private void mnuSach_Click(object sender, EventArgs e)
        {
            btnSach_Click(sender, e);
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            btnNhanVien_Click(sender, e);
        }

        private void mnuTheThuVien_Click(object sender, EventArgs e)
        {
            if (BD == null || BD.IsDisposed)
            {
                BD = new frmBanDoc();
                BD.MdiParent = this;
                BD.Show();
            }
            else
                BD.Activate();
        }

        private void mnuTaikhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan_Click(sender, e);
        }

        private void mnuNXB_Click(object sender, EventArgs e)
        {
            btnNXB_Click(sender, e);
        }

        private void mnuTheLoai_Click(object sender, EventArgs e)
        {
            btnTheLoai_Click(sender, e);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }


        private void mnuTKsach_Click(object sender, EventArgs e)
        {
            if (BCSach == null || BCSach.IsDisposed)
            {
                BCSach = new frmBCSach();
                BCSach.MdiParent = this;
                BCSach.Show();
            }
            else
                BCSach.Activate();
        }
        
        private void mnuTKNhanVien_Click(object sender, EventArgs e)
        {
            if (BCMT == null || BCMT.IsDisposed)
            {
                BCMT = new frmBCMuonTra(); 
                BCMT.MdiParent = this;
                BCMT.Show();

            }

            else
                BCMT.Activate();
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            if (BD == null || BD.IsDisposed)
            {
                BD = new frmBanDoc();
                BD.MdiParent = this;
                BD.Show();
            }
            else
                BD.Activate();
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {

            if (MT == null || MT.IsDisposed)
            {
                MT = new frmMuonTra();
                MT.MdiParent = this;
                MT.Show();
            }
            else
                MT.Activate();
        }

        private void BtnPhieuTra_Click(object sender, EventArgs e)
        {

            if (CT == null || CT.IsDisposed)
            {
                CT = new frmCTMuonTra();
                CT.MdiParent = this;
                CT.Show();
            }
            else
                CT.Activate();
        }

        private void MnuPhieuMuon_Click(object sender, EventArgs e)
        {
            btnPhieuMuon_Click(sender, e);
        }

        private void mnuPhieuTra_Click(object sender, EventArgs e)
        {
            BtnPhieuTra_Click(sender, e);
        }
        public int i = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += 10;
            if (pictureBox1.Left >= 2000)
                timer1.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btnHuongDan_Click(sender, e);
        }

        private void btnSVMuon_Click(object sender, EventArgs e)
        {
            if (quyenhan == "Sinh Viên")
            {
                if (MS == null || MS.IsDisposed)
                {
                    MS = new frmMuonSach();
                    MS.MdiParent = this;
                    MS.Show();
                    MS.btnXoa.Visible = false;
                    MS.btnSua.Visible = false;
                    MS.button1.Visible = false;
                    MS.label5.Visible = true;
                    MS.btnHuy.Visible = false;
                    MS.progressBar1.Visible = false;
                    MS.txtTimkiem.Text = HoVaTen;
                    MS.txtTimkiem.Visible = false;
                    MS.groupControl2.Text = "Ghi chú dành cho sinh viên đăng ký mượn";
                    MS.textBox1.Visible = false;
                    this.MS.txtMaSV.Text = HoVaTen;
                    
                }
                else
                    MS.Activate();
            }
            if (quyenhan == "Quản lý")
            {
                if (MS == null || MS.IsDisposed)
                {
                    MS = new frmMuonSach();
                    MS.MdiParent = this;
                    MS.Show();
                    MS.BtnLUU.Text = "Lưu lại";
                }
                else
                    MS.Activate();
            }
            if (quyenhan == "Nhân viên")
            {
                if (MS == null || MS.IsDisposed)
                {
                    MS = new frmMuonSach();
                    MS.MdiParent = this;
                    MS.Show();

                }
                else
                    MS.Activate();
            }
            if (MS == null || MS.IsDisposed)
            {
                MS = new frmMuonSach();
                MS.MdiParent = this;
                MS.Show();
            }
            else
                MS.Activate();
        }

        private void mnuSVmuon_Click(object sender, EventArgs e)
        {
            btnSVMuon_Click(sender, e);
        }

        private void mnuDoiMK_Click(object sender, EventArgs e)
        {
            if (DMK == null || DMK.IsDisposed)
            {
                //TK = new frmTaiKhoan();
                //TK.MdiParent = this;
                //TK.Show();
                //this.TK.groupBox3.Visible = false;
                //this.TK.BtnLUU.Visible = false;
                //this.TK.button1.Visible = true;
                //TK.cboTenHT.Visible = false;
                //TK.label5.Visible = false;
                //TK.cboQuyenHan.Visible = false;
                //TK.DgvTaiKhoan.Visible = false;
                //TK.pictureBox1.Visible = true;
                //TK.groupBox2.Text = "";
                //TK.txttracuu.Visible = false;
                //TK.label17.Visible = false;
                //TK.label4.Visible = false;
                //TK.nmID.Visible = false;
                //TK.label1.Visible = false;
                //TK.ribbonControl1.Visible = false;
                //TK.label3.Text = "Mật khẩu mới";
                //this.TK.txtTaiKhoan.Enabled = false;
                //this.TK.txtTaiKhoan.Text = HoVaTen;
                //this.TK.nmID.Text = ID;
                //this.TK.cboQuyenHan.Text = QHan;
                DMK = new frmDoiMatKhau();
                DMK.MdiParent = this;
                DMK.Show();
                DMK.ID.Text = ID;
                DMK.TK.Text = taikhoan;
                DMK.QuyenHan.Text = quyenhan;
                DMK.txtmkcu.Text = matKhau;
                DMK.TenHT.Text = tenHienThi;

            }
            else
                DMK.Activate();

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (DN == null || DN.IsDisposed)
            {
                DN = new frmDangNhap();
                DN.MdiParent = this;
                DN.Show();

            }
            else
                DN.Activate();
        }

        private void MnuDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap_Click(sender, e);
        }


        private void btnDoiFont_Click_1(object sender, EventArgs e)
        {

            if (DialogResult.OK == fd.ShowDialog(this))
                foreach (var ctrl in this.Controls.OfType<Control>())
                    ctrl.Font = fd.Font;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (var ctrl in this.Controls.OfType<Control>())
                ctrl.Font = new Font("Segoe UI", 9);
            fd.Font = new Font("Segoe UI", 9);
            foreach (var button in this.Controls.OfType<Button>())
                button.BackColor = Color.FromArgb(94, 178, 225);
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            btnDoiFont_Click_1(sender, e);
        }

        private void mnuMacDinh_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            mnuDoiMK_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AboutBox1 tb = new AboutBox1();
            tb.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult dlr = XtraMessageBox.Show("Trở về trang chủ sẽ đóng tất cả các Form đang mở", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                foreach (Form mdiForm in this.MdiChildren)
                {
                    mdiForm.Close();
                }
                
            }
        }

     
    }
}
