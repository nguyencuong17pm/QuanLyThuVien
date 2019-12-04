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
  public  class NhaXuatBan_DAO
    {
        static SqlConnection con;
        public static List<NhaXuatBan_DTO> LayDSNXB()
        {
            
            string sTruyVan = "select * from NHAXUATBAN";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<NhaXuatBan_DTO> lstNXB = new List<DTO.NhaXuatBan_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
                NXB.MaNXB = dt.Rows[i]["MaNXB"].ToString();
                NXB.TenNXB = dt.Rows[i]["TenNXB"].ToString();
                lstNXB.Add(NXB);
            }
            DataProvider.DongKetNoi(con);
            return lstNXB;
        }
        public static bool ThemNXB(NhaXuatBan_DTO NXB)
        {
            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into NhaXuatBan values(N'" + NXB.MaNXB + "',N'" + NXB.TenNXB+ "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;           
        }
             public static bool XoaNXB(string MaNXB)
             {      
            string sTruyVan = @"delete from NhaXuatBan where MaNXB='" + MaNXB + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;


        }
        public static bool SuaNXB(NhaXuatBan_DTO NXB)
        {
            string sTruyVan = @"update NhaXuatBan set TenNXB =N'" + NXB.TenNXB + "' where MaNXB='" + NXB.MaNXB + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static NhaXuatBan_DTO TimNXB_TheoMa(string NhaXB)
        {
            string sTruyVan = @"select * from NHAXUATBAN where MaNXB='" + NhaXB + "'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
                return null;
            NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
            NXB.MaNXB = dt.Rows[0]["MaNXB"].ToString();
            NXB.TenNXB = dt.Rows[0]["TenNXB"].ToString();
            DataProvider.DongKetNoi(con);
            return NXB;
        }
        public static List<NhaXuatBan_DTO> TimNXB(string dk, string giatri)
        {
            string sTruyVan = @"select * from NHAXUATBAN where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<NhaXuatBan_DTO> lstNXB = new List<NhaXuatBan_DTO>();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NhaXuatBan_DTO NXB = new NhaXuatBan_DTO();
                    NXB.MaNXB = dt.Rows[i]["MaNXB"].ToString();
                    NXB.TenNXB = dt.Rows[i]["TenNXB"].ToString();
                    lstNXB.Add(NXB);
                }
            }
            catch
            {
            }
            DataProvider.DongKetNoi(con);
            return lstNXB;
        }
    }
}
