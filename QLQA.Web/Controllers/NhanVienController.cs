using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;

namespace QLQA.Web.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private NhanVienSvc nhanVienSvc;
        public NhanVienController()
        {
            nhanVienSvc = new NhanVienSvc();

        }

        [HttpPost("Get-All-NhanVien")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = nhanVienSvc.All;
            return Ok(res);
        }

        [HttpPost("Get-by-id")]
        public IActionResult GetNhanVienByID([FromBody] SimpleReq req)
        {

            return Ok(nhanVienSvc.Read(req.Keyword));
        }


        [HttpPost("create-NhanVien")]
        public IActionResult CreateNhanVien([FromBody] NhanVienReq nhanVienReq)
        {

            return Ok(nhanVienSvc.CreateNhanVien(nhanVienReq));
        }


        [HttpDelete("Delete-NhanVien")]
        public IActionResult DeleteNhanVien([FromBody] SimpleReq req)
        {

            return Ok(nhanVienSvc.DeleteNhanVien(req.Keyword));
        }

        [HttpPut("Update-NhanVien")]
        public IActionResult UpdateNhanVien(string keyWord, [FromBody] NhanVienReq nhanVienReq)
        {
            if (!string.Equals(keyWord, nhanVienReq.MaNv))
            {
                return BadRequest("Không tồn tại nhân viên ");
            }
            var res = new SingleRsp();
            res = nhanVienSvc.UpdateNhanVien(nhanVienReq);
            return Ok(res);

        }
    }
}
