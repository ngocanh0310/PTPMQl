using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Employee
    {
        [Key]
        public string? EmployeeId { get; set; } // Hoặc int nếu cần
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
    }
}
