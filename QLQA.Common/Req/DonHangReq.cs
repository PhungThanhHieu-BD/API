using QLQA.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class DonHangReq
    {
       
     //   public int MaDh { get; set; }
        public string MaKh { get; set; }
        public string MaNv { get; set; }
        public string MaShipper { get; set; }
        public DateTime? NgayDatHang { get; set; }
        public double? PhiVc { get; set; }
        public DateTime? NgayGiaoHang { get; set; }
        public string DcgiaoHang { get; set; }
        public string TinhThanhDh { get; set; }

        
    }
}
