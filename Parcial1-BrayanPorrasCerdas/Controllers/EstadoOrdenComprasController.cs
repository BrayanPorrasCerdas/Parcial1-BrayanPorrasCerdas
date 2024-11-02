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
    public class EstadoOrdenComprasController : Controller
    {
        private readonly TiendaOnlineBrayanPorrasContext _context;

        public EstadoOrdenComprasController(TiendaOnlineBrayanPorrasContext context)
        {
            _context = context;
        }

        // GET: EstadoOrdenCompras
        public async Task<IActionResult> Index(string buscar_estado)
        {
            var estado_compras = from EstadoOrdenCompra in _context.EstadoOrdenCompras select EstadoOrdenCompra;

            if (!String.IsNullOrEmpty(buscar_estado))
            {
                estado_compras = estado_compras.Where(s =>
                    s.Estado!.Contains(buscar_estado));
            }

            return View(await estado_compras.ToListAsync());

        }

        // GET: EstadoOrdenCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoOrdenCompra = await _context.EstadoOrdenCompras
                .FirstOrDefaultAsync(m => m.IdEstadoOrden == id);
            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }

            return View(estadoOrdenCompra);
        }

        // GET: EstadoOrdenCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoOrdenCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoOrden,Estado,FechaCreacion,FechaModificacion")] EstadoOrdenCompra estadoOrdenCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoOrdenCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoOrdenCompra);
        }

        // GET: EstadoOrdenCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoOrdenCompra = await _context.EstadoOrdenCompras.FindAsync(id);
            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }
            return View(estadoOrdenCompra);
        }

        // POST: EstadoOrdenCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoOrden,Estado,FechaCreacion,FechaModificacion")] EstadoOrdenCompra estadoOrdenCompra)
        {
            if (id != estadoOrdenCompra.IdEstadoOrden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoOrdenCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoOrdenCompraExists(estadoOrdenCompra.IdEstadoOrden))
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
            return View(estadoOrdenCompra);
        }

        // GET: EstadoOrdenCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoOrdenCompra = await _context.EstadoOrdenCompras
                .FirstOrDefaultAsync(m => m.IdEstadoOrden == id);
            if (estadoOrdenCompra == null)
            {
                return NotFound();
            }

            return View(estadoOrdenCompra);
        }

        // POST: EstadoOrdenCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoOrdenCompra = await _context.EstadoOrdenCompras.FindAsync(id);
            if (estadoOrdenCompra != null)
            {
                _context.EstadoOrdenCompras.Remove(estadoOrdenCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoOrdenCompraExists(int id)
        {
            return _context.EstadoOrdenCompras.Any(e => e.IdEstadoOrden == id);
        }
    }
}
