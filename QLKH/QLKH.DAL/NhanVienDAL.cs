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
    public class NhanVienDAL : SqlDataProvider
    {
        public List<NhanVien> NhanVien_GetByTop(string Top, string Where, string Order)
        {
            List<NhanVien> list = new List<NhanVien>();
            using (SqlCommand dbCmd = new SqlCommand("sp_NhanVien_getByTop", openConnection()))
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
                        NhanVien obj = new NhanVien();
                        obj.NhanVienIDataReader(dr);
                        list.Add(obj);
                    }
                }
                dr.Close();
            }
            return list;
        }
        public bool NhanVien_Insert(NhanVien data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_NhanVien_Insert", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@name", data.Name));
                    dbCmd.Parameters.Add(new SqlParameter("@address", data.Address));
                    dbCmd.Parameters.Add(new SqlParameter("@phone", data.Phone));
                    dbCmd.Parameters.Add(new SqlParameter("@machucvu", data.MaChucVu));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool NhanVien_Update(NhanVien data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_NhanVien_Update", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@id", data.ID));
                    dbCmd.Parameters.Add(new SqlParameter("@name", data.Name));
                    dbCmd.Parameters.Add(new SqlParameter("@address", data.Address));
                    dbCmd.Parameters.Add(new SqlParameter("@phone", data.Phone));
                    dbCmd.Parameters.Add(new SqlParameter("@machucvu", data.MaChucVu));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool NhanVien_Delete(string ID)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_NhanVien_Delete", openConnection()))
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
