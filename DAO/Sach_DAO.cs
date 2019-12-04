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
    public class Sach_DAO
    {
        static SqlConnection con;
        public static List<Sach_DTO> LayDSSach()
        {
            string sTruyVan = "select * from SACH";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Sach_DTO> lstSach = new List<DTO.Sach_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sach_DTO s = new Sach_DTO();
                s.MaSach = dt.Rows[i]["MaSach"].ToString();
                s.TenSach = dt.Rows[i]["TenSach"].ToString();
                s.TheLoai = dt.Rows[i]["TheLoai"].ToString();
                s.TinhTrang = dt.Rows[i]["TinhTrang"].ToString();
                s.SoLuong = dt.Rows[i]["SoLuong"].ToString();
                s.NhaXB = dt.Rows[i]["NXB"].ToString();
                s.NamXB = dt.Rows[i]["NamXB"].ToString();
                s.TacGia = dt.Rows[i]["TacGia"].ToString();
                lstSach.Add(s);
            }
            DataProvider.DongKetNoi(con);
            return lstSach;
        }
        public static bool ThemSach(Sach_DTO s)
        {
            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into SACH values(N'" + s.MaSach + "',N'" + s.TenSach + "',N'" + s.TheLoai + "',N'" + s.TinhTrang + "',N'" + s.SoLuong + "',N'" + s.NhaXB + "',N'" + s.NamXB + "',N'" + s.TacGia + "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
       
        public static bool XoaSach(string masach)
        {
            string sTruyVan = @"delete from SACH where MaSach='" + masach + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
          
        }
        public static bool SuaSach(Sach_DTO s)
        {
            string sTruyVan = @"update SACH set TenSach = N'" + s.TenSach + "', Theloai = N'" + s.TheLoai + "',TinhTrang = N'" + s.TinhTrang + "',SoLuong = N'" + s.SoLuong + "',NXB = N'" + s.NhaXB + "',NamXB = N'" + s.NamXB + "',TacGia = N'" + s.TacGia + "' where MaSach='" + s.MaSach + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
         
        }
        public static Sach_DTO TimSach_TheoMa(string masach)
        {
            string sTruyVan = @"select * from sach where masach='" + masach + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            Sach_DTO s = new Sach_DTO();
            s.MaSach = dt.Rows[0]["MaSach"].ToString();
            s.TenSach = dt.Rows[0]["TenSach"].ToString();
            s.TheLoai = dt.Rows[0]["TheLoai"].ToString();
            s.TinhTrang = dt.Rows[0]["TinhTrang"].ToString();
            s.SoLuong = dt.Rows[0]["SoLuong"].ToString();
            s.NhaXB = dt.Rows[0]["NXB"].ToString();
            s.NamXB = dt.Rows[0]["NamXB"].ToString();
            s.TacGia = dt.Rows[0]["TacGia"].ToString();
            DataProvider.DongKetNoi(con);
            return s;
        }
        public static List<Sach_DTO> TimSach(string dk, string giatri)
        {
            string sTruyVan = @"select * from sach where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<Sach_DTO> lstsach = new List<Sach_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sach_DTO s = new Sach_DTO();
                s.MaSach = dt.Rows[i]["MaSach"].ToString();
                s.TenSach = dt.Rows[i]["TenSach"].ToString();
                s.TheLoai = dt.Rows[i]["TheLoai"].ToString();
                s.TinhTrang = dt.Rows[i]["TinhTrang"].ToString();
                s.SoLuong = dt.Rows[i]["SoLuong"].ToString();
                s.NhaXB = dt.Rows[i]["NXB"].ToString();
                s.NamXB = dt.Rows[i]["NamXB"].ToString();
                s.TacGia = dt.Rows[i]["TacGia"].ToString();
                lstsach.Add(s);
            }
            DataProvider.DongKetNoi(con);
            return lstsach;
        }
    }
}