using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace RezervacijaSmjestaja.Controllers
{
    public class SmjestajController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmjestajController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!UserLoggedIn()) return RedirectToAction("Login", "Account");

            var smjestaji = _context.Smjestaji.ToList();
            return View(smjestaji);
        }

        public IActionResult Detalji(int id)
        {
            if (!UserLoggedIn()) return RedirectToAction("Login", "Account");

            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == id);
            if (smjestaj == null) return NotFound();

            return View(smjestaj);
        }

        private bool UserLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }
    }
}
