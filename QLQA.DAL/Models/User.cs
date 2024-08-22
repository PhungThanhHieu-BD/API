using System;
using System.Collections.Generic;

#nullable disable

namespace QLQA.DAL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string MaNv { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IsAd { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
