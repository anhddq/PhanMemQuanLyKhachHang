using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKH.Entities
{
   public  class PhieuYeuCau
    {
        public string MaPhieuYC { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string YeuCau { get; set; }
        public string TGNhan { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string Alias { get; set; }
        public PhieuYeuCau(string _MaPhieuYC, string _MaKhachHang, string _YeuCau,
            string _TGNhan, string _MaNhanVien)
        {
            this.MaNhanVien = _MaNhanVien;
            this.MaPhieuYC = _MaPhieuYC;
            this.MaKhachHang = _MaKhachHang;
            this.YeuCau = _YeuCau;
            this.TGNhan = _TGNhan;
        }
        public PhieuYeuCau()
        {

        }
        public void PhieuYeuCauIDataReader(SqlDataReader dr)
        {
            MaPhieuYC = dr["MaPhieuYC"] is DBNull ? string.Empty : dr["MaPhieuYC"].ToString();
            MaKhachHang = dr["MaKhachHang"] is DBNull ? string.Empty : dr["MaKhachHang"].ToString();
            TenKhachHang = dr["TenKhachHang"] is DBNull ? string.Empty : dr["TenKhachHang"].ToString();
            YeuCau = dr["YeuCau"] is DBNull ? string.Empty : dr["YeuCau"].ToString();
            TGNhan = dr["TGNhan"] is DBNull ? "" : dr["TGNhan"].ToString();
            MaNhanVien = dr["MaNhanVien"] is DBNull ? "" : dr["MaNhanVien"].ToString();
            TenNhanVien = dr["TenNhanVien"] is DBNull ? "" : dr["TenNhanVien"].ToString();
            Alias = dr["Alias"] is DBNull ? "" : dr["Alias"].ToString();
        }
    }
}
