using Microsoft.EntityFrameworkCore;
using QLQA.Common.DAL;
using QLQA.Common.Rsp;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLQA.DAL
{
    public  class ChiTietDhRep: GenericRep<QLBHContext, ChiTietDh>
    {

        public override ChiTietDh Read(int id)
        {
            var res = All.FirstOrDefault(o => o.MaDh == id);
            return res;
        }

        public SingleRsp CreateChiTietDh(ChiTietDh chiTietDh)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ChiTietDhs.Add(chiTietDh);
                        int result =context.SaveChanges();
                        tran.Commit();
                         res.SetData("201", "Them chi tiet don hang thanh cong.!");
                       // res.SetData("201", result);

                    }
               //     catch (DbUpdateException dbEx)
               //     {
               //         tran.Rollback();
               //         var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
               //         res.SetError($"Database update exception: {innerException}");
               //     }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError($"Exception: {ex}");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteChiTietDh(ChiTietDh chiTietDh)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ChiTietDhs.Remove(chiTietDh);
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


        public SingleRsp SearchChiTietDh(string keyWord)
        {
            var res = new SingleRsp();
            res.Data = All.Where(x => x.MaGiamGia.Contains(keyWord));
            return res;
        }


        public SingleRsp UpdateChiTietDh(ChiTietDh chiTietDh)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.ChiTietDhs.Update(chiTietDh);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật thất bại");
                    }
                }
            }
            return res;
        }
    }
}
