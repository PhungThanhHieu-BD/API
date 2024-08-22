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
    public class SanPhamSvc : GenericSvc<SanPhamRep, SanPham>
    {
        private SanPhamRep sanPhamRep;

        public SanPhamSvc()
        {
            sanPhamRep = new SanPhamRep(); //tạo mới đối tượng DLL

        }
        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", sanPhamRep.Read(keyword));
            return res;
        }

        public SingleRsp CreateSanPham(SanPhamReq sanPhamReq)
        {

            SanPham sanPham = new SanPham();
            sanPham.MaSp = sanPhamReq.MaSp;
            sanPham.MaLh = sanPhamReq.MaLh;
            sanPham.TenSp = sanPhamReq.TenSp;
            sanPham.DonGia = sanPhamReq.DonGia;
            sanPham.SoLuongTonKho = sanPhamReq.SoLuongTonKho;
            sanPham.NgayNhapHang = sanPhamReq.NgayNhapHang;
            sanPham.MauSac = sanPhamReq.MauSac;
            sanPham.GiamGia = sanPhamReq.GiamGia;

            return sanPhamRep.CreateSanPham(sanPham);
        }
        /*
        public  override SingleRsp UpdateSanPham(SanPham m)
        {
            var res = new SingleRsp();

            var m1 = m.MaSp > 0 ? _rep.Read(m.MaSp) : _rep.Read(m.MaSp);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        */
        public SingleRsp DeleteSanPham(string keyword)
        {
            var res = new SingleRsp();
            SanPham sp = sanPhamRep.Read(keyword);
            if (sp != null)
            {
                sanPhamRep.DeleteSanPham(sp);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy sản phẩm mã  {keyword} ");
                return res;
            }
        }

        public SingleRsp UpdateSanPham(SanPhamReq sanPhamReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(sanPhamReq.MaSp);

            exist.MaSp = sanPhamReq.MaSp;
            exist.MaLh = sanPhamReq.MaLh;
            exist.TenSp = sanPhamReq.TenSp;
            exist.DonGia = sanPhamReq.DonGia;
            exist.SoLuongTonKho = sanPhamReq.SoLuongTonKho;
            exist.NgayNhapHang = sanPhamReq.NgayNhapHang;
            exist.MauSac = sanPhamReq.MauSac;
            exist.GiamGia = sanPhamReq.GiamGia;

            res = sanPhamRep.UpdateSanPham(exist);

            return res;
        }

        public SingleRsp SearchSanPham(SearchSanPhamReq searchSanPhamReq)
        {
            var res = new SingleRsp();
            //lấy dssp theo từ khóa
            var sanPham = sanPhamRep.SearchSanPham(searchSanPhamReq.KeyWord);
            //xử lý phân trang 
            int pCount, totalPage, offSet;
            offSet = searchSanPhamReq.Size * (searchSanPhamReq.Page - 1);
            pCount = sanPham.Count;

            totalPage = (pCount % searchSanPhamReq.Size) == 0 ? pCount / searchSanPhamReq.Size : 1
                + (pCount / searchSanPhamReq.Size);
            var p = new
            {
                Data = sanPham.Skip(offSet).Take(searchSanPhamReq.Size).ToList(),
                page = searchSanPhamReq.Page,
                Size = searchSanPhamReq.Size
            };
            res.Data = p;
            return res;
        }

    }
}
