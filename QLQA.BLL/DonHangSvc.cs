using Microsoft.IdentityModel.Tokens;
using QLQA.Common.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace QLQA.BLL
{
   public class DonHangSvc : GenericSvc<DonHangRep, DonHang>
    {
        private DonHangRep donHangRep;
        DonHangRep req = new DonHangRep();

        #region
        //   public override SingleRsp Read(int id)
        //   {
        //       var res = new SingleRsp();
        //       var m = _rep.Read(id);
        //       res.Data = m;
        //       return res;
        //  }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }


        public DonHangSvc()
        {
            donHangRep = new DonHangRep();

        }
        
     /*   public override SingleRsp UpdateDonHang(DonHang m)
        {
            var res = new SingleRsp();
            var m1 = m.MaDh > 0 ? _rep.Read(m.MaDh) : _rep.Read(m.MaKh);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.UpdateDonHang(m);
                res.Data = m;
            }

            return res;
        }
     */

        #endregion
      
        #region
       

        

        public SingleRsp CreateDonHang(DonHangReq donHangReq)
        {
           // var res = new SingleRsp();
            DonHang donHang = new DonHang();

            //donHang.MaDh = donHangReq.MaDh;
            donHang.MaKh = donHangReq.MaKh;

            donHang.MaNv = donHangReq.MaNv;

            donHang.MaShipper = donHangReq.MaShipper;

            donHang.PhiVc = donHangReq.PhiVc;

            donHang.NgayGiaoHang = donHangReq.NgayGiaoHang;

            donHang.NgayDatHang = donHangReq.NgayDatHang;
            donHang.DcgiaoHang = donHangReq.DcgiaoHang;
            
            donHang.TinhThanhDh = donHangReq.TinhThanhDh;

           // res = donHangRep.CreateDonHang(donHang);
            return donHangRep.CreateDonHang(donHang);


        }
        public SingleRsp SearchDonHang(SearchDonHangReq s)
        {
            var res = new SingleRsp();
            //Lấy DSSP theo từ khóa
            var donHangs = donHangRep.SearchDonHang(s.KeyWord);
            //Xử lý phân trang
            int pCount, totalPages, offset;
            offset = s.Size * (s.Page - 1);
            pCount= donHangs.Count;
            totalPages=(pCount%s.Size)==0? pCount/s.Size:1+(pCount/s.Size);
            var p = new
            {
                Data = donHangs.Skip(offset).Take(s.Size).ToList(),
                Page = s.Page,
                Size = s.Size,

            };   
            res.Data = p;
            return res;
        }

        public SingleRsp UpdateDonHang(int id,DonHangReq donHangReq)
        {
            var res = new SingleRsp();
            var donHang = donHangRep.Read(id);
          // DonHang donHang = new DonHang();
          //  donHang.MaDh = donHang.MaDh;
            donHang.MaKh = donHang.MaKh;
            donHang.MaNv = donHang.MaNv;
            donHang.MaShipper = donHang.MaShipper;
            donHang.ChiTietDhs = donHang.ChiTietDhs;
            donHang.NgayDatHang = donHang.NgayDatHang; ;
            donHang.NgayGiaoHang = donHang.NgayGiaoHang;
            
            res = donHangRep.UpdateDonHang(donHang);
            return res;
        }

        public SingleRsp DeleteDonHang(int id)
        {
            var res = new SingleRsp();
            var exist = _rep.Read(id);
            if(exist != null)
            {
                res.SetError($"Không tìm thấy đơn hàng có mã {id}");
                return res;
            }
            donHangRep.DeleteDonHang(exist);
            res.SetMessage("Xóa thành công");
            return res;
        }




        #endregion



    }
}
