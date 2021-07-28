using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLKH.Entities
{
    public class PhieuHen
    {
        public string MaPhieuHen { get; set; }
        public string MaPhieuYC { get; set; }
        public string PAGiaiQuyet { get; set; }
        public string ThoiGianHen { get; set; }
        public string DoUuTien { get; set; }
        public string TinhTrang { get; set; }
        public string MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public string Alias { get; set; }
        public string YeuCau { get; set; }
        public PhieuHen(string _MaPhieuHen, string _MaPhieuYC, string _PAGiaiQuyet,
            string _ThoiGianHen, string _DoUuTien, string _TinhTrang, string _MaNV)
        {
            this.MaPhieuHen = _MaPhieuHen;
            this.MaPhieuYC = _MaPhieuYC;
            this.PAGiaiQuyet = _PAGiaiQuyet;
            this.ThoiGianHen = _ThoiGianHen;
            this.DoUuTien = _DoUuTien;
            this.TinhTrang = _TinhTrang;
            this.MaNV = _MaNV;
        }
        public PhieuHen()
        {

        }
        public void PhieuHenIDataReader(SqlDataReader dr)
        {
            MaPhieuHen = dr["MaPhieuHen"] is DBNull ? string.Empty : dr["MaPhieuHen"].ToString();
            MaPhieuYC = dr["MaPhieuYC"] is DBNull ? string.Empty : dr["MaPhieuYC"].ToString();
            PAGiaiQuyet = dr["PAGiaiQuyet"] is DBNull ? string.Empty : dr["PAGiaiQuyet"].ToString();
            ThoiGianHen = dr["ThoiGianHen"] is DBNull ? string.Empty : dr["ThoiGianHen"].ToString();
            DoUuTien = dr["DoUuTien"] is DBNull ? string.Empty : dr["DoUuTien"].ToString();
            TinhTrang = dr["TinhTrang"] is DBNull ? string.Empty : dr["TinhTrang"].ToString();
            MaNV = dr["MaNV"] is DBNull ? string.Empty : dr["MaNV"].ToString();
            TenNhanVien = dr["TenNhanVien"] is DBNull ? string.Empty : dr["TenNhanVien"].ToString();
            TenKhachHang = dr["TenKhachHang"] is DBNull ? string.Empty : dr["TenKhachHang"].ToString();
            Alias = dr["Alias"] is DBNull ? string.Empty : dr["Alias"].ToString();
            YeuCau = dr["YeuCau"] is DBNull ? string.Empty : dr["YeuCau"].ToString();
        }
    }
}
