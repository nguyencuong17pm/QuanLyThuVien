using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CTMuonTra_DTO
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string maMuonTra;

        public string MaMuonTra
        {
            get { return maMuonTra; }
            set { maMuonTra = value; }
        }
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private string daTra;

        public string DaTra
        {
            get { return daTra; }
            set { daTra = value; }
        }


        private string ngayTra;

        public string NgayTra
        {
            get { return ngayTra; }
            set { ngayTra = value; }
        }


        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }
}
