using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QLQA.Common.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.BLL
{
    public class UserSvc : GenericSvc<UserRep, User>
    {
        private UserRep userRep;

        public UserSvc()
        {
            userRep = new UserRep();
        }

        //Lấy user theo ID truyền vào
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);

            if (res.Data == null)

            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }

            return res;
        }

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.MaNv = userReq.MaNv;
            user.UserName = userReq.UserName; ;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            user.IsAd = userReq.IsAd;
            //Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
            if (userReq.IsAd != 0 && userReq.IsAd != 1)
                user.IsAd = 0;
            userRep.CreateUser(user);
            return res;
        }

        public SingleRsp UpdateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.MaNv = userReq.MaNv;
            user.UserName = userReq.UserName;
            user.Email = userReq.Email;
            user.Password = userReq.Password;
            user.IsAd = userReq.IsAd;
            //Nếu isAdmin khác 0 hoặc 1 thì gán mặc định là 0
            if (userReq.IsAd != 0 && userReq.IsAd != 1)
                user.IsAd = 0;
            userRep.UpdateUser(user);
            return res;
        }

   //     public SingleRsp DeleteUser(int id)
  //      {
   //         var res = new SingleRsp();
   //         var context = new QLBHContext();
   //         var user = context.Users.Find(id);
   //         if (user != null)
   //         {
   //             context.Users.Remove(user);
   //             context.SaveChanges();
   //             res.SetMessage("Da xoa user");
   //         }
   //         else
   //         {
   //             res.SetMessage("Khong tim thay user");
   //             res.SetError("404", "Khong tim thay user");
   //         }
   //         return res;
   //     }


        public SingleRsp GetUserByUsername(String username)
        {
            var res = new SingleRsp();
            res.Data = userRep.GetUserByUsername(username);
            if (res.Data != null)

            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }
            return res;
        }

        /*
        private readonly QLBHContext _dbContext;
        private readonly IConfiguration _configuration;


        public UserSvc(QLBHContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> CreateUserAsync(string username, string password, string email)
        {
            if (await _dbContext.Users.AnyAsync(u => u.UserName == username || u.Email == email))
            {
                Console.WriteLine("Validate User!");
                return false; // Username or email already exists
            }

            var user = new User
            {
                UserName = username,
                Email = email,
                Password = password,
                // RoleId = 2
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            Console.WriteLine("create User successfully!");
            return true;
        }


          public SingleRsp GetUserByUsername(String  username)
        {
            var res = new SingleRsp();
            res.Data = userRep.GetUserByUsername(username);
            if(res.Data != null)

            {
                res.SetMessage("Khong tim thay user");
                res.SetError("404", "Khong tim thay user");
            }        
            return res;
        }
        public async Task<string> ValidateUserAsync(string username, string password)
        {
            var user = await _dbContext.Users
                .Where(u => u.UserName == username)
                .FirstOrDefaultAsync();

            if (user == null || user.Password != password)
            {
                return null; // Invalid username or password
            }

            return GenerateJwtToken(user.UserName, user.UserId);//,(int)user.RoleId); // Return the JWT token
        }

        private string GenerateJwtToken(string userName, int userId)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwtToken(string username, int userID, int roleId)
        {
            var secretKey = _configuration["Jwt:SecretKey"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim("UserId", userID.ToString()),
                    new Claim("RoleId", roleId.ToString())
                }),
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        */



    }
}
