using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
   public class TaiKhoan_BUS
    {
       public static List<TaiKhoan_DTO> LayDSTK()
       {
           return TaiKhoan_DAO.LayDSTK();
       }
       public static bool ThemTaiKhoan(TaiKhoan_DTO Tk)
       {
           return TaiKhoan_DAO.ThemTK(Tk);
       }
       public static bool SuaTaiKhoan(TaiKhoan_DTO TK)
       {
           return TaiKhoan_DAO.SuaTaiKhoan(TK);
       }
       public static bool XoaTaiKhoan(string TK)
       {
           return TaiKhoan_DAO.XoaTaiKhoan(TK);
       }
       public static TaiKhoan_DTO TimTk_TheoTen(string taikhoan)
       {
           return TaiKhoan_DAO.TimTK_TheoTen(taikhoan);
       }
       public static TaiKhoan_DTO TimTk_TheoTenHT(string tenHT)
       {
           return TaiKhoan_DAO.TimTK_TheoTenHT(tenHT);
       }
     
       public static List<TaiKhoan_DTO> Timtaikhoan(string dk, string giatri)
       {
           return TaiKhoan_DAO.TimTK(dk, giatri);
       }
    }
}
