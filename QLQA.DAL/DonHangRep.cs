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
    public class DonHangRep : GenericRep<QLBHContext, DonHang>
    {
        #region
        public override DonHang Read(int id)
        {
            var res = All.FirstOrDefault(p=>p.MaDh == id);
            return res;
        }

     //   public int Delete(int id)
     //   {
     //       var m = base.All.First(i=>i.MaDh == id);
     //       m = base.Delete(m);
      //      return m.MaDh;
      //  }
        #endregion
        #region
        //     public SingleRsp CreateDonHang(DonHang donHang)
        //     {


        //         var res = new SingleRsp();
        //         using (var context = new QLBHContext())
        //         {
        //             using (var tran = context.Database.BeginTransaction())
        //             {
        //                 try
        //                 {
        //                     var p = context.DonHangs.Add(donHang);
        //                     context.SaveChanges();
        //                     tran.Commit();


        //               }
        //               catch (Exception ex)
        //                {
        //                   tran.Rollback();
        //                  res.SetError(ex.StackTrace);
        //              }
        //         }
        //    }    
        //     return res;
        //   }

        /*    public SingleRsp CreateDonHang(DonHang donHang)
            {
                var res = new SingleRsp();
                using (var context = new QLBHContext())
                {
                    using (var tran = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.DonHangs.Add(donHang);
                            int result = context.SaveChanges();
                            tran.Commit();
                            res.SetData("201", result);
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
        */
        /*     public SingleRsp CreateDonHang(DonHang donHang)
             {
                 var res = new SingleRsp();
                 using (var context = new QLBHContext())
                 {
                     using (var tran = context.Database.BeginTransaction())
                     {
                         try
                         {
                             context.DonHangs.Add(donHang);
                             context.SaveChanges();
                             tran.Commit();
                             res.SetData("201", "Them don hang thanh cong.!");

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
        */
        public SingleRsp CreateDonHang(DonHang donHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Add(donHang);
                        int result = context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", "Them don hang thanh cong");
                    }
               //     catch (DbUpdateException dbEx)
               //     {
               //         tran.Rollback();
              //          var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
              //          res.SetError($"Database update exception: {innerException}");
              //      }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError($"Exception: {ex}");
                    }
                }
            }
            return res;
        }
        public List<DonHang> SearchDonHang(string keyWord)
        {

            // res.Data = All.Where(x=>x.MaKh.Contains(keyWord));
            return All.Where(x => x.MaKh.Contains(keyWord)).ToList();
        }
/*
        public SingleRsp UpdateDonHang(DonHang donHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.DonHangs.Update(donHang);
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
*/
        public SingleRsp DeleteDonHang(DonHang donHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                       var p = context.DonHangs.Remove(donHang);
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

        public SingleRsp UpdateDonHang(DonHang donHang)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Update(donHang);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật thất bại ");
                    }
                }
            }
            return res;
        }
        #endregion

    }
}
