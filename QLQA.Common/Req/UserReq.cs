using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class UserReq
    {
        public int UserId { get; set; }
        public string MaNv { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IsAd { get; set; } = 0;
    }
}
