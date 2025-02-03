using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace RezervacijaSmjestaja.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                _context.Korisnici.Add(korisnik);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(korisnik);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string lozinka)
        {
            var korisnik = _context.Korisnici.FirstOrDefault(k => k.Email == email && k.Lozinka == lozinka);
            if (korisnik != null)
            {
                HttpContext.Session.SetInt32("UserId", korisnik.Id);
                HttpContext.Session.SetString("UserEmail", korisnik.Email);
                return RedirectToAction("Index", "Smjestaj");
            }
            ModelState.AddModelError("", "Neispravni podaci za prijavu.");
            return View();
        }
    }
}
