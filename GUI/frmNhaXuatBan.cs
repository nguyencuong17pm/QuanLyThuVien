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
using BUS;

using DevExpress.XtraEditors;
namespace GUI
{
    public partial class frmNhaXuatBan : Form
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }
        private int flag = 0;
        private string dieukien;
        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            List<NhaXuatBan_DTO> lstNXB = NhaXuatBan_BUS.LayDSTK();
            DgvNhaXuatBan.DataSource = lstNXB;
            DgvNhaXuatBan.Columns["MaNXB"].HeaderText = "Mã nhà xuất bản";
            DgvNhaXuatBan.Columns["MaNXB"].Width = 150;
            DgvNhaXuatBan.Columns["TenNXB"].HeaderText = "Tên nhà xuất bản";
            DgvNhaXuatBan.Columns["TenNXB"].Width = 400;
            
            HienThi(true);
            txttracuu.Enabled = false;
           
        }
        public void HienThi(bool giaTri)
        {
            
            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
            txtTenNXB.Enabled = !giaTri;
            txtNXB.Clear();
            txtTenNXB.Clear();
            txtTenNXB.Focus();
        }
        public void HienThi1(bool giaTri)
        {

            BtnLUU.Enabled = !giaTri;
            btnSua.Enabled = giaTri;
            btnXoa.Enabled = giaTri;
            btnThem.Enabled = giaTri;
            txtTenNXB.Enabled = !giaTri;
            txtTenNXB.Focus();
        }
        private void BtnLUU_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (txtTenNXB.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa nhập tên nhà xuất bản!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (NhaXuatBan_BUS.TimNXB_TheoMa(txtNXB.Text.Trim()) != null)
                {
                    XtraMessageBox.Show("Mã nhà xuất bản không được trùng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
                    NXB.MaNXB = txtNXB.Text.Trim();
                    NXB.TenNXB = txtTenNXB.Text.Trim();
                    if (NhaXuatBan_BUS.ThemNXB(NXB))
                    {
                        frmNhaXuatBan_Load(sender, e);
                        XtraMessageBox.Show("Bạn đã thêm thành công " + txtNXB.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        XtraMessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else if (flag == 2)
            {
                if (txtNXB.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Bạn chưa chọn dòng cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNXB.Focus();
                }
              else  if (txtTenNXB.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Tên nhà xuất bản không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNXB.Focus();
                }
                else
                {
                    NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
                    NXB.MaNXB = txtNXB.Text.Trim();
                    NXB.TenNXB = txtTenNXB.Text.Trim();
                    if (NhaXuatBan_BUS.SuaNXB(NXB))
                    {
                        frmNhaXuatBan_Load(sender, e);
                        XtraMessageBox.Show("Sửa nhà xuất bản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa nhà xuất bản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenNXB.Focus();
                    }
                }
            }
            
        }
        private void matudong()
        {
            string MaNXB = "NXB01";
            int dem = 0;
            while (NhaXuatBan_BUS.TimNXB_TheoMa(MaNXB) != null)
            {
                dem += 1;
                if (dem < 10)
                    MaNXB = "NXB0" + dem.ToString();
                else if (dem < 100)
                    MaNXB = "NXB" + dem.ToString();
                else
                    XtraMessageBox.Show("Không thể thêm nữa. Không đủ bộ nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNXB.Text = MaNXB;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            flag = 1;
            HienThi(false);
            matudong();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(NhaXuatBan_BUS.TimNXB_TheoMa(txtNXB.Text.Trim()) == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng cần xóa?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DialogResult dr = XtraMessageBox.Show("Bạn chắc chắn muốn xoá loại này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    XtraMessageBox.Show("Xoá thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dr == DialogResult.Yes)
                {
                    if (NhaXuatBan_BUS.XoaNXB(txtNXB.Text.Trim()))
                    {
                        frmNhaXuatBan_Load(sender, e);
                        XtraMessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
                        //NXB.MaNXB = txtNXB.Text;
                        //if (NhaXuatBan_BUS.XoaNXB(NXB) == false)
                        //{
                        //    List<NhaXuatBan_DTO> lstTK = NhaXuatBan_BUS.LayDSTK();
                        //    DgvNhaXuatBan.DataSource = lstTK;
                        //    MessageBox.Show("Bạn đã xóa thành công " + txtTenNXB.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void DgvNhaXuatBan_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = DgvNhaXuatBan.SelectedRows[0];
                txtNXB.Text = dr.Cells["MaNXB"].Value.ToString();
                txtTenNXB.Text = dr.Cells["TenNXB"].Value.ToString();
            }
            catch
            { }
            //int t = DgvNhaXuatBan.CurrentCell.RowIndex;
            //txtNXB.Text = DgvNhaXuatBan.Rows[t].Cells[0].Value.ToString();
            //txtTenNXB.Text = DgvNhaXuatBan.Rows[t].Cells[1].Value.ToString();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HienThi1(false);
            flag = 2; 
            //NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
            //NXB.MaNXB = txtNXB.Text;
            //NXB.TenNXB = txtTenNXB.Text;
            //if (NhaXuatBan_BUS.SuaNXB(NXB) == false)
            //{
            //    List<NhaXuatBan_DTO> lstTK = NhaXuatBan_BUS.LayDSTK();
            //    DgvNhaXuatBan.DataSource = lstTK;
            //    MessageBox.Show("Bạn đã sửa thành công " + txtNXB.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    frmNhaXuatBan_Load(sender, e);
            
        }
       
        private void cbotimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txttracuu.Enabled = true;
            txttracuu.Clear();
            txttracuu.Focus();
            if (cbotimkiem.Text == "Mã NXB")
            {
                dieukien = "MaNXB";
            }
            else
                if (cbotimkiem.Text == "Tên NXB")
                {
                    dieukien = "TenNXB";
                }
        }

        private void txttracuu_TextChanged(object sender, EventArgs e)
        {
            if (txttracuu.Text.Trim() == "")
            {
                List<NhaXuatBan_DTO> lstTK = NhaXuatBan_BUS.LayDSTK();
                DgvNhaXuatBan.DataSource = lstTK;
            }
            else
            {
                List<NhaXuatBan_DTO> lstTimKiem = NhaXuatBan_BUS.TimNXB(dieukien, txttracuu.Text);
                DgvNhaXuatBan.DataSource = lstTimKiem;
            }
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
            sheet.Name = "DsNXB";

            // Thêm dòng tiêu đề
            for (int c = 0; c < DgvNhaXuatBan.Columns.Count; c++)
            {
                sheet.Cells[1, c + 1] = DgvNhaXuatBan.Columns[c].HeaderText;
            }

            // Thêm các dòng nội dung
            for (int i = 0; i < DgvNhaXuatBan.Rows.Count; i++)
            {
                for (int j = 0; j < DgvNhaXuatBan.Columns.Count; j++)
                {
                    if (DgvNhaXuatBan.Rows[i].Cells[j].Value != null)
                    {
                        sheet.Cells[i + 2, j + 1] = DgvNhaXuatBan.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }

            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Excel 2007 (*.xlsx)|*.xlsx|Excel 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            file.FilterIndex = 1;
            file.FileName = "NhaXuatBan";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(file.FileName);
                workbook.Close();
                excel.Quit();
                XtraMessageBox.Show("Danh sách nhà xuất bản đã được xuất ra Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txttracuu.Text = "Nhập từ khóa cần tìm...";
            frmNhaXuatBan_Load(sender, e);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txttracuu.Clear();
            txttracuu.Focus();
        }

       

       

       
    }
}
