using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiHangController : ControllerBase
    {
        private LoaiHangSvc loaiHangSvc;
        public LoaiHangController()
        {
            loaiHangSvc = new LoaiHangSvc();
        }


    
        //lấy thông tin loai hàng theo id 
        [HttpPost("Get-by-ID")]
        public IActionResult GetLoaiHangByID([FromBody] SimpleReq req)
        {


            return Ok(loaiHangSvc.Read(req.Keyword));
        }

        [HttpPost("Create-LoaiHang")]
        public IActionResult CreateLoaiHang([FromBody] LoaiHangReq loaiHangReq)
        {
            //var res = new SingleRsp
            return Ok(loaiHangSvc.CreateLoaiHang(loaiHangReq));
        }

        [HttpPut("Update-LoaiHang")]
        public IActionResult UpdateCategory(string keyWord, [FromBody] LoaiHangReq loaiHangReq)
        {
            if (!string.Equals(keyWord, loaiHangReq.MaLh))
            {
                return BadRequest("Không tồn tại sản phẩm ");
            }
            var res = new SingleRsp();
            res = loaiHangSvc.UpdateLoaiHang(loaiHangReq);
            return Ok(res);
        }


        [HttpPost("Search-LoaiHang")]
        public IActionResult SearchLoaiHang([FromBody] SearchLoaiHangReq searchLoaiHangReq)
        {
            var res = new SingleRsp();
            res.Data = loaiHangSvc.SearchLoaiHang(searchLoaiHangReq);
            return Ok(res);
        }

        [HttpPost("Get-All-LoaiHang")]
        public IActionResult GetAllCategory()
        {
            var res = new SingleRsp();
            res.Data = loaiHangSvc.All;
            return Ok(res);
        }
    }
}
