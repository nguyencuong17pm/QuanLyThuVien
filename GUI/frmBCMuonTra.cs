using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI
{
    public partial class frmBCMuonTra : Form
    {
        public frmBCMuonTra()
        {
            InitializeComponent();
        }

        private void frmBCMuonTra_Load(object sender, EventArgs e)
        {

        }

        private void cboDieuKien_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboDieuKien.Text == "Mã mượn trả")
            {
                CTMuonTra_DTOBindingSource.DataSource = CTMuonTra_BUS.LayDSMT();
                this.reportViewer1.RefreshReport();
                List<CTMuonTra_DTO> lst = CTMuonTra_BUS.LayDSMT();
                cboDanhSach.DataSource = lst;
                CTMuonTra_DTO CT = new CTMuonTra_DTO();
                CT.MaMuonTra = "TC";
                CT.MaMuonTra = "Tất cả";
                lst.Insert(0, CT);
                cboDanhSach.DisplayMember = "MaMuonTra";
            }
            else if (cboDieuKien.Text == "Tình trạng")
            {
                CTMuonTra_DTOBindingSource.DataSource = CTMuonTra_BUS.LayDSMT();
                this.reportViewer1.RefreshReport();
                List<CTMuonTra_DTO> lst = CTMuonTra_BUS.LayDSMT();
                cboDanhSach.DataSource = lst;
                CTMuonTra_DTO CT = new CTMuonTra_DTO();
                CT.DaTra = "TC";
                CT.DaTra = "Tất cả";
                lst.Insert(0, CT);
                cboDanhSach.DisplayMember = "DaTra";

            }
        }
        private string dieukien;
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboDanhSach.Text == "Tất cả")
            {
                CTMuonTra_DTOBindingSource.DataSource = CTMuonTra_BUS.LayDSMT();
                this.reportViewer1.RefreshReport();
            }
            else if (cboDieuKien.Text == "Tình trạng")
            {
                dieukien = "DaTra";
                CTMuonTra_DTOBindingSource.DataSource = CTMuonTra_BUS.TimKiem(dieukien, cboDanhSach.Text);

                this.reportViewer1.RefreshReport();

            }
            else if (cboDieuKien.Text == "Mã mượn trả")
            {
                dieukien = "MaMuonTra";
                CTMuonTra_DTOBindingSource.DataSource = CTMuonTra_BUS.TimKiem(dieukien, cboDanhSach.Text);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
