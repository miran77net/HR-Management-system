using HR_MS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HR_MS.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
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
            var data = _context.Attendances.ToList();

            

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
        public IActionResult Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Attendances.Add(attendance);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(attendance);
        }

       
        public IActionResult Edit(int id)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");

            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var data = _context.Attendances.Find(id);

            return View(data);
        }

        
        [HttpPost]
        public IActionResult Edit(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var data = _context.Attendances.Find(id);

            _context.Attendances.Remove(data);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}