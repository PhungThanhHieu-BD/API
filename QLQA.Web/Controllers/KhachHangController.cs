using Microsoft.AspNetCore.Mvc;
using QLQA.DAL.Models;

namespace QLQA.Web.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly QLBHContext db;
        public KhachHangController(QLBHContext context)
        {
            db= context;
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
    }
}
