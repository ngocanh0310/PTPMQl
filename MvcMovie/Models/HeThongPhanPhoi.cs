using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class HeThongPhanPhoi
{
    [Key]
    public string MaHTPP { get; set; }

    [Required]
    public string TenHTPP { get; set; }

    // Quan hệ 1-n với Đại Lý
    public ICollection<DaiLy> DaiLys { get; set; }
}
