using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;
//using QLQA.BLL.Users;
using QLQA.Common.Req;
using QLQA.Common.Rsp;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private SanPhamSvc sanPhamSvc;
        public SanPhamController()
        {
            sanPhamSvc = new SanPhamSvc();
        }
        //lấy ds san pham
        [HttpPost("get-all-sanPham")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = sanPhamSvc.All;
            return Ok(res);
        }


        [HttpPost("Get-by-id")]
        public IActionResult GetSanPhamByID([FromBody] SimpleReq req)
        {

            return Ok(sanPhamSvc.Read(req.Keyword));
        }


        [HttpPost("create-sanPham")]
        public IActionResult CreateSanPham([FromBody] SanPhamReq sanPhamReq)
        {

            return Ok(sanPhamSvc.CreateSanPham(sanPhamReq));
        }


        [HttpDelete("Delete-SanPham")]
        public IActionResult DeleteSanPham([FromBody] SimpleReq req)
        {

            return Ok(sanPhamSvc.DeleteSanPham(req.Keyword));
        }
        
       
        
        [HttpPut("Update-SanPham")]
        public IActionResult UpdateProduct(string keyWord, [FromBody] SanPhamReq sanPhamReq)
        {
            if (!string.Equals(keyWord, sanPhamReq.MaSp))
            {
                return BadRequest("Không tồn tại sản phẩm ");
            }
            var res = new SingleRsp();
            res = sanPhamSvc.UpdateSanPham(sanPhamReq);
            return Ok(res);

        }

        
         [HttpPost ("Search-SanPham")]
        public IActionResult SearchProduct([FromBody] SearchSanPhamReq searchSanPhamReq)
        {
            var res = new SingleRsp();
            res.Data = sanPhamSvc.SearchSanPham(searchSanPhamReq);
            return Ok(res);
        }
         
    }
}
