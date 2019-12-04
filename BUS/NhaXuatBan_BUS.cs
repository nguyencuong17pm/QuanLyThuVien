using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class NhaXuatBan_BUS
    {

        public static List<NhaXuatBan_DTO> LayDSTK()
        {
            return NhaXuatBan_DAO.LayDSNXB();
        }
        public static bool ThemNXB(NhaXuatBan_DTO NXB)
        {
            return NhaXuatBan_DAO.ThemNXB(NXB);
        }
        public static bool XoaNXB(string maNXB)
        {
            return NhaXuatBan_DAO.XoaNXB(maNXB);
        }
        public static bool SuaNXB(NhaXuatBan_DTO NXB)
        {
            return NhaXuatBan_DAO.SuaNXB(NXB);
        }
        public static List<NhaXuatBan_DTO> TimNXB(string dk, string giatri)
        {
            return NhaXuatBan_DAO.TimNXB(dk, giatri);
        }
        public static NhaXuatBan_DTO TimNXB_TheoMa(string MaNXB)
        {
            return NhaXuatBan_DAO.TimNXB_TheoMa(MaNXB);
        }
     
    }
}
