using QLQA.Common.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace QLQA.BLL
{
    public class NhanVienSvc : GenericSvc<NhanVienRep, NhanVien>
    {

        private NhanVienRep nhanVienRep;

        public NhanVienSvc()
        {
            nhanVienRep = new NhanVienRep(); //tạo mới đối tượng DLL

        }
        public override SingleRsp Read(string keyword)
        {
            var res = new SingleRsp();

            res.SetData("200", nhanVienRep.Read(keyword));
            return res;
        }

        public SingleRsp CreateNhanVien(NhanVienReq nhanVienReq)
        {

            NhanVien nhanVien = new NhanVien();
            nhanVien.MaNv = nhanVienReq.MaNv;
            nhanVien.HoNv = nhanVienReq.HoNv;
            nhanVien.TenNv = nhanVienReq.TenNv;
            nhanVien.DiaChiNv = nhanVienReq.DiaChiNv;
            nhanVien.NgaySinh = nhanVienReq.NgaySinh;
            nhanVien.Email = nhanVienReq.Email;
            nhanVien.ChucVu = nhanVienReq.ChucVu;
            nhanVien.Luong = nhanVienReq.Luong;



            return nhanVienRep.CreateNhanVien(nhanVien);
        }

        public SingleRsp DeleteNhanVien(string keyword)
        {
            var res = new SingleRsp();
            NhanVien nv = nhanVienRep.Read(keyword);
            if (nv != null)
            {
                nhanVienRep.DeleteNhanVien(nv);
                res.SetMessage("Xóa thành công .");
                return res;
            }
            else
            {
                res.SetError($"Không tìm thấy nhân viên mã  {keyword} ");
                return res;
            }
        }

        public SingleRsp UpdateNhanVien(NhanVienReq nhanVienReq)
        {
            var res = new SingleRsp();

            var exist = _rep.Read(nhanVienReq.MaNv);

            exist.MaNv = nhanVienReq.MaNv;
            exist.HoNv = nhanVienReq.HoNv;
            exist.TenNv = nhanVienReq.TenNv;
            exist.DiaChiNv = nhanVienReq.DiaChiNv;
            exist.NgaySinh = nhanVienReq.NgaySinh;
            exist.Email = nhanVienReq.Email;
            exist.ChucVu = nhanVienReq.ChucVu;
            exist.Luong = nhanVienReq.Luong;
           

            res = nhanVienRep.UpdateNhanVien(exist);

            return res;
        }

        


    }
}
