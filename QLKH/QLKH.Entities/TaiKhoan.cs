using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKH.Entities
{
    public class TaiKhoan
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Quyen { get; set; }
        public string IDNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string Alias { get; set; }
        public TaiKhoan()
        {

        }
        public TaiKhoan(string _Username, string _Password, string _Quyen)
        {
            this.Username = _Username;
            this.Password = _Password;
            this.Quyen = _Quyen;
        }
        public void TaiKhoanIDataReader(SqlDataReader dr)
        {
            Username = dr["Username"] is DBNull ? string.Empty : dr["Username"].ToString();
            Password = dr["Password"] is DBNull ? string.Empty : dr["Password"].ToString();
            Quyen = dr["Quyen"] is DBNull ? string.Empty : dr["Quyen"].ToString();
            IDNhanVien = dr["IDNhanVien"] is DBNull ? string.Empty : dr["IDNhanVien"].ToString();
            TenNhanVien = dr["TenNhanVien"] is DBNull ? string.Empty : dr["TenNhanVien"].ToString();
            Alias = dr["Alias"] is DBNull ? string.Empty : dr["Alias"].ToString();
        }
    }
}
