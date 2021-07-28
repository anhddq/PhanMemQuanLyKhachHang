using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKH.Entities
{
    public class NhanVien
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MaChucVu { get; set; }
        public string TenChucVu { get; set; }
        public string Alias { get; set; }
        public NhanVien()
        {

        }
        public NhanVien(string _ID, string _Name, string _Address, string _Phone, string _MaChucVu)
        {
            this.ID = _ID;
            this.Name = _Name;
            this.Address = _Address;
            this.Phone = _Phone;
            this.MaChucVu = _MaChucVu;
        }
        public void NhanVienIDataReader(SqlDataReader dr)
        {
            ID = dr["id"] is DBNull ? string.Empty : dr["id"].ToString();
            Name = dr["name"] is DBNull ? string.Empty : dr["name"].ToString();
            Address = dr["Address"] is DBNull ? string.Empty : dr["Address"].ToString();
            Phone = dr["Phone"] is DBNull ? string.Empty : dr["Phone"].ToString();
            MaChucVu = dr["MaChucVu"] is DBNull ? string.Empty : dr["MaChucVu"].ToString();
            Alias = dr["alias"] is DBNull ? string.Empty : dr["alias"].ToString();
            TenChucVu = dr["TenChucVu"] is DBNull ? string.Empty : dr["TenChucVu"].ToString();
        }
    }
}
