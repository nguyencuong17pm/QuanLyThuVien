using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class NhanVien_DAO
    {
        static SqlConnection con;
        public static List<NhanVien_DTO> LayDSNhanVien()
        {
            string sTruyVan = "select * from NHANVIEN";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhanVien_DTO> lstNhanVien = new List<DTO.NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNV = dt.Rows[i]["MaNV"].ToString();
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.NgaySinh = Convert.ToDateTime(dt.Rows[i]["NgaySinh"]);
                nv.NgayVaoLam = Convert.ToDateTime(dt.Rows[i]["NgayVaoLam"]);
                nv.GioiTinh = dt.Rows[i]["Gioitinh"].ToString();
                nv.DiaChi = dt.Rows[i]["DiaChiNV"].ToString();
                nv.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
        public static bool ThemNhanVien(NhanVien_DTO nv)
        {


            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into NhanVien values(N'" + nv.MaNV + "',N'" + nv.TenNV + "',N'" + nv.NgaySinh + "',N'" + nv.NgayVaoLam + "',N'" + nv.GioiTinh + "',N'" + nv.DiaChi + "',N'" + nv.DienThoai + "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaNhanVien(string manv)
        {
            string sTruyVan = @"delete from NhanVien where MaNV='" + manv + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaNhanVien(NhanVien_DTO nv)
        {
            string sTruyVan = @"update NhanVien set TenNV =N'" + nv.TenNV + "', NgaySinh = CONVERT (date,'" + nv.NgaySinh + "',103), NgayVaoLam = CONVERT (date,'" + nv.NgayVaoLam + "',103),Gioitinh =N'" + nv.GioiTinh + "',DiaChiNV =N'" + nv.DiaChi + "',DienThoai =N'" + nv.DienThoai + "' where MaNV='" + nv.MaNV + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static NhanVien_DTO TimNhanVien_TheoMa(string manhanvien)
        {
            string sTruyVan = @"select * from NHANVIEN where MaNV='" + manhanvien + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = dt.Rows[0]["MaNV"].ToString();
            nv.TenNV = dt.Rows[0]["TenNV"].ToString();
            nv.NgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
            nv.NgayVaoLam = DateTime.Parse(dt.Rows[0]["NgayVaoLam"].ToString());
            nv.GioiTinh = dt.Rows[0]["Gioitinh"].ToString();
            nv.DiaChi = dt.Rows[0]["DiaChiNV"].ToString();
            nv.DienThoai = dt.Rows[0]["DienThoai"].ToString();
            DataProvider.DongKetNoi(con);
            return nv;
        }
        public static List<NhanVien_DTO> TimNhanVien(string dk, string giatri)
        {
            string sTruyVan = @"select * from NHANVIEN where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<NhanVien_DTO> lstNhanVien = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNV = dt.Rows[i]["MaNV"].ToString();
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.NgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                nv.NgayVaoLam = DateTime.Parse(dt.Rows[i]["NgayVaoLam"].ToString());
                nv.GioiTinh = dt.Rows[i]["Gioitinh"].ToString();
                nv.DiaChi = dt.Rows[i]["DiaChiNV"].ToString();
                nv.DienThoai = dt.Rows[i]["DienThoai"].ToString();
                lstNhanVien.Add(nv);
            }
            DataProvider.DongKetNoi(con);
            return lstNhanVien;
        }
    }
}
