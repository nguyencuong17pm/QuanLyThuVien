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
  public  class TheLoai_DAO
    {
        static SqlConnection con;
        public static List<Theloai_DTO> LayDSTL()
        {
            string sTruyVan = "select * from THELOAI";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<Theloai_DTO> lstTheLoai = new List<DTO.Theloai_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Theloai_DTO TL = new Theloai_DTO();
                TL.MaLoai = dt.Rows[i]["MaLoai"].ToString();
                TL.TenLoai = dt.Rows[i]["TenLoai"].ToString();
                lstTheLoai.Add(TL);
            }
            DataProvider.DongKetNoi(con);
            return lstTheLoai;
        }
        public static bool ThemTL(Theloai_DTO TL)
        {

            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into TheLoai values(N'" + TL.MaLoai + "',N'" + TL.TenLoai + "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaTL(string maloai)
        {

            string sTruyVan = @"delete from Theloai where MaLoai='" + maloai + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool SuaTL(Theloai_DTO TL)
        {

            string sTruyVan = @"update TheLoai set TenLoai =N'" + TL.TenLoai + "' where MaLoai='" + TL.MaLoai + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static Theloai_DTO TimTL_TheoMa(string maloai)
        {
            string sTruyVan = @"select * from THELOAI where MaLoai='" + maloai + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            Theloai_DTO TL = new Theloai_DTO();
            TL.MaLoai = dt.Rows[0]["MaLoai"].ToString();
            TL.TenLoai = dt.Rows[0]["TenLoai"].ToString();
            DataProvider.DongKetNoi(con);
            return TL;
        }
        public static List<Theloai_DTO> TimTL(string dk, string giatri)
        {
            string sTruyVan = @"select * from THELOAI where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<Theloai_DTO> lstTL = new List<Theloai_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Theloai_DTO TL = new Theloai_DTO();
                TL.MaLoai = dt.Rows[i]["MaLoai"].ToString();
                TL.TenLoai = dt.Rows[i]["TenLoai"].ToString();
                lstTL.Add(TL);
            }
            DataProvider.DongKetNoi(con);
            return lstTL;
        }
    }
}
