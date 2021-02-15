using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReCapProject;Trusted_Connection=true");
        }
        public DbSet<Brand> tblBrands { get; set; }
        public DbSet<Car> tblCars { get; set; }
        public DbSet<Color> tblColors { get; set; }
        public DbSet<Customer> tblCustomers { get; set; }
        public DbSet<Rental> tblRentals { get; set; }
        public DbSet<User> tblUsers { get; set; }
    }
}