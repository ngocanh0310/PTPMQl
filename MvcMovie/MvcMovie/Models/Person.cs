using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int Age { get; set; }

        public string Address { get; set; }
    }
}
