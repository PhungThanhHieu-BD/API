using QLQA.Common.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLQA.BLL
{
    public class LoaiHangSvc: GenericSvc<LoaiHangRep, LoaiHang>
    {
        private LoaiHangRep loaiHangRep;
        public LoaiHangSvc() {
            loaiHangRep = new LoaiHangRep();
        }

        public override SingleRsp Read(string keyword)  //int id
        {
            var res = new SingleRsp();
            //  res.Data = _rep.Read(id);

            res.SetData("200", loaiHangRep.Read(keyword));
            return res;
        }

        public SingleRsp CreateLoaiHang(LoaiHangReq loaiHangReq)
        {
            var res = new SingleRsp();
            LoaiHang loaiHang = new LoaiHang();
            loaiHang.MaLh = loaiHangReq.MaLh;
            loaiHang.TenLh = loaiHangReq.TenLh;
            loaiHang.GhiChu = loaiHangReq.GhiChu;

            loaiHangRep.CreateLoaiHang(loaiHang);
            res.SetData("201", "Create successful.!");
            return res;
        }

        public SingleRsp UpdateLoaiHang(LoaiHangReq categoryReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(categoryReq.MaLh);

            exist.MaLh = categoryReq.MaLh;
            exist.TenLh = categoryReq.TenLh;
            exist.GhiChu = categoryReq.GhiChu;



            res = loaiHangRep.UpdateLoaiHang(exist);
            return res;
        }

        public SingleRsp DeleteLoaiHang(string keyword)
        {
            var res = new SingleRsp();
            LoaiHang c = loaiHangRep.Read(keyword);
            if (c != null)
            {
                loaiHangRep.DeleteLoaiHang(c);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy loại hàng mã  {keyword} ");
                return res;
            }
        }

        public SingleRsp SearchLoaiHang(SearchLoaiHangReq searchLoaiHangReq)
        {
            var res = new SingleRsp();
            //lấy dssp theo từ khóa
            var loaiHang = loaiHangRep.SearchLoaiHang(searchLoaiHangReq.KeyWord);
            //xử lý phân trang 
            int pCount, totalPage, offSet;
            offSet = searchLoaiHangReq.Size * (searchLoaiHangReq.Page - 1);
            pCount = loaiHang.Count;

            totalPage = (pCount % searchLoaiHangReq.Size) == 0 ? pCount / searchLoaiHangReq.Size : 1
                + (pCount / searchLoaiHangReq.Size);
            var p = new
            {
                Data = loaiHang.Skip(offSet).Take(searchLoaiHangReq.Size).ToList(),
                page = searchLoaiHangReq.Page,
                Size = searchLoaiHangReq.Size
            };
            res.Data = p;
            return res;
        }
    }
}
