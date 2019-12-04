using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
   public  class Sach_BUS
    {
       public static List<Sach_DTO> LayDSSach()
       {
           return Sach_DAO.LayDSSach();
       }
       public static bool ThemSach(Sach_DTO s)
       {
           return Sach_DAO.ThemSach(s);
       }
       public static bool XoaSach(string masach)
       {
           return Sach_DAO.XoaSach(masach);
       }
       public static bool SuaSach(Sach_DTO s)
       {
           return Sach_DAO.SuaSach(s);
       }
       public static List<Sach_DTO> TimSach(string dk, string giatri)
       {
           return Sach_DAO.TimSach(dk, giatri);
       }
       public static Sach_DTO TimSach_TheoMa(string ma)
       {
           return Sach_DAO.TimSach_TheoMa(ma);
       }
    }
}
