using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKH.Entities
{
   public class ChucVu
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public ChucVu()
        {

        }
        public ChucVu(string _ID, string _Name)
        {
            this.ID = _ID;
            this.Name = _Name;
        }
        public void ChucVuIDataReader(SqlDataReader dr)
        {
            ID = dr["id"] is DBNull ? string.Empty : dr["id"].ToString();
            Name = dr["name"] is DBNull ? string.Empty : dr["name"].ToString();
            Alias = dr["alias"] is DBNull ? string.Empty : dr["alias"].ToString();
        }
    }
}
