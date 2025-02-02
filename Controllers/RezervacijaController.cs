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
            return View(model); // Ovdje se mora vratiti "Rezerviraj.cshtml"
        }





        public IActionResult PotvrdiRezervaciju(int smjestajId, DateTime datumOd, DateTime datumDo)
        {
            Console.WriteLine($"➡️ Spremam rezervaciju: SmještajID={smjestajId}, DatumOd={datumOd}, DatumDo={datumDo}");

            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == smjestajId);
            if (smjestaj == null)
            {
                Console.WriteLine("❌ Smještaj nije pronađen!");
                return RedirectToAction("Index", "Smjestaj");
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
            if (rezervacija != null && datumOd < datumDo)
            {
                rezervacija.DatumOd = datumOd;
                rezervacija.DatumDo = datumDo;
                _context.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }
    }
}
