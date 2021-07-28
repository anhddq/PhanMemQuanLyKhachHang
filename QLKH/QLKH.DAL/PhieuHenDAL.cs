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
    public class PhieuHenDAL : SqlDataProvider
    {
        public List<PhieuHen> PhieuHen_GetByTop(string Top, string Where, string Order)
        {
            List<PhieuHen> list = new List<PhieuHen>();
            using (SqlCommand dbCmd = new SqlCommand("sp_PhieuHen_getByTop", openConnection()))
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
                        PhieuHen obj = new PhieuHen();
                        obj.PhieuHenIDataReader(dr);
                        list.Add(obj);
                    }
                }
                dr.Close();
            }
            return list;
        }
        public bool PhieuHen_Insert(PhieuHen data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuHen_Insert", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuyc", data.MaPhieuYC));
                    dbCmd.Parameters.Add(new SqlParameter("@pagiaiquyet", data.PAGiaiQuyet));
                    dbCmd.Parameters.Add(new SqlParameter("@thoigianhen", data.ThoiGianHen));
                    dbCmd.Parameters.Add(new SqlParameter("@douutien", data.DoUuTien));
                    dbCmd.Parameters.Add(new SqlParameter("@tinhtrang", data.TinhTrang));
                    dbCmd.Parameters.Add(new SqlParameter("@manv", data.MaNV));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool PhieuHen_Update(PhieuHen data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuHen_Update", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuhen", data.MaPhieuHen));
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuyc", data.MaPhieuYC));
                    dbCmd.Parameters.Add(new SqlParameter("@pagiaiquyet", data.PAGiaiQuyet));
                    dbCmd.Parameters.Add(new SqlParameter("@thoigianhen", data.ThoiGianHen));
                    dbCmd.Parameters.Add(new SqlParameter("@douutien", data.DoUuTien));
                    dbCmd.Parameters.Add(new SqlParameter("@tinhtrang", data.TinhTrang));
                    dbCmd.Parameters.Add(new SqlParameter("@manv", data.MaNV));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool PhieuHen_Delete(string ID)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhieuHen_Delete", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@maphieuhen", ID));
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
