using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class DaiLy
    {
        [Key]
        public string? MaDaiLy { get; set; }

        [Required]
        public string? TenDaiLy { get; set; }

        public string? DiaChi { get; set; }
        public string? NguoiDaiDien { get; set; }
        public string? DienThoai { get; set; }


    }
}
