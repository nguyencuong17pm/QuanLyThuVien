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
   public class TaiKhoan_DAO
    {
        static SqlConnection con;
        public static List<TaiKhoan_DTO> LayDSTK()
        {
            string sTruyVan = "select * from TAIKHOAN";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<TaiKhoan_DTO> lstSach = new List<DTO.TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO TK = new TaiKhoan_DTO();
                TK.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                TK.TaiKhoan = dt.Rows[i]["TaiKhoan"].ToString();
                TK.TenHienThi = dt.Rows[i]["TenHienThi"].ToString();
                TK.MauKhau = dt.Rows[i]["MatKhau"].ToString();
               
                TK.QuyenHan = dt.Rows[i]["QuyenHan"].ToString();
                lstSach.Add(TK);
            }
            DataProvider.DongKetNoi(con);
            return lstSach;
        }
        public static bool ThemTK(TaiKhoan_DTO TK)
        {

            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into TaiKhoan values(N'" + TK.TaiKhoan + "',N'" + TK.TenHienThi + "',N'" + TK.MauKhau + "',N'" + TK.QuyenHan + "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;       


        }
        public static TaiKhoan_DTO TimTK_TheoTen(string taikhoan)
        {
            string sTruyVan = @"select * from TAIKHOAN where TaiKhoan='" + taikhoan + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            TaiKhoan_DTO TK = new TaiKhoan_DTO();
            TK.ID = int.Parse(dt.Rows[0]["ID"].ToString());
            TK.TaiKhoan = dt.Rows[0]["TaiKhoan"].ToString();
            TK.TenHienThi = dt.Rows[0]["TenHienThi"].ToString();
            TK.MauKhau = dt.Rows[0]["MatKhau"].ToString();
            TK.QuyenHan = dt.Rows[0]["QuyenHan"].ToString();
            DataProvider.DongKetNoi(con);
            return TK;
        }
        public static TaiKhoan_DTO TimTK_TheoTenHT(string TenHT)
        {
            string sTruyVan = @"select * from TAIKHOAN where TenHienThi='" + TenHT + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            TaiKhoan_DTO TK = new TaiKhoan_DTO();
            TK.ID = int.Parse(dt.Rows[0]["ID"].ToString());
            TK.TaiKhoan = dt.Rows[0]["TaiKhoan"].ToString();
            TK.TenHienThi = dt.Rows[0]["TenHienThi"].ToString();
            TK.MauKhau = dt.Rows[0]["MatKhau"].ToString();
            TK.QuyenHan = dt.Rows[0]["QuyenHan"].ToString();
            DataProvider.DongKetNoi(con);
            return TK;
        }
        public static bool XoaTaiKhoan(string TK)
        {
            string sTruyVan = @"delete from TaiKhoan where ID ='" + TK + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTaiKhoan(TaiKhoan_DTO Tk)
        {
            string sTruyVan = @"update TaiKhoan set TaiKhoan =N'" + Tk.TaiKhoan + "', TenHienThi =N'" + Tk.TenHienThi + "',MatKhau  =N'" + Tk.MauKhau + "',QuyenHan =N'" + Tk.QuyenHan + "' where ID  ='" + Tk.ID + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<TaiKhoan_DTO> TimTK(string dk, string giatri)
        {
            string sTruyVan = @"select * from TAIKHOAN where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<TaiKhoan_DTO> lstTaiKhoan = new List<TaiKhoan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TaiKhoan_DTO TK = new TaiKhoan_DTO();
                TK.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                TK.TaiKhoan = dt.Rows[i]["TaiKhoan"].ToString();
                TK.TenHienThi = dt.Rows[i]["TenHienThi"].ToString();
                TK.MauKhau = dt.Rows[i]["MatKhau"].ToString();
                TK.QuyenHan = dt.Rows[i]["QuyenHan"].ToString();
                lstTaiKhoan.Add(TK);
            }
            DataProvider.DongKetNoi(con);
            return lstTaiKhoan;
        }
    }
}
