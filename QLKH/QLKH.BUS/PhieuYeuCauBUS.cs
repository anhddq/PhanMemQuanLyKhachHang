using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKH.DAL;
using QLKH.Entities;

namespace QLKH.BUS
{
    public static class PhieuYeuCauBUS
    {
        private static PhieuYeuCauDAL obj = new PhieuYeuCauDAL();
        public static List<PhieuYeuCau> PhieuYeuCau_GetByTop(string Top, string Where, string Order)
        {
            return obj.PhieuYeuCau_GetByTop(Top, Where, Order);
        }
        public static bool PhieuYeuCau_Insert(PhieuYeuCau data)
        {
            return obj.PhieuYeuCau_Insert(data);
        }

        public static bool PhieuYeuCau_Update(PhieuYeuCau data)
        {
            return obj.PhieuYeuCau_Update(data);
        }

        public static bool PhieuYeuCau_Delete(string ID)
        {
            return obj.PhieuYeuCau_Delete(ID);
        }
    }
}
