using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelPortal.Data;
using PersonelPortal.Models;

namespace PersonelPortal.Controllers
{
    public class RehberController : Controller
    {
        private readonly AppDbContext _context;

        public RehberController(AppDbContext context)
        {
            _context = context;
        }

        // LISTE
        public async Task<IActionResult> Index()
        {
            var liste = await _context.Personeller
                .OrderBy(x => x.AdSoyad)
                .ToListAsync();

            return View(liste);
        }

        // EKLE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // EKLE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel)
        {
            if (!ModelState.IsValid)
                return View(personel);

            _context.Personeller.Add(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GÜNCELLE (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel == null) return NotFound();
            return View(personel);
        }

        // GÜNCELLE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Personel personel)
        {
            if (id != personel.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(personel);

            _context.Update(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // SİL (GET) - onay ekranı
        public async Task<IActionResult> Delete(int id)
        {
            var personel = await _context.Personeller.FirstOrDefaultAsync(x => x.Id == id);
            if (personel == null) return NotFound();
            return View(personel);
        }

        // SİL (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel == null) return NotFound();

            _context.Personeller.Remove(personel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
} 
