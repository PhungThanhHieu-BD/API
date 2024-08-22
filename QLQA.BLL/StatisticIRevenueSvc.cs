using QLQA.Common.BLL;
using QLQA.Common.Rsp;
using QLQA.DAL;
using QLQA.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.BLL
{
    public class StatisticIRevenueSvc : GenericSvc<StatisticIRevenueRep, DonHang>
    {
        private StatisticIRevenueRep statisticRep;


        public StatisticIRevenueSvc()
        {
            statisticRep = new StatisticIRevenueRep();
        }

        public SingleRsp TongDoanhThuTheoNam(int year)
        {
            var res = new SingleRsp();
            var totalRevenue = statisticRep.TongDoanhThuTheoNam(year);
            var result = new
            {
                Year = year,
                TongDoanhThu = totalRevenue
            };
            res.Data = result;
            return res;
        }
        public SingleRsp TongDoanhThuTheoThangCuaNam(int month, int year)
        {
            var res = new SingleRsp();
            var total = statisticRep.TongDoanhThuTheoThangCuaNam(month);

            if (month < 1 || month > 12)
            {

                throw new ArgumentException("Tháng không hợp lệ");
            }
            var result = new
            {
                Year = year,
                Month = month,
                TongDoanhThu = total
            };
            res.Data = result;
            return res;
        }

        public object TongDoanhThuTheoQuy(int quarter)
        {
            if (quarter < 1 || quarter > 4)
            {
                throw new ArgumentException("Invalid quarter. Quarter should be between 1 and 4.");
            }

            int currentYear = DateTime.Now.Year;
            decimal totalRevenue = statisticRep.TongDoanhThuTheoQuy(currentYear, quarter);

            return new
            {
                Year = currentYear,
                Quarter = quarter,
                TongDoanhThu = totalRevenue
            };
        }

        public List<object> CountOrdersByMaKh()
        {
            return statisticRep.CountOrdersByMaKh();
        }
        public List<object> CountTotalRevenueByMaKh(string id)
        {
            return statisticRep.CountTotalRevenueByMaKh(id);
        }
    }
}
