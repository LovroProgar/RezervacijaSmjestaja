    using Microsoft.AspNetCore.Mvc;
    using RezervacijaSmjestaja.Data;
    using RezervacijaSmjestaja.Models;

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
                // Brišemo sesiju i cookies koji sadrže informacije o prijavljenom korisniku
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account"); // Preusmjeravamo korisnika na login stranicu
            }
            // GET: Account/Register
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


            // GET: Account/Login
            public IActionResult Login()
            {
                return View();
            }

            // POST: Account/Login
            [HttpPost]
            public IActionResult Login(string email, string lozinka)
            {
                var korisnik = _context.Korisnici.FirstOrDefault(k => k.Email == email && k.Lozinka == lozinka);
                if (korisnik != null)
                {
                    HttpContext.Session.SetString("UserEmail", korisnik.Email);
                    return RedirectToAction("Index", "Smjestaj");
                }
                ModelState.AddModelError("", "Neispravni podaci za prijavu.");
                return View();
            }

        }
    }