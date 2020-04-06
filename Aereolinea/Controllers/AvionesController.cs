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
    public class AvionesController : Controller
    {
        private readonly MyDbContext _context;

        public AvionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Aviones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aviones.ToListAsync());
        }

        // GET: Aviones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviones = await _context.Aviones
                .FirstOrDefaultAsync(m => m.AvionesID == id);
            if (aviones == null)
            {
                return NotFound();
            }

            return View(aviones);
        }

        // GET: Aviones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aviones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvionesID,Modelos,Eye,Capacity")] Aviones aviones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aviones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aviones);
        }

        // GET: Aviones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviones = await _context.Aviones.FindAsync(id);
            if (aviones == null)
            {
                return NotFound();
            }
            return View(aviones);
        }

        // POST: Aviones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AvionesID,Modelos,Eye,Capacity")] Aviones aviones)
        {
            if (id != aviones.AvionesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aviones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvionesExists(aviones.AvionesID))
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
            return View(aviones);
        }

        // GET: Aviones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aviones = await _context.Aviones
                .FirstOrDefaultAsync(m => m.AvionesID == id);
            if (aviones == null)
            {
                return NotFound();
            }

            return View(aviones);
        }

        // POST: Aviones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aviones = await _context.Aviones.FindAsync(id);
            _context.Aviones.Remove(aviones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvionesExists(int id)
        {
            return _context.Aviones.Any(e => e.AvionesID == id);
        }
    }
}
