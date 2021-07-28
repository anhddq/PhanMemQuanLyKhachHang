using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKH.DAL;
using QLKH.Entities;

namespace QLKH.BUS
{
    public  static class NhanVienBUS
    {
        private static NhanVienDAL obj = new NhanVienDAL();
        public static List<NhanVien> NhanVien_GetByTop(string Top, string Where, string Order)
        {
            return obj.NhanVien_GetByTop(Top, Where, Order);
        }
        public static bool NhanVien_Insert(NhanVien data)
        {
            return obj.NhanVien_Insert(data);
        }

        public static bool NhanVien_Update(NhanVien data)
        {
            return obj.NhanVien_Update(data);
        }

        public static bool NhanVien_Delete(string ID)
        {
            return obj.NhanVien_Delete(ID);
        }
    }
}
