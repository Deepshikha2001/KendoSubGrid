using KendoSubGrid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KendoSubGrid.Controllers
{
    public class KendoController : Controller
    {
        public readonly KendoDbContext context;
        public KendoController(KendoDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetData()
        {
            var employees = context.EmpKendodata.ToList();
            return Json(employees);
        }
        //[HttpGet]
        //public IActionResult GetOrders()
        //{
        //    var orders = context.Orders.ToList();
        //    return Json(orders);
        //}
        [HttpGet]
        public IActionResult GetOrders(int employeeId)
        {
            var orders = context.Orders.Where(o => o.EmployeeID == employeeId).ToList();
            return Json(orders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Country = model.Country,
                    City = model.City,
                };
                context.EmpKendodata.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Saved SuccessFully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty Field Can't Submit";
                return View(model);
            }

        }
        public IActionResult Edit(int id)
        {
            var emp = context.EmpKendodata.FirstOrDefault(x => x.EmployeeID == id);
            var result = new Employee()
            {
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Country = emp.Country,
                City = emp.City
            };

            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                EmployeeID = model.EmployeeID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Country = model.Country,
                City = model.City

            };
            context.EmpKendodata.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Updated SuccessFully!";

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var emp = context.EmpKendodata.FirstOrDefault(x => x.EmployeeID == id);
            context.EmpKendodata.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted!";

            return RedirectToAction("Index");
        }
    }
}
