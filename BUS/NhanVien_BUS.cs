using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
  public  class NhanVien_BUS
    {
      public static List<NhanVien_DTO> LayDSNhanVien()
      {
          return NhanVien_DAO.LayDSNhanVien();
      }
      public static bool ThemNhanVien(NhanVien_DTO nv)
      {
          return NhanVien_DAO.ThemNhanVien(nv);
      }
      public static bool XoaNhanVien(string manv)
      {
          return NhanVien_DAO.XoaNhanVien(manv);
      }
      public static bool SuaNhanVien(NhanVien_DTO nv)
      {
          return NhanVien_DAO.SuaNhanVien(nv);
      }
      public static List<NhanVien_DTO> TimNhanVien(string dk, string giatri)
      {
          return NhanVien_DAO.TimNhanVien(dk, giatri);
      }
      public static NhanVien_DTO TimNhanVien_TheoMa(string manhanvien)
      {
          return NhanVien_DAO.TimNhanVien_TheoMa(manhanvien);
      }
    }
}
