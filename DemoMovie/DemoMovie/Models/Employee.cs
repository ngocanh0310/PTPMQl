using System.ComponentModel.DataAnnotations;

namespace DemoMovie.Models
{
    public class Employee : Person
    {
        public string? EmployeeId { get; set; }
        public int Age { get; set; }
    }

    public class HeThongPhanPhoi
    {
        public string? MaHTPP { get; set; }
        public string? TenHTPP { get; set; }
    }
}
