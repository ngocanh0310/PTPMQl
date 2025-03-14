using System.ComponentModel.DataAnnotations;

namespace DemoMovieMovie.Models
{
    public class DaiLy
    {
        [Key]
        public int MaDaiLy { get; set; }

        [Required]
        public string? TenDaiLy { get; set; } // Sửa kiểu dữ liệu từ int -> string

        [Required]
        public string? DiaChi { get; set; } // Sửa kiểu dữ liệu từ int -> string

        public string? NguoiDaiDien { get; set; }
        public string? DienThoai { get; set; }
        public string? MaHTPP { get; set; } // Khóa ngoại liên kết với HeThongPhanPhoi
    }
}
