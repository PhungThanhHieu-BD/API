﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLQA.BLL;

namespace QLQA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        private StatisticIRevenueSvc statisticSvc;
        
    

    [HttpPost("Cal-Total-by-Year")]
    public IActionResult CalTotalByYear(int year)
    {
        var res = statisticSvc.TongDoanhThuTheoNam(year);
        return Ok(res);
    }

    [HttpPost("Cal-Total-by-Month")]
    public IActionResult CalTotalByMonth(int month, int year)
    {
        var res = statisticSvc.TongDoanhThuTheoThangCuaNam(month, year);
        return Ok(res);
    }


        [HttpPost("Cal-Total-by-Quarter")]
        public IActionResult CalTotalByQuarter(int quarter)
        {
            var res = statisticSvc.TongDoanhThuTheoQuy(quarter);
            return Ok(res);
        }
    }

}
