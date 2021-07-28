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
    public class TaiKhoanDAL : SqlDataProvider
    {
        public List<TaiKhoan> TaiKhoan_GetByTop(string Top, string Where, string Order)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            using (SqlCommand dbCmd = new SqlCommand("sp_TaiKhoan_getByTop", openConnection()))
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
                        TaiKhoan obj = new TaiKhoan();
                        obj.TaiKhoanIDataReader(dr);
                        list.Add(obj);
                    }
                }
                dr.Close();
            }
            return list;
        }
        public bool TaiKhoan_Insert(TaiKhoan data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_TaiKhoan_Insert", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@username", data.Username));
                    dbCmd.Parameters.Add(new SqlParameter("@password", data.Password));
                    dbCmd.Parameters.Add(new SqlParameter("@quyen", data.Quyen));
                    dbCmd.Parameters.Add(new SqlParameter("@idnhanvien", data.IDNhanVien));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool TaiKhoan_Update(TaiKhoan data)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_TaiKhoan_Update", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@username", data.Username));
                    if(data.Password != null) dbCmd.Parameters.Add(new SqlParameter("@password", data.Password));
                    dbCmd.Parameters.Add(new SqlParameter("@quyen", data.Quyen));
                    dbCmd.Parameters.Add(new SqlParameter("@idnhanvien", data.IDNhanVien));
                    int r = dbCmd.ExecuteNonQuery();
                    if (r > 0) check = true;
                }
            }
            catch
            {
            }
            return check;
        }

        public bool TaiKhoan_Delete(string ID)
        {
            bool check = false;
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_TaiKhoan_Delete", openConnection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add(new SqlParameter("@username", ID));
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
