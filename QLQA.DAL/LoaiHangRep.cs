using QLQA.Common.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QLQA.Common.Rsp;

namespace QLQA.DAL
{
    public class LoaiHangRep : GenericRep<QLBHContext, LoaiHang>
    {
        public LoaiHangRep()
        {

        }
        //    public override LoaiHang Read(int id)
        //    {
        //        var res = All.FirstOrDefault(c => c.SoLh == id);
        //        return res;
        //     }

        public override LoaiHang Read(string id)
        {
            var res = All.FirstOrDefault(c => c.MaLh == id);
            return res;
        }

        public SingleRsp CreateLoaiHang(LoaiHang loaiHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Add(loaiHang);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError(ex.Message);
                    }
                }
            }
            return res;

        }
        public List<LoaiHang> SearchLoaiHang(string keyWord)
        {


            return All.Where(x => x.TenLh.Contains(keyWord)).ToList();
        }


        public SingleRsp UpdateLoaiHang(LoaiHang loaiHang)
        {
            var res = new SingleRsp();

            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Update(loaiHang);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật loại hàng thành công!!!");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật loại hàng thất bại!!!");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteLoaiHang(LoaiHang loaiHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.LoaiHangs.Remove(loaiHang);
                        int result = context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
