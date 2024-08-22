using System.ComponentModel.DataAnnotations;

namespace QLQA.Web.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="*")]
        [MaxLength(20, ErrorMessage ="Tối đa 20 kí tự")]
        public string MaKh { get; set; }
        public string HoKh { get; set; }
        public string TenKh { get; set; }
        public string DiaChi { get; set; }
        public string TinhThanh { get; set; }
        public string Sdt { get; set; }
    }
}
