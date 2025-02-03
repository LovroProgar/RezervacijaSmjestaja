using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;
using System.Linq;

namespace RezervacijaSmjestaja.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Rezerviraj(int smjestajId)
        {
            Console.WriteLine($"Pozvana metoda Rezerviraj() sa smjestajId: {smjestajId}");

            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId)
                           ?? new Smjestaj { Id = 0, Naziv = "Nepoznati smještaj", Opis = "Opis nije dostupan", CijenaPoNoci = 0, SlikaUrl = "/images/default.jpg" };

            var model = new Rezervacija
            {
                SmjestajId = smjestajId,
                Smjestaj = smjestaj
            };

            Console.WriteLine("Vraćam View sa podacima.");
            return View(model); 
        }

        public IActionResult PotvrdiRezervaciju(int smjestajId, DateTime datumOd, DateTime datumDo)
        {
            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null) return NotFound();

            
            bool vecRezervirano = _context.Rezervacije.Any(r => r.SmjestajId == smjestajId);
            if (vecRezervirano)
            {
                TempData["Greska"] = "Već imate rezervaciju za ovaj smještaj.";
                return RedirectToAction("Rezerviraj", new { smjestajId });
            }

            var rezervacija = new Rezervacija
            {
                SmjestajId = smjestajId,
                Smjestaj = smjestaj,
                DatumOd = datumOd,
                DatumDo = datumDo
            };

            _context.Rezervacije.Add(rezervacija);
            _context.SaveChanges();

            return RedirectToAction("MojeRezervacije");
        }



        public IActionResult MojeRezervacije()
        {
            var rezervacije = _context.Rezervacije.Include(r => r.Smjestaj).ToList();
            return View(rezervacije);
        }

        public IActionResult ObrisiRezervaciju(int id)
        {
            var rezervacija = _context.Rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
                _context.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }

        public IActionResult PromijeniDatume(int id, DateTime datumOd, DateTime datumDo)
        {
            var rezervacija = _context.Rezervacije.FirstOrDefault(r => r.Id == id);
            if (rezervacija != null && datumOd >= DateTime.Today && datumDo > datumOd)
            {
                rezervacija.DatumOd = datumOd;
                rezervacija.DatumDo = datumDo;
                _context.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }

    }
}
