using QLQA.Common.DAL;
using QLQA.Common.Rsp;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLQA.DAL
{
    public class UserRep : GenericRep<QLBHContext, User>
    {
        public UserRep() { }
        //Lấy user theo ID truyền vào 
        public override User Read(int id)
        {
            var res = All.FirstOrDefault(u => u.UserId == id);
            return res;
        }

        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            var context = new QLBHContext();
            using (var tran = context.Database.BeginTransaction())
            {
                var checkuser = context.Users.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
                if (checkuser == null)
                {     
                    try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    tran.Commit();
                    res.SetMessage("Tao thanh cong");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    res.SetError(ex.StackTrace);
                    res.SetMessage("Tao that bai");
                }
            }
             else
            {
                res.SetMessage("User da ton tai");
                return res;
            }
        }
            return res;
        }
        public SingleRsp UpdateUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Users.Update(user);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update that bai");
                    }
                }
            }
            return res;
        }

        /*
        public SingleRsp DeleteUser(User user)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa user");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Xoa that bai");
                    }
                }
            }
            return res;
        }
        */

        public User GetUserByUsername(string username)
        {
            var res = All.FirstOrDefault(e => e.UserName == username);
            return res;
        }
    }
}
