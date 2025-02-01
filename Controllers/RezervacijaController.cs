using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using System.Linq;
using System.Security.Claims;

namespace RezervacijaSmjestaja.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Prikazuje formu za rezervaciju određenog smještaja
        public IActionResult Rezerviraj(int smjestajId)
        {
            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null) return NotFound();

            var model = new Rezervacija
            {
                SmjestajId = smjestajId,
                Smjestaj = smjestaj
            };

            return View(model); // Prikazuje "Rezerviraj.cshtml"
        }

        // Obrada rezervacije nakon potvrde
        [HttpPost]
        public IActionResult PotvrdiRezervaciju(Rezervacija rezervacija)
        {
            if (!ModelState.IsValid)
            {
                var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == rezervacija.SmjestajId);
                rezervacija.Smjestaj = smjestaj;
                return View("Rezerviraj", rezervacija);
            }

            // Dobavljanje ID-a prijavljenog korisnika (pretpostavka: koristi se autentifikacija)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return RedirectToAction("Login", "Account"); // Ako nije prijavljen, preusmjeri na login

            rezervacija.KorisnikId = int.Parse(userId); // Konverzija ID-a u int
            _context.Rezervacije.Add(rezervacija);
            _context.SaveChanges();

            TempData["Uspjeh"] = "Rezervacija uspješno potvrđena!";
            return RedirectToAction("MojeRezervacije");
        }

        // Prikazuje sve rezervacije prijavljenog korisnika
        public IActionResult MojeRezervacije()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return RedirectToAction("Login", "Account");

            int korisnikId = int.Parse(userId);
            var rezervacije = _context.Rezervacije
                .Include(r => r.Smjestaj)
                .Where(r => r.KorisnikId == korisnikId)
                .ToList();

            return View(rezervacije); // Prikazuje "MojeRezervacije.cshtml"
        }
    }
}