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
    public class KhachHangDAL : SqlDataProvider
    {
        public List<KhachHang> KhachHang_GetByTop(string Top, string Where, string Order)
        {
            List<KhachHang> list = new List<KhachHang>();
            using (SqlCommand dbCmd = new SqlCommand("sp_KhachHang_getByTop", openConnection()))
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
                        KhachHang obj = new KhachHang();
                        obj.KhachHangIDataReader(dr);
                        list.Add(obj);
                    }
                }
                dr.Close();
            }
            return list;
        }
        public bool KhachHang_Insert(KhachHang data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhachHang_Insert", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@name", data.Name));
                    dbCmd.Parameters.Add(new SqlParameter("@address", data.Address));
                    dbCmd.Parameters.Add(new SqlParameter("@phone", data.Phone));
                    dbCmd.Parameters.Add(new SqlParameter("@email", data.Email));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool KhachHang_Update(KhachHang data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhachHang_Update", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@id", data.ID));
                    dbCmd.Parameters.Add(new SqlParameter("@name", data.Name));
                    dbCmd.Parameters.Add(new SqlParameter("@address", data.Address));
                    dbCmd.Parameters.Add(new SqlParameter("@phone", data.Phone));
                    dbCmd.Parameters.Add(new SqlParameter("@email", data.Email));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool KhachHang_Delete(string ID)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhachHang_Delete", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@id", ID));
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
