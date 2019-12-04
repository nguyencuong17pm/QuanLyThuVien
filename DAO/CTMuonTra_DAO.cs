using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
   public class CTMuonTra_DAO
    {
       static SqlConnection con;
        public static List<CTMuonTra_DTO> LayDSCTMuonTra()
        {

            string sTruyVan = "select * from CTMuonTra";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<CTMuonTra_DTO> lstCTMuonTra = new List<DTO.CTMuonTra_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CTMuonTra_DTO CTMT = new CTMuonTra_DTO();
                CTMT.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                CTMT.MaMuonTra = dt.Rows[i]["MaMuonTra"].ToString();
                CTMT.MaSach = dt.Rows[i]["TenSach"].ToString();
                CTMT.DaTra = dt.Rows[i]["DaTra"].ToString();
                CTMT.NgayTra = dt.Rows[i]["NgayTra"].ToString();
                CTMT.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                lstCTMuonTra.Add(CTMT);
            }
            DataProvider.DongKetNoi(con);
            return lstCTMuonTra;
        }
        public static bool ThemCTMuonTra(CTMuonTra_DTO CTMT)
        {
            con = DataProvider.MoKetNoi();
            string sTruyVan = @"insert into CTMuonTra values(N'" + CTMT.MaMuonTra + "',N'" + CTMT.MaSach + "',N'" + CTMT.DaTra + "',N'" + CTMT.NgayTra + "',N'" + CTMT.GhiChu + "')";
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static bool XoaCTMuon(string ID)
        {
            string sTruyVan = @"delete from CTMuonTra where ID='" + ID + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;


        }
        public static bool SuaCTMuonTra(CTMuonTra_DTO CTMT)
        {
            string sTruyVan = @"update CTMuonTra set MaMuonTra =N'" + CTMT.MaMuonTra + "',TenSach = N'" + CTMT.MaSach + "' , DaTra = N'" + CTMT.DaTra + "' , NgayTra = N'" + CTMT.NgayTra + "', GhiChu = N'" + CTMT.GhiChu + "'  where ID='" + CTMT.ID + "'";
            con = DataProvider.MoKetNoi();
            bool kq = DataProvider.TruyVanKhongLayDuLieu(sTruyVan, con);
            DataProvider.DongKetNoi(con);
            return kq;
        }
        public static List<CTMuonTra_DTO> TimKiem(string dk, string giatri)
        {
            string sTruyVan = @"select * from CTMuonTra where " + dk + " like N'%" + giatri + "%'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            List<CTMuonTra_DTO> lst = new List<CTMuonTra_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                CTMuonTra_DTO CTMT = new CTMuonTra_DTO();
                CTMT.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                CTMT.MaMuonTra = dt.Rows[i]["MaMuonTra"].ToString();
                CTMT.MaSach = dt.Rows[i]["TenSach"].ToString();
                CTMT.DaTra = dt.Rows[i]["DaTra"].ToString();
                CTMT.NgayTra = dt.Rows[i]["NgayTra"].ToString();
                CTMT.GhiChu = dt.Rows[i]["GhiChu"].ToString();
                lst.Add(CTMT);
            }
            DataProvider.DongKetNoi(con);
            return lst;
        }
    }
}
