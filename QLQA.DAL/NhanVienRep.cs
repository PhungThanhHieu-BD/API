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
    public class NhanVienRep:GenericRep<QLBHContext, NhanVien>
    {
        public override NhanVien Read(string keyword)
        {
            var res = All.FirstOrDefault(s => s.MaNv == keyword);
            return res;
        }

        public SingleRsp CreateNhanVien(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Add(nhanVien);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them nhan vien thanh cong.!");

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

        public SingleRsp DeleteNhanVien(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.NhanViens.Remove(nhanVien);
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

        public SingleRsp SearchNhanVien(string keyWord)
        {
            var res = new SingleRsp();
            res.Data = All.Where(x => x.TenNv.Contains(keyWord));
            return res;
        }

        public SingleRsp UpdateNhanVien(NhanVien nhanVien)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.NhanViens.Update(nhanVien);
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
