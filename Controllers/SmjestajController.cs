using Microsoft.AspNetCore.Mvc;
using RezervacijaSmjestaja.Data;
using RezervacijaSmjestaja.Models;

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
            var smjestaji = _context.Smjestaji.ToList(); // Dohvati sve smještaje iz baze
            return View(smjestaji); // Proslijedi ih u View
        }


        public IActionResult Detalji(int id)
        {
            var smjestaj = _context.Smjestaji.FirstOrDefault(s => s.Id == id);
            if (smjestaj == null)
                return NotFound();

            return View(smjestaj);
        }
    }
}