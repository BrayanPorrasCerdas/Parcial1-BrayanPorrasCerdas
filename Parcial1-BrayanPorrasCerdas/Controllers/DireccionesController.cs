using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1_BrayanPorrasCerdas.Models;

namespace Parcial1_BrayanPorrasCerdas.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public DireccionesController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index(string buscar_direccion)
        {
            var direcciones = from Direccion in _context.Direccions select Direccion;

            if (!String.IsNullOrEmpty(buscar_direccion))
            {
                direcciones = direcciones.Where(s =>
                    s.DireccionExacta!.Contains(buscar_direccion) ||
                    s.CodigoPostal!.Contains(buscar_direccion)); 
            }

            return View(await direcciones.ToListAsync());

        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // GET: Direcciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProvinciaId,CantonId,DistritoId,DireccionExacta,CodigoPostal,IdPais,FechaCreacion,FechaModificacion")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProvinciaId,CantonId,DistritoId,DireccionExacta,CodigoPostal,IdPais,FechaCreacion,FechaModificacion")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _context.Direccions.FindAsync(id);
            if (direccion != null)
            {
                _context.Direccions.Remove(direccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _context.Direccions.Any(e => e.Id == id);
        }
    }
}
