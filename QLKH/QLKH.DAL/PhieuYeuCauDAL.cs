using QLKH.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKH.DAL
{
    public class PhieuYeuCauDAL : SqlDataProvider
    {
        public List<PhieuYeuCau> PhieuYeuCau_GetByTop(string Top, string Where, string Order)
        {
            List<PhieuYeuCau> list = new List<PhieuYeuCau>();
            using (SqlCommand dbCmd = new SqlCommand("sp_PhieuYeuCau_getByTop", openConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                dr.Close();
                dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        PhieuYeuCau obj = new PhieuYeuCau();
                        obj.PhieuYeuCauIDataReader(dr);
                        list.Add(obj);
                    }
                }
                dr.Close();
            }
            return list;
        }
        public bool PhieuYeuCau_Insert(PhieuYeuCau data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuYeuCau_Insert", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@makhachhang", data.MaKhachHang));
                    dbCmd.Parameters.Add(new SqlParameter("@yeucau", data.YeuCau));
                    dbCmd.Parameters.Add(new SqlParameter("@tgnhan", data.TGNhan));
                    dbCmd.Parameters.Add(new SqlParameter("@manv", data.MaNhanVien));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool PhieuYeuCau_Update(PhieuYeuCau data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuYeuCau_Update", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuyc", data.MaPhieuYC));
                    dbCmd.Parameters.Add(new SqlParameter("@makhachhang", data.MaKhachHang));
                    dbCmd.Parameters.Add(new SqlParameter("@yeucau", data.YeuCau));
                    dbCmd.Parameters.Add(new SqlParameter("@tgnhan", data.TGNhan));
                    dbCmd.Parameters.Add(new SqlParameter("@manv", data.MaNhanVien));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool PhieuYeuCau_Delete(string ID)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuYeuCau_Delete", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuyc", ID));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }
    }
}
