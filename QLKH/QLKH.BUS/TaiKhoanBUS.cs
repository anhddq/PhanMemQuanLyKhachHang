using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKH.DAL;
using QLKH.Entities;

namespace QLKH.BUS
{
    public static class TaiKhoanBUS
    {
        private static TaiKhoanDAL obj = new TaiKhoanDAL();
        public static List<TaiKhoan> TaiKhoan_GetByTop(string Top, string Where, string Order)
        {
            return obj.TaiKhoan_GetByTop(Top, Where, Order);
        }
        public static bool TaiKhoan_Insert(TaiKhoan data)
        {
            return obj.TaiKhoan_Insert(data);
        }

        public static bool TaiKhoan_Update(TaiKhoan data)
        {
            return obj.TaiKhoan_Update(data);
        }

        public static bool TaiKhoan_Delete(string ID)
        {
            return obj.TaiKhoan_Delete(ID);
        }
    }
}
