using QLQA.Common.BLL;
using QLQA.DAL.Models;
using QLQA.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using QLQA.Common.Req;
using QLQA.Common.Rsp;

namespace QLQA.BLL
{
    public class ChiTietDhSvc : GenericSvc<ChiTietDhRep, ChiTietDh>
    {
        private ChiTietDhRep chiTietDhRep;

        public ChiTietDhSvc()
        {
            ChiTietDhRep req = new ChiTietDhRep();
        }


        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            res.Data = _rep.Read(id);
            return res;
        }

        public SingleRsp CreateChiTietDh(ChiTietDhReq chiTietDhReq)
        {
            
            ChiTietDh chiTietDh = new ChiTietDh();

            chiTietDh.MaDh = chiTietDhReq.MaDh;
            chiTietDh.MaSp = chiTietDhReq.MaSp;
            chiTietDh.MaGiamGia = chiTietDhReq.MaGiamGia;
            chiTietDh.DonGia = chiTietDhReq.DonGia;


            chiTietDh.SoLuong = chiTietDhReq.SoLuong;
            



            return chiTietDhRep.CreateChiTietDh(chiTietDh);



        }
        public SingleRsp DeleteChiTietDh(int id)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(id);
            //  ChiTietDh chiTietDh = chiTietDhRep.Read(keyword);
            if (exist == null)
            {
                res.SetError($"Không tìm thấy đơn mã {id}");
                
                return res;
            }

            chiTietDhRep.DeleteChiTietDh(exist);
            res.SetMessage("Xóa thành công");
            return res;
        }


        public SingleRsp UpdateChiTietDh(int id, ChiTietDhReq chiTietDhReq)
        {
            var res = new SingleRsp();
            var chiTietDh = chiTietDhRep.Read(id);

            chiTietDh.MaSp = chiTietDhReq.MaSp;
            chiTietDh.MaGiamGia = chiTietDhReq.MaGiamGia;
            chiTietDh.SoLuong = chiTietDhReq.SoLuong;
            chiTietDh.DonGia = chiTietDhReq.DonGia;



            res = chiTietDhRep.UpdateChiTietDh(chiTietDh);
            return res;
        }


    }
}

    
