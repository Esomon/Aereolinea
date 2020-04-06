using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aereolinia.Models;

namespace aereolinia.Controllers
{
    public class VuelosController : Controller
    {
        private readonly MyDbContext _context;

        public VuelosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Vuelos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vuelos.ToListAsync());
        }

        // GET: Vuelos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelos = await _context.Vuelos
                .FirstOrDefaultAsync(m => m.VuelosID == id);
            if (vuelos == null)
            {
                return NotFound();
            }

            return View(vuelos);
        }

        // GET: Vuelos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vuelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VuelosID,Cinty,Fecha,Aerolinea")] Vuelos vuelos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vuelos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vuelos);
        }

        // GET: Vuelos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelos = await _context.Vuelos.FindAsync(id);
            if (vuelos == null)
            {
                return NotFound();
            }
            return View(vuelos);
        }

        // POST: Vuelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VuelosID,Cinty,Fecha,Aerolinea")] Vuelos vuelos)
        {
            if (id != vuelos.VuelosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vuelos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VuelosExists(vuelos.VuelosID))
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
            return View(vuelos);
        }

        // GET: Vuelos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vuelos = await _context.Vuelos
                .FirstOrDefaultAsync(m => m.VuelosID == id);
            if (vuelos == null)
            {
                return NotFound();
            }

            return View(vuelos);
        }

        // POST: Vuelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vuelos = await _context.Vuelos.FindAsync(id);
            _context.Vuelos.Remove(vuelos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VuelosExists(int id)
        {
            return _context.Vuelos.Any(e => e.VuelosID == id);
        }
    }
}
