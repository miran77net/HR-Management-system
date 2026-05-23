using HR_MS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_MS.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;
        public AccountController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(user model)
        {

            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserRole", user.userRole);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Error = "Invalid Email or Password";

            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
        public IActionResult Signup()
        {
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(user Users)
        {


            if (ModelState.IsValid)
            {


                _context.Add(Users);
                _context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }

            return View(Users);
        }

    }
}
