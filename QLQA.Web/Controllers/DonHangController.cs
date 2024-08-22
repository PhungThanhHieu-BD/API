using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using QLQA.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private DonHangSvc donHangSvc;
        public DonHangController()
        {
            donHangSvc = new DonHangSvc();

        }



        [HttpPost("Get-All-DonHang")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = donHangSvc.All;
            return Ok(res);
        }


        [HttpPost("Get-by-ID")]
        public IActionResult GetOrderByID([FromBody] SimpleReq req)
        {

            var res = new SingleRsp();
            res = donHangSvc.Read(req.Id);
            return Ok(res);

        }



        [HttpPost("Create-DonHang")]
        public IActionResult CreateDonHang([FromBody] DonHangReq donHangReq )
        {
          //  var res = new SingleRsp();
           // res = donHangSvc.CreateDonHang(donHangReq);
            return Ok(donHangSvc.CreateDonHang(donHangReq));
        }



        [HttpPost("Search-DonHang")]
        public IActionResult SearchDonHang([FromBody] SearchDonHangReq searchDonHangReq)
        {
            var res = new SingleRsp();
            res = donHangSvc.SearchDonHang(searchDonHangReq);
            return Ok(res);
        }



        [HttpPost("update-DonHang")]
        public IActionResult UpdateDonHang(int id,[FromBody] DonHangReq donHangReq)
        {
            var res = new SingleRsp();
            res = donHangSvc.UpdateDonHang(id,donHangReq);
            return Ok(res);
        }

        [HttpDelete("Delete{id}")]
        public IActionResult DeleteDonHang(int id)
        {
            return Ok(donHangSvc.DeleteDonHang(id));
        }




    }

}