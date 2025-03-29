namespace Movie.Data  // Đảm bảo namespace này đúng với thư mục chứa file
{
    using Microsoft.EntityFrameworkCore;
    using Movie.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }


}
