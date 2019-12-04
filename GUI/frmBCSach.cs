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
namespace GUI
{
    public partial class frmBCSach : Form
    {
        public frmBCSach()
        {
            InitializeComponent();
        }

        private void frmBCSach_Load(object sender, EventArgs e)
        {

            cboDieuKien.Text = "Mã sách";
        }

        private void cboDieuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDieuKien.Text == "Mã sách")
            {
                Sach_DTOBindingSource.DataSource = Sach_BUS.LayDSSach();
                this.reportViewer1.RefreshReport();
                List<Sach_DTO> lst = Sach_BUS.LayDSSach();
                cboMaThe.DataSource = lst;
                Sach_DTO d = new Sach_DTO();
                d.MaSach = "TC";
                d.MaSach = "Tất cả";
                lst.Insert(0, d);
                cboMaThe.ValueMember = "MaSach";
                cboMaThe.DisplayMember = "MaSach";
            }

            else if (cboDieuKien.Text == "Tên sách")
            {
                Sach_DTOBindingSource.DataSource = Sach_BUS.LayDSSach();
                this.reportViewer1.RefreshReport();
                List<Sach_DTO> lst = Sach_BUS.LayDSSach();
                cboMaThe.DataSource = lst;
                Sach_DTO d = new Sach_DTO();
                d.TenSach = "TC";
                d.TenSach = "Tất cả";
                lst.Insert(0, d);
                cboMaThe.ValueMember = "TenSach";
                cboMaThe.DisplayMember = "TenSach";
            }
            else if (cboDieuKien.Text == "Năm xuất bản")
            {
                Sach_DTOBindingSource.DataSource = Sach_BUS.LayDSSach();
                this.reportViewer1.RefreshReport();
                List<Sach_DTO> lst = Sach_BUS.LayDSSach();
                cboMaThe.DataSource = lst;
                Sach_DTO d = new Sach_DTO();
                d.NamXB = "TC";
                d.NamXB = "Tất cả";
                lst.Insert(0, d);
                cboMaThe.ValueMember = "NamXB";
                cboMaThe.DisplayMember = "NamXB";
            }
            else if (cboDieuKien.Text == "Tác giả")
            {
                Sach_DTOBindingSource.DataSource = Sach_BUS.LayDSSach();
                this.reportViewer1.RefreshReport();
                List<Sach_DTO> lst = Sach_BUS.LayDSSach();
                cboMaThe.DataSource = lst;
                Sach_DTO d = new Sach_DTO();
                d.TacGia = "TC";
                d.TacGia = "Tất cả";
                lst.Insert(0, d);
                cboMaThe.ValueMember = "TacGia";
                cboMaThe.DisplayMember = "TacGia";
            }
        }
        private string dieukien;
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboMaThe.Text == "Tất cả")
            {
                Sach_DTOBindingSource.DataSource = Sach_BUS.LayDSSach();
                this.reportViewer1.RefreshReport();
            }
            else if (cboDieuKien.Text == "Tên sách")
            {
                dieukien = "TenSach";
                Sach_DTOBindingSource.DataSource = Sach_BUS.TimSach(dieukien, cboMaThe.Text);
                this.reportViewer1.RefreshReport();

            }
            else if (cboDieuKien.Text == "Mã sách")
            {
                dieukien = "MaSach";              
                Sach_DTOBindingSource.DataSource = Sach_BUS.TimSach(dieukien, cboMaThe.Text);
                //dieukien = cboMaThe.SelectedValue.ToString();
                //List<SachMuon_DTO> lstTimKiem = SachMuon_BUS.TimSach(dieukien, txttracuu.Text);
                //DgvSachMuon.DataSource = lstTimKiem;
                this.reportViewer1.RefreshReport();
            }
            else if (cboDieuKien.Text == "Năm xuất bản")
            {
                dieukien = "NamXB";
                Sach_DTOBindingSource.DataSource = Sach_BUS.TimSach(dieukien, cboMaThe.Text);
                //dieukien = cboMaThe.SelectedValue.ToString();
                //List<SachMuon_DTO> lstTimKiem = SachMuon_BUS.TimSach(dieukien, txttracuu.Text);
                //DgvSachMuon.DataSource = lstTimKiem;
                this.reportViewer1.RefreshReport();
            }
            else if (cboDieuKien.Text == "Tác giả")
            {
                dieukien = "TacGia";
                Sach_DTOBindingSource.DataSource = Sach_BUS.TimSach(dieukien, cboMaThe.Text);
                //dieukien = cboMaThe.SelectedValue.ToString();
                //List<SachMuon_DTO> lstTimKiem = SachMuon_BUS.TimSach(dieukien, txttracuu.Text);
                //DgvSachMuon.DataSource = lstTimKiem;
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
