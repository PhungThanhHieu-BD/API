using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class SearchNhanVienReq
    {
        public string KeyWord { get; set; }
        public int Page { get; set; }

        public int Size { get; set; }

    }
}
