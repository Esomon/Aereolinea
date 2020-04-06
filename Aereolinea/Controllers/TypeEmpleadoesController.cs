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
    public class TypeEmpleadoesController : Controller
    {
        private readonly MyDbContext _context;

        public TypeEmpleadoesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TypeEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeEmpleado.ToListAsync());
        }

        // GET: TypeEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmpleado = await _context.TypeEmpleado
                .FirstOrDefaultAsync(m => m.TypeEmpleadoID == id);
            if (typeEmpleado == null)
            {
                return NotFound();
            }

            return View(typeEmpleado);
        }

        // GET: TypeEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeEmpleadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeEmpleadoID,Name")] TypeEmpleado typeEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeEmpleado);
        }

        // GET: TypeEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmpleado = await _context.TypeEmpleado.FindAsync(id);
            if (typeEmpleado == null)
            {
                return NotFound();
            }
            return View(typeEmpleado);
        }

        // POST: TypeEmpleadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeEmpleadoID,Name")] TypeEmpleado typeEmpleado)
        {
            if (id != typeEmpleado.TypeEmpleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeEmpleadoExists(typeEmpleado.TypeEmpleadoID))
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
            return View(typeEmpleado);
        }

        // GET: TypeEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeEmpleado = await _context.TypeEmpleado
                .FirstOrDefaultAsync(m => m.TypeEmpleadoID == id);
            if (typeEmpleado == null)
            {
                return NotFound();
            }

            return View(typeEmpleado);
        }

        // POST: TypeEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeEmpleado = await _context.TypeEmpleado.FindAsync(id);
            _context.TypeEmpleado.Remove(typeEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeEmpleadoExists(int id)
        {
            return _context.TypeEmpleado.Any(e => e.TypeEmpleadoID == id);
        }
    }
}
