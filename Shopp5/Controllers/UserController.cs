using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopp5.Models;

namespace Shopp5.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Username == user.Username || u.Email == user.Email))
            {
                ViewBag.Message = "User already exists.";
                return View();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
            if (user == null)
            {
                ViewBag.Message = "Invalid email or password.";
                return View();
            }
            return RedirectToAction("Welcome");
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }
}
