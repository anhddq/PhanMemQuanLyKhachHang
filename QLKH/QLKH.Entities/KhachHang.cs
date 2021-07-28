using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKH.Entities
{
    public class KhachHang
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public KhachHang()
        {

        }
        public KhachHang(string _ID, string _Name, string _Address, string _Phone, string _Email)
        {
            this.ID = _ID;
            this.Name = _Name;
            this.Address = _Address;
            this.Phone = _Phone;
            this.Email = _Email;
        }
        public void KhachHangIDataReader(SqlDataReader dr)
        {
            ID = dr["id"] is DBNull ? string.Empty : dr["id"].ToString();
            Name = dr["name"] is DBNull ? string.Empty : dr["name"].ToString();
            Address = dr["Address"] is DBNull ? string.Empty : dr["Address"].ToString();
            Phone = dr["Phone"] is DBNull ? string.Empty : dr["Phone"].ToString();
            Email = dr["Email"] is DBNull ? string.Empty : dr["Email"].ToString();
            Alias = dr["alias"] is DBNull ? string.Empty : dr["alias"].ToString();
        }
    }
}
