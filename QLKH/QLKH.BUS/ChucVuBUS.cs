using QLKH.DAL;
using QLKH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKH.BUS
{
    public static class ChucVuBUS
    {
        private static ChucVuDAL obj = new ChucVuDAL();
        public static List<ChucVu> ChucVu_GetByTop(string Top, string Where, string Order)
        {
            return obj.ChucVu_GetByTop(Top, Where, Order);
        }
        public static bool ChucVu_Insert(ChucVu data)
        {
            return obj.ChucVu_Insert(data);
        }

        public static bool ChucVu_Update(ChucVu data)
        {
            return obj.ChucVu_Update(data);
        }

        public static bool ChucVu_Delete(string ID)
        {
            return obj.ChucVu_Delete(ID);
        }
    }
}
