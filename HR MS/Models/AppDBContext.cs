using Microsoft.EntityFrameworkCore;

namespace HR_MS.Models
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext>options) :base(options) { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<user> Users { get; set; }

       
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
    }

   
}
