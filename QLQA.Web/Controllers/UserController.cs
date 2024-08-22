using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using System.Threading.Tasks;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
   // [Authorize(Roles = "Admin")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserSvc userSvc;
        public UserController()
        {
            userSvc = new UserSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetUserByID(int id)
        {
            var res = new SingleRsp();
            res = userSvc.Read(id);
            return Ok(res);
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            var res = new SingleRsp();
            res.Data = userSvc.All;
            return Ok(res);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserReq userReq)
        {
            var res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser([FromBody] UserReq userReq)
        {
            var res = userSvc.UpdateUser(userReq);
            return Ok(res);
        }

    //    [HttpDelete("DeleteUser")]
   //     public IActionResult DeleteUser(int id)
    //    {
    //        var res = userSvc.DeleteUser(id);
    //        return Ok(res);
    //    }


        /*
        private readonly UserSvc _userSvc;

        public UserController(UserSvc userSvc)
        {
            _userSvc = userSvc;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] UserReq userReq)
        {
            var success = await _userSvc.CreateUserAsync(userReq.UserName, userReq.Password, userReq.Email);

            if (success)
            {
                return Ok(new { message = "User created successfully" });
            }

            return BadRequest(new { message = "Username or email already exists" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserReq userReq)
        {
            var token = await _userSvc.ValidateUserAsync(userReq.UserName, userReq.Password);

            if (token != null)
            {
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Invalid username or password" });
        }
        */
    }

}

