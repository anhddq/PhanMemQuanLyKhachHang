using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKH.DAL;
using QLKH.Entities;

namespace QLKH.BUS
{
    public static class KhachHangBUS
    {
        private  static KhachHangDAL obj = new KhachHangDAL();
        public static List<KhachHang> KhachHang_GetByTop(string Top, string Where, string Order)
        {
            return obj.KhachHang_GetByTop(Top, Where, Order);
        }
        public static bool KhachHang_Insert(KhachHang data)
        {
            return obj.KhachHang_Insert(data);
        }

        public static bool KhachHang_Update(KhachHang data)
        {
            return obj.KhachHang_Update(data);
        }

        public static bool KhachHang_Delete(string ID)
        {
            return obj.KhachHang_Delete(ID);
        }
    }
}
