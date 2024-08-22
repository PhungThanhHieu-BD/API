using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class NhanVienReq
    {
        public string MaNv { get; set; }
        public string HoNv { get; set; }
        public string TenNv { get; set; }
        public string DiaChiNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public double? Luong { get; set; }

    }
}
