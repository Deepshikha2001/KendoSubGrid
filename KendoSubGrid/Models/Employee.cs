using System.ComponentModel.DataAnnotations;

namespace KendoSubGrid.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }

    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
        public string ShipName { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
    }

    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
    }

}
