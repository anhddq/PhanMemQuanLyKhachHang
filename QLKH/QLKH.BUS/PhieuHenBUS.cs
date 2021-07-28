using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKH.DAL;
using QLKH.Entities;

namespace QLKH.BUS
{
    public static class PhieuHenBUS
    {
        private static PhieuHenDAL obj = new PhieuHenDAL();
        public static List<PhieuHen> PhieuHen_GetByTop(string Top, string Where, string Order)
        {
            return obj.PhieuHen_GetByTop(Top, Where, Order);
        }
        public static bool PhieuHen_Insert(PhieuHen data)
        {
            return obj.PhieuHen_Insert(data);
        }

        public static bool PhieuHen_Update(PhieuHen data)
        {
            return obj.PhieuHen_Update(data);
        }

        public static bool PhieuHen_Delete(string ID)
        {
            return obj.PhieuHen_Delete(ID);
        }
    }
}
