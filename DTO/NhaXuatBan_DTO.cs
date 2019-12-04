using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class NhaXuatBan_DTO
    {
        private string maNXB;

        public string MaNXB
        {
            get { return maNXB; }
            set { maNXB = value; }
        }
        private string tenNXB;

        public string TenNXB
        {
            get { return tenNXB; }
            set { tenNXB = value; }
        }
    }
}
