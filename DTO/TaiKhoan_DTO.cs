using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class TaiKhoan_DTO
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string taiKhoan;

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        private string tenHienThi;

        public string TenHienThi
        {
            get { return tenHienThi; }
            set { tenHienThi = value; }
        }
        private string mauKhau;

        public string MauKhau
        {
            get { return mauKhau; }
            set { mauKhau = value; }
        }
       
        private string quyenHan;

        public string QuyenHan
        {
            get { return quyenHan; }
            set { quyenHan = value; }
        }

    }
}
