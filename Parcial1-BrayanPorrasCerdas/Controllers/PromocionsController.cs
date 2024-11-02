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
    public class PromocionsController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public PromocionsController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: Promocions
        public async Task<IActionResult> Index(string buscar_promocion)
        {
            var promociones = from promocion in _context.Promocions select promocion;

            if (!string.IsNullOrEmpty(buscar_promocion))
            {
                promociones = promociones.Where(s =>
                    (s.Descripcion != null && s.Descripcion.Contains(buscar_promocion)) ||
                    (s.FechaFinaliza != null && s.FechaFinaliza.ToString().Contains(buscar_promocion)) ||
                    (s.PorcentajeDescuento != null && s.PorcentajeDescuento.ToString().Contains(buscar_promocion)) ||
                    (s.FechaInicia != null && s.FechaInicia.ToString().Contains(buscar_promocion)));
            }

            return View(await promociones.ToListAsync());
        }


        // GET: Promocions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocion = await _context.Promocions
                .FirstOrDefaultAsync(m => m.IdPromocion == id);
            if (promocion == null)
            {
                return NotFound();
            }

            return View(promocion);
        }

        // GET: Promocions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPromocion,NombreCorto,Descripcion,PorcentajeDescuento,FechaInicia,FechaFinaliza,FechaCreacion,FechaModificacion")] Promocion promocion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocion);
        }

        // GET: Promocions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocion = await _context.Promocions.FindAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            return View(promocion);
        }

        // POST: Promocions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPromocion,NombreCorto,Descripcion,PorcentajeDescuento,FechaInicia,FechaFinaliza,FechaCreacion,FechaModificacion")] Promocion promocion)
        {
            if (id != promocion.IdPromocion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocionExists(promocion.IdPromocion))
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
            return View(promocion);
        }

        // GET: Promocions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocion = await _context.Promocions
                .FirstOrDefaultAsync(m => m.IdPromocion == id);
            if (promocion == null)
            {
                return NotFound();
            }

            return View(promocion);
        }

        // POST: Promocions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocion = await _context.Promocions.FindAsync(id);
            if (promocion != null)
            {
                _context.Promocions.Remove(promocion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocionExists(int id)
        {
            return _context.Promocions.Any(e => e.IdPromocion == id);
        }
    }
}
