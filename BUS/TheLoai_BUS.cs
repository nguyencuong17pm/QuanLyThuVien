using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
  public  class TheLoai_BUS
    {
      public static List<Theloai_DTO> LayDSTL()
      {
          return TheLoai_DAO.LayDSTL();
      }
      public static bool ThemTL(Theloai_DTO TL)
      {
          return TheLoai_DAO.ThemTL(TL);
      }
      public static bool XoaTL(string maloai)
      {
          return TheLoai_DAO.XoaTL(maloai);
      }
      public static bool SuaTL(Theloai_DTO TL)
      {
          return TheLoai_DAO.SuaTL(TL);
      }
      public static List<Theloai_DTO> TimTL(string dk, string giatri)
      {
          return TheLoai_DAO.TimTL(dk, giatri);
      }
      public static Theloai_DTO TimTL_TheoMa(string maloai)
      {
          return TheLoai_DAO.TimTL_TheoMa(maloai);
      }
    }
}
