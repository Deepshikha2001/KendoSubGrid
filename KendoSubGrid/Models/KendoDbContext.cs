using Microsoft.EntityFrameworkCore;

namespace KendoSubGrid.Models
{
    public class KendoDbContext: DbContext
    {
        public KendoDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> EmpKendodata {  get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

    }

}
