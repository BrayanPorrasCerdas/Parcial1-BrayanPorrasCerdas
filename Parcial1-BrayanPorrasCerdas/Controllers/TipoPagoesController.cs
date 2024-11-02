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
    public class TipoPagoesController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public TipoPagoesController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: TipoPagoes
        public async Task<IActionResult> Index(string buscar_tipo_pago)
        {

            var tipo_pago = from TipoPago in _context.TipoPagos select TipoPago;

            if (!String.IsNullOrEmpty(buscar_tipo_pago))
            {
                tipo_pago = tipo_pago.Where(s =>
                    s.Descripcion!.Contains(buscar_tipo_pago));
            }

            return View(await tipo_pago.ToListAsync());
        }

        // GET: TipoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // GET: TipoPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPago,Descripcion,FechaCreacion,FechaModificacion")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPago);
        }

        // GET: TipoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos.FindAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }
            return View(tipoPago);
        }

        // POST: TipoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPago,Descripcion,FechaCreacion,FechaModificacion")] TipoPago tipoPago)
        {
            if (id != tipoPago.IdTipoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagoExists(tipoPago.IdTipoPago))
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
            return View(tipoPago);
        }

        // GET: TipoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPagos
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // POST: TipoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPago = await _context.TipoPagos.FindAsync(id);
            if (tipoPago != null)
            {
                _context.TipoPagos.Remove(tipoPago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagoExists(int id)
        {
            return _context.TipoPagos.Any(e => e.IdTipoPago == id);
        }
    }
}
