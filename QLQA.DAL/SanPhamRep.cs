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
    public class SanPhamRep : GenericRep<QLBHContext, SanPham>
    {
        public override SanPham Read(string keyword)
        {
            var res = All.FirstOrDefault(s => s.MaSp == keyword);
            return res;
        }


        public SingleRsp CreateSanPham(SanPham sanPham)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SanPhams.Add(sanPham);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them san pham thanh cong.!");

                    }
                    catch (DbUpdateException dbEx)
                    {
                        tran.Rollback();
                        var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                        res.SetError($"Database update exception: {innerException}");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError($"Exception: {ex}");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteSanPham(SanPham sanPham)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SanPhams.Remove(sanPham);
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

        public List<SanPham> SearchSanPham(string keyWord)
        {


            return All.Where(x => x.TenSp.Contains(keyWord)).ToList();
        }

        //     public SingleRsp SearchSanPham(string keyWord)
        //      {
        //          var res = new SingleRsp();
        //          res.Data = All.Where(x => x.TenSp.Contains(keyWord));
        //          return res;
        //      }

        public SingleRsp UpdateSanPham(SanPham sanPham)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.SanPhams.Update(sanPham);
                        context.SaveChanges();
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
