using Models;
using Microsoft.EntityFrameworkCore;


namespace DatabaseSchema.Database
{
    public class EmployeesDbContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql("Server=localhost; User ID=postgres; Password=guest; Port=7777");
    }
}
