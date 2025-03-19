using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class HeThongPhanPhoi
    {
        [Key]
        public string? MaHTPP { get; set; }

        [Required]
        public string? TenHTPP { get; set; }

        // Quan hệ 1-N với DaiLy
    }
}
