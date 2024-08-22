﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QLQA.DAL.Models
{
    public partial class ChiTietDh
    {

        public int MaDh { get; set; }
        public string MaSp { get; set; }
        public string MaGiamGia { get; set; }
       
        public double? DonGia { get; set; }
        public int? SoLuong { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual GiamGium MaGiamGiaNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
