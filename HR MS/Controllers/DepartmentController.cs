using HR_MS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR_MS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDBContext _context;

        public DepartmentController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var data = _context.Departments.ToList();



            return View(data);
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
        public IActionResult Create(Department Departments)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(Departments);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(Departments);
        }


        public IActionResult Edit(int id)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var data = _context.Departments.Find(id);

            return View(data);
        }


        [HttpPost]
        public IActionResult Edit(Department Departments)
        {
            _context.Departments.Update(Departments);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var data = _context.Departments.Find(id);

            _context.Departments.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
