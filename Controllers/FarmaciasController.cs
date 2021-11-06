using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dwc.Data;
using dwc.Models;

namespace dwc.Controllers
{
    public class FarmaciasController : Controller
    {
        private readonly FARMACIASContext _context;

        public FarmaciasController(FARMACIASContext context)
        {
            _context = context;
        }

        // GET: Farmacias
        public async Task<IActionResult> Index()
        {
            var fARMACIASContext = _context.Farmacias.Include(f => f.IdperiodoNavigation);
            return View(await fARMACIASContext.ToListAsync());
        }

        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias
                .Include(f => f.IdperiodoNavigation)
                .FirstOrDefaultAsync(m => m.Idfarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            ViewData["Idperiodo"] = new SelectList(_context.Factperiodos, "Idperiodo", "Descripcion");
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfarmacia,Nombre,Poblacion,Idperiodo,Ultfactura")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idperiodo"] = new SelectList(_context.Factperiodos, "Idperiodo", "Descripcion", farmacia.Idperiodo);
            return View(farmacia);
        }

        // GET: Farmacias/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias.FindAsync(id);
            if (farmacia == null)
            {
                return NotFound();
            }
            ViewData["Idperiodo"] = new SelectList(_context.Factperiodos, "Idperiodo", "Descripcion", farmacia.Idperiodo);
            return View(farmacia);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idfarmacia,Nombre,Poblacion,Idperiodo,Ultfactura")] Farmacia farmacia)
        {
            if (id != farmacia.Idfarmacia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciaExists(farmacia.Idfarmacia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idperiodo"] = new SelectList(_context.Factperiodos, "Idperiodo", "Descripcion", farmacia.Idperiodo);
            return View(farmacia);
        }

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacias
                .Include(f => f.IdperiodoNavigation)
                .FirstOrDefaultAsync(m => m.Idfarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var farmacia = await _context.Farmacias.FindAsync(id);
            _context.Farmacias.Remove(farmacia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciaExists(string id)
        {
            return _context.Farmacias.Any(e => e.Idfarmacia == id);
        }
    }
}
