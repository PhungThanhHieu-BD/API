using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class SanPhamReq
    {
        public string MaSp { get; set; }
        public string MaLh { get; set; }
        public string TenSp { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTonKho { get; set; }
        public DateTime? NgayNhapHang { get; set; }
        public bool? GiamGia { get; set; }
        public string MauSac { get; set; }

    }
}
