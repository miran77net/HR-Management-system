using HR_MS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HR_MS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDBContext _context;

        public DashboardController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Dashboard()

        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            List<Employees> Employee = _context.Employees.ToList();
            List<Department> Departments = _context.Departments.ToList();

            
            ViewBag.TotalEmployees = Employee.Count();
            ViewBag.TotalDepartments = Departments.Count();
            ViewBag.TotalPresent =
                _context.Attendances.Count(x => x.Status == "Present");

            ViewBag.TotalLeave =
                _context.Attendances.Count(x => x.Status == "Leave");

            ViewBag.TotalAbsent =
                _context.Attendances.Count(x => x.Status == "Absent");

            return View(Employee);
        }




        public IActionResult Employees()
        {

            try
            {
                var userEmail = HttpContext.Session.GetString("UserEmail");

                if (userEmail == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                List<Employees> Employee = _context.Employees.ToList();

                return View(Employee);
            }
            catch (Exception ex)
            {

                throw;
            }

          
        }

        public IActionResult Create()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees Employees)
        {


            if (ModelState.IsValid)
            {
                Employees.Joiningdate = DateTime.Now;

                _context.Add(Employees);
                _context.SaveChanges();
                return RedirectToAction("Employees");
            }

            return View(Employees);
        }
        public IActionResult Delete(int id)
        {
            var Employees = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (Employees is not null)
            {
                _context.Remove(Employees);
                _context.SaveChanges();
            }
            return RedirectToAction("Employees");
        }

        public IActionResult Edit(int id)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var employees = _context.Employees.FirstOrDefault(x => x.Id == id);
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees Employees)
        {

            var employeesIsExist = _context.Employees.Any(x => x.Id == Employees.Id);
            if (employeesIsExist)
            {
                if (ModelState.IsValid)
                {

                    _context.Update(Employees);
                    _context.SaveChanges();
                    return RedirectToAction("Employees");
                }


                return View(Employees);
            }
            else
            {
                return NotFound();
            }

        }
        
    }
}
