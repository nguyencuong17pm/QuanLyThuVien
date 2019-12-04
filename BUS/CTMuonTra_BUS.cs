using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
   public class CTMuonTra_BUS
    {
        public static List<CTMuonTra_DTO> TimKiem(string dk, string giatri)
        {
            return CTMuonTra_DAO.TimKiem(dk, giatri);
        }
        public static List<CTMuonTra_DTO> LayDSMT()
        {
            return CTMuonTra_DAO.LayDSCTMuonTra();
        }
        public static bool ThemCTMuonTra(CTMuonTra_DTO CTMT)
        {
            return CTMuonTra_DAO.ThemCTMuonTra(CTMT);
        }
        public static bool XoaCTMuonTra(string CTMT)
        {
            return CTMuonTra_DAO.XoaCTMuon(CTMT);
        }
        public static bool SuaCTMuonTra(CTMuonTra_DTO CTMT)
        {
            return CTMuonTra_DAO.SuaCTMuonTra(CTMT);
        }
    }
}
