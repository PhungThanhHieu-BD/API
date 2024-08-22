using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;
using QLQA.Common.Req;
using QLQA.Common.Rsp;
using System.Runtime.InteropServices.WindowsRuntime;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDhController : ControllerBase
    {

        private ChiTietDhSvc chiTietDhSvc;
        public ChiTietDhController()
        {
            chiTietDhSvc = new ChiTietDhSvc();

        }



        [HttpPost("Get-All-ChiTietDonHang")]
        public IActionResult getAllChiTietDh()
        {
            var res = new SingleRsp();
            res.Data = chiTietDhSvc.All;
            return Ok(res);
        }


        [HttpPost("Get-by-ID")]
        public IActionResult GetChiTietDH([FromBody] SimpleReq req)
        {

            var res = new SingleRsp();
            res = chiTietDhSvc.Read(req.Id);
            return Ok(res);

        }

        [HttpPost("Create-ChiTietDonHang")]
        public IActionResult CreateChiTietDh([FromBody] ChiTietDhReq chiTietDhReq)
        {
            return Ok(chiTietDhSvc.CreateChiTietDh(chiTietDhReq));
            // var res = new SingleRsp();
            // res = chiTietDhSvc.CreateChiTietDh(chiTietDhReq);
            // return Ok(res);
        }

        [HttpDelete("Delete-{ID}")]
        public IActionResult DeleteChiTietDh(int id)
        {

            return Ok(chiTietDhSvc.DeleteChiTietDh(id));
        }


        [HttpPut("Update-ChiTietDh")]
        public IActionResult UpdateChiTietDh(int id, [FromBody] ChiTietDhReq chiTietDhReq)
        {
            var res = chiTietDhSvc.UpdateChiTietDh(id, chiTietDhReq);

            return Ok(res);
        }
    }
}
